using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.COMMON
{
    public  static class PagingHelper
    {
        /// <summary>
        /// 获取分页SQL语句，默认row_number为关健字，所有表不允许使用该字段名
        /// </summary>
        /// <param name="_recordCount">记录总数</param>
        /// <param name="_pageSize">每页条数</param>
        /// <param name="_pageIndex">当前页数</param>
        /// <param name="_safeSql">SQL查询语句</param>
        /// <param name="_orderField">排序字段，多个则用“,”隔开</param>
        /// <returns>分页SQL语句</returns>
        public static string CreatePagingSql(int _recordCount, int _pageSize, int _pageIndex, string _safeSql, string _orderField)
        {
            //计算总页数
            _pageSize = _pageSize == 0 ? _recordCount : _pageSize;
            int pageCount = (_recordCount + _pageSize - 1) / _pageSize;

            //检查当前页数
            if (_pageIndex < 1)
            {
                _pageIndex = 1;
            }
            else if (_pageIndex > pageCount)
            {
                _pageIndex = pageCount;
            }
            //拼接SQL字符串，加上ROW_NUMBER函数进行分页
            StringBuilder newSafeSql = new StringBuilder();
            newSafeSql.AppendFormat("SELECT ROW_NUMBER() OVER(ORDER BY {0})  row_number,", _orderField);
            newSafeSql.Append(_safeSql.Substring(_safeSql.ToUpper().IndexOf("SELECT") + 6));

            //拼接成最终的SQL语句
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM (");
            sbSql.Append(newSafeSql.ToString());
            sbSql.Append(")  T");
            sbSql.AppendFormat(" WHERE row_number between {0} and {1}", ((_pageIndex - 1) * _pageSize) + 1, _pageIndex * _pageSize);

            return sbSql.ToString();
        }

        public static string CreatePagingSqls( int _recordCount, int _pageSize, int _pageIndex, string _safeSql, string _orderField )
        {
            //计算总页数
            _pageSize = _pageSize == 0 ? _recordCount : _pageSize;
            int pageCount = ( _recordCount + _pageSize - 1 ) / _pageSize;

            //检查当前页数
            if (_pageIndex < 1)
            {
                _pageIndex = 1;
            }
            else if (_pageIndex > pageCount)
            {
                _pageIndex = pageCount;
            }
            //拼接SQL字符串，加上ROW_NUMBER函数进行分页
            StringBuilder newSafeSql = new StringBuilder ( );
            newSafeSql.AppendFormat ( "SELECT ROW_NUMBER() OVER(ORDER BY {0})  row_number,", _orderField );
            newSafeSql.Append ( _safeSql.Substring ( _safeSql.ToUpper ( ).IndexOf ( "SELECT *" ) + 6 ) );

            //拼接成最终的SQL语句
            StringBuilder sbSql = new StringBuilder ( );
            sbSql.Append ( "SELECT * FROM (" );
            sbSql.Append ( newSafeSql.ToString ( ) );
            sbSql.Append ( ")  T" );
            sbSql.AppendFormat ( " WHERE row_number between {0} and {1}", ( ( _pageIndex - 1 ) * _pageSize ) + 1, _pageIndex * _pageSize );

            return sbSql.ToString ( );
        }

        /// <summary>
        /// 获取记录总数SQL语句
        /// </summary>
        /// <param name="_safeSql">SQL查询语句</param>
        /// <returns>记录总数SQL语句</returns>
        public static string CreateCountingSql(string _safeSql)
        {
            return string.Format(" SELECT COUNT(1) RecordCount FROM ({0}) T ", _safeSql);
        }
        /// <summary>
        /// 临时任务专属分页方法
        /// </summary>
        /// <param name="_recordCount"></param>
        /// <param name="_pageSize"></param>
        /// <param name="_pageIndex"></param>
        /// <param name="_safeSql"></param>
        /// <param name="_orderField"></param>
        /// <returns></returns>
        public static string PagingSql(int _recordCount, int _pageSize, int _pageIndex, string _safeSql, string _orderField)
        {
            //计算总页数
            _pageSize = _pageSize == 0 ? _recordCount : _pageSize;
            int pageCount = (_recordCount + _pageSize - 1) / _pageSize;

            //检查当前页数
            if (_pageIndex < 1)
            {
                _pageIndex = 1;
            }
            else if (_pageIndex > pageCount)
            {
                _pageIndex = pageCount;
            }
            //拼接成最终的SQL语句
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat(@" SELECT *
             FROM   ( SELECT    ROW_NUMBER() OVER ( ORDER BY {0}) row_number ,
                                *
                      FROM      ( {1}
                                ) t
                    ) t1
             WHERE  1 = 1
                    AND t1.row_number BETWEEN {2} AND {3}", _orderField, _safeSql, ((_pageIndex - 1) * _pageSize) + 1, _pageIndex * _pageSize);
            return sbSql.ToString();
        }

    }
}
