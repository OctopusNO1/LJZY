using LJZY.DBUtility;
using LJZY.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.DAO.Map
{
    public class MapDAO
    {
        #region 地图列表
        /// <summary>
        /// 地图列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet MapList(string Time, string strWhere, string dtName1, string dtName61)
        {
            string strSql = string.Format(@"
SELECT T1.JH,
       T1.LJDH,
       T1.SJJS,
       T61.DRJS,
       T1.SJHZBB,
       T1.SJZZBB,
       (CASE
            WHEN NVL (DRJS, 0) > 0 THEN '正钻井'
            WHEN NVL (DRJS, 0) = 0 THEN '待派井'
        END)
           JFL,
       T1.SGDH,
       T1.SGDDH,
       CASE WHEN T1.STARSTART IS NOT NULL AND (T1.STAREND IS NULL OR T1.STAREND !='') THEN '是' ELSE '否' END STARTS
  FROM " + dtName1 + @" T1 LEFT JOIN " + dtName61 + @" T61 ON T1.JH = T61.JH
 WHERE HBRQ = TO_DATE('{0}', 'YYYY/MM/DD')", Time);
            if (strWhere.Trim() != "")
            {
                strSql += strWhere;
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        public DataSet MapListByJH(string strWhere, string dtName1, string dtName61)
        {
            string strSql = string.Format(@"
SELECT T1.JH,
       T1.LJDH,
       T1.SJJS,
       T61.DRJS,
       T1.SJHZBB,
       T1.SJZZBB,
       (CASE
            WHEN NVL (DRJS, 0) > 0 THEN '正钻井'
            WHEN NVL (DRJS, 0) = 0 THEN '待派井'
        END)
           JFL,
       T1.SGDH,
       T1.SGDDH,
       CASE WHEN T1.STARSTART IS NOT NULL AND (T1.STAREND IS NULL OR T1.STAREND !='') THEN '是' ELSE '否' END STARTS
  FROM " + dtName1 + @" T1 LEFT JOIN " + dtName61 + @" T61 ON T1.JH = T61.JH ");
            if (strWhere.Trim() != "")
            {
                strSql += " WHERE 1=1" + strWhere;
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据条件统计当日总井数
        /// </summary>
        /// <param name="Time"></param>
        /// <returns></returns>
        public int CountNum(string strWhere, string dtName1, string dtName61)
        {
            string strSql = string.Format(@"SELECT COUNT (*)  FROM " + dtName1 + @" a LEFT JOIN " + dtName61 + @" b ON a.JH = b.JH ");
            if (strWhere.Trim() != "")
            {
                strSql += " Where 1=1 " + strWhere;
            }

            object result = DbHelperOra.GetSingle(strSql.ToString());
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            return 0;
        }


        public DataSet RYList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROW_NUMBER() OVER(ORDER BY K.TJSJ DESC) AS TROW,P.JH,K.XM,K.LXDH FROM LQ_RYFP P ");
            strSql.Append(" INNER JOIN LQ_RYSJK K  ON K.RYBH=P.RYBH AND K.GW='录井地质师' ");

            return DbHelperOra.Query(strSql.ToString());
        }
        #endregion

        public LQ_RYFP RYModel(DataRow dr)
        {
            LQ_RYFP model = new LQ_RYFP();
            if (dr["JH"] != null && dr["JH"].ToString() != "")
            {
                model.JH = dr["JH"].ToString();
            }

            if (dr["XM"] != null && dr["XM"].ToString() != "")
            {
                model.XM = dr["XM"].ToString();
            }

            if (dr["LXDH"] != null && dr["LXDH"].ToString() != "")
            {
                model.LXDH = dr["LXDH"].ToString();
            }
            return model;
        }


        /// <summary>
        /// 地图实体类
        /// </summary>
        /// <returns></returns>
        public BDMap MapModel(DataRow dr)
        {
            BDMap model = new BDMap();
            if (dr["JH"] != null && dr["JH"].ToString() != "")
            {
                model.JH = dr["JH"].ToString();
            }

            if (dr["LJDH"] != null && dr["LJDH"].ToString() != "")
            {
                model.LJDH = dr["LJDH"].ToString();
            }

            if (dr["SJJS"] != null && dr["SJJS"].ToString() != "")
            {
                model.SJJS = dr["SJJS"].ToString();
            }

            if (dr["DRJS"] != null && dr["DRJS"].ToString() != "")
            {
                model.DRJS = dr["DRJS"].ToString();
            }

            if (dr["JFL"] != null && dr["JFL"].ToString() != "")
            {
                model.JFL = dr["JFL"].ToString();
            }

            if (dr["SGDH"] != null && dr["SGDH"].ToString() != "")
            {
                model.SGDH = dr["SGDH"].ToString();
            }

            if (dr["STARTS"] != null && dr["STARTS"].ToString() != "")
            {
                model.STARTS = dr["STARTS"].ToString();
            }

            if ((dr["SJHZBB"] != null && dr["SJHZBB"].ToString() != "") || (dr["SJZZBB"] != null && dr["SJZZBB"].ToString() != ""))
            {
                double longitude = 0;
                double latitude = 0;
                GetCoord(0, Convert.ToDouble(dr["SJHZBB"]), Convert.ToDouble(dr["SJZZBB"]), out longitude, out latitude);
                model.Point = (longitude.ToString() + "," + latitude.ToString());
            }
            return model;

        }


        /// <summary>
        /// 坐标转换方法
        /// </summary>
        /// <param name="dh"></param>
        /// <param name="N"></param>
        /// <param name="E"></param>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        public static void GetCoord(int dh, double N, double E, out double longitude, out double latitude)
        {
            int ProjNo;
            int ZoneWide;
            double longitude1;
            double latitude1;
            double longitude0;
            double latitude0;
            double X0;
            double Y0;
            double xval;
            double yval;
            double e1;
            double e2;
            double f;
            double a;
            double ee;
            double NN;
            double T;
            double C;
            double M;
            double D;
            double R;
            double u;
            double fai;
            double iPI;

            //int du;
            //double fen;
            //int miao;

            iPI = 0.0174532925199433;////3.1415926535898/180.0; 
            a = 6378245.0;
            f = 1.0 / 298.3;//54年北京坐标系参数 
                            ////a=6378140.0; f=1/298.257; //80年西安坐标系参数 
            ZoneWide = 6;////6度带宽 
            if (dh <= 0)
            {
                ProjNo = (int)Math.Floor(E / 1000000.0);//查找带号
            }
            else
            {
                ProjNo = dh;// (int)Math.Floor(E / 1000000.0);//查找带号
            }
            if (dh == 0)
            {
                ProjNo = (int)Math.Floor(E / 1000000.0);
            }
            longitude0 = (ProjNo - 1) * ZoneWide + ZoneWide / 2;
            longitude0 = longitude0 * iPI;//中央经线
            X0 = ProjNo * 1000000 + 500000;
            Y0 = 0;
            xval = E - X0;
            yval = N - Y0; //带内大地坐标
            e2 = 2 * f - f * f;
            e1 = (1.0 - Math.Sqrt(1 - e2)) / (1.0 + Math.Sqrt(1 - e2));
            ee = e2 / (1 - e2);
            M = yval;
            u = M / (a * (1 - e2 / 4 - 3 * e2 * e2 / 64 - 5 * e2 * e2 * e2 / 256));
            fai = u + (3 * e1 / 2 - 27 * e1 * e1 * e1 / 32) * Math.Sin(2 * u) + (21 * e1 * e1 / 16 - 55 * e1 * e1 * e1 * e1 / 32) * Math.Sin(4 * u) + (151 * e1 * e1 * e1 / 96) * Math.Sin(6 * u) + (1097 * e1 * e1 * e1 * e1 / 512) * Math.Sin(8 * u);
            C = ee * Math.Cos(fai) * Math.Cos(fai);
            T = Math.Tan(fai) * Math.Tan(fai);
            NN = a / Math.Sqrt(1.0 - e2 * Math.Sin(fai) * Math.Sin(fai));
            R = a * (1 - e2) / Math.Sqrt((1 - e2 * Math.Sin(fai) * Math.Sin(fai)) * (1 - e2 * Math.Sin(fai) * Math.Sin(fai)) * (1 - e2 * Math.Sin(fai) * Math.Sin(fai)));
            D = xval / NN;
            //计算经度(Longitude) 纬度(Latitude)
            longitude1 = longitude0 + (D - (1 + 2 * T + C) * D * D * D / 6 + (5 - 2 * C + 28 * T - 3 * C * C + 8 * ee + 24 * T * T) * D * D * D * D * D / 120) / Math.Cos(fai);
            latitude1 = fai - (NN * Math.Tan(fai) / R) * (D * D / 2 - (5 + 3 * T + 10 * C - 4 * C * C - 9 * ee) * D * D * D * D / 24 + (61 + 90 * T + 298 * C + 45 * T * T - 256 * ee - 3 * C * C) * D * D * D * D * D * D / 720);
            //转换为度 DD
            longitude = longitude1 / iPI;
            latitude = latitude1 / iPI;


            //wd = string.Format("{0:#00}°{1:00}′{2:00}″", du, fen, miao);
        }
    }
}
