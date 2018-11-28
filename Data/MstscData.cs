using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Common;
namespace Data
{
    public class MstscData
    {
        public static string FileUrl
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + "/mstsc.txt";

            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="mstsc"></param>
        public static void Update(Mstsc mstsc)
        {
            var list = GetAll();
            var model = list.FirstOrDefault(d => d.Id == mstsc.Id);
            if (model == null)
            {
                throw new Exception($"IP地址{mstsc.IPAddress}不存在");
            }
            model.Name = mstsc.Name;
            model.IPAddress = mstsc.IPAddress;
            model.UserName = mstsc.UserName;
            model.Password = mstsc.Password;
            model.NetType = mstsc.NetType;
            File.WriteAllText(FileUrl, list.ToJson(), Encoding.Default);
        }
        public static List<Mstsc> GetAll()
        {
            if (!File.Exists(FileUrl))
            {
                return new List<Mstsc>();
            }
            var txt = File.ReadAllText(FileUrl, Encoding.Default);
            return txt.ToEntity<List<Mstsc>>().OrderByDescending(d => d.CreateTime).ToList();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(string id)
        {
            var list = GetAll();
            var model = list.FirstOrDefault(d => d.Id == id);
            if (model != null)
            {
                list.Remove(model);
                File.WriteAllText(FileUrl, list.ToJson(), Encoding.Default);
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="mstsc"></param>
        public static void Add(Mstsc mstsc)
        {
            var list = GetAll();
            if (list.Count(d => d.IPAddress == mstsc.IPAddress) > 0)
            {
                throw new Exception($"IP地址{mstsc.IPAddress}已存在");
            }
            list.Add(mstsc);
            File.WriteAllText(FileUrl, list.ToJson(), Encoding.Default);
        }
    }
}
