namespace WindowsFormsApp1
{
    partial class Form_Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.기준정보ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Form01_ItemMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.Form02_Material = new System.Windows.Forms.ToolStripMenuItem();
            this.발주관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Form03_Order = new System.Windows.Forms.ToolStripMenuItem();
            this.Form05_Wearing = new System.Windows.Forms.ToolStripMenuItem();
            this.현황관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Form04_OrderList = new System.Windows.Forms.ToolStripMenuItem();
            this.Form06_WearingList = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSButton = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnEnd = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stsFormName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsNowDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.myTabControlr = new Common.MyTabControlr();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.기준정보ToolStripMenuItem,
            this.발주관리ToolStripMenuItem,
            this.현황관리ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 기준정보ToolStripMenuItem
            // 
            this.기준정보ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Form01_ItemMaster,
            this.Form02_Material});
            this.기준정보ToolStripMenuItem.Name = "기준정보ToolStripMenuItem";
            this.기준정보ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.기준정보ToolStripMenuItem.Text = "기준정보";
            this.기준정보ToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStripMenuItem_DropDownItemClicked);
            // 
            // Form01_ItemMaster
            // 
            this.Form01_ItemMaster.Name = "Form01_ItemMaster";
            this.Form01_ItemMaster.Size = new System.Drawing.Size(122, 22);
            this.Form01_ItemMaster.Text = "품목관리";
            // 
            // Form02_Material
            // 
            this.Form02_Material.Name = "Form02_Material";
            this.Form02_Material.Size = new System.Drawing.Size(122, 22);
            this.Form02_Material.Text = "자재관리";
            // 
            // 발주관리ToolStripMenuItem
            // 
            this.발주관리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Form03_Order,
            this.Form05_Wearing});
            this.발주관리ToolStripMenuItem.Name = "발주관리ToolStripMenuItem";
            this.발주관리ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.발주관리ToolStripMenuItem.Text = "재고관리";
            this.발주관리ToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStripMenuItem_DropDownItemClicked);
            // 
            // Form03_Order
            // 
            this.Form03_Order.Name = "Form03_Order";
            this.Form03_Order.Size = new System.Drawing.Size(122, 22);
            this.Form03_Order.Text = "발주관리";
            // 
            // Form05_Wearing
            // 
            this.Form05_Wearing.Name = "Form05_Wearing";
            this.Form05_Wearing.Size = new System.Drawing.Size(122, 22);
            this.Form05_Wearing.Text = "입고관리";
            // 
            // 현황관리ToolStripMenuItem
            // 
            this.현황관리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Form04_OrderList,
            this.Form06_WearingList});
            this.현황관리ToolStripMenuItem.Name = "현황관리ToolStripMenuItem";
            this.현황관리ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.현황관리ToolStripMenuItem.Text = "현황관리";
            this.현황관리ToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ToolStripMenuItem_DropDownItemClicked);
            // 
            // Form04_OrderList
            // 
            this.Form04_OrderList.Name = "Form04_OrderList";
            this.Form04_OrderList.Size = new System.Drawing.Size(122, 22);
            this.Form04_OrderList.Text = "발주내역";
            // 
            // Form06_WearingList
            // 
            this.Form06_WearingList.Name = "Form06_WearingList";
            this.Form06_WearingList.Size = new System.Drawing.Size(122, 22);
            this.Form06_WearingList.Text = "입고내역";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSButton,
            this.btnClose,
            this.btnEnd});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 72);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSButton
            // 
            this.TSButton.Image = global::WindowsFormsApp1.Properties.Resources.BtnSearch;
            this.TSButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TSButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSButton.Name = "TSButton";
            this.TSButton.Size = new System.Drawing.Size(54, 69);
            this.TSButton.Text = "조회";
            this.TSButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TSButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TSButton.Click += new System.EventHandler(this.TSButton_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::WindowsFormsApp1.Properties.Resources.BtcExit;
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 69);
            this.btnClose.Text = "닫기";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.TSButton_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Image = global::WindowsFormsApp1.Properties.Resources.BtnClose;
            this.btnEnd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(54, 69);
            this.btnEnd.Text = "종료";
            this.btnEnd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsFormName,
            this.toolStripStatusLabel2,
            this.stsUserName,
            this.stsNowDateTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 421);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 29);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stsFormName
            // 
            this.stsFormName.AutoSize = false;
            this.stsFormName.Name = "stsFormName";
            this.stsFormName.Size = new System.Drawing.Size(200, 24);
            this.stsFormName.Text = "HomeName";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(235, 24);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // stsUserName
            // 
            this.stsUserName.AutoSize = false;
            this.stsUserName.Name = "stsUserName";
            this.stsUserName.Size = new System.Drawing.Size(150, 24);
            // 
            // stsNowDateTime
            // 
            this.stsNowDateTime.AutoSize = false;
            this.stsNowDateTime.Name = "stsNowDateTime";
            this.stsNowDateTime.Size = new System.Drawing.Size(200, 24);
            this.stsNowDateTime.Text = "NowDateTime";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // myTabControlr
            // 
            this.myTabControlr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTabControlr.Location = new System.Drawing.Point(0, 96);
            this.myTabControlr.Name = "myTabControlr";
            this.myTabControlr.SelectedIndex = 0;
            this.myTabControlr.Size = new System.Drawing.Size(800, 354);
            this.myTabControlr.TabIndex = 1;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.myTabControlr);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Main";
            this.Text = "원자재관리";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private Common.MyTabControlr myTabControlr;
        private System.Windows.Forms.ToolStripMenuItem 기준정보ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Form01_ItemMaster;
        private System.Windows.Forms.ToolStripMenuItem Form02_Material;
        private System.Windows.Forms.ToolStripMenuItem 발주관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Form03_Order;
        private System.Windows.Forms.ToolStripMenuItem Form05_Wearing;
        private System.Windows.Forms.ToolStripMenuItem 현황관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Form04_OrderList;
        private System.Windows.Forms.ToolStripMenuItem Form06_WearingList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnEnd;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stsFormName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel stsUserName;
        private System.Windows.Forms.ToolStripStatusLabel stsNowDateTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton TSButton;
    }
}