using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class LQ_XMBPG
    {
        private string _LJFGS;
        /// <summary>
        /// 录井项目部
        /// </summary>
        [DisplayName ( "LJFGS" )]
        public string LJFGS
        {
            get { return _LJFGS; }
            set { _LJFGS = value; }
        }

        private int _DWZS;
        /// <summary>
        /// 队伍总数
        /// </summary>
        [DisplayName ( "DWZS" )]
        public int DWZS
        {
            get { return _DWZS; }
            set { _DWZS = value; }
        }

        private int _DMDW;
        /// <summary>
        /// 待命队伍
        /// </summary>
        [DisplayName ( "DMDW" )]
        public int DMDW
        {
            get { return _DMDW; }
            set { _DMDW = value; }
        }
        /// <summary>
        /// 勘探井
        /// </summary>
        public List<LQ_SCPG> KTJ_List
        {
            get { return _KTJ_List; }
            set { _KTJ_List = value; }
        }
        /// <summary>
        /// 评价井
        /// </summary>
        public List<LQ_SCPG> PJJ_List
        {
            get { return _PJJ_List; }
            set { _PJJ_List = value; }
        }
        /// <summary>
        /// 开发井
        /// </summary>
        public List<LQ_SCPG> KFJ_List
        {
            get { return _KFJ_List; }
            set { _KFJ_List = value; }
        }

        private List<LQ_SCPG> _KTJ_List;



        private List<LQ_SCPG> _PJJ_List;



        private List<LQ_SCPG> _KFJ_List;


    }
}
