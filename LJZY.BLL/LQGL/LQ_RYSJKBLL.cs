using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LJZY.DAO.LQGL;
using LJZY.MODEL;
using System.Data;
using Newtonsoft.Json;

namespace LJZY.BLL.LQGL
{
    public class LQ_RYSJKBLL
    {
        private readonly LQ_RYSJKDAO dal;
        public LQ_RYSJKBLL()
        {
            dal = new LQ_RYSJKDAO();
        }

        public bool Add(LQ_RYSJK RYSJK)
        {
            return dal.Add(RYSJK);
        }

        public bool Update(LQ_RYSJK RYSJK)
        {
            return dal.Update(RYSJK);
        }

        public bool Del(string ID)
        {
            return dal.Del(ID);

        }

        public int COUNT_List()
        {
            return dal.COUNT_List();
        }

        /// <summary>
        /// 根据排序获取人员信息
        /// </summary>
        /// <param name="TROW"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<LQ_RYSJK> RYSJKInfo(int TROW)

        {
            LQ_JCZJSON jczlist = new LQ_JCZJSON();
            LQ_SGZJSON sgzlist = new LQ_SGZJSON();
            LQ_HSEJSON hselist = new LQ_HSEJSON();
            List<LQ_RYSJK> list = new List<LQ_RYSJK>();
            string strSql = string.Format(@" AND TROW={0} ", TROW);
            DataTable dt = dal.RYSJKInfo(strSql).Tables[0];
            int yearsjday = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_RYSJK model = new LQ_RYSJK();
                DataRow dr = dt.Rows[i];
                model = dal.RYSJKModel(dr);

                list.Add(model);
                DataTable dt2 = dal.SJRZInfo(dt.Rows[i]["RYBH"].ToString()).Tables[0];//根据人员编号查询最新一条上井记录
                for (int j = 0; j < list.Count; j++)
                {
                    if (dt2.Rows.Count > 0)
                    {
                        list[j].SJJH = dt2.Rows[0]["ZJH"].ToString();//上井井号
                        if (!string.IsNullOrEmpty(dt2.Rows[0]["KSSJRQ"].ToString()))
                        {
                            list[j].KSSJRQ = Convert.ToDateTime(dt2.Rows[0]["KSSJRQ"]);//开始上井时间
                        }

                        if (!string.IsNullOrEmpty(dt2.Rows[0]["JSSJRQ"].ToString()))
                        {
                            list[j].JSSJRQ = Convert.ToDateTime(dt2.Rows[0]["JSSJRQ"]);//结束上井时间
                        }
                    }
                    //json反序列化井控证 上岗证 hse证
                    if (!string.IsNullOrEmpty(list[i].JCZ))
                    {
                        jczlist = JsonConvert.DeserializeObject<LQ_JCZJSON>(list[i].JCZ);
                        list[i].JCZBH = jczlist.ZJBH;//井控证编号
                        list[i].JCZYXQ = jczlist.YXQ;//有效期
                        list[i].JCZIMG = jczlist.IMG;//井控证图片
                    }
                    if (!string.IsNullOrEmpty(list[i].SGZ))
                    {
                        sgzlist = JsonConvert.DeserializeObject<LQ_SGZJSON>(list[i].SGZ);
                        list[i].SGZBH = sgzlist.ZJBH;//上岗证编号
                        list[i].SGZYXQ = sgzlist.YXQ;//有效期
                        list[i].SGZIMG = sgzlist.IMG;//上岗证图片
                    }
                    if (!string.IsNullOrEmpty(list[i].HSE))
                    {
                        hselist = JsonConvert.DeserializeObject<LQ_HSEJSON>(list[i].HSE);
                        list[i].HSEBH = hselist.ZJBH;//hse证编号
                        list[i].HSEYXQ = hselist.YXQ;//有效期
                        list[i].HSEIMG = hselist.IMG;//hse证图片
                    }
                }
                if (!string.IsNullOrEmpty(list[i].KSSJRQ.ToString()) && !string.IsNullOrEmpty(list[i].JSSJRQ.ToString()))
                {
                    list[i].BJSJTS = GetDay(list[i].KSSJRQ, list[i].JSSJRQ);
                    if (list[i].BJSJTS < 0)
                    {
                        list[i].BJSJTS = 0;
                    }
                }
                else
                {
                    list[i].BJSJTS = 0;
                }
                string Year = DateTime.Now.Year.ToString();//获取当前年份
                string kstime = Year + "-01-01";
                string jstime = Year + "-12-31";

                DataTable dt3 = dal.GetYearDay(dt.Rows[i]["RYBH"].ToString(), kstime, jstime, list[i].SJJH).Tables[0];//根据人员编号查询员工今年所有的上井记录

                for (int n = 0; n < dt3.Rows.Count; n++)
                {
                    if (!string.IsNullOrEmpty(dt3.Rows[n]["KSSJRQ"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[n]["JSSJRQ"].ToString()))
                    {
                        if (GetDay(Convert.ToDateTime(dt3.Rows[n]["KSSJRQ"]), Convert.ToDateTime(dt3.Rows[n]["JSSJRQ"])) < 0)//计算上井天数
                        {
                            yearsjday += 0;//时间差小于0(结束上井日期小于开始上井日期)则记为0;
                        }
                        else
                        {
                            yearsjday += GetDay(Convert.ToDateTime(dt3.Rows[n]["KSSJRQ"]), Convert.ToDateTime(dt3.Rows[n]["JSSJRQ"]));
                        }

                    }

                }

                list[i].NDSJTS = yearsjday.ToString();
            }


            return list;
        }

