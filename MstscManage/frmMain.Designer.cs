namespace MstscManage
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnJson = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripLabel();
            this.menuMstsc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重启ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvMstsc = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.menuMstsc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMstsc)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.txtSearch,
            this.btnSearch,
            this.btnAdd,
            this.btnJson,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(782, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(48, 22);
            this.toolStripLabel1.Text = "IP/名称";
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 25);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(36, 22);
            this.btnSearch.Text = "搜索";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 22);
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnJson
            // 
            this.btnJson.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnJson.Image = ((System.Drawing.Image)(resources.GetObject("btnJson.Image")));
            this.btnJson.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnJson.Name = "btnJson";
            this.btnJson.Size = new System.Drawing.Size(48, 22);
            this.btnJson.Text = "源文件";
            this.btnJson.Click += new System.EventHandler(this.btnJson_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.ForeColor = System.Drawing.Color.Gray;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(56, 22);
            this.toolStripButton1.Text = "双击连接";
            // 
            // menuMstsc
            // 
            this.menuMstsc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连接ToolStripMenuItem,
            this.开机ToolStripMenuItem,
            this.重启ToolStripMenuItem,
            this.关机ToolStripMenuItem});
            this.menuMstsc.Name = "menuMstsc";
            this.menuMstsc.Size = new System.Drawing.Size(101, 92);
            // 
            // 连接ToolStripMenuItem
            // 
            this.连接ToolStripMenuItem.Name = "连接ToolStripMenuItem";
            this.连接ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.连接ToolStripMenuItem.Text = "连接";
            // 
            // 开机ToolStripMenuItem
            // 
            this.开机ToolStripMenuItem.Name = "开机ToolStripMenuItem";
            this.开机ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.开机ToolStripMenuItem.Text = "重启";
            // 
            // 重启ToolStripMenuItem
            // 
            this.重启ToolStripMenuItem.Name = "重启ToolStripMenuItem";
            this.重启ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.重启ToolStripMenuItem.Text = "开机";
            // 
            // 关机ToolStripMenuItem
            // 
            this.关机ToolStripMenuItem.Name = "关机ToolStripMenuItem";
            this.关机ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关机ToolStripMenuItem.Text = "关机";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvMstsc);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Size = new System.Drawing.Size(782, 398);
            this.splitContainer1.SplitterDistance = 367;
            this.splitContainer1.TabIndex = 3;
            // 
            // dgvMstsc
            // 
            this.dgvMstsc.AllowUserToAddRows = false;
            this.dgvMstsc.AllowUserToDeleteRows = false;
            this.dgvMstsc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMstsc.BackgroundColor = System.Drawing.Color.White;
            this.dgvMstsc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMstsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMstsc.Location = new System.Drawing.Point(0, 0);
            this.dgvMstsc.MultiSelect = false;
            this.dgvMstsc.Name = "dgvMstsc";
            this.dgvMstsc.ReadOnly = true;
            this.dgvMstsc.RowTemplate.Height = 23;
            this.dgvMstsc.Size = new System.Drawing.Size(782, 367);
            this.dgvMstsc.TabIndex = 0;
            this.dgvMstsc.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMstsc_CellContentClick);
            this.dgvMstsc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMstsc_CellDoubleClick);
            this.dgvMstsc.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvMstsc_RowPostPaint);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 423);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "远程桌面管理工具";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuMstsc.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMstsc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ContextMenuStrip menuMstsc;
        private System.Windows.Forms.ToolStripMenuItem 连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重启ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关机ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvMstsc;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnJson;
        private System.Windows.Forms.ToolStripLabel toolStripButton1;
    }
}