using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LJZY.MODEL;
using System.Data;
using LJZY.DBUtility;
using LJZY.COMMON;
using Oracle.DataAccess.Client;

namespace LJZY.DAO.LQGL
{
    public class LQ_SBGLDAO
    {
        //车辆model
        public LQ_SB_CL SB_CLModel(DataRow dr)
        {
            LQ_SB_CL model = new LQ_SB_CL();
            if (dr["ID"] != null && dr["ID"].ToString() != "")
            {
                model.ID = dr["ID"].ToString();
            }

            if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            {
                model.TROW = Convert.ToInt32(dr["TROW"]);
            }

            if (dr["DW"] != null && dr["DW"].ToString() != "")
            {
                model.DW = dr["DW"].ToString();
            }

            if (dr["SBMC"] != null && dr["SBMC"].ToString() != "")
            {
                model.SBMC = dr["SBMC"].ToString();
            }

            if (dr["GGXH"] != null && dr["GGXH"].ToString() != "")
            {
                model.GGXH = dr["GGXH"].ToString();
            }

            if (dr["SCCJ"] != null && dr["SCCJ"].ToString() != "")
            {
                model.SCCJ = dr["SCCJ"].ToString();
            }

            if (dr["GB"] != null && dr["GB"].ToString() != "")
            {
                model.GB = dr["GB"].ToString();
            }

            if (dr["CCRQ"] != null && dr["CCRQ"].ToString() != "")
            {
                model.CCRQ = Convert.ToDateTime(dr["CCRQ"]);
                model.CCRQ_GD= Convert.ToDateTime(dr["CCRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.CCRQ_GD = "";
            }

            if (dr["CCBH"] != null && dr["CCBH"].ToString() != "")
            {
                model.CCBH = dr["CCBH"].ToString();
            }

            if (dr["TCRQ"] != null && dr["TCRQ"].ToString() != "")
            {
                model.TCRQ = Convert.ToDateTime(dr["TCRQ"]);
                model.TCRQ_GD = Convert.ToDateTime(dr["TCRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.TCRQ_GD = "";
            }

            if (dr["ZJNX"] != null && dr["ZJNX"].ToString() != "")
            {
                model.ZJNX = Convert.ToInt32(dr["ZJNX"]);
            }

            if (dr["RLFL"] != null && dr["RLFL"].ToString() != "")
            {
                model.RLFL = dr["RLFL"].ToString();
            }

            if (dr["SBZK"] != null && dr["SBZK"].ToString() != "")
            {
                model.SBZK = dr["SBZK"].ToString();
            }

            if (dr["SBSZWZ"] != null && dr["SBSZWZ"].ToString() != "")
            {
                model.SBSZWZ = dr["SBSZWZ"].ToString();
            }

            if (dr["DXQK"] != null && dr["DXQK"].ToString() != "")
            {
                model.DXQK = dr["DXQK"].ToString();
            }

            if (dr["BZ"] != null && dr["BZ"].ToString() != "")
            {
                model.BZ = dr["BZ"].ToString();
            }
  
            return model;

        }

        //地化model
        public LQ_SB_DHFX SB_DHFXModel(DataRow dr)
        {
            LQ_SB_DHFX model = new LQ_SB_DHFX();
            if (dr["ID"] != null && dr["ID"].ToString() != "")
            {
                model.ID = dr["ID"].ToString();
            }

            if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            {
                model.TROW = Convert.ToInt32(dr["TROW"]);
            }

            if (dr["DW"] != null && dr["DW"].ToString() != "")
            {
                model.DW = dr["DW"].ToString();
            }

            if (dr["SBMC"] != null && dr["SBMC"].ToString() != "")
            {
                model.SBMC = dr["SBMC"].ToString();
            }

            if (dr["GGXH"] != null && dr["GGXH"].ToString() != "")
            {
                model.GGXH = dr["GGXH"].ToString();
            }

            if (dr["SCCJ"] != null && dr["SCCJ"].ToString() != "")
            {
                model.SCCJ = dr["SCCJ"].ToString();
            }

            if (dr["GB"] != null && dr["GB"].ToString() != "")
            {
                model.GB = dr["GB"].ToString();
            }

            if (dr["CCRQ"] != null && dr["CCRQ"].ToString() != "")
            {
                model.CCRQ = Convert.ToDateTime(dr["CCRQ"]);
                model.CCRQ_GD = Convert.ToDateTime(dr["CCRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.CCRQ_GD = "";
            }

            if (dr["CCBH"] != null && dr["CCBH"].ToString() != "")
            {
                model.CCBH = dr["CCBH"].ToString();
            }

            if (dr["TCRQ"] != null && dr["TCRQ"].ToString() != "")
            {
                model.TCRQ = Convert.ToDateTime(dr["TCRQ"]);
                model.TCRQ_GD = Convert.ToDateTime(dr["TCRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.TCRQ_GD = "";
            }

            if (dr["ZBH"] != null && dr["ZBH"].ToString() != "")
            {
                model.ZBH = dr["ZBH"].ToString();
            }

            if (dr["SBSZWZ"] != null && dr["SBSZWZ"].ToString() != "")
            {
                model.SBSZWZ = dr["SBSZWZ"].ToString();
            }

            if (dr["SBZK"] != null && dr["SBZK"].ToString() != "")
            {
                model.SBZK = dr["SBZK"].ToString();
            }

            if (dr["SSDW"] != null && dr["SSDW"].ToString() != "")
            {
                model.SSDW = dr["SSDW"].ToString();
            }

            if (dr["BZ"] != null && dr["BZ"].ToString() != "")
            {
                model.BZ = dr["BZ"].ToString();
            }

            return model;

        }

        //工程参数model
        public LQ_SB_GCCSY LQ_SB_GCCSYModel(DataRow dr)
        {
            LQ_SB_GCCSY model = new LQ_SB_GCCSY();
            if (dr["ID"] != null && dr["ID"].ToString() != "")
            {
                model.ID = dr["ID"].ToString();
            }

            if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            {
                model.TROW = Convert.ToInt32(dr["TROW"]);
            }

            if (dr["DW"] != null && dr["DW"].ToString() != "")
            {
                model.DW = dr["DW"].ToString();
            }

            if (dr["SBMC"] != null && dr["SBMC"].ToString() != "")
            {
                model.SBMC = dr["SBMC"].ToString();
            }

            if (dr["GGXH"] != null && dr["GGXH"].ToString() != "")
            {
                model.GGXH = dr["GGXH"].ToString();
            }

            if (dr["SCCJ"] != null && dr["SCCJ"].ToString() != "")
            {
                model.SCCJ = dr["SCCJ"].ToString();
            }

            if (dr["GB"] != null && dr["GB"].ToString() != "")
            {
                model.GB = dr["GB"].ToString();
            }

            if (dr["CCRQ"] != null && dr["CCRQ"].ToString() != "")
            {
                model.CCRQ = Convert.ToDateTime(dr["CCRQ"]);
                model.CCRQ_GD = Convert.ToDateTime(dr["CCRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.CCRQ_GD = "";
            }

            if (dr["CCBH"] != null && dr["CCBH"].ToString() != "")
            {
                model.CCBH = dr["CCBH"].ToString();
            }

            if (dr["TCRQ"] != null && dr["TCRQ"].ToString() != "")
            {
                model.TCRQ = Convert.ToDateTime(dr["TCRQ"]);
                model.TCRQ_GD = Convert.ToDateTime(dr["TCRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.TCRQ_GD = "";
            }

            if (dr["SBXBH"] != null && dr["SBXBH"].ToString() != "")
            {
                model.SBXBH = dr["SBXBH"].ToString();
            }

            if (dr["SBZBH"] != null && dr["SBZBH"].ToString() != "")
            {
                model.SBZBH = dr["SBZBH"].ToString();
            }

            if (dr["SBZK"] != null && dr["SBZK"].ToString() != "")
            {
                model.SBZK = dr["SBZK"].ToString();
            }

            if (dr["SBSZWZ"] != null && dr["SBSZWZ"].ToString() != "")
            {
                model.SBSZWZ = dr["SBSZWZ"].ToString();
            }

            if (dr["BZ"] != null && dr["BZ"].ToString() != "")
            {
                model.BZ = dr["BZ"].ToString();
            }

            if (dr["DXSJ"] != null && dr["DXSJ"].ToString() != "")
            {
                model.DXSJ = Convert.ToDateTime(dr["DXSJ"]);
                model.DXSJ_GD = Convert.ToDateTime(dr["DXSJ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.DXSJ_GD = "";
            }

            return model;

        }

        //卫星model
        public LQ_SB_WX LQ_SB_WXModel(DataRow dr)
        {
            LQ_SB_WX model = new LQ_SB_WX();
            if (dr["ID"] != null && dr["ID"].ToString() != "")
            {
                model.ID = dr["ID"].ToString();
            }

            if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            {
                model.TROW = Convert.ToInt32(dr["TROW"]);
            }

            if (dr["DW"] != null && dr["DW"].ToString() != "")
            {
                model.DW = dr["DW"].ToString();
            }

            if (dr["SBMC"] != null && dr["SBMC"].ToString() != "")
            {
                model.SBMC = dr["SBMC"].ToString();
            }

            if (dr["GGXH"] != null && dr["GGXH"].ToString() != "")
            {
                model.GGXH = dr["GGXH"].ToString();
            }

            if (dr["SCCJ"] != null && dr["SCCJ"].ToString() != "")
            {
                model.SCCJ = dr["SCCJ"].ToString();
            }

            if (dr["GB"] != null && dr["GB"].ToString() != "")
            {
                model.GB = dr["GB"].ToString();
            }

            if (dr["CCRQ"] != null && dr["CCRQ"].ToString() != "")
            {
                model.CCRQ = Convert.ToDateTime(dr["CCRQ"]);
                model.CCRQ_GD = Convert.ToDateTime(dr["CCRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.CCRQ_GD = "";
            }

            if (dr["CCBH"] != null && dr["CCBH"].ToString() != "")
            {
                model.CCBH = dr["CCBH"].ToString();
            }

            if (dr["TCRQ"] != null && dr["TCRQ"].ToString() != "")
            {
                model.TCRQ = Convert.ToDateTime(dr["TCRQ"]);
                model.TCRQ_GD = Convert.ToDateTime(dr["TCRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.TCRQ_GD = "";
            }

            if (dr["ZCBH"] != null && dr["ZCBH"].ToString() != "")
            {
                model.ZCBH = dr["ZCBH"].ToString();
            }


            if (dr["ZBH"] != null && dr["ZBH"].ToString() != "")
            {
                model.ZBH = dr["ZBH"].ToString();
            }

            if (dr["SBSZWZ"] != null && dr["SBSZWZ"].ToString() != "")
            {
                model.SBSZWZ = dr["SBSZWZ"].ToString();
            }

            if (dr["SBZK"] != null && dr["SBZK"].ToString() != "")
            {
                model.SBZK = dr["SBZK"].ToString();
            }

            if (dr["BZ"] != null && dr["BZ"].ToString() != "")
            {
                model.BZ = dr["BZ"].ToString();
            }
            return model;

        }

        //综合仪
        public LQ_SB_ZHY LQ_SB_ZHYModel(DataRow dr)
        {
            LQ_SB_ZHY model = new LQ_SB_ZHY();
            if (dr["ID"] != null && dr["ID"].ToString() != "")
            {
                model.ID = dr["ID"].ToString();
            }

            if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            {
                model.TROW = Convert.ToInt32(dr["TROW"]);
            }

            if (dr["DW"] != null && dr["DW"].ToString() != "")
            {
                model.DW = dr["DW"].ToString();
            }

            if (dr["SBMC"] != null && dr["SBMC"].ToString() != "")
            {
                model.SBMC = dr["SBMC"].ToString();
            }

            if (dr["SSXD"] != null && dr["SSXD"].ToString() != "")
            {
                model.SSXD = dr["SSXD"].ToString();
            }

            if (dr["ZZ"] != null && dr["ZZ"].ToString() != "")
            {
                model.ZZ = dr["ZZ"].ToString();
            }

            if (dr["GGXH"] != null && dr["GGXH"].ToString() != "")
            {
                model.GGXH = dr["GGXH"].ToString();
            }

            if (dr["SCCJ"] != null && dr["SCCJ"].ToString() != "")
            {
                model.SCCJ = dr["SCCJ"].ToString();
            }

            if (dr["GB"] != null && dr["GB"].ToString() != "")
            {
                model.GB = dr["GB"].ToString();
            }

            if (dr["CCRQ"] != null && dr["CCRQ"].ToString() != "")
            {
                model.CCRQ = Convert.ToDateTime(dr["CCRQ"]);
                model.CCRQ_GD = Convert.ToDateTime(dr["CCRQ"]).ToString("yyyy-MM-dd");

            }
            else
            {
                model.CCRQ_GD = "";
            }

            if (dr["CCBH"] != null && dr["CCBH"].ToString() != "")
            {
                model.CCBH = dr["CCBH"].ToString();
            }

            if (dr["TCRQ"] != null && dr["TCRQ"].ToString() != "")
            {
                model.TCRQ = Convert.ToDateTime(dr["TCRQ"]);
                model.TCRQ_GD = Convert.ToDateTime(dr["TCRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.TCRQ_GD = "";
            }


            if (dr["SBXBH"] != null && dr["SBXBH"].ToString() != "")
            {
                model.SBXBH = dr["SBXBH"].ToString();
            }

            if (dr["SP"] != null && dr["SP"].ToString() != "")
            {
                model.SP = dr["SP"].ToString();
            }
            if (dr["SPFXZQ"] != null && dr["SPFXZQ"].ToString() != "")
            {
                model.SPFXZQ = Convert.ToDecimal(dr["SPFXZQ"]);
            }

            if (dr["SBZK"] != null && dr["SBZK"].ToString() != "")
            {
                model.SBZK = dr["SBZK"].ToString();
            }

            if (dr["SSDW"] != null && dr["SSDW"].ToString() != "")
            {
                model.SSDW = dr["SSDW"].ToString();
            }

            if (dr["SBSZWZ"] != null && dr["SBSZWZ"].ToString() != "")
            {
                model.SBSZWZ = dr["SBSZWZ"].ToString();
            }

            if (dr["DXSJ"] != null && dr["DXSJ"].ToString() != "")
            {
                model.DXSJ = Convert.ToDateTime(dr["DXSJ"]);
                model.DXSJ_GD = Convert.ToDateTime(dr["DXSJ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.DXSJ_GD = "";
            }

            if (dr["LHQTT"] != null && dr["LHQTT"].ToString() != "")
            {
                model.LHQTT = dr["LHQTT"].ToString();
            }

            if (dr["LHQNJ"] != null && dr["LHQNJ"].ToString() != "")
            {
                model.LHQNJ = dr["LHQNJ"].ToString();
            }

            if (dr["QTBY"] != null && dr["QTBY"].ToString() != "")
            {
                model.QTBY = dr["QTBY"].ToString();
            }

            if (dr["BZ"] != null && dr["BZ"].ToString() != "")
            {
                model.BZ = dr["BZ"].ToString();
            }
            return model;

        }

        //钻时仪model
        public LQ_SB_ZSY LQ_SB_ZSYModel(DataRow dr)
        {
            LQ_SB_ZSY model = new LQ_SB_ZSY();
            if (dr["ID"] != null && dr["ID"].ToString() != "")
            {
                model.ID = dr["ID"].ToString();
            }

            if (dr["TROW"] != null && dr["TROW"].ToString() != "")
            {
                model.TROW = Convert.ToInt32(dr["TROW"]);
            }

            if (dr["DW"] != null && dr["DW"].ToString() != "")
            {
                model.DW = dr["DW"].ToString();
            }

            if (dr["SBMC"] != null && dr["SBMC"].ToString() != "")
            {
                model.SBMC = dr["SBMC"].ToString();
            }

            if (dr["GGXH"] != null && dr["GGXH"].ToString() != "")
            {
                model.GGXH = dr["GGXH"].ToString();
            }

            if (dr["SCCJ"] != null && dr["SCCJ"].ToString() != "")
            {
                model.SCCJ = dr["SCCJ"].ToString();
            }

            if (dr["GB"] != null && dr["GB"].ToString() != "")
            {
                model.GB = dr["GB"].ToString();
            }

            if (dr["CCRQ"] != null && dr["CCRQ"].ToString() != "")
            {
                model.CCRQ = Convert.ToDateTime(dr["CCRQ"]);
                model.CCRQ_GD = Convert.ToDateTime(dr["CCRQ"]).ToString("yyyy-MM-dd");
            }
            else {
                model.CCRQ_GD = "";
            }

            if (dr["CCBH"] != null && dr["CCBH"].ToString() != "")
            {
                model.CCBH = dr["CCBH"].ToString();
            }

            if (dr["TCRQ"] != null && dr["TCRQ"].ToString() != "")
            {
                model.TCRQ = Convert.ToDateTime(dr["TCRQ"]);
                model.TCRQ_GD = Convert.ToDateTime(dr["TCRQ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.TCRQ_GD = "";
            }


            if (dr["SBXBH"] != null && dr["SBXBH"].ToString() != "")
            {
                model.SBXBH = dr["SBXBH"].ToString();
            }

            if (dr["SBZBH"] != null && dr["SBZBH"].ToString() != "")
            {
                model.SBZBH = dr["SBZBH"].ToString();
            }

            if (dr["SBZK"] != null && dr["SBZK"].ToString() != "")
            {
                model.SBZK = dr["SBZK"].ToString();
            }

            if (dr["SBSZWZ"] != null && dr["SBSZWZ"].ToString() != "")
            {
                model.SBSZWZ = dr["SBSZWZ"].ToString();
            }

            if (dr["DXSJ"] != null && dr["DXSJ"].ToString() != "")
            {
                model.DXSJ = Convert.ToDateTime(dr["DXSJ"]);
                model.DXSJ_GD = Convert.ToDateTime(dr["DXSJ"]).ToString("yyyy-MM-dd");
            }
            else
            {
                model.DXSJ_GD = "";
            }

            if (dr["BZ"] != null && dr["BZ"].ToString() != "")
            {
                model.BZ = dr["BZ"].ToString();
            }
            return model;

        }

        //房屋model
        public LQ_FW LQ_FWModel(DataRow dr)
        {
            LQ_FW model = new LQ_FW();
            if (dr["ID"] != null && dr["ID"].ToString() != "")
            {
                model.ID = dr["ID"].ToString();
            }

            if (dr["XH"] != null && dr["XH"].ToString() != "")
            {
                model.XH = Convert.ToInt32(dr["XH"]);
            }

            if (dr["FL"] != null && dr["FL"].ToString() != "")
            {
                model.FL = dr["FL"].ToString();
            }

            if (dr["LJFGS"] != null && dr["LJFGS"].ToString() != "")
            {
                model.LJFGS = dr["LJFGS"].ToString();
            }

            if (dr["CCBH"] != null && dr["CCBH"].ToString() != "")
            {
                model.CCBH = dr["CCBH"].ToString();
            }

            if (dr["GGXH"] != null && dr["GGXH"].ToString() != "")
            {
                model.GGXH = dr["GGXH"].ToString();
            }

            if (dr["SBZK"] != null && dr["SBZK"].ToString() != "")
            {
                model.SBZK = dr["SBZK"].ToString();
            }

            if (dr["SBSZWZ"] != null && dr["SBSZWZ"].ToString() != "")
            {
                model.SBSZWZ = dr["SBSZWZ"].ToString();
            }

            if (dr["BZ"] != null && dr["BZ"].ToString() != "")
            {
                model.BZ = dr["BZ"].ToString();
            }

            if (dr["TJR"] != null && dr["TJR"].ToString() != "")
            {
                model.TJR = dr["TJR"].ToString();
            }

            if (dr["TJRQ"] != null && dr["TJRQ"].ToString() != "")
            {
                model.TJRQ = Convert.ToDateTime(dr["TJRQ"]);
            }

            return model;
        }

        //钻时仪分页查询
        public DataSet SB_ZSY_strWhere(string strWhere, int pageSize, int pageIndex, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY CCRQ DESC) AS TROW,d.* from LQ_SB_ZSY d");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        //车辆分页查询
        public DataSet SB_CL_strWhere(string strWhere, int pageSize, int pageIndex, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY CCRQ DESC) AS TROW,d.* from LQ_SB_CL d");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        //地化分析分页查询
        public DataSet SB_DHFX_strWhere(string strWhere, int pageSize, int pageIndex, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY CCRQ DESC) AS TROW,d.* from LQ_SB_DHFX d");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        //工程参数分页查询
        public DataSet SB_GCCSY_strWhere(string strWhere, int pageSize, int pageIndex, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY CCRQ DESC) AS TROW,d.* from LQ_SB_GCCSY d");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        //卫星分页查询
        public DataSet SB_WX_strWhere(string strWhere, int pageSize, int pageIndex, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY CCRQ DESC) AS TROW,d.* from LQ_SB_WX d");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        //综合仪分页查询
        public DataSet SB_ZHY_strWhere(string strWhere, int pageSize, int pageIndex, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY CCRQ DESC) AS TROW,d.* from LQ_SB_ZHY d");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        //房屋分页查询
        public DataSet FW_strWhere(string strWhere, int pageSize, int pageIndex, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY TJRQ DESC) AS TROW,d.* from LQ_FW d");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 车辆excel
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet Excel_CL(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY CCRQ DESC) AS TROW,DW,SBMC,GGXH,SCCJ,GB,CCRQ,CCBH,TCRQ,ZJNX,RLFL,SBZK,SBSZWZ,DXQK,BZ,ID from LQ_SB_CL");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
          
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 卫星excel
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet Excel_WX(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY CCRQ DESC) AS TROW,DW,SBMC,GGXH,SCCJ,GB,CCRQ,CCBH,TCRQ,ZCBH,ZBH,SBSZWZ,SBZK,BZ,ID from LQ_SB_WX");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 钻时仪excel
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet Excel_ZSY(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY CCRQ DESC) AS TROW,SBMC,GGXH,SCCJ,GB,CCRQ,CCBH,TCRQ,SBXBH,SBZBH,SBZK,DW,SBSZWZ,DXSJ,BZ,ID from LQ_SB_ZSY");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 工程参数仪excel
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet Excel_GCCSY(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY CCRQ DESC) AS TROW,SBMC,GGXH,SCCJ,GB,CCRQ,CCBH,TCRQ,SBXBH,SBZBH,SBZK,DW,SBSZWZ,DXSJ,BZ,ID from LQ_SB_GCCSY");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 地化分析excel
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet Excel_DHFX(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY CCRQ DESC) AS TROW,DW,SBMC,GGXH,SCCJ,GB,CCRQ,CCBH,TCRQ,ZBH,SBSZWZ,SBZK,SSDW,BZ,ID from LQ_SB_DHFX");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 综合仪excel
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet Excel_ZHY(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY CCRQ DESC) AS TROW,DW,SBMC,SSXD,ZZ,GGXH,SCCJ,GB,CCRQ,CCBH,TCRQ,SBXBH,SBZBH,SP,SPFXZQ,SBZK,SSDW,SBSZWZ,DXSJ,LHQTT,LHQNJ,QTBY,BZ,ID from LQ_SB_ZHY");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }

            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 房屋excel
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet Excel_FW(string strWhere,string fl)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROW_NUMBER() OVER(ORDER BY TJRQ DESC) AS TROW,FL,LJFGS,CCBH,GGXH,SBZK,SBSZWZ,BZ,ID from LQ_FW WHERE FL='"+fl+"' ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }

            return DbHelperOra.Query(strSql.ToString());
        }


        /// <summary>
        /// 车辆设备添加
        /// </summary>
        /// <param name="cl"></param>
        /// <returns></returns>
        public bool Add_CL(LQ_SB_CL cl)
        {

            string sqlStr = string.Format(@"
insert into LQ_SB_CL(DW,SBMC,
GGXH,
SCCJ, 
GB, 
CCRQ, 
CCBH, 
TCRQ, 
ZJNX, 
RLFL, 
SBZK, 
SBSZWZ, 
DXQK, 
BZ
)
values
 ('{0}','{1}','{2}',
'{3}',
'{4}', 
TO_DATE(substr('{5}',1,10),'yyyy-MM-dd'), 
'{6}',
TO_DATE(substr('{7}',1,10),'yyyy-MM-dd'), 
{8},
'{9}',
'{10}',
'{11}',
'{12}',
'{13}'
)",cl.DW,cl.SBMC,cl.GGXH,cl.SCCJ,cl.GB,cl.CCRQ_GD,cl.CCBH,cl.TCRQ_GD,cl.ZJNX,cl.RLFL,cl.SBZK,cl.SBSZWZ,cl.DXQK,cl.BZ);

            int rows = DbHelperOra.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///车辆设备修改
        /// </summary>
        /// <param name="RYSJK"></param>
        /// <returns></returns>
        public bool Update_CL(LQ_SB_CL cl)
        {
            string sqlStr = string.Format(@"
Update LQ_SB_CL Set 
DW='{0}',SBMC='{1}',
GGXH='{2}',
SCCJ='{3}', 
GB='{4}', 
CCRQ=TO_DATE(substr('{5}',1,10),'yyyy-MM-dd'),
CCBH='{6}', 
TCRQ=TO_DATE(substr('{7}',1,10),'yyyy-MM-dd'), 
ZJNX={8}, 
RLFL='{9}', 
SBZK='{10}', 
SBSZWZ='{11}', 
DXQK='{12}', 
BZ='{13}'
WHERE ID='{14}' ",cl.DW,cl.SBMC,cl.GGXH,cl.SCCJ,cl.GB,cl.CCRQ_GD,cl.CCBH,cl.TCRQ_GD,cl.ZJNX,cl.RLFL,cl.SBZK,cl.SBSZWZ,cl.DXQK,cl.BZ,cl.ID);

            int rows = DbHelperOra.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 卫星设备添加
        /// </summary>
        /// <param name="cl"></param>
        /// <returns></returns>
        public bool Add_WX(LQ_SB_WX wx)
        {

            string sqlStr =string.Format( @"
insert into LQ_SB_WX(DW,SBMC,
GGXH,
SCCJ, 
GB, 
CCRQ, 
CCBH, 
TCRQ, 
ZCBH,
ZBH, 
SBSZWZ, 
SBZK, 
BZ
)
values
 ('{0}','{1}','{2}',
'{3}',
'{4}', 
TO_DATE(substr('{5}',1,10),'yyyy-MM-dd'),
'{6}',
TO_DATE(substr('{7}',1,10),'yyyy-MM-dd'),
'{8}',
'{9}',
'{10}',
'{11}',
'{12}'
)",wx.DW,wx.SBMC,wx.GGXH,wx.SCCJ,wx.GB,wx.CCRQ_GD,wx.CCBH,wx.TCRQ_GD,wx.ZCBH,wx.ZBH,wx.SBSZWZ,wx.SBZK,wx.BZ);

            int rows = DbHelperOra.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///卫星设备修改
        /// </summary>
        /// <param name="RYSJK"></param>
        /// <returns></returns>
        public bool Update_WX(LQ_SB_WX wx)
        {
            string sqlStr = string.Format(@"
Update LQ_SB_WX Set 
DW='{0}',SBMC='{1}',
GGXH='{2}',
SCCJ='{3}', 
GB='{4}', 
CCRQ=TO_DATE(substr('{5}',1,10),'yyyy-MM-dd'), 
CCBH='{6}', 
TCRQ=TO_DATE(substr('{7}',1,10),'yyyy-MM-dd'),
ZCBH='{8}',
ZBH='{9}', 
SBSZWZ='{10}', 
SBZK='{11}', 
BZ='{12}',
WHERE ID='{13}' ", wx.DW, wx.SBMC, wx.GGXH, wx.SCCJ, wx.GB, wx.CCRQ_GD, wx.CCBH, wx.TCRQ_GD,wx.ZCBH, wx.ZBH, wx.SBSZWZ, wx.SBZK, wx.BZ,wx.ID);

            int rows = DbHelperOra.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 钻时仪设备添加
        /// </summary>
        /// <param name="cl"></param>
        /// <returns></returns>
        public bool Add_ZSY(LQ_SB_ZSY zsy)
        {

            string sqlStr = string.Format(@"
insert into LQ_SB_ZSY(SBMC,
GGXH,
SCCJ, 
GB, 
CCRQ, 
CCBH, 
TCRQ, 
SBXBH, 
SBZBH, 
SBZK, 
DW,
SBSZWZ,
DXSJ,
BZ
)
values
 ('{0}','{1}',
'{2}',
'{3}',  
TO_DATE(substr('{4}',1,10),'yyyy-MM-dd'), 
'{5}', 
TO_DATE(substr('{6}',1,10),'yyyy-MM-dd'), 
'{7}',
'{8}',
'{9}',
'{10}',
'{11}',
TO_DATE(substr('{12}',1,10),'yyyy-MM-dd'), 
'{13}'
)",zsy.SBMC,zsy.GGXH,zsy.SCCJ,zsy.GB,zsy.CCRQ_GD,zsy.CCBH,zsy.TCRQ_GD,zsy.SBXBH,zsy.SBZBH,zsy.SBZK,zsy.DW,zsy.SBSZWZ,zsy.DXSJ_GD,zsy.BZ);
           
            int rows = DbHelperOra.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///钻时仪设备修改
        /// </summary>
        /// <param name="RYSJK"></param>
        /// <returns></returns>
        public bool Update_ZSY(LQ_SB_ZSY zsy)
        {
            string sqlStr = string.Format(@"
Update LQ_SB_ZSY Set 
SBMC='{0}',
GGXH='{1}',
SCCJ='{2}', 
GB='{3}', 
CCRQ=TO_DATE(substr('{4}',1,10),'yyyy-MM-dd'), 
CCBH='{5}', 
TCRQ=TO_DATE(substr('{6}',1,10),'yyyy-MM-dd'),  
SBXBH='{7}', 
SBZBH='{8}', 
SBZK='{9}', 
DW='{10}',
SBSZWZ='{11}',
DXSJ=TO_DATE(substr('{12}',1,10),'yyyy-MM-dd'),
BZ='{13}' WHERE ID='{14}'",zsy.SBMC,zsy.GGXH,zsy.SCCJ,zsy.GB,zsy.CCRQ_GD,zsy.CCBH,zsy.TCRQ_GD,zsy.SBXBH,zsy.SBZBH,zsy.SBZK,zsy.DW,zsy.SBSZWZ,zsy.DXSJ_GD,zsy.BZ,zsy.ID);
          
            int rows = DbHelperOra.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 工程参数仪添加
        /// </summary>
        /// <param name="gccsy"></param>
        /// <returns></returns>
        public bool Add_GCCSY(LQ_SB_GCCSY gccsy)
        {

            string sqlStr = string.Format(@"
insert into LQ_SB_GCCSY(SBMC,
GGXH,
SCCJ, 
GB, 
CCRQ, 
CCBH, 
TCRQ, 
SBXBH, 
SBZBH, 
SBZK, 
DW,
SBSZWZ,
DXSJ,
BZ
)
values
 ('{0}','{1}',
'{2}',
'{3}', 

TO_DATE(substr('{4}',1,10),'yyyy-MM-dd'), 
'{5}', 
TO_DATE(substr('{6}',1,10),'yyyy-MM-dd'), 
'{7}',
'{8}',
'{9}',
'{10}',
'{11}',
TO_DATE(substr('{12}',1,10),'yyyy-MM-dd'), 
'{13}'
)",gccsy.SBMC, gccsy.GGXH, gccsy.SCCJ, gccsy.GB, gccsy.CCRQ_GD, gccsy.CCBH, gccsy.TCRQ_GD, gccsy.SBXBH, gccsy.SBZBH, gccsy.SBZK, gccsy.DW, gccsy.SBSZWZ, gccsy.DXSJ_GD, gccsy.BZ);

            int rows = DbHelperOra.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 工程参数仪修改
        /// </summary>
        /// <param name="gccsy"></param>
        /// <returns></returns>
        public bool Update_GCCSY(LQ_SB_GCCSY gccsy)
        {
            string sqlStr = string.Format(@"
Update LQ_SB_GCCSY Set 
SBMC='{0}',
GGXH='{1}',
SCCJ='{2}', 
GB='{3}', 
CCRQ=TO_DATE(substr('{4}',1,10),'yyyy-MM-dd'),
CCBH='{5}', 
TCRQ=TO_DATE(substr('{6}',1,10),'yyyy-MM-dd'), 
SBXBH='{7}', 
SBZBH='{8}', 
SBZK='{9}', 
DW='{10}',
SBSZWZ='{11}',
DXSJ=TO_DATE(substr('{12}',1,10),'yyyy-MM-dd'), 
BZ='{13}' WHERE ID='{14}'",gccsy.SBMC,gccsy.GGXH,gccsy.SCCJ,gccsy.GB,gccsy.CCRQ_GD,gccsy.CCBH,gccsy.TCRQ_GD,gccsy.SBXBH,gccsy.SBZBH,gccsy.SBZK,gccsy.DW,gccsy.SBSZWZ,gccsy.DXSJ_GD,gccsy.BZ,gccsy.ID);
           
            int rows = DbHelperOra.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 地化分析仪添加
        /// </summary>
        /// <param name="dhfx"></param>
        /// <returns></returns>
        public bool Add_DHFX(LQ_SB_DHFX dhfx)
        {

            string sqlStr = string.Format(@"
insert into LQ_SB_DHFX(DW,SBMC,
GGXH,
SCCJ, 
GB, 
CCRQ, 
CCBH, 
TCRQ, 
ZBH,
SBSZWZ,
SBZK, 
SSDW,
BZ
)
values
 ('{0}','{1}','{2}',
'{3}',
'{4}', 
TO_DATE(substr('{5}',1,10),'yyyy-MM-dd'), 
'{6}', 
TO_DATE(substr('{7}',1,10),'yyyy-MM-dd'), 
'{8}',
'{9}',
'{10}',
'{11}',
'{12}'

)",dhfx.DW,dhfx.SBMC,dhfx.GGXH,dhfx.SCCJ,dhfx.GB,dhfx.CCRQ_GD,dhfx.CCBH,dhfx.TCRQ_GD,dhfx.ZBH,dhfx.SBSZWZ,dhfx.SBZK,dhfx.SSDW,dhfx.BZ);
            int rows = DbHelperOra.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 地化分析仪修改
        /// </summary>
        /// <param name="dhfx"></param>
        /// <returns></returns>
        public bool Update_DHFX(LQ_SB_DHFX dhfx)
        {
            string sqlStr = string.Format(@"
Update LQ_SB_DHFX Set 
DW='{0}',SBMC='{1}',
GGXH='{2}',
SCCJ='{3}', 
GB='{4}', 
CCRQ=TO_DATE(substr('{5}',1,10),'yyyy-MM-dd'), 
CCBH='{6}', 
TCRQ=TO_DATE(substr('{7}',1,10),'yyyy-MM-dd'), 
ZBH='{8}',
SBSZWZ='{9}',
SBZK='{10}', 
SSDW='{11}',
BZ='{12}' WHERE ID='{13}'",dhfx.DW,dhfx.SBMC,dhfx.GGXH,dhfx.SCCJ,dhfx.GB,dhfx.CCRQ_GD,dhfx.CCBH,dhfx.TCRQ_GD,dhfx.ZBH,dhfx.SBSZWZ,dhfx.SBZK,dhfx.SSDW,dhfx.BZ,dhfx.ID);
          
            int rows = DbHelperOra.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 综合仪添加
        /// </summary>
        /// <param name="zhy"></param>
        /// <returns></returns>
        public bool Add_ZHY(LQ_SB_ZHY zhy)
        {

            string sqlStr =string.Format(@"
insert into LQ_SB_ZHY(
DW,
SBMC,
SSXD,
ZZ, 
GGXH, 
SCCJ, 
GB, 
CCRQ, 
CCBH,
TCRQ,
SBXBH, 
SBZBH,
SP,
SPFXZQ,
SBZK,
SSDW,
SBSZWZ,
DXSJ,
LHQTT,
LHQNJ,
QTBY,
BZ
)
values
 (
'{0}',
'{1}',
'{2}',
'{3}',
'{4}', 
'{5}', 
'{6}', 
TO_DATE(substr('{7}',1,10),'yyyy-MM-dd'), 
'{8}',
TO_DATE(substr('{9}',1,10),'yyyy-MM-dd'),
'{10}', 
'{11}',
'{12}',
{13},
'{14}',
'{15}',
'{16}',
TO_DATE(substr('{17}',1,10),'yyyy-MM-dd'),
'{18}',
'{19}',
'{20}',
'{21}'
)", zhy.DW, zhy.SBMC, zhy.SSXD, zhy.ZZ, zhy.GGXH, zhy.SCCJ, zhy.GB, zhy.CCRQ_GD, zhy.CCBH, zhy.TCRQ_GD, zhy.SBXBH, zhy.SBZBH, zhy.SP, zhy.SPFXZQ, zhy.SBZK, zhy.SSDW, zhy.SBSZWZ, zhy.DXSJ_GD, zhy.LHQTT, zhy.LHQNJ, zhy.QTBY, zhy.BZ);
           
            int rows = DbHelperOra.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
       
        }

        /// <summary>
        /// 综合仪修改
        /// </summary>
        /// <param name="zhy"></param>
        /// <returns></returns>
        public bool Update_ZHY(LQ_SB_ZHY zhy)
        {
            string sqlStr = string.Format(@"
Update LQ_SB_ZHY Set 
DW='{0}',SBMC='{1}',
SSXD='{2}',
ZZ='{3}', 
GGXH='{4}', 
SCCJ='{5}', 
GB='{6}', 
CCRQ=TO_DATE(substr('{7}',1,10),'yyyy-MM-dd'), 
CCBH='{8}',
TCRQ=TO_DATE(substr('{9}',1,10),'yyyy-MM-dd'),
SBXBH='{10}', 
SBZBH='{11}',
SP='{12}',
SPFXZQ={13},
SBZK='{14}',
SSDW='{15}',
SBSZWZ='{16}',
DXSJ=TO_DATE(substr('{17}',1,10),'yyyy-MM-dd'),
LHQTT='{18}',
LHQNJ='{19}',
QTBY='{20}',
BZ='{21}' WHERE ID='{22}'", zhy.DW,zhy.SBMC,zhy.SSXD,zhy.ZZ,zhy.GGXH,zhy.SCCJ,zhy.GB,zhy.CCRQ_GD,zhy.CCBH,zhy.TCRQ_GD,zhy.SBXBH,zhy.SBZBH,zhy.SP,zhy.SPFXZQ,zhy.SBZK,zhy.SSDW,zhy.SBSZWZ,zhy.DXSJ_GD,zhy.LHQTT,zhy.LHQNJ,zhy.QTBY,zhy.BZ,zhy.ID);

            int rows = DbHelperOra.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 房屋添加
        /// </summary>
        /// <param name="fw"></param>
        /// <returns></returns>
        public bool Add_FW(LQ_FW fw)
        {

            string sqlStr = @"
insert into LQ_FW(FL,LJFGS,
CCBH,
GGXH, 
SBZK, 
SBSZWZ, 
BZ, 
TJR, 
TJRQ
)
values
 (:FL,:LJFGS,
:CCBH,
:GGXH, 
:SBZK, 
:SBSZWZ, 
:BZ, 
:TJR, 
:TJRQ
)";
            OracleParameter[] parameter = {

                                            new OracleParameter(":FL",OracleDbType.Varchar2,20),
                                            new OracleParameter(":LJFGS",OracleDbType.Varchar2,50),
                                            new OracleParameter(":CCBH",OracleDbType.Varchar2,50),
                                            new OracleParameter(":GGXH",OracleDbType.Varchar2,20),
                                            new OracleParameter(":SBZK",OracleDbType.Varchar2,50),
                                            new OracleParameter(":SBSZWZ",OracleDbType.Varchar2,50),
                                            new OracleParameter(":BZ",OracleDbType.Varchar2,50),
                                            new OracleParameter(":TJR",OracleDbType.Varchar2,50),
                                            new OracleParameter(":TJRQ",OracleDbType.Date)                         
                                        };

            parameter[0].Value = fw.FL;
            parameter[1].Value = fw.LJFGS;
            parameter[2].Value = fw.CCBH;
            parameter[3].Value = fw.GGXH;
            parameter[4].Value = fw.SBZK;
            parameter[5].Value = fw.SBSZWZ;
            parameter[6].Value = fw.BZ;
            parameter[7].Value = fw.TJR;
            parameter[8].Value = fw.TJRQ;
           
            int rows = DbHelperOra.ExecuteSql(sqlStr, parameter);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 房屋修改
        /// </summary>
        /// <param name="fw"></param>
        /// <returns></returns>
        public bool Update_FW(LQ_FW fw,string fl)
        {
            string sqlStr = string.Format(@"
Update LQ_FW Set 
LJFGS='{0}',
CCBH='{1}',
GGXH='{2}', 
SBZK='{3}', 
SBSZWZ='{4}', 
BZ='{5}'
WHERE ID='{6}' ", fw.LJFGS,fw.CCBH,fw.GGXH,fw.SBZK,fw.SBSZWZ,fw.BZ,fw.ID,fl);

            int rows = DbHelperOra.ExecuteSql(sqlStr);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public int CheckCL(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) from LQ_SB_CL WHERE  ID='" + ID + "'");

            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result == null)
            {
                return 0;
            }
            return Convert.ToInt32(result);

        }

        public int CheckWX(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) from LQ_SB_WX WHERE  ID='" + ID + "'");

            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result == null)
            {
                return 0;
            }
            return Convert.ToInt32(result);

        }

        public int CheckZSY(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) from LQ_SB_ZSY WHERE  ID='" + ID + "'");

            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result == null)
            {
                return 0;
            }
            return Convert.ToInt32(result);

        }

        public int CheckGCCSY(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) from LQ_SB_GCCSY WHERE  ID='" + ID + "'");

            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result == null)
            {
                return 0;
            }
            return Convert.ToInt32(result);

        }

        public int CheckDHFX(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) from LQ_SB_DHFX WHERE  ID='" + ID + "'");

            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result == null)
            {
                return 0;
            }
            return Convert.ToInt32(result);

        }

        public int CheckZHY(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) from LQ_SB_ZHY WHERE  ID='" + ID + "'");

            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result == null)
            {
                return 0;
            }
            return Convert.ToInt32(result);

        }

        public int CheckFW(string ID,string FL)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) from LQ_FW WHERE FL='"+FL+"' AND  ID='" + ID + "'");

            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result == null)
            {
                return 0;
            }
            return Convert.ToInt32(result);
        }
    }
}
