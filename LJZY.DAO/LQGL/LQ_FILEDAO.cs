using LJZY.COMMON;
using LJZY.DBUtility;
using LJZY.MODEL;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.DAO.LQGL
{
    public class LQ_FILEDAO
    {
        /// <summary>
        /// 上传添加数据
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool Add(LQ_FILE file)
        {
            string sqlStr = @"INSERT INTO LQ_File(ID, ZJH, JX, REPORT_TYPE, ND, TYPE, FILEURL, UPLOADTIME, UPLOADEMP, FILENAME, PDFURL)
							VALUES(:ID, :ZJH, :JX, :REPORT_TYPE, :ND, :TYPE, :FILEURL, :UPLOADTIME, :UPLOADEMP, :FILENAME, :PDFURL)";
            OracleParameter[] parameter = {
                                            new OracleParameter(":ID",OracleDbType.Varchar2,32),
                                            new OracleParameter(":ZJH",OracleDbType.Varchar2,10),
                                            new OracleParameter(":JX",OracleDbType.Varchar2,10),
                                            new OracleParameter(":REPORT_TYPE",OracleDbType.Varchar2,10),
                                            new OracleParameter(":ND",OracleDbType.Varchar2,10),
                                            new OracleParameter(":TYPE",OracleDbType.Varchar2,10),
                                            new OracleParameter(":FILEURL",OracleDbType.Varchar2,100),
                                            new OracleParameter(":UPLOADTIME",OracleDbType.Date),
                                            new OracleParameter(":UPLOADEMP",OracleDbType.Varchar2,50),
                                            new OracleParameter(":FILENAME",OracleDbType.Varchar2,50),
                                            new OracleParameter(":PDFURL",OracleDbType.Varchar2,100)
                                        };
            parameter[0].Value = file.ID;
            parameter[1].Value = file.ZJH;
            parameter[2].Value = file.JX;
            parameter[3].Value = file.REPORT_TYPE;
            parameter[4].Value = file.ND;
            parameter[5].Value = file.TYPE;
            parameter[6].Value = file.FILEURL;
            parameter[7].Value = DateTime.Now;
            parameter[8].Value = file.UPLOADEMP;
            parameter[9].Value = file.FILENAME;
            parameter[10].Value = file.PDFURL;
            int rows = DbHelperOra.ExecuteSql(sqlStr, parameter);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(LQ_FILE file)
        {
            string sqlStr = @"
Update LQ_File
Set FILEURL= :FILEURL,
FILENAME= :FILENAME,
PDFURL= :PDFURL,
ND= :ND,
REPORT_TYPE= :REPORT_TYPE,
UPLOADTIME= :UPLOADTIME,
UPLOADEMP= :UPLOADEMP
WHERE ZJH= :ZJH AND TYPE= :TYPE ";
            OracleParameter[] parameter = {
                                            new OracleParameter(":FILEURL",OracleDbType.Varchar2,100),
                                            new OracleParameter(":FILENAME",OracleDbType.Varchar2,50),
                                            new OracleParameter(":PDFURL",OracleDbType.Varchar2,100),
                                            new OracleParameter(":ND",OracleDbType.Varchar2,50),
                                            new OracleParameter(":REPORT_TYPE",OracleDbType.Varchar2,50),
                                            new OracleParameter(":UPLOADTIME",OracleDbType.Date),
                                            new OracleParameter(":UPLOADEMP",OracleDbType.Varchar2,50),
                                            new OracleParameter(":ZJH",OracleDbType.Varchar2,10),
                                            new OracleParameter(":TYPE",OracleDbType.Varchar2,10)
                                        };

            parameter[0].Value = file.FILEURL;
            parameter[1].Value = file.FILENAME;
            parameter[2].Value = file.PDFURL;
            parameter[3].Value = file.ND;
            parameter[4].Value = file.REPORT_TYPE;
            parameter[5].Value = DateTime.Now;
            parameter[6].Value = file.UPLOADEMP;
            parameter[7].Value = file.ZJH;
            parameter[8].Value = file.TYPE;

            int rows = DbHelperOra.ExecuteSql(sqlStr, parameter);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据Id删除附件信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DelFileById(string ID)
        {

            try
            {
                string sqlStr = string.Format(@" delete from  LQ_FILE   WHERE ID='{0}'  ", ID);

                int rows = DbHelperOra.ExecuteSql(sqlStr);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 根据条件获取附件列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet FileList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select f.* from LQ_FILE f ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1" + strWhere);
            }
            DataSet ds = DbHelperOra.Query(strSql.ToString());
            return ds;
        }

        public DataSet FileList(string strWhere, int pageSize, int pageIndex, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select f.* from LQ_FILE f ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE 1=1 " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOra.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOra.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
            //return DbHelperOra.Query(strSql.ToString());
        }

        public LQ_FILE FileModel(DataRow dr)
        {
            LQ_FILE model = new LQ_FILE();
            if (dr["ID"] != null && dr["ID"].ToString() != "")
            {
                model.ID = dr["ID"].ToString();
            }

            if (dr["ZJH"] != null && dr["ZJH"].ToString() != "")
            {
                model.ZJH = dr["ZJH"].ToString();
            }

            if (dr["JX"] != null && dr["JX"].ToString() != "")
            {
                model.JX = dr["JX"].ToString();
            }

            if (dr["REPORT_TYPE"] != null && dr["REPORT_TYPE"].ToString() != "")
            {
                model.REPORT_TYPE = dr["REPORT_TYPE"].ToString();
            }

            if (dr["ND"] != null && dr["ND"].ToString() != "")
            {
                model.ND = dr["ND"].ToString();
            }

            if (dr["TYPE"] != null && dr["TYPE"].ToString() != "")
            {
                model.TYPE = dr["TYPE"].ToString();
            }

            if (dr["FILENAME"] != null && dr["FILENAME"].ToString() != "")
            {
                model.FILENAME = dr["FILENAME"].ToString();
            }

            if (dr["FILEURL"] != null && dr["FILEURL"].ToString() != "")
            {
                model.FILEURL = dr["FILEURL"].ToString();
            }

            if (dr["PDFURL"] != null && dr["PDFURL"].ToString() != "")
            {
                model.PDFURL = dr["PDFURL"].ToString();
            }

            if (dr["UPLOADEMP"] != null && dr["UPLOADEMP"].ToString() != "")
            {
                model.UPLOADEMP = dr["UPLOADEMP"].ToString();
            }

            if (dr["UPLOADEMP"] != null && dr["UPLOADEMP"].ToString() != "")
            {
                model.UPLOADEMP = dr["UPLOADEMP"].ToString();
            }
            return model;

        }


    }
}
