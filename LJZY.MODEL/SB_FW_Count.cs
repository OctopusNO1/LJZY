using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class SB_FW_Count
    {
        public SB_FW_Count()
        {
            _TYPE = "";
            _ZHY = 0;
            _DZF = 0;
            _YQF = 0;
            _ZF = 0;
            _KF = 0; 
        }

        private string _TYPE;
        private int _ZHY;
        private int _DZF;
        private int _YQF;
        private int _ZF;
        private int _KF;

        public int KF
        {
            get
            {
                return _KF;
            }

            set
            {
                _KF = value;
            }
        }

        public int ZF
        {
            get
            {
                return _ZF;
            }

            set
            {
                _ZF = value;
            }
        }

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

        public int ZHY
        {
            get
            {
                return _ZHY;
            }

            set
            {
                _ZHY = value;
            }
        }

        public int DZF
        {
            get
            {
                return _DZF;
            }

            set
            {
                _DZF = value;
            }
        }

        public int YQF
        {
            get
            {
                return _YQF;
            }

            set
            {
                _YQF = value;
            }
        }
    }
}
