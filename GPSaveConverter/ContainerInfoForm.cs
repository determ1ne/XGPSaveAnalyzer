using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using GPSaveConverter.Xbox;
using System.Xml.Linq;

namespace GPSaveConverter
{
    public partial class ContainerInfoForm : Form
    {
        public ContainerInfoForm()
        {
            InitializeComponent();
        }

        private void log(string msg)
        {
            if (msg != null)
            {
                tbxLog.Text += DateTime.Now.ToString("G");
                tbxLog.Text += " ";
                tbxLog.Text += msg;
            }
            tbxLog.Text += Environment.NewLine;
        }

        private void analyzeContainerFile(string path)
        {
            log($"Opening container {path}");
            var container = new XboxFileContainer(path);
            log($"File count: {container.fileList.Count}");
            foreach (var cf in container.fileList)
            {
                log($"  * {cf.getFileName()}: {cf.FileID}");
            }
            log(null);
        }


        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (dlgOpenContainer.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            var fName = dlgOpenContainer.FileName;
            analyzeContainerFile(fName);
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            var p = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            p += "\\Packages\\Microsoft.624F8B84B80_8wekyb3d8bbwe\\SystemAppData\\wgs";
            var matcher = new Matcher();
            matcher.AddIncludePatterns(new[] { "**\\**\\container.*" });
            var result = matcher.Execute(new DirectoryInfoWrapper(new DirectoryInfo(p)));
            foreach (var cf in result.Files)
            {
                analyzeContainerFile(Path.Combine(p, cf.Path));
            }
        }
    }
}
