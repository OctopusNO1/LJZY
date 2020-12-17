using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class LQ_SCDT
    {
        public LQ_SCDT()
        {
            _XQXMB = "";
            _SGDH = "";
            _JDDT = "";
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

        private string _XQXMB;
        /// <summary>
        ///辖区项目部
        /// </summary>
        [DisplayName ( "XQXMB" )]
        public string XQXMB
        {
            get { return _XQXMB; }
            set { _XQXMB = value; }
        }

        private string _DWZBH;
        /// <summary>
        /// 队伍自编号
        /// </summary>
        [DisplayName ( "DWZBH" )]
        public string DWZBH
        {
            get { return _DWZBH; }
            set { _DWZBH = value; }
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

        private string _XDT;
        /// <summary>
        /// 井动态
        /// </summary>
        [DisplayName ( "XDT" )]
        public string XDT
        {
            get { return _XDT; }
            set { _XDT = value; }
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

        private string _DRJS;
        /// <summary>
        /// 当日井深
        /// </summary>
        [DisplayName ( "DRJS" )]
        public string DRJS
        {
            get { return _DRJS; }
            set { _DRJS = value; }
        }

        private string _KZRQ;
        /// <summary>
        /// 开钻日期
        /// </summary>
        [DisplayName ( "KZRQ" )]
        public string KZRQ
        {
            get { return _KZRQ; }
            set { _KZRQ = value; }
        }

        private string _YJWJRQ;
        /// <summary>
        /// 预计完井日期
        /// </summary>
        [DisplayName ( "YJWJRQ" )]
        public string YJWJRQ
        {
            get { return _YJWJRQ; }
            set { _YJWJRQ = value; }
        }

        private string _HXJW;
        /// <summary>
        /// 后续井位
        /// </summary>
        [DisplayName ( "HXJW" )]
        public string HXJW
        {
            get { return _HXJW; }
            set { _HXJW = value; }
        }

        private string _HXJDH;
        /// <summary>
        /// 后续井队号
        /// </summary>
        [DisplayName ( "HXJDH" )]
        public string HXJDH
        {
            get { return _HXJDH; }
            set { _HXJDH = value; }
        }

        private string _SGZT;
        /// <summary>
        /// 井队动态
        /// </summary>
        [DisplayName ( "SGZT" )]
        public string SGZT
        {
            get { return _SGZT; }
            set { _SGZT = value; }
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

        private string _LSDW;
        /// <summary>
        /// 隶属单位
        /// </summary>
        [DisplayName ( "LSDW" )]
        public string LSDW
        {
            get { return _LSDW; }
            set { _LSDW = value; }
        }

        private string _DQZT;
        /// <summary>
        /// 当前状态
        /// </summary>
        [DisplayName ( "DQZT" )]
        public string DQZT
        {
            get { return _DQZT; }
            set { _DQZT = value; }
        }

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
    }
}
