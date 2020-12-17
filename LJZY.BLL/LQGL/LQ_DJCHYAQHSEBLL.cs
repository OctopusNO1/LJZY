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
  public class LQ_DJCHYAQHSEBLL
    {
        private readonly LQ_DJCHYAQHSEDAO dal;
        private readonly LQ_FILEDAO filedal;
        private readonly LQGLDAO lqgldal;

        public LQ_DJCHYAQHSEBLL()
        {
            dal = new LQ_DJCHYAQHSEDAO();
            filedal = new LQ_FILEDAO();
            lqgldal = new LQGLDAO();
        }

        public bool Add(LQ_DJCHYAQHSE DJCHYAQHSE)
        {
            return dal.Add(DJCHYAQHSE);
        }

        public bool Update(LQ_DJCHYAQHSE DJCHYAQHSE,string type)
        {
            return dal.Update(DJCHYAQHSE,type);
        }

        public bool Del(string ZJH, string FL)
        {
            return dal.Del(ZJH,FL);
        }

        public string Ptype(string Name)
        {
            return dal.Ptype(Name);
        }
        public Dictionary<string, object> DJCHYAQSHEDataGrid(string type,string strWhere, int rows, int page)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            int recordCount = 0;
            List<LQ_DJCHYAQHSE> list = new List<LQ_DJCHYAQHSE>();
            DataTable dt = dal.DJCHYAQSHE_strWhere(type,strWhere, rows, page, "TJSJ DESC ", out recordCount).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_DJCHYAQHSE model = new LQ_DJCHYAQHSE();
                DataRow dr = dt.Rows[i];
                model = dal.DJCHYAQHSEModel(dr);
                list.Add(model);
            }

            for (int i = 0; i < list.Count; i++)
            {
                list[i].BZRQ_DG = Convert.ToDateTime(list[i].BZRQ).ToString("yyyy-MM-dd");     
            }
            LQ_FILEBLL fileBLL = new LQ_FILEBLL();
            for (int i = 0; i < list.Count; i++)
            {
                if (type== "0")
                {
                    list[i].DJCHList = fileBLL.FileInfoList(list[i].ZJH, "单井策划");
                }
                if (type == "1")
                {
                    list[i].YJYAList = fileBLL.FileInfoList(list[i].ZJH, "单井应急预案");
                }
                if (type == "2")
                {
                    list[i].QSHEList = fileBLL.FileInfoList(list[i].ZJH, "QSHE作业计划书");
                }
            }
            dic.Add("total", recordCount.ToString());
            dic.Add("rows", list);
            return dic;
        }


        public int CheckDJCHYAHSE(string str, string type)
        {
            return dal.CheckDJCHYAHSE(str,type);
        }
    }
}
