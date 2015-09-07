namespace ToolsManager
{
    partial class AppPreview
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.lbName = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pbIcon
            // 
            this.pbIcon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbIcon.Location = new System.Drawing.Point(0, 0);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(65, 41);
            this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbIcon.TabIndex = 0;
            this.pbIcon.TabStop = false;
            this.pbIcon.Click += new System.EventHandler(this.pbIcon_Click);
            this.pbIcon.DoubleClick += new System.EventHandler(this.pbIcon_DoubleClick);
            this.pbIcon.MouseLeave += new System.EventHandler(this.lbName_MouseLeave);
            this.pbIcon.MouseHover += new System.EventHandler(this.AppPreview_MouseHover);
            // 
            // lbName
            // 
            this.lbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbName.Location = new System.Drawing.Point(0, 41);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(65, 25);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "label1";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbName.MouseLeave += new System.EventHandler(this.lbName_MouseLeave);
            this.lbName.MouseHover += new System.EventHandler(this.AppPreview_MouseHover);
            // 
            // AppPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pbIcon);
            this.Name = "AppPreview";
            this.Size = new System.Drawing.Size(65, 66);
            this.Load += new System.EventHandler(this.AppPreview_Load);
            this.MouseHover += new System.EventHandler(this.AppPreview_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
