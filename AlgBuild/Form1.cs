using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using AlgBuild.Engine;
using AlgBuild.PathSettings;

namespace AlgBuild
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var executor = new Executor();
            executor.RunSettings();
        }

        private void WriteTestSettings()
        {
            var sets = new PathSetting()
            {
                PathSettings =
                    new List<PathSettingItem>
                                       {
                                           new PathSettingItem
                                               {
                                                   Name = "CompilExe",
                                                   VersionType = VersionType.All,
                                                   Lang = Lang.Ru,
                                                   SourcePath = "sf",
                                                   TargetPath = "",
                                                   Directories = new List<string>{"a","b"},
                                                   Files = new List<string>{"dfa","bdf"},
                                               }
                                       }
            };

            var fileStream = System.IO.File.CreateText("Settings.txt");

            var ser = new XmlSerializer(typeof(PathSetting));
            ser.Serialize(fileStream, sets);
        }
    }
}
