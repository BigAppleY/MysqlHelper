using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace dsbsstj.Helper
{
    public abstract class DataHelper
    {
    
        private static readonly string connectionString = "data source=localhost;database=wedge_lottery_mg_monit;user id=root;password=frontfree;pooling=true;charset=utf8;";
        public static string GetConfig()
        {
           
                return connectionString;
         
        }

        /// <summary>
        /// Dataset转换为实体集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ds"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static List<T> DataSetAToEntitiyList<T>(DataSet ds, int index = 0)
        {
            List<T> list = new List<T>();
            if (ds == null || ds.Tables.Count <= 0)
            {
                return list;
            }
            else if (index > ds.Tables.Count - 1)
            {
                return list;
            }
            else if (index < 0)
            {
                index = 0;
            }
            else if (ds.Tables[index].Rows.Count <= 0)
            {
                return list;
            }

            DataTable dt = ds.Tables[index];
            for (int i = 0, len = dt.Rows.Count; i < len; i++)
            {
                T t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo p in propertys)
                {
                    if (dt.Columns.IndexOf(p.Name.ToUpper()) != -1 && dt.Rows[i][p.Name.ToUpper()] != DBNull.Value)
                    {
                        p.SetValue(t, dt.Rows[i][p.Name.ToUpper()], null);
                    }
                    else
                    {
                        p.SetValue(t, null, null);
                    }

                }
                list.Add(t);
            }
            return list;

        }
    }
}