        public List<LQ_RYSJK> RYSJKInfo_BH(string ID)
        {
            LQ_JCZJSON jczlist = new LQ_JCZJSON();
            LQ_SGZJSON sgzlist = new LQ_SGZJSON();
            LQ_HSEJSON hselist = new LQ_HSEJSON();
            int yearsjday = 0;
            List<LQ_RYSJK> list = new List<LQ_RYSJK>();
            string strSql = string.Format(@" AND ID='{0}' ", ID);
            DataTable dt = dal.RYSJKInfo(strSql).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_RYSJK model = new LQ_RYSJK();

                DataRow dr = dt.Rows[i];
                model = dal.RYSJKModel(dr);
                //model.TROW = i;
                list.Add(model);
                DataTable dt2 = dal.SJRZInfo(dt.Rows[i]["RYBH"].ToString()).Tables[0];
                for (int j = 0; j < list.Count; j++)
                {
                    for (int m = 0; m < dt2.Rows.Count; m++)
                    {
                        list[j].SJJH = dt2.Rows[m]["ZJH"].ToString();
                        if (!string.IsNullOrEmpty(dt2.Rows[m]["KSSJRQ"].ToString()))
                        {
                            list[j].KSSJRQ = Convert.ToDateTime(dt2.Rows[m]["KSSJRQ"]);
                        }
                        if (!string.IsNullOrEmpty(dt2.Rows[m]["JSSJRQ"].ToString()))
                        {
                            list[j].JSSJRQ = Convert.ToDateTime(dt2.Rows[m]["JSSJRQ"]);
                        }
                    }

                    if (!string.IsNullOrEmpty(list[i].JCZ))
                    {
                        jczlist = JsonConvert.DeserializeObject<LQ_JCZJSON>(list[i].JCZ);
                        list[i].JCZBH = jczlist.ZJBH;
                        list[i].JCZYXQ = jczlist.YXQ;
                        list[i].JCZIMG = jczlist.IMG;
                    }
                    if (!string.IsNullOrEmpty(list[i].SGZ))
                    {
                        sgzlist = JsonConvert.DeserializeObject<LQ_SGZJSON>(list[i].SGZ);
                        list[i].SGZBH = sgzlist.ZJBH;
                        list[i].SGZYXQ = sgzlist.YXQ;
                        list[i].SGZIMG = sgzlist.IMG;
                    }
                    if (!string.IsNullOrEmpty(list[i].HSE))
                    {
                        hselist = JsonConvert.DeserializeObject<LQ_HSEJSON>(list[i].HSE);
                        list[i].HSEBH = hselist.ZJBH;
                        list[i].HSEYXQ = hselist.YXQ;
                        list[i].HSEIMG = hselist.IMG;
                    }
                }
                if (!string.IsNullOrEmpty(list[i].KSSJRQ.ToString()) && !string.IsNullOrEmpty(list[i].JSSJRQ.ToString()))
                {
                    list[i].BJSJTS = GetDay(list[i].KSSJRQ, list[i].JSSJRQ);
                    if (list[i].BJSJTS < 0)
                    {
                        list[i].BJSJTS = 0;
                    }
                }
                else
                {
                    list[i].BJSJTS = 0;
                }
                string Year = DateTime.Now.Year.ToString();
                string kstime = Year + "-01-01";
                string jstime = Year + "-12-31";
                DataTable dt3 = dal.GetYearDay(dt.Rows[i]["RYBH"].ToString(), kstime, jstime, list[i].SJJH).Tables[0];
                for (int n = 0; n < dt3.Rows.Count; n++)
                {
                    if (!string.IsNullOrEmpty(dt3.Rows[n]["KSSJRQ"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[n]["JSSJRQ"].ToString()))
                    {
                        if (GetDay(Convert.ToDateTime(dt3.Rows[n]["KSSJRQ"]), Convert.ToDateTime(dt3.Rows[n]["JSSJRQ"])) < 0)
                        {
                            yearsjday += 0;
                        }
                        else
                        {
                            yearsjday += GetDay(Convert.ToDateTime(dt3.Rows[n]["KSSJRQ"]), Convert.ToDateTime(dt3.Rows[n]["JSSJRQ"]));
                        }

                    }


                }
                list[i].NDSJTS = yearsjday.ToString();
            }

            return list;
        }

