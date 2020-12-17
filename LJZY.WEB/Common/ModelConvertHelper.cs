using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace LJZY.WEB.Common
{
    /// <summary>    
    /// 实体转换辅助类    
    /// </summary>    
    public class ModelConvertHelper<T> where T : new()
    {
        public static List<T> ConvertToModel(DataTable dt, Dictionary<string, string> dic)
        {
            // 定义集合    
            List<T> ts = new List<T>();

            // 获得此模型的类型   
            Type type = typeof(T);
            string tempName = "";


            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性      
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    //tempName = pi.Name;  // 检查DataTable是否包含此列    
                    foreach (var item in dic)
                    {
                        //Console.Write(pi.Name);
                        if (item.Value == pi.Name)
                        {
                            tempName = item.Value;
                            if (dt.Columns.Contains(tempName))
                            {
                                // 判断此属性是否有Setter      
                                if (!pi.CanWrite) continue;

                                object value = dr[tempName];
                                if (value != DBNull.Value && !string.IsNullOrEmpty(value.ToString()))
                                {
                                    //pi.GetMethod.ReturnType;
                                    string typeName = pi.PropertyType.Name;
                                    switch (typeName)
                                    {
                                        case "String":
                                            pi.SetValue(t, value, null);
                                            break;
                                        case "Decimal":

                                            pi.SetValue(t, Convert.ToDecimal(value), null);
                                            break;
                                        case "DateTime":
                                            string time = Convert.ToDateTime(value).ToString("yyyy-MM-dd");
                                            pi.SetValue(t, Convert.ToDateTime(time), null);
                                            break;
                                    }

                                    break;
                                }
                            }

                        }
                    }


                }
                ts.Add(t);
            }
            return ts;
        }

        public static DataTable ConvertToDt(DataTable dt, Dictionary<string, string> dic)
        {

            foreach (var item in dic)
            {
                if (dt.Columns.Contains(item.Key))
                {
                    // 判断此属性是否有Setter      
                    dt.Columns[item.Key].ColumnName = item.Value;
                }
            }

            return dt;
        }

        
    }
}