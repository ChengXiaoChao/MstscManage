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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        //ilmerge /targetplatform:v4 /target:winexe /out:远程桌面管理工具.exe MstscManage.exe Common.dll Data.dll Model.dll Newtonsoft.Json.dll
        private void frmMain_Load(object sender, EventArgs e)
        {
            Init();
            Bind();
        }
        void Bind()
        {
            var list = MstscData.GetAll();
            var search = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(d => (d.IPAddress + d.Name).Contains(search)).ToList();
            }
            dgvMstsc.DataSource = list;
        }
        void Init()
        {
            dgvMstsc.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn(){ Name="Id",DataPropertyName="Id",HeaderText="Id",Visible=false },
                new DataGridViewTextBoxColumn(){ Name="Name",DataPropertyName="Name",HeaderText="名称",Width=200 },
                new DataGridViewTextBoxColumn(){ Name="IPAddress",DataPropertyName="IPAddress",HeaderText="IP",Width=120 },
                new DataGridViewTextBoxColumn(){ Name="UserName",DataPropertyName="UserName",HeaderText="账号"},
                new DataGridViewTextBoxColumn(){ Name="Password",DataPropertyName="Password",HeaderText="密码"},
                new DataGridViewTextBoxColumn(){ Name="NetType",DataPropertyName="NetType",HeaderText="类型",Width=55 },
                new DataGridViewTextBoxColumn(){ Name="RDPFileName",DataPropertyName="RDPFileName",HeaderText="RDP文件",Visible=false },
                new DataGridViewTextBoxColumn(){ Name="CreateTime",DataPropertyName="CreateTime",HeaderText="创建时间" },
                //new DataGridViewButtonColumn(){ Name="btnConnection",HeaderText="连接",DefaultCellStyle=new DataGridViewCellStyle(){ NullValue="连接"}},
                new DataGridViewButtonColumn(){ Name="btnUpdate",HeaderText="修改",DefaultCellStyle=new DataGridViewCellStyle(){ NullValue="修改"},Width=60},
                new DataGridViewButtonColumn(){ Name="btnDel",HeaderText="删除",DefaultCellStyle=new DataGridViewCellStyle(){ NullValue="删除"},Width=60},
            });
            dgvMstsc.AutoGenerateColumns = false;
            //dgvMstsc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void dgvMstsc_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //dgv自动编号
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               dgvMstsc.RowHeadersWidth - 4,
               e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                  (e.RowIndex + 1).ToString(),
                   dgvMstsc.RowHeadersDefaultCellStyle.Font,
                   rectangle,
                   dgvMstsc.RowHeadersDefaultCellStyle.ForeColor,
                   TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Bind();
            }
        }

        private void dgvMstsc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    var id = dgvMstsc.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    var fileName = dgvMstsc.Rows[e.RowIndex].Cells["RDPFileName"].Value.ToString();
                    switch (dgvMstsc.Columns[e.ColumnIndex].Name)
                    {
                        case "btnConnection":
                            MstscHelper.ConnectionServer(fileName);
                            break;
                        case "btnUpdate":
                            new frmAddOrEdit() { Id = id }.ShowDialog();
                            Bind();
                            break;
                        case "btnDel":
                            if (MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                MstscData.Delete(id);
                                MstscHelper.DeleteFileByName(fileName);
                                Bind();
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            new frmAddOrEdit().ShowDialog();
            Bind();
        }

        private void dgvMstsc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var fileName = dgvMstsc.Rows[e.RowIndex].Cells["RDPFileName"].Value.ToString();
                MstscHelper.ConnectionServer(fileName);
            }
        }

        private void btnJson_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(MstscData.FileUrl))
            {
                System.Diagnostics.Process.Start(MstscData.FileUrl);
            }
        }
    }
}
