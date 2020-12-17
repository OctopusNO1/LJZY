using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class LQ_SCPG
    {
        public LQ_SCPG()
        { }

        private int _ID;
        /// <summary>
        /// 主键Id
        /// </summary>
        [DisplayName ( "ID" )]
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _TROW;
        /// <summary>
        /// 排序序号
        /// </summary>
        [DisplayName ( "TROW" )]
        public int TROW
        {
            get { return _TROW; }
            set { _TROW = value; }
        }

        private string _JH;
        /// <summary>
        /// 井号
        /// </summary>
        [DisplayName ( "JH" )]
        public string JH
        {
            get { return _JH; }
            set { _JH = value; }
        }

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

        private string _TJR;
        /// <summary>
        /// 创建人
        /// </summary>
        [DisplayName ( "TJR" )]
        public string TJR
        {
            get { return _TJR; }
            set { _TJR = value; }
        }

        private string _TJSJ;
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName ( "TJSJ" )]
        public string TJSJ
        {
            get { return _TJSJ; }
            set { _TJSJ = value; }
        }

        //private int _FPZT;
        ///// <summary>
        ///// 分配状态
        ///// </summary>
        //[DisplayName ( "FPZT" )]
        //public int FPZT
        //{
        //    get { return _FPZT; }
        //    set { _FPZT = value; }
        //}

        private string _REPORT_TYPE;
        /// <summary>
        /// 井别
        /// </summary>
        [DisplayName ("REPORT_TYPE")]
        public string REPORT_TYPE
        {
            get { return _REPORT_TYPE; }
            set { _REPORT_TYPE = value; }
        }
    }
}
