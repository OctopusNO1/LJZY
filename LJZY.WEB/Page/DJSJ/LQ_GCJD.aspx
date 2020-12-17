 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LQ_GCJD.aspx.cs" Inherits="LJZY.WEB.Page.DJSJ.LQ_GCJD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
       <link href="<%=System.Configuration.ConfigurationManager.AppSettings["theme"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["icon"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["demo"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/layui/css/layui.css" rel="stylesheet" />
    <link href="../../CSS/LQ_GCJD.css" rel="stylesheet" />
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["jquery"].ToString()%>" type="text/javascript"></script>
    <script src="../../Scripts/layui/layui.js"></script>
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-min"].ToString()%>" type="text/javascript"></script>
     <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-zh_CN"].ToString()%>" type="text/javascript"></script>
    <script src="../../Scripts/LQZY/LQ_GCJD.js"></script>
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
</head>
<body class="easyui-layout">
                <div id="loading" style="position:absolute;z-index:1000;top:0px;left:0px;width:100%;height:100%;background:#ffffff;text-align :center;padding-top:20%;">
     <h3><font color="#242b5f">加载中....</font></h3>
</div> 
<%--   <div data-options="region:'west',split:true" title="菜单" style="width: 200px;overflow-y:auto;">
        <ul id="tt" class="easyui-tree">
        </ul>
        <span id="treeVal" style="display:none;"></span>
    </div>--%>
    <div data-options="region:'center',iconCls:'icon-ok',border:false" >
        <div class="easyui-tabs" data-options="fit:true,plain:true">
            <div title="工程进度查询" >
                <div class="contentbox">
                    <div style="height:40px;background: #e3efff;padding:5px 0 0 6px;box-sizing:border-box">
                        <button class="easyui-linkbutton btnGetType" onclick="Showdailog()">选择字段</button>
                        <input id="SelectColumn_List" class="easyui-combobox" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=GCJD_ZD',
					    method:'post',
					    valueField:'CODE',
					    textField:'NAME',
                        editable:false,
                        value:''" style="width:150px"/>
                        <input id="Symbol_List" class="easyui-combobox" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=Symbol_List',
					    method:'post',
					    valueField:'CODE',
					    textField:'NAME',
                        editable:false,
                        value:'='" style="width:70px"/>
                        <input class="easyui-textbox" data-options="prompt:'请输入关键词...'" style="width:100px" id="isvalue"/>
                        <input type="checkbox" id="chkbox" /><span>OR</span>
                        <button class="easyui-linkbutton btnGetType" onclick="addTJ();">添加条件</button>
                        <div id="SelectWhere"></div>
                        <button class="easyui-linkbutton btnGetType" id="sousuo" onclick="doSearch1()">搜索</button>
                         <button class="easyui-linkbutton btnGetType" onclick="importbtn();" id="import">导入</button>
                         <a class="easyui-linkbutton btnGetType" id="daochu_one" onclick="exportExcel()">导出<iframe id="ExportIframe" class="J_iframe" name="iframe0" width="100%" height="100%" src="" frameborder="0" data-id="DownLoad.aspx" seamless="" style="display: none;"></iframe></a>
                    </div>
                    <div  title="DataGrid"  border-style: "none" id="designSelect" data-options="closable:true;fit:false">  
                        <div style="padding:0px 3px 0 1px;" >                   
                           <table id="dg" class="easyui-datagrid" style="width:100%;height:100%;overflow:scroll;" >
                                <thead>
                                    <tr>
                                        <th data-options="field:'ZJH',width:80,align:'center',sortable:true,sortable:true">井号</th>
                                        <th data-options="field:'SC3',width:160,align:'center',sortable:true,sortable:true">甲方单位</th>
                                        <th data-options="field:'SC2',width:80,align:'center',sortable:true,sortable:true">地区</th>
                                        <th data-options="field:'QK',width:80,align:'center',sortable:true,sortable:true">区块</th>
                                        <th data-options="field:'REPORT_TYPE',width:60,align:'center',sortable:true">井别</th>
                                        <th data-options="field:'JX',width:100,align:'center',sortable:true">井型</th>
                                        <th data-options="field:'JH',width:80,align:'center',sortable:true">井筒号</th>
                                        <th data-options="field:'LJXL',width:80,align:'center',sortable:true">录井系列</th>
                                        <th data-options="field:'DZLJKSJS',width:120,align:'center',sortable:true">地质录井开始井深</th>
                                        <th data-options="field:'DZLJKSSJ_DG',width:120,align:'center',sortable:true">地质录井开始时间</th>
                                        <th data-options="field:'YXLJKSJS',width:120,align:'center',sortable:true">岩屑录井开始井深</th>
                                        <th data-options="field:'YXLJKSSJ_DG',width:120,align:'center',sortable:true">岩屑录井开始时间</th>
                                        <th data-options="field:'QCLJKSJS',width:120,hidden:false,align:'center',sortable:true">气测录井开始井深</th>
                                        <th data-options="field:'QCLJKSSJ_DG',width:120,hidden:false,align:'center',sortable:true">气测录井开始时间</th>
                                        <th data-options="field:'ZHLJKSJS',width:120,hidden:false,align:'center',sortable:true">综合录井开始井深</th>
                                        <th data-options="field:'ZHLJKSSJ_DG',width:120,hidden:false,align:'center',sortable:true">综合录井开始时间</th>
                                        <th data-options="field:'SJJS',width:80,hidden:false,align:'center',sortable:true">设计井深</th>
                                        <th data-options="field:'JSSJJS',width:120,hidden:false,align:'center',sortable:true">加深设计井深</th>
                                        <th data-options="field:'WZJS',width:80,hidden:false,align:'center',sortable:true">完钻井深</th>
                                        <th data-options="field:'SJZZB',width:100,hidden:false,align:'center',sortable:true">实测纵坐标</th>
                                        <th data-options="field:'SJHZB',width:100,hidden:false,align:'center',sortable:true">实测横坐标</th>
                                        <th data-options="field:'DMHB',width:80,hidden:false,align:'center',sortable:true">地面海拔</th>
                                        <th data-options="field:'BXG',width:80,hidden:false,align:'center',sortable:true">补心高</th>
                                        <th data-options="field:'SGDW',width:160,hidden:false,align:'center',sortable:true">施工单位</th>
                                        <th data-options="field:'SGDH',width:120,hidden:false,align:'center',sortable:true">施工队号</th>
                                        <th data-options="field:'LJFGS',width:100,hidden:false,align:'center',sortable:true">录井项目部</th>
                                        <th data-options="field:'LJDH',width:80,hidden:false,align:'center',sortable:true">录井队号</th>
                                        <th data-options="field:'LJYQXH',width:80,hidden:false,align:'center',sortable:true">设备型号</th>
                                        <th data-options="field:'KZRQ_DG',width:80,hidden:false,align:'center',sortable:true">开钻日期</th>
                                        <th data-options="field:'WZRQ_DG',width:80,hidden:false,align:'center',sortable:true">完钻日期</th>
                                        <th data-options="field:'GJRQ_DG',width:80,hidden:false,align:'center',sortable:true">固井日期</th>
                                        <th data-options="field:'WJRQ_DG',width:80,hidden:false,align:'center',sortable:true">完井日期</th>
                                        <th data-options="field:'ZYMDC',width:80,hidden:false,align:'center',sortable:true">主要目的层</th>
                                        <th data-options="field:'WZCW',width:80,hidden:false,align:'center',sortable:true">完钻层位</th>
                                        <th data-options="field:'WJFF',width:80,hidden:false,align:'center',sortable:true">完井方法</th>
                                        <th data-options="field:'DYNZDJS',width:160,hidden:false,align:'center',sortable:true">分支点（第一年）井深</th>
                                        <th data-options="field:'DENZDJS',width:160,hidden:false,align:'center',sortable:true">第二年钻达井深</th>
                                        <th data-options="field:'SFJJYQXS',width:120,hidden:false,align:'center',sortable:true">是否见汽油</th>
                                        <th data-options="field:'SFQX',width:80,hidden:false,align:'center',sortable:true">是否取心</th>
                                        <th data-options="field:'SFJSYQC',width:120,hidden:false,align:'center',sortable:true">解释油气层否</th>
                                        <th data-options="field:'SFCXGCFZ',width:120,hidden:false,align:'center',sortable:true">是否出现工程复杂</th>
                                        <th data-options="field:'CXGCFZLX',width:120,hidden:false,align:'center',sortable:true">出现工程复杂类型</th>
                                        <th data-options="field:'GCFZCLSJ_DG',width:120,hidden:false,align:'center',sortable:true">工程复杂处理时间</th>
                                        <th data-options="field:'SFXYCTG',width:80,hidden:false,align:'center',sortable:true">下油套否</th>
                                        <th data-options="field:'SJWZYZ',width:120,hidden:false,align:'center',sortable:true">设计完钻原则</th>
                                        <th data-options="field:'WZYJ',width:80,hidden:false,align:'center',sortable:true">完钻依据</th>
                                        <th data-options="field:'SFBF',width:80,hidden:false,align:'center',sortable:true">是否报废</th>
                                        <th data-options="field:'BFLX',width:80,hidden:false,align:'center',sortable:true">报废类型</th>
                                        <th data-options="field:'STARSTART_DG',width:80,hidden:false,align:'center',sortable:true">装卫星时间</th>
                                        <th data-options="field:'STAREND_DG',width:80,hidden:false,align:'center',sortable:true">拆卫星时间</th>
                                        <th data-options="field:'ZTLX',width:80,hidden:false,align:'center',sortable:true">中停类型</th>
                                        <th data-options="field:'DRJS',width:80,hidden:false,align:'center',sortable:true">当前井深</th>
                                        <th data-options="field:'SGZT',width:80,hidden:false,align:'center',sortable:true">当前动态</th>
                                        <th data-options="field:'BZ',width:80,hidden:false,align:'center',sortable:true">备注</th>
                                    </tr>
                                </thead>
                            </table> 
                        </div>                  
                    </div>
                </div>
            </div>
            <div title="工程进度入库">
                <div class="contentbox" style="height:842px;overflow-x: auto;overflow-y: auto;">
                    <div style="height: 80px;">
                        <table style="width:1000px;background: #C4D6EE;margin: 20px auto;">
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
                        <div style="width:1000px;margin: 0 auto;">
                            <table style="border-collapse:inherit;border-spacing:4px;">
                                <tr>
                                    <td class="bx" style="background: #F1EFE2;">甲方单位</td>
                                        <td> <input id="List_SC3" name="SC3" class="easyui-combobox" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_SC3',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:false,
                        value:'勘探公司'" style="height:32px;"/></td>
                                        <td class="bx">井筒号</td>
                                        <td>  <input name="List_JH" id="List_JH" class="easyui-combobox" style="height: 32px" /></td>
                                    
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
                                             <input name="JH" id="txtJH" class="easyui-textbox" style=" height: 32px" data-options="required:true"  />
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
                                        <td class="bx">设计井深</td>
                                        <td>
                                             <input name="SJJS" id="numSJJS" class="easyui-numberbox" style=" height: 32px" data-options="max:99999,precision:2" />
                                        </td>
                                        <td class="bx">当前井深</td>
                                        <td>
                                           <input name="DRJS" id="numDRJS" class="easyui-numberbox" style=" height: 32px" data-options="max:99999,precision:2" />
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
                        editable:false " />
                                        </td>
                                        <td class="bx">区块</td>
                                        <td>
                                             <input name="QK" id="List_QK" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_QK',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:'玛湖'" />
                                        </td>                                      
                                </tr>
                                <tr>
                                        <td class="bx">当前动态</td>
                                        <td>
                                             <input name="SGZT"  class="easyui-textbox" style="height: 32px" />
                                        </td>
                                        <td class="bx">地质录井开始井深</td>
                                        <td>
                                           <input name="DZLJKSJS" class="easyui-numberbox" style="height: 32px" data-options="max:99999,precision:2" />  
                                        </td>
                                        <td class="bx">地质录井开始时间</td>
                                        <td>
                                            <input name="DZLJKSSJ" class="easyui-datebox" style="height: 32px" id="DZLJKSSJ" />
                                        </td>
                                        
                                </tr>
                                <tr>
                                    <td class="bx">岩屑录井开始井深</td>
                                        <td>
                                           <input name="YXLJKSJS" class="easyui-numberbox" style="height: 32px" data-options="max:99999,precision:2" /> 
                                        </td>
                                        <td class="bx">岩屑录井开始时间</td>
                                        <td>
                                             <input name="YXLJKSSJ" class="easyui-datebox" style=" height: 32px" id="YXLJKSSJ"  /> 
                                        </td>
                                        <td class="bx">气测录井开始井深</td>
                                        <td>
                                           <input name="QCLJKSJS" class="easyui-numberbox" style="height: 32px" data-options="max:99999,precision:2" />  
                                        </td>
                                        
                                </tr>
                                <tr>
                                    <td class="bx">气测录井开始时间</td>
                                        <td>
                                           <input name="QCLJKSSJ" class="easyui-datebox" style="height: 32px" id="QCLJKSSJ" /> 
                                        </td>
                                        <td class="bx">综合录井开始井深</td>
                                        <td>
                                             <input name="ZHLJKSJS" class="easyui-numberbox" style="height: 32px" data-options="max:99999,precision:2" /> 
                                        </td>
                                        <td class="bx">综合录井开始时间</td>
                                        <td>
                                          <input name="ZHLJKSSJ" class="easyui-datebox" style="height: 32px" id="ZHLJKSSJ" />  
                                        </td>
                                       
                                </tr>
                                <tr>
                                     <td class="bx">加深设计井深</td>
                                        <td>
                                            <input name="JSSJJS" class="easyui-numberbox" style="height: 32px" data-options="max:99999,precision:2" /> 
                                        </td>
                                        <td class="bx">完钻井深</td>
                                        <td>
                                            <input name="WZJS" class="easyui-numberbox" style="height: 32px" data-options="max:99999,precision:2" />  
                                        </td>
                                        <td class="bx">设计完钻原则</td>
                                        <td>
                                             <input name="SJWZYZ" class="easyui-textbox" style="height: 32px"  />
                                        </td>
                                        
                                </tr>
                                <tr>
                                    <td class="bx">完钻依据</td>
                                        <td>
                                            <input name="WZYJ" class="easyui-textbox" style="height: 32px"  /> 
                                        </td>
                                        <td class="bx">实测纵坐标</td>
                                        <td>
                                           <input name="SJZZB" class="easyui-numberbox" style="height: 32px" data-options="max:99999,precision:2" /> 
                                        </td>
                                        <td class="bx">实测横坐标</td>
                                        <td>
                                            <input name="SJHZB" class="easyui-numberbox" style="height: 32px" data-options="max:99999,precision:2" />  
                                        </td>
                                       
                                </tr>
                                <tr>
                                      <td class="bx">地面海拔</td>
                                        <td>
                                             <input name="DMHB" class="easyui-numberbox" style="height: 32px" data-options="max:99999,precision:2" />
                                        </td>
                                        <td class="bx">补心高</td>
                                        <td>
                                            <input name="BXG" class="easyui-numberbox" style="height: 32px" data-options="max:99999,precision:2" /> 
                                        </td>
                                        <td class="bx">施工单位</td>
                                        <td>
                                              <input name="SGDW" id="List_SGDW" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_SGDW',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:'西部钻探准东钻井公司'" /> 
                                        </td>                                        
                                </tr>
                                <tr>
                                        <td class="bx">施工队号</td>
                                        <td>
                                            <input name="SGDH" id="List_SGDH" class="easyui-combobox" style=" height: 32px" data-options="
                                                                                url:'../../Controllers/ColumnListController.ashx?action=List_SGDH',
					                                                            method:'post',
					                                                            valueField:'NAME',
					                                                            textField:'NAME',
                                                                                editable:true,
                                                                                value:'L11029'" />
                                        </td>
                                        <td class="bx">施工队电话</td>
                                        <td>
                                            <input name="SGDDH" class="easyui-numberbox" id="SGDDH"  style=" height: 32px" data-options="" />
                                        </td>
                                        <td class="bx">录井项目部</td>
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
                                        <td class="bx">开钻日期</td>
                                        <td>
                                           <input name="KZRQ" class="easyui-datebox" style="height: 32px" id="KZRQ" />
                                        </td>
                                        <td class="bx">完钻日期</td>
                                        <td>
                                             <input name="WZRQ" class="easyui-datebox" style="height: 32px" id="WZRQ" />   
                                        </td>
                                                                          
                                </tr>
                                <tr>
                                         <td class="bx">固井日期</td>
                                        <td>
                                           <input name="GJRQ" class="easyui-datebox" style="height: 32px" id="GJRQ"  />
                                        </td>   
                                        <td class="bx">完井日期</td>
                                        <td>
                                             <input name="WJRQ" class="easyui-datebox" style="height: 32px" id="WJRQ"  /> 
                                        </td>
                                        <td class="bx">主要目的层</td>
                                        <td>
                                             <input name="ZYMDC" class="easyui-textbox" style="height: 32px" /> 
                                        </td>
                                                                              
                                </tr>
                                <tr>
                                    <td class="bx">完钻层位</td>
                                        <td>
                                            <input name="WZCW" class="easyui-textbox" style="height: 32px"  />
                                        </td>  
                                    <td class="bx">完井方法</td>
                                        <td>
                                             <input name="WJFF" id="List_WJFF" class="easyui-combobox" style=" height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_WJFF',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:''" />
                                        </td>
                                    <td class="bx">分支点（第一年）井深</td>
                                    <td>
                                         <input name="DYNZDJS" class="easyui-numberbox" style="height: 32px" data-options="max:99999,precision:2" />  
                                    </td>
                                                                      
                                </tr>
                                <tr>
                                    <td class="bx">第二年钻达井深</td>
                                        <td>
                                          <input name="DENZDJS" class="easyui-numberbox" style="height: 32px" data-options="max:99999,precision:2" />
                                        </td>  
                                    <td class="bx">是否见油气</td>
                                    <td>
                                           <select class="easyui-combobox" name="SFJJYQXS" style="width: 100%;">
		                                    <option value="是">是</option>
                                            <option value="否">否</option>
                                            </select>
                                        </td>
                                    <td class="bx">是否取心</td>
                                    <td>
                                            <select class="easyui-combobox" name="SFQX" style="width: 100%;">
		                                        <option value="是">是</option>
                                                <option value="否">否</option>
                                                </select>  
                                        </td>
                                                                   
                                </tr>
                                <tr>
                                     <td class="bx">解释油气层否</td>
                                    <td>
                                           <select class="easyui-combobox" name="SFJSYQC" style="width: 100%;">
		                                        <option value="是">是</option>
                                                <option value="否">否</option>
                                                </select>
                                        </td>  
                                    <td class="bx">是否出现工程复杂</td>
                                    <td>
                                       <select class="easyui-combobox" name="SFCXGCFZ" style="width: 100%;">
		                                        <option value="是">是</option>
                                                <option value="否">否</option>
                                                </select>     
                                    </td>
                                    <td class="bx">出现工程复杂类型</td>
                                    <td>                                             
                                        <input name="CXGCFZLX" id="List_CXGCFZLX" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_GCFZLX',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:''" />       
                                    </td>
                                                                     
                                </tr>
                                <tr>
                                    <td class="bx">工程复杂处理时间</td>
                                    <td>
                                        <input name="GCFZCLSJ" class="easyui-datebox" style=" height: 32px" id="GCFZCLSJ" />
                                    </td>  
                                    <td class="bx">
                                      下油套否
                                    </td>
                                    <td>
                                        <select class="easyui-combobox" name="SFXYCTG" style="width: 100%;">
		                                        <option value="是">是</option>
                                                <option value="否">否</option>
                                                </select>      
                                    </td>
                                    <td class="bx">
                                       设备型号
                                    </td>
                                    <td>
                                        <input name="LJYQXH" id="List_LJYQXH" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_SBXH',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:''" />     
                                    </td>
                                                                                                  
                                </tr>
                                <tr>
                                      <td class="bx">
                                         <div style="width:50%;float:left">
                                        <select class="easyui-combobox" name="CZMC" style="width:70px;" id="CZMC1">
		                                                <option value="侧钻1">侧钻1</option>
                                                        <option value="侧钻2">侧钻2</option>
                                                        <option value="侧钻3">侧钻3</option>
                                        </select>

                                        </div>
                                        <div style="line-height:30px">
                                            开始录井井深
                                        </div>
                                    </td>                               
                                    <td>
                                        <input name="CZKSJS" class="easyui-numberbox" style="height: 32px" data-options="max:99999,precision:2" />
                                    </td> 
                                    <td class="bx">
                                          <div style="width:50%;float:left"> 
                                        <%--<select class="easyui-combobox" name="state" style="width:70px;">
		                                <option value="侧钻1">侧钻1</option>
                                        <option value="侧钻2">侧钻2</option>
                                        <option value="侧钻3">侧钻3</option>
                                        </select>--%>
                                             <input name="" class="easyui-textbox" style="width:70px;" data-options="readonly:true" id="CZMC2" />
                                        </div>
                                        <div style="line-height:30px">
                                        开始录井时间
                                        </div>                                                             
                                    </td>
                                    <td>
                                       <input name="CZKSSJ" class="easyui-datebox" style="height: 32px" id="CZKSLJSJ1" />
                                    </td>

                                    <%--/////////////////////--%>
                                    <td class="bx">
                                        <div style="width:50%;float:left">
                                            <%--<select class="easyui-combobox" name="state" style="width:70px;">
		                                                    <option value="侧钻1">侧钻1</option>
                                                            <option value="侧钻2">侧钻2</option>
                                                            <option value="侧钻3">侧钻3</option>
                                            </select>--%>
                                                 <input name="" class="easyui-textbox" style="width:70px;" data-options="readonly:true" id="CZMC3" />
                                            </div>
                                            <div style="line-height:30px">
                                                结束录井井深
                                            </div>               
                                    </td>
                                    <td>
                                        <input name="CZJSJS" class="easyui-numberbox" style="height: 32px" data-options="max:99999,precision:2" />     
                                    </td>
                                                                                                                   
                                </tr>
                                <tr>
                                     <td class="bx">
                                       <div style="width:50%;float:left">
                                            <%--<select class="easyui-datebox" name="state" style="width:70px;">
		                                            <option value="侧钻1">侧钻1</option>
                                                    <option value="侧钻2">侧钻2</option>
                                                    <option value="侧钻3">侧钻3</option>
                                            </select>--%>
                                           <input name="" class="easyui-textbox" style="width:70px;" data-options="readonly:true" id="CZMC4"/>
                                        </div>
                                        <div style="line-height:30px">结束录井时间</div>       
                                    </td>
                                    <td>
                                       <input name="CZJSSJ" class="easyui-datebox" style=" height: 32px" id="CZJSSJ" />
                                    </td>  
                                    <td class="bx">
                                           中停类型                            
                                    </td>
                                    <td>
                                           <input name="ZTLX" id="List_ZTLX" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_ZTLX',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:''" />
                                    </td>         
                                    <td class="bx">
                                        <div style="width:50%;float:left">
                                            <select class="easyui-combobox" name="ZTMC" style="width:70px;" id="ZTMC1">
		                                            <option value="中停1">中停1</option>
                                                    <option value="中停2">中停2</option>
                                                    <option value="中停3">中停3</option>
                                            </select>
                                        </div>
                                        <div style="line-height:30px">
                                            开始录井时间
                                        </div>                                   
                                    </td>
                                    <td>
                                           <input name="ZTKSSJ" id="ZTKSSJ" class="easyui-datebox" style=" height: 32px" />
                                    </td>
                        
                                                                      
                                </tr>                          
                                <tr>
                                     <td class="bx">
                                        <div style="width:50%;float:left">                                           
                                           <input name="" class="easyui-textbox" style="width:70px;" data-options="readonly:true" id="ZTMC2"/>
                                        </div>
                                        <div style="line-height:30px">结束录井时间</div>       
                                    </td>
                                    <td>
                                             <input name="ZTJSSJ" id="ZTJSSJ" class="easyui-datebox" style=" height: 32px" />
                                    </td>
                                    <td class="bx">装卫星时间</td>
                                    <td>
                                         <input name="STARSTART" class="easyui-datebox" style="height: 32px" id="STARSTART" />
                                    </td>     
                                    <td class="bx">拆卫星时间</td>
                                    <td>
                                        <input name="STAREND" class="easyui-datebox" style="height: 32px" id="STAREND"  />    
                                        </td>
                                                                     
                                </tr>
                                <tr>    
                                    <td class="bx">是否报废</td>
                                    <td>
                                          <select class="easyui-combobox" name="SFBF" style="width: 100%;">
		                                    <option value="是">是</option>
                                            <option value="否">否</option>
                                        </select>
                                    </td>                                   
                                    <td class="bx">报废类型</td>
                                    <td>
                                            <input name="BFLX" id="List_BFLX" class="easyui-combobox" style="height: 32px" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=List_BFLX',
					    method:'post',
					    valueField:'NAME',
					    textField:'NAME',
                        editable:true,
                        value:''" />
                                    </td>       
                                    <td class="bx">预计完井日期</td>
                                        <td>
                                             <input name="YJWJRQ" class="easyui-datebox" style="height: 32px" id="YJWJRQ"  /> 
                                        </td>
                                </tr>
                            </table>
                            <table style="border-collapse:inherit;border-spacing:4px;">
                                <tr>
                                    <td>工程备注</td>
                                </tr>
                                <tr>
                                    <td>
                                        <input name="BZ" class="easyui-textbox" data-options="multiline:true" value="" style="width:1000px;height:100px;margin-left:4px"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td><a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" onclick="submitForm();" style="width:92px;line-height:28px;color:#000;margin-top:10px;">保 存</a></td>
                                </tr>
                            </table>
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
                        <li><input type="checkbox" value="SC3" /><span>甲方单位</span></li>
                        <li><input type="checkbox" value="SC2" /><span>地区</span></li>
                        <li><input type="checkbox" value="QK" /><span>区块</span></li>
                        <li><input type="checkbox" value="REPORT_TYPE" /><span>井别</span></li>
                        <li><input type="checkbox" value="JX" /><span>井型</span></li>
                        <li><input type="checkbox" value="JH" /><span>井筒号</span></li>
                        <li><input type="checkbox" value="LJXL" /><span>录井系列</span></li>
                        <li><input type="checkbox" value="DZLJKSJS" /><span>地质录井开始井深</span></li>
                        <li><input type="checkbox" value="DZLJKSSJ_DG" /><span>地质录井开始时间</span></li>
                        <li><input type="checkbox" value="YXLJKSJS" /><span>岩屑录井开始井深</span></li>
                        <li><input type="checkbox" value="YXLJKSSJ_DG" /><span>岩屑录井开始时间</span></li>
                        <li><input type="checkbox" value="QCLJKSJS" /><span>气测录井开始井深</span></li>
                        <li><input type="checkbox" value="QCLJKSSJ_DG" /><span>气测录井开始时间</span></li>
                        <li><input type="checkbox" value="ZHLJKSJS" /><span>综合录井开始井深</span></li>
                        <li><input type="checkbox" value="ZHLJKSSJ_DG" /><span>综合录井开始时间</span></li>
                        <li><input type="checkbox" value="SJJS" /><span>设计井深</span></li>
                        <li><input type="checkbox" value="JSSJJS" /><span>加深设计井深</span></li>
                        <li><input type="checkbox" value="WZJS" /><span>完钻井深</span></li>
                        <li><input type="checkbox" value="SJZZB" /><span>实测纵坐标</span></li>
                        <li><input type="checkbox" value="SJHZB" /><span>实测横坐标</span></li>
                        <li><input type="checkbox" value="DMHB" /><span>地面海拔</span></li>
                        <li><input type="checkbox" value="BXG" /><span>补心高</span></li>
                        <li><input type="checkbox" value="SGDW" /><span>施工单位</span></li>
                        <li><input type="checkbox" value="SGDH" /><span>施工队号</span></li>
                        <li><input type="checkbox" value="LJFGS" /><span>录井项目部</span></li>
                        <li><input type="checkbox" value="LJDH" /><span>录井队号</span></li>
                        <li><input type="checkbox" value="LJYQXH" /><span>设备型号</span></li>
                        <li><input type="checkbox" value="KZRQ_DG" /><span>开钻日期</span></li>
                        <li><input type="checkbox" value="WZRQ_DG" /><span>完钻日期</span></li>
                        <li><input type="checkbox" value="GJRQ_DG" /><span>固井日期</span></li>
                        <li><input type="checkbox" value="WJRQ_DG" /><span>完井日期</span></li>
                        <li><input type="checkbox" value="ZYMDC" /><span>主要目的层</span></li>
                        <li><input type="checkbox" value="WZCW" /><span>完钻层位</span></li>
                        <li><input type="checkbox" value="WJFF" /><span>完井方法</span></li>
                        <li><input type="checkbox" value="DYNZDJS" /><span>分支点（第一年）井深</span></li>
                        <li><input type="checkbox" value="DENZDJS" /><span>第二年钻达井深</span></li>
                        <li><input type="checkbox" value="SFJJYQXS" /><span>是否见汽油</span></li>
                        <li><input type="checkbox" value="SFQX" /><span>是否取心</span></li>
                        <li><input type="checkbox" value="SFJSYQC" /><span>解释油气层否</span></li>
                        <li><input type="checkbox" value="SFCXGCFZ" /><span>是否出现工程复杂</span></li>
                        <li><input type="checkbox" value="CXGCFZLX" /><span>出现工程复杂类型</span></li>
                        <li><input type="checkbox" value="GCFZCLSJ_DG" /><span>工程复杂处理时间</span></li>
                        <li><input type="checkbox" value="SFXYCTG" /><span>下油套否</span></li>
                        <li><input type="checkbox" value="SJWZYZ" /><span>设计完钻原则</span></li>
                        <li><input type="checkbox" value="WZYJ" /><span>完钻依据</span></li>
                        <li><input type="checkbox" value="SFBF" /><span>是否报废</span></li>
                        <li><input type="checkbox" value="BFLX" /><span>报废类型</span></li>
                        <li><input type="checkbox" value="STARSTART_DG" /><span>装卫星时间</span></li>
                        <li><input type="checkbox" value="STAREND_DG" /><span>拆卫星时间</span></li>
                        <li><input type="checkbox" value="ZTLX" /><span>中停类型</span></li>
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
</body>
</html>
<script type="text/javascript">
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
        var contentwidth = parent.$('.layout-panel-center').width();
        var width = $('.gridcontainer').width();
        var mwidth = contentwidth - width;
        $("#dg").datagrid('resize', { height: parent.$('.layout-panel-center').height() - mwidth });
        $('#designSelect .datagrid-pager').css({ 'width': '100%', 'position': 'absolute', 'bottom': '0' });
        var height = $(window).height() - $('#designSelect .panel-htop').offset().top - $(document).scrollTop();
        $('#designSelect .panel-htop').css({ 'height': height + 'px' });
        $('#designSelect .datagrid-wrap').css({ 'height': height - 2 + 'px', 'border-bottom': '1px solid #95B8E7', 'position': 'relative' });


    });



    function Showdailog() {
        $("#dlg").dialog("open").dialog("setTitle", "选择字段");
    }

    function Closedialog() {
        $('#dlg').dialog('close');
    }

    function saveXZ() {
var list = [];
    var listAll = [];
    $("#ZD ul li").each(function () {
        if ($(this).children("input").is(':checked')) {
            list.push($(this).children("input").val())
        }
        listAll.push($(this).children("input").val())
    })
    console.log(list,listAll);
            for (var i = 0; i < listAll.length; i++) {
                console.log(listAll[i])
                $("#dg").datagrid('hideColumn', listAll[i]);
            }
            for (var i = 0; i < list.length; i++) {
                $("#dg").datagrid('showColumn', list[i]);
            }
            Closedialog();
    }
