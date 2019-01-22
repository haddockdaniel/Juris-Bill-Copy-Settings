using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Globalization;
using Gizmox.Controls;
using JDataEngine;
using JurisAuthenticator;
using JurisUtilityBase.Properties;
using System.Data.OleDb;

namespace JurisUtilityBase
{
    public partial class UtilityBaseMain : Form
    {
        #region Private  members

        private JurisUtility _jurisUtility;

        #endregion

        #region Public properties

        public string CompanyCode { get; set; }

        public string JurisDbName { get; set; }

        public string JBillsDbName { get; set; }

        public int FldClient { get; set; }

        public int FldMatter { get; set; }

        private ListViewColumnSorter lvwColumnSorter1;

        #endregion

        #region Constructor

        public UtilityBaseMain()
        {
            InitializeComponent();
            _jurisUtility = new JurisUtility();

            listView2.MultiSelect = true;
            listView2.CheckBoxes = true;
            listView2.FullRowSelect = true;
            setColumns();
            lvwColumnSorter1 = new ListViewColumnSorter();
            this.listView2.ListViewItemSorter = lvwColumnSorter1;
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
        }

        #endregion

        #region Public methods

        public void setColumns()
        {
            listView2.Columns.Add("Client ID", 80, HorizontalAlignment.Left);
            listView2.Columns.Add("Client Code", 75, HorizontalAlignment.Left);
            listView2.Columns.Add("Client Name", 350, HorizontalAlignment.Left);
        }



        public void LoadCompanies()
        {
            var companies = _jurisUtility.Companies.Cast<object>().Cast<Instance>().ToList();
//            listBoxCompanies.SelectedIndexChanged -= listBoxCompanies_SelectedIndexChanged;
            listBoxCompanies.ValueMember = "Code";
            listBoxCompanies.DisplayMember = "Key";
            listBoxCompanies.DataSource = companies;
//            listBoxCompanies.SelectedIndexChanged += listBoxCompanies_SelectedIndexChanged;
            var defaultCompany = companies.FirstOrDefault(c => c.Default == Instance.JurisDefaultCompany.jdcJuris);
            if (companies.Count > 0)
            {
                listBoxCompanies.SelectedItem = defaultCompany ?? companies[0];
            }
        }

        #endregion

        #region MainForm events

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void listBoxCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_jurisUtility.DbOpen)
            {
                _jurisUtility.CloseDatabase();
            }
            CompanyCode = "Company" + listBoxCompanies.SelectedValue;
            _jurisUtility.SetInstance(CompanyCode);
            JurisDbName = _jurisUtility.Company.DatabaseName;
            JBillsDbName = "JBills" + _jurisUtility.Company.Code;
            _jurisUtility.OpenDatabase();
            if (_jurisUtility.DbOpen)
            {
                ///GetFieldLengths();
            }

            listView2.Clear();
            setColumns();
            string SQLTkpr = "SELECT [CliSysNbr] ,right([CliCode], 8) as CliCode,[CliNickName] FROM [Client]";
            DataSet myRSTkpr = _jurisUtility.RecordsetFromSQL(SQLTkpr);