        /// <summary>
        /// 检查人员编号是否存在
        /// </summary>
        /// <param name="RYBH"></param>
        /// <returns></returns>
        public int CheckRY(string RYBH)
        {
            return dal.CheckRY(RYBH);
        }
        /// <summary>
        /// 人员信息列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="rows"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public Dictionary<string, object> RYSJKDataGrid(string strWhere, int rows, int page)
        {
            LQ_JCZJSON jczlist = new LQ_JCZJSON();
            LQ_SGZJSON sgzlist = new LQ_SGZJSON();
            LQ_HSEJSON hselist = new LQ_HSEJSON();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_RYSJK> list = new List<LQ_RYSJK>();
            DataTable dt = dal.RYSJK_strWhere(strWhere, rows, page, "TJSJ DESC ", out recordCount).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_RYSJK model = new LQ_RYSJK();
                DataRow dr = dt.Rows[i];
                model = dal.RYSJKModel(dr);
                list.Add(model);
            }

            for (int i = 0; i < list.Count; i++)
            {
                DataTable dt2 = dal.SJRZInfo(dt.Rows[i]["RYBH"].ToString()).Tables[0];//根据人员编号查询最新一条上井记录
                for (int m = 0; m < dt2.Rows.Count; m++)
                {
                    list[i].SJJH = dt2.Rows[m]["ZJH"].ToString();
                    if (!string.IsNullOrEmpty(dt2.Rows[m]["KSSJRQ"].ToString()))
                    {
                        list[i].KSSJRQ = Convert.ToDateTime(dt2.Rows[m]["KSSJRQ"]);
                        list[i].KSSJRQ_DG = Convert.ToDateTime(list[i].KSSJRQ).ToString("yyyy-MM-dd");
                    }
                    if (!string.IsNullOrEmpty(dt2.Rows[m]["JSSJRQ"].ToString()))
                    {
                        list[i].JSSJRQ = Convert.ToDateTime(dt2.Rows[m]["JSSJRQ"]);
                        list[i].JSSJRQ_DG = Convert.ToDateTime(list[i].JSSJRQ).ToString("yyyy-MM-dd");
                    }

                }
                int yearsjday = 0;
                string Year = DateTime.Now.Year.ToString();
                string kstime = Year + "-01-01";
                string jstime = Year + "-12-31";
                DataTable dt3 = dal.GetYearDay(dt.Rows[i]["RYBH"].ToString(), kstime, jstime, list[i].SJJH).Tables[0];
                for (int n = 0; n < dt3.Rows.Count; n++)
                {
                    if (!string.IsNullOrEmpty(dt3.Rows[n]["KSSJRQ"].ToString()) && !string.IsNullOrEmpty(dt3.Rows[n]["JSSJRQ"].ToString()))
                    {
                        if (GetDay(Convert.ToDateTime(dt3.Rows[n]["KSSJRQ"]), Convert.ToDateTime(dt3.Rows[n]["JSSJRQ"])) < 0)
                        {
                            yearsjday += 0;
                        }
                        else
                        {
                            yearsjday += GetDay(Convert.ToDateTime(dt3.Rows[n]["KSSJRQ"]), Convert.ToDateTime(dt3.Rows[n]["JSSJRQ"]));
                        }

                    }


                }
                list[i].NDSJTS = yearsjday.ToString();

                if (!string.IsNullOrEmpty(list[i].JCZ))
                {
                    jczlist = JsonConvert.DeserializeObject<LQ_JCZJSON>(list[i].JCZ);
                    list[i].JCZBH = jczlist.ZJBH;
                    list[i].JCZYXQ = jczlist.YXQ;
                    list[i].JCZIMG = jczlist.IMG;
                }
                if (!string.IsNullOrEmpty(list[i].SGZ))
                {
                    sgzlist = JsonConvert.DeserializeObject<LQ_SGZJSON>(list[i].SGZ);
                    list[i].SGZBH = sgzlist.ZJBH;
                    list[i].SGZYXQ = sgzlist.YXQ;
                    list[i].SGZIMG = sgzlist.IMG;
                }
                if (!string.IsNullOrEmpty(list[i].HSE))
                {
                    hselist = JsonConvert.DeserializeObject<LQ_HSEJSON>(list[i].HSE);
                    list[i].HSEBH = hselist.ZJBH;
                    list[i].HSEYXQ = hselist.YXQ;
                    list[i].HSEIMG = hselist.IMG;
                }

            }
            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }



