using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
   public class LQ_FW
    {
        private string _ID;
        private int _XH;
        private int _TROW;
        private string _FL;
        private string _LJFGS;
        private string _CCBH;
        private string _GGXH;
        private string _SBZK;
        private string _SBSZWZ;
        private string _BZ;
        private string _TJR;
        private DateTime _TJRQ;

        public LQ_FW()
        {

        }

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

        public int XH
        {
            get
            {
                return _XH;
            }

            set
            {
                _XH = value;
            }
        }

        public string FL
        {
            get
            {
                return _FL;
            }

            set
            {
                _FL = value;
            }
        }

        public string LJFGS
        {
            get
            {
                return _LJFGS;
            }

            set
            {
                _LJFGS = value;
            }
        }

        public string CCBH
        {
            get
            {
                return _CCBH;
            }

            set
            {
                _CCBH = value;
            }
        }

        public string GGXH
        {
            get
            {
                return _GGXH;
            }

            set
            {
                _GGXH = value;
            }
        }

        public string SBZK
        {
            get
            {
                return _SBZK;
            }

            set
            {
                _SBZK = value;
            }
        }

        public string SBSZWZ
        {
            get
            {
                return _SBSZWZ;
            }

            set
            {
                _SBSZWZ = value;
            }
        }

        public string BZ
        {
            get
            {
                return _BZ;
            }

            set
            {
                _BZ = value;
            }
        }

        public string TJR
        {
            get
            {
                return _TJR;
            }

            set
            {
                _TJR = value;
            }
        }

        public DateTime TJRQ
        {
            get
            {
                return _TJRQ;
            }

            set
            {
                _TJRQ = value;
            }
        }

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
    }
}
