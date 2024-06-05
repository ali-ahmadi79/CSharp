using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography;

namespace TCCIM_DB_Update
{
   
    public partial class frmMain : Form
    {

        string SIP, DIP, SDB, DDB, SDBU, DDBU, SDBP, DDBP, SDBName, LoadType, SelectedTables, isTargetDataToBeDeleted, ScheduledTime, ListOfQueries, ListOfQueriesTargetTables, ListOfQueriesTargetDelete, ListOfQueriesTargetDeleteField, sUpdateTableETL, sToken;
        string sTokenEnable = "1";
        string sCurHashCodeLicence = "";
        Boolean isWorking = false;
        public Boolean isLiceneceValid = true;
        public Boolean isIdleProcess = true;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            try
            {
                string[] lines = System.IO.File.ReadAllLines(@"config.conf");

                int cnt = 0;
                foreach (string line in lines)
                {

                    cnt += 1;
                    switch (cnt)
                    {

                        case 1:
                            SIP = line.Substring(4).ToString().Trim();
                            lblSourceIP.Text = SIP;
                            break;
                        case 2:
                            DIP = line.Substring(4).ToString().Trim();
                            lblTargetIP.Text = DIP;
                            break;
                        case 3:
                            SDB = line.Substring(4).ToString().Trim();
                            lblSourceDBName.Text = SDB;
                            break;
                        case 4:
                            DDB = line.Substring(4).ToString().Trim();
                            lblTargetDB.Text = DDB;
                            break;
                        case 5:
                            SDBU = line.Substring(5).ToString().Trim();
                            break;
                        case 6:
                            DDBU = line.Substring(5).ToString().Trim();
                            break;
                        case 7:
                            SDBP = line.Substring(5).ToString().Trim();
                            break;
                        case 8:
                            DDBP = line.Substring(5).ToString().Trim();
                            break;
                        case 9:
                            SDBName = line.Substring(8).ToString().Trim();
                            break;
                        case 10:
                            LoadType = line.Substring(9).ToString().Trim();
                            break;
                        case 11:
                            SelectedTables = line.Substring(15).ToString().Trim();
                            break;
                        case 12:
                            isTargetDataToBeDeleted = line.Substring(24).ToString().Trim();
                            break;
                        case 13:
                            ScheduledTime = line.Substring(14).ToString().Trim();
                            break;
                        case 14:
                            ListOfQueries = line.Substring(14).ToString().Trim();
                                string[] arrItems = ListOfQueries.Split(';');
                                int cnt2 = 0;
                                foreach (string itm in arrItems)
                                {
                                   if (itm.Trim() != ""){
                                    chkQueries.Items.Add(itm);
                                    cnt2 += 1;
                                    chkQueries.SetItemChecked(cnt2 - 1, true);
                                   }
                                   
                                }
                             break;
                         case 15:
                            ListOfQueriesTargetTables = line.Substring(27).ToString().Trim();
                            string[] arrItems2 = ListOfQueriesTargetTables.Split(';');
                            foreach (string itm in arrItems2)
                            {
                                if (itm.Trim() != "")
                                {
                                    LstListOfQueriesTargetTables.Items.Add(itm);
                                }

                            }
                            break;
                        case 16:
                            ListOfQueriesTargetDelete = line.Substring(27).ToString().Trim();
                            string[] arrItems3 = ListOfQueriesTargetDelete.Split(';');
                            foreach (string itm in arrItems3)
                            {
                                if (itm.Trim() != "")
                                {
                                    LstListOfQueriesTargetDelete.Items.Add(itm);
                                }

                            }
                            break;
                        case 17:
                            ListOfQueriesTargetDeleteField = line.Substring(32).ToString().Trim();
                            string[] arrItems4 = ListOfQueriesTargetDeleteField.Split(';');
                            foreach (string itm in arrItems4)
                            {
                                if (itm.Trim() != "")
                                {
                                    LstListOfQueriesTargetDeleteField.Items.Add(itm);
                                }

                            }
                            break;
                        case 18:
                            sUpdateTableETL = line.Substring(18).ToString().Trim();
                            break;
                        case 19:
                            sToken = line.Substring(12).ToString().Trim();
                            break;
                        case 20:
                            sTokenEnable = line.Substring(12).ToString().Trim();
                            break;
                    }
                }
            }
            catch (Exception)
            {
                ToolStripStatusLabel1.Text = "Unable to read config.conf !";
            }

