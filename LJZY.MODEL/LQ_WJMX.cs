using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class LQ_WJMX
    {
        public LQ_WJMX()
        {
            _JH = "";
            _LJFGS = ""; ;
            _LJDH = "";
            _SGDH = "";
            _YJWJRQ = "";
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

        private string _JH;
        /// <summary>
        /// 井号
        /// </summary>
        [DisplayName("JH")]
        public string JH
        {
            get { return _JH; }
            set { _JH = value; }
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

        private string _YJWJRQ;
        /// <summary>
        /// 预计完井日期
        /// </summary>
        [DisplayName("YJWJRQ")]
        public string YJWJRQ
        {
            get
            {
                return _YJWJRQ;
            }

            set
            {
                _YJWJRQ = value;
            }
        }




    }
}
