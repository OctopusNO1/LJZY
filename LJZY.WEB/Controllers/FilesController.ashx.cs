using Aspose.Cells;
using Aspose.Slides;
using Aspose.Words;
using LJZY.BLL.LQGL;
using LJZY.MODEL;
using LJZY.WEB.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LJZY.WEB.Controllers
{
    /// <summary>
    /// FilesController 的摘要说明
    /// </summary>
    public class FilesController : IHttpHandler
    {
        LQ_FILEBLL fileBLL = new LQ_FILEBLL();
        FileHelp fileHelp = new FileHelp();
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"];
            switch (action)
            {
                //上传
                case "FileUpload": FileUpload(context); break;
                //上传列表
                case "FileList": FileList(context); break;
                //上传文件列表
                case "FileInfoList": FileInfoList(context); break;
                //根据Id返回附件信息
                case "FileInfoById": FileInfoById(context); break;
                //根据井号和类型返回附件信息
                case "FileInfoByJH": FileInfoByJH(context); break;
                //根据Id删除附件信息
                case "DelFileById": DelFileById(context); break;
            }
        }

        public void FileUpload(HttpContext context)
        {
            string json = "";
            HttpFileCollection files = context.Request.Files;
            try
            {
                string ZJH = context.Request["ZJH"];//井号
                                                    //string JX = context.Request["JX"]; //井型
                string REPORT_TYPE = context.Request["REPORT_TYPE"];//井别
                string ND = context.Request["ND"]; //年度
                                                   //string EJML = context.Request["EJML"];//二级目录
                string TYPE = context.Request["TYPE"];//文件类型
                List<LQ_FILE> List = new List<LQ_FILE>();
                FileHelp fileHelp = new FileHelp();
                for (int i = 0; i < files.Count; i++)
                {
                    //补充上传文件信息 保存上传文件
                    LQ_FILE file = new LQ_FILE();
                    file.ID = Guid.NewGuid().ToString().ToUpper();
                    file.ZJH = ZJH;
                    file.REPORT_TYPE = REPORT_TYPE;
                    file.ND = ND;
                    file.TYPE = TYPE;
                    file.FILENAME = files[i].FileName;
                    file.UPLOADEMP = CFunctions.getUserId(context);
                    string url = "~/Upload/" + ND + "/" + REPORT_TYPE + "/" + ZJH + "/" + TYPE;
                    string urlPath = "../../Upload/" + ND + "/" + REPORT_TYPE + "/" + ZJH + "/" + TYPE + "/";
                    file.FILEURL = urlPath + file.FILENAME;
                    string Path = fileHelp.FileCreateDirectory(url, file.FILENAME);
                    files[i].SaveAs(Path);
                    //保存PDF文件方便在线预览
                    string strFileName = file.FILENAME;
                    string[] arr = strFileName.Split('.');
                    string suffix = arr[arr.Length - 1];
                    string fileName = arr[0];
                    switch (suffix)
                    {
                        //case "doc":
                        //    //Document doc = new Document(Path);
                        //    //string docPath = Path.Replace(".doc", ".pdf");
                        //    //string docPdf = file.FILEURL.Replace(".doc", ".pdf");
                        //    //file.PDFURL = "../../PDFjs/web/viewer.html?file=" + docPdf;
                        //    //doc.Save(docPath, Aspose.Words.SaveFormat.Pdf);
                        //    //file.PDFURL = "../../PDFjs/web/viewer.html?file=" + file.FILEURL;
                        //    break;
                        //case "docx":
                        //    //Document docx = new Document(Path);
                        //    //string docxPath = Path.Replace(".docx", ".pdf");
                        //    //string docxPdf = file.FILEURL.Replace(".docx", ".pdf");
                        //    //file.PDFURL = "../../PDFjs/web/viewer.html?file=" + docxPdf;
                        //    //docx.Save(docxPath, Aspose.Words.SaveFormat.Pdf);
                        //    file.PDFURL = "../../PDFjs/web/viewer.html?file=" + file.FILEURL;
                        //    break;
                        //case "ppt":
                        //    //Presentation ppt = new Presentation(Path);
                        //    //string pptPath = Path.Replace(".ppt", ".pdf");
                        //    //string pptPdf = file.FILEURL.Replace(".ppt", ".pdf");
                        //    //file.PDFURL = "../../PDFjs/web/viewer.html?file=" + pptPdf;
                        //    //ppt.Save(pptPath, Aspose.Slides.Export.SaveFormat.Pdf);
                        //    //file.PDFURL = file.FILEURL;
                        //    file.PDFURL = "../../PDFjs/web/viewer.html?file=" + file.FILEURL;
                        //    break;
                        //case "pptx":
                        //    //Presentation pptx = new Presentation(Path);
                        //    //string pptxPath = Path.Replace(".pptx", ".pdf");
                        //    //string pptxPdf = file.FILEURL.Replace(".pptx", ".pdf");
                        //    //file.PDFURL = "../../PDFjs/web/viewer.html?file=" + pptxPdf;
                        //    //pptx.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pdf);
                        //    //file.PDFURL = file.FILEURL;
                        //    file.PDFURL = "../../PDFjs/web/viewer.html?file=" + file.FILEURL;
                        //    break;
                        //case "xlsx":
                        //    //Workbook xlsx = new Workbook(Path);
                        //    //string xlsxPath = Path.Replace(".xlsx", ".pdf");
                        //    //string xlsxPdf = file.FILEURL.Replace(".xlsx", ".pdf");
                        //    //file.PDFURL = "../../PDFjs/web/viewer.html?file=" + xlsxPdf;
                        //    //xlsx.Save(xlsxPath, Aspose.Cells.SaveFormat.Pdf);
                        //    file.PDFURL = "../../PDFjs/web/viewer.html?file=" + file.FILEURL;
                        //    break;
                        //case "xls":
                        //    //Workbook xls = new Workbook(Path);
                        //    //string xlsPath = Path.Replace(".xls", ".pdf");
                        //    //string xlsPdf = file.FILEURL.Replace(".xls", ".pdf");
                        //    //file.PDFURL = "../../PDFjs/web/viewer.html?file=" + xlsPdf;
                        //    file.PDFURL = "../../PDFjs/web/viewer.html?file=" + file.FILEURL;
                        //    //xls.Save(xlsPath, Aspose.Cells.SaveFormat.Pdf);
                        //    //file.PDFURL = file.FILEURL;
                        //    break;
                        case "pdf":

                            file.PDFURL = "../../PDFjs/web/viewer.html?file=" + file.FILEURL;

                            break;
                        //case "bmp":

                        //    file.PDFURL = file.FILEURL;

                        //    break;
                        default:
                            break;
                    }


                    file.UPLOADEMP = CFunctions.getUserId(context);
                    file.UPLOADTIME = DateTime.Now;
                    List.Add(file);//获取多文件名列表

                    if (fileBLL.FileCheck(List[0].ZJH, List[0].TYPE))
                    {
                        if (fileBLL.Add(List[i]))
                        {
                            json = JsonConvert.SerializeObject(List);
                            json = "{\"IsSuccess\":\"true\",\"Message\":\" 上传成功！ \",\"FileList\":" + json + "}";
                        }
                        else
                        {
                            json = "{\"IsSuccess\":\"false\",\"Message\":\" 上传失败！ \"";
                        }
                    }
                    else
                    {
                        if (fileBLL.Update(List[i]))
                        {
                            json = JsonConvert.SerializeObject(List);
                            json = "{\"IsSuccess\":\"true\",\"Message\":\" 上传成功！ \",\"FileList\":" + json + "}";
                        }
                        else
                        {

                            json = "{\"IsSuccess\":\"false\",\"Message\":\" 上传失败！ \"";
                        }

                    }

                }

            }
            catch (Exception e)
            {
                //logger.Error(e.Message);
                json = "{\"IsSuccess\":\"false\",\"Message\":\" 获取数据出现异常！ \"}";
            }



            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        /// <summary>
        /// 附件列表
        /// </summary>
        /// <param name="context"></param>
        public void FileList(HttpContext context)
        {
            string json = "";
            try
            {
                int rows = Convert.ToInt32(context.Request["limit"]);
                int page = Convert.ToInt32(context.Request["page"]);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                string ZJH = context.Request["ZJH"] ?? "";//井号
                dic = fileBLL.FileList(ZJH, rows, page);

                json = JsonConvert.SerializeObject(dic);

            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\" 获取数据出现异常！ \"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        /// <summary>
        /// 根据Id返回附件信息
        /// </summary>
        /// <param name="context"></param>
        public void FileInfoById(HttpContext context)
        {
            string json = "";
            try
            {
                string ID = context.Request["ID"] ?? "";//主键
                LQ_FILE model = new LQ_FILE();
                model = fileBLL.FileInfo(ID);

                json = JsonConvert.SerializeObject(model);


                json = "{\"IsSuccess\":\"true\",\"Data\":" + json + "}";
            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\" 获取数据出现异常！ \"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public void FileInfoByJH(HttpContext context)
        {
            string json = "";
            int View = 0;
            try
            {
                string JH = context.Request["JH"] ?? "";//井号
                string TYPE = "钻井地质设计";
                LQ_FILE model = new LQ_FILE();
                model = fileBLL.FileInfoByJH(JH, TYPE);
                string strFileName = model.FILENAME;
                string FileURL = "";
                if (!string.IsNullOrEmpty(strFileName))
                {
                    string[] arr = strFileName.Split('.');
                    string suffix = arr[arr.Length - 1];
                    if (suffix == "pdf")
                    {
                        FileURL = model.PDFURL;
                        View = 1;
                    }
                    else
                    {
                        FileURL = model.FILEURL;
                    }
                }
                string strView = JsonConvert.SerializeObject(View);
                strFileName = JsonConvert.SerializeObject(strFileName);
                FileURL = JsonConvert.SerializeObject(FileURL);
                json = "{\"IsSuccess\":\"true\",\"View\":" + strView + ",\"FileName\":" + strFileName + ",\"FileURL\":" + FileURL + "}";
            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\" 获取数据出现异常！ \"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }


        public void FileInfoList(HttpContext context)
        {
            string json = "";
            try
            {
                string ZJH = context.Request["ZJH"] ?? "";//井号
                string TYPE = context.Request["TYPE"] ?? "";//类型
                List<LQ_FILE> list = new List<LQ_FILE>();
                list = fileBLL.FileInfoList(ZJH, TYPE);
                json = JsonConvert.SerializeObject(list);


                json = "{\"IsSuccess\":\"true\",\"Data\":" + json + "}";
            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\" 获取数据出现异常！ \"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        /// <summary>
        /// 根据Id删除附件
        /// </summary>
        /// <param name="context"></param>
        public void DelFileById(HttpContext context)
        {
            string json = "";
            try
            {
                string ID = context.Request["ID"] ?? "";//主键
                LQ_FILE model = fileBLL.FileInfo(ID);
                if (fileBLL.DelFileById(ID))
                {
                    fileHelp.FileDel(model.FILEURL);
                    json = "{\"IsSuccess\":\"true\",\"Message\":\"删除成功！\"}";
                }
                else
                {
                    json = "{\"IsSuccess\":\"false\",\"Message\":\"删除失败！\"}";
                }

            }
            catch (Exception e)
            {
                json = "{\"IsSuccess\":\"false\",\"Message\":\" 获取数据出现异常！ \"}";
            }

            context.Response.ContentType = "application/json";
            //返回JSON结果
            context.Response.Clear();
            context.Response.Write(json);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}