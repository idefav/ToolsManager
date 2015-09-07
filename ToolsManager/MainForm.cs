using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolsManager.Interface;

namespace ToolsManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ToolCompose pluginProvider = new ToolCompose();
            pluginProvider.UpdateEvent += (s, eve) =>
            {
                this.Invoke((Action)(() =>
                {
                    LoadControls(eve.Data);
                }));
            };
            //pluginProvider.Compose();
            LoadControls(pluginProvider.Tests);
        }

        private void LoadControls(Lazy<ITool,IToolModel>[] data)
        {
            Common.Tests = data;
            pAppList.Controls.Clear();
            foreach (var test in data)
            {
                //MessageBox.Show(test.Metadata.Name.ToString());

                //listBox1.Items.Add(test.Metadata.Name);
                AppPreview preview = new AppPreview(test);
                
                preview.AppIcon = test.Value.GetAppIcon();
                pAppList.Controls.Add(preview);

            }
        }

        private void pAppList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            else e.Effect = DragDropEffects.None;
        }

        private void pAppList_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Array aryFiles = ((Array)e.Data.GetData(DataFormats.FileDrop));
                for (int i = 0; i < aryFiles.Length; i++)
                {
                    if (File.Exists(aryFiles.GetValue(i).ToString()))
                    {
                        string dest = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "api",
                            Path.GetFileName(aryFiles.GetValue(i).ToString()));
                        if (File.Exists(dest))
                        {
                            MessageBox.Show(string.Format("[{0}]文件已存在",aryFiles.GetValue(i).ToString()));
                            continue;
                        }
                        File.Copy(aryFiles.GetValue(i).ToString(),dest);
                    }

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
    }
}