            if (sToken != "" && sTokenEnable !="0")
            {
                sCurHashCodeLicence = MD5Hash("MyLicence" + DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString());

                if (sToken != sCurHashCodeLicence) {
                    isLiceneceValid = false;
                    this.Text = "ETL Export Data~";
                }
                
            }else{
                ToolStripStatusLabel1.Text = "Invalid config.conf - Error 110!";
            }

            try
            {
                SqlConnection sourceConnection = new SqlConnection("data source=" + SIP + ";persist security info=False;initial catalog=" + SDB + ";user id=" + SDBU + ";password=" + SDBP + ";Connection Timeout=9000;");
                sourceConnection.Open();
                SqlConnection targetConnectionDB = new SqlConnection("data source=" + DIP + ";persist security info=False;initial catalog=" + DDB + ";user id=" + DDBU + ";password=" + DDBP + ";Connection Timeout=9000;");
                targetConnectionDB.Open();

                ToolStripStatusLabel1.Text = "Connected to source DB (" + SIP + " - " + SDB + ") and destination DB (" + DIP + " - " + DDB + ").";

                SqlCommand command = new SqlCommand("SELECT * FROM sys.objects WHERE type_desc = 'USER_TABLE' OR type_desc = 'VIEW' ORDER BY type_desc, name", sourceConnection);

                command.CommandTimeout = 9000;
                //int result = (int)(command.ExecuteScalar());
                int cnt = 0;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        cnt += 1;
                        chkLstSourceDB.Items.Add(reader[0]);
                        if (isCheckItems(reader[0].ToString(), SelectedTables))
                        {
                            chkLstSourceDB.SetItemChecked(cnt - 1, true);
                        }

                    }
                }

                sourceConnection.Close();

                System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

