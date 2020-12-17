using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LJZY.MODEL;
using LJZY.DAO.SYSTEM;
using System.Data;

namespace LJZY.BLL.SYSTEM
{
    public class HISTBLL
    {
        private readonly HISTDAO dal;
        public HISTBLL()
        {
            dal = new HISTDAO();
        }
        public bool Add(Sys_Hostroy hist)
        {
            return dal.Add(hist);
        }
        public bool Delete(string str)
        {
            return dal.Delete(str);
        }
        public List<Sys_Hostroy> GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public List<Sys_Hostroy> GetUserLastHistory(string uid)
        {
            return dal.GetUserLastHistory(uid);

        }

        public int CheckHistoryIsHave(string uid)
        {
            return dal.CheckHistoryIsHave(uid);
        }
    }
}
