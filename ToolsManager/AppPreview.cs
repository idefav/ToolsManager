using System;
using System.Drawing;
using System.Windows.Forms;
using ToolsManager.Interface;

namespace ToolsManager
{
    public partial class AppPreview : UserControl
    {
        public AppPreview()
        {
            InitializeComponent();
        }

        public AppPreview(Lazy<ITool, IToolModel> model)
        {
            Model = model;
            InitializeComponent();
        }

        public string FileName { get; set; }

        public Lazy<ITool, IToolModel> Model { get; set; }
       
        public Image AppIcon { get; set; }

        private void pbIcon_Click(object sender, EventArgs e)
        {
            
        }

        private void AppPreview_Load(object sender, EventArgs e)
        {
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.ToolTipTitle = Model.Metadata.Name;
            toolTip1.SetToolTip(pbIcon, string.Format("时间:{4}\n作者:{3}\n公司:{2}\n版本:{0}\n描述:{1}",Model.Metadata.Version,Model.Metadata.Description,Model.Metadata.Company,Model.Metadata.Author,Model.Metadata.Time));
            lbName.Text = Model.Metadata.Name;
            if (AppIcon != null)
                pbIcon.Image = AppIcon;
            else
            {
                pbIcon.Image = Properties.Resources.AppIcon;
            }

        }

        private void AppPreview_MouseHover(object sender, EventArgs e)
        {
            this.BackColor=Color.Silver;
        }

        private void lbName_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
        }

        private void pbIcon_DoubleClick(object sender, EventArgs e)
        {
            if (Model != null)
            {
                Model.Value.Run();
            }
        }
    }


}