            if (myRSTkpr.Tables[0].Rows.Count == 0)
                MessageBox.Show("There are no open clients in this database", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                
                 foreach (DataRow dr in myRSTkpr.Tables[0].Rows)
                {
                     string offsetClient = "";
                     if (dr["CliCode"].ToString().Trim().Length < 8) //ensure they are all same number of digits
                     {
                         int diff = 8 - dr["CliCode"].ToString().Trim().Length;
                         for (int a = 0; a < diff; a++)
                             offsetClient = offsetClient + "0";
                     }


                    ListViewItem lvi = new ListViewItem(dr["CliSysNbr"].ToString());
                    lvi.SubItems.Add(offsetClient + dr["CliCode"].ToString().Trim());
                    lvi.SubItems.Add(dr["CliNickName"].ToString()); 
                    listView2.Items.Add(lvi);

                }
            }


        }



        #endregion

        #region Private methods

        private void DoDaFix()
        {
            try //ensures number of copies is an int. If not, go to Catch block
            {
                Int32.Parse(textBox2.Text);
                string selectedClients = "";
                foreach (ListViewItem eachItem in listView2.CheckedItems)
                {
                    selectedClients = selectedClients + eachItem.SubItems[0].Text + ","; //get the client id from each item selected
                }

                selectedClients = selectedClients.TrimEnd(',');
                if (!String.IsNullOrEmpty(selectedClients))
                {
                    DialogResult dialog = MessageBox.Show("This tool will update all BillCopy Settings for all matters associated" + "\r\n" + "with the selected clients. This cannot be undone. Are you sure?", "Confirmation Dialog", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == System.Windows.Forms.DialogResult.Yes)
                    {
                        //get matterIDs from clients
                        string selectedMatters = "";
                        string SQL = "SELECT MatSysNbr FROM Matter where MatCliNbr in (" + selectedClients + ") and MatStatusFlag <> 'C'";
                        DataSet myRSTkpr = _jurisUtility.RecordsetFromSQL(SQL);
                        foreach (DataRow dr in myRSTkpr.Tables[0].Rows)
                        {
                            selectedMatters = selectedMatters + dr["MatSysNbr"].ToString() + ",";
                        }
                        selectedMatters = selectedMatters.TrimEnd(',');

                        //now do the damn thing
                        SQL = "update billcopy set BilCpyNbrOfCopies=" + textBox2.Text + ", bilcpyprintformat=" + comboBox1.SelectedIndex + ", bilcpyemailformat=" + comboBox3.SelectedIndex + ", bilcpyexportformat=" + comboBox4.SelectedIndex + ", BilCpyARFormat=" + comboBox2.SelectedIndex;

                        if (!String.IsNullOrEmpty(textBox1.Text)) //if they entered a comment, add it
                            SQL = SQL + ", BilCpyComment = '" + textBox1.Text + "' from billto inner join matter on matbillto=billtosysnbr where bilcpybillto=billtosysnbr and matsysnbr in (" + selectedMatters + ")";
                        else
                            SQL = SQL + " from billto inner join matter on matbillto=billtosysnbr where bilcpybillto=billtosysnbr and matsysnbr in (" + selectedMatters + ")";

                        _jurisUtility.ExecuteNonQueryCommand(0, SQL);
                        UpdateStatus("Selected matters updated.", 1, 1);

                        MessageBox.Show("The process is complete", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                else //there were no matters selected
                    MessageBox.Show("Please select at least one client", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex1)
            {
                MessageBox.Show("Number of copies entered is not a valid integer", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private bool VerifyFirmName()
        {
            //    Dim SQL     As String
            //    Dim rsDB    As ADODB.Recordset
            //
            //    SQL = "SELECT CASE WHEN SpTxtValue LIKE '%firm name%' THEN 'Y' ELSE 'N' END AS Firm FROM SysParam WHERE SpName = 'FirmName'"
            //    Cmd.CommandText = SQL
            //    Set rsDB = Cmd.Execute
            //
            //    If rsDB!Firm = "Y" Then
            return true;
            //    Else
            //        VerifyFirmName = False
            //    End If

        }

        private bool FieldExistsInRS(DataSet ds, string fieldName)
        {

            foreach (DataColumn column in ds.Tables[0].Columns)
            {
                if (column.ColumnName.Equals(fieldName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }


        private static bool IsDate(String date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool IsNumeric(object Expression)
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum; 
        }

        private void WriteLog(string comment)
        {
            var sql =
                string.Format("Insert Into UtilityLog(ULTimeStamp,ULWkStaUser,ULComment) Values('{0}','{1}', '{2}')",
                    DateTime.Now, GetComputerAndUser(), comment);
            _jurisUtility.ExecuteNonQueryCommand(0, sql);
        }

        private string GetComputerAndUser()
        {
            var computerName = Environment.MachineName;
            var windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var userName = (windowsIdentity != null) ? windowsIdentity.Name : "Unknown";
            return computerName + "/" + userName;
        }

        /// <summary>
        /// Update status bar (text to display and step number of total completed)
        /// </summary>
        /// <param name="status">status text to display</param>
        /// <param name="step">steps completed</param>
        /// <param name="steps">total steps to be done</param>
        private void UpdateStatus(string status, long step, long steps)
        {
            labelCurrentStatus.Text = status;

            if (steps == 0)
            {
                progressBar.Value = 0;
                labelPercentComplete.Text = string.Empty;
            }
            else
            {
                double pctLong = Math.Round(((double)step/steps)*100.0);
                int percentage = (int)Math.Round(pctLong, 0);
                if ((percentage < 0) || (percentage > 100))
                {
                    progressBar.Value = 0;
                    labelPercentComplete.Text = string.Empty;
                }
                else
                {
                    progressBar.Value = percentage;
                    labelPercentComplete.Text = string.Format("{0} percent complete", percentage);
                }
            }
        }

        private void DeleteLog()
        {
            string AppDir = Path.GetDirectoryName(Application.ExecutablePath);
            string filePathName = Path.Combine(AppDir, "VoucherImportLog.txt");
            if (File.Exists(filePathName + ".ark5"))
            {
                File.Delete(filePathName + ".ark5");
            }
            if (File.Exists(filePathName + ".ark4"))
            {
                File.Copy(filePathName + ".ark4", filePathName + ".ark5");
                File.Delete(filePathName + ".ark4");
            }
            if (File.Exists(filePathName + ".ark3"))
            {
                File.Copy(filePathName + ".ark3", filePathName + ".ark4");
                File.Delete(filePathName + ".ark3");
            }
            if (File.Exists(filePathName + ".ark2"))
            {
                File.Copy(filePathName + ".ark2", filePathName + ".ark3");
                File.Delete(filePathName + ".ark2");
            }
            if (File.Exists(filePathName + ".ark1"))
            {
                File.Copy(filePathName + ".ark1", filePathName + ".ark2");
                File.Delete(filePathName + ".ark1");
            }
            if (File.Exists(filePathName ))
            {
                File.Copy(filePathName, filePathName + ".ark1");
                File.Delete(filePathName);
            }

        }

            

        private void LogFile(string LogLine)
        {
            string AppDir = Path.GetDirectoryName(Application.ExecutablePath);
            string filePathName = Path.Combine(AppDir, "VoucherImportLog.txt");
            using (StreamWriter sw = File.AppendText(filePathName))
            {
                sw.WriteLine(LogLine);
            }	
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            DoDaFix();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {

            System.Environment.Exit(0);
          
        }

        private string getReportSQL()
        {
            string reportSQL = "";
            //if matter and billing timekeeper
            if (true)
                reportSQL = "select Clicode, Clireportingname, Matcode, Matreportingname,empinitials as CurrentBillingTimekeeper, 'DEF' as NewBillingTimekeeper" +
                        " from matter" +
                        " inner join client on matclinbr=clisysnbr" +
                        " inner join billto on matbillto=billtosysnbr" +
                        " inner join employee on empsysnbr=billtobillingatty" +
                        " where empinitials<>'ABC'";


            return reportSQL;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) // we WANT all selected
            {
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    listView2.Items[i].Checked = true;
                }

            }
            else //we want them all DESELECTED
            {
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    listView2.Items[i].Checked = false;
                }
            }
        }

        private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter1.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter1.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter1.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter1.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter1.SortColumn = e.Column;
                lvwColumnSorter1.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView2.Sort();
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            var where = listView2.HitTest(e.Location);

            if (where.Location == ListViewHitTestLocations.Label)
            {
                where.Item.Checked = true;
            }

            //clientID = listView2.CheckedItems[0].SubItems[0].Text;


        }




    }
}
