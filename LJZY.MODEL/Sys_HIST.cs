using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJZY.MODEL
{
   public class Sys_Hostroy
    {
        private string _ID;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _TITLE;

        public string TITLE
        {
            get { return _TITLE; }
            set { _TITLE = value; }
        }
        private string _URL;

        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }
        private string _USER_ID;

        public string USER_ID
        {
            get { return _USER_ID; }
            set { _USER_ID = value; }
        }
        private DateTime _ADDTIME;

        public DateTime ADDTIME
        {
            get { return _ADDTIME; }
            set { _ADDTIME = value; }
        }
        private string _TIME;

        public string TIME
        {
            get { return _TIME; }
            set { _TIME = value; }
        }

    }
}