                float sChTime = (float)Convert.ToDouble(ScheduledTime);
                if ( sChTime > 0)
                {
                    timer1.Interval = Convert.ToInt32( sChTime * float.Parse("60000")); // specify interval time as you want
                    txtScheduleInterval.Text =sChTime.ToString();
                    timer1.Tick += new EventHandler(timer_Tick);
                    timer1.Start();
                }
                else
                {
                    txtScheduleInterval.Text = "0";
                }
            }
            catch (Exception)
            {
                ToolStripStatusLabel1.Text = "Unable to connect to source DB or destination DB!";
                doLogFile(DateTime.Now.ToShortTimeString() + ": " + "Unable to connect to source DB or destination DB!");
            }



        }
        void timer_Tick(object sender, EventArgs e)
        {
            if(!chkScheduleDisable.Checked ){
                if(isIdleProcess){
                    lstLogs.Items.Add(DateTime.Now.ToLongTimeString() + ": Scheduled task was started.");
                    doLogFile(DateTime.Now.ToShortTimeString() + ": " + "Scheduled task was started.");
                    btnTransfer_Click(null,null);
                }else{
                    lstLogs.Items.Add(DateTime.Now.ToLongTimeString() + ": Scheduled task was not started because of parallel processing !");
                    doLogFile(DateTime.Now.ToShortTimeString() + ": " + "Scheduled task was not started because of parallel processing !");
                }
            }
        }
        private Boolean isCheckItems(string TableListRow, string CheckedTables)
        {
            string[] arrItems = CheckedTables.Split(',');
            Boolean result = false;
            foreach (string itm in arrItems)
            {
                if (itm.ToString() == TableListRow){
                    result = true;
                }
            }

            return result;
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkLstSourceDB.Items.Count; i++)
            {
                chkLstSourceDB.SetItemChecked(i, true);
            }
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkLstSourceDB.Items.Count; i++)
            {
                chkLstSourceDB.SetItemChecked(i, false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ? \nAll the selected tables in the list will be completely truncated! \nIt would not be reversible anymore. ", "Delete confirmation:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                SqlConnection targetConnectionDB2 = new SqlConnection("data source=" + DIP + ";persist security info=False;initial catalog=" + DDB + ";user id=" + DDBU + ";password=" + DDBP + ";Connection Timeout=9000;");
                targetConnectionDB2.Open();

                for (int i = 0; i < chkLstSourceDB.Items.Count; i++)
                {
                    if (chkLstSourceDB.GetItemChecked(i))
                    {

                        SqlCommand cmd2 = new SqlCommand("TRUNCATE TABLE " + chkLstSourceDB.Items[i], targetConnectionDB2);
                        cmd2.CommandTimeout = 9000;
                        cmd2.ExecuteNonQuery();
                        cmd2.Dispose();

                        lstLogs.Items.Add(DateTime.Now.ToShortTimeString() + ": " + "Table '" + chkLstSourceDB.Items[i] + "' was truncated successfully.");

                    }

                }

                targetConnectionDB2.Close();
                targetConnectionDB2.Dispose();

            }
           

        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (btnTransfer.Text == "Start Transfer (Update Jobs)")
            {
                isWorking = true;
                btnTransfer.Text = "Cancel Updating Job..";
                Color sColor =  Color.OrangeRed;
                btnTransfer.BackColor = sColor;
                isIdleProcess = false;
            }else{
                isWorking = false;
                btnTransfer.Text = "Start Transfer (Update Jobs)";
                ToolStripStatusLabel1.Text = "...";
                Color sColor = Color.ForestGreen;
                btnTransfer.BackColor = sColor;
                isIdleProcess = true;
            }
            
            
            ToolStripStatusLabel1.Text = "Preparing to transfer source data... ";

            SqlConnection sourceConnectionDB = new SqlConnection("data source=" + SIP + ";persist security info=False;initial catalog=" + SDB + ";user id=" + SDBU + ";password=" + SDBP + ";Connection Timeout=9000;");
            sourceConnectionDB.Open();
            SqlConnection targetConnectionDB = new SqlConnection("data source=" + DIP + ";persist security info=False;initial catalog=" + DDB + ";user id=" + DDBU + ";password=" + DDBP + ";Connection Timeout=9000;");
            targetConnectionDB.Open();

            ToolStripStatusLabel1.Text = "Connected to source DB (" + SIP + " - " + SDB + ") and destination DB (" + DIP + " - " + DDB + ").";

            for (int i = 0; i < chkLstSourceDB.Items.Count && isWorking; i++)
            {
                if (chkLstSourceDB.GetItemChecked(i))
                {

                    Application.DoEvents();

                    try
                    {

                        //get all records count:
                        Int32 iAllRowsCount = 0;
                        SqlCommand sqlcmd = new SqlCommand("SELECT count(*) AS cnt FROM " + chkLstSourceDB.Items[i], sourceConnectionDB);
                        iAllRowsCount = Convert.ToInt32(sqlcmd.ExecuteScalar());
                        sqlcmd.Dispose();

                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = sourceConnectionDB;
                        cmd.CommandText = "SELECT * FROM " + chkLstSourceDB.Items[i];
                        cmd.CommandTimeout = 9000;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            Int32 columnCount = dr.FieldCount;
                            string sSQL1 = "";
                            string sSQL2 = "";
                            string sSQL = "";
                            if (dr.HasRows && isTargetDataToBeDeleted == "1")
                            {
                                SqlCommand cmd2 = new SqlCommand("TRUNCATE TABLE " + chkLstSourceDB.Items[i], targetConnectionDB);
                                cmd2.CommandTimeout = 9000;
                                cmd2.ExecuteNonQuery();
                                doLogFile(DateTime.Now.ToShortTimeString() + ": " + "Table '" + chkLstSourceDB.Items[i] + "' was truncated successfully.");
                                lstLogs.Items.Add(DateTime.Now.ToShortTimeString() + ": " + "Table '" + chkLstSourceDB.Items[i] + "' was truncated successfully.");
                            }
                            
                            int iRowscount = 0;
                            //progressBar1.Visible = true;
                            //progressBar1.Maximum = iAllRowsCount;

                            picWorking.Visible = true;

                            if (isWorking) {
                                doLogFile(DateTime.Now.ToShortTimeString() + ": " + " '" + iAllRowsCount + "' Records  have been retrieved from " + chkLstSourceDB.Items[i] + ".");
                                lstLogs.Items.Add(DateTime.Now.ToShortTimeString() + ": " + " '" + iAllRowsCount + "' Records  have been retrieved from " + chkLstSourceDB.Items[i] + ".");
                            }

                            while (dr.Read() && isWorking)	
                            {

                                Application.DoEvents();
                                if (!isWorking)
                                {
                                    ToolStripStatusLabel1.Text = "Data transfer canceled by user!";
                                    lstLogs.Items.Add(DateTime.Now.ToShortTimeString() + ": " + "Data transfer canceled by user!");
                                    break;
                                }
                                sSQL1 = "";
                                sSQL2 = "";
                                sSQL = "";

                                for (Int32 columnIndex = 0; columnIndex < columnCount; columnIndex++)
                                {
                                    sSQL1 += "[" + dr.GetName(columnIndex) + "],";
                                    if (dr.GetValue(columnIndex) is DBNull )
                                    {
                                        sSQL2 += "null,";
                                    }else{
                                        sSQL2 += "N'" + dr.GetValue(columnIndex).ToString().Replace("'","''") + "',";
                                    }
                                    
                                }
                                if (sSQL1.ToString().Length > 0)
                                {
                                    sSQL1 = sSQL1.Substring(0, sSQL1.Length - 1);
                                }
                                if (sSQL2.ToString().Length > 0)
                                {
                                    sSQL2 = sSQL2.Substring(0, sSQL2.Length - 1);
                                }

                               
                                sSQL = "INSERT INTO " + chkLstSourceDB.Items[i] + " (" + sSQL1  + ") VALUES (" + sSQL2 + ")";
                                
                                // Insert into target tables:
                                try
                                {
                                    if (isLiceneceValid) 
                                    { 
                                        SqlCommand cmd3 = new SqlCommand(sSQL, targetConnectionDB);
                                        cmd3.CommandTimeout = 9000;
                                        cmd3.ExecuteNonQuery();
                                        cmd3.Dispose();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    ToolStripStatusLabel1.Text = "Unable to insert data in target DB (" + chkLstSourceDB.Items[i] + ") !";
                                    doLogFile(DateTime.Now.ToShortTimeString() + ": " + "Unable to insert data in target DB (" + chkLstSourceDB.Items[i] + ") !" + Environment.NewLine + ex.Message);
                                }
                                                   
                                
                                iRowscount += 1;

                                if (iAllRowsCount > 0) {
                                    ToolStripStatusLabel1.Text = iRowscount.ToString() + " of " + iAllRowsCount.ToString() + " records were transferred.";
                                    //progressBar1.Value = iRowscount;

                                    //int percent = (int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100);
                                    //progressBar1.Refresh();
                                    //progressBar1.CreateGraphics().DrawString(percent.ToString() + "%",
                                    //    new Font("Tahoma", (float)8.25, FontStyle.Regular),
                                    //    Brushes.Black,
                                    //    new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));

                                } else {
                                    ToolStripStatusLabel1.Text = iRowscount.ToString() + " records were transferred.";
                                    //progressBar1.Value = 0;
                                    //progressBar1.Visible = false;
                                    picWorking.Visible = false;
                                }

                            }
                            //progressBar1.Value = 0;
                            //progressBar1.Visible = false;
                            picWorking.Visible = false;
                            dr.Close();

                            ToolStripStatusLabel1.Text = "Export Data was finished '" + chkLstSourceDB.Items[i] + "' " + iRowscount + " records affected.";
                            doLogFile(DateTime.Now.ToShortTimeString() + ": " + "Export Data was finished '" + chkLstSourceDB.Items[i] + "' " + iRowscount + " records affected." + Environment.NewLine);
                            lstLogs.Items.Add(DateTime.Now.ToShortTimeString() + ": " + "Export Data was finished '" + chkLstSourceDB.Items[i] + "' " + iRowscount + " records affected.");
                           
                            if (isWorking)
                            {
                                ToolStripStatusLabel1.Text = "Table '" + chkLstSourceDB.Items[i] + "': " + iAllRowsCount + " records have been transferred completely.";
                            }


                        }



                    }
                    catch (Exception ex)
                    {
                        ToolStripStatusLabel1.Text = "Unable to connect to source DB (" + chkLstSourceDB.Items[i] + ") ! - " + ex.Message;
                        doLogFile(DateTime.Now.ToShortTimeString() + ": " + "Unable to connect to source DB (" + chkLstSourceDB.Items[i] + ") ! - " + ex.Message);
                    }

                }
            }





            // Queries processing part:

            Boolean bUpdatedBISecussfully = false;

            for (int i = 0; i < chkQueries.Items.Count && isWorking; i++)
            {
                if (chkQueries.GetItemChecked(i))
                {

                    Application.DoEvents();

                    try
                    {

                   
                        Int32 iAllRowsCount = 1;

                        SqlCommand cmd = new SqlCommand();

                        cmd.Connection = sourceConnectionDB;
                        string qText = getQuery(chkQueries.Items[i].ToString());
                        if (qText != "")
                        {
                         cmd.CommandText = getQuery(chkQueries.Items[i].ToString());
                         cmd.CommandTimeout = 9000;
                        }
                        else {
                            MessageBox.Show("Unable to find query file \n" + chkQueries.Items[i].ToString(), "Error loading query",MessageBoxButtons.OK, MessageBoxIcon.Error); 
                            ToolStripStatusLabel1.Text = "Unable to find query file \n" + chkQueries.Items[i].ToString();
                        };

                        doLogFile(DateTime.Now.ToShortTimeString() + ": " + "Table '" + chkQueries.Items[i].ToString() + "' retrieving records were started.");
                        lstLogs.Items.Add(DateTime.Now.ToShortTimeString() + ": " + "Table '" + chkQueries.Items[i].ToString() + "' retrieving records were started.");

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            Int32 columnCount = dr.FieldCount;
                            string sSQL1 = "";
                            string sSQL2 = "";
                            string sSQL = "";

                            // delete old records
                            string fldDeleteBaseField, fldDeleteBaseFieldWhere ;
                            fldDeleteBaseField = LstListOfQueriesTargetDelete.Items[i].ToString();
                            fldDeleteBaseFieldWhere = LstListOfQueriesTargetDeleteField.Items[i].ToString();
                            if (fldDeleteBaseField == "1")
                            {
                                
                                //for delete part parameters

                                fldDeleteBaseFieldWhere.Replace("@CurShamsiDate", getCurShamsiDate());
                                fldDeleteBaseFieldWhere.Replace("@CurGregorianDate", DateTime.Now.ToShortTimeString());
                                
                                SqlCommand cmd2 = new SqlCommand("DELETE FROM " + LstListOfQueriesTargetTables.Items[i].ToString() + " WHERE " + fldDeleteBaseFieldWhere, targetConnectionDB);
                                cmd2.CommandTimeout = 9000;
                                cmd2.ExecuteNonQuery();
                                cmd2.Dispose();
                                doLogFile(DateTime.Now.ToShortTimeString() + ": " + "Table '" + chkQueries.Items[i].ToString() + "' records were deleted successfully.");
                                lstLogs.Items.Add(DateTime.Now.ToShortTimeString() + ": " + "Table '" + chkQueries.Items[i].ToString() + "' records were deleted successfully. ");
                            }


                            int iRowscount = 0;
                            //progressBar1.Visible = true;
                            //progressBar1.Maximum = iAllRowsCount;
                            picWorking.Visible = true;
                            //if (isWorking)
                            //{
                            //    if (iAllRowsCount > 0)
                            //    {
                            //        doLogFile(DateTime.Now.ToShortTimeString() + ": " + " '" + iAllRowsCount + "' Records  have been retrieved from " + chkQueries.Items[i].ToString() + ".");
                            //        lstLogs.Items.Add(DateTime.Now.ToShortTimeString() + ": " + " '" + iAllRowsCount + "' Records  have been retrieved from " + chkQueries.Items[i].ToString() + ".");
                            //    }
                            //}

                            while (dr.Read() && isWorking)	// Assuming there is only one row.
                            {

                                Application.DoEvents();
                                if (!isWorking)
                                {
                                    ToolStripStatusLabel1.Text = "Data transfer canceled by user!";
                                    lstLogs.Items.Add(DateTime.Now.ToShortTimeString() + ": " + "Data transfer canceled by user!");
                                    break;
                                }
                                sSQL1 = "";
                                sSQL2 = "";
                                sSQL = "";

                                for (Int32 columnIndex = 0; columnIndex < columnCount; columnIndex++)
                                {
                                    sSQL1 += "[" + dr.GetName(columnIndex) + "],";
                                    if (dr.GetValue(columnIndex) is DBNull)
                                    {
                                        sSQL2 += "null,";
                                    }
                                    else
                                    {
                                        sSQL2 += "N'" + dr.GetValue(columnIndex).ToString().Replace("'", "''") + "',";
                                    }

                                }
                                if (sSQL1.ToString().Length > 0)
                                {
                                    sSQL1 = sSQL1.Substring(0, sSQL1.Length - 1);
                                }
                                if (sSQL2.ToString().Length > 0)
                                {
                                    sSQL2 = sSQL2.Substring(0, sSQL2.Length - 1);
                                }


                                sSQL = "INSERT INTO " + LstListOfQueriesTargetTables.Items[i].ToString() + " (" + sSQL1 + ") VALUES (" + sSQL2 + ")";

                                // Insert into target tables:
                                try
                                {
                                    if (isLiceneceValid)
                                    {
                                        SqlCommand cmd3 = new SqlCommand(sSQL, targetConnectionDB);
                                        cmd3.CommandTimeout = 9000;
                                        cmd3.ExecuteNonQuery();
                                        cmd3.Dispose();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    ToolStripStatusLabel1.Text = "Unable to insert data in target DB (" + chkQueries.Items[i].ToString() + ") ! - " + ex.Message;
                                    doLogFile(DateTime.Now.ToShortTimeString() + ": " + "Unable to insert data in target DB (" + chkQueries.Items[i].ToString() + ") !" + Environment.NewLine + ex.Message);
                                }


                                iRowscount += 1;
                                iAllRowsCount += 1;

                                ToolStripStatusLabel1.Text = iRowscount.ToString() + " of " + iAllRowsCount.ToString() + " records were transferred.";
                                if (iAllRowsCount > 0){
                                    //progressBar1.Maximum = iAllRowsCount;
                                    //progressBar1.Value = iRowscount;

                                    //int percent = (int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100);
                                    //progressBar1.Refresh();
                                    //progressBar1.CreateGraphics().DrawString(percent.ToString() + "%",
                                    //    new Font("Tahoma", (float)8.25, FontStyle.Regular),
                                    //    Brushes.Black,
                                    //    new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                                }
                                else
                                {
                                    ToolStripStatusLabel1.Text = iRowscount.ToString() + " records were transferred.";
                                    //progressBar1.Value = 0;
                                    //progressBar1.Visible = false;
                                    picWorking.Visible = true;
                                }


                            }
                            //progressBar1.Value = 0;
                            //progressBar1.Visible = false;
                            picWorking.Visible = false;
                            dr.Close();

                            ToolStripStatusLabel1.Text = "Export Data was finished '" + chkQueries.Items[i].ToString() + "' " + iRowscount + " records affected.";
                            doLogFile(DateTime.Now.ToShortTimeString() + ": " + "Export Data was finished '" + chkQueries.Items[i].ToString() + "' " + iRowscount + " records affected." + Environment.NewLine);
                            lstLogs.Items.Add(DateTime.Now.ToShortTimeString() + ": " + "Export Data was finished '" + chkQueries.Items[i].ToString() + "' " + iRowscount + " records affected.");

                            if (isWorking)
                            {
                                ToolStripStatusLabel1.Text = "Table '" + chkQueries.Items[i].ToString() + "': " + iRowscount + " records have been transferred completely.";
                            }

                            bUpdatedBISecussfully = true;

                        }

                    }
                    catch (Exception ex)
                    {
                        bUpdatedBISecussfully = false;
                        ToolStripStatusLabel1.Text = "Unable to connect to source DB (" + chkQueries.Items[i].ToString() + ") ! - " + ex.Message;
                        doLogFile(DateTime.Now.ToShortTimeString() + ": " + "Unable to connect to source DB (" + chkQueries.Items[i].ToString() + ") !" + Environment.NewLine + ex.Message);
                    }

                }
            }


            // Update ETL date table
            try
            {
                if (bUpdatedBISecussfully)
                {
                    string sCurGregorianDate = (DateTime.Now.Year).ToString() + '/' + doNormalize(DateTime.Now.Month.ToString()) + '/' + doNormalize(DateTime.Now.Day.ToString());
                    System.Globalization.PersianCalendar persianCalandar =
                                             new System.Globalization.PersianCalendar();
                    string GregorianDate = DateTime.Now.ToShortDateString();
                    DateTime curDateTime = DateTime.Parse(GregorianDate);
                    int year = persianCalandar.GetYear(curDateTime);
                    int month = persianCalandar.GetMonth(curDateTime);
                    int day = persianCalandar.GetDayOfMonth(curDateTime);

                    string sCurShamsiDate = doNormalize(year.ToString()) + '/' + doNormalize(month.ToString()) + '/' + doNormalize(day.ToString());

                    if (isLiceneceValid)
                    {
                        SqlCommand cmd4 = new SqlCommand("DELETE FROM tbl_BI_LastUpdate; INSERT INTO tbl_BI_LastUpdate (UpdateDate, Module, Status) VALUES ('" + sCurShamsiDate + "', '0', '1')", targetConnectionDB);
                        cmd4.CommandTimeout = 9000;
                        cmd4.ExecuteNonQuery();
                        cmd4.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                ToolStripStatusLabel1.Text = "Updated Table (" + sUpdateTableETL + ") - " + ex.Message;
                doLogFile(DateTime.Now.ToShortTimeString() + ": " + "Update Table (" + sUpdateTableETL + ") " + Environment.NewLine + ex.Message);
            }


            sourceConnectionDB.Close();
           
            isWorking = false;
            isIdleProcess = true;
            btnTransfer.Text = "Start Transfer (Update Jobs)";
            Color sColor2 = Color.ForestGreen;
            btnTransfer.BackColor = sColor2;

        }
        private string getQuery(string fileName)
        {
            string result = "";
            try {
                result = doChangeQVariables(System.IO.File.ReadAllText(@"Queries\" + fileName + ".txt")).Replace(Environment.NewLine , " "); 
            }
            catch (Exception){
                ToolStripStatusLabel1.Text = "Unable to read query file (" + @"Queries\" + fileName + ") !";
                doLogFile(DateTime.Now.ToShortTimeString() + ": " + "Unable to read query file (" + @"Queries\" + fileName + ") !");
            }
            
            return result;
        }
        private string doChangeQVariables(string query)
        {
            string sCurGregorianDate = (DateTime.Now.Year).ToString() + '/' + doNormalize(DateTime.Now.Month.ToString()) + '/' + doNormalize(DateTime.Now.Day.ToString());
            System.Globalization.PersianCalendar persianCalandar =
                                     new System.Globalization.PersianCalendar();
            string GregorianDate = DateTime.Now.ToShortDateString();
            DateTime curDateTime = DateTime.Parse(GregorianDate);
            int year = persianCalandar.GetYear(curDateTime);
            int month = persianCalandar.GetMonth(curDateTime);
            int day = persianCalandar.GetDayOfMonth(curDateTime);

            string sCurShamsiDate = doNormalize(year.ToString()) + '/' + doNormalize(month.ToString()) + '/' + doNormalize(day.ToString());
            return query.Replace("@CurShamsiDate", sCurShamsiDate).Replace("@CurGregorianDate", sCurGregorianDate);
        }
        private string doNormalize(string sInput)
        {
            string result = sInput.Trim();
            if (result.Length < 2){
                result = "0" + result;
            }
            return result ;
        }
        private void doLogFile(string sWriteDate)
        {
            System.IO.File.AppendAllText(@"Logs\log_" + ( DateTime.Now.Year.ToString()  +  DateTime.Now.Month.ToString() +  DateTime.Now.Day.ToString()).ToString() + ".txt", sWriteDate + Environment.NewLine);
        }

        private void StatusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ClearEvents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lstLogs.Items.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void scheduleDisableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chkScheduleDisable.Checked = true;
        }

        private void scheduleIntervalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void queryVariablesDefinitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Query files could have variables like: " + Environment.NewLine + Environment.NewLine + "1) @CurShamsiDate : Current Shamsi Date" + Environment.NewLine + "2) @CurGregorianDate : Current Gregorian Date", "Query content predefined variables:");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmAbout = new frmAboutUs();
            frmAbout.ShowDialog();
        }

        private void queryTablesDefinitionTipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Query table name definition tips: " + Environment.NewLine + Environment.NewLine + "1) All query files should have .txt extension" + Environment.NewLine + "2) In config file, table name does not mentioned with extension (.txt)", "Query content file tips:");
        }

        private void chkTablesSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTablesSelectAll.Checked ){
                for (int i = 0; i < chkLstSourceDB.Items.Count; i++)
                {
                    chkLstSourceDB.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < chkLstSourceDB.Items.Count; i++)
                {
                    chkLstSourceDB.SetItemChecked(i, false);
                }
            }
        }

        private void chkSelectAllQueries_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAllQueries.Checked)
            {
                for (int i = 0; i < chkQueries.Items.Count; i++)
                {
                    chkQueries.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < chkQueries.Items.Count; i++)
                {
                    chkQueries.SetItemChecked(i, false);
                }
            }
        }

        private string getCurShamsiDate()
        {

            string sCurShamsiDate = "";

            string sCurGregorianDate = (DateTime.Now.Year).ToString() + '/' + doNormalize(DateTime.Now.Month.ToString()) + '/' + doNormalize(DateTime.Now.Day.ToString());
            System.Globalization.PersianCalendar persianCalandar =
                                    new System.Globalization.PersianCalendar();
            string GregorianDate = DateTime.Now.ToShortDateString();
            DateTime curDateTime = DateTime.Parse(GregorianDate);
            int year = persianCalandar.GetYear(curDateTime);
            int month = persianCalandar.GetMonth(curDateTime);
            int day = persianCalandar.GetDayOfMonth(curDateTime);

            sCurShamsiDate = doNormalize(year.ToString()) + '/' + doNormalize(month.ToString()) + '/' + doNormalize(day.ToString());

            return sCurShamsiDate;
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

    }
  
  
}
