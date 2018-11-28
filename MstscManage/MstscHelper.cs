using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MstscManage
{
    public class MstscHelper
    {
        public static void ConnectionServer(string filename)
        {
            var rdpFileName = FileDirectory + filename;
            if (File.Exists(rdpFileName))
            {
                System.Diagnostics.Process.Start(rdpFileName);
            }
            else
            {
                throw new Exception($"{filename}文件不存在，请修改保存后再试试");
            }
        }
        public static string FileDirectory
        {
            get
            {
                var dir = AppDomain.CurrentDomain.BaseDirectory + "/RDP/";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                return dir;
            }
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName"></param>
        public static void DeleteFileByName(string fileName)
        {
            var fullFileName = FileDirectory + fileName;
            DeleteRDPFileIfExist(fullFileName);
        }
        /// <summary>
        /// 删除文件 完整文件名.rdp
        /// </summary>
        /// <param name="fullFileName"></param>
        public static void DeleteRDPFileIfExist(string fullFileName)
        {
            if (File.Exists(fullFileName))
            {
                File.Delete(fullFileName);
            }
        }
        /// <summary>
        /// 生成RDP文件
        /// </summary>
        /// <param name="filename">文件名.rdp</param>
        /// <param name="address">IP地址 包含端口号 192.168.1.1:1234</param>
        /// <param name="username">账号</param>
        /// <param name="password">密码 未加密的密码</param>
        public static void WriteRDPFile(string filename, string address, string username, string password)
        {
            var fullFileName = FileDirectory + filename;
            DeleteRDPFileIfExist(fullFileName);
            using (StreamWriter streamWriter = new StreamWriter(fullFileName, true))
            {
                streamWriter.WriteLine("screen mode id:i:2");
                streamWriter.WriteLine("desktopwidth:i:0");
                streamWriter.WriteLine("desktopheight:i:0");
                streamWriter.WriteLine("session bpp:i:32");
                streamWriter.WriteLine("winposstr:s:0,1,0,0,1234,792");
                streamWriter.WriteLine("compression:i:1");
                streamWriter.WriteLine("keyboardhook:i:2");
                streamWriter.WriteLine("audiocapturemode:i:0");
                streamWriter.WriteLine("videoplaybackmode:i:1");
                streamWriter.WriteLine("connection type:i:6");
                streamWriter.WriteLine("displayconnectionbar:i:1");
                streamWriter.WriteLine("disable wallpaper:i:1");
                streamWriter.WriteLine("allow font smoothing:i:1");
                streamWriter.WriteLine("allow desktop composition:i:1");
                streamWriter.WriteLine("disable full window drag:i:1");
                streamWriter.WriteLine("disable menu anims:i:1");
                streamWriter.WriteLine("disable themes:i:1");
                streamWriter.WriteLine("disable cursor setting:i:0");
                streamWriter.WriteLine("bitmapcachepersistenable:i:0");
                streamWriter.WriteLine("full address:s:" + address);
                streamWriter.WriteLine("audiomode:i:0");
                streamWriter.WriteLine("redirectprinters:i:0");
                streamWriter.WriteLine("redirectcomports:i:0");
                streamWriter.WriteLine("redirectsmartcards:i:0");
                streamWriter.WriteLine("redirectclipboard:i:1");
                streamWriter.WriteLine("redirectposdevices:i:0");
                streamWriter.WriteLine("redirectdirectx:i:1");
                streamWriter.WriteLine("drivestoredirect:s:");
                streamWriter.WriteLine("autoreconnection enabled:i:1");
                streamWriter.WriteLine("authentication level:i:2");
                streamWriter.WriteLine("prompt for credentials:i:0");
                streamWriter.WriteLine("negotiate security layer:i:1");
                streamWriter.WriteLine("remoteapplicationmode:i:0");
                streamWriter.WriteLine("alternate shell:s:");
                streamWriter.WriteLine("shell working directory:s:");
                streamWriter.WriteLine("gatewayhostname:s:");
                streamWriter.WriteLine("gatewayusagemethod:i:4");
                streamWriter.WriteLine("gatewaycredentialssource:i:4");
                streamWriter.WriteLine("gatewayprofileusagemethod:i:0");
                streamWriter.WriteLine("promptcredentialonce:i:1");
                streamWriter.WriteLine("use redirection server name:i:0");
                streamWriter.WriteLine("use multimon:i:0");
                if (!string.IsNullOrEmpty(username))
                {
                    streamWriter.WriteLine("username:s:" + username);
                }
                if (!string.IsNullOrEmpty(password))
                {
                    var pwd = Encrypt(password);
                    streamWriter.WriteLine("password 51:b:" + pwd);
                }
            }
        }
        /// <summary>
        /// 密码加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Encrypt(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            DATA_BLOB dATA_BLOB = default(DATA_BLOB);
            DATA_BLOB dATA_BLOB2 = default(DATA_BLOB);
            DATA_BLOB dATA_BLOB3 = default(DATA_BLOB);
            dATA_BLOB.cbData = bytes.Length;
            dATA_BLOB.pbData = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, dATA_BLOB.pbData, bytes.Length);
            dATA_BLOB3.cbData = 0;
            dATA_BLOB3.pbData = IntPtr.Zero;
            dATA_BLOB2.cbData = 0;
            dATA_BLOB2.pbData = IntPtr.Zero;
            CRYPTPROTECT_PROMPTSTRUCT cRYPTPROTECT_PROMPTSTRUCT = new CRYPTPROTECT_PROMPTSTRUCT
            {
                cbSize = Marshal.SizeOf(typeof(CRYPTPROTECT_PROMPTSTRUCT)),
                dwPromptFlags = 0,
                hwndApp = IntPtr.Zero,
                szPrompt = null
            };
            if (CryptProtectData(ref dATA_BLOB, "psw", ref dATA_BLOB3, IntPtr.Zero, ref cRYPTPROTECT_PROMPTSTRUCT, 1, ref dATA_BLOB2))
            {
                if (IntPtr.Zero != dATA_BLOB.pbData)
                {
                    Marshal.FreeHGlobal(dATA_BLOB.pbData);
                }
                if (IntPtr.Zero != dATA_BLOB3.pbData)
                {
                    Marshal.FreeHGlobal(dATA_BLOB3.pbData);
                }
                byte[] array = new byte[dATA_BLOB2.cbData];
                Marshal.Copy(dATA_BLOB2.pbData, array, 0, dATA_BLOB2.cbData);
                return BitConverter.ToString(array).Replace("-", string.Empty);
            }
            return string.Empty;

        }
        #region 密码加密
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct DATA_BLOB
        {
            public int cbData;

            public IntPtr pbData;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct CRYPTPROTECT_PROMPTSTRUCT
        {
            public int cbSize;

            public int dwPromptFlags;

            public IntPtr hwndApp;

            public string szPrompt;
        }
        [DllImport("crypt32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool CryptProtectData(ref DATA_BLOB pDataIn, string szDataDescr, ref DATA_BLOB pOptionalEntropy, IntPtr pvReserved, ref CRYPTPROTECT_PROMPTSTRUCT pPromptStruct, int dwFlags, ref DATA_BLOB pDataOut);
        #endregion
    }
}
