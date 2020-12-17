using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class SCJSK_Count
    {
        public SCJSK_Count()
        {
            _LJFGS = "";
            _TOTAL = 0;
            _TYPE = "";
        }

        private string _LJFGS;
        private int _TOTAL;
        private string _TYPE;

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

        public int TOTAL
        {
            get
            {
                return _TOTAL;
            }

            set
            {
                _TOTAL = value;
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
    }
}
