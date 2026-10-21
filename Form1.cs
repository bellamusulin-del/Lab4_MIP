using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_MIP
{
    public partial class Form1 : Form
    {
        private static readonly string logFile =
            Path.Combine(Application.StartupPath, "events.log");

        private static readonly object logLock = new object();

        private List<string> blockedKeywords = new List<string>();

        private SQLiteHandler db = new SQLiteHandler();

        public Form1()
        {
            InitializeComponent();

            Trace.Listeners.Add(new TextWriterTraceListener(logFile));
            Trace.AutoFlush = true;

            db.ConnectToDb();

            FormClosed += Form1_FormClosed;
        }

        private void LogEvent(string message)
        {
            string logMessage =
                $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} - {message}";

            Task.Run(() =>
            {
                lock (logLock)
                {
                    Trace.WriteLine(logMessage);
                }
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                blockedKeywords = db.GetAllKeywords();

                keywords_combo.Items.Clear();

                foreach (string keyword in blockedKeywords)
                {
                    keywords_combo.Items.Add(keyword);
                }

                LogEvent("Program elindult");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Nem sikerult betolteni a kulcsszavakat: " + ex.Message);
            }
        }

        private void navigate_btn_Click(object sender, EventArgs e)
        {
            LogEvent("Navigate gomb megnyomva");
            webBrowser1.Navigate(text_box.Text);
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
                LogEvent("Back gomb megnyomva");
            }
        }

        private void forward_btn_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
                LogEvent("Forward gomb megnyomva");
            }
        }

        private void home_btn_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
            LogEvent("Home gomb megnyomva");
        }

        private void text_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser1.Navigate(text_box.Text);
                LogEvent("Enter megnyomva a URL mezoben");
                e.SuppressKeyPress = true;
            }
        }

        private void text_box_Click(object sender, EventArgs e)
        {
        }

        private void webBrowser1_Navigating(
            object sender, WebBrowserNavigatingEventArgs e)
        {
            string url = e.Url.ToString();

            bool blocked = blockedKeywords.Any(
                keyword => url.IndexOf(
                    keyword,
                    StringComparison.OrdinalIgnoreCase) >= 0);

            if (blocked)
            {
                e.Cancel = true;

                LogEvent("Tiltott oldal blokkolva: " + url);

                MessageBox.Show(
                    "Az oldal elerese blokkolva van!",
                    "Blokkolas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void add_keyword_btn_Click(object sender, EventArgs e)
        {
            using (KeywordForm form = new KeywordForm())
            {
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string keyword = form.Keyword;

                bool exists = blockedKeywords.Any(
                    k => k.Equals(
                        keyword,
                        StringComparison.OrdinalIgnoreCase));

                if (exists)
                {
                    MessageBox.Show(
                        "Ez a kulcsszo mar szerepel a listaban!");

                    return;
                }

                try
                {
                    db.InsertKeyword(keyword);

                    blockedKeywords.Add(keyword);
                    keywords_combo.Items.Add(keyword);

                    LogEvent("Uj tiltott kulcsszo hozzaadva: " + keyword);
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(
                        "Nem sikerult elmenteni a kulcsszot: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Hiba tortent: " + ex.Message);
                }
            }
        }

        private void toolStrip1_ItemClicked(
            object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void webBrowser1_DocumentCompleted(
            object sender, WebBrowserDocumentCompletedEventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.DisconnectFromDb();

            Trace.Flush();
            Trace.Close();
        }
    }
}


