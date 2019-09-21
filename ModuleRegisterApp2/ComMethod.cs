using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ModuleRegisterApp2
{
    public class ComMethod
    {
        public static DataTable ConverToDataTable<T>(List<T> entitys)
        {
            if (entitys == null || entitys.Count < 1)
            {
                return new DataTable();
            }
            try
            {
                Type entityType = entitys[0].GetType();
                //取得对象所有的属性
                PropertyInfo[] entityProperties = entityType.GetProperties();
                DataTable dt = new DataTable("dt");
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    //按对象属性添加DataTable的列
                    dt.Columns.Add(entityProperties[i].Name);
                }
                foreach (object entity in entitys)
                {
                    //定义一个object数组存放，再将数组添加到DataTable行
                    object[] entityValue = new object[entityProperties.Length];
                    for (int i = 0; i < entityValue.Length; i++)
                    {
                        entityValue[i] = entityProperties[i].GetValue(entity, null);
                    }
                    dt.Rows.Add(entityValue);
                }
                return dt;
            }
            catch
            {
                return new DataTable();
            }
        }

        public List<T> DateTableConverToList<T>(DataTable dt) where T : class, new()
        {
            if (dt == null || dt.Rows.Count < 1)
            {
                return null;
            }
            try
            {
                List<T> ts = new List<T>();
                string tempName;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    T t = new T();
                    for (int c = 0; c < dt.Columns.Count; c++)
                    {
                        foreach (PropertyInfo pi in t.GetType().GetProperties())
                        {
                            tempName = pi.Name;
                            if (dt.Columns.Contains(tempName))
                            {
                                object obj = dt.Rows[i][tempName];
                                if (obj != DBNull.Value)
                                {
                                    pi.SetValue(t, obj, null);
                                }
                            }
                        }
                    }
                    ts.Add(t);
                }
                return ts;
            }
            catch
            {
                return null;
            }
        }
    }
}
