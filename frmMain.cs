using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PTManager
{
    public partial class frmMain : Form
    {
        private string SETTINGS_PATH = Application.StartupPath + "\\settings.ini";
        public frmMain()
        {
            InitializeComponent();

            if (!File.Exists(SETTINGS_PATH))
            {
                File.Create(SETTINGS_PATH).Close();
            }
        }

        private void lstApps_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void lstApps_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, true);
                AddToList(s.FirstOrDefault());
            }
        }

        void AddToList(string filePath)
        {
            lstApps.Items.Add(filePath);
            SaveToIniFile(filePath);
        }

        void SaveToIniFile(string filePath)
        {
            File.AppendAllText(SETTINGS_PATH,filePath + Environment.NewLine);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lstApps.Items.Clear();
            if (File.Exists(SETTINGS_PATH))
            {
                lstApps.Items.AddRange(File.ReadAllLines(SETTINGS_PATH));
            }
        }

        private void btnClearDB_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection =
                    new MySqlConnection("Server=localhost;Database=pricetracking;Uid=root;Pwd=toor;");
                if (connection.State == ConnectionState.Open)
                {
                    MySqlCommand truncatePrices = new MySqlCommand("TRUNCATE TABLE prices",connection);
                    truncatePrices.ExecuteNonQuery();

                    MySqlCommand truncateHistory = new MySqlCommand("TRUNCATE TABLE history", connection);
                    truncateHistory.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnStartAll_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < lstApps.Items.Count; i++)
                {
                    ProcessStartInfo pInfo = new ProcessStartInfo();
                    pInfo.FileName = lstApps.Items[i].ToString();
                    pInfo.WorkingDirectory = Path.GetDirectoryName(lstApps.Items[i].ToString());
                    Process.Start(pInfo);
                }
            });
        }

        private void lstApps_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lstApps.SelectedIndex != -1)
                {
                    var lines = File.ReadAllLines(SETTINGS_PATH).ToArray();
                    File.WriteAllText(SETTINGS_PATH,String.Empty);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i] != lstApps.Items[lstApps.SelectedIndex].ToString())
                        {
                            SaveToIniFile(lines[i]);
                        }
                    }

                    lstApps.Items.RemoveAt(lstApps.SelectedIndex);
                    lstApps.Refresh();
                }
            }
        }
    }
}
