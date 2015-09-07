namespace ToolsManager
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pAppList = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // pAppList
            // 
            this.pAppList.AllowDrop = true;
            this.pAppList.AutoScroll = true;
            this.pAppList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAppList.Location = new System.Drawing.Point(0, 0);
            this.pAppList.Name = "pAppList";
            this.pAppList.Size = new System.Drawing.Size(685, 375);
            this.pAppList.TabIndex = 1;
            this.pAppList.DragDrop += new System.Windows.Forms.DragEventHandler(this.pAppList_DragDrop);
            this.pAppList.DragEnter += new System.Windows.Forms.DragEventHandler(this.pAppList_DragEnter);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 375);
            this.Controls.Add(this.pAppList);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "小工具管理平台";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pAppList;
    }
}

