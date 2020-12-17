using LJZY.DAO.LQGL;
using LJZY.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.BLL.LQGL
{
    public class LQ_RYSBBLL
    {
        private readonly LQ_RYSBDAO dal;

        public LQ_RYSBBLL()
        {
            dal = new LQ_RYSBDAO();
        }

        public LQ_RSList RYSB_List(string Time, string strWhere, string dtName1, string dtName61)
        {
            LQ_RSList dic = new LQ_RSList();
            List<string> strList = new List<string>();

            List<LQ_RYSB> allList = new List<LQ_RYSB>();
            List<LQ_RYDT> rydtList = new List<LQ_RYDT>();
            List<LQ_SJRZ> sjrzList = new List<LQ_SJRZ>();
            List<LQ_FWFP> fwList = new List<LQ_FWFP>();

            //获取主要数据部分
            DataTable dt = dal.LJXMInfo_List(Time, strWhere, dtName1, dtName61).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_RYSB model = new LQ_RYSB();
                DataRow dr = dt.Rows[i];
                model = dal.RYSBModel(dr);
                allList.Add(model);
            }

            //录井分配人员部分信息
            DataTable dt1 = dal.RYFPInfo_List().Tables[0];
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                LQ_RYDT model = new LQ_RYDT();
                DataRow dr = dt1.Rows[i];
                model = dal.RYDTModel(dr);
                rydtList.Add(model);
            }

            //上井日志部分信息
            DataTable dt2 = dal.SJRZInfo_List().Tables[0];
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                LQ_SJRZ model = new LQ_SJRZ();
                DataRow dr = dt2.Rows[i];
                model = dal.SJRZModel(dr);
                sjrzList.Add(model);
            }

            //房屋分配部分信息
            DataTable dt3 = dal.FWInfo_List().Tables[0];
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                LQ_FWFP model = new LQ_FWFP();
                DataRow dr = dt3.Rows[i];
                model = dal.FWModel(dr);
                fwList.Add(model);
            }
            LQ_RYSBCount rysbCount = new LQ_RYSBCount();//人员设备统计行
            rysbCount.DWZBHCount = 0;
            rysbCount.LJDHCount = 0;
            rysbCount.LJYQXHCount = 0;
            rysbCount.ZJHCount = 0;
            rysbCount.SGDHCount = 0;
            rysbCount.DQZTCount = 0;
            rysbCount.HXJWCount = 0;
            rysbCount.DzsListCount = 0;
            rysbCount.DzzlListCount = 0;
            rysbCount.DzgListCount = 0;
            rysbCount.CzyListCount = 0;
            rysbCount.GcsListCount = 0;
            rysbCount.DzfListCount = 0;
            rysbCount.ZfListCount = 0;


            for (int i = 0; i < allList.Count; i++)
            {
                if (!string.IsNullOrEmpty(allList[i].DWZBH))
                {
                    rysbCount.DWZBHCount += 1;
                }

                if (!string.IsNullOrEmpty(allList[i].LJDH))
                {
                    rysbCount.LJDHCount += 1;
                }

                if (!string.IsNullOrEmpty(allList[i].LJYQXH))
                {
                    rysbCount.LJYQXHCount += 1;
                }

                if (!string.IsNullOrEmpty(allList[i].JH))
                {
                    rysbCount.ZJHCount += 1;
                }

                if (!string.IsNullOrEmpty(allList[i].SGDH))
                {
                    rysbCount.SGDHCount += 1;
                }

                if (!string.IsNullOrEmpty(allList[i].DQZT))
                {
                    rysbCount.DQZTCount += 1;
                }

                if (!string.IsNullOrEmpty(allList[i].HXJW))
                {
                    rysbCount.HXJWCount += 1;
                }

                allList[i].DzsList = rydtList.Where(m => (m.GW == "录井地质师" || m.GW == "开发井地质师") && m.JH == allList[i].JH).ToList<LQ_RYDT>();
                if (allList[i].DzsList.Count > 0)
                {
                    allList[i].Dzs = allList[i].DzsList[0].XM;
                    rysbCount.DzsListCount += allList[i].DzsList.Count;
                }

                for (int j = 0; j < allList[i].DzsList.Count; j++)
                { 
                    allList[i].DzsList[j].SjrzList = sjrzList.Where(n => n.RYBH == allList[i].DzsList[j].RYBH).ToList<LQ_SJRZ>();
                }

                allList[i].DzzlList = rydtList.Where(m => m.GW == "地质助理" && m.JH == allList[i].JH).ToList<LQ_RYDT>();
                if (allList[i].DzzlList.Count > 0)
                {
                    allList[i].Dzzl = allList[i].DzzlList[0].XM;
                    rysbCount.DzzlListCount += allList[i].DzzlList.Count;
                }
                for (int j = 0; j < allList[i].DzzlList.Count; j++)
                {
                    allList[i].DzzlList[j].SjrzList = sjrzList.Where(n => n.RYBH == allList[i].DzzlList[j].RYBH).ToList<LQ_SJRZ>();
                }
                //录井工程师
                allList[i].GcsList = rydtList.Where(m => m.GW == "录井工程师" && m.JH == allList[i].JH).ToList<LQ_RYDT>();
                if (allList[i].GcsList.Count > 0)
                {
                    allList[i].Gcs = allList[i].GcsList[0].XM;
                    rysbCount.GcsListCount += allList[i].GcsList.Count;
                }
                for (int j = 0; j < allList[i].GcsList.Count; j++)
                {
                    allList[i].GcsList[j].SjrzList = sjrzList.Where(n => n.RYBH == allList[i].GcsList[j].RYBH).ToList<LQ_SJRZ>();
                }

                //操作员
                allList[i].CzyList = rydtList.Where(m => m.GW == "操作员" && m.JH == allList[i].JH).ToList<LQ_RYDT>();
                if (allList[i].CzyList.Count > 0)
                {
                    rysbCount.CzyListCount += allList[i].CzyList.Count;
                }
                for (int j = 0; j < allList[i].CzyList.Count; j++)
                {
                    switch (j)
                    {
                        case 1:
                            allList[i].Czy1 = allList[i].CzyList[j].XM;
                            break;
                        case 2:
                            allList[i].Czy2 = allList[i].CzyList[j].XM;
                            break;
                        case 3:
                            allList[i].Czy3 = allList[i].CzyList[j].XM;
                            break;
                    }
                    allList[i].CzyList[j].SjrzList = sjrzList.Where(n => n.RYBH == allList[i].CzyList[j].RYBH).ToList<LQ_SJRZ>();
                }
                //地质工
                allList[i].DzgList = rydtList.Where(m => m.GW == "地质工" && m.JH == allList[i].JH).ToList<LQ_RYDT>();
                if (allList[i].DzgList.Count > 0)
                {
                    rysbCount.DzgListCount += allList[i].DzgList.Count;
                }
                for (int j = 0; j < allList[i].DzgList.Count; j++)
                {
                    switch (j)
                    {
                        case 1:
                            allList[i].Dzg1 = allList[i].DzgList[j].XM;
                            break;
                        case 2:
                            allList[i].Dzg2 = allList[i].DzgList[j].XM;
                            break;
                        case 3:
                            allList[i].Dzg3 = allList[i].DzgList[j].XM;
                            break;
                        case 4:
                            allList[i].Dzg4 = allList[i].DzgList[j].XM;
                            break;
                    }
                    allList[i].DzgList[j].SjrzList = sjrzList.Where(n => n.RYBH == allList[i].DzgList[j].RYBH).ToList<LQ_SJRZ>();
                }
                //地质房
                allList[i].DzfList = fwList.Where(m => m.FL == "地质房" && m.JH == allList[i].JH).ToList<LQ_FWFP>();
                if (allList[i].DzfList.Count > 0)
                {
                    allList[i].Dzg4 = allList[i].DzfList[0].CCBH;
                    rysbCount.DzfListCount += allList[i].DzfList.Count;
                }
                //住房
                allList[i].ZfList = fwList.Where(m => m.FL == "住房" && m.JH == allList[i].JH).ToList<LQ_FWFP>();
                if (allList[i].ZfList.Count > 0)
                {
                    for (int j = 0; j < allList[i].ZfList.Count; j++)
                    {
                        switch (j)
                        {
                            case 1:
                                allList[i].Zf1 = allList[i].ZfList[j].CCBH;
                                break;
                            case 2:
                                allList[i].Zf2 = allList[i].ZfList[j].CCBH;
                                break;
                            
                        }
                    }     
                    rysbCount.ZfListCount += allList[i].ZfList.Count;
                }

            }

            dic.List = allList;
            dic.ListCount = rysbCount;
            return dic;
        }

        public LQ_JDLXRY RY_List( )
        {
            LQ_JDLXRY LXRY = new LQ_JDLXRY();
            List<LQ_RYSJK> Ry_List= dal.RYInfo_List();
            LXRY.LD_List = Ry_List.Where(o => o.GW == "领导").ToList<LQ_RYSJK>();
            LXRY.ZRS_List = Ry_List.Where(o => o.GW == "责任师").ToList<LQ_RYSJK>();
            LXRY.JGY_List = Ry_List.Where(o => o.GW == "经管院").ToList<LQ_RYSJK>();
            LXRY.SBGL_List = Ry_List.Where(o => o.GW == "设备管理").ToList<LQ_RYSJK>();
            LXRY.KF_List = Ry_List.Where(o => o.GW == "开发").ToList<LQ_RYSJK>();
            LXRY.Dzs_List = Ry_List.Where(m => (m.GW == "录井地质师" || m.GW == "开发井地质师") && m.RYZT == "轮休").ToList<LQ_RYSJK>();
            LXRY.Czy_List = Ry_List.Where(m => m.GW == "操作员" && m.RYZT == "轮休").ToList<LQ_RYSJK>();
            LXRY.Sxs_List = Ry_List.Where(m => m.GW == "实习生" && m.RYZT == "轮休").ToList<LQ_RYSJK>();
            LXRY.Dzg_List = Ry_List.Where(m => m.GW == "地质工" && m.RYZT == "轮休").ToList<LQ_RYSJK>();
            return LXRY;
        }

            //public List<LQ_RYSB> RS_List()
            //{
            //    //Dictionary<string, object> dic = new Dictionary<string, object> ( );
            //    //List<string> strList = new List<string> ( );

            //    List<LQ_RYSB> allList = new List<LQ_RYSB> ( );
            //    List<LQ_RYDT> rydtList = new List<LQ_RYDT> ( );
            //    List<LQ_SJRZ> sjrzList = new List<LQ_SJRZ> ( );
            //    List<LQ_FWFP> fwList = new List<LQ_FWFP> ( );

            //    //获取主要数据部分
            //    DataTable dt = dal.LJXMInfo_List ( ).Tables[0];
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        LQ_RYSB model = new LQ_RYSB ( );
            //        DataRow dr = dt.Rows[i];
            //        model = dal.RYSBModel ( dr );
            //        allList.Add ( model );
            //    }

            //    //录井分配人员部分信息
            //    DataTable dt1 = dal.RYFPInfo_List ( ).Tables[0];
            //    for (int i = 0; i < dt1.Rows.Count; i++)
            //    {
            //        LQ_RYDT model = new LQ_RYDT ( );
            //        DataRow dr = dt1.Rows[i];
            //        model = dal.RYDTModel ( dr );
            //        rydtList.Add ( model );
            //    }

            //    //上井日志部分信息
            //    DataTable dt2 = dal.SJRZInfo_List ( ).Tables[0];
            //    for (int i = 0; i < dt2.Rows.Count; i++)
            //    {
            //        LQ_SJRZ model = new LQ_SJRZ ( );
            //        DataRow dr = dt2.Rows[i];
            //        model = dal.SJRZModel ( dr );
            //        sjrzList.Add ( model );
            //    }

            //    //房屋分配部分信息
            //    DataTable dt3 = dal.FWInfo_List ( ).Tables[0];
            //    for (int i = 0; i < dt3.Rows.Count; i++)
            //    {
            //        LQ_FWFP model = new LQ_FWFP ( );
            //        DataRow dr = dt3.Rows[i];
            //        model = dal.FWModel ( dr );
            //        fwList.Add ( model );
            //    }
            //    LQ_RYSBCount rysbCount = new LQ_RYSBCount ( );//人员设备统计行
            //    rysbCount.DWZBHCount = 0;
            //    rysbCount.LJDHCount = 0;
            //    rysbCount.LJYQXHCount = 0;
            //    rysbCount.ZJHCount = 0;
            //    rysbCount.SGDHCount = 0;
            //    rysbCount.DQZTCount = 0;
            //    rysbCount.HXJWCount = 0;
            //    rysbCount.DzsListCount = 0;
            //    rysbCount.DzzlListCount = 0;
            //    rysbCount.DzgListCount = 0;
            //    rysbCount.CzyListCount = 0;
            //    rysbCount.GcsListCount = 0;
            //    rysbCount.DzfListCount = 0;
            //    rysbCount.ZfListCount = 0;


            //    for (int i = 0; i < allList.Count; i++)
            //    {
            //        if (!string.IsNullOrEmpty ( allList[i].DWZBH ))
            //        {
            //            rysbCount.DWZBHCount += 1;
            //        }

            //        if (!string.IsNullOrEmpty ( allList[i].LJDH ))
            //        {
            //            rysbCount.LJDHCount += 1;
            //        }

            //        if (!string.IsNullOrEmpty ( allList[i].LJYQXH ))
            //        {
            //            rysbCount.LJYQXHCount += 1;
            //        }

            //        if (!string.IsNullOrEmpty ( allList[i].ZJH ))
            //        {
            //            rysbCount.ZJHCount += 1;
            //        }

            //        if (!string.IsNullOrEmpty ( allList[i].SGDH ))
            //        {
            //            rysbCount.SGDHCount += 1;
            //        }

            //        if (!string.IsNullOrEmpty ( allList[i].DQZT ))
            //        {
            //            rysbCount.DQZTCount += 1;
            //        }

            //        if (!string.IsNullOrEmpty ( allList[i].HXJW ))
            //        {
            //            rysbCount.HXJWCount += 1;
            //        }

            //        allList[i].DzsList = rydtList.Where ( m => ( m.GW == "录井地质师" || m.GW == "开发井地质师" ) && m.ZJH == allList[i].ZJH ).ToList<LQ_RYDT> ( );
            //        if (allList[i].DzsList.Count > 0)
            //        {
            //            rysbCount.DzsListCount += allList[i].DzsList.Count;
            //        }

            //        for (int j = 0; j < allList[i].DzsList.Count; j++)
            //        {
            //            allList[i].DzsList[j].SjrzList = sjrzList.Where ( n => n.RYBH == allList[i].DzsList[j].RYBH ).ToList<LQ_SJRZ> ( );
            //        }

            //        allList[i].DzzlList = rydtList.Where ( m => m.GW == "地质助理" && m.ZJH == allList[i].ZJH ).ToList<LQ_RYDT> ( );
            //        if (allList[i].DzzlList.Count > 0)
            //        {
            //            rysbCount.DzzlListCount += allList[i].DzzlList.Count;
            //        }
            //        for (int j = 0; j < allList[i].DzzlList.Count; j++)
            //        {
            //            allList[i].DzzlList[j].SjrzList = sjrzList.Where ( n => n.RYBH == allList[i].DzzlList[j].RYBH ).ToList<LQ_SJRZ> ( );
            //        }
            //        //录井工程师
            //        allList[i].GcsList = rydtList.Where ( m => m.GW == "录井工程师" && m.ZJH == allList[i].ZJH ).ToList<LQ_RYDT> ( );
            //        if (allList[i].GcsList.Count > 0)
            //        {
            //            rysbCount.GcsListCount += allList[i].GcsList.Count;
            //        }
            //        for (int j = 0; j < allList[i].GcsList.Count; j++)
            //        {
            //            allList[i].GcsList[j].SjrzList = sjrzList.Where ( n => n.RYBH == allList[i].GcsList[j].RYBH ).ToList<LQ_SJRZ> ( );
            //        }

            //        //操作员
            //        allList[i].CzyList = rydtList.Where ( m => m.GW == "操作员" && m.ZJH == allList[i].ZJH ).ToList<LQ_RYDT> ( );
            //        if (allList[i].CzyList.Count > 0)
            //        {
            //            rysbCount.CzyListCount += allList[i].CzyList.Count;
            //        }
            //        for (int j = 0; j < allList[i].CzyList.Count; j++)
            //        {
            //            allList[i].CzyList[j].SjrzList = sjrzList.Where ( n => n.RYBH == allList[i].CzyList[j].RYBH ).ToList<LQ_SJRZ> ( );
            //        }
            //        //地质工
            //        allList[i].DzgList = rydtList.Where ( m => m.GW == "地质工" && m.ZJH == allList[i].ZJH ).ToList<LQ_RYDT> ( );
            //        if (allList[i].DzgList.Count > 0)
            //        {
            //            rysbCount.DzgListCount += allList[i].DzgList.Count;
            //        }
            //        for (int j = 0; j < allList[i].DzgList.Count; j++)
            //        {
            //            allList[i].DzgList[j].SjrzList = sjrzList.Where ( n => n.RYBH == allList[i].DzgList[j].RYBH ).ToList<LQ_SJRZ> ( );
            //        }
            //        //地质房
            //        allList[i].DzfList = fwList.Where ( m => m.FL == "地质房" && m.ZJH == allList[i].ZJH ).ToList<LQ_FWFP> ( );
            //        if (allList[i].DzfList.Count > 0)
            //        {
            //            rysbCount.DzfListCount += allList[i].DzfList.Count;
            //        }
            //        //住房
            //        allList[i].ZfList = fwList.Where ( m => m.FL == "住房" && m.ZJH == allList[i].ZJH ).ToList<LQ_FWFP> ( );
            //        if (allList[i].ZfList.Count > 0)
            //        {
            //            rysbCount.ZfListCount += allList[i].ZfList.Count;
            //        }

            //    }
            //    //dic.Add ( "List", allList );
            //    //dic.Add ( "Count", rysbCount );

            //    return allList;
            //}
        }
}
