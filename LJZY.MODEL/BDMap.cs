using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class BDMap
    {
        /// <summary>
        /// 默认构造方法
        /// </summary>
        public BDMap()
        {
            JH = "";
            LJDH = "";
            SJJS = "";
            DRJS = "";
            SGDH = "";
            SGDDH = "";
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

        private string _Title;
        /// <summary>
        /// 标题
        /// </summary>
        [DisplayName ( "Title" )]
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        private string _Point;
        /// <summary>
        /// 坐标
        /// </summary>
        [DisplayName ( "Point" )]
        public string Point
        {
            get { return _Point; }
            set { _Point = value; }
        }

        ///// <summary>
        ///// 联系电话
        ///// </summary>
        //public string LXDH
        //{
        //    get
        //    {
        //        return _LXDH;
        //    }

        //    set
        //    {
        //        _LXDH = value;
        //    }
        //}

        ///// <summary>
        ///// 姓名
        ///// </summary>
        //public string XM
        //{
        //    get
        //    {
        //        return _XM;
        //    }

        //    set
        //    {
        //        _XM = value;
        //    }
        //}

        /// <summary>
        /// 当日井深
        /// </summary>
        public string DRJS
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
        /// 设计井深
        /// </summary>
        public string SJJS
        {
            get
            {
                return _SJJS;
            }

            set
            {
                _SJJS = value;
            }
        }
        /// <summary>
        /// 录井队号
        /// </summary>
        public string LJDH
        {
            get
            {
                return _LJDH;
            }

            set
            {
                _LJDH = value;
            }
        }

        /// <summary>
        /// 井分类
        /// </summary>
        public string JFL
        {
            get
            {
                return _JFL;
            }

            set
            {
                _JFL = value;
            }
        }

        public List<LQ_RYFP> RyList
        {
            get
            {
                return _ryList;
            }

            set
            {
                _ryList =  value ;
            }
        }

        public string SGDH
        {
            get { return _SGDH; }
            set { _SGDH = value; }
        }

        public string SGDDH
        {
            get { return _SGDDH; }
            set { _SGDDH = value; }
        }

        public string STARTS
        {
            get
            {
                return _STARTS;
            }

            set
            {
                _STARTS = value;
            }
        }

        private string _JFL;
        private string _LJDH;
        private string _SJJS;
        private string _DRJS;
        private string _SGDH;
        private string _SGDDH;
        private string _STARTS;

        private List<LQ_RYFP> _ryList;
    }
}
