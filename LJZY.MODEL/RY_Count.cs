using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{

    public class RY_Count
    {
        public RY_Count()
        {
            _TYPE = "";
            _LJDZS = 0;
            _LJGCS = 0;
            _CZY = 0;
            _DZG = 0;
            _SXS = 0;
            _DZZL = 0;
            _KFJDZS = 0;
        }

        private string _TYPE;
        private int _LJDZS;
        private int _LJGCS;
        private int _CZY;
        private int _DZG;
        private int _SXS;
        private int _DZZL;
        private int _KFJDZS;

        /// <summary>
        /// 类别
        /// </summary>
        public string TYPE
        {
            get
            {
                return _TYPE;
            }

            set
            {
                _TYPE = value;
            }
        }

        public int LJDZS
        {
            get
            {
                return _LJDZS;
            }

            set
            {
                _LJDZS = value;
            }
        }

        public int LJGCS
        {
            get
            {
                return _LJGCS;
            }

            set
            {
                _LJGCS = value;
            }
        }

        public int CZY
        {
            get
            {
                return _CZY;
            }

            set
            {
                _CZY = value;
            }
        }

        public int DZG
        {
            get
            {
                return _DZG;
            }

            set
            {
                _DZG = value;
            }
        }

        public int SXS
        {
            get
            {
                return _SXS;
            }

            set
            {
                _SXS = value;
            }
        }

        public int DZZL
        {
            get
            {
                return _DZZL;
            }

            set
            {
                _DZZL = value;
            }
        }

        public int KFJDZS
        {
            get
            {
                return _KFJDZS;
            }

            set
            {
                _KFJDZS = value;
            }
        }
    }
}