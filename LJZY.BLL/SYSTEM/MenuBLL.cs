using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LJZY.MODEL;
using LJZY.DAO.SYSTEM;
namespace LJZY.BLL.SYSTEM
{
    public class MenuBLL
    {
        private readonly MenuDAO dal;
        public MenuBLL()
        {
            dal = new MenuDAO();
        }

        /// <summary>
        /// 获取树状二级目录
        /// </summary>
        /// <returns></returns>
        public List<Sys_Menu> SYS_MenuTreeList(string str)
        {
            List<Sys_Menu> AllList = new List<Sys_Menu>();
            DataTable dt = dal.SYS_MenuList(str).Tables[0];
            List<Sys_Menu> list = new List<Sys_Menu>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sys_Menu model = new Sys_Menu();
                DataRow dr = dt.Rows[i];
                model = dal.MenuModel(dr);
                list.Add(model);
            }
            list = list.OrderByDescending(n => n.CODE).ToList();

            return list;
        }

        public void GetTree(List<Sys_Menu> allList, Sys_Menu parent)
        {
            //获取子节点
            List<Sys_Menu> childList = allList.Where(m => m.PID == parent.MENUID).ToList<Sys_Menu>();
            if (childList.Count > 0)
            {
                parent.ItermList = childList;
                foreach (Sys_Menu child in childList)
                {
                    GetTree(allList, child);
                }
            }
        }


        /// <summary>
        /// 获取用户菜单列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public List<Sys_Menu> GetRoleMenu(Sys_User model, string str)
        {

            DataTable dt = dal.GetRoleMenu(model, str).Tables[0];
            List<Sys_Menu> list = new List<Sys_Menu>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Sys_Menu menu = new Sys_Menu();
                DataRow dr = dt.Rows[i];
                menu = dal.MenuModel(dr);
                list.Add(menu);
            }
            list = list.OrderByDescending(n => n.CODE).ToList();

            return list;

        }


    }
}
