using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace SearchAlgorithmBenchmarker
{
    public partial class ConfigSettingsWindow : Form
    {
        private Color fontColour;
        private int fontSize;

        public ConfigSettingsWindow()
        {
            InitializeComponent();
            txtOutputFile.Text = ConfigurationManager.AppSettings.Get("ResultOutputDirectory");
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            //ConfigurationManager.AppSettings.Set("ResultOutputDirectory", txtOutputFile.Text);
            //ConfigurationManager.AppSettings.Set("ReadoutFontSize", fontSize.ToString());
            //ConfigurationManager.AppSettings.Set("ReadoutFontColor", fontColour.ToArgb().ToString());

            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfg.AppSettings.Settings["ResultOutputDirectory"].Value = txtOutputFile.Text;
            cfg.AppSettings.Settings["ReadoutFontSize"].Value = fontSize.ToString();
            cfg.AppSettings.Settings["ReadoutFontColour"].Value = '#' + fontColour.ToArgb().ToString();

            cfg.Save(ConfigurationSaveMode.Modified, true);

            ConfigurationManager.RefreshSection("appSettings");
        }

        private void cmdBrowseOutput_Click(object sender, EventArgs e)
        {
            if (dlgOutputDirectory.ShowDialog() == DialogResult.OK)
            {
                txtOutputFile.Text = dlgOutputDirectory.SelectedPath;
            }
        }

        private void cbFontColour_SelectedIndexChanged(object sender, EventArgs e)
        {
            // open colour dialog if custom colour selected.
            if (cbFontColour.SelectedIndex == cbFontColour.Items.Count - 1)
            {
                if(dlgFontColour.ShowDialog() == DialogResult.OK)
                {
                    cbFontColour.SelectedItem.Colour = dlgFontColour.Color;
                }
            }
            fontColour = cbFontColour.SelectedValue;
        }

        private void numFontSize_ValueChanged(object sender, EventArgs e)
        {
            fontSize = (int)numFontSize.Value;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfg.AppSettings.Settings["ResultOutputDirectory"].Value = txtOutputFile.Text;
            cfg.AppSettings.Settings["ReadoutFontSize"].Value = fontSize.ToString();
            cfg.AppSettings.Settings["ReadoutFontColour"].Value = '#' + fontColour.ToArgb().ToString();

            cfg.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show("Configuration changes applied.\nPlease note that the font changes won't be applied until the application is restarted.");

            Close();
        }
    }
}
