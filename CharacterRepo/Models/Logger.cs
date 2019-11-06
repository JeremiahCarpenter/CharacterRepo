using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CharacterRepo.Models
{
    public class Logger
    {
        static Logger()
        {
            LoggerConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["LoggerConnectionString"].ConnectionString;
        }
        static string LoggerConnectionString { get; set; }
        public static void Log(Exception ex)
        {
            try
            {
                // write code to Log this exception
                using (SqlConnection con = new SqlConnection(LoggerConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("SP_CREATE_LOGITEM", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@parm_Message", ex.Message);
                        cmd.Parameters.AddWithValue("@parm_Stacktrace", ex.StackTrace.ToString());
                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex2)
            {

                var path = HttpContext.Current.Server.MapPath("~");
                path = path + "errorlog.log";
                System.IO.File.AppendAllText(path, "An error occured while trying to log. The exception is:");
                System.IO.File.AppendAllText(path, ex2.ToString());
                System.IO.File.AppendAllText(path, "The original error was;");
                System.IO.File.AppendAllText(path, ex.ToString());
            }


        }
    }
}