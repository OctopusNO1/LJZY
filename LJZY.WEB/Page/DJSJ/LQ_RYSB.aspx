<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LQ_RYSB.aspx.cs" Inherits="LJZY.WEB.Page.DJSJ.LQ_RYSB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["theme"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["icon"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["demo"].ToString()%>" rel="stylesheet" type="text/css" />
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["jquery"].ToString()%>" type="text/javascript"></script>
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-min"].ToString()%>" type="text/javascript"></script>
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-zh_CN"].ToString()%>" type="text/javascript"></script>
    <script src="../../Scripts/layui/layui.js"></script>
    <link href="../../Scripts/layui/css/layui.css" rel="stylesheet" />
    <link href="../../CSS/LQ_RYSB.css" rel="stylesheet" />
    <script src="../../Scripts/vue.js"></script>
    <style>
        /*#noDataList td  input:hover{
            box-sizing:border-box;
            height:20px;
            
        }*/
        .tableBody tr {
          min-width:1372px;
        }
        .tableBody th{
          border: 0.5px solid #000;
        }
        .tableBody td {
           border: 0.5px solid #000;
        }
        #RYSB {
           overflow-y:auto;
        }
        .table_padding {
          margin-top:30px;
        }
        .noDataList td{
          border:1px solid #e6e6e6;
        }
      
    </style>
</head>
<body  style="margin:0 auto;">
    <script>
    </script>
<div class="easyui-tabs" data-options="fit:true,plain:true" style="overflow:auto">
    <!--生产动态报表-->
    <div id="RYSB" title="人员设备">  
        <div class="table_padding" >   
            <table id="dataList_top">
              
                <thead>
                    <tr class="tableTitle">
                        <th colspan="16">
                            <input type="text" name="name" value="人员及设备动态表" id="RYSBTitle"/>
                        </th>
                    </tr>
                    <tr class="tableTitle">
                        <th style="width:100px">
                            <span style="font-weight:bold">录井项目部</span>
                        </th>
                        <th  style="width:100px">
                            <select id="SELECT_OPTION" v-model="XMBName" style="width:90px;">
                                     
                                      <option value="" style="display:none" id="Qb">全部</option>
                                     <option v-for="val in XMBList" v-bind:value="val.NAME" >{{val.NAME}}</option>
                                 
                            </select>
                        </th>

                    <th  style="width:80px">
                            <span style="font-weight:bold">日期</span>
                    </th>
                    <th >
                        <input class="easyui-datebox" id="datecheckbox" style="width:100px; height: 17px" data-options="onSelect:onSelect" v-model="changeDATA" />
                    </th>
                        <th >
                        <button style="margin-left:50px"  class="Commit" id="Commit" v-on:click="CommitData">提交</button>
                        </th>
                        <th colspan="11" style="text-align:right">
                            <a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" onclick="exportExcel();" style="height: 25px;width: 60px;">导出
                                 <iframe id="ExportIframe" class="J_iframe" name="iframe0" width="100%" height="100%" src="" frameborder="0" data-id="DownLoad.aspx"
                                      seamless="" style="display:none;"></iframe>
                             </a>
                        </th>
                    </tr>
                    <tr class="tableHeader">
                        <th   colspan="3">
                            <input type="text" name="name" value="录井仪:0台" />
                        </th>
                        <th  >
                            <input type="text" name="name" value="总人数：0" />
                        </th>
                        <th  >
                            <input type="text" name="name" value="" />
                        </th>
                        <th  >
                            <input type="text" name="name" value="前线：0" />
                        </th>
                        <th  >
                            <input type="text" name="name" value="" />
                        </th>
                        <th  >
                            <input type="text" name="name" value="轮休：0" />
                        </th>
                        <th  >
                            <input type="text" name="name" value="" />
                        </th>
                        <th  >
                            <input type="text" name="name" value="后勤：0" />
                        </th>
                        <th  >
                            <input type="text" name="name" value="外借：0" />
                        </th>
                        <th  >
                            <input type="text" name="name" value="培训：0" />
                        </th>
                        <th  >
                            <input type="text" name="name" value="事病假：0" />
                        </th>
                        <th colspan="2">
                            <table>
                                <tr>
                                    <td><input type="text" name="name" value="暂岗地质师" style="background:#FFFF99" /></td>
                                    <td><input type="text" name="name" value="暂岗工程师" style="background:#99CCFF"/></td>
                                    <td><input type="text" name="name" value="暂岗操作员" style="background:#00FF00"/></td>
                                    <td><input type="text" name="name" value="有事要回" style="background:#FFFF00" /></td>
                                </tr>
                            </table>
                        </th>
                        <th  >
                        </th>
                    </tr>
                    </thead>
          
                <%--<tbody class="tableBody" id="tableBody">
                      <tr>
                        <th style="width:128px;box-sizing:border-box;height:18px;">序号</th>
                        <th style="width:128px;box-sizing:border-box;">自编号</th>
                        <th style="width:128px;box-sizing:border-box;">队号</th>
                        <th style="width:128px;box-sizing:border-box;">仪器型号</th>
                        <th style="width:128px;box-sizing:border-box;">正录井</th>
                        <th style="width:128px;box-sizing:border-box;">钻井队</th>
                        <th style="width:128px;box-sizing:border-box;">设备状态</th>
                        <th style="width:128px;box-sizing:border-box;">待录井</th>
                        <th style="width:128px;box-sizing:border-box;">地质师</th>
                        <th style="width:128px;box-sizing:border-box;">地质助理</th>
                        <th style="width:128px;box-sizing:border-box;">工程师</th>
                        <th style="width:384px;box-sizing:border-box;">操作员</th>
                        <th style="width:512px;box-sizing:border-box;">地质工</th>
                        <th style="width:256px;box-sizing:border-box;">住房</th>
                        <th style="width:128px;box-sizing:border-box;">地质房</th>
                        <th style="width:128px;box-sizing:border-box;">设备所在地</th>
                    </tr>
                </tbody>--%>
         
        </table>
   </div> 

        <div id="dataTable" style="padding:0 30px">
            <table class="layui-hide" id="tableData"></table>   
        </div>

        <div style="margin-left:30px">                 
               <img v-on:click ="showEyeClick" v-if="showEye" src="../../Image/xs.png" alt="Alternate Text" />             
               <img v-on:click ="showEyeClick" v-else  src="../../Image/yc.png" alt="Alternate Text" />
        </div>
        
        <%--<button class="easyui-linkbutton bx btnGetType" style="margin-left:30px;" v-on:click="showTable"> 显示表格</button>--%>
        <div style="padding:0 30px;overflow: auto;display:none" id="tableContent">
            
            
           
                            
            <div style ="position: relative;top: -20px;left: 86px;display:none">
                <textarea style=" width:100px;height:100px;">content</textarea>
            </div>
            
            <table id="noDataList">
                <tr>
                    <td colspan="11" class="textLeft" style="background:#f2f2f2"><input type="text" name="name" value=" 领导:" /></td>
                    <td  style="background:#f2f2f2"><input type="text" name="name" value=" " /></td>                    
                    <td colspan="11"  style="background:#f2f2f2"><input type="text" name="name" value=" 基地轮休人员" /></td>
                </tr>
                <tr id="RY">

                    <td colspan="3" id="one"><input type="text" name="name" value=" " /></td>
                    <td>
                        <input type="text" name="name" value="" id="LD0" />
                    </td>
                   <td><input type="text" name="name" value=" " id="LD1" /></td>
                    <td><input type="text" name="name" value=" " id="LD2" /></td>
                    <td><input type="text" name="name" value=" " id="LD3" /></td>
                    <td><input type="text" name="name" value=" " id="LD4" /></td>
                    <td><input type="text" name="name" value=" " id="LD5" /></td>
                    <td><input type="text" name="name" value=" " id="LD6" /></td>
                    <td><input type="text" name="name" value=" " id="LD7" /></td>
                    <td rowspan="3" id="DZS"  style="background:#f2f2f2"><input type="text" name="name" value=" 地质师" /></td>
                    <td><input type="text" name="name" value=" " class="DZS0" /></td>
                    <td><input type="text" name="name" value=" "  class="DZS1"/></td>
                    <td><input type="text" name="name" value=" "  class="DZS2"/></td>
                    <td><input type="text" name="name" value=" "  class="DZS3"/></td>
                    <td><input type="text" name="name" value=" "  class="DZS4"/></td>
                    <td><input type="text" name="name" value=" "  class="DZS5"/></td>
                    <td><input type="text" name="name" value=" "  class="DZS6"/></td>
                    <td><input type="text" name="name" value=" "  class="DZS7"/></td>
                    <td><input type="text" name="name" value=" "  class="DZS8"/></td>
                    <td><input type="text" name="name" value=" "  class="DZS9"/></td>
                </tr>
                <tr>
                    <td colspan="11" id="ZRS"  style="background:#f2f2f2" class="textLeft"><input type="text" name="name" value=" 责任师:" /></td>
                    <td><input type="text" name="name" value=" " class="DZS10"/></td>
                    <td><input type="text" name="name" value=" "class="DZS11" /></td>
                    <td><input type="text" name="name" value=" " class="DZS12"/></td>
                    <td><input type="text" name="name" value=" " class="DZS13"/></td>
                    <td><input type="text" name="name" value=" " class="DZS14"/></td>
                    <td><input type="text" name="name" value=" " class="DZS15"/></td>
                    <td><input type="text" name="name" value=" " class="DZS16" /></td>
                    <td><input type="text" name="name" value=" " class="DZS17"/></td>
                    <td><input type="text" name="name" value=" "class="DZS18" /></td>
                    <td><input type="text" name="name" value=" "class="DZS19" /></td>
                </tr>
                <tr>
                    <td colspan="3"><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " class="DZS20"/></td>
                    <td><input type="text" name="name" value=" " class="DZS21"/></td>
                    <td><input type="text" name="name" value=" " class="DZS22"/></td>
                    <td><input type="text" name="name" value=" " class="DZS23" /></td>
                    <td><input type="text" name="name" value=" " class="DZS24"/></td>
                    <td><input type="text" name="name" value=" " class="DZS25"/></td>
                    <td><input type="text" name="name" value=" " class="DZS26" /></td>
                    <td><input type="text" name="name" value=" " class="DZS27"/></td>
                    <td><input type="text" name="name" value=" " class="DZS28"/></td>
                    <td><input type="text" name="name" value=" " class="DZS28" /></td>
                    <td><input type="text" name="name" value=" " class="DZS30"/></td>
                    <td><input type="text" name="name" value=" " class="DZS31"/></td>
                    <td><input type="text" name="name" value=" " class="DZS32"/></td>
                    <td><input type="text" name="name" value=" " class="DZS33"/></td>
                    <td><input type="text" name="name" value=" " class="DZS34"/></td>
                    <td><input type="text" name="name" value=" " class="DZS35"/></td>
                    <td><input type="text" name="name" value=" " class="DZS36"/></td>
                    <td><input type="text" name="name" value=" " class="DZS37"/></td>
                </tr>
                <tr>
                    <td colspan="11" class="textLeft"  style="background:#f2f2f2"><input type="text" name="name" value=" 经管员:" /></td>
                    <td rowspan="3"  style="background:#f2f2f2"><input type="text" name="name" value=" 工程师" /></td>
                    <td><input type="text" name="name" value=" " class="GCS0" /></td>
                    <td><input type="text" name="name" value=" " class="GCS1"/></td>
                    <td><input type="text" name="name" value=" " class="GCS2"/></td>
                    <td><input type="text" name="name" value=" " class="GCS3"/></td>
                    <td><input type="text" name="name" value=" " class="GCS4"/></td>
                    <td><input type="text" name="name" value=" " class="GCS5"/></td>
                    <td><input type="text" name="name" value=" " class="GCS6"/></td>
                    <td><input type="text" name="name" value=" " class="GCS7"/></td>
                    <td><input type="text" name="name" value=" " class="GCS8"/></td>
                    <td><input type="text" name="name" value=" " class="GCS9"/></td>
                </tr>
                <tr>
                    <td colspan="3" ><input type="text" name="name" value=" " /></td>
                     <td><input type="text" name="name" value=" " class="JGY0" /></td>
                    <td><input type="text" name="name" value=" " class="JGY1"/></td>
                    <td><input type="text" name="name" value=" " class="JGY2"/></td>
                    <td><input type="text" name="name" value=" "class="JGY3" /></td>
                    <td><input type="text" name="name" value=" " class="JGY4"/></td>
                    <td><input type="text" name="name" value=" "class="JGY5" /></td>
                    <td><input type="text" name="name" value=" " class="JGY6"/></td>
                    <%-- 工程师 --%>
                                     
                    <td><input type="text" name="name" value=" "class="GCS10" /></td>
                    <td><input type="text" name="name" value=" " class="GCS11"/></td>
                    <td><input type="text" name="name" value=" " class="GCS12" /></td>
                    <td><input type="text" name="name" value=" " class="GCS13"/></td>
                    <td><input type="text" name="name" value=" "class="GCS14" /></td>
                    <td><input type="text" name="name" value=" " class="GCS15"/></td>
                    <td><input type="text" name="name" value=" " class="GCS16"/></td>
                    <td><input type="text" name="name" value=" " class="GCS17"/></td>
                    <td><input type="text" name="name" value=" " class="GCS18"/></td>
                    <td><input type="text" name="name" value=" " class="GCS19"/></td>
                    <td><input type="text" name="name" value=" " class="GCS20"/></td>  
                </tr>
                <tr>
                    <td colspan="11" class="textLeft"  style="background:#f2f2f2"><input type="text" name="name" value=" 设备管理和设计:" /></td>
                      <%-- 工程师 --%>
                     
                    <td><input type="text" name="name" value=" "class="GCS21" /></td>
                    <td><input type="text" name="name" value=" "class="GCS22" /></td>
                    <td><input type="text" name="name" value=" "class="GCS23" /></td>
                    <td><input type="text" name="name" value=" " class="GCS24"/></td>
                    <td><input type="text" name="name" value=" "class="GCS25" /></td>
                    <td><input type="text" name="name" value=" " class="GCS26"/></td>
                    <td><input type="text" name="name" value=" " class="GCS27"/></td>
                    <td><input type="text" name="name" value=" " class="GCS28"/></td>
                    <td><input type="text" name="name" value=" "class="GCS29" /></td>
                    <td><input type="text" name="name" value=" " class="GCS30"/></td>
                </tr>
                <tr>
                    <td colspan="3"><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " class="SBGL0"/></td>
                    <td><input type="text" name="name" value=" "  class="SBGL1"/></td>
                    <td><input type="text" name="name" value=" "  class="SBGL2"/></td>
                    <td><input type="text" name="name" value=" "  class="SBGL3"/></td>
                    <td><input type="text" name="name" value=" "  class="SBGL4"/></td>
                    <td><input type="text" name="name" value=" "  class="SBGL5"/></td>
                    <td><input type="text" name="name" value=" "  class="SBGL6"/></td>
                    <td><input type="text" name="name" value=" "  class="SBGL7"/></td>
                    <td rowspan="5"  style="background:#f2f2f2"><input type="text" name="name" value=" 操作员" /></td>
                    <td><input type="text" name="name" value=" " class="CZY0"/></td>
                    <td><input type="text" name="name" value=" " class="CZY1"/></td>
                    <td><input type="text" name="name" value=" " class="CZY2"/></td>
                    <td><input type="text" name="name" value=" " class="CZY3" /></td>
                    <td><input type="text" name="name" value=" " class="CZY4"/></td>
                    <td><input type="text" name="name" value=" " class="CZY5"/></td>
                    <td><input type="text" name="name" value=" " class="CZY6"/></td>
                    <td><input type="text" name="name" value=" " class="CZY7" /></td>
                    <td><input type="text" name="name" value=" " class="CZY8"/></td>
                    <td><input type="text" name="name" value=" " class="CZY9" /></td>
                </tr>
                <tr>
                    <td colspan="11"  style="background:#f2f2f2" class="textLeft"><input type="text" name="name" value=" 厂区停放设备" /></td>
                    <td><input type="text" name="name" value=" " class="CZY10"/></td>
                    <td><input type="text" name="name" value=" " class="CZY11"/></td>
                    <td><input type="text" name="name" value=" " class="CZY12"/></td>
                    <td><input type="text" name="name" value=" " class="CZY13"/></td>
                    <td><input type="text" name="name" value=" " class="CZY14"/></td>
                    <td><input type="text" name="name" value=" " class="CZY15"/></td>
                    <td><input type="text" name="name" value=" " class="CZY16"/></td>
                    <td><input type="text" name="name" value=" " class="CZY17"/></td>
                    <td><input type="text" name="name" value=" " class="CZY18"/></td>
                    <td><input type="text" name="name" value=" " class="CZY19"/></td>
                </tr>
                <tr>
                    <td colspan="11"  style="background:#f2f2f2" class="textLeft"><input type="text" name="name" value=" 住 房:(共 间： 大、 小 )" /></td>
                    <td><input type="text" name="name" value=" " class="CZY20"/></td>
                    <td><input type="text" name="name" value=" " class="CZY21"/></td>
                    <td><input type="text" name="name" value=" "class="CZY22" /></td>
                    <td><input type="text" name="name" value=" "class="CZY23" /></td>
                    <td><input type="text" name="name" value=" " class="CZY24"/></td>
                    <td><input type="text" name="name" value=" " class="CZY25"/></td>
                    <td><input type="text" name="name" value=" " class="CZY26"/></td>
                    <td><input type="text" name="name" value=" " class="CZY27"/></td>
                    <td><input type="text" name="name" value=" " class="CZY28"/></td>
                    <td><input type="text" name="name" value=" "class="CZY29" /></td>
                </tr>
                <tr>
                    <td colspan="11"><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " class="CZY30"/></td>
                    <td><input type="text" name="name" value=" " class="CZY31"/></td>
                    <td><input type="text" name="name" value=" " class="CZY32"/></td>
                    <td><input type="text" name="name" value=" " class="CZY33"/></td>
                    <td><input type="text" name="name" value=" " class="CZY34"/></td>
                    <td><input type="text" name="name" value=" " class="CZY35"/></td>
                    <td><input type="text" name="name" value=" " class="CZY36"/></td>
                    <td><input type="text" name="name" value=" " class="CZY37"/></td>
                    <td><input type="text" name="name" value=" " class="CZY38"/></td>
                    <td><input type="text" name="name" value=" " class="CZY39"/></td>
                </tr>
                <tr>
                    <td colspan="11"><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " class="CZY40"/></td>
                    <td><input type="text" name="name" value=" " class="CZY41"/></td>
                    <td><input type="text" name="name" value=" " class="CZY42"/></td>
                    <td><input type="text" name="name" value=" " class="CZY43"/></td>
                    <td><input type="text" name="name" value=" "class="CZY44" /></td>
                    <td><input type="text" name="name" value=" " class="CZY45"/></td>
                    <td><input type="text" name="name" value=" " class="CZY46"/></td>
                    <td><input type="text" name="name" value=" " class="CZY47"/></td>
                    <td><input type="text" name="name" value=" " class="CZY48"/></td>
                    <td><input type="text" name="name" value=" " class="CZY49"/></td>
                </tr>
                <tr>
                    <td colspan="11" class="textLeft"  style="background:#f2f2f2"><input type="text" name="name" value="地 质 房：(共间：大、小): " /></td>
                    <td  style="background:#f2f2f2"><input type="text" name="name" value=" 实习生" /></td>
                    <%-- 实习生 --%>
                    <td><input type="text" name="name" value=" " class="SXS0"/></td>
                    <td><input type="text" name="name" value=" " class="SXS1"/></td>
                    <td><input type="text" name="name" value=" " class="SXS2"/></td>
                    <td><input type="text" name="name" value=" " class="SXS3"/></td>
                    <td><input type="text" name="name" value=" " class="SXS4"/></td>
                    <td><input type="text" name="name" value=" " class="SXS5"/></td>
                    <td><input type="text" name="name" value=" " class="SXS6"/></td>
                    <td><input type="text" name="name" value=" " class="SXS7"/></td>
                    <td><input type="text" name="name" value=" " class="SXS8"/></td>
                    <td><input type="text" name="name" value=" " class="SXS9"/></td>
                </tr>
                <tr>
                    <td colspan="11"><input type="text" name="name" value=" " /></td>
                    <td rowspan="2" id="DZG1"  style="background:#f2f2f2"><input type="text" name="name" value=" 地质工" /></td>
                    <%-- 地质工 --%>
                    <td><input type="text" name="name" value=" " class="DZG0"/></td>
                    <td><input type="text" name="name" value=" " class="DZG1"/></td>
                    <td><input type="text" name="name" value=" " class="DZG2"/></td>
                    <td><input type="text" name="name" value=" " class="DZG3"/></td>
                    <td><input type="text" name="name" value=" "class="DZG4" /></td>
                    <td><input type="text" name="name" value=" "class="DZG5" /></td>
                    <td><input type="text" name="name" value=" " class="DZG6"/></td>
                    <td><input type="text" name="name" value=" " class="DZG7"/></td>
                    <td><input type="text" name="name" value=" " class="DZG8"/></td>
                    <td><input type="text" name="name" value=" "class="DZG9" /></td>
                </tr>
                <tr>
                    <td id="KF"  style="background:#f2f2f2"><input type="text" name="name" value=" 开发" /></td>
                    <%--<td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>--%>
                    <%-- 地质工 --%>
                    <td id="DZG2"><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" "class="DZG10" /></td>
                    <td><input type="text" name="name" value=" "class="DZG11" /></td>
                    <td><input type="text" name="name" value=" " class="DZG12"/></td>
                    <td><input type="text" name="name" value=" "class="DZG13" /></td>
                    <td><input type="text" name="name" value=" " class="DZG14"/></td>
                    <td><input type="text" name="name" value=" "class="DZG15" /></td>
                    <td><input type="text" name="name" value=" " class="DZG16"/></td>
                    <td><input type="text" name="name" value=" " class="DZG17"/></td>
                    <td><input type="text" name="name" value=" " class="DZG18"/></td>
                </tr>
            </table>
        </div>
        
	</div>
</div>
<script src="../../Scripts/layui/layui.js"></script>
<script src="../../Scripts/LQZY/LQ_RYSB.js"></script>
    <script>
       
        //头部定位
        $(function () {
            //$("#tableContent").scroll(function () {
            //    var scrollLeft = $("#tableContent").scrollLeft();
            //    $(".table_padding").css("left", -scrollLeft + "px")
            //    var scrollTop = $("#tableContent").scrollTop();              
            //    if (scrollLeft > 0) {
            //        $(".table_padding").css({
            //            "margin-left": "1px",
                        
            //        })
            //    }
            //})
            //点击调整td的width
            $("#noDataList td").on("click", "input", function () {
                var $this = $(this);
                var itemWidth = parseFloat($this.css("width"));
               
            })
            //select option  去掉全部
            $("#SELECT_OPTION").change(function () {
                  $("#Qb").css("display", "block")
                  if ($("#SELECT_OPTION option:selected").text() == "全部") {
                        $("#Qb").css("display","none")
                  }
            })
            //日期时间的width
            $(".textbox").css("width","121px")
            $(".textbox .textbox-text").css({
                
                "margin-right": "71px"
                
            })
        })
       $("#selection option").val("全部")
        $(document).ready(function () {
            var height = $(window).height() - $('#tableContent').offset().top - $(document).scrollTop()-200;
            console.log(height)
            $('#tableContent').css({ 'height': height+ 'px' });
            $('#tableContent').css({ 'height': height - 2 + 'px', 'border-bottom': '1px solid #95B8E7', 'position': 'relative' });
        });


        $(window).resize(function () {
            var height = $(window).height() - $('#tableContent').offset().top - $(document).scrollTop();
            $('#tableContent').css({ 'height': height + 'px' });
            $('#tableContent').css({ 'height': height - 2 + 'px', 'border-bottom': '1px solid #95B8E7', 'position': 'relative' });
        });

        setTimeout(function () {
            $(".tableBody table").css("border", "none")
            $(".tableBody table").each(function () {
                $(this).find("tr").not(":has(td)").html('<td><input type="text" name="" value="" /></td>')
                $(this).find("td").css({ "border-top": "none", "border-bottom": "none" });
                $(this).find("td:first").css("border-left", "none");
                $(this).find("td:last").css("border-right", "none")
                console.log()
            })
            
        }, 300)
    </script>
    <script>
        window.onload = function () {
            SetCurrentTime();
        }
        //设置日期显示格式
        formatterDate = function (date) {

            var day = date.getDate() > 9 ? date.getDate() : "0" + date.getDate();

            var month = (date.getMonth() + 1) > 9 ? (date.getMonth() + 1) : "0"

                + (date.getMonth() + 1);

            return date.getFullYear() + '-' + month + '-' + day;

        }

        //设置日期为当前日期
        var timer = '';
        function SetCurrentTime() {

            $('#datecheckbox').datebox('setValue', formatterDate(new Date()));
            console.log($('#datecheckbox').datebox('setValue', formatterDate(new Date())).val())
            timer = $('#datecheckbox').datebox('setValue', formatterDate(new Date())).val()
        }
        function onSelect(date) {
            $('#result').text(date)
        }
      //  $('.layui-table').append('<tfoot>1</tfoot>')
    </script>
    <script>
        /*$(function () {
            var contentWidth = parseInt($("#RYSB").css("width"));
            $(".table_padding #dataList_top").css({"width":contentWidth,"padding":"0 30px"})
        })*/
      
    </script>
</body>
</html>
