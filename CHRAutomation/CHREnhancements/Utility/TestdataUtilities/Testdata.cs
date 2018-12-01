using System;
using System.Data.SqlClient;


namespace CHREnhancements.Utility.TestdataUtilities
{
    class Testdata
    {
        public static string url;
        public static string username;
        public static string cmusername;
        public static string cmpassword;
        public static string password;
        public static string templatename;
        public static string quantity;
        public static string templateid;
        public static string adminurl;
        public static string clientspecificun;
        public static string clientspecificpwd;
        public static string mailurl;
        public static string mailun;
        public static string mailpwd;
        public static string designtrackerurl;
        public static string designtrackerun;
        public static string designtrackerpwd;
        public static string ii4uploadaddressun;
        public static string ii4uploadaddresspwd;
        public static string corporattionname;
        public static string distributorname;

        public static void DatabaseValues()
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;
                string connection = "server=bmi-azdb001.database.windows.net;database=brandmuscleautomation;user=brandmuscle;password=N0tS3arstower";
                string query = "select * from instantimpact";
                conn = new SqlConnection(connection);
                conn.Open();
                cmd = new SqlCommand(query, conn);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        url = (rdr["Url"].ToString());
                        username = (rdr["Username"].ToString());
                        password = (rdr["Password"].ToString());
                        templatename = (rdr["TemplateName"].ToString());
                        quantity = (rdr["Quantity"].ToString());
                        cmusername = (rdr["CMakerUserName"].ToString());
                        cmpassword = (rdr["CMakerPassword"].ToString());
                        templateid = (rdr["TemplateId"].ToString());
                        adminurl = (rdr["AdminUrl"].ToString());
                        clientspecificun = (rdr["ClientSpcicficUn"].ToString());
                        clientspecificpwd = (rdr["ClientSpcicficPwd"].ToString());
                        mailurl = (rdr["MailUrl"].ToString());
                        mailun = (rdr["MailUn"].ToString());
                        mailpwd = (rdr["MailPwd"].ToString());
                        designtrackerurl = (rdr["DesignTrackerUrl"].ToString());
                        designtrackerun = (rdr["DesignTrackerUN"].ToString());
                        designtrackerpwd = (rdr["DesignTrackerPwd"].ToString());
                        ii4uploadaddressun = (rdr["IIUploadAddressUn"].ToString());
                        ii4uploadaddresspwd = (rdr["IIUploadAddressPwd"].ToString());
                        corporattionname = (rdr["Corporationname"].ToString());
                        distributorname = (rdr["Distributorname"].ToString());
                    }
                }
                conn.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Database connection failed due to " + e);
            }    
        }
    }
}

