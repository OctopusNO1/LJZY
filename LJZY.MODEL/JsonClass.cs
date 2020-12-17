using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    class JsonClass
    {
    }

    public class LQ_SGZJSON //上岗证
    {
        public LQ_SGZJSON()
        {
        }
        public string ZJBH { get; set; }
        public string YXQ { get; set; }
        public string IMG { get; set; }
    }


    public class LQ_JCZJSON //井控证
    {

        public LQ_JCZJSON()
        {
        }
        public string ZJBH { get; set; }
        public string YXQ { get; set; }
        public string IMG { get; set; }

    }

    public class LQ_HSEJSON //HSE证
    {
        public LQ_HSEJSON()
        {

        }
        public string ZJBH { get; set; }
        public string YXQ { get; set; }
        public string IMG { get; set; }
    }
}
