<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LQ_LJXM.aspx.cs" Inherits="LJZY.WEB.Page.DJSJ.LQ_LJXM" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>    
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["theme"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["icon"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["demo"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/layui/css/layui.css" rel="stylesheet" />
    <link href="../../CSS/LQ_LJXM.css" rel="stylesheet" /> 
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["jquery"].ToString()%>" type="text/javascript"></script>
    <script src="../../Scripts/layui/layui.js"></script>
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-min"].ToString()%>" type="text/javascript"></script>
     <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-zh_CN"].ToString()%>" type="text/javascript"></script>
    <script src="../../Scripts/LQZY/LQ_LJXM.js"></script>  
    <script type="text/javascript">
       
        //$(function () {
        //    var Btable_width = $("datagrid-btable").css("width")
        //    console.log(Btable_width)
        //    //$(".datagrid-htable").css("width","1213"+"px")
        //})

       
    </script>
     <script>
         var pc;
         $.parser.onComplete = function () {
             if (pc) clearTimeout(pc);
             pc = setTimeout(closes, 500);
         }

         function closes() {
             $('#loading').fadeOut('normal', function () {
                 $(this).remove();
             });
         }
         var Type = getUrlParam('type');
         function getUrlParam(name) {
             var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
             var r = window.location.search.substr(1).match(reg);  //匹配目标参数
             if (r != null) return unescape(r[2]); return null; //返回参数值
         }
         console.log(Type)
</script>
    <style>
        .datagrid-btable {
            width: 1213px;
        }

        .datagrid-view2 .datagrid-htable {
            width: 1213px;
        }

        .datagrid-btable {
            width: 676px;
        }

        .datagrid-view2 .datagrid-htable {
            width: 676px;
        }

        #See .datagrid-view2 .datagrid-header {
            height: 34px;
        }

        #See .datagrid-view {
            height: 300px;
        }
    </style>
</head>
<body class="easyui-layout">
                <div id="loading" style="position:absolute;z-index:1000;top:0px;left:0px;width:100%;height:100%;background:#ffffff;text-align :center;padding-top:20%;">
     <h3><font color="#242b5f">加载中....</font></h3>
</div> 
    <%--<div data-options="region:'west',split:true" title="菜单" style="width: 200px;overflow-y:auto;display:none;">
        <ul id="tt" class="easyui-tree">
        </ul>
        <span id="treeVal" style="display:none;"></span>
    </div>--%>
    <div data-options="region:'center',iconCls:'icon-ok',border:false" >
        <div class="easyui-tabs" data-options="fit:true,plain:true">
            <div title="录井查询">
                <div class="contentbox">
                    <div style="height: 40px;background: #e3efff;padding:5px 0 0 6px;box-sizing:border-box">
                        <button class="easyui-linkbutton btnGetType" onclick="Showdailog()">选择字段</button>
                        <input id="SelectColumn_List" class="easyui-combobox" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=LJXM_ZD',
					    method:'post',
					    valueField:'CODE',
					    textField:'NAME',
                        editable:false,
                        value:'ZJH'" style="width:150px"/>
                        <input id="Symbol_List" class="easyui-combobox" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=Symbol_List',
					    method:'post',
					    valueField:'CODE',
					    textField:'NAME',
                        editable:false,
                        value:'='" style="width:70px"/>
                        <input class="easyui-textbox" data-options="prompt:'请输入关键词...'" style="width:100px" id="isvalue"/>
                        <input type="checkbox" id="chkbox" /><span>OR</span>
                        <button class="easyui-linkbutton btnGetType" onclick="addTJ();" >添加条件</button>                   
                        <div id="SelectWhere"></div>              
                        <button class="easyui-linkbutton btnGetType" onclick="doSearch1();" id="sousuo">搜索</button>
                         <button class="easyui-linkbutton btnGetType" onclick="importbtn();" id="import">导入</button>
                        <%-- <button class="easyui-linkbutton btnGetType" onclick="exportbtn();" id="export">导出</button>--%>
                        <a class="easyui-linkbutton btnGetType" id="daochu_one" onclick="exportExcel()">导出<iframe id="ExportIframe" class="J_iframe" name="iframe0" width="100%" height="100%" src="" frameborder="0" data-id="DownLoad.aspx" seamless="" style="display: none;"></iframe></a>
                    </div>
                    <div  title="DataGrid" id="designSelect" border-style: "none" data-options="closable:true;fit:false">
                        <div style="padding:0px 3px 0 1px;" >                 
                           <%-- <table id="dg" class="easyui-datagrid" style="width:100%;height:100%;overflow:scroll;">                      
                            </table>--%>
                            <table id="dg" class="easyui-datagrid" style="width:100%;height:100%;overflow:scroll;" >
                                <thead>
                                    <tr>                                        
                                        <th data-options="field:'SC3',align:'center',width:160,sortable:true">甲方单位</th>
                                        <th data-options="field:'SC2',align:'center',width:80,sortable:true">地区</th>
                                        <th data-options="field:'QK',align:'center', width:80,sortable:true">区块</th>
                                        <th data-options="field: 'ZJH', align:'center', width:80,sortable:true">井号</th>
                                        <th data-options="field: 'REPORT_TYPE',align:'center',width:60,sortable:true">井别</th>
                                        <th data-options="field: 'JX',align:'center',width:100,sortable:true">井型</th>
                                        <th data-options="field: 'JH',align:'center', width:80,sortable:true">井筒号</th>
                                        <th data-options="field: 'LJXL',align:'center', width:80,sortable:true">录井系列</th>
                                        <th data-options="field: 'SJJS',align:'center',width:80,sortable:true">设计井深</th>
                                        <th data-options="field: 'JSSJJS',align:'center', width:120,sortable:true">加深设计井深</th>
                                        <th data-options="field: 'SCFL',align:'center',width:120,sortable:true">市场类型</th>
                                        <th data-options="field: 'GJ',align:'center',width:80,hidden:false,sortable:true">国家</th>
                                        <th data-options="field: 'SC1',align:'center',width:120,hidden:false,sortable:true">一级市场</th>
                                        <th data-options="field: 'DZJDXM',align:'center',width:120,hidden:false,sortable:true">地质监督姓名</th>
                                        <th data-options="field: 'DZJDZJH',align:'center',width:120,hidden:false,sortable:true">地质监督证件号</th>
                                        <th data-options="field: 'DZJDSSGS',align:'center',width:120,hidden:false,sortable:true">地质监督所属公司</th>
                                        <th data-options="field: 'ZJJDXM',align:'center',width:120,hidden:false,sortable:true">钻井监督姓名</th>
                                        <th data-options="field: 'ZJJDZJH',align:'center',width:120,hidden:false,sortable:true">钻井监督证件号</th>
                                        <th data-options="field: 'ZJJDSSGS',align:'center',width:120,hidden:false,sortable:true">钻井监督所属公司</th>
                                        <th data-options="field: 'LJFGS',align:'center',width:120,hidden:false,sortable:true">录井项目部</th>
                                        <th data-options="field: 'LJDWZZ',align:'center',width:120,hidden:false,sortable:true">录井资质</th>
                                        <th data-options="field: 'LJDH',align:'center',width:120,hidden:false,sortable:true">录井队号</th>
                                        <th data-options="field: 'LJYQXH',align:'center',width:120,hidden:false,sortable:true">设备型号</th>
                                        <th data-options="field: 'YQZZ',align:'center',width:120,hidden:false,sortable:true">仪器资质</th>
                                        <th data-options="field: 'DWZBH',align:'center',width:120,hidden:false,sortable:true">队伍自编号</th>
                                        <th data-options="field: 'DZS',width:120,align:'center',hidden:false,sortable:true">地质师</th>
                                        <th data-options="field: 'STARSTART_DG',align:'center',width:120,hidden:false,sortable:true">装卫星时间</th>
                                        <th data-options="field: 'STARAZR',align:'center',width:120,hidden:false,sortable:true">安装卫星人</th>
                                        <th data-options="field: 'STAREND_DG',align:'center',width:120,hidden:false,sortable:true">拆卫星时间</th>
                                        <th data-options="field: 'STARCCR',align:'center',width:120,hidden:false,sortable:true">拆卫星人</th>
                                        <th data-options="field: 'SGDW',align:'center',width:160,hidden:false,sortable:true">施工单位</th>
                                        <th data-options="field: 'SGDH',align:'center',width:120,hidden:false,sortable:true">施工队号</th>
                                        <th data-options="field: 'YJBASJ_DG',align:'center',width:120,hidden:false,sortable:true">预计搬安时间</th>
                                        <th data-options="field: 'SJBASJ_DG',align:'center',width:120,hidden:false,sortable:true">实际搬安时间</th>
                                        <th data-options="field: 'BQJL',align:'center',width:120,hidden:false,sortable:true">搬迁距离</th>
                                        <th data-options="field: 'HQSJ_DG',align:'center',width:120,hidden:false,sortable:true">回迁时间</th>
                                        <th data-options="field: 'DQZT',align:'center',width:120,hidden:false,sortable:true">当前状态</th>
                                        <th data-options="field: 'CHOUXIYOU',align:'center',width:120,hidden:false,sortable:true">稠油/稀油</th>
                                        <th data-options="field: 'HXJW',align:'center',width:120,hidden:false,sortable:true">后续井位</th>
                                        <th data-options="field: 'HXJDH',align:'center',width:120,hidden:false,sortable:true">后续井队号</th>
                                        <th data-options="field: 'JDDT',align:'center',width:120,hidden:false,sortable:true">井队动态</th>
                                        <th data-options="field: 'LSDW',align:'center',width:120,hidden:false,sortable:true">隶属单位</th>
                                        <th data-options="field: 'XMBJWXX',align:'center',width:120,hidden:false,sortable:true">项目部井位信息</th>
                                        <th data-options="field: 'PGZDTS',align:'center',width:120,hidden:false,sortable:true">派工重点提示</th>
                                        <th data-options="field: 'DRJS',align:'center',width:120,hidden:false,sortable:true">当前井深</th>
                                        <th data-options="field: 'SGZT',align:'center',width:120,hidden:false,sortable:true">当前动态</th>
                                        <th data-options="field: 'BZ',align:'center',width:120,hidden:false,sortable:true">备注</th>
                                    </tr>
                                </thead>
                            </table>
                        </div>
                    </div>
                </div>     
            </div>

            <div title="录井入库">
                <div class="contentbox" style="height:842px;overflow:auto;">
                    <div style="height: 80px;">
                        <table style="width:860px;background: #C4D6EE;margin: 20px auto;">
                            <tr>
                                <%--<td style="padding-right: 20px"><button  class="easyui-linkbutton btnAdd" onclick="clearForm()" style="background:url(/Image/add.png) no-repeat center center;"></button></td>--%>
                                <td style="padding-right: 20px"><button  class="easyui-linkbutton btnShou" onclick="loadRemote_Home()" style="background:url(/Image/shou.png) no-repeat center center;"></button></td>
                                <td style="padding-right: 20px"><button  class="easyui-linkbutton btnShang" onclick="loadRemote_Up()" style="background:url(/Image/shang.png) no-repeat center center;"></button></td>
                                <td style="padding-right: 20px"><button  class="easyui-linkbutton btnXia" onclick="loadRemote_Down()" style="background:url(/Image/xia.png) no-repeat center center;"></button></td>
                                <td style="padding-right: 20px"><button  class="easyui-linkbutton btnWei" onclick="loadRemote_End()" style="background:url(/Image/wei.png) no-repeat center center;"></button></td>
                                <td style="padding-right: 20px"><button  class="easyui-linkbutton btnDel" onclick="delForm()" style="background:url(/Image/del.png) no-repeat center center;"></button></td>
                            </tr>
                        </table>
                    </div>
                    <div class="bdbox">
                         <form id="ff" method="post" data-options="novalidate:true">
                            <div style="width:860px;margin: 0 auto;position:relative">
                                <table style="border-collapse:inherit;border-spacing:4px;">
                                    <tr>
                                        <td class="bx" style="background: #F1EFE2;">甲方单位</td>
                                        <td style="border:none;">
                                            <input id="List_SC3" name="SC3" class="easyui-combobox" data-options="
                                                url:'../../Controllers/ColumnListController.ashx?action=List_SC3',
					                            method:'post',
					                            valueField:'NAME',
					                            textField:'NAME',
                                                editable:false,
                                                value:'勘探公司'" style="height: 32px;"/>
                                        </td>
                                        <td class="bx">井筒号</td>
                                        <td>
                                            <input name="List_JH" id="List_JH" class="easyui-combobox" style="height: 32px" />
                                        </td>
                                        <td style="display:none;">
                                            <input name="ID" id="txtID" value="" style="height: 32px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" style="height:20px">
                                            <a style="width:100%;display:inline-block;border-top: 2px solid #436C9F;padding-bottom: 3px;"></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="bx">井号</td>
                                        <td>
                                            <input name="ZJH" id="txtZJH" class="easyui-textbox" style="height: 32px" data-options="required:true" />

                                        </td>
                                        <td class="bx">井筒号</td>
                                        <td>
                                            <input name="JH" id="txtJH" class="easyui-textbox" style="height: 32px" data-options="required:true" />
                                        </td>
                                        <td class="bx">地区</td>
                                        <td>
                                            <input name="SC2" id="List_SC2" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_SC2',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:false,
                        value:'西北缘'" />
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td class="bx">井型</td>
                                        <td>
                                                <input name="JX" id="List_JX" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_JX',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:false,
                        value:'直井'" />
                                        </td>
                                        <td class="bx">井别</td>
                                        <td>
                                            <input name="REPORT_TYPE" id="List_TYPE" class="easyui-combobox" style=" height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_TYPE',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:false" />
                                        </td><td class="bx">录井项目部</td>
                                        <td>
                                            <input name="LJFGS" id="List_LJFGS" class="easyui-combobox" style=" height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_LJFGS',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:false,
                        value:'第一项目部'" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="bx">区块</td>
                                        <td>
                                            <input name="QK" id="List_QK" class="easyui-combobox" style=" height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_QK',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:'玛湖'" />
                                        </td>
                                        <td class="bx">国家</td>
                                        <td>
                                            <input name="GJ" id="List_GJ" class="easyui-combobox" style=" height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_GJ',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:'中国'" />
                                        </td>
                                        <td class="bx">设计井深</td>
                                        <td>
                                            <input name="SJJS" id="numSJJS" class="easyui-numberbox" style="height: 32px" data-options="max:99999,precision:2" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="bx">加深设计井深</td>
                                        <td>
                                            <input name="JSSJJS" id="numJSSJJS" class="easyui-numberbox" style=" height: 32px" data-options="max:99999,precision:2"/>
                                        </td>
                                        <td class="bx">市场类型</td>
                                        <td>
                                            <input name="SCFL" id="List_SCFL" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_SCFL',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:'集团内本油区'" />
                                        </td>
                                        <td class="bx">一级市场</td>
                                        <td>
                                            <input name="SC1" id="List_SC1" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_SC1',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:'中石油'" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="bx">当前井深</td>
                                        <td> <input class="easyui-numberbox" name="DRJS" style="height: 32px" data-options="max:99999,precision:2" /></td>
                                        <td class="bx">当前动态</td>
                                        <td> <input class="easyui-textbox" name="SGZT" style="height: 32px"  /></td>
                                        <td class="bx">地质监督姓名</td>
                                        <td>
                                            <input name="DZJDXM" class="easyui-textbox" style=" height: 32px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="bx">地质监督证件号</td>
                                        <td>
                                            <input name="DZJDZJH" class="easyui-textbox" style=" height: 32px" />
                                        </td>
                                        <td class="bx">地质监督所属公司</td>
                                        <td>
                                             <input name="DZJDSSGS" id="List_DZJDSSGS" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_DZJDSSGS',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:''" />
                                        </td>
                                          <td class="bx">录井资质</td>
                                        <td>
                                            <input name="LJDWZZ" class="easyui-textbox" style="height: 32px" />
                                        </td>
                                    </tr>
                                    <tr>
                                      
                                        <td class="bx">钻井监督姓名</td>
                                        <td>
                                            <input name="ZJJDXM" class="easyui-textbox" style=" height: 32px" />
                                        </td>
                                        <td class="bx">钻井监督证件号</td>
                                        <td>
                                            <input name="ZJJDZJH" class="easyui-textbox" style="height: 32px" />
                                        </td>
                                        <td class="bx">钻井监督所属公司</td>
                                        <td>
                                            <input name="ZJJDSSGS" id="List_ZJJDSSGS" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_ZJJDSSGS',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:''" />
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="bx">录井队号</td>
                                        <td>
                                            <input name="LJDH" id="List_LJDH" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_LJDH',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:'L11011'" />
                                        </td>
                                        <td class="bx">设备型号</td>
                                        <td>
                                           <input name="LJYQXH" id="List_LJYQXH" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_SBXH',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:''" />
                                        </td>
                                                          <td class="bx">仪器资质</td>
                                        <td>
                                            <input name="YQZZ" class="easyui-textbox" style="height: 32px" />
                                        </td>
                                    </tr>
                                    <tr>
                      
                                        <td class="bx">队伍自编号</td>
                                        <td>
                                            <input name="DWZBH" class="easyui-textbox" style="height: 32px" />
                                        </td>
                                        <td class="bx">地质师</td>
                                        <td>
                                            <input name="DZS" class="easyui-textbox" style="height: 32px" data-options="readonly:true"  />
                                        </td>
                                        <td class="bx">装卫星时间</td>
                                        <td>
                                            <input  name="STARSTART" class="easyui-datebox" style=" height: 32px" id="STARSTART" />
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="bx">安装卫星人</td>
                                        <td>
                                            <input name="STARAZR" class="easyui-textbox" style="height: 32px"  />
                                        </td>
                                        <td class="bx">拆卫星时间</td>
                                        <td>
                                            <input  name="STAREND" class="easyui-datebox" style="height: 32px" id="STAREND" />
                                        </td>
                                         <td class="bx">拆卫星人</td   >
                                        <td>
                                            <input name="STARCCR" class="easyui-textbox" style="height: 32px"  />
                                        </td>   
                                    </tr>
                                    <tr>
                                       
                                        <td class="bx">施工单位</td>
                                        <td>
                                            <%--<input name="SGDW" class="easyui-textbox" style="width: 100%; height: 32px" data-options="required:true" />--%>
                                            <input name="SGDW" id="List_SGDW" class="easyui-combobox" style=" height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_SGDW',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:'西部钻探准东钻井公司'" />
                                        </td>
                                        <td class="bx">施工队号</td>
                                        <td>
                                            <%--<input name="SGDH" class="easyui-textbox" style="width: 100%; height: 32px" data-options="required:true" />--%>
                                            <input name="SGDH" id="List_SGDH" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_SGDH',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:'L11029'" />
                                        </td>
                                         <td class="bx">预计搬安时间</td>
                                        <td>
                                            <input  name="YJBASJ" class="easyui-datebox" style="height: 32px" id="YJBASJ" />
                                        </td>
                                    </tr>
                                    <tr>
                                       
                                        <td class="bx">实际搬安时间</td>
                                        <td>
                                            <input  name="SJBASJ" class="easyui-datebox" style="height: 32px" id="SJBASJ" />
                                        </td>
                                        <td class="bx">搬迁距离</td>
                                        <td>
                                            <input name="BQJL" id="numBQJL" class="easyui-numberbox" style=" height: 32px" data-options="max:99999,precision:2" />
                                        </td>
                                        <td class="bx">回迁时间</td>
                                        <td>
                                             <input  name="HQSJ" class="easyui-datebox" style="height: 32px" id="HQSJ"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="bx">当前状态</td>
                                        <td>
                                            <input name="DQZT" id="List_DQZT" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_DQZT',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:'正录'" />
                                        </td>
                                        <td class="bx">稠油/稀油</td>
                                        <td>
                                            <input name="CHOUXIYOU" id="List_CHOUXIYOU" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_CHOUXIYOU',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:'稠油'" />
                                        </td>
                                                                                <td class="bx">后续井位</td>
                                        <td>
                                             <%--<input name="HXJW" id="List_HXJW" class="easyui-combobox" style="width: 100%; height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_HXJW',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:''" />--%>
                                            <input name="HXJW" class="easyui-textbox" style="height: 32px" />
                                        </td>
                                    </tr>
                                    <tr>

                                        <td class="bx">后续井队号</td>
                                        <td>
                                             <%--<input name="HXJDH" id="List_HXJDH" class="easyui-combobox" style="width: 100%; height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_HXJDH',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:''" />--%>
                                            <input name="HXJDH" class="easyui-textbox" style="height: 32px" />
                                        </td>
                                        <td class="bx">井队动态</td>
                                        <td>
                                             <input name="JDDT" id="List_JDDT" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_JDDT',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:'等设备'" />
                                        </td>
                                        <td class="bx">隶属单位</td>
                                        <td>
                                             <input name="LSDW" id="List_LSDW" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_LSDW',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:'广陆'" />
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                        <td class="bx">项目部井位信息</td>
                                        <td>
                                           <%--<input name="XMBJWXX" id="List_XMBJWXX" class="easyui-combobox" style="width: 100%; height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_XMBJWXX',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:''" />           --%>  
                                            <input name="XMBJWXX" class="easyui-textbox" style=" height: 32px" />                   
                                        </td>
                                        <td class="bx">录井系列</td>
                                        <td>
                                            <input name="LJXL" id="List_LJXL" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_LJXL',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:'综合'" />                      
                                        </td>
                                        <td class="bx">辖区项目部</td>
                                        <td>
                                            <input name="XQXMB" id="List_XQXMB" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_XQXMB',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:'第一项目部'" />                      
                                        </td>
                                    </tr>
                       
                                </table>
                                
                                <table style="border-collapse:inherit;">
                                    <tr>
                                        <td>派工重点提示</td>
                                    </tr>
                                    <tr>
                                        <td> 
                                            <input name="PGZDTS" class="easyui-textbox" data-options="multiline:true" value="" style="width:860px;height:100px"/>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <%--<tr>
                                        <td>
                                            <p style="width:100%;height:20px;background:#D0E17D;text-align:right">
                                                <a id="RYPB">查看</a>
                                            </p>
                                        </td>
                                    </tr>--%>
                                    <%--data-options="multiple:true"--%> 
                                </table>
                                    
                                <div id="accordion" class="easyui-accordion"   style="width:860px;margin-left: 4px;">
                                    <div title="人员配备" data-options=""  style="overflow: auto; padding: 10px;position:relative">
                                        <div id="See" style="overflow-x:auto">
                                            <table id="getWorkerL1" class="easyui-datagrid"  style="width:835px;height:300px;overflow-x:auto">
	                                            </table>
                                            <%-- <a onclick="getWorker()" style="position:absolute;top:100px;right:20px;"></a>--%>
                                            <%--<input  class="easyui-textbox workersPB" data-options="multiline:true" value="" style="width:676px;height:100px"/>--%>
                                        </div>    

                                        
                                    </div>
                                    <div title="设备配备" data-options=""  style="overflow: auto;padding: 10px;position:relative">
                                        <div >
                                            <table id="getEquipmentL1" class="easyui-datagrid" style="width:835px;height:300px">
	                                            </table>
                                            <%--<input class="easyui-textbox equipmentPB" data-options="multiline:true" value="" style="width:676px;height:100px"/>--%>
                                            <%--<a onclick="getEquipment()" style="position:absolute;top:100px;right:20px;"></a>--%>
                                        </div>
                                    </div>
                                    <div title="地质房配备" data-options=""  style="overflow: auto;padding: 10px;position:relative">
                                        <div >
                                            <table id="getDZFL1" class="easyui-datagrid" style="width:835px;height:300px">
	                                            </table>
                                            <%--<input class="easyui-textbox dzfPB" data-options="multiline:true" value="" style="width:676px;height:100px"/>--%>
                                           <%-- <a onclick="showDzfModel()"style="position:absolute;top:100px;right:20px;" ></a>--%>
                                        </div>
                                    </div>
                                    <div title="住房配备" style="overflow: auto;padding: 10px;position:relative">
                                        <div >
                                            <table id="getZFL1" class="easyui-datagrid" style="width:835px;height:300px">
	                                            </table>
                                            <%--<input class="easyui-textbox zfPB" data-options="multiline:true" value="" style="width:676px;height:100px"/>--%>
                                           <%-- <a onclick="showZF()" style="position:absolute;top:100px;right:20px;"></a>--%>
                                        </div>
                                    </div>
                                    <div title="库房配备" style="overflow: auto;padding: 10px; position:relative">
                                        <div >
                                            <table id="getKFL1" class="easyui-datagrid" style="width:835px;height:300px">
	                                            </table>
                                            <%--<input class="easyui-textbox kfPB" data-options="multiline:true" value="" style="width:676px;height:100px"/>--%>
                                           <%-- <a onclick="showKF()" style="position:absolute;top:100px;right:20px;"  ></a>--%>
                                        </div>
                                    </div>
                                </div>
                                <div style="margin:10px 0 0 4px;">
                                    <a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" onclick="submitForm();" style="width:92px;line-height:28px;color:#000;">保 存</a>
                                </div>
                                <!--添加人员配备弹窗-->
                                  <div id="SCPG_content" style="min-height:800px;margin:auto;position:absolute;top:750px;right:-185px; display:none;">
                                                      <div class="easyui-panel clear" title="勘探井" style="width:224px;height:310px;padding:10px">
                           
                                                       <div class="react_JH" id="react_JH" style="overflow:hidden;overflow-y:auto;width:200px;overflow-x:auto;height:240px;float:left;border:1px solid #95B8E7;margin-top:20px"></div>
		                            
	                                                </div>
                                                      <div class="easyui-panel clear" title="评价井" style="width:224px;height:330px;padding:10px">
                       
                                                       <div class="react_JH" id="react_JH2" style="overflow:hidden;overflow-y:auto;width:200px;height:240px;float:left;border:1px solid #95B8E7;">
                               
                                                       </div>
		                            
	                                                </div>
                                                      <div  class="easyui-panel clear" title="开发井" style="width:224px;height:330px;padding:10px">
                           
                                                       <div class="react_JH" id="react_JH3"  style="overflow:hidden;overflow-y:auto;width:200px;height:240px;float:left;border:1px solid #95B8E7;"></div>
		                          
	                                                </div>
                                    </div> 
                                 <%--easyui-draggable 拖拽class--%>
                                <div id="workerModel"  class="contentBox " style=";background:white" data-options="handle:'.layui-layer-title'">
                                    <div class="layui-layer-title" style="background:white;padding-bottom:10px;border-bottom: 1px solid #95B8E7;height: 40px;font-size: 14px;padding-left: 20px;line-height: 40px;">人员选择</div>
                                    <div class="layui-form-item" style="background:white;padding-bottom:15px;padding-top:15px;margin-bottom:2%">
                                        <div class="layui-inline" style="margin-left:14%">
                                            <label class="layui-form-label" style="padding:5px 0px;">选择岗位：</label>
                                            <div class="layui-input-inline" style="width:150px">
                                                
                                                <input id="workerGW" name="" class="easyui-combobox" data-options="
                                                    url:'../../Controllers/ColumnListController.ashx?action=List_GWLB',
					                                method:'post',
					                                valueField:'NAME',
					                                textField:'NAME',
                                                    editable:false,
                                                    " style="width:150px;"/>
                                            </div>
                                        </div>
                                        <div class="layui-inline">
                                            <label class="layui-form-label" style="padding:5px 0px;">查询条件：</label>
                                            <div class="layui-input-inline" style="margin-right:20px;">
                                                
                                                <input id="workerTJ" name="" class="easyui-combobox" data-options="
                                                    url:'../../Controllers/ColumnListController.ashx?action=List_RYTJ',
					                                method:'post',
					                                valueField:'CODE',
					                                textField:'NAME',
                                                    editable:false,
                                                    " style="width:150px;"/>
                                            </div>
                                        </div>
                                        <div class="layui-inline">
                                            <input id="keyWords" type="text" name="" class="easyui-textbox" style="width:150px;margin-right:50px;"/>
                                        </div>
                                        <div class="layui-inline">
                                            <a href="#" class="easyui-linkbutton  btnGetType" data-options="iconCls:'icon-search'" style="width:80px" onclick="selectWorkers()">搜索</a>
                                        </div>
                                        <%--<div class="layui-inline">
                                            <button class="layui-btn" data-type="reload">搜索</button>
                                        </div>--%>
                                    </div>
                                         
                                    <h3 style="margin-left:19px;"></h3>
                                    <div style="width:100%;overflow:auto;background:white;margin-left:3%">
                                        <div style="width:1270px;">
                                            <div style="width:520px;display:inline-block;float:left">
                                                <table id="getWorkerL" class="easyui-datagrid" title="在岗人员" style="width:520px;height:370px;">
	                                            </table>
                                            </div>
                                            <div style="width:100px;display:inline-block;float:left;margin-top:5%;text-align: center;">
                                                <p style="font-size:16px;">人员安排</p>
                                                <div class="tableBtn" style="width:90px;height:200px;border:1px solid #e6e6e6;margin-left: 4px;">
                                                     <div>
                                                        <i class="layui-icon layui-icon-left"  style="font-size: 48px; color: #FF5722;margin:30px 20px;display: block;" onclick="CheckDataL()"></i>
                                                    </div>
                                                    <div>
                                                        <i class="layui-icon layui-icon-right"  style="font-size: 48px; color: #1E9FFF;margin:30px 20px;display: block;" onclick="CheckDataR()"></i>
                                                    </div>                                                   
                                                </div>
                                            </div>
                                            <div style="width:520px;display:inline-block;float:left">
                                                <table id="getWorkerR" class="easyui-datagrid" title="待派人员" style="width:520px;height:370px">
	                                            </table>
                                            </div>
                                        </div>
                                    </div>
                                    <span style="position: absolute;top: 6px;right: 6px;">
                                        <a href="javascript:;" onclick="$('#workerModel').hide()" style="display:block;width:15px;height:15px;background:url(../../Scripts/jquery-easyui-1.5.5.2/themes/icons/clear.png) no-repeat center center;"></a>

                                    </span>
                                    <div class="layui-layer-btn layui-layer-btn-c " style="text-align:center;margin: 5px 0;background:white">
                                        <a  href="#" class="easyui-linkbutton btnGetType" style="width:80px" onclick="loadList()">确认</a>
                                    </div>
                                    <div class="modelShow" style="display:block;position:fixed;top:33px;left:201px;background:white;opacity:0.7;width:100%;height:100%;z-index:-1"></div>
                                </div>
                                <!--添加设备配备弹窗-->
                                <div  id="equipmentModel" class="contentBox " data-options="handle:'.layui-layer-title'">
                                    <div class="layui-layer-title" style="background:white;padding-bottom:10px;border-bottom: 1px solid #95B8E7;height: 40px;font-size: 14px;padding-left: 20px;line-height: 40px;">设备选择</div>
                                    <div class="layui-form-item" style="background:white;margin-bottom:0;padding-top:15px;padding-bottom:15px;margin-bottom:2%">
                                        <div class="layui-inline"  style="margin-left:14%">
                                            <label class="layui-form-label" style="padding:5px 0px;">选择设备：</label>
                                            <div class="layui-input-inline" style="width:150px">
                                                
                                                <input id="equipmentFL" name="" class="easyui-combobox" data-options="
                                                    url:'../../Controllers/ColumnListController.ashx?action=List_SBFL',
					                                method:'post',
					                                valueField:'NAME',
					                                textField:'NAME',
                                                    editable:false," style="width:150px;"/>
                                            </div>
                                        </div>
                                        <div class="layui-inline">
                                            <label class="layui-form-label" style="padding:5px 0px;">查询条件：</label>
                                            <div class="layui-input-inline" style="margin-right:20px;">
                                                
                                                <input id="equipmentTJ" name="" class="easyui-combobox" data-options="
                                                    url:'../../Controllers/ColumnListController.ashx?action=List_SBTJ',
					                                method:'post',
					                                valueField:'CODE',
					                                textField:'NAME',
                                                    editable:false," style="width:150px;"/>
                                            </div>
                                        </div>
                                        <div class="layui-inline">
                                            <input id="keyEquipment" type="text" name="" class="easyui-textbox" style="width:150px;margin-right:50px;"/>
                                        </div>
                                        <div class="layui-inline">
                                            <a href="#" class="easyui-linkbutton  btnGetType" data-options="iconCls:'icon-search'" style="width:80px" onclick="selectEquipment()">搜索</a>
                                        </div>
                                    </div>  
                                    <h3 style="margin-left:19px;"></h3>
                                    <div style="width:100%;overflow:auto;background:white;margin-left:3%">
                                        <div style="width:1270px;">
                                            <div style="width:520px;display:inline-block;float:left">
                                                <table id="getEquipmentL" class="easyui-datagrid" title="在用设备" style="width:520px;height:370px;">
	                                            </table>
                                            </div>
                                            <div style="width:100px;display:inline-block;float:left;margin-top:5%;text-align: center;">
                                                <p style="font-size:16px;">设备安排</p>
                                                <div class="tableBtn" style="width:90px;height:200px;border:1px solid #e6e6e6;margin-left: 4px;">
                                                   <div>
                                                        <i class="layui-icon layui-icon-left"  style="font-size: 48px; color: #FF5722;margin:30px 20px;display: block;" onclick="CheckEquipmentL()"></i>
                                                    </div> 
                                                    <div>
                                                        <i class="layui-icon layui-icon-right"  style="font-size: 48px; color: #1E9FFF;margin:30px 20px;display: block;" onclick="CheckEquipmentR()"></i>
                                                    </div>
                                                    
                                                </div>
                                            </div>
                                            <div style="width:520px;display:inline-block;float:left">
                                                <table id="getEquipmentR" class="easyui-datagrid" title="闲置设备" style="width:520px;height:370px">
	                                            </table>
                                            </div>
                                        </div>
                                    </div>
                                    <span style="position: absolute;top: 6px;right: 6px;">
                                        <a href="javascript:;" onclick="$('#equipmentModel').hide()" style="display:block;width:15px;height:15px;background:url(../../Scripts/jquery-easyui-1.5.5.2/themes/icons/clear.png) no-repeat center center;"></a>
                                    </span>
                                    <div class="layui-layer-btn layui-layer-btn-c " style="text-align:center;margin: 5px 0;background:white">
                                        <a  href="#" class="easyui-linkbutton btnGetType" style="width:80px" onclick="overSBPB()">确定</a>
                                    </div>
                                    <div class="modelShow" style="display:block;position:fixed;top:33px;left:201px;background:white;opacity:0.7;width:100%;height:100%;z-index:-1"></div>
                                </div>
                                <!--添加地质房配备弹窗-->
                                <div id="dzfModel" class="contentBox " data-options="handle:'.layui-layer-title'">
                                    <div class="layui-layer-title" style="background:white;padding-bottom:10px;border-bottom: 1px solid #95B8E7;height: 40px;font-size: 14px;padding-left: 20px;line-height: 40px;">地质房选择</div>
                                    <div style="width:100%;overflow:auto;background:white;margin-left:3%;margin-top:8%">
                                        <div style="width:1270px;">
                                            <div style="width:520px;display:inline-block;float:left">
                                                <table id="getDZFL" class="easyui-datagrid" title="在用地质房" style="width:520px;height:370px;">
	                                            </table>
                                            </div>
                                            <div style="width:100px;display:inline-block;float:left;margin-top:5%;text-align: center;">
                                                <p style="font-size:16px;">地质房安排</p>
                                                <div class="tableBtn" style="width:90px;height:200px;border:1px solid #e6e6e6;margin-left: 4px;">
                                                     <div>
                                                        <i class="layui-icon layui-icon-left"  style="font-size: 48px; color: #FF5722;margin:30px 20px;display: block;" onclick="CheckDZFL()"></i>
                                                    </div> 
                                                    <div>
                                                        <i class="layui-icon layui-icon-right"  style="font-size: 48px; color: #1E9FFF;margin:30px 20px;display: block;" onclick="CheckDZFR()"></i>
                                                    </div>
                                                  
                                                </div>
                                            </div>
                                            <div style="width:520px;display:inline-block;float:left">
                                                <table id="getDZFR" class="easyui-datagrid" title="闲置地质房" style="width:520px;height:370px">
	                                            </table>
                                            </div>
                                        </div>
                                    </div>
                                    <span style="position: absolute;top: 6px;right: 6px;">
                                        <a href="javascript:;" onclick="$('#dzfModel').hide()" style="display:block;width:15px;height:15px;background:url(../../Scripts/jquery-easyui-1.5.5.2/themes/icons/clear.png) no-repeat center center;"></a>
                                    </span>
                                    <div class="layui-layer-btn layui-layer-btn-c " style="text-align:center;margin: 5px 0;background:white">
                                        <a  href="#" class="easyui-linkbutton btnGetType" style="width:80px" onclick="overDZ()">确定</a>
                                    </div>
                                     <div class="modelShow" style="display:block;position:fixed;top:33px;left:201px;background:white;opacity:0.7;width:100%;height:100%;z-index:-1"></div>
                                </div>
                                <!--添加住房配备弹窗-->
                                <div id="zfModel" class="contentBox " data-options="handle:'.layui-layer-title'">
                                    <div class="layui-layer-title" style="background:white;padding-bottom:10px;border-bottom: 1px solid #95B8E7;height: 40px;font-size: 14px;padding-left: 20px;line-height: 40px;">住房选择</div>
                                    <div style="width:100%;overflow:auto;background:white;margin-left:3%;margin-top:8%"">
                                        <div style="width:1270px;">
                                            <div style="width:520px;display:inline-block;float:left">
                                                <table id="getZFL" class="easyui-datagrid" title="在用住房" style="width:520px;height:370px;">
	                                            </table>
                                            </div>
                                            <div style="width:100px;display:inline-block;float:left;margin-top:5%;text-align: center;">
                                                <p style="font-size:16px;">住房安排</p>
                                                <div class="tableBtn" style="width:90px;height:200px;border:1px solid #e6e6e6;margin-left: 4px;">
                                                    <div>
                                                        <i class="layui-icon layui-icon-left"  style="font-size: 48px; color: #FF5722;margin:30px 20px;display: block;" onclick="CheckZFL()"></i>
                                                    </div>
                                                    <div>
                                                        <i class="layui-icon layui-icon-right"  style="font-size: 48px; color: #1E9FFF;margin:30px 20px;display: block;" onclick="CheckZFR()"></i>
                                                    </div>
                                                    
                                                </div>
                                            </div>
                                            <div style="width:520px;display:inline-block;float:left">
                                                <table id="getZFR" class="easyui-datagrid" title="闲置住房" style="width:520px;height:370px">
	                                            </table>
                                            </div>
                                        </div>
                                    </div>
                                    <span style="position: absolute;top: 6px;right: 6px;">
                                        <a href="javascript:;" onclick="$('#zfModel').hide()" style="display:block;width:15px;height:15px;background:url(../../Scripts/jquery-easyui-1.5.5.2/themes/icons/clear.png) no-repeat center center;"></a>
                                    </span>
                                    <div class="layui-layer-btn layui-layer-btn-c " style="text-align:center;margin: 5px 0;background:white">
                                        <a  href="#" class="easyui-linkbutton btnGetType" style="width:80px" onclick="overZF()">确定</a>
                                    </div>
                                     <div class="modelShow" style="display:block;position:fixed;top:33px;left:201px;background:white;opacity:0.7;width:100%;height:100%;z-index:-1"></div>
                                </div>
                                <!--添加库房配备弹窗-->
                                <div id="kfModel" class="contentBox " data-options="handle:'.layui-layer-title'">
                                    <div class="layui-layer-title" style="background:white;padding-bottom:10px;border-bottom: 1px solid #95B8E7;height: 40px;font-size: 14px;padding-left: 20px;line-height: 40px;">住房选择</div>
                                    <div style="width:100%;overflow:auto;background:white;margin-left:3%;margin-top:8%"">
                                        <div style="width:1270px;">
                                            <div style="width:520px;display:inline-block;float:left">
                                                <table id="getKFL" class="easyui-datagrid" title="在用库房" style="width:520px;height:370px;">
	                                            </table>
                                            </div>
                                            <div style="width:100px;display:inline-block;float:left;margin-top:5%;text-align: center;">
                                                <p style="font-size:16px;">库房安排</p>
                                                <div class="tableBtn" style="width:90px;height:200px;border:1px solid #e6e6e6;margin-left: 4px;">
                                                   <div>
                                                        <i class="layui-icon layui-icon-left"  style="font-size: 48px; color: #FF5722;margin:30px 20px;display: block;" onclick="CheckKFL()"></i>
                                                    </div>
                                                     <div>
                                                        <i class="layui-icon layui-icon-right"  style="font-size: 48px; color: #1E9FFF;margin:30px 20px;display: block;" onclick="CheckKFR()"></i>
                                                    </div>
                                                    
                                                </div>
                                            </div>
                                            <div style="width:520px;display:inline-block;float:left">
                                                <table id="getKFR" class="easyui-datagrid" title="闲置库房" style="width:520px;height:370px">
	                                            </table>
                                            </div>
                                        </div>
                                    </div>
                                    <span style="position: absolute;top: 6px;right: 6px;">
                                        <a href="javascript:;" onclick="$('#kfModel').hide()" style="display:block;width:15px;height:15px;background:url(../../Scripts/jquery-easyui-1.5.5.2/themes/icons/clear.png) no-repeat center center;"></a>
                                    </span>
                                    <div class="layui-layer-btn layui-layer-btn-c " style="text-align:center;margin: 5px 0;background:white">
                                        <a  href="#" class="easyui-linkbutton btnGetType" style="width:80px" onclick="overKF()">确定</a>
                                    </div>
                                    <div class="modelShow" style="display:block;position:fixed;top:33px;left:201px;background:white;opacity:0.7;width:100%;height:100%;z-index:-1"></div>
                                </div>
                            </div>
                        </form> 
                    </div>                 
                </div>
            </div>
        </div>
    </div>
    

    <div id="dlg" class="easyui-dialog" title="Basic Dialog" data-options="iconCls:'icon-save',toolbar: [{
				text:'全选',
				handler:function(){
					$('#ZD ul li').each(function () {
        $(this).find('input').prop('checked', true);
    });
				}
			},'-',{
				text:'反选',
				handler:function(){
					$('#ZD ul li').each(function () {
        $(this).find('input').prop('checked', !$(this).find('input').prop('checked'));
    });
				},
			},'-',{
				text:'连续选择',
				handler:function(){
                 var checked = [];
                        $('#ZD ul li').each(function (index,val) {
                            if($(this).find('input').is(':checked') == true){
                                checked.push(index);
                            }
                        });
                  for(var i = checked[0];i<checked[checked.length-1]+1;i++){
                            $('#ZD ul li')[i].firstChild.checked = 'checked';
                        }
                    

            }
                    }],buttons: '#dlg-buttons' " style="width:240px;height:300px;padding:10px;overflow-y:scroll" closed="true">
        <form method="post" data-options="novalidate:true" name="contractForm" id="xzff">
                    <div id="ZD">
            		<ul>
            <li><input type="checkbox" value="ZJH"/><span>井号</span></li>
            <li><input type="checkbox"  value="SC3"/><span>甲方单位</span></li>
            <li><input type="checkbox" value="SC2"/><span>地区</span></li>
            <li><input type="checkbox" value="QK"/><span>区块</span></li>
            <li><input type="checkbox" value="REPORT_TYPE" /><span>井别</span></li>
            <li><input type="checkbox" value="JX" /><span>井型</span></li>
            <li><input type="checkbox" value="JH" /><span>井筒号</span></li>
            <li><input type="checkbox" value="LJXL" /><span>录井系列</span></li>
            <li><input type="checkbox" value="SJJS" /><span>设计井深</span></li>
            <li><input type="checkbox" value="JSSJJS" /><span>加深设计井深</span></li>
            <li><input type="checkbox" value="SCFL" /><span>市场类型</span></li>
            <li><input type="checkbox" value="GJ" /><span>国家</span></li>
            <li><input type="checkbox" value="SC1" /><span>一级市场</span></li>
            <li><input type="checkbox" value="DZJDXM" /><span>地质监督姓名</span></li>
            <li><input type="checkbox" value="DZJDZJH" /><span>地质监督证件号</span></li>
            <li><input type="checkbox" value="DZJDSSGS" /><span>地质监督所属公司</span></li>
            <li><input type="checkbox" value="ZJJDXM" /><span>钻井监督姓名</span></li>
            <li><input type="checkbox" value="ZJJDZJH" /><span>钻井监督证件号</span></li>
            <li><input type="checkbox" value="ZJJDSSGS" /><span>钻井监督所属公司</span></li>
            <li><input type="checkbox" value="LJFGS" /><span>录井项目部</span></li>
            <li><input type="checkbox" value="LJDWZZ" /><span>录井资质</span></li>
            <li><input type="checkbox" value="LJDH" /><span>录井队号</span></li>
            <li><input type="checkbox" value="LJYQXH" /><span>设备型号</span></li>
            <li><input type="checkbox" value="YQZZ" /><span>仪器资质</span></li>
            <li><input type="checkbox" value="DWZBH" /><span>队伍自编号</span></li>
            <li><input type="checkbox" value="DZS" /><span>地质师</span></li>
            <li><input type="checkbox" value="STARSTART_DG" /><span>装卫星时间</span></li>
            <li><input type="checkbox" value="STARAZR" /><span>安装卫星人</span></li>
            <li><input type="checkbox" value="STAREND_DG" /><span>拆卫星时间</span></li>
            <li><input type="checkbox" value="STARCCR" /><span>拆卫星人</span></li>
            <li><input type="checkbox" value="SGDW" /><span>施工单位</span></li>
            <li><input type="checkbox" value="SGDH" /><span>施工队号</span></li>
            <li><input type="checkbox" value="YJBASJ_DG" /><span>预计搬安时间</span></li>
            <li><input type="checkbox" value="SJBASJ_DG" /><span>实际搬安时间</span></li>
            <li><input type="checkbox" value="BQJL" /><span>搬迁距离</span></li>
            <li><input type="checkbox" value="HQSJ_DG" /><span>回迁时间</span></li>
            <li><input type="checkbox" value="DQZT" /><span>当前状态</span></li>
            <li><input type="checkbox" value="CHOUXIYOU" /><span>稠油/稀油</span></li>
            <li><input type="checkbox" value="HXJW" /><span>后续井位</span></li>
            <li><input type="checkbox" value="HXJDH" /><span>后续井队号</span></li>
            <li><input type="checkbox" value="JDDT" /><span>井队动态</span></li>
            <li><input type="checkbox" value="LSDW" /><span>隶属单位</span></li>
            <li><input type="checkbox" value="XMBJWXX" /><span>项目部井位信息</span></li>
            <li><input type="checkbox" value="PGZDTS" /><span>派工重点提示</span></li>                        
            <li><input type="checkbox" value="DRJS" /><span>当前井深</span></li>
            <li><input type="checkbox" value="SGZT" /><span>当前动态</span></li>
            <li><input type="checkbox" value="BZ" /><span>备注</span></li>

		</ul>
        </div>
        </form>
	</div>
    <div id="dlg-buttons">
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="saveXZ()">确定</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg').dialog('close')">取消</a>
	</div>

    <!--点击导入弹出框-->
    <div id="insert_dlg" class="easyui-dialog" closed="true" style="width:1000px;height:700px;padding:10px" data-options="buttons: '#insert_btn',toolbar:'#dlg-toolbar'">
        <form enctype="multipart/form-data" method="post" id="jurSubsystemMenu">
                <input id="FileUpload" name="FileUpload" type="file" style="height: 20px; background: White;margin-right:80px" class="easyui-validatebox" data-options="validType:'length[ 1,100]'" onchange="excelImport()" />
        </form>
        <table id="girdPreview" toolbar= "#uploadexcel"> </table>
    </div>
    <!--导出框里的按钮-->
