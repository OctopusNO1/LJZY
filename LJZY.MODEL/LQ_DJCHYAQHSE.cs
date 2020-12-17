using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class LQ_DJCHYAQHSE
    {
        private string _ID;
        private string _ZJH;
        private Int32 _XH;
        private int _TROW;
        private string _FL;
        private string _SC3;
        private string _JH;
        private string _JX;
        private string _REPORT_TYPE;
        private string _SC2;
        private string _QK;
        private string _LJFGS;
        private string _BZR;
        private DateTime _BZRQ;
        private string _TJR;
        private DateTime _TJSJ;
        private string _BZ;
        private string _BZRQ_DG;

        public LQ_DJCHYAQHSE()
        {
            _BZRQ = DateTime.Now;
        }

        //主键ID
        [DisplayName("ID")]
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        //主井号
        [DisplayName("ZJH")]
        public string ZJH
        {
            get { return _ZJH; }
            set { _ZJH = value; }
        }

        //序号
        [DisplayName("XH")]
        public int XH
        {
            get { return _XH; }
            set { _XH = value; }
        }

        /// <summary>
        /// 排序号
        /// </summary>
        [DisplayName("TROW")]
        public int TROW
        {
            get { return _TROW; }
            set { _TROW = value; }
        }


        //单井策划 应急预案 QSHE
        [DisplayName("FL")]
        public string FL
        {
            get { return _FL; }
            set { _FL = value; }
        }

        //甲方单位
        [DisplayName("SC3")]
        public string SC3
        {
            get { return _SC3; }
            set { _SC3 = value; }
        }

        //井号
        [DisplayName("JH")]
        public string JH
        {
            get { return _JH; }
            set { _JH = value; }
        }

        //井型
        [DisplayName("JX")]
        public string JX
        {
            get { return _JX; }
            set { _JX = value; }
        }

        //井别
        [DisplayName("REPORT_TYPE")]
        public string REPORT_TYPE
        {
            get { return _REPORT_TYPE; }
            set { _REPORT_TYPE = value; }
        }

        //地区
        [DisplayName("SC2")]
        public string SC2
        {
            get{ return _SC2;}
            set { _SC2 = value; }
        }

        //区块
        [DisplayName("QK")]
        public string QK
        {
            get { return _QK;}
            set { _QK = value; }
        }

        //录井项目部
        [DisplayName("LJFGS")]
        public string LJFGS
        {
            get{return _LJFGS;}
            set { _LJFGS = value; }
        }

        //编制人
        [DisplayName("BZR")]
        public string BZR
        {
            get{ return _BZR; }
            set { _BZR = value; }
        }

        //编制日期
        [DisplayName("BZRQ")]
        public DateTime BZRQ
        {
            get{ return _BZRQ; }
            set { _BZRQ = value; }
        }

        //添加人
        [DisplayName("TJR")]
        public string TJR
        {
            get{ return _TJR; }
            set { _TJR = value; }
        }

        //添加时间
        [DisplayName("TJSJ")]
        public DateTime TJSJ
        {
            get {return _TJSJ;}
            set { _TJSJ = value; }
        }

        //备注
        [DisplayName("BZ")]
        public string BZ
        {
            get { return _BZ; }
            set { _BZ = value; }
        }

        public string BZRQ_DG
        {
            get
            {
                return _BZRQ_DG;
            }

            set
            {
                _BZRQ_DG = value;
            }
        }

        private List<LQ_FILE> _DJCHList;
        public List<LQ_FILE> DJCHList
        {
            get { return _DJCHList; }
            set { _DJCHList = value; }
        }
        private List<LQ_FILE> _YJYAList;
        public List<LQ_FILE> YJYAList
        {
            get { return _YJYAList; }
            set { _YJYAList = value; }
        }

        private List<LQ_FILE> _QSHEList;
        public List<LQ_FILE> QSHEList
        {
            get { return _QSHEList; }
            set { _QSHEList = value; }
        }
    }
}
