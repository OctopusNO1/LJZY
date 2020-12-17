<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LQ_RYSB_BF.aspx.cs" Inherits="LJZY.WEB.Page.DJSJ.LQ_RYSB_BF" %>

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
    </style>
</head>
<body  style="margin:0 auto;">
    <script>
    </script>
<div class="easyui-tabs" data-options="fit:true,plain:true" style="overflow:auto">
    <!--生产动态报表-->
    <div id="RYSB" title="人员设备">  
        <%--<div style="text-align:center;padding-top:20px">
            <h1>
                <input type="text" name="name" value="第一项目经理部人员及设备动态表" style="width:100%"/></h1>
        </div>
        <div style="text-align:right;padding-right:220px">
            <h4>2018.7.11</h4>
        </div>--%>
        

        <div class="table_padding" style="width:2816px;height:123px">   
            <table id="dataList_top">
              
                <thead>
                    <tr class="tableTitle">
                        <th colspan="16">
                            <input type="text" name="name" value="人员及设备动态表" id="RYSBTitle"/>
                        </th>
                    </tr>
                    <tr class="tableTitle">
                        <th>
                            <span>录井项目部</span>
                        </th>
                        <th style="width:90px;">
                            <select id="SELECT_OPTION" v-model="XMBName" style="width:90px;">
                                     
                                      <option value="" style="display:none" id="Qb">全部</option>
                                     <option v-for="val in XMBList" v-bind:value="val.NAME" >{{val.NAME}}</option>
                                 
                            </select>
                        </th>

                    <th>
                            <span>日期</span>
                    </th>
                    <th>
                        <input class="easyui-datebox" id="datecheckbox" style="width:100px; height: 17px" data-options="onSelect:onSelect" v-model="changeDATA" />
                    </th>
                        <th>
                        <button  class="Commit" id="Commit" v-on:click="CommitData">提交</button>
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
                <tbody class="tableBody">
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
                        <th style="width:128px;box-sizing:border-box;"> 工程师</th>
                        <th style="width:384px;box-sizing:border-box;">操作员</th>
                        <th style="width:512px;box-sizing:border-box;">地质工</th>
                        <th style="width:256px;box-sizing:border-box;">住房</th>
                        <th style="width:128px;box-sizing:border-box;">地质房</th>
                        <th style="width:128px;box-sizing:border-box;">设备所在地</th>
                    </tr>
                </tbody>
         
        </table>
   </div> 






        <div style="padding:0 30px;overflow: auto;" id="tableContent">
            
            
           
            <table id="dataList">
                <thead>
                    <tr>
                        <td colspan="16" style="height: 100px;"></td>
                    </tr>

                </thead>
                  <%--<thead>
                    <tr class="tableTitle">
                        <th colspan="20">
                            <input type="text" name="name" value="人员及设备动态表"/>
                        </th>
                    </tr>
                    <tr class="tableTitle">
                        <th style="width:100px">
                            <span>录井项目部</span>
                        </th>
                        <th>
                            <select style="width:120px;"  id="seletion">
                                <option style="display:none">全部</option>
                                <option v-for="val in XMBList" v-bind:value="val.NAME" id="selectItem">{{val.NAME}}</option>
                            </select>
                        </th>

                    <th>
                            <span>日期</span>
                    </th>
                    <th>
                        <input class="easyui-datebox" id="datecheckbox1" style="width: 140px; height: 17px" data-options="onSelect:onSelect" />
                    </th>
                        <th colspan="20" style="text-align:right">
                            <a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" onclick="exportExcel();" style="height: 25px;
    width: 60px;">导出
                                 <iframe id="ExportIframe1" class="J_iframe" name="iframe0" width="100%" height="100%" src="" frameborder="0" data-id="DownLoad.aspx"
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
                    </thead>--%>
                <tbody class="tableBody" id="LAY_demo2">
                    
                    <tr>
                        <th colspan="16" style="height:21px;"></th>
                        <%--<th style="height:18px;">序号</th>
                        <th>自编号</th>
                        <th>队号</th>
                        <th>仪器型号</th>
                        <th>正录井</th>
                        <th>钻井队</th>
                        <th>设备状态</th>
                        <th>待录井</th>
                        <th>地质师</th>
                        <th>地质助理</th>
                        <th>工程师</th>
                        <th>操作员</th>
                        <th>地质工</th>
                        <th>住房</th>
                        <th>地质房</th>
                        <th>设备所在地</th>--%>
                    </tr>
                    <tr v-for="(val,index) in list">
                        <td style="width: 50px;">
                                    <input type="text" name="name" :value="++index"   />
                        </td>
                        <td  style="width: 50px" >
                                    <input type="text" name="name" :value="val.DWZBH"   />
                        </td>
                        <td  style="width: 50px" >
                                    <input type="text" name="name" :value="val.LJDH"   />
                        </td>
                        <td   style="width:50px">
                                    <input type="text" name="name" :value="val.LJYQXH"   />
                        </td>
                        <td  style="width: 50px">
                                    <input type="text" name="name" :value="val.JH"   />
                        </td>
                        <td  style="width: 50px"  >
                                    <input type="text" name="name" :value="val.SGDH"   />
                        </td>
                        <td   style="width: 50px" >
                                    <input type="text" name="name" :value="val.DQZT"   />
                        </td>
                        <td  style="width:50px"  >
                                    <input type="text" name="name" :value="val.HXJW"   />
                        </td>
                        <td  style="width: 50px" >
                            <table>
                                <tr>
                                    <%--<td v-for="valdzs in val.DzsList">
                                                <input type="text" name="name" :value="valdzs.XM"   />
                                    </td>--%>
                                    <td>
                                        <input type="text" name="name" :value="val.DzsList.length > 0 ? val.DzsList[0].XM :'' "   />
                                    </td>
                                </tr>
                            </table>
                            
                        </td>

                        <td  style="width:50px" >
                            <table>
                                <tr>
                                    <%--<td v-for="valdzz in val.DzzlList">
                                                <input type="text" name="name" :value="valdzz.XM"   />
                                    </td>--%>
                                    <td>
                                        <input type="text" name="name" :value="val.DzzlList.length > 0 ? val.DzzlList[0].XM : ''"   />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td  style="width:50px" >
                            <table>
                                <tr>
                                    <%--<td v-for="valgcs in val.GcsList">
                                                <input type="text" name="name" :value="valgcs.XM"   />
                                    </td>--%>
                                    <td>
                                        <input type="text" name="name" :value="val.GcsList.length > 0 ? val.GcsList[0].XM :''"   />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td  style="width:150px;" >
                            <table>
                                <tr>
                                    <%--<td v-for="valczy in val.CzyList">
                                                <input type="text" name="name" :value="valczy.XM"   />
                                    </td>--%>
                                    <td style="border-right:1px solid #000;">
                                        <input type="text" name="name" :value="val.CzyList.length > 0 ? val.CzyList[0].XM :''"   />
                                    </td>
                                    <td style="border-right:1px solid #000;">
                                        <input type="text" name="name" :value="val.CzyList.length > 1 ? val.CzyList[1].XM :''"   />
                                    </td>
                                    <td>
                                        <input type="text" name="name" :value="val.CzyList.length > 2 ? val.CzyList[2].XM :''"   />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td  style="width:200px;"  >
                            <table>
                                <tr>
                                    <%--<td  v-for="valdzg in val.DzgList">
                                                <input type="text" name="name" :value="valdzg.XM"   />
                                    </td>--%>
                                    <td style="border-right:1px solid #000;">
                                        <input type="text" name="name" :value="val.DzgList.length > 0 ? val.DzgList[0].XM :''"   />
                                    </td>
                                    <td style="border-right:1px solid #000;">
                                        <input type="text" name="name" :value="val.DzgList.length > 1 ? val.DzgList[1].XM:''"   />
                                    </td>
                                    <td style="border-right:1px solid #000;">
                                        <input type="text" name="name" :value="val.DzgList.length > 2 ? val.DzgList[2].XM :''"   />
                                    </td>
                                    <td>
                                        <input type="text" name="name" :value="val.DzgList.length > 3 ? val.DzgList[3].XM:''"   />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td   style="width: 100px;" >
                            <table>
                                <tr>
                                    <%--<td  v-for="valzf in val.ZfList">
                                                <input type="text" name="name" :value="valzf.XM"   />
                                    </td>--%>
                                    <td style="border-right:1px solid #000;">
                                        <input type="text" name="name" :value="val.ZfList.length > 0 ? val.ZfList[0].CCBH:''"   />
                                    </td>
                                    <td>
                                        <input type="text" name="name" :value="val.ZfList.length > 1 ? val.ZfList[1].CCBH:''"   />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:50px">
                            <table >
                                <tr>
                                    <%--<td  v-for="valdzf in val.DzfList">
                                                <input type="text" name="name" :value="valdzf.GGXH"   />
                                    </td>--%>
                                    <td>
                                        <input type="text" name="name" :value="val.DzfList.length > 0 ? val.DzfList[0].CCBH:''"   />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width:50px" >
                                    <input type="text" name="name" :value="val.SBSZD"   />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width:16%">
                            <input type="text" name="name" value="合计：" />
                        </td>
                        <td style="width:5.35%">
                            <input type="text" name="name" v-model="count.LJDHCount" />
                        </td>
                        <td style="width:9.38%">
                            <input type="text" name="name" v-model="count.LJYQXHCount" />
                        </td>
                        <td style="width:10.14%">
                            <input type="text" name="name" v-model="count.LJYQXHCount" />
                        </td>
                        <td>
                            <input type="text" name="name" v-model="count.ZJHCount" />
                        </td>
                        <td>
                            <input type="text" name="name" v-model="count.DQZTCount"/>
                        </td>
                        <td>
                            <input type="text" name="name" v-model="count.HXJWCount" />
                        </td>
                        <td>
                            <input type="text" name="name" v-model="count.DzsListCount" />
                        </td>
                        <td>
                            <input type="text" name="name" v-model="count.DzzlListCount" />
                        </td>
                        <td>
                            <input type="text" name="name" v-model="count.GcsListCount" />
                        </td>
                        <td>
                            <input type="text" name="name" v-model="count.CzyListCount" />
                        </td>
                        <td>
                            <input type="text" name="name" v-model="count.DzgListCount" />
                        </td>
                        <td>
                            <input type="text" name="name" v-model="count.ZfListCount" />
                        </td>
                        <td>
                            <input type="text" name="name" v-model="count.DzfListCount" />
                        </td>
                        <td>
                            <input type="text" name="name" v-model="count.ZHCount" />
                            </td>
                    </tr>
                </tbody>
            </table>
            <div style ="position: relative;top: -20px;left: 86px;display:none">
                <textarea style=" width:100px;height:100px;">content</textarea>
            </div>
            <table id="noDataList">
                <tr>
                    <td colspan="8" class="textLeft"><input type="text" name="name" value=" 领导:" /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td colspan="11"><input type="text" name="name" value=" 基地轮休人员" /></td>
                </tr>
                <tr>
                    <td colspan="3"><input type="text" name="name" value=" " /></td>
                    <td>
                        <input type="text" name="name" value=" " />
                    </td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td rowspan="3"><input type="text" name="name" value=" 地质师" /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td colspan="11" class="textLeft"><input type="text" name="name" value=" 责任师:" /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td colspan="3"><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td colspan="11" class="textLeft"><input type="text" name="name" value=" 经管员:" /></td>
                    <td rowspan="3"><input type="text" name="name" value=" 工程师" /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td colspan="3"><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td colspan="11" class="textLeft"><input type="text" name="name" value=" 设备管理和设计:" /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td colspan="3"><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td rowspan="5"><input type="text" name="name" value=" 操作员" /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td colspan="11" class="textLeft"><input type="text" name="name" value=" 厂区停放设备" /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td colspan="11" class="textLeft"><input type="text" name="name" value=" 住 房:(共 间： 大、 小 )" /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td colspan="11"><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td colspan="11"><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td colspan="11" class="textLeft"><input type="text" name="name" value="地 质 房：(共间：大、小): " /></td>
                    <td><input type="text" name="name" value=" 实习生" /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td colspan="11"><input type="text" name="name" value=" " /></td>
                    <td rowspan="2"><input type="text" name="name" value=" 地质工" /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td><input type="text" name="name" value=" 开发" /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td rowspan="2"><input type="text" name="name" value="代管 " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                </tr>
                <tr>
                    <td colspan="5"><input type="text" name="name" value="注:红色为当日变动；[实习生]" /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
                    <td><input type="text" name="name" value=" " /></td>
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
            $("#tableContent").scroll(function () {
                var scrollLeft = $("#tableContent").scrollLeft();
                $(".table_padding").css("left", -scrollLeft + "px")
                var scrollTop = $("#tableContent").scrollTop();              
                if (scrollLeft > 0) {
                    $(".table_padding").css({
                        "margin-left": "1px",
                        
                    })
                }
            })
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
            var height = $(window).height() - $('#tableContent').offset().top - $(document).scrollTop();
            $('#tableContent').css({ 'height': height + 'px' });
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
        
    </script>
    <script>
        /*$(function () {
            var contentWidth = parseInt($("#RYSB").css("width"));
            $(".table_padding #dataList_top").css({"width":contentWidth,"padding":"0 30px"})
        })*/
        
    </script>
</body>
</html>
