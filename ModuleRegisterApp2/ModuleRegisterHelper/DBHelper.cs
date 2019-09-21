using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Npgsql;

namespace ModuleRegisterApp2
{
    public class DBHelper
    {
        static string conStr = ConfigurationManager.AppSettings["ThisSysDB"].ToString();
        static NpgsqlConnection con;

        public static void ExecuteRefDT(string sql,ref DataTable dt)
        {
            using (con = new NpgsqlConnection(conStr))
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
                da.Fill(dt);
            }
        }

        public static bool WriteRecord(string[] tmp)
        {
            using (con = new NpgsqlConnection(conStr))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = con;
                NpgsqlTransaction tran = con.BeginTransaction();
                cmd.Transaction = tran;
                try
                {
                    for(int i=0;i<tmp.Length;i++)
                    {
                        cmd.CommandText = tmp[i];
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
                catch(Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    tran.Rollback();
                    return false;
                }
                return true;
            }
        }

        public static string GetNewRecordId()
        {
            string newid = "";
            using (con = new NpgsqlConnection(conStr))
            {
                con.Open();
                string sql0 = "LOCK TABLE t_record IN ACCESS EXCLUSIVE MODE";
                string sql1 = "select MAX(record_id) from t_record where register_date >='" + DateTime.Now.ToString("yyyy/MM/dd 00:00:00") + "'";
                NpgsqlTransaction tran = con.BeginTransaction();
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(sql0, con);
                    cmd.ExecuteNonQuery();
                    cmd = new NpgsqlCommand(sql1, con);
                    newid = cmd.ExecuteScalar().ToString();
                    if (newid == string.Empty)
                    {
                        newid = DateTime.Now.ToString("yyyyMMdd") + "P" + "001";
                    }
                    else
                    {
                        string tmp = "00" + (int.Parse(newid.Substring(9, 3)) + 1).ToString();
                        newid = newid.Substring(0, 8) + "P" + tmp.Substring(tmp.Length - 3, 3);
                    }
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }
            return newid;
        }

        public static string GetNewCartonId()
        {
            string newid = "";
            using (con = new NpgsqlConnection(conStr))
            {
                con.Open();
                string sql0 = "LOCK TABLE t_record IN ACCESS EXCLUSIVE MODE";
                string sql1 = "select MAX(record_id) from t_record where register_date >='" + DateTime.Now.ToString("yyyy/MM/dd 00:00:00") + "'";
                NpgsqlTransaction tran = con.BeginTransaction();
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(sql0, con);
                    cmd.ExecuteNonQuery();
                    cmd = new NpgsqlCommand(sql1, con);
                    newid = cmd.ExecuteScalar().ToString();
                    if (newid == string.Empty)
                    {
                        newid = DateTime.Now.ToString("yyyyMMdd") + "C" + "001";
                    }
                    else
                    {
                        string tmp = "00" + (int.Parse(newid.Substring(9, 3)) + 1).ToString();
                        newid = newid.Substring(0, 8) + "C" + tmp.Substring(tmp.Length - 3, 3);
                    }
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }
            return newid;
        }
    }
}