<div id="insert_btn">
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="openUrl()">确定</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#insert_dlg').dialog('close')">取消</a>
	</div>
    <script>
        $(document).ready(function () {

            var height1 = $(window).height() - 34;
            var w = $(window).width() - 236;
            $(".contentbox").attr("style", "background: #fff;overflow-x:auto;overflow-y:auto;height:" + height1 + "px");
            //$(".contentbox").layout("resize", {
            //    width: w,
            //    height: height1
            //});
            $('#designSelect .datagrid-pager').css({ 'width': '100%', 'position': 'absolute', 'bottom': '0' });
            var height = $(window).height() - $('#designSelect .panel-htop').offset().top - $(document).scrollTop();
            $('#designSelect .panel-htop').css({ 'height': height + 'px' });
            $('#designSelect .datagrid-wrap').css({ 'height': height - 2 + 'px', 'border-bottom': '1px solid #95B8E7', 'position': 'relative' });
        });


        $(window).resize(function () {
            var height1 = $(window).height() - 34;
            var w = $(window).width() - 236;
            $(".contentbox").attr("style", "background: #fff;overflow-x:auto;overflow-y:auto;height:" + height1 + "px");
            //$(".contentbox").layout("resize", {
            //    width: w,
            //    height: height1
            //});
            var contentwidth = parent.$('.kkklayout-panel-center').width();
            var width = $('.gridcontainer').width();
            var mwidth = contentwidth - width;
            $("#dg").datagrid('resize', { height: parent.$('.layout-panel-center').height() - mwidth });
            $('#designSelect .datagrid-pager').css({ 'width': '100%', 'position': 'absolute', 'bottom': '0' });
            //var height = $(window).height() - $(document).scrollTop();
            var height = $(window).height() - $('#designSelect .panel-htop').offset().top - $(document).scrollTop();
            $('#designSelect .panel-htop').css({ 'height': height + 'px' });
            $('#designSelect .datagrid-wrap').css({ 'height': height - 2 + 'px', 'border-bottom': '1px solid #95B8E7', 'position': 'relative' });


        });
        //点击回车触发搜索事件
        $("body").keydown(function () {
            if (event.keyCode == "13") {//keyCode=13是回车键
                $('#sousuo').click();
            }
        });
        $("body").click(function () {
            console.log(1)
        })
        function onClickCell(rowIndex, field, value) {
            console.log(rowIndex, field, value)
        }
        $("#designSelect").click(function (event) {
            console.log(1)
        })
        function Showdailog() {
            $("#dlg").dialog("open").dialog("setTitle", "选择字段");
        }

        function Closedialog() {
            $('#dlg').dialog('close');
        }
    </script>
</body>
</html>
