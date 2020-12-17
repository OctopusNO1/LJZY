using LJZY.DBUtility;
using LJZY.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.DAO.Column
{
	public class ColumnDAO
	{
		/// <summary>
		/// 查询二级目录所有数据
		/// </summary>
		/// <returns></returns>
		public DataSet EJML_List()
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append(" select t.* from LQ_EJML t");
			strSql.Append(" ORDER BY PX ");
			DataSet ds = DbHelperOra.Query(strSql.ToString());
			return ds;
		}

	
		#region 下拉框查询
		/// <summary>
		/// 根据条件获取下拉数据
		/// </summary>
		/// <param name="strWhere"></param>
		/// <returns></returns>
		public DataSet ListSelect(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT NAME, CODE, PTYPE  FROM Sys_Dictionary");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" WHERE 1=1" + strWhere);
			}
			strSql.Append(" ORDER BY CODE ");

			return DbHelperOra.Query(strSql.ToString());
		}
		#endregion

		/// <summary>
		/// 字典实体类
		/// </summary>
		/// <returns></returns>
		public Sys_Dictionary DicModel(DataRow dr)
		{
			Sys_Dictionary model = new Sys_Dictionary();
			if (dr["CODE"] != null && dr["CODE"].ToString() != "")
			{
				model.CODE = dr["CODE"].ToString();
			}

			if (dr["NAME"] != null && dr["NAME"].ToString() != "")
			{
				model.NAME = dr["NAME"].ToString();
			}

			if (dr["PTYPE"] != null && dr["PTYPE"].ToString() != "")
			{
				model.PTYPE = dr["PTYPE"].ToString();
			}
			return model;

		}

		/// <summary>
		/// 二级目录实体类
		/// </summary>
		/// <param name="dr"></param>
		/// <returns></returns>
		public LQ_EJML EJMLModel(DataRow dr)
		{
			LQ_EJML model = new LQ_EJML();
			if (dr["ID"] != null && dr["ID"].ToString() != "")
			{
				model.ID = dr["ID"].ToString();
			}

			if (dr["MC"] != null && dr["MC"].ToString() != "")
			{
				model.MC = dr["MC"].ToString();
			}

			if (dr["BM"] != null && dr["BM"].ToString() != "")
			{
				model.BM = dr["BM"].ToString();
			}

			if (dr["PID"] != null && dr["PID"].ToString() != "")
			{
				model.PID = dr["PID"].ToString();
			}

			if (dr["TJR"] != null && dr["TJR"].ToString() != "")
			{
				model.TJR = dr["TJR"].ToString();
			}

			if (dr["TJSJ"] != null && dr["TJSJ"].ToString() != "")
			{
				model.TJSJ = Convert.ToDateTime(dr["TJSJ"]);
			}
			return model;

		}
	}
}
