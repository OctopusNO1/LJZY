using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
	public class LQ_LJXM
	{
		public LQ_LJXM()
		{
             
        }

        private string _STARSTART_DG;
        private string _STAREND_DG;
        private string _YJBASJ_DG;
        private string _SJBASJ_DG;
        private string _HQSJ_DG;


        private int _TROW;
		/// <summary>
		/// 排序序号
		/// </summary>
		[DisplayName("TROW")]
		public int TROW
		{
			get { return _TROW; }
			set { _TROW = value; }
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

		private Int32 _XH;
		/// <summary>
		/// 序号
		/// </summary>
		[DisplayName("XH")]
		public int XH
		{
			get { return _XH; }
			set { _XH = value; }
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

		private decimal _SJJS;
		/// <summary>
		/// 设计井深
		/// </summary>
		[DisplayName("SJJS")]
		public decimal SJJS
		{
			get { return _SJJS; }
			set { _SJJS = value; }
		}

		private decimal _JSSJJS;
		/// <summary>
		/// 加深设计井深
		/// </summary>
		[DisplayName("JSSJJS")]
		public decimal JSSJJS
		{
			get { return _JSSJJS; }
			set { _JSSJJS = value; }
		}

		private string _SCFL;
		/// <summary>
		/// 市场类型
		/// </summary>
		[DisplayName("SCFL")]
		public string SCFL
		{
			get { return _SCFL; }
			set { _SCFL = value; }
		}

		private string _GJ;
		/// <summary>
		/// 国家
		/// </summary>
		[DisplayName("GJ")]
		public string GJ
		{
			get { return _GJ; }
			set { _GJ = value; }
		}

		private string _SC1;
		/// <summary>
		/// 一级市场
		/// </summary>
		[DisplayName("SC1")]
		public string SC1
		{
			get { return _SC1; }
			set { _SC1 = value; }
		}

		private string _DZJDXM;
		/// <summary>
		/// 地质监督姓名
		/// </summary>
		[DisplayName("DZJDXM")]
		public string DZJDXM
		{
			get { return _DZJDXM; }
			set { _DZJDXM = value; }
		}

		private string _DZJDZJH;
		/// <summary>
		/// 地质监督证件号
		/// </summary>
		[DisplayName("DZJDZJH")]
		public string DZJDZJH
		{
			get { return _DZJDZJH; }
			set { _DZJDZJH = value; }
		}

		private string _DZJDSSGS;
		/// <summary>
		/// 地质监督所属公司
		/// </summary>
		[DisplayName("DZJDSSGS")]
		public string DZJDSSGS
		{
			get { return _DZJDSSGS; }
			set { _DZJDSSGS = value; }
		}

		private string _ZJJDXM;
		/// <summary>
		/// 钻井监督姓名
		/// </summary>
		[DisplayName("ZJJDXM")]
		public string ZJJDXM
		{
			get { return _ZJJDXM; }
			set { _ZJJDXM = value; }
		}

		private string _ZJJDZJH;
		/// <summary>
		/// 钻井监督证件号
		/// </summary>
		[DisplayName("ZJJDZJH")]
		public string ZJJDZJH
		{
			get { return _ZJJDZJH; }
			set { _ZJJDZJH = value; }
		}

		private string _ZJJDSSGS;
		/// <summary>
		/// 钻井监督所属公司
		/// </summary>
		[DisplayName("ZJJDSSGS")]
		public string ZJJDSSGS
		{
			get { return _ZJJDSSGS; }
			set { _ZJJDSSGS = value; }
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

		private string _LJDWZZ;
		/// <summary>
		/// 录井资质
		/// </summary>
		[DisplayName("LJDWZZ")]
		public string LJDWZZ
		{
			get { return _LJDWZZ; }
			set { _LJDWZZ = value; }
		}

		private string _LJDH;
		/// <summary>
		/// 录井队号
		/// </summary>
		[DisplayName("LJDH")]
		public string LJDH
		{
			get { return _LJDH; }
			set { _LJDH = value; }
		}

		private string _LJYQXH;
		/// <summary>
		/// 设备型号
		/// </summary>
		[DisplayName("LJYQXH")]
		public string LJYQXH
		{
			get { return _LJYQXH; }
			set { _LJYQXH = value; }
		}

		private string _YQZZ;
		/// <summary>
		/// 仪器资质
		/// </summary>
		[DisplayName("YQZZ")]
		public string YQZZ
		{
			get { return _YQZZ; }
			set { _YQZZ = value; }
		}

		private string _DWZBH;
		/// <summary>
		/// 队伍自编号
		/// </summary>
		[DisplayName("DWZBH")]
		public string DWZBH
		{
			get { return _DWZBH; }
			set { _DWZBH = value; }
		}

		private string _DZS;
		/// <summary>
		/// 地质师
		/// </summary>
		[DisplayName("DZS")]
		public string DZS
		{
			get { return _DZS; }
			set { _DZS = value; }
		}

		private DateTime _STARSTART;
		/// <summary>
		/// 装卫星时间
		/// </summary>
		[DisplayName("STARSTART")]
		public DateTime STARSTART
		{
			get { return _STARSTART; }
			set { _STARSTART = value; }
		}



        private string _STARAZR;
		/// <summary>
		/// 安装卫星人
		/// </summary>
		[DisplayName("STARAZR")]
		public string STARAZR
		{
			get { return _STARAZR; }
			set { _STARAZR = value; }
		}

		private DateTime _STAREND;
		/// <summary>
		/// 拆卫星时间	
		/// </summary>
		[DisplayName("STAREND")]
		public DateTime STAREND
		{
			get { return _STAREND; }
			set { _STAREND = value; }
		}


        private string _STARCCR;
		/// <summary>
		/// 拆卫星人
		/// </summary>
		[DisplayName("STARCCR")]
		public string STARCCR
		{
			get { return _STARCCR; }
			set { _STARCCR = value; }
		}

		private string _SGDW;
		/// <summary>
		/// 施工单位
		/// </summary>
		[DisplayName("SGDW")]
		public string SGDW
		{
			get { return _SGDW; }
			set { _SGDW = value; }
		}

		private string _SGDH;
		/// <summary>
		/// 施工队号
		/// </summary>
		[DisplayName("SGDH")]
		public string SGDH
		{
			get { return _SGDH; }
			set { _SGDH = value; }
		}

		private DateTime _YJBASJ;
		/// <summary>
		/// 预计搬安时间
		/// </summary>
		[DisplayName("YJBASJ")]
		public DateTime YJBASJ
		{
			get { return _YJBASJ; }
			set { _YJBASJ = value; }
		}



        private DateTime _SJBASJ;
		/// <summary>
		/// 实际搬安时间
		/// </summary>
		[DisplayName("SJBASJ")]
		public DateTime SJBASJ
		{
			get { return _SJBASJ; }
			set { _SJBASJ = value; }
		}


        private Decimal _BQJL;
		/// <summary>
		/// 搬迁距离
		/// </summary>
		[DisplayName("BQJL")]
		public Decimal BQJL
		{
			get { return _BQJL; }
			set { _BQJL = value; }
		}

		private DateTime _HQSJ;
		/// <summary>
		/// 回迁时间
		/// </summary>
		[DisplayName("HQSJ")]
		public DateTime HQSJ
		{
			get { return _HQSJ; }
			set { _HQSJ = value; }
		}

		private string _DQZT;
		/// <summary>
		/// 当前状态
		/// </summary>
		[DisplayName("DQZT")]
		public string DQZT
		{
			get { return _DQZT; }
			set { _DQZT = value; }
		}

		private string _CHOUXIYOU;
		/// <summary>
		/// 稠油/稀油
		/// </summary>
		[DisplayName("CHOUXIYOU")]
		public string CHOUXIYOU
		{
			get { return _CHOUXIYOU; }
			set { _CHOUXIYOU = value; }
		}

		private string _HXJW;
		/// <summary>
		/// 后续井位
		/// </summary>
		[DisplayName("HXJW")]
		public string HXJW
		{
			get { return _HXJW; }
			set { _HXJW = value; }
		}

		private string _HXJDH;
		/// <summary>
		/// 后续井队号
		/// </summary>
		[DisplayName("HXJDH")]
		public string HXJDH
		{
			get { return _HXJDH; }
			set { _HXJDH = value; }
		}

		private string _JDDT;
		/// <summary>
		/// 井队动态
		/// </summary>
		[DisplayName("JDDT")]
		public string JDDT
		{
			get { return _JDDT; }
			set { _JDDT = value; }
		}

		private string _LSDW;
		/// <summary>
		/// 隶属单位
		/// </summary>
		[DisplayName("LSDW")]
		public string LSDW
		{
			get { return _LSDW; }
			set { _LSDW = value; }
		}

		private string _XMBJWXX;
		/// <summary>
		/// 项目部井位信息
		/// </summary>
		[DisplayName("XMBJWXX")]
		public string XMBJWXX
		{
			get { return _XMBJWXX; }
			set { _XMBJWXX = value; }
		}

		private string _PGZDTS;
		/// <summary>
		/// 派工重点提示	
		/// </summary>
		[DisplayName("PGZDTS")]
		public string PGZDTS
		{
			get { return _PGZDTS; }
			set { _PGZDTS = value; }
		}

		private string _BZ;
		/// <summary>
		/// 备注
		/// </summary>
		[DisplayName("BZ")]
		public string BZ
		{
			get { return _BZ; }
			set { _BZ = value; }
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

		private DateTime _TJRQ;
		/// <summary>
		/// 添加时间
		/// </summary>
		[DisplayName("TJRQ")]
		public DateTime TJRQ
		{
			get { return _TJRQ; }
			set { _TJRQ = value; }
		}
        /// <summary>
        /// 当前井深
        /// </summary>
        private decimal _DRJS;
        [DisplayName ( "DRJS" )]
        public decimal DRJS
        {
            get { return _DRJS; }
            set { _DRJS = value; }
        }
        /// <summary>
        /// 当前动态
        /// </summary>
        private string _SGZT;
        [DisplayName ( "SGZT" )]
        public string SGZT
        {
            get { return _SGZT; }
            set { _SGZT = value; }
        }

        /// <summary>
        /// 当前动态
        /// </summary>
        private string _ID;
        [DisplayName ( "ID" )]
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string HQSJ_DG
        {
            get
            {
                return _HQSJ_DG;
            }

            set
            {
                _HQSJ_DG =  value ;
            }
        }

        public string SJBASJ_DG
        {
            get
            {
                return _SJBASJ_DG;
            }

            set
            {
                _SJBASJ_DG =  value ;
            }
        }

        public string YJBASJ_DG
        {
            get
            {
                return _YJBASJ_DG;
            }

            set
            {
                _YJBASJ_DG =  value ;
            }
        }

        public string STAREND_DG
        {
            get
            {
                return _STAREND_DG;
            }

            set
            {
                _STAREND_DG =  value ;
            }
        }

        public string STARSTART_DG
        {
            get
            {
                return _STARSTART_DG;
            }

            set
            {
                _STARSTART_DG =  value ;
            }
        }
        /// <summary>
        /// 辖区项目部
        /// </summary>
        public string XQXMB
        {
            get
            {
                return _XQXMB;
            }

            set
            {
                _XQXMB =  value ;
            }
        }

        /// <summary>
        /// 预计完井日期
        /// </summary>
        public string YJWJRQ
        {
            get
            {
                return _YJWJRQ;
            }

            set
            {
                _YJWJRQ =  value ;
            }
        }

        
        private string _XQXMB;

        private string _YJWJRQ;

        
    }
}
