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
    public class LQ_SCDTBLL
    {
        private readonly LQ_SCDTDAO dal;

        public LQ_SCDTBLL()
        {
            dal = new LQ_SCDTDAO ( );
        }


        public List<LQ_SCDT> SCDT_List( string Time, string strWhere, string dtName1, string dtName61 )
        {
            Dictionary<string, object> dic = new Dictionary<string, object> ( );
            List<string> strList = new List<string> ( );

            List<LQ_SCDT> list = new List<LQ_SCDT> ( );

            DataTable dt = dal.SCDT_List ( Time, strWhere, dtName1, dtName61 ).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LQ_SCDT model = new LQ_SCDT ( );
                DataRow dr = dt.Rows[i];
                model = dal.SCDTModel ( dr );
                list.Add ( model );
            }


            //List<SCDTList> scList = new List<SCDTList> ( );

            //strList = list.Select ( x => x.XQXMB ).Distinct ( ).ToList ( );
            //for (int i = 0; i < strList.Count; i++)
            //{
            //    SCDTList SCmodel = new SCDTList ( );
            //    SCmodel.XQXMB = strList[i];
            //    List<LQ_SCDT> rootList = list.Where ( m => m.XQXMB == strList[i] ).ToList<LQ_SCDT> ( );
            //    SCmodel.ItemList = rootList;
            //    scList.Add ( SCmodel );
            //}

            return list;
        }

        public DataTable excelSCDT(string Time, string strWhere, string dtName1, string dtName61)
        {
             
            DataTable dt = dal.SCDT_List(Time, strWhere, dtName1, dtName61).Tables[0];             
            return dt;
        }

    }
}
