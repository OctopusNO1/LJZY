using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LJZY.DAO.LQGL;
using LJZY.MODEL;
using System.Data;

namespace LJZY.BLL.LQGL
{
  public class LQ_SBGLBLL
    {
        private readonly LQ_SBGLDAO dal;
        public LQ_SBGLBLL()
        {
            dal = new LQ_SBGLDAO();
        }

        public Dictionary<string, object> SB_CLDataGrid(string strWhere, int rows, int page)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_SB_CL> list = new List<LQ_SB_CL>();
            DataTable dt = dal.SB_CL_strWhere(strWhere, rows, page, "CCRQ DESC ", out recordCount).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_SB_CL model = new LQ_SB_CL();
                DataRow dr = dt.Rows[i];
                model = dal.SB_CLModel(dr);
                list.Add(model);
            }

            for (int i = 0; i < list.Count; i++)
            {

                if (list[i].CCRQ_GD != "")
                {
                    list[i].CCRQ_GD = Convert.ToDateTime(list[i].CCRQ).ToString("yyyy-MM-dd");
                }
                if (list[i].TCRQ_GD != "")
                {
                    list[i].TCRQ_GD = Convert.ToDateTime(list[i].TCRQ).ToString("yyyy-MM-dd");
                }
            }
            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }

        public Dictionary<string, object> SB_DHFXDataGrid(string strWhere, int rows, int page)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_SB_DHFX> list = new List<LQ_SB_DHFX>();
            DataTable dt = dal.SB_DHFX_strWhere(strWhere, rows, page, "CCRQ DESC ", out recordCount).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_SB_DHFX model = new LQ_SB_DHFX();
                DataRow dr = dt.Rows[i];
                model = dal.SB_DHFXModel(dr);
                list.Add(model);
            }

            for (int i = 0; i < list.Count; i++)
            {

                if (list[i].CCRQ_GD != "")
                {
                    list[i].CCRQ_GD = Convert.ToDateTime(list[i].CCRQ).ToString("yyyy-MM-dd");
                }
                if (list[i].TCRQ_GD != "")
                {
                    list[i].TCRQ_GD = Convert.ToDateTime(list[i].TCRQ).ToString("yyyy-MM-dd");
                }
            }
            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }

        public Dictionary<string, object> SB_GCCSYDataGrid(string strWhere, int rows, int page)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_SB_GCCSY> list = new List<LQ_SB_GCCSY>();
            DataTable dt = dal.SB_GCCSY_strWhere(strWhere, rows, page, "CCRQ DESC ", out recordCount).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_SB_GCCSY model = new LQ_SB_GCCSY();
                DataRow dr = dt.Rows[i];
                model = dal.LQ_SB_GCCSYModel(dr);
                list.Add(model);
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CCRQ_GD != "")
                {
                    list[i].CCRQ_GD = Convert.ToDateTime(list[i].CCRQ).ToString("yyyy-MM-dd");
                }
                if (list[i].TCRQ_GD!="")
                {
                    list[i].TCRQ_GD = Convert.ToDateTime(list[i].TCRQ).ToString("yyyy-MM-dd");
                }
                if (list[i].DXSJ_GD!="")
                {
                    list[i].DXSJ_GD = Convert.ToDateTime(list[i].DXSJ).ToString("yyyy-MM-dd");
                }
              
            }
            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }

        public Dictionary<string, object> SB_WXDataGrid(string strWhere, int rows, int page)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_SB_WX> list = new List<LQ_SB_WX>();
            DataTable dt = dal.SB_WX_strWhere(strWhere, rows, page, "CCRQ DESC ", out recordCount).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_SB_WX model = new LQ_SB_WX();
                DataRow dr = dt.Rows[i];
                model = dal.LQ_SB_WXModel(dr);
                list.Add(model);
            }

            for (int i = 0; i < list.Count; i++)
            {

                if (list[i].CCRQ_GD != "")
                {
                    list[i].CCRQ_GD = Convert.ToDateTime(list[i].CCRQ).ToString("yyyy-MM-dd");
                }
                if (list[i].TCRQ_GD != "")
                {
                    list[i].TCRQ_GD = Convert.ToDateTime(list[i].TCRQ).ToString("yyyy-MM-dd");
                }
            }
            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }

        public Dictionary<string, object> SB_ZHYDataGrid(string strWhere, int rows, int page)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_SB_ZHY> list = new List<LQ_SB_ZHY>();
            DataTable dt = dal.SB_ZHY_strWhere(strWhere, rows, page, "CCRQ DESC ", out recordCount).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_SB_ZHY model = new LQ_SB_ZHY();
                DataRow dr = dt.Rows[i];
                model = dal.LQ_SB_ZHYModel(dr);
                list.Add(model);
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CCRQ_GD != "")
                {
                    list[i].CCRQ_GD = Convert.ToDateTime(list[i].CCRQ).ToString("yyyy-MM-dd");
                }
                if (list[i].TCRQ_GD != "")
                {
                    list[i].TCRQ_GD = Convert.ToDateTime(list[i].TCRQ).ToString("yyyy-MM-dd");
                }
                if (list[i].DXSJ_GD != "")
                {
                    list[i].DXSJ_GD = Convert.ToDateTime(list[i].DXSJ).ToString("yyyy-MM-dd");
                }
            }
            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }

        public Dictionary<string, object> SB_ZSYDataGrid(string strWhere, int rows, int page)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_SB_ZSY> list = new List<LQ_SB_ZSY>();
            DataTable dt = dal.SB_ZSY_strWhere(strWhere, rows, page, "CCRQ DESC ", out recordCount).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_SB_ZSY model = new LQ_SB_ZSY();
                DataRow dr = dt.Rows[i];
                model = dal.LQ_SB_ZSYModel(dr);
                list.Add(model);
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].CCRQ_GD != "")
                {
                    list[i].CCRQ_GD = Convert.ToDateTime(list[i].CCRQ).ToString("yyyy-MM-dd");
                }
                if (list[i].TCRQ_GD != "")
                {
                    list[i].TCRQ_GD = Convert.ToDateTime(list[i].TCRQ).ToString("yyyy-MM-dd");
                }
                if (list[i].DXSJ_GD != "")
                {
                    list[i].DXSJ_GD = Convert.ToDateTime(list[i].DXSJ).ToString("yyyy-MM-dd");
                }
            }
            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }

        public Dictionary<string, object> FW_DataGrid(string strWhere, int rows, int page)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_FW> list = new List<LQ_FW>();
            DataTable dt = dal.FW_strWhere(strWhere, rows, page, "TJRQ DESC ", out recordCount).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_FW model = new LQ_FW();
                DataRow dr = dt.Rows[i];
                model = dal.LQ_FWModel(dr);
                list.Add(model);
            }

            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }

        /// <summary>
        /// 车辆excel导出
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public DataTable Excel_CL(string str)
        {     
            return dal.Excel_CL(str).Tables[0];
        }

        /// <summary>
        /// 卫星excel
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Excel_WX(string strWhere)
        {
            return dal.Excel_WX(strWhere).Tables[0];
        }

        /// <summary>
        /// 钻时仪excel
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Excel_ZSY(string strWhere)
        {
            return dal.Excel_ZSY(strWhere).Tables[0];
        }
        /// <summary>
        /// 工程参数仪excel
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Excel_GCCSY(string strWhere)
        {
            return dal.Excel_GCCSY(strWhere).Tables[0];
        }
        /// <summary>
        /// 地化分析excel
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Excel_DHFX(string strWhere)
        {
            return dal.Excel_DHFX(strWhere).Tables[0];
        }

        /// <summary>
        /// 综合仪excel
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable Excel_ZHY(string strWhere)
        {
            return dal.Excel_ZHY(strWhere).Tables[0];
        }


        public DataTable Excel_FW(string strWhere,string fl)
        {
            return dal.Excel_FW(strWhere,fl).Tables[0];
        }

























        /// <summary>
        /// 车辆添加
        /// </summary>
        /// <param name="cl"></param>
        /// <returns></returns>
        public bool Add_CL(LQ_SB_CL cl)
        {
            return dal.Add_CL(cl);
        }
        /// <summary>
        /// 车辆修改
        /// </summary>
        /// <param name="cl"></param>
        /// <returns></returns>
        public bool Update_CL(LQ_SB_CL cl)
        {
            return dal.Update_CL(cl);
        }

        /// <summary>
        /// 卫星添加
        /// </summary>
        /// <param name="wx"></param>
        /// <returns></returns>
        public bool Add_WX(LQ_SB_WX wx)
        {
            return dal.Add_WX(wx);
        }

        /// <summary>
        /// 卫星修改
        /// </summary>
        /// <param name="wx"></param>
        /// <returns></returns>
        public bool Update_WX(LQ_SB_WX wx)
        {
            return dal.Update_WX(wx);
        }

        /// <summary>
        /// 钻时仪添加
        /// </summary>
        /// <param name="zsy"></param>
        /// <returns></returns>
        public bool Add_ZSY(LQ_SB_ZSY zsy)
        {
            return dal.Add_ZSY(zsy);
        }
        /// <summary>
        /// 钻时仪修改
        /// </summary>
        /// <param name="zsy"></param>
        /// <returns></returns>
        public bool Update_ZSY(LQ_SB_ZSY zsy)
        {
            return dal.Update_ZSY(zsy);
        }

        /// <summary>
        /// 工程参数仪添加
        /// </summary>
        /// <param name="gccsy"></param>
        /// <returns></returns>
        public bool Add_GCCSY(LQ_SB_GCCSY gccsy)
        {
            return dal.Add_GCCSY(gccsy);

        }

        /// <summary>
        /// 工程参数仪修改
        /// </summary>
        /// <param name="gccsy"></param>
        /// <returns></returns>
        public bool Update_GCCSY(LQ_SB_GCCSY gccsy)
        {
            return dal.Update_GCCSY(gccsy);

        }

        /// <summary>
        /// 地化分析仪添加
        /// </summary>
        /// <param name="dhfx"></param>
        /// <returns></returns>
        public bool Add_DHFX(LQ_SB_DHFX dhfx)
        {
            return dal.Add_DHFX(dhfx);
        }

        /// <summary>
        /// 地化分析仪修改
        /// </summary>
        /// <param name="dhfx"></param>
        /// <returns></returns>
        public bool Update_DHFX(LQ_SB_DHFX dhfx)
        {
            return dal.Update_DHFX(dhfx);
        }

        /// <summary>
        /// 综合仪添加
        /// </summary>
        /// <param name="zhy"></param>
        /// <returns></returns>
        public bool Add_ZHY(LQ_SB_ZHY zhy)
        {
            return dal.Add_ZHY(zhy);

        }
        /// <summary>
        /// 综合仪修改
        /// </summary>
        /// <param name="zhy"></param>
        /// <returns></returns>
        public bool Update_ZHY(LQ_SB_ZHY zhy)
        {
            return dal.Update_ZHY(zhy);
        }


        public bool Add_FW(LQ_FW fw)
        {
            return dal.Add_FW(fw);
        }


        public bool Update_FW(LQ_FW fw,string fl)
        {
            return dal.Update_FW(fw,fl);
        }

        public int CheckCL(string ID)
        {
            return dal.CheckCL(ID);
        }

        public int CheckWX(string ID)
        {
            return dal.CheckWX(ID);
        }

        public int CheckZSY(string ID)
        {
            return dal.CheckZSY(ID);
        }

        public int CheckGCCSY(string ID)
        {
            return dal.CheckGCCSY(ID);
        }

        public int CheckDHFX(string ID)
        {
            return dal.CheckDHFX(ID);
        }

        public int CheckZHY(string ID)
        {
            return dal.CheckZHY(ID);
        }

        public int CheckFW(string ID, string FL)
        {
            return dal.CheckFW(ID,FL);
        }
    }
}
