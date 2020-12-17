using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
   public class LQ_SJRZ
    {
        private string _ID;
        private string _RYBH;
        private string _XM;
        private string _JH;
        private DateTime _KSSJRQ;
        private DateTime _JSSJRQ;
        private string _GWXS;
        private DateTime _TJSJ;
        private int _TROW;

        private int _SJTS;
        private int _LJSJTS;

        private string _GW;
        private int _JXS;
        private string _REPORT_TYPE;

        #region  帮助字段
        private string _KSSJRQ_GD;
        private string _JSSJRQ_GD;
        #endregion

        

        public LQ_SJRZ()
        {
            _SJTS = 0;
            _LJSJTS = 0;
            _JXS = 0;
        }

        /// <summary>
        /// 主键Id
        /// </summary>
        public string ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        /// <summary>
        /// 人员编号
        /// </summary>
        public string RYBH
        {
            get
            {
                return _RYBH;
            }

            set
            {
                _RYBH = value;
            }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string XM
        {
            get
            {
                return _XM;
            }

            set
            {
                _XM = value;
            }
        }

        /// <summary>
        /// 井号
        /// </summary>
        public string JH
        {
            get
            {
                return _JH;
            }

            set
            {
                _JH = value;
            }
        }
        /// <summary>
        /// 开始上井日期
        /// </summary>
        public DateTime KSSJRQ
        {
            get
            {
                return _KSSJRQ;
            }

            set
            {
                _KSSJRQ = value;
            }
        }

        /// <summary>
        /// 结束上井日期
        /// </summary>
        public DateTime JSSJRQ
        {
            get
            {
                return _JSSJRQ;
            }

            set
            {
                _JSSJRQ = value;
            }
        }

        /// <summary>
        /// 岗位系数
        /// </summary>
        public string GWXS
        {
            get
            {
                return _GWXS;
            }

            set
            {
                _GWXS = value;
            }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime TJSJ
        {
            get
            {
                return _TJSJ;
            }

            set
            {
                _TJSJ = value;
            }
        }

        /// <summary>
        /// 序号
        /// </summary>
        public int TROW
        {
            get
            {
                return _TROW;
            }

            set
            {
                _TROW = value;
            }
        }

        /// <summary>
        /// 上井开始时间
        /// </summary>
        public string KSSJRQ_GD
        {
            get
            {
                return _KSSJRQ_GD;
            }

            set
            {
                _KSSJRQ_GD = value;
            }
        }
        /// <summary>
        /// 上井结束时间
        /// </summary>
        public string JSSJRQ_GD
        {
            get
            {
                return _JSSJRQ_GD;
            }

            set
            {
                _JSSJRQ_GD = value;
            }
        }

        /// <summary>
        /// 上井天数
        /// </summary>
        public int SJTS
        {
            get
            {
                return _SJTS;
            }

            set
            {
                _SJTS = value;
            }
        }

        /// <summary>
        /// 上井总天数
        /// </summary>
        public int LJSJTS
        {
            get
            {
                return _LJSJTS;
            }

            set
            {
                _LJSJTS = value;
            }
        }

        
        /// <summary>
        /// 岗位
        /// </summary>
        [DisplayName ( "GW" )]
        public string GW
        {
            get
            {
                return _GW;
            }

            set
            {
                _GW = value;
            }
        }

        /// <summary>
        /// 井系数
        /// </summary>
        public int JXS
        {
            get
            {
                return _JXS;
            }

            set
            {
                _JXS = value;
            }
        }

        /// <summary>
        /// 井别
        /// </summary>
        public string REPORT_TYPE
        {
            get
            {
                return _REPORT_TYPE;
            }

            set
            {
                _REPORT_TYPE = value;
            }
        }
    }
}