        public Dictionary<string, object> SJRZDataGrid(string dtName1, string strWhere, int rows, int page)
        {

            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_SJRZ> list = new List<LQ_SJRZ>();
            DataTable dt = dal.RYRZ_strWhere(dtName1, strWhere, rows, page, " TJSJ DESC ", out recordCount).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_SJRZ model = new LQ_SJRZ();
                DataRow dr = dt.Rows[i];
                model = dal.RYRZModel(dr);
                list.Add(model);

            }
            //for (int j = 0; j < list.Count; j++)
            //{
            //    if (string.IsNullOrEmpty ( dt.Rows[j]["KSSJRQ"].ToString ( ) ) || string.IsNullOrEmpty ( dt.Rows[j]["JSSJRQ"].ToString ( ) ))
            //    {
            //        list[j].SJTS = 0;
            //    }
            //    else
            //    {
            //        list[j].SJTS = GetDay ( Convert.ToDateTime ( dt.Rows[j]["KSSJRQ"] ), Convert.ToDateTime ( dt.Rows[j]["JSSJRQ"] ) );
            //        if (list[j].SJTS < 0)
            //        {
            //            list[j].SJTS = 0;
            //        }
            //    }
            //    string Year = DateTime.Now.Year.ToString ( );
            //    string kstime = Year + "-01-01";
            //    string jstime = Year + "-12-31";
            //    int yearsjday = 0;
            //    DataTable dt3 = dal.GetYearDay ( dt.Rows[j]["RYBH"].ToString ( ), kstime, jstime, dt.Rows[j]["JH"].ToString ( ) ).Tables[0];
            //    for (int n = 0; n < dt3.Rows.Count; n++)
            //    {
            //        if (!string.IsNullOrEmpty ( dt3.Rows[n]["KSSJRQ"].ToString ( ) ) && !string.IsNullOrEmpty ( dt3.Rows[n]["JSSJRQ"].ToString ( ) ))
            //        {
            //            if (GetDay ( Convert.ToDateTime ( dt3.Rows[n]["KSSJRQ"] ), Convert.ToDateTime ( dt3.Rows[n]["JSSJRQ"] ) ) < 0)
            //            {
            //                yearsjday += 0;
            //            }
            //            else
            //            {
            //                yearsjday += GetDay ( Convert.ToDateTime ( dt3.Rows[n]["KSSJRQ"] ), Convert.ToDateTime ( dt3.Rows[n]["JSSJRQ"] ) );
            //            }

            //        }


            //    }
            //   list[j].LJSJTS = yearsjday;

            //}

            //for (int i = 0; i < list.Count; i++)
            //{
            //    list[i].KSSJRQ_GD = Convert.ToDateTime ( list[i].KSSJRQ ).ToString ( "yyyy-MM-dd" );
            //    list[i].JSSJRQ_GD = Convert.ToDateTime ( list[i].JSSJRQ ).ToString ( "yyyy-MM-dd" );
            //}

            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }

        /// <summary>
        /// 上井日志导出
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="dtName1"></param>
        /// <returns></returns>
        public DataTable EXCEL_SJRZ(string strWhere, string dtName1)
        {
            DataTable dt = dal.RYRZ_strWhere(dtName1, strWhere).Tables[0];
            return dt;
        }

        /// <summary>
        /// 人员信息excel
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public DataTable EXCEL_RYSJK(string str)
        {
            return dal.EXCEL_RYSJK(str).Tables[0];
        }

        /// <summary>
        /// 计算天数
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public int GetDay(DateTime StartTime, DateTime EndTime)
        {
            DateTime start = Convert.ToDateTime(StartTime.ToShortDateString());
            DateTime end = Convert.ToDateTime(EndTime.ToShortDateString());
            TimeSpan Today = end.Subtract(start);
            return Today.Days;
        }

        public bool ADDNDJZ(LQ_RYSJK lQ_RYSJK, string ID)
        {
            return dal.ADDNDJZ(lQ_RYSJK, ID);
        }
    }

}