</script>

<script type="text/javascript">
    //$(document).ready(function () {
    //    $('#designSelect .datagrid-pager').css({ 'width': '100%', 'position': 'absolute', 'bottom': '0' });
    //    var height = $(window).height() - $('#designSelect .panel-htop').offset().top - $(document).scrollTop();
    //    $('#designSelect .panel-htop').css({ 'height': height + 'px' });
    //    $('#designSelect .datagrid-wrap').css({ 'height': height - 2 + 'px', 'border-bottom': '1px solid #95B8E7', 'position': 'relative' });

    //    //子表查询页面
    //    $('#designSelect2 .datagrid-pager').css({ 'width': '100%', 'position': 'absolute', 'bottom': '0' });
    //    var height = $(window).height() - $('#designSelect2 .panel-htop').offset().top - $(document).scrollTop();
    //    $('#designSelect2 .panel-htop').css({ 'height': height + 'px' });
    //    $('#designSelect2 .datagrid-wrap').css({ 'height': height - 2 + 'px', 'border-bottom': '1px solid #95B8E7', 'position': 'relative' });
    //});

    function myformatter(date) {
        var y = date.getFullYear();
        var m = date.getMonth() + 1;
        var d = date.getDate();
        return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
    }
    function myparser(s) {
        if (!s) return new Date();
        var ss = (s.split('-'));
        var y = parseInt(ss[0], 10);
        var m = parseInt(ss[1], 10);
        var d = parseInt(ss[2], 10);
        if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
            return new Date(y, m - 1, d);
        } else {
            return new Date();
        }
    }
    //点击回车触发搜索事件
    $("body").keydown(function () {
        if (event.keyCode == "13") {//keyCode=13是回车键
            $('#sousuo').click();
        }
    });


    </script>