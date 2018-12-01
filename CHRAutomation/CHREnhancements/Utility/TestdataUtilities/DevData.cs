using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CHREnhancements.Utility.TestdataUtilities
{
    class DevData
    {
        public static HashSet<string> corporationslistindatabase = new HashSet<string>();

        public static void GetDevData()
        {
            try
            {
                SqlConnection conn;
                SqlCommand cmd;
                
                string connection = "server=codb05d.brandmuscle.local;database=centiv_nexiv2;user=nexiv;password=nexiv";
                string corporates= "select a.corpid, c.corporationname  from centiv_nexiv2..FulfillmentCorp a join centiv_nexiv2.dbo.Corporation c on a.CorpId=c.CorpId";
                conn = new SqlConnection(connection);
                conn.Open();
                cmd = new SqlCommand(corporates, conn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        corporationslistindatabase.Add(rdr["corporationname"].ToString());
                    }
                }
                int listsize = corporationslistindatabase.Count;
                Console.WriteLine("Corporation names in database are "+listsize);
                conn.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Database connection failed due to " + e);
            }
        }
    }
}
