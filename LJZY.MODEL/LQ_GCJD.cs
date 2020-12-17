using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class LQ_GCJD
    {
        public LQ_GCJD()
        {
            //_DZLJKSSJ = DateTime.Now;
            //_YXLJKSSJ = DateTime.Now;
            //_QCLJKSSJ = DateTime.Now;
            //_ZHLJKSSJ = DateTime.Now;
            //_KZRQ = DateTime.Now;
            //_WZRQ = DateTime.Now;
            //_GJRQ = DateTime.Now;
            //_GCFZCLSJ = DateTime.Now;
            //_STARSTART = DateTime.Now;
            //_STAREND = DateTime.Now;
            //_CZKSSJ = DateTime.Now;
            //_CZJSSJ = DateTime.Now;
            //_ZTKSSJ = DateTime.Now;
            //_ZTJSSJ = DateTime.Now;
            //_WJRQ = DateTime.Now;
        }

        private string _DZLJKSSJ_DG;
        private string _YXLJKSSJ_DG;
        private string _QCLJKSSJ_DG;
        private string _ZHLJKSSJ_DG;
        private string _KZRQ_DG;
        private string _WZRQ_DG;
        private string _GJRQ_DG;
        private string _GCFZCLSJ_DG;
        private string _STARSTART_DG;
        private string _STAREND_DG;
        private string _WJRQ_DG;
        private string _ND;

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

        private string _ZJH;
        /// <summary>
        /// 井号
        /// </summary>
        [DisplayName ( "ZJH" )]
        public string ZJH
        {
            get { return _ZJH; }
            set { _ZJH = value; }
        }

        //private Int32 _XH;
        ///// <summary>
        ///// 序号
        ///// </summary>
        //[DisplayName("XH")]
        //public int XH
        //{
        //	get { return _XH; }
        //	set { _XH = value; }
        //}

        private string _SC3;
        /// <summary>
        /// 甲方单位
        /// </summary>
        [DisplayName ( "SC3" )]
        public string SC3
        {
            get { return _SC3; }
            set { _SC3 = value; }
        }

        private string _SC2;
        /// <summary>
        /// 地区
        /// </summary>
        [DisplayName ( "SC2" )]
        public string SC2
        {
            get { return _SC2; }
            set { _SC2 = value; }
        }

        private string _QK;
        /// <summary>
        /// 区块
        /// </summary>
        [DisplayName ( "QK" )]
        public string QK
        {
            get { return _QK; }
            set { _QK = value; }
        }

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

        private string _JX;
        /// <summary>
        /// 井型
        /// </summary>
        [DisplayName ( "JX" )]
        public string JX
        {
            get { return _JX; }
            set { _JX = value; }
        }

        private string _JH;
        /// <summary>
        /// 井筒号
        /// </summary>
        [DisplayName ( "JH" )]
        public string JH
        {
            get { return _JH; }
            set { _JH = value; }
        }

        private string _LJXL;
        /// <summary>
        /// 录井系列
        /// </summary>
        [DisplayName ( "LJXL" )]
        public string LJXL
        {
            get { return _LJXL; }
            set { _LJXL = value; }
        }
        private decimal _DZLJKSJS;
        /// <summary>
        /// 地质录井开始井深
        /// </summary>
        [DisplayName ( "DZLJKSJS" )]
        public decimal DZLJKSJS
        {
            get { return _DZLJKSJS; }
            set { _DZLJKSJS = value; }
        }

        private DateTime? _DZLJKSSJ;
        /// <summary>
        /// 地质录井开始时间
        /// </summary>
        [DisplayName ( "DZLJKSSJ" )]
        public DateTime? DZLJKSSJ
        {
            get { return _DZLJKSSJ; }
            set { _DZLJKSSJ = value; }
        }

        private string  _DZLJKSSJ_Str;
        /// <summary>
        /// 地质录井开始时间
        /// </summary>
        [DisplayName("DZLJKSSJ_Str")]
        public string DZLJKSSJ_Str
        {
            get { return _DZLJKSSJ_Str; }
            set { _DZLJKSSJ_Str = value; }
        }

        private decimal _YXLJKSJS;
        /// <summary>
        /// 岩屑录井开始井深
        /// </summary>
        [DisplayName ( "YXLJKSJS" )]
        public decimal YXLJKSJS
        {
            get { return _YXLJKSJS; }
            set { _YXLJKSJS = value; }
        }

        private DateTime? _YXLJKSSJ;
        /// <summary>
        /// 岩屑录井开始时间
        /// </summary>
        [DisplayName ( "YXLJKSSJ" )]
        public DateTime? YXLJKSSJ
        {
            get { return _YXLJKSSJ; }
            set { _YXLJKSSJ = value; }
        }

        private string _YXLJKSSJ_Str;
        /// <summary>
        /// 岩屑录井开始时间
        /// </summary>
        [DisplayName("YXLJKSSJ_Str")]
        public string YXLJKSSJ_Str
        {
            get { return _YXLJKSSJ_Str; }
            set { _YXLJKSSJ_Str = value; }
        }


        private decimal _QCLJKSJS;
        /// <summary>
        /// 气测录井开始井深
        /// </summary>
        [DisplayName ( "QCLJKSJS" )]
        public decimal QCLJKSJS
        {
            get { return _QCLJKSJS; }
            set { _QCLJKSJS = value; }
        }

        private DateTime? _QCLJKSSJ;
        /// <summary>
        /// 气测录井开始时间
        /// </summary>
        [DisplayName ( "QCLJKSSJ" )]
        public DateTime? QCLJKSSJ
        {
            get { return _QCLJKSSJ; }
            set { _QCLJKSSJ = value; }
        }


        private string _QCLJKSSJ_Str;
        /// <summary>
        /// 气测录井开始时间
        /// </summary>
        [DisplayName("QCLJKSSJ_Str")]
        public string QCLJKSSJ_Str
        {
            get { return _QCLJKSSJ_Str; }
            set { _QCLJKSSJ_Str = value; }
        }



        private decimal _ZHLJKSJS;
        /// <summary>
        /// 综合录井开始井深
        /// </summary>
        [DisplayName ( "ZHLJKSJS" )]
        public decimal ZHLJKSJS
        {
            get { return _ZHLJKSJS; }
            set { _ZHLJKSJS = value; }
        }

        private DateTime? _ZHLJKSSJ;
        /// <summary>
        /// 综合录井开始时间
        /// </summary>
        [DisplayName ( "ZHLJKSSJ" )]
        public DateTime? ZHLJKSSJ
        {
            get { return _ZHLJKSSJ; }
            set { _ZHLJKSSJ = value; }
        }


        private string  _ZHLJKSSJ_Str;
        /// <summary>
        /// 综合录井开始时间
        /// </summary>
        [DisplayName("ZHLJKSSJ_Str")]
        public string ZHLJKSSJ_Str
        {
            get { return _ZHLJKSSJ_Str; }
            set { _ZHLJKSSJ_Str = value; }
        }



        private decimal _SJJS;
        /// <summary>
        /// 设计井深
        /// </summary>
        [DisplayName ( "SJJS" )]
        public decimal SJJS
        {
            get { return _SJJS; }
            set { _SJJS = value; }
        }

        private decimal _JSSJJS;
        /// <summary>
        /// 加深设计井深
        /// </summary>
        [DisplayName ( "JSSJJS" )]
        public decimal JSSJJS
        {
            get { return _JSSJJS; }
            set { _JSSJJS = value; }
        }

        private decimal _WZJS;
        /// <summary>
        /// 完钻井深
        /// </summary>
        [DisplayName ( "WZJS" )]
        public decimal WZJS
        {
            get { return _WZJS; }
            set { _WZJS = value; }
        }

        private Decimal _SJZZB;
        /// <summary>
        /// 实测纵坐标
        /// </summary>
        [DisplayName ( "SJZZB" )]
        public Decimal SJZZB
        {
            get { return _SJZZB; }
            set { _SJZZB = value; }
        }
        private Decimal _SJHZB;
        /// <summary>
        /// 实测横坐标
        /// </summary>
        [DisplayName ( "SJHZB" )]
        public Decimal SJHZB
        {
            get { return _SJHZB; }
            set { _SJHZB = value; }
        }

        private Decimal _DMHB;
        /// <summary>
        /// 地面海拔
        /// </summary>
        [DisplayName ( "DMHB" )]
        public Decimal DMHB
        {
            get { return _DMHB; }
            set { _DMHB = value; }
        }
        private Decimal _BXG;
        /// <summary>
        /// 补心高
        /// </summary>
        [DisplayName ( "BXG" )]
        public Decimal BXG
        {
            get { return _BXG; }
            set { _BXG = value; }
        }

        private string _SGDW;
        /// <summary>
        /// 施工单位
        /// </summary>
        [DisplayName ( "SGDW" )]
        public string SGDW
        {
            get { return _SGDW; }
            set { _SGDW = value; }
        }

        private string _SGDH;
        /// <summary>
        /// 施工队号
        /// </summary>
        [DisplayName ( "SGDH" )]
        public string SGDH
        {
            get { return _SGDH; }
            set { _SGDH = value; }
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

        private string _LJDH;
        /// <summary>
        /// 录井队号
        /// </summary>
        [DisplayName ( "LJDH" )]
        public string LJDH
        {
            get { return _LJDH; }
            set { _LJDH = value; }
        }

        private string _LJYQXH;
        /// <summary>
        /// 设备型号
        /// </summary>
        [DisplayName ( "LJYQXH" )]
        public string LJYQXH
        {
            get { return _LJYQXH; }
            set { _LJYQXH = value; }
        }

        private DateTime? _KZRQ;
        /// <summary>
        /// 开钻日期
        /// </summary>
        [DisplayName ( "KZRQ" )]
        public DateTime? KZRQ
        {
            get { return _KZRQ; }
            set { _KZRQ = value; }
        }

        private string _KZRQ_Str;

        [DisplayName("KZRQ_Str")]
        public string KZRQ_Str
        {
            get { return _KZRQ_Str; }
            set { _KZRQ_Str = value; }
        }


        private DateTime? _WZRQ;
        /// <summary>
        /// 完钻日期
        /// </summary>
        [DisplayName ( "WZRQ" )]
        public DateTime? WZRQ
        {
            get { return _WZRQ; }
            set { _WZRQ = value; }
        }

        private string _WZRQ_Str;
        /// <summary>
        /// 完钻日期
        /// </summary>
        [DisplayName("WZRQ_Str")]
        public string WZRQ_Str
        {
            get { return _WZRQ_Str; }
            set { _WZRQ_Str = value; }
        }



        private DateTime? _GJRQ;
        /// <summary>
        /// 固井日期
        /// </summary>
        [DisplayName ( "GJRQ" )]
        public DateTime? GJRQ
        {
            get { return _GJRQ; }
            set { _GJRQ = value; }
        }


        private string _GJRQ_Str;
        /// <summary>
        /// 固井日期
        /// </summary>
        [DisplayName("GJRQ_Str")]
        public string GJRQ_Str
        {
            get { return _GJRQ_Str; }
            set { _GJRQ_Str = value; }
        }


        private DateTime? _WJRQ;
        /// <summary>
        /// 完井日期
        /// </summary>
        [DisplayName ( "WJRQ" )]
        public DateTime? WJRQ
        {
            get { return _WJRQ; }
            set { _WJRQ = value; }
        }


        private string _WJRQ_Str;
        /// <summary>
        /// 完井日期
        /// </summary>
        [DisplayName("WJRQ_Str")]
        public string WJRQ_Str
        {
            get { return _WJRQ_Str; }
            set { _WJRQ_Str = value; }
        }



        private string _ZYMDC;
        /// <summary>
        /// 主要目的层
        /// </summary>
        [DisplayName ( "ZYMDC" )]
        public string ZYMDC
        {
            get { return _ZYMDC; }
            set { _ZYMDC = value; }
        }

        private string _WZCW;
        /// <summary>
        /// 完钻层位
        /// </summary>
        [DisplayName ( "WZCW" )]
        public string WZCW
        {
            get { return _WZCW; }
            set { _WZCW = value; }
        }

        private string _WJFF;
        /// <summary>
        /// 完井方法
        /// </summary>
        [DisplayName ( "WJFF" )]
        public string WJFF
        {
            get { return _WJFF; }
            set { _WJFF = value; }
        }

        private decimal _DYNZDJS;
        /// <summary>
        /// 分支点（第一年）井深
        /// </summary>
        [DisplayName ( "DYNZDJS" )]
        public decimal DYNZDJS
        {
            get { return _DYNZDJS; }
            set { _DYNZDJS = value; }
        }

        private decimal _DENZDJS;
        /// <summary>
        /// 第二年钻达井深
        /// </summary>
        [DisplayName ( "DENZDJS" )]
        public decimal DENZDJS
        {
            get { return _DENZDJS; }
            set { _DENZDJS = value; }
        }

        private string _SFJJYQXS;
        /// <summary>
        /// 是否见油气
        /// </summary>
        [DisplayName ( "SFJJYQXS" )]
        public string SFJJYQXS
        {
            get { return _SFJJYQXS; }
            set { _SFJJYQXS = value; }
        }

        private string _SFQX;
        /// <summary>
        /// 是否取心
        /// </summary>
        [DisplayName ( "SFQX" )]
        public string SFQX
        {
            get { return _SFQX; }
            set { _SFQX = value; }
        }

        private string _SFJSYQC;
        /// <summary>
        /// 解释油气层否
        /// </summary>
        [DisplayName ( "SFJSYQC" )]
        public string SFJSYQC
        {
            get { return _SFJSYQC; }
            set { _SFJSYQC = value; }
        }

        private string _SFCXGCFZ;
        /// <summary>
        /// 是否出现工程复杂
        /// </summary>
        [DisplayName ( "SFCXGCFZ" )]
        public string SFCXGCFZ
        {
            get { return _SFCXGCFZ; }
            set { _SFCXGCFZ = value; }
        }

        private string _CXGCFZLX;
        /// <summary>
        /// 出现工程复杂类型
        /// </summary>
        [DisplayName ( "CXGCFZLX" )]
        public string CXGCFZLX
        {
            get { return _CXGCFZLX; }
            set { _CXGCFZLX = value; }
        }

        private DateTime? _GCFZCLSJ;
        /// <summary>
        /// 工程复杂处理时间
        /// </summary>
        [DisplayName ( "GCFZCLSJ" )]
        public DateTime? GCFZCLSJ
        {
            get { return _GCFZCLSJ; }
            set { _GCFZCLSJ = value; }
        }


        private string  _GCFZCLSJ_Str;
        /// <summary>
        /// 工程复杂处理时间
        /// </summary>
        [DisplayName("GCFZCLSJ_Str")]
        public string GCFZCLSJ_Str
        {
            get { return _GCFZCLSJ_Str; }
            set { _GCFZCLSJ_Str = value; }
        }

        private string _SFXYCTG;
        /// <summary>
        /// 下油套否
        /// </summary>
        [DisplayName ( "SFXYCTG" )]
        public string SFXYCTG
        {
            get { return _SFXYCTG; }
            set { _SFXYCTG = value; }
        }

        private string _SJWZYZ;
        /// <summary>
        /// 设计完钻原则
        /// </summary>
        [DisplayName ( "SJWZYZ" )]
        public string SJWZYZ
        {
            get { return _SJWZYZ; }
            set { _SJWZYZ = value; }
        }

        private string _WZYJ;
        /// <summary>
        /// 完钻依据
        /// </summary>
        [DisplayName ( "WZYJ" )]
        public string WZYJ
        {
            get { return _WZYJ; }
            set { _WZYJ = value; }
        }

        private string _CZ;
        /// <summary>
        /// 侧钻
        /// </summary>
        [DisplayName ( "CZ" )]
        public string CZ
        {
            get { return _CZ; }
            set { _CZ = value; }
        }


        //private Decimal _CZKSLJJS1;
        ///// <summary>
        ///// 侧钻1开始录井井深
        ///// </summary>
        //[DisplayName ( "CZKSLJJS1" )]
        //public Decimal CZKSLJJS1
        //{
        //    get { return _CZKSLJJS1; }
        //    set { _CZKSLJJS1 = value; }
        //}

        //private DateTime _CZKSLJSJ1;
        ///// <summary>
        ///// 侧钻1开始录井时间
        ///// </summary>
        //[DisplayName ( "CZKSLJSJ1" )]
        //public DateTime CZKSLJSJ1
        //{
        //    get { return _CZKSLJSJ1; }
        //    set { _CZKSLJSJ1 = value; }
        //}

        //private Decimal _CZJSJS1;
        ///// <summary>
        ///// 侧钻1结束录井井深
        ///// </summary>
        //[DisplayName ( "CZJSJS1" )]
        //public Decimal CZJSJS1
        //{
        //    get { return _CZJSJS1; }
        //    set { _CZJSJS1 = value; }
        //}

        //private DateTime _CZJSSJ1;
        ///// <summary>
        ///// 侧钻1结束录井时间
        ///// </summary>
        //[DisplayName ( "CZJSSJ1" )]
        //public DateTime CZJSSJ1
        //{
        //    get { return _CZJSSJ1; }
        //    set { _CZJSSJ1 = value; }
        //}

        //private Decimal _CZKSLJJS2;
        ///// <summary>
        ///// 侧钻2开始录井井深
        ///// </summary>
        //[DisplayName ( "CZKSLJJS2" )]
        //public Decimal CZKSLJJS2
        //{
        //    get { return _CZKSLJJS2; }
        //    set { _CZKSLJJS2 = value; }
        //}

        //private DateTime _CZKSLJSJ2;
        ///// <summary>
        ///// 侧钻2开始录井时间
        ///// </summary>
        //[DisplayName ( "CZKSLJSJ2" )]
        //public DateTime CZKSLJSJ2
        //{
        //    get { return _CZKSLJSJ2; }
        //    set { _CZKSLJSJ2 = value; }
        //}

        //private Decimal _CZJSJS2;
        ///// <summary>
        ///// 侧钻2结束录井井深
        ///// </summary>
        //[DisplayName ( "CZJSJS2" )]
        //public Decimal CZJSJS2
        //{
        //    get { return _CZJSJS2; }
        //    set { _CZJSJS2 = value; }
        //}

        //private DateTime _CZJSSJ2;
        ///// <summary>
        ///// 侧钻2结束录井时间
        ///// </summary>
        //[DisplayName ( "CZJSSJ2" )]
        //public DateTime CZJSSJ2
        //{
        //    get { return _CZJSSJ2; }
        //    set { _CZJSSJ2 = value; }
        //}

        //private Decimal _CZKSLJJS3;
        ///// <summary>
        ///// 侧钻3开始录井井深
        ///// </summary>
        //[DisplayName ( "CZKSLJJS3" )]
        //public Decimal CZKSLJJS3
        //{
        //    get { return _CZKSLJJS3; }
        //    set { _CZKSLJJS3 = value; }
        //}

        //private DateTime _CZKSLJSJ3;
        ///// <summary>
        ///// 侧钻3开始录井时间
        ///// </summary>
        //[DisplayName ( "CZKSLJSJ3" )]
        //public DateTime CZKSLJSJ3
        //{
        //    get { return _CZKSLJSJ3; }
        //    set { _CZKSLJSJ3 = value; }
        //}

        //private Decimal _CZJSJS3;
        ///// <summary>
        ///// 侧钻3结束录井井深
        ///// </summary>
        //[DisplayName ( "CZJSJS3" )]
        //public Decimal CZJSJS3
        //{
        //    get { return _CZJSJS3; }
        //    set { _CZJSJS3 = value; }
        //}

        //private DateTime _CZJSSJ3;
        ///// <summary>
        ///// 侧钻3结束录井时间
        ///// </summary>
        //[DisplayName ( "CZJSSJ3" )]
        //public DateTime CZJSSJ3
        //{
        //    get { return _CZJSSJ3; }
        //    set { _CZJSSJ3 = value; }
        //}

        private string _SFBF;
        /// <summary>
        /// 是否报废
        /// </summary>
        [DisplayName ( "SFBF" )]
        public string SFBF
        {
            get { return _SFBF; }
            set { _SFBF = value; }
        }

        private string _BFLX;
        /// <summary>
        /// 报废类型
        /// </summary>
        [DisplayName ( "BFLX" )]
        public string BFLX
        {
            get { return _BFLX; }
            set { _BFLX = value; }
        }

        private DateTime? _STARSTART;
        /// <summary>
        /// 装卫星时间
        /// </summary>
        [DisplayName ( "STARSTART" )]
        public DateTime? STARSTART
        {
            get { return _STARSTART; }
            set { _STARSTART = value; }
        }

        private string _STARSTART_Str;
        /// <summary>
        /// 装卫星时间
        /// </summary>
        [DisplayName("STARSTART_Str")]
        public string STARSTART_Str
        {
            get { return _STARSTART_Str; }
            set { _STARSTART_Str = value; }
        }


        private DateTime? _STAREND;
        /// <summary>
        /// 拆卫星时间
        /// </summary>
        [DisplayName ( "STAREND" )]
        public DateTime? STAREND
        {
            get { return _STAREND; }
            set { _STAREND = value; }
        }


        private string _STAREND_Str;
        /// <summary>
        /// 拆卫星时间
        /// </summary>
        [DisplayName("STAREND_Str")]
        public string STAREND_Str
        {
            get { return _STAREND_Str; }
            set { _STAREND_Str = value; }
        }

        private string _ZTLX;
        /// <summary>
        /// 中停类型
        /// </summary>
        [DisplayName ( "ZTLX" )]
        public string ZTLX
        {
            get { return _ZTLX; }
            set { _ZTLX = value; }
        }

        private string _ZT;
        /// <summary>
        /// 中停
        /// </summary>
        [DisplayName ( "ZT" )]
        public string ZT
        {
            get { return _ZT; }
            set { _ZT = value; }
        }

        //private Decimal _ZT1JSSTART;
        ///// <summary>
        ///// 中停1开始录井井深
        ///// </summary>
        //[DisplayName("ZT1JSSTART")]
        //public Decimal ZT1JSSTART
        //{
        //	get { return _ZT1JSSTART; }
        //	set { _ZT1JSSTART = value; }
        //}

        //private DateTime _ZTSJ1;
        ///// <summary>
        ///// 中停1开始录井时间
        ///// </summary>
        //[DisplayName ( "ZTSJ1" )]
        //public DateTime ZTSJ1
        //{
        //    get { return _ZTSJ1; }
        //    set { _ZTSJ1 = value; }
        //}

        //private Decimal _ZT1JSEND;
        ///// <summary>
        ///// 中停1结束录井井深
        ///// </summary>
        //[DisplayName("ZT1JSEND")]
        //public Decimal ZT1JSEND
        //{
        //	get { return _ZT1JSEND; }
        //	set { _ZT1JSEND = value; }
        //}

        //private DateTime _ZTJSSJ1;
        ///// <summary>
        ///// 中停1结束录井时间
        ///// </summary>
        //[DisplayName ( "ZTJSSJ1" )]
        //public DateTime ZTJSSJ1
        //{
        //    get { return _ZTJSSJ1; }
        //    set { _ZTJSSJ1 = value; }
        //}

        //private Decimal _ZT2JSSTART;
        ///// <summary>
        ///// 中停2开始录井井深
        ///// </summary>
        //[DisplayName("ZT2JSSTART")]
        //public Decimal ZT2JSSTART
        //{
        //	get { return _ZT2JSSTART; }
        //	set { _ZT2JSSTART = value; }
        //}

        //private DateTime _ZTSJ2;
        ///// <summary>
        ///// 中停2开始录井时间
        ///// </summary>
        //[DisplayName ( "ZTSJ2" )]
        //public DateTime ZTSJ2
        //{
        //    get { return _ZTSJ2; }
        //    set { _ZTSJ2 = value; }
        //}

        //private Decimal _ZT2JSEND;
        ///// <summary>
        ///// 中停2结束录井井深
        ///// </summary>
        //[DisplayName("ZT2JSEND")]
        //public Decimal ZT2JSEND
        //{
        //	get { return _ZT2JSEND; }
        //	set { _ZT2JSEND = value; }
        //}

        //private DateTime _ZTJSSJ2;
        ///// <summary>
        ///// 中停2结束录井时间
        ///// </summary>
        //[DisplayName ( "ZTJSSJ2" )]
        //public DateTime ZTJSSJ2
        //{
        //    get { return _ZTJSSJ2; }
        //    set { _ZTJSSJ2 = value; }
        //}

        //private Decimal _ZT3JSSTART;
        ///// <summary>
        ///// 中停3开始录井井深
        ///// </summary>
        //[DisplayName("ZT3JSSTART")]
        //public Decimal ZT3JSSTART
        //{
        //	get { return _ZT3JSSTART; }
        //	set { _ZT3JSSTART = value; }
        //}

        //private DateTime _ZTSJ3;
        ///// <summary>
        ///// 中停3开始录井时间
        ///// </summary>
        //[DisplayName ( "ZTSJ3" )]
        //public DateTime ZTSJ3
        //{
        //    get { return _ZTSJ3; }
        //    set { _ZTSJ3 = value; }
        //}

        //private Decimal _ZT3JSEND;
        ///// <summary>
        ///// 中停3结束录井井深
        ///// </summary>
        //[DisplayName("ZT3JSEND")]
        //public Decimal ZT3JSEND
        //{
        //	get { return _ZT3JSEND; }
        //	set { _ZT3JSEND = value; }
        //}

        //private DateTime _ZTJSSJ3;
        ///// <summary>
        ///// 中停3结束录井时间
        ///// </summary>
        //[DisplayName ( "ZTJSSJ3" )]
        //public DateTime ZTJSSJ3
        //{
        //    get { return _ZTJSSJ3; }
        //    set { _ZTJSSJ3 = value; }
        //}

        private string _BZ;
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName ( "BZ" )]
        public string BZ
        {
            get { return _BZ; }
            set { _BZ = value; }
        }

        private string _TJR;
        /// <summary>
        /// 添加人
        /// </summary>
        [DisplayName ( "TJR" )]
        public string TJR
        {
            get { return _TJR; }
            set { _TJR = value; }
        }

        /// <summary>
        /// 当前动态
        /// </summary>
        [DisplayName ( "SGZT" )]
        public string SGZT
        {
            get
            {
                return _SGZT;
            }

            set
            {
                _SGZT = value;
            }
        }

        /// <summary>
        /// 当前井深
        /// </summary>
        [DisplayName ( "DRJS" )]
        public decimal DRJS
        {
            get
            {
                return _DRJS;
            }

            set
            {
                _DRJS = value;
            }
        }

        /// <summary>
        /// 侧钻名称
        /// </summary>
        [DisplayName ( "CZMC" )]
        public string CZMC
        {
            get
            {
                return _CZMC;
            }

            set
            {
                _CZMC = value;
            }
        }

        /// <summary>
        /// 侧钻结束井深
        /// </summary>
        [DisplayName ( "CZJSJS" )]
        public decimal CZJSJS
        {
            get
            {
                return _CZJSJS;
            }

            set
            {
                _CZJSJS = value;
            }
        }

        /// <summary>
        /// 侧钻结束时间
        /// </summary>
        [DisplayName ( "CZJSSJ" )]
        public DateTime? CZJSSJ
        {
            get
            {
                return _CZJSSJ;
            }

            set
            {
                _CZJSSJ = value;
            }
        }

        /// <summary>
        /// 侧钻开始井深
        /// </summary>
        [DisplayName ( "CZKSJS" )]
        public decimal CZKSJS
        {
            get
            {
                return _CZKSJS;
            }

            set
            {
                _CZKSJS = value;
            }
        }

        /// <summary>
        /// 侧钻开始时间
        /// </summary>
        [DisplayName ( "CZKSSJ" )]
        public DateTime? CZKSSJ
        {
            get
            {
                return _CZKSSJ;
            }

            set
            {
                _CZKSSJ = value;
            }
        }
        /// <summary>
        /// 中停结束时间
        /// </summary>
        [DisplayName ( "ZTJSSJ" )]
        public DateTime? ZTJSSJ
        {
            get
            {
                return _ZTJSSJ;
            }

            set
            {
                _ZTJSSJ = value;
            }
        }

        /// <summary>
        /// 中停开始时间
        /// </summary>
        [DisplayName ( "ZTKSSJ" )]
        public DateTime? ZTKSSJ
        {
            get
            {
                return _ZTKSSJ;
            }

            set
            {
                _ZTKSSJ = value;
            }
        }

        /// <summary>
        /// 中停名称
        /// </summary>
        [DisplayName ( "ZTMC" )]
        public string ZTMC
        {
            get
            {
                return _ZTMC;
            }

            set
            {
                _ZTMC = value;
            }
        }

        private decimal _DRJS;
        private string _SGZT;


        private string _CZMC;
        private DateTime? _CZKSSJ;
        private decimal _CZKSJS;
        private DateTime? _CZJSSJ;
        private decimal _CZJSJS;

        private string _ZTMC;
        private DateTime? _ZTKSSJ;
        private DateTime? _ZTJSSJ;

        //private DateTime _TJRQ;
        ///// <summary>
        ///// 添加时间
        ///// </summary>
        //[DisplayName("TJRQ")]
        //public DateTime TJRQ
        //{
        //	get { return _TJRQ; }
        //	set { _TJRQ = value; }
        //}
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

        public string GCFZCLSJ_DG
        {
            get
            {
                return _GCFZCLSJ_DG;
            }

            set
            {
                _GCFZCLSJ_DG =  value ;
            }
        }

        public string GJRQ_DG
        {
            get
            {
                return _GJRQ_DG;
            }

            set
            {
                _GJRQ_DG =  value ;
            }
        }

        public string WZRQ_DG
        {
            get
            {
                return _WZRQ_DG;
            }

            set
            {
                _WZRQ_DG =  value ;
            }
        }

        public string KZRQ_DG
        {
            get
            {
                return _KZRQ_DG;
            }

            set
            {
                _KZRQ_DG =  value ;
            }
        }

        public string ZHLJKSSJ_DG
        {
            get
            {
                return _ZHLJKSSJ_DG;
            }

            set
            {
                _ZHLJKSSJ_DG =  value ;
            }
        }

        public string QCLJKSSJ_DG
        {
            get
            {
                return _QCLJKSSJ_DG;
            }

            set
            {
                _QCLJKSSJ_DG =  value ;
            }
        }

        public string YXLJKSSJ_DG
        {
            get
            {
                return _YXLJKSSJ_DG;
            }

            set
            {
                _YXLJKSSJ_DG =  value ;
            }
        }

        public string DZLJKSSJ_DG
        {
            get
            {
                return _DZLJKSSJ_DG;
            }

            set
            {
                _DZLJKSSJ_DG =  value ;
            }
        }

        public string WJRQ_DG
        {
            get
            {
                return _WJRQ_DG;
            }

            set
            {
                _WJRQ_DG =  value ;
            }
        }

        public string ND
        {
            get
            {
                return _ND;
            }

            set
            {
                _ND =  value ;
            }
        }

        /// <summary>
        /// 施工队电话
        /// </summary>
        public string SGDDH
        {
            get
            {
                return _SGDDH;
            }

            set
            {
                _SGDDH = value;
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

        private string _SGDDH;

        private string _YJWJRQ;
    }
}
