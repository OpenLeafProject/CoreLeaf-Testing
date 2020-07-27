using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeafTests
{
    class Tools
    {

        public static Boolean InitDatabase(IConfiguration _config)
        {
            try
            {
                string script = System.IO.File.ReadAllText(@"C:\Projects\CoreLeaf\Database\LeafDBv0.1.sql");

                using (MySqlConnection conn = new MySqlConnection(_config.GetValue<String>("ConnectionStrings:Testing")))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(script, conn);
                    cmd.ExecuteNonQuery();
                }
                return true;

            } catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        private static MySqlConnection GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}
