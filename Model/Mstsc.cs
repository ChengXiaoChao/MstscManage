using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Enums;

namespace Model
{
    public class Mstsc
    {
        /// <summary>
        /// GUID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// IP地址 含端口
        /// </summary>
        public string IPAddress { get; set; }
        /// <summary>
        /// 服务器名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 内网 外网
        /// </summary>
        public EnumNetType NetType { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// RDP文件名
        /// </summary>
        public string RDPFileName
        {
            get
            {
                return IPAddress.Replace(":", "_") + ".rdp";
            }
            set { }
        }

    }
}
