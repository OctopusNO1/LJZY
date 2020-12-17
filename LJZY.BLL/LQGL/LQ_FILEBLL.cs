using LJZY.DAO.LQGL;
using LJZY.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.BLL.LQGL
{
	public class LQ_FILEBLL
	{
		private readonly LQ_FILEDAO dal;

		public LQ_FILEBLL()
		{
			dal = new LQ_FILEDAO();
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(LQ_FILE file)
		{
			return dal.Add(file);
		}

		public bool Update(LQ_FILE file)
		{
			return dal.Update(file);
		}

		/// <summary>
		/// 返回附件列表
		/// </summary>
		/// <param name="strWhere"></param>
		/// <returns></returns>
		public Dictionary<string, object> FileList(string ZJH, int rows, int page)
		{
			Dictionary<string, object> dic = new Dictionary<string, object>();
			int recordCount = 0;
			List<LQ_FILE> list = new List<LQ_FILE>();
			string strSql = string.Format(@" AND ZJH='{0}' ", ZJH);
			DataTable dt = dal.FileList(strSql, rows, page, " UPLOADTIME DESC ", out recordCount).Tables[0];

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				LQ_FILE model = new LQ_FILE();
				DataRow dr = dt.Rows[i];
				model = dal.FileModel(dr);
				list.Add(model);
			}
			dic.Add("count", recordCount.ToString());
			dic.Add("code", 0);
			dic.Add("msg", null);
			dic.Add("data", list);
			return dic;

		}

		/// <summary>
		/// 根据ID返回附件信息
		/// </summary>
		/// <param name="ID"></param>
		/// <returns></returns>
		public LQ_FILE FileInfo(string ID)
		{
			LQ_FILE model = new LQ_FILE();
			string strSql = string.Format(@" AND ID='{0}' ", ID);
			DataTable dt = dal.FileList(strSql).Tables[0];

			if (dt.Rows.Count > 0)
			{
				DataRow dr = dt.Rows[0];
				model = dal.FileModel(dr);
			}

			return model;

		}

        public LQ_FILE FileInfoByJH(string JH,string TYPE)
        {
            LQ_FILE model = new LQ_FILE();
            string strSql = string.Format(@" AND ZJH='{0}' AND TYPE='{1}' ", JH,TYPE);
            DataTable dt = dal.FileList(strSql).Tables[0];

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                model = dal.FileModel(dr);
            }

            return model;

        }

        /// <summary>
        /// 查询井号对应类型文件
        /// </summary>
        /// <param name="ZJH"></param>
        /// <param name="TYPE"></param>
        /// <returns></returns>
        public List<LQ_FILE> FileInfoList(string ZJH, string TYPE)
		{
			
			List<LQ_FILE> list = new List<LQ_FILE>();
			
			string strSql = string.Format(@" AND ZJH='{0}' AND TYPE='{1}' ", ZJH, TYPE);
			DataTable dt = dal.FileList(strSql).Tables[0];

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				LQ_FILE model = new LQ_FILE();
				DataRow dr = dt.Rows[i];
				model = dal.FileModel(dr);
				//string extension = System.IO.Path.GetExtension(model.FILEURL);//扩展名 “.aspx”
				//string strPath = model.FILENAME.Replace(extension, ".pdf");
				//model.PDFURL = strPath;
				list.Add(model);
			}

			return list;

		}

		/// <summary>
		/// 判断附件是否替换
		/// </summary>
		/// <param name="ZJH"></param>
		/// <param name="TYPE"></param>
		/// <returns></returns>
		public bool FileCheck(string ZJH, string TYPE)
		{

			bool result = true;
			List<LQ_FILE> list = new List<LQ_FILE>();
			if (TYPE.Trim() != "附件")
			{
				string strSql = string.Format(@" AND ZJH='{0}' AND TYPE='{1}' ", ZJH, TYPE);
				DataTable dt = dal.FileList(strSql).Tables[0];
				if (dt.Rows.Count > 0)
				{
					result = false;
				}
			}

			return result;

		}


		/// <summary>
		/// 根据主键id删除附件信息
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		public bool DelFileById(string Id)
		{
			return dal.DelFileById(Id);
		}


	}
}
