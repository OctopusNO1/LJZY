using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LJZY.MODEL
{
	public class LQ_DJSJ
	{
		/// <summary>
		/// 默认构造方法
		/// </summary>
		public LQ_DJSJ()
		{ 
            //_SJRQ = DateTime.Now;
            //_SPRQ = DateTime.Now;
            _ISLATESTRECORD = 0;
            _ISISFINISH = 0;

        }
		private string _ZJH;
		/// <summary>
		/// 井号
		/// </summary>
		[DisplayName("ZJH")]
		public string ZJH
		{
			get { return _ZJH; }
			set { _ZJH = value; }
		}

		private int _XH;
		/// <summary>
		/// 序号
		/// </summary>
		[DisplayName("XH")]
		public int XH
		{
			get { return _XH; }
			set { _XH = value; }
		}

		private int _TROW;
		/// <summary>
		/// 排序号
		/// </summary>
		[DisplayName("TROW")]
		public int TROW
		{
			get { return _TROW; }
			set { _TROW = value; }
		}

		private string _SC3;
		/// <summary>
		/// 甲方单位
		/// </summary>
		[DisplayName("SC3")]
		public string SC3
		{
			get { return _SC3; }
			set { _SC3 = value; }
		}

		private string _SC2;
		/// <summary>
		/// 地区
		/// </summary>
		[DisplayName("SC2")]
		public string SC2
		{
			get { return _SC2; }
			set { _SC2 = value; }
		}

		private string _QK;
		/// <summary>
		/// 区块
		/// </summary>
		[DisplayName("QK")]
		public string QK
		{
			get { return _QK; }
			set { _QK = value; }
		}

		private string _REPORT_TYPE;
		/// <summary>
		/// 井别
		/// </summary>
		[DisplayName("REPORT_TYPE")]
		public string REPORT_TYPE
        {
			get { return _REPORT_TYPE; }
			set { _REPORT_TYPE = value; }
		}

		private string _JX;
		/// <summary>
		/// 井型
		/// </summary>
		[DisplayName("JX")]
		public string JX
		{
			get { return _JX; }
			set { _JX = value; }
		}

		private string _JH;
		/// <summary>
		/// 井筒号
		/// </summary>
		[DisplayName("JH")]
		public string JH
		{
			get { return _JH; }
			set { _JH = value; }
		}

		private string _LJXL;
		/// <summary>
		/// 录井系列
		/// </summary>
		[DisplayName("LJXL")]
		public string LJXL
		{
			get { return _LJXL; }
			set { _LJXL = value; }
		}

		private Decimal _SJJS;
		/// <summary>
		/// 设计井深
		/// </summary>
		[DisplayName("SJJS")]
		public Decimal SJJS
		{
			get { return _SJJS; }
			set { _SJJS = value; }
		}

		private Decimal _JSSJJS;
		/// <summary>
		/// 加深设计井深
		/// </summary>
		[DisplayName("JSSJJS")]
		public Decimal JSSJJS
		{
			get { return _JSSJJS; }
			set { _JSSJJS = value; }
		}

		private Decimal _WZJS;
		/// <summary>
		///  完钻井深
		/// </summary>
		[DisplayName("WZJS")]
		public Decimal WZJS
		{
			get { return _WZJS; }
			set { _WZJS = value; }
		}

		private string _DLWZ;
		/// <summary>
		/// 地理位置
		/// </summary>
		[DisplayName("DLWZ")]
		public string DLWZ
		{
			get { return _DLWZ; }
			set { _DLWZ = value; }
		}

		private string _GZWZ;
		/// <summary>
		/// 构造位置
		/// </summary>
		[DisplayName("GZWZ")]
		public string GZWZ
		{
			get { return _GZWZ; }
			set { _GZWZ = value; }
		}

		private string _CXWZ;
		/// <summary>
		/// 测线位置
		/// </summary>
		[DisplayName("CXWZ")]
		public string CXWZ
		{
			get { return _CXWZ; }
			set { _CXWZ = value; }
		}

		private Decimal _SJZZBB;
		/// <summary>
		/// 设计纵坐标（北京）
		/// </summary>
		[DisplayName("SJZZBB")]
		public Decimal SJZZBB
		{
			get { return _SJZZBB; }
			set { _SJZZBB = value; }
		}

		private Decimal _SJHZBB;
		/// <summary>
		/// 设计横坐标（北京）
		/// </summary>
		[DisplayName("SJHZBB")]
		public Decimal SJHZBB
		{
			get { return _SJHZBB; }
			set { _SJHZBB = value; }
		}

		private Decimal _SJZZBX;
		/// <summary>
		/// 设计纵坐标（西安）
		/// </summary>
		[DisplayName("SJZZBX")]
		public Decimal SJZZBX
		{
			get { return _SJZZBX; }
			set { _SJZZBX = value; }
		}

		private Decimal _SJHZBX;
		/// <summary>
		/// 设计横坐标（西安）
		/// </summary>
		[DisplayName("SJHZBX")]
		public Decimal SJHZBX
		{
			get { return _SJHZBX; }
			set { _SJHZBX = value; }
		}

		private Decimal _SJZZB;
		/// <summary>
		/// 实测纵坐标
		/// </summary>
		[DisplayName("SJZZB")]
		public Decimal SJZZB
		{
			get { return _SJZZB; }
			set { _SJZZB = value; }
		}
		private Decimal _SJHZB;
		/// <summary>
		/// 实测横坐标
		/// </summary>
		[DisplayName("SJHZB")]
		public Decimal SJHZB
        {
			get { return _SJHZB; }
			set { _SJHZB = value; }
		}
		private Decimal _DMHB;
		/// <summary>
		/// 地面海拔
		/// </summary>
		[DisplayName("DMHB")]
		public Decimal DMHB
		{
			get { return _DMHB; }
			set { _DMHB = value; }
		}
		private Decimal _BXG;
		/// <summary>
		/// 补心高
		/// </summary>
		[DisplayName("BXG")]
		public Decimal BXG
		{
			get { return _BXG; }
			set { _BXG = value; }
		}
		private string _ZYMDC;
		/// <summary>
		/// 目的层
		/// </summary>
		[DisplayName("ZYMDC")]
		public string ZYMDC
		{
			get { return _ZYMDC; }
			set { _ZYMDC = value; }
		}
		private string _SJR;
		/// <summary>
		/// 设计人
		/// </summary>
		[DisplayName("SJR")]
		public string SJR
		{
			get { return _SJR; }
			set { _SJR = value; }
		}
		private string _SPR;
		/// <summary>
		/// 审批人
		/// </summary>
		[DisplayName("SPR")]
		public string SPR
		{
			get { return _SPR; }
			set { _SPR = value; }
		}
		private string  _SJRQ;
		/// <summary>
		/// 设计日期
		/// </summary>
		[DisplayName("SJRQ")]
		public string SJRQ
		{
			get { return _SJRQ; }
			set { _SJRQ = value; }
		}

        private DateTime? _SJRQ_date;

        public DateTime? SJRQ_date
        {
            get { return _SJRQ_date; }
            set { _SJRQ_date = value; }
        }

        private DateTime? _SPRQ_date;

        public DateTime? SPRQ_date
        {
            get { return _SPRQ_date; }
            set { _SPRQ_date = value; }
        }

        private string _SJRQ_DG;
		/// <summary>
		/// 设计日期(表格)
		/// </summary>
		[DisplayName("SJRQ_DG")]
		public string SJRQ_DG
		{
			get { return _SJRQ_DG; }
			set { _SJRQ_DG = value; }
		}

		private string _TJR;
		/// <summary>
		/// 添加人
		/// </summary>
		[DisplayName("TJR")]
		public string TJR
		{
			get { return _TJR; }
			set { _TJR = value; }
		}
		private DateTime _BCRQ;
		/// <summary>
		/// 添加时间
		/// </summary>
		[DisplayName( "BCRQ" )]
		public DateTime BCRQ
        {
			get { return _BCRQ; }
			set { _BCRQ = value; }
		}
		private string _BZ;
		/// <summary>
		///  备注
		/// </summary>
		[DisplayName("BZ")]
		public string BZ
		{
			get { return _BZ; }
			set { _BZ = value; }
		}

		private string _LJFGS;
		/// <summary>
		/// 录井项目部
		/// </summary>
		[DisplayName("LJFGS")]
		public string LJFGS
		{
			get { return _LJFGS; }
			set { _LJFGS = value; }
		}

		private string _SPRQ;
		/// <summary>
		/// 审批日期
		/// </summary>
		[DisplayName("SPRQ")]
		public string SPRQ
		{
			get { return _SPRQ; }
			set { _SPRQ = value; }
		}

		private string _SPRQ_DG;
		/// <summary>
		/// 审批日期(表格)
		/// </summary>
		[DisplayName("SPRQ_DG")]
		public string SPRQ_DG
		{
			get { return _SPRQ_DG; }
			set { _SPRQ_DG = value; }
		}

		private string _ND;
		/// <summary>
		/// 年度
		/// </summary>
		[DisplayName("ND")]
		public string ND
		{
			get { return _ND; }
			set { _ND = value; }
		}

        private int _ISLATESTRECORD;
        /// <summary>
        /// 是否派工(0;否,1:是)
        /// </summary>
        [DisplayName ( "ISLATESTRECORD" )]
        public int ISLATESTRECORD
        {
            get { return _ISLATESTRECORD; }
            set { _ISLATESTRECORD = value; }
        }


        private int _ISISFINISH;
        /// <summary>
        /// 是否派工完成(0;否,1:是)
        /// </summary>
        [DisplayName("ISFINISH")]
        public int ISFINISH
        {
            get { return _ISISFINISH; }
            set { _ISISFINISH = value; }
        }
        private List<LQ_FILE> _JWSJList;
		[DisplayName("JWSJList")]
		public List<LQ_FILE> JWSJList
		{
			get { return _JWSJList; }
			set { _JWSJList = value; }
		}
		private List<LQ_FILE> _ZJDZSJList;
		[DisplayName("ZJDZSJList")]
		public List<LQ_FILE> ZJDZSJList
		{
			get { return _ZJDZSJList; }
			set { _ZJDZSJList = value; }
		}
		private List<LQ_FILE> _ZJGCSJList;
		[DisplayName("ZJGCSJList")]
		public List<LQ_FILE> ZJGCSJList
		{
			get { return _ZJGCSJList; }
			set { _ZJGCSJList = value; }
		}
		private List<LQ_FILE> _SJTLDMTList;
		[DisplayName("SJTLDMTList")]
		public List<LQ_FILE> SJTLDMTList
		{
			get { return _SJTLDMTList; }
			set { _SJTLDMTList = value; }
		}

        /// <summary>
        /// 主键ID
        /// </summary>
        [DisplayName ( "ID" )]
        public string ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID =  value ;
            }
        }

        private string _ID;


    }
}
