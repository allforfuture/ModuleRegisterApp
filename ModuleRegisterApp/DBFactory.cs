using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;

using Npgsql;

namespace ModuleRegisterApp
{
    public class DBFactory
    {
		//static string DbConnectstring = ConfigurationManager.AppSettings["pqmcon"].ToString();
		static string DbConnectstring = ConfigurationManager.ConnectionStrings["pqmcon"].ToString();
		static string AOIDbConnectstringK6 = ConfigurationManager.AppSettings["pqmcon_aoiK6"].ToString();
		static string AOIDbConnectstringK7 = ConfigurationManager.AppSettings["pqmcon_aoiK7"].ToString();
		static string AOIDbConnectstringK4 = ConfigurationManager.AppSettings["pqmcon_aoiK4"].ToString();
		NpgsqlConnection con;
        
        public int ExecuteSQL(string sql)
        {
            using (con = new NpgsqlConnection(DbConnectstring))
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql,con);
                int result = cmd.ExecuteNonQuery();
                return result;                
            }
        }

        public void ExecuteDataTable(string sql,ref DataTable dt)
        {
            using (con = new NpgsqlConnection(DbConnectstring))
            {
                try
                { 
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
                    da.Fill(dt);
                }
                catch(Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            }
        }

        public void ExecuteTran(ref DataTable dt)
        {
            using (con = new NpgsqlConnection(DbConnectstring))
            {
                NpgsqlTransaction tran;
                NpgsqlCommand cmd=new NpgsqlCommand();
                cmd.Connection = con;
                tran = cmd.Transaction;
                try
                {
                    string newRecordId = GetNewRecordId();
                    cmd.CommandText = "insert into t_record values('" + newRecordId + "','" + dt.Rows[0]["holder_dept"].ToString() + "','" + dt.Rows[0]["holder_dept"].ToString() + "'," +
                        "'" + dt.Rows[0]["holder_emp"].ToString() + "','" + dt.Rows[0]["holder_name"].ToString() + "','" + dt.Rows[0]["register_emp"].ToString() + "',getdate(),'',0,'n','" + dt.Rows[0]["reason"].ToString() + "'";
                    cmd.ExecuteNonQuery();
                    for (int i=0;i<dt.Rows.Count;i++)
                    {
                        cmd = new NpgsqlCommand("insert into t_module values('"+ newRecordId +"','" + dt.Rows[0]["serial_cd"].ToString() + "','" + dt.Rows[0]["model"].ToString() + "')", con);
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }
        }

        public bool ExecuteObject(ref RecordInfo info)
        {
            using (con = new NpgsqlConnection(DbConnectstring))
            {
                con.Open();
                NpgsqlTransaction tran = con.BeginTransaction();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = con;
                try
                {
                    // modify date:2018-06-05 将register_date的时间改为数据的时间
                    string newRecordId = GetNewRecordId();
                    info.record_id = newRecordId;
					cmd.CommandText = "insert into t_record(record_id,site,holder_dept,holder_emp,holder_name,register_emp,register_date,type,category_id,category_cd) values('" + newRecordId + "','" + info.site + "','" + info.holder_dept + "'," +
						"'" + info.holder_emp + "','" + info.holder_name + "','" + info.register_emp + "',now(),'" + info.type + "','" + info.statue + "','" + info.reason + "')";
					cmd.ExecuteNonQuery();
					//事务
                    foreach (serial se in info.serials)
                    {
                        cmd.CommandText = "insert into t_module values('" + newRecordId + "','" + se.serial_cd + "','" + se.model + "','"+se.category+"')";
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    return true;
                }
                catch(Exception ex)
                {
                    tran.Rollback();
                    System.Windows.Forms.MessageBox.Show(ex.Message,"数据库增加记录失败：",
                        System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
                    return false;
                }
            }
        }
        
        private string GetNewRecordId()
        {
            string newid = "";
            using (con = new NpgsqlConnection(DbConnectstring))
            {
                con.Open();
                string sql0 = "LOCK TABLE t_record IN ACCESS EXCLUSIVE MODE";
                //string sql1 = "select MAX(record_id) from t_record where register_date >='" + DateTime.Now.ToString("yyyy/MM/dd 00:00:00") + "'";
                string sql1 = "select MAX(record_id) from t_record where register_date >=current_date";
                NpgsqlTransaction tran = con.BeginTransaction();
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(sql0, con);
                    cmd.ExecuteNonQuery();
                    cmd = new NpgsqlCommand(sql1, con);
					//运行标量cmd.ExecuteScalar(),获取select的值
					newid = cmd.ExecuteScalar().ToString();
                    if(newid==string.Empty)
                    {
                        //不取电脑的时间来做ID，以为要是电脑时间
                        //newid = DateTime.Now.ToString("yyyyMMdd") +"P"+ "001";
                        cmd = new NpgsqlCommand("select to_char(current_date,'yyyyMMddP001')", con);
                        newid = cmd.ExecuteScalar().ToString();
                    }
                    else
                    {
                        string tmp = "00" + (int.Parse(newid.Substring(9, 3)) + 1).ToString();
                        newid = newid.Substring(0,8)+"P"+tmp.Substring(tmp.Length-3,3);
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

        public string GetNewCartonId(string db,string identifier)
        {
            string newid = "";
            using (con = new NpgsqlConnection(DbConnectstring))
            {
                con.Open();
                string sql0 = $"LOCK TABLE t_{db} IN ACCESS EXCLUSIVE MODE";
                string sql1 = string.Format(
@"SELECT MAX({0}_id)
FROM t_{0}
WHERE create_date >='{1}'
AND SUBSTRING(carton_id FROM 9 FOR 1)='{2}'",
db, DateTime.Now.ToString("yyyy-MM-dd"), identifier);
                
                NpgsqlTransaction tran = con.BeginTransaction();
                try
                {
                    NpgsqlCommand cmd = new NpgsqlCommand(sql0, con);
                    cmd.ExecuteNonQuery();
                    cmd = new NpgsqlCommand(sql1, con);
					
					newid = cmd.ExecuteScalar().ToString();//运行标量cmd.ExecuteScalar(),获取select的值
                    if (newid == string.Empty)
                    {
                        switch (identifier)
                        {
                            //报废装箱
                            case "C":
                                newid = DateTime.Now.ToString("yyyyMMdd") + "C" + "001";
                                break;
                            //报废装大箱
                            case "B":
                                newid = DateTime.Now.ToString("yyyyMMdd") + "B" + "001";
                                break;
                            //保留品装箱
                            case "R":
                                newid = DateTime.Now.ToString("yyyyMMdd") + "R" + "001";
                                break;
                            //保留品装大箱
                            case "L":
                                newid = DateTime.Now.ToString("yyyyMMdd") + "L" + "001";
                                break;
                        }
                    }
                    else
                    {
                        string tmp = "00" + (int.Parse(newid.Substring(9, 3)) + 1).ToString();
                        switch (identifier)
                        {
                            case "C":
                                newid = newid.Substring(0, 8) + "C" + tmp.Substring(tmp.Length - 3, 3);
                                break;
                            case "B":
                                newid = newid.Substring(0, 8) + "B" + tmp.Substring(tmp.Length - 3, 3);
                                break;
                            case "R":
                                newid = newid.Substring(0, 8) + "R" + tmp.Substring(tmp.Length - 3, 3);
                                break;
                            case "L":
                                newid = newid.Substring(0, 8) + "L" + tmp.Substring(tmp.Length - 3, 3);
                                break;
                        }
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

        public void ExcuteDataTableAOI(string model,string sql,ref DataTable dt)
        {
            string DBConStr;
            switch (model)
            {
                case "KK06":
                    DBConStr = AOIDbConnectstringK6;
                    break;
                case "KK04":
                    DBConStr = AOIDbConnectstringK4;
                    break;
                case "KK07":
                    DBConStr = AOIDbConnectstringK7;
                    break;
                default:
                    DBConStr = AOIDbConnectstringK6;
                    break;
            }
            using (con = new NpgsqlConnection(DBConStr))
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
                da.Fill(dt);
            }
        }
    }
}
