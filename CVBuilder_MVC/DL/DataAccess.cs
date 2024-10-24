using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace CVBuilder_MVC.DL
{
    public class DataAccess
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());

        //  SqlConnection con = new SqlConnection("data source=IRFANKHAN; initial catalog=POS_DB; User ID=sa;Password=sa!@");
        // static SqlConnection con = new SqlConnection("data source=IRFANKHAN; initial catalog=POS_DB;  integrated security=true");
        /// <summary>
        ///   execute query hmry pass plain query k ley function hey jo insert delete ur update kar skta hey   
        /// </summary>
        /// <param name="query">
        /// query parameter k under ap ny front end sy query passs karni hey insert delete ya update ki
        /// </param>
        /// <returns></returns>
        public static bool ExecuteQuery(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {

                con.Close();
                return false;
            }


        }

        /// <summary>
        ///  yeh function hmry pass parameterize query k ley hey       
        /// </summary>
        /// <param name="query">
        /// front end sy parameterize query pass karen
        /// </param>
        /// <param name="prm">
        /// sth main parameters ki array pass karen
        /// </param>

        /// <returns></returns>
        public static bool ExecuteQuery(string query, SqlParameter[] prm)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddRange(prm);
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {

                con.Close();
                return false;
            }


        }
        public static bool sp_ExecuteQuery(string ProcName, SqlParameter[] prm)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = ProcName;
                cmd.Parameters.AddRange(prm);
                con.Open();

                cmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch
            {

                con.Close();
                return false;
            }


        }
        public static DataTable GetTable(string query)
        {
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable GetTable(string query, SqlParameter[] prm)
        {
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddRange(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //SqlDataAdapter da = new SqlDataAdapter(query, con);
            //da.SelectCommand.Parameters.AddRange(prm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable sp_GetTable(string ProcName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ProcName;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //SqlDataAdapter da = new SqlDataAdapter(query, con);
            //da.SelectCommand.Parameters.AddRange(prm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataTable sp_GetTable(string ProcName, SqlParameter[] prm)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = ProcName;
            cmd.Parameters.AddRange(prm);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //SqlDataAdapter da = new SqlDataAdapter(query, con);
            //da.SelectCommand.Parameters.AddRange(prm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}