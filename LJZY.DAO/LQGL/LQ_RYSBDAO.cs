using LJZY.DBUtility;
using LJZY.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.DAO.LQGL
{
    public class LQ_RYSBDAO
    {
        /// <summary>
        /// 录井项目列表
        /// </summary>
        /// <returns></returns>
        public DataSet LJXMInfo_List( string Time, string strWhere, string dtName1, string dtName61 )
        {
            //StringBuilder strSql = new StringBuilder ( );
            string strSql = string.Format (@" 
SELECT ROW_NUMBER ()
       OVER (
           ORDER BY
               L.DWZBH,
               CASE L.XQXMB
                   WHEN '第一项目部' THEN 0
                   WHEN '第二项目部' THEN 1
                   WHEN '第三项目部' THEN 2
                   WHEN '准东项目部' THEN 3
                   WHEN '塔里木项目部' THEN 4
                   WHEN '海外项目部' THEN 5
                   ELSE 100
               END ASC,
               L.XQXMB ASC, 
               L.REPORT_TYPE ASC,
               CASE L.DQZT
                   WHEN '正录' THEN 0
                   WHEN '待录' THEN 1
                   WHEN '待派' THEN 2
                   ELSE 100
               END ASC,
               L.DQZT ASC,
               L.KZRQ DESC )
           AS TROW,
       L.DWZBH,
       L.LJDH,
       L.LJYQXH,
       L.JH,
       L.SGDH,
       L.DQZT,
       L.HXJW,
       D.SGZT,
       D.DRJS,
       D.HBRQ,
       '' SBSZD
  FROM " + dtName1 + @" L                        
  INNER JOIN " + dtName61 + @" D ON L.JH=D.JH
  WHERE HBRQ=TO_DATE('{0}','YYYY/MM/DD') OR L.DQZT='待录' ", Time );

            if (strWhere.Trim ( ) != "")
            {
                strSql += strWhere;
            }

            return DbHelperOra.Query ( strSql );
        }


        /// <summary>
        /// 录井分配人员信息列表
        /// </summary>
        /// <returns></returns>
        public DataSet RYFPInfo_List()
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql.Append ( " SELECT P.RYBH,K.XM,P.JH,K.GW,K.LXDH FROM LQ_RYFP P " );
            strSql.Append ( " LEFT JOIN LQ_RYSJK K ON P.RYBH=K.RYBH " );
            return DbHelperOra.Query ( strSql.ToString ( ) );
        }

        /// <summary>
        /// 人员信息列表
        /// </summary>
        /// <returns></returns>
        public List<LQ_RYSJK> RYInfo_List()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT RYBH,XM,GW,RYZT FROM LQ_RYSJK ");
            DataTable dt = DbHelperOra.Query(strSql.ToString()).Tables[0];
            return DTtoRYList(dt);
        }

        public List<LQ_RYSJK> DTtoRYList(DataTable dt)
        {
            List<LQ_RYSJK> List = new List<LQ_RYSJK>();
            foreach (DataRow dr in dt.Rows)
            {
                LQ_RYSJK item = DataRowToRYModel(dr);
                List.Add(item);
            }
            return List;
        }
        public static LQ_RYSJK DataRowToRYModel(DataRow row)
        {
            LQ_RYSJK model = new LQ_RYSJK();
            if (row != null)
            {
                if (row["RYBH"] != null && row["RYBH"].ToString() != "")
                {
                    model.RYBH = row["RYBH"].ToString();
                }
                if (row["XM"] != null && row["XM"].ToString() != "")
                {
                    model.XM = row["XM"].ToString();
                }
                if (row["GW"] != null && row["GW"].ToString() != "")
                {
                    model.GW = row["GW"].ToString();
                }
                if (row["RYZT"] != null && row["RYZT"].ToString() != "")
                {
                    model.RYZT = row["RYZT"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 录井日志记录列表
        /// </summary>
        /// <returns></returns>
        public DataSet SJRZInfo_List()
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql.Append ( " SELECT Z.RYBH,K.XM,Z.JH,K.GW,Z.KSSJRQ,Z.JSSJRQ FROM LQ_SJRZ Z " );
            strSql.Append ( " LEFT JOIN LQ_RYSJK K ON Z.RYBH = K.RYBH " );
            return DbHelperOra.Query ( strSql.ToString ( ) );
        }

        /// <summary>
        /// 房屋分配信息列表
        /// </summary>
        /// <returns></returns>
        public DataSet FWInfo_List()
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql.Append (" SELECT P.JH,P.FWID,W.GGXH,W.CCBH,W.FL FROM LQ_FWFP P ");
            strSql.Append ( " LEFT JOIN LQ_FW W ON P.FWID=W.ID " );
            return DbHelperOra.Query ( strSql.ToString ( ) );
        }

        /// <summary>
        /// 人员设备主要信息部分
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public LQ_RYSB RYSBModel( DataRow dr )
        {
            LQ_RYSB model = new LQ_RYSB ( );
            if (dr["TROW"] != null && dr["TROW"].ToString ( ) != "")
            {
                model.TROW = Convert.ToInt32 ( dr["TROW"] );
            }
            if (dr["DWZBH"] != null && dr["DWZBH"].ToString ( ) != "")
            {
                model.DWZBH = dr["DWZBH"].ToString ( );
            }
            if (dr["LJDH"] != null && dr["LJDH"].ToString ( ) != "")
            {
                model.LJDH = dr["LJDH"].ToString ( );
            }
            if (dr["LJYQXH"] != null && dr["LJYQXH"].ToString ( ) != "")
            {
                model.LJYQXH = dr["LJYQXH"].ToString ( );
            }
            if (dr["JH"] != null && dr["JH"].ToString ( ) != "")
            {
                model.JH = dr["JH"].ToString ( );
            }

            if (dr["SGDH"] != null && dr["SGDH"].ToString ( ) != "")
            {
                model.SGDH = dr["SGDH"].ToString ( );
            }

            if (dr["DQZT"] != null && dr["DQZT"].ToString ( ) != "")
            {
                model.DQZT = dr["DQZT"].ToString ( );
            }

            if (dr["HXJW"] != null && dr["HXJW"].ToString ( ) != "")
            {
                model.HXJW = dr["HXJW"].ToString ( );
            }
            if (dr["SBSZD"] != null && dr["SBSZD"].ToString() != "")
            {
                model.SBSZD = dr["SBSZD"].ToString();
            }

            return model;
        }

        /// <summary>
        /// 人员分配部分信息
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public LQ_RYDT RYDTModel( DataRow dr )
        {
            LQ_RYDT model = new LQ_RYDT ( );
            if (dr["RYBH"] != null && dr["RYBH"].ToString ( ) != "")
            {
                model.RYBH = dr["RYBH"].ToString ( );
            }
            if (dr["JH"] != null && dr["JH"].ToString ( ) != "")
            {
                model.JH = dr["JH"].ToString ( );
            }
            if (dr["LXDH"] != null && dr["LXDH"].ToString ( ) != "")
            {
                model.LXDH = dr["LXDH"].ToString ( );
            }
            if (dr["GW"] != null && dr["GW"].ToString ( ) != "")
            {
                model.GW = dr["GW"].ToString ( );
            }
            if (dr["XM"] != null && dr["XM"].ToString ( ) != "")
            {
                model.XM = dr["XM"].ToString ( );
            }


            return model;
        }

        /// <summary>
        /// 录井日志部分信息
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public LQ_SJRZ SJRZModel( DataRow dr )
        {
            LQ_SJRZ model = new LQ_SJRZ ( );
            if (dr["RYBH"] != null && dr["RYBH"].ToString ( ) != "")
            {
                model.RYBH = dr["RYBH"].ToString ( );
            }
            if (dr["JH"] != null && dr["JH"].ToString ( ) != "")
            {
                model.JH = dr["JH"].ToString ( );
            }
            if (dr["XM"] != null && dr["XM"].ToString ( ) != "")
            {
                model.XM = dr["XM"].ToString ( );
            }
            if (dr["GW"] != null && dr["GW"].ToString ( ) != "")
            {
                model.GW = dr["GW"].ToString ( );
            }
            if (dr["KSSJRQ"] != null && dr["KSSJRQ"].ToString ( ) != "")
            {
                model.KSSJRQ = Convert.ToDateTime ( dr["KSSJRQ"] );
                model.KSSJRQ_GD = Convert.ToDateTime ( dr["KSSJRQ"] ).ToString ( "yyyy-MM-dd" );
            }
            else
            {
                model.KSSJRQ_GD = "";
            }
            if (dr["JSSJRQ"] != null && dr["JSSJRQ"].ToString ( ) != "")
            {
                model.JSSJRQ = Convert.ToDateTime ( dr["JSSJRQ"] );
                model.JSSJRQ_GD = Convert.ToDateTime ( dr["JSSJRQ"] ).ToString ( "yyyy-MM-dd" );
            }
            else
            {
                model.JSSJRQ_GD = "";
            }
            return model;
        }

        /// <summary>
        /// 房屋分配部分信息
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public LQ_FWFP FWModel( DataRow dr )
        {
            LQ_FWFP model = new LQ_FWFP ( );

            if (dr["JH"] != null && dr["JH"].ToString ( ) != "")
            {
                model.JH = dr["JH"].ToString ( );
            }
            if (dr["FWID"] != null && dr["FWID"].ToString ( ) != "")
            {
                model.FWID = dr["FWID"].ToString ( );
            }
            if (dr["GGXH"] != null && dr["GGXH"].ToString ( ) != "")
            {
                model.GGXH = dr["GGXH"].ToString ( );
            }
            if (dr["CCBH"] != null && dr["CCBH"].ToString() != "")
            {
                model.CCBH = dr["CCBH"].ToString();
            }
            if (dr["FL"] != null && dr["FL"].ToString ( ) != "")
            {
                model.FL = dr["FL"].ToString ( );
            }
            return model;
        }
    }
}
