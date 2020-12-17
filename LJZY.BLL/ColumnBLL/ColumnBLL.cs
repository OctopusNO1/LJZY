using LJZY.DAO.Column;
using LJZY.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.BLL.ColumnBLL
{
	public class ColumnBLL
	{

		private readonly ColumnDAO dal;

		public ColumnBLL()
		{
			dal = new ColumnDAO();
		}
		/// <summary>
		/// 甲方单位下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_SC3()
		{
			string Type = "SC3";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 井型下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_JX()
		{
			string Type = "JX";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 井别下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_TYPE()
		{
			string Type = "REPORT_TYPE";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 地区下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_SC2()
		{
			string Type = "SC2";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 区块下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_QK()
		{
			string Type = "QK";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 录井项目部下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_LJFGS()
		{
			string Type = "LJFGS";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 国家下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_GJ()
		{
			string Type = "GJ";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 市场类型下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_SCFL()
		{
			string Type = "SCFL";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 一级市场下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_SC1()
		{
			string Type = "SC1";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 地质监督所属公司下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_DZJDSSGS()
		{
			string Type = "DZJDSSGS";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 钻井监督所属公司下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_ZJJDSSGS()
		{
			string Type = "ZJJDSSGS";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 录井队号下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_LJDH()
		{
			string Type = "LJDH";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 设备型号下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_LJYQXH()
		{
			string Type = "LJYQXH";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 当前状态下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_DQZT()
		{
			string Type = "DQZT";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 稠油/稀油下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_CHOUXIYOU()
		{
			string Type = "CHOUXIYOU";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 后续井位下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_HXJW()
		{
			string Type = "HXJW";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 后续井队号下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_HXJDH()
		{
			string Type = "HXJDH";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}


		/// <summary>
		/// 井队动态下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_JDDT()
		{
			string Type = "JDDT";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

        /// <summary>
        /// 辖区项目部下拉数据
        /// </summary>
        /// <returns></returns>
        public List<Sys_Dictionary> List_XQXMB()
        {
            string Type = "XQXMB";
            string strWhere = " And PTYPE='" + Type + "'";
            List<Sys_Dictionary> list = new List<Sys_Dictionary> ( );
            DataTable dt = dal.ListSelect ( strWhere ).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sys_Dictionary model = new Sys_Dictionary ( );
                DataRow dr = dt.Rows[i];
                model = dal.DicModel ( dr );
                list.Add ( model );
            }
            return list;
        }

        ///// <summary>
        ///// 井队动态下拉数据
        ///// </summary>
        ///// <returns></returns>
        //public List<Sys_Dictionary> List_JDDT()
        //{
        //	string Type = "JDDT";
        //	string strWhere = " And PTYPE='" + Type + "'";
        //	List<Sys_Dictionary> list = new List<Sys_Dictionary>();
        //	DataTable dt = dal.ListSelect(strWhere).Tables[0];
        //	for (int i = 0; i < dt.Rows.Count; i++)
        //	{
        //		Sys_Dictionary model = new Sys_Dictionary();
        //		DataRow dr = dt.Rows[i];
        //		model = dal.DicModel(dr);
        //		list.Add(model);
        //	}
        //	return list;
        //}

        /// <summary>
        /// 隶属单位下拉数据
        /// </summary>
        /// <returns></returns>
        public List<Sys_Dictionary> List_LSDW()
		{
			string Type = "LSDW";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 项目部井位信息下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_XMBJWXX()
		{
			string Type = "XMBJWXX";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 录井系列下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_LJXL()
		{
			string Type = "LJXL";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 施工单位下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_SGDW()
		{
			string Type = "SGDW";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 施工队号下拉数据
		/// </summary>
		/// <returns></returns>
		public List<Sys_Dictionary> List_SGDH()
		{
			string Type = "SGDH";
			string strWhere = " And PTYPE='" + Type + "'";
			List<Sys_Dictionary> list = new List<Sys_Dictionary>();
			DataTable dt = dal.ListSelect(strWhere).Tables[0];
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				Sys_Dictionary model = new Sys_Dictionary();
				DataRow dr = dt.Rows[i];
				model = dal.DicModel(dr);
				list.Add(model);
			}
			return list;
		}

		/// <summary>
		/// 获取二级目录数据
		/// </summary>
		/// <returns></returns>
		public List<LQ_EJML> EJMLList()
		{
			//List<LQ_EJML> AllList = new List<LQ_EJML>();
			//string strSql = @" AND XH='" + XH + "'";
			DataTable dt = dal.EJML_List().Tables[0];
			List<LQ_EJML> list = new List<LQ_EJML>();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				LQ_EJML model = new LQ_EJML();
				DataRow dr = dt.Rows[i];
				model = dal.EJMLModel(dr);
				list.Add(model);
			}
			string strYear = DateTime.Now.ToString("yyyy");
			LQ_EJML ejmL_Year = new LQ_EJML();
			ejmL_Year.ID = "0";
			ejmL_Year.MC = strYear;
			list.Add(ejmL_Year);
			return list;
		}

		/// <summary>
		/// 获取树状二级目录
		/// </summary>
		/// <returns></returns>
		public List<LQ_EJML> EJMLTreeList()
		{
			List<LQ_EJML> AllList = new List<LQ_EJML>();
			//string strSql = @" AND XH='" + XH + "'";
			DataTable dt = dal.EJML_List().Tables[0];
			List<LQ_EJML> list = new List<LQ_EJML>();
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				LQ_EJML model = new LQ_EJML();
				DataRow dr = dt.Rows[i];
				model = dal.EJMLModel(dr);
				list.Add(model);
			}
			AllList = list.Where(m => m.PID == "0").ToList<LQ_EJML>();
			foreach (LQ_EJML model in list)
			{
				GetTree(list, model);
			}
			return AllList;
		}

		public void GetTree(List<LQ_EJML> allList, LQ_EJML parent)
		{
			//获取子节点
			List<LQ_EJML> childList = allList.Where(m => m.PID == parent.ID).ToList<LQ_EJML>();
			if (childList.Count > 0)
			{
				parent.ItermList = childList;
				foreach (LQ_EJML child in childList)
				{
					GetTree(allList, child);
				}
			}
		}

        public List<Sys_Dictionary> List_GWLB()
        {
            string Type = "GWLB";
            string strWhere = " And PTYPE='" + Type + "'";
            List<Sys_Dictionary> list = new List<Sys_Dictionary>(); 
            DataTable dt = dal.ListSelect(strWhere).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sys_Dictionary model = new Sys_Dictionary();
                DataRow dr = dt.Rows[i];
                model = dal.DicModel(dr);
                list.Add(model);
            }
            return list;
        }

        public List<Sys_Dictionary> List_XMBGW()
        {
            string Type = "GWLB";
            string strWhere = " And PTYPE='" + Type + "'";
            List<Sys_Dictionary> list = new List<Sys_Dictionary>();
            Sys_Dictionary allModel = new Sys_Dictionary();
            allModel.CODE = "";
            allModel.NAME = "全部";
            list.Add(allModel);
            DataTable dt = dal.ListSelect(strWhere).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sys_Dictionary model = new Sys_Dictionary();
                DataRow dr = dt.Rows[i];
                model = dal.DicModel(dr);
                list.Add(model);
            }
            return list;
        }

        public List<Sys_Dictionary> List_XB()
        {
            string Type = "XB";
            string strWhere = " And PTYPE='" + Type + "'";
            List<Sys_Dictionary> list = new List<Sys_Dictionary>();
            DataTable dt = dal.ListSelect(strWhere).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sys_Dictionary model = new Sys_Dictionary();
                DataRow dr = dt.Rows[i];
                model = dal.DicModel(dr);
                list.Add(model);
            }
            return list;
        }

        public List<Sys_Dictionary> List_XL()
        {
            string Type = "XL";
            string strWhere = " And PTYPE='" + Type + "'";
            List<Sys_Dictionary> list = new List<Sys_Dictionary>();
            DataTable dt = dal.ListSelect(strWhere).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sys_Dictionary model = new Sys_Dictionary();
                DataRow dr = dt.Rows[i];
                model = dal.DicModel(dr);
                list.Add(model);
            }
            return list;
        }

        public List<Sys_Dictionary> List_YGXZ()
        {
            string Type = "YGXZ";
            string strWhere = " And PTYPE='" + Type + "'";
            List<Sys_Dictionary> list = new List<Sys_Dictionary>();
            DataTable dt = dal.ListSelect(strWhere).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sys_Dictionary model = new Sys_Dictionary();
                DataRow dr = dt.Rows[i];
                model = dal.DicModel(dr);
                list.Add(model);
            }
            return list;
        }

        public List<Sys_Dictionary> List_JKZK()
        {
            string Type = "JKZK";
            string strWhere = " And PTYPE='" + Type + "'";
            List<Sys_Dictionary> list = new List<Sys_Dictionary>();
            DataTable dt = dal.ListSelect(strWhere).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sys_Dictionary model = new Sys_Dictionary();
                DataRow dr = dt.Rows[i];
                model = dal.DicModel(dr);
                list.Add(model);
            }
            return list;
        }

        public List<Sys_Dictionary> List_ZC()
        {
            string Type = "ZC";
            string strWhere = " And PTYPE='" + Type + "'";
            List<Sys_Dictionary> list = new List<Sys_Dictionary>();
            DataTable dt = dal.ListSelect(strWhere).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sys_Dictionary model = new Sys_Dictionary();
                DataRow dr = dt.Rows[i];
                model = dal.DicModel(dr);
                list.Add(model);
            }
            return list;
        }

        public List<Sys_Dictionary> List_RYZT()
        {
            string Type = "RYZT";
            string strWhere = " And PTYPE='" + Type + "'";
            List<Sys_Dictionary> list = new List<Sys_Dictionary>();
            DataTable dt = dal.ListSelect(strWhere).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sys_Dictionary model = new Sys_Dictionary();
                DataRow dr = dt.Rows[i];
                model = dal.DicModel(dr);
                list.Add(model);
            }
            return list;
        }
    }
}
