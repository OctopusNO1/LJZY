using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LJZY.WEB.Common
{
	public class FileHelp
	{
		public FileHelp()
		{ }

		/// <summary>
		/// 删除文件
		/// </summary>
		/// <param name="context"></param>
		public void FileDel(string PathUrl)
		{
			string strUrl = System.Web.HttpContext.Current.Server.MapPath(PathUrl);
			if (System.IO.Directory.Exists(strUrl))
			{
				DirectoryInfo subdir = new DirectoryInfo(strUrl);
				subdir.Delete(true); //删除子目录和文件
			}

		}

		/// <summary>
		/// 移动文件位置
		/// </summary>
		/// <param name="NewURL"></param>
		/// <param name="OldURL"></param>
		/// <param name="FileName"></param>
		public void FileMove(string NewURL, string OldURL, string FileName)
		{

			if (!System.IO.Directory.Exists(NewURL))
			{
				System.IO.Directory.CreateDirectory(NewURL);
			}
			NewURL = NewURL + "\\" + System.IO.Path.GetFileName(FileName);
			if (!Directory.Exists(OldURL))
			{
				Directory.Move(OldURL, NewURL);
			}
		}

		/// <summary>
		/// 判断路径是否存在不存在则创建
		/// </summary>
		/// <param name="strUrl"></param>
		/// <param name="FileName"></param>
		/// <returns></returns>
		public string FileCreateDirectory(string oldPath, string FileName)
		{
			string strUrl = System.Web.HttpContext.Current.Server.MapPath(oldPath);

			if (!System.IO.Directory.Exists(strUrl))
			{
				System.IO.Directory.CreateDirectory(strUrl);
			}
			strUrl = strUrl + "\\" + System.IO.Path.GetFileName(FileName);
			return strUrl;
		}
	}
}