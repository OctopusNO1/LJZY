using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace LJZY.COMMON
{
    /// <summary>
    /// 将DataTable 转化成List<T>或将List<T>转化成DataTable的静态类/将Class转化成RowObject
    /// </summary>
    public static class SQlDataExtensions
    {
        /// <summary>
        /// DataRow扩展方法：将DataRow类型转化为指定类型的实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns></returns>
        public static T ToModel<T>(this DataRow dr) where T : class, new()
        {
            return ToModel<T>(dr, true);
        }
        /// <summary>
        /// DataRow扩展方法：将DataRow类型转化为指定类型的实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="dateTimeToString">是否需要将日期转换为字符串，默认为转换,值为true</param>
        /// <returns></returns>
        /// <summary>
        public static T ToModel<T>(this DataRow dr, bool dateTimeToString) where T : class, new()
        {
            if (dr != null)
                return ToList<T>(dr.Table, dateTimeToString).First();
            return null;
        }
        /// <summary>
        /// DataTable扩展方法：将DataTable类型转化为指定类型的实体集合
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dt) where T : class, new()
        {
            return ToList<T>(dt, true);
        }
        /// <summary>
        /// DataTable扩展方法：将DataTable类型转化为指定类型的实体集合
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="dateTimeToString">是否需要将日期转换为字符串，默认为转换,值为true</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dt, bool dateTimeToString) where T : class, new()
        {
            List<T> list = new List<T>();

            if (dt != null)
            {
                List<PropertyInfo> infos = new List<PropertyInfo>();
                Array.ForEach<PropertyInfo>(typeof(T).GetProperties(), p =>
                {
                    if (dt.Columns.Contains(p.Name) == true)
                    {
                        infos.Add(p);
                    }
                });
                SetList<T>(list, infos, dt, dateTimeToString);
            }
            return list;
        }
        /// <summary>
        /// 将RowObject 转化成Table.Row 单个类的转化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DataTable ToDataTableRow<T>(T value) where T : class
        {
            //属性集合
            List<PropertyInfo> PList = new List<PropertyInfo>();

            //反射获得入口
            Type type = typeof(T);

            DataTable dt = new DataTable();

            Array.ForEach<PropertyInfo>(type.GetProperties(), p => { PList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });

            DataRow row = dt.NewRow();

            PList.ForEach(p => { row[p.Name] = p.GetValue(value, null); });

            dt.Rows.Add(row);

            return dt;
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> value) where T : class
        {

            //创建属性的集合

            List<PropertyInfo> pList = new List<PropertyInfo>();

            //获得反射的入口

            Type type = typeof(T);

            DataTable dt = new DataTable();

            //把所有的public属性加入到集合 并添加DataTable的列

            Array.ForEach<PropertyInfo>(type.GetProperties(), p => { pList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); });

            foreach (var item in value)
            {

                //创建一个DataRow实例

                DataRow row = dt.NewRow();

                //给row 赋值

                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));

                //加入到DataTable

                dt.Rows.Add(row);

            }

            return dt;

        }

        public static T ToRowObject<T>(this DataTable dt) where T : class, new()
        {
            return ToRowObject<T>(dt, true);
        }
        /// <summary>
        /// DataTable扩展方法：将DataTable类型转化为指定类型的实体集合
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="dateTimeToString">是否需要将日期转换为字符串，默认为转换,值为true</param>
        /// <returns></returns>
        public static T ToRowObject<T>(this DataTable dt, bool dateTimeToString) where T : class, new()
        {
            T RowObject = new T();

            if (dt != null)
            {
                List<PropertyInfo> infos = new List<PropertyInfo>();
                Array.ForEach<PropertyInfo>(typeof(T).GetProperties(), p =>
                {
                    if (dt.Columns.Contains(p.Name) == true)
                    {
                        infos.Add(p);
                    }
                });


                foreach (DataRow dr in dt.Rows)
                {
                    infos.ForEach(p =>
                    {
                        if (dr[p.Name] != DBNull.Value)
                        {
                            object tempValue = dr[p.Name];
                            if (dr[p.Name].GetType() == typeof(DateTime) && dateTimeToString == true)
                            {
                                tempValue = dr[p.Name].ToString();
                            }
                            try
                            {
                                p.SetValue(RowObject, tempValue, null);

                            }
                            catch { }
                        }
                    });


                }
            }
            return RowObject;
        }

        #region 私有方法
        private static void SetList<T>(List<T> list, List<PropertyInfo> infos, DataTable dt, bool dateTimeToString) where T : class, new()
        {
            foreach (DataRow dr in dt.Rows)
            {
                T model = new T();
                infos.ForEach(p =>
                {
                    if (dr[p.Name] != DBNull.Value)
                    {
                        object tempValue = dr[p.Name];
                        if (dr[p.Name].GetType() == typeof(DateTime) && dateTimeToString == true)
                        {
                            tempValue = dr[p.Name];
                        }
                        try
                        {
                            p.SetValue(model, tempValue, null);
                        }
                        catch { }
                    }
                });
                list.Add(model);
            }
        }
        #endregion
    }
}
