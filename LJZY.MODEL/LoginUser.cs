using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class LoginUser
    {
        public LoginUser()
        {
            username = "";
            id = "";
        }
        private string username;
        /// <summary>
        /// 用户id
        /// </summary>
        [DisplayName("Username")]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string id;
        /// <summary>
        /// 用户id
        /// </summary>
        [DisplayName("Id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
 
    }
}
