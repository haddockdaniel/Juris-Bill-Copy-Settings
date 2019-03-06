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

        public string employeesOrig = "";

        public string allEmployeesOrig = ""; //used if they select all employees

        public string employeesBill = "";

        public string allEmployeesBill = ""; //used if they select all employees

        private ListViewColumnSorter lvwColumnSorter1;

        #endregion

        #region Constructor

        public UtilityBaseMain()
        {
            InitializeComponent();
            _jurisUtility = new JurisUtility();

            listViewClient.MultiSelect = true;
            listViewClient.CheckBoxes = true;
            listViewClient.FullRowSelect = true;
            setColumns();
            lvwColumnSorter1 = new ListViewColumnSorter();
            this.listViewClient.ListViewItemSorter = lvwColumnSorter1;
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;

        }

        #endregion

        #region Public methods

        public void setColumns()
        {
            listViewClient.Columns.Add("Client ID", 80, HorizontalAlignment.Left);
            listViewClient.Columns.Add("Client Code", 75, HorizontalAlignment.Left);
            listViewClient.Columns.Add("Client Name", 350, HorizontalAlignment.Left);
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

            listViewClient.Clear();
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
                    listViewClient.Items.Add(lvi);

                }
            }

            comboBoxBill.ClearItems();
            myRSTkpr.Clear();
            SQLTkpr = "select cast(EmpSysNbr as varchar) + ' ' + EmpName as employee from employee";
            myRSTkpr = _jurisUtility.RecordsetFromSQL(SQLTkpr);

            if (myRSTkpr.Tables[0].Rows.Count == 0)
                comboBoxBill.SelectedIndex = 0;
            else
            {
                comboBoxBill.Items.Add("* All Employees");
                foreach (DataRow dr in myRSTkpr.Tables[0].Rows)
                {
                    comboBoxBill.Items.Add(dr["employee"].ToString());
                    allEmployeesBill = allEmployeesBill + dr["employee"].ToString().Split(' ')[0] + ",";
                }
                allEmployeesBill = allEmployeesBill.TrimEnd(',');

            }

            comboBoxOrig.ClearItems();
            myRSTkpr.Clear();
            SQLTkpr = "select cast(EmpSysNbr as varchar) + ' ' + EmpName as employee from employee";
            myRSTkpr = _jurisUtility.RecordsetFromSQL(SQLTkpr);

            if (myRSTkpr.Tables[0].Rows.Count == 0)
                comboBoxOrig.SelectedIndex = 0;
            else
            {
                comboBoxOrig.Items.Add("* All Employees");
                foreach (DataRow dr in myRSTkpr.Tables[0].Rows)
                {
                    comboBoxOrig.Items.Add(dr["employee"].ToString());
                    allEmployeesOrig = allEmployeesOrig + dr["employee"].ToString().Split(' ')[0] + ",";
                }
                allEmployeesOrig = allEmployeesOrig.TrimEnd(',');
            }


        }



        #endregion

        #region Private methods

        private void DoDaFix()
        {
          //  try //ensures number of copies is an int. If not, go to Catch block
           // {
                Int32.Parse(textBox2.Text);
                
                //orig
                if (radioButtonBill.Checked)
                {
                    if (comboBoxBill.SelectedIndex > -1)
                        processByBillTkpr();
                    else
                        MessageBox.Show("Please select a Billing Atty", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                //bill
                else if (radioButtonOrig.Checked)
                {
                    if (comboBoxOrig.SelectedIndex > -1)
                        processByOrigTkpr();
                    else
                        MessageBox.Show("Please select an Originating Atty", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }

                //client
                else if (radioButtonClient.Checked)
                    processByClient();

          //  }
          //  catch (Exception ex1)//we only get here if they put something NOT an int in the "Number of Copies" textbox
          //  {
           //     MessageBox.Show("Number of copies entered is not a valid integer" + "\r\n" + ex1.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
           // }
        }

        private void processByBillTkpr()
        {
            string selectedMatters = "";
            String SQL = "";

            SQL = "SELECT MatSysNbr FROM [BillTo] inner join matter on BillToSysNbr = MatBillTo where BillToBillingAtty in (" + employeesBill + ")";
            DataSet myRSTkpr = _jurisUtility.RecordsetFromSQL(SQL);
            foreach (DataRow dr in myRSTkpr.Tables[0].Rows)
            {
                selectedMatters = selectedMatters + dr["MatSysNbr"].ToString() + ",";
            }
            selectedMatters = selectedMatters.TrimEnd(',');
            runUpdateSQL(selectedMatters);
        }

        private void processByOrigTkpr()
        {
            string selectedMatters = "";
            string SQL = "SELECT MOrigMat FROM MatOrigAtty where MOrigAtty in (" + employeesOrig + ")";
            DataSet myRSTkpr = _jurisUtility.RecordsetFromSQL(SQL);
            foreach (DataRow dr in myRSTkpr.Tables[0].Rows)
            {
                selectedMatters = selectedMatters + dr["MOrigMat"].ToString() + ",";
            }
            selectedMatters = selectedMatters.TrimEnd(',');
            runUpdateSQL(selectedMatters);


        }

        private void processByClient()
        {
            string selectedClients = "";
            foreach (ListViewItem eachItem in listViewClient.CheckedItems)
            {
                selectedClients = selectedClients + eachItem.SubItems[0].Text + ","; //get the client id from each item selected
            }

            selectedClients = selectedClients.TrimEnd(',');
            if (!String.IsNullOrEmpty(selectedClients))
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
                    runUpdateSQL(selectedMatters);
                
            }
            else //there were no matters selected
                MessageBox.Show("Please select at least one client", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void runUpdateSQL(string selectedMatters)
        {
            if (!string.IsNullOrEmpty(selectedMatters))
            {
                string SQLTkpr = getReportSQL(selectedMatters);

                DataSet report = _jurisUtility.RecordsetFromSQL(SQLTkpr);

                ReportDisplay rpds = new ReportDisplay(report);
                rpds.ShowDialog();

                if (areAnyCheckBoxesChecked())
                {
                    string options = returnSQLUpdateString();
                    DialogResult dialog = MessageBox.Show("This tool will update all BillCopy Settings for all matters associated" + "\r\n" + "with the selections. This cannot be undone. Are you sure?", "Confirmation Dialog", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == System.Windows.Forms.DialogResult.Yes)
                    {
                        string SQL = "update billcopy set " + options + " from billto inner join matter on matbillto=billtosysnbr where bilcpybillto=billtosysnbr and matsysnbr in (" + selectedMatters + ")";
                        _jurisUtility.ExecuteNonQueryCommand(0, SQL);
                        UpdateStatus("Selected matters updated.", 1, 1);

                        MessageBox.Show("The process is complete", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                else
                    MessageBox.Show("There are no checkboxes checked. Please update your selection.", "No selections made", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
                MessageBox.Show("This timekeeper or the selected client(s) have no matters associated" + "\r\n" + "with them so there is nothing to process. Please update your selection.", "No Matters to Process", MessageBoxButtons.OK, MessageBoxIcon.None);
        }


        private bool areAnyCheckBoxesChecked()
        {
            if (checkBoxNbrCopies.Checked == true)
                return true;
            if (checkBoxPrintBill.Checked == true)
                return true;
            if (checkBoxPrintARStmt.Checked == true)
                return true;
            if (checkBoxEmailType.Checked == true)
                return true;
            if (checkBoxExportType.Checked == true)
                return true;
            if (checkBoxComment.Checked == true)
                return true;
            return false;
        }

        private string returnSQLUpdateString()
        {
            string SQL = "";
            if (checkBoxNbrCopies.Checked == true)
                SQL = " BilCpyNbrOfCopies=" + textBox2.Text + ",";
            if (checkBoxPrintBill.Checked == true)
                SQL = SQL + " bilcpyprintformat=" + comboBox1.SelectedIndex + ",";
            if (checkBoxPrintARStmt.Checked == true)
                SQL = SQL + " BilCpyARFormat=" + comboBox3.SelectedIndex + ","; 
            if (checkBoxEmailType.Checked == true)
                SQL = SQL + " bilcpyemailformat=" + comboBox4.SelectedIndex + ","; 
            if (checkBoxExportType.Checked == true)
                SQL = SQL + " bilcpyexportformat=" + comboBox2.SelectedIndex + ","; 
            if (checkBoxComment.Checked == true)
                SQL = SQL + " BilCpyComment = '" + textBox1.Text + "'";
            SQL = SQL.TrimEnd(',');
            return SQL;
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

        private void buttonExit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private string getReportSQL(string selectedMatters)
        {
            string reportSQL = "";
            //if matter and billing timekeeper
                reportSQL = "select Clicode, Clireportingname, Matcode, Matreportingname" +
                        " from matter" +
                        " inner join client on matclinbr=clisysnbr where matsysnbr in (" + selectedMatters + ")";


            return reportSQL;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxClient.Checked == true) // we WANT all selected
            {
                for (int i = 0; i < listViewClient.Items.Count; i++)
                {
                    listViewClient.Items[i].Checked = true;
                }

            }
            else //we want them all DESELECTED
            {
                for (int i = 0; i < listViewClient.Items.Count; i++)
                {
                    listViewClient.Items[i].Checked = false;
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
            this.listViewClient.Sort();
        }

        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            var where = listViewClient.HitTest(e.Location);

            if (where.Location == ListViewHitTestLocations.Label)
            {
                where.Item.Checked = true;
            }

        }


        private void makeItemsVisibleOrInvisible(bool orig, bool bill, bool client)
        {
            comboBoxBill.Visible = bill;
            comboBoxOrig.Visible = orig;
            listViewClient.Visible = client;
            checkBoxClient.Visible = client;
        }

        private void radioButtonOrig_Click(object sender, EventArgs e)
        {
            if (radioButtonOrig.Checked)
            {
                makeItemsVisibleOrInvisible(true, false, false);
                radioButtonBill.Checked = false;
                radioButtonClient.Checked = false;
            }
        }

        private void radioButtonBill_Click(object sender, EventArgs e)
        {
            if (radioButtonBill.Checked)
            {
                makeItemsVisibleOrInvisible(false, true, false);
                radioButtonOrig.Checked = false;
                radioButtonClient.Checked = false;
            }
        }

        private void radioButtonClient_Click(object sender, EventArgs e)
        {
            if (radioButtonClient.Checked)
            {
                makeItemsVisibleOrInvisible(false, false, true);
                radioButtonOrig.Checked = false;
                radioButtonBill.Checked = false;
            }
        }

        private void comboBoxOrig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxOrig.Text.StartsWith("*"))
                employeesOrig = comboBoxOrig.Text.Split(' ')[0];
            else
                employeesOrig = allEmployeesOrig;
        }

        private void comboBoxBill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxBill.Text.StartsWith("*"))
                employeesBill = comboBoxBill.Text.Split(' ')[0];
            else
                employeesBill = allEmployeesBill;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            checkBoxNbrCopies.Checked = true;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            checkBoxPrintBill.Checked = true;
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            checkBoxPrintARStmt.Checked = true;
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            checkBoxEmailType.Checked = true;
        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            checkBoxExportType.Checked = true;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            checkBoxComment.Checked = true;
        }

    }
}
