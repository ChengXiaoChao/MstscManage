using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Data;

namespace MstscManage
{
    public partial class frmAddOrEdit : Form
    {
        public frmAddOrEdit()
        {
            InitializeComponent();
        }
        public string Id { get; set; }
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                var list = Controls.Cast<Control>().OrderBy(d => d.TabIndex);
                foreach (var item in list)
                {
                    if (item is TextBox)
                    {
                        var txt = item as TextBox;
                        if (string.IsNullOrEmpty(txt.Text.Trim()))
                        {
                            txt.Focus();
                            lblMsg.Text = "请输入该项";
                            return;
                        }
                    }
                }
                var model = new Mstsc()
                {
                    IPAddress = txtIPAddress.Text.Trim(),
                    Name = txtName.Text.Trim(),
                    UserName = txtUserName.Text.Trim(),
                    Password = txtPassword.Text.Trim(),
                    NetType = (Enums.EnumNetType)cboNetType.SelectedValue.ToString().ToInt(),
                };
                if (!string.IsNullOrEmpty(Id))
                {
                    //修改
                    model.Id = Id;
                    MstscData.Update(model);
                }
                else
                {
                    //添加
                    model.Id = Guid.NewGuid().ToString();
                    model.CreateTime = DateTime.Now;
                    MstscData.Add(model);
                }
                MstscHelper.WriteRDPFile(model.RDPFileName, model.IPAddress, model.UserName, model.Password);
                MessageBox.Show("保存成功");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            Init();
        }
        void Init()
        {
            //绑定下拉
            var list = new List<object>();
            foreach (var item in Enum.GetValues(typeof(Enums.EnumNetType)))
            {
                list.Add(new { Id = (int)item, Name = item.ToString() });
            }
            cboNetType.DataSource = list;
            cboNetType.DisplayMember = "Name";
            cboNetType.ValueMember = "Id";
            this.Text = "添加服务器信息";
            if (!string.IsNullOrEmpty(Id))
            {
                this.Text = "修改服务器信息";
                var model = MstscData.GetAll().FirstOrDefault(d => d.Id == Id);
                if (model != null)
                {
                    txtIPAddress.Text = model.IPAddress;
                    txtName.Text = model.Name;
                    txtUserName.Text = model.UserName;
                    txtPassword.Text = model.Password;
                    cboNetType.SelectedValue = (int)model.NetType;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
