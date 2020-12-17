<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LQ_WJKP.aspx.cs" Inherits="LJZY.WEB.Page.DJSJ.LQ_WJKP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["theme"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["icon"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["demo"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/layui/css/layui.css" rel="stylesheet" />
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["jquery"].ToString()%>" type="text/javascript"></script>    
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-min"].ToString()%>" type="text/javascript"></script>
      <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-zh_CN"].ToString()%>" type="text/javascript"></script>
    <link href="../../CSS/LQ_WJKP.css" rel="stylesheet" />
    <script src="../../Scripts/layui/layui.js"></script>
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
</script>
</head>
<body  style="margin:0 auto">
          <div id="loading" style="position:absolute;z-index:1000;top:0px;left:0px;width:100%;height:100%;background:#ffffff;text-align :center;padding-top:20%;">
     <h3><font color="#242b5f">加载中....</font></h3>
</div> 
<div class="easyui-tabs" data-options="fit:true,plain:true"style="width:100%;height:100%;max-height:800px;min-height:400px;">
    <!--完井统计查询-->
    <div title="完井统计查询">   
        <div class="search_div">
            <div style="height:4px"></div>
                <button class="easyui-linkbutton btnGetType" onclick="Showdailog()" style="margin-left:5px">选择字段</button>
                <input id="SelectColumn_List" class="easyui-combobox" style="width:150px" panelHeight="auto" data-options="
                            url:'../../Controllers/ColumnListController.ashx?action=RYGL_ZD',
					        method:'post',
					        valueField:'CODE',
					        textField:'NAME',
                            editable:false,
                            value:'XM'"/>
                <input id="Symbol_List" class="easyui-combobox"  style="width:70px" panelHeight="auto" data-options="
                            url:'../../Controllers/ColumnListController.ashx?action=Symbol_List',
					        method:'post',
					        valueField:'CODE',
					        textField:'NAME',
                            editable:false,
                            value:'='"/>
                <input class="easyui-textbox" style="width: 150px; height: 32px" data-options="prompt:'请输入关键字'" id="isvalue" />
                <input type="checkbox" id="chkbox"/><span>OR</span>
                <button class="easyui-linkbutton btnGetType" onclick="addTJ();">添加条件</button>                   
                         <div id="SelectWhere">                     
                         </div>    
                <button class="easyui-linkbutton btnGetType" id="sousuo" onclick="doSearch1()">查询</button>
                <button class="easyui-linkbutton btnGetType" id="daoru_one" onclick="insert_one()">导入</button>
                <a class="easyui-linkbutton btnGetType" id="daochu_one" onclick="exportExcel()">导出<iframe id="ExportIframe" class="J_iframe" name="iframe0" width="100%" height="100%" src="" frameborder="0" data-id="DownLoad.aspx" seamless="" style="display: none;"></iframe></a>
             
        </div>
        <%--<div style="clear:both"></div>--%>
        
            <table class="easyui-datagrid" id="dg" style="width:100%;height:95%;">
			    
			</table>
        
	</div>
     <!--子表查询（没用）-->
    <div title="人员日志查询">   
        <div class="search_div">
            <div style="height:4px"></div>
                <button class="easyui-linkbutton btnGetType" style="margin-left:5px" onclick="Showdailog2()">选择字段</button>
                <input id="SelectColumn_List2" class="easyui-combobox" style="width:150px" panelHeight="auto" data-options="
                           url:'../../Controllers/ColumnListController.ashx?action=getZD_RYGLZB',
					        method:'post',
					        valueField:'CODE',
					        textField:'NAME',
                            editable:false,
                            value:'XM'"/>
                <input id="Symbol_List2" class="easyui-combobox"  style="width:70px" panelHeight="auto" data-options="
                            url:'../../Controllers/ColumnListController.ashx?action=Symbol_List',
					        method:'post',
					        valueField:'CODE',
					        textField:'NAME',
                            editable:false,
                            value:'='"/>
                <input class="easyui-textbox" style="width: 150px; height: 32px" data-options="prompt:'请输入关键字'" id="isvalue2"  />
                <input type="checkbox" id="chkbox2"/><span>OR</span>
                <button class="easyui-linkbutton btnGetType" onclick="addTJ2();">添加条件</button>                   
                         <div id="SelectWhere2">                     
                         </div>    
                <button class="easyui-linkbutton btnGetType" id="searchbtn2" onclick="doSearch2()">查询</button>
             <a class="easyui-linkbutton btnGetType" id="daochu_one" onclick="exportExcelSJRZ()">导出<iframe id="ExportIframe" class="J_iframe" name="iframe0" width="100%" height="100%" src="" frameborder="0" data-id="DownLoad.aspx" seamless="" style="display: none;"></iframe></a>
        </div>
        <%--<div style="clear:both"></div>--%>
        <table class="easyui-datagrid" id="dg2" style="width:100%;height:95%;">
				
			</table>
       <%-- <div  title="DataGrid"  border-style: "none" id="designSelect2" data-options="closable:true;fit:true" style="height:100%;width:100%">
            
        </div>--%>
	</div>
     <!--人员入库（没用）-->
    <div title="人员信息修改">
                <div style="height: 80px;padding-top:20px;">
                    <table style="background: #C4D6EE;margin: 0 auto;width:54%; ">
                        <tr>
<%--                            <td style="padding:0 15px"><button  class="easyui-linkbutton btnAdd" style="background:url(/Image/add.png) no-repeat center center;width:100px;height:30px"></button></td>--%>
                            <td style="padding:0 14px"><button  class="easyui-linkbutton btnShou" onclick="loadRemote_Home()" style="background:url(/Image/shou.png) no-repeat center center;width:100px;height:30px"></button></td>
                            <td style="padding:0 14px"><button  class="easyui-linkbutton btnShang" onclick="loadRemote_Up()" style="background:url(/Image/shang.png) no-repeat center center;width:100px;height:30px"></button></td>
                            <td style="padding:0 14px"><button  class="easyui-linkbutton btnXia" onclick="loadRemote_Down()" style="background:url(/Image/xia.png) no-repeat center center;width:100px;height:30px"></button></td>
                            <td style="padding:0 14px"><button  class="easyui-linkbutton btnWei" onclick="loadRemote_End()" style="background:url(/Image/wei.png) no-repeat center center;width:100px;height:30px"></button></td>
                            <td style="padding:0 15px 0 14px "><button  class="easyui-linkbutton btnDel" onclick="openDelWin()" style="background:url(/Image/del.png) no-repeat center center;width:100px;height:30px"></button></td>
                        </tr>
                    </table>
                </div>
                <form id="ff" method="post" data-options="novalidate:true" name="contractForm"  enctype="multipart/form-data" >
                <div>
        <table  style="margin:0 auto;border-collapse:inherit;border-spacing:4px;" >
            <tr>  
            <td class="bx">所属项目部</td>
             <td>
                <input class="easyui-combobox" name="XMB" style="width: 100%; height: 32px" panelHeight="auto" data-options="
                     url:'../../Controllers/ColumnListController.ashx?action=List_LJFGS',
					method:'post',
					valueField:'NAME',
					textField:'NAME',
                    editable:false,
                    value:''" />
            </td>

            <td class="bx">岗位类别</td>
             <td>
                <input class="easyui-combobox" name="GW" style="width: 100%; height: 32px" panelHeight="auto" data-options="
                     url:'../../Controllers/ColumnListController.ashx?action=List_GWLB',
					method:'post',
					valueField:'NAME',
					textField:'NAME',
                    editable:false,
                    value:''"/>
            </td>
            <td class="bx">人员编号</td>
            <td>
                <input class="easyui-textbox" name="RYBH" id="txtRYBH" style="width: 100%; height: 32px" />
            </td>
            <td style="display:none">
                <input  class="easyui-textbox" name="ID" id="txtID" style="display:none"  />
            </td>
           </tr>
            <tr>
            <td class="bx">姓名</td>
            <td>
                <input class="easyui-textbox" name="XM" style="width: 100%; height: 32px" />
            </td>


                <td class="bx">联系电话</td>
                <td>
                    <input class="easyui-textbox" name="LXDH" style="width: 100%; height: 32px" />
                </td>
                                  <td class="bx">性别</td>
                 <td>
                     <input class="easyui-combobox"  name="XB" style="width: 100%; height: 32px" panelHeight="auto" data-options="
                     url:'../../Controllers/ColumnListController.ashx?action=List_XB',
					method:'post',
					valueField:'NAME',
					textField:'NAME',
                    editable:false,
                    value:''" />
                 </td>
            
              
            </tr>
            <tr>
                 
                <td class="bx">年龄</td>
                <td>
                     <input class="easyui-textbox" name="NL" style="width: 100%; height: 32px" />
                </td>
               
                  <td class="bx">学历</td>
                <td>
                      <input class="easyui-combobox" name="XL" style="width: 100%; height: 32px" panelHeight="auto" data-options="
                     url:'../../Controllers/ColumnListController.ashx?action=List_XL',
					method:'post',
					valueField:'NAME',
					textField:'NAME',
                    editable:false,
                    value:''" />
                </td>
                 <td class="bx">用工性质</td>
                 <td>
                      <input class="easyui-combobox" name="YGXZ" style="width: 100%; height: 32px" panelHeight="auto" data-options="
                     url:'../../Controllers/ColumnListController.ashx?action=List_YGXZ',
					method:'post',
					valueField:'NAME',
					textField:'NAME',
                    editable:false,
                    value:''" />
                 </td>
            </tr>
            <tr>
                 <td class="bx">健康状况</td>
                <td>
                      <input class="easyui-combobox" name="JKZK" style="width: 100%; height: 32px" panelHeight="auto" data-options="
                     url:'../../Controllers/ColumnListController.ashx?action=List_JKZK',
					method:'post',
					valueField:'NAME',
					textField:'NAME',
                    editable:false,
                    value:''"/>
                </td>
                   <td class="bx">职称</td>
                 <td>
                     <input class="easyui-combobox" name="ZC" style="width: 100%; height: 32px"  panelHeight="auto" data-options="
                     url:'../../Controllers/ColumnListController.ashx?action=List_ZC',
					method:'post',
					valueField:'NAME',
					textField:'NAME',
                    editable:false,
                    value:''"/>
                 </td>

                 <td class="bx">
                   人员状态
                </td>
                <td>
                      <input class="easyui-combobox" name="RYZT" style="width: 100%; height: 32px"  panelHeight="auto" data-options="
                     url:'../../Controllers/ColumnListController.ashx?action=List_RYZT',
					method:'post',
					valueField:'NAME',
					textField:'NAME',
                    editable:false,
                    value:''"/>
                </td>

                  
               
            </tr>
            <tr>
                <td class="bx">上井井号</td>
                <td>
                     <input class="easyui-textbox" name="SJJH" style="width: 100%; height: 32px" />
                </td>
                <td class="bx">开始上井日期</td>
                <td>
                 <input class="easyui-datebox" name="KSSJRQ" id="KSSJRQ" style="width: 100%; height: 32px" data-options="disabled:true" />
                </td>     
                <td class="bx">结束上井日期</td>
                <td>
                 <input class="easyui-datebox" name="JSSJRQ" id="JSSJRQ" style="width: 100%; height: 32px"/>
                </td>   
            </tr>
            <tr>
                <td class="bx">本井上井天数</td>
                <td>
                     <input class="easyui-textbox" name="BJSJTS" style="width: 100%; height: 32px" />
                </td>
                 <td class="bx">年度上井天数</td>
                <td>
                     <input class="easyui-textbox" name="NDSJTS" style="width: 100%; height: 32px" />
                </td>
                 <td class="bx">岗位系数</td>
                <td>
                     <input class="easyui-textbox" name="GWXS" style="width: 100%; height: 32px" />
                </td>
            </tr>
            <tr>
                <td class="bx">备注</td>
                <td colspan="5">
                     <input class="easyui-textbox" name="BZ" style="width: 100%; height: 32px" />
                </td>
            </tr>
            <tr>
                <td class="bx">上岗证编号</td>
                <td>
                     <input class="easyui-textbox" name="SGZBH" style="width: 100%; height: 32px" />
                </td>
               <td class="bx">有效期</td>
                <td>
                     <input class="easyui-textbox" name="SGZYXQ" style="width: 100%; height: 32px" />
                </td>
                 <td>

                     <div class="layui-upload">
                        <img id="showPhotoSGZ" src="../../Image/photo.png" style="width:40px;height:30px;vertical-align:middle;"/>
                         <button type="button" class="easyui-linkbutton" style="background:url(/Image/xia.png) no-repeat center center;width:30px;height:30px;border-style:none;vertical-align:middle;" id="previewImgSGZ">
                         </button>
                    </div>

                 </td>
                <td>
                    <div id="previewSGZ" style="position:absolute;top:30%;left:30%;display:none;background: #000;z-index:99;max-width:600px;max-height:400px" class="easyui-draggable">
                        <img src="" id="imgheadSGZ"/>
                    </div>
                    <input id="inputSGZ" type="text" name="SGZIMG" value=""  style="display:none"/>
                </td>
            </tr>
            <tr>
               <td class="bx">井控证编号</td>
                <td>
                     <input class="easyui-textbox" name="JCZBH" style="width: 100%; height: 32px" />
                </td>
               <td class="bx">有效期</td>
                <td>
                     <input class="easyui-textbox" name="JCZYXQ" style="width: 100%; height: 32px" />
                </td>
                 <td>

                     <div class="layui-upload">
                        <img id="showPhotoJCZ" src="../../Image/photo.png" style="width:40px;height:30px;vertical-align:middle;"/>
                         <button type="button" class="easyui-linkbutton" style="background:url(/Image/xia.png) no-repeat center center;width:30px;height:30px;border-style:none;vertical-align:middle;" id="previewImgJCZ">
                         </button>
                    </div>
                 </td>
                <td>
                    <div id="previewJCZ" style="position:fixed;top:30%;left:30%;display:none;background: #fff;z-index:99;max-width:600px;max-height:400px" class="easyui-draggable">
                        <img src=""  id="imgheadJCZ"/>
                    </div>
                    <input id="inputJCZ" type="text" name="JCZIMG" value=""  style="display:none"/>
                </td>
            </tr>
            <tr>
               <td class="bx">安全环保健康证(HSE)</td>
                <td>
                     <input class="easyui-textbox" name="HSEBH" style="width: 100%; height: 32px" />
                </td>
               <td class="bx">有效期</td>
                <td>
                     <input class="easyui-textbox" name="HSEYXQ" style="width: 100%; height: 32px" />
                </td>
                 <td>

                     <div class="layui-upload">
                        <img id="showPhotoHSE" src="../../Image/photo.png" style="width:40px;height:30px;vertical-align:middle;"/>
                         <button type="button" class="easyui-linkbutton" style="background:url(/Image/xia.png) no-repeat center center;width:30px;height:30px;border-style:none;vertical-align:middle;" id="previewImgHSE">
                         </button>
                    </div>
                 </td>
                <td>
                    <div id="previewHSE" style="position:fixed;top:30%;left:30%;background: #fff;display:none;z-index:99;max-width:600px;max-height:400px" class="easyui-draggable">
                        <img src="" id="imgheadHSE"/>
                    </div>
                    <input id="inputHSE" type="text" name="HSEIMG" value="" style="display:none"/>
                </td>
            </tr>
            <tr>
                <td> 
                    <a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" style="width:92px;line-height:28px;color:#000" onclick="saveNDJZ()">年度结转</a>
                </td>
                 <td> 
                    <a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" style="width:92px;line-height:28px;color:#000" onclick="submitForm()">保 存</a>
                </td>
            </tr>
    </table>
    </div>
        </form>

                </div>

   </div>

                <!--选择字段弹出框-->
<div id="dlg" class="easyui-dialog" title="Basic Dialog"  data-options="iconCls:'icon-save',toolbar: [{
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
                <div id="ZD">
            	<ul>
                    <li><input type="checkbox" value="XMB"/><span>所属项目部</span></li>
                    <li><input type="checkbox" value="GW"/><span>岗位类别</span></li>
                    <li><input type="checkbox" value="RYBH"/><span>人员编号</span></li>
                    <li><input type="checkbox" value="XM" /><span>姓名</span></li>
                    <li><input type="checkbox" value="LXDH"/><span>联系电话</span></li>
                    <li><input type="checkbox" value="XB"/><span>性别</span></li>
                    <li><input type="checkbox" value="NL"/><span>年龄</span></li>  
                    <li><input type="checkbox" value="XL"/><span>学历</span></li>
                    <li><input type="checkbox" value="YGXZ"/><span>用工性质</span></li>
                    <li><input type="checkbox" value="JKZK"/><span>健康状况</span></li>
                    <li><input type="checkbox" value="ZC"/><span>职称</span></li>
                    <li><input type="checkbox" value="RYZT"/><span>人员状态</span></li>
                    <li><input type="checkbox" value="NDSJTS"/><span>年度上井天数</span></li>
                    <li><input type="checkbox" value="SJJH"/><span>上井井号</span></li>
                    <li><input type="checkbox" value="KSSJRQ_DG"/><span>开始上井日期</span></li>
                    <li><input type="checkbox" value="JSSJRQ_DG"/><span>结束上井日期</span></li>
                    <li><input type="checkbox" value="GWXS"/><span>岗位系数</span></li>
                    <li><input type="checkbox" value="BZ"/><span>备注</span></li>
                    <li><input type="checkbox" value="JCZIMAGE"/><span>井控证</span></li>
                    <li><input type="checkbox" value="HSEIMG"/><span>安全环保健康证(HSE)</span></li>
                    <li><input type="checkbox" value="SGZIMG"/><span>上岗证</span></li>
       
	</ul>
    </div>
</div>
<div id="dlg-buttons">
	<a href="javascript:void(0)" class="easyui-linkbutton" onclick="saveXZ()">确定</a>
	<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg').dialog('close')">取消</a>
</div>
    <!--子表选择字段弹出框-->
                <div id="dlg2" class="easyui-dialog" title="Basic Dialog" data-options="iconCls:'icon-save',toolbar: [{
					text:'全选',
					handler:function(){
						$('#ZD2 ul li').each(function () {
            $(this).find('input').prop('checked', true);
        });
					}
				},'-',{
					text:'反选',
					handler:function(){
						$('#ZD2 ul li').each(function () {
            $(this).find('input').prop('checked', !$(this).find('input').prop('checked'));
        });
					},
				},'-',{
					text:'连续选择',
					handler:function(){
                        var checked = [];
                        $('#ZD2 ul li').each(function (index,val) {
                            if($(this).find('input').is(':checked') == true){
                                checked.push(index);
                            }
                        });
                        for(var i = 0;i<checked[checked.length-1]+1;i++){
                            $('#ZD2 ul li')[i].firstChild.checked = 'checked';
                        }
                    }
                     }],buttons: '#dlg2-buttons' "style="width:240px;height:300px;padding:10px;overflow-y:scroll" closed="true">
                <div id="ZD2">
            	<ul>
                    <li><input type="checkbox" value="XM" /><span>姓名</span></li>
                    <li><input type="checkbox" value="KSSJRQ"/><span>开始上井时间</span></li>
                    <li><input type="checkbox" value="JSSJRQ"/><span>结束上井时间</span></li>
                    <li><input type="checkbox" value="SJTS"/><span>上井天数</span></li>
                    <li><input type="checkbox" value="LJSJTS"/><span>累计上井天数</span></li>
                    <li><input type="checkbox" value="GWXS"/><span>岗位系数</span></li>
                    <li><input type="checkbox" value="BZ"/><span>备注</span></li>
	</ul>
    </div>
</div>
<div id="dlg2-buttons">
	<a href="javascript:void(0)" class="easyui-linkbutton" onclick="saveXZ2()">确定</a>
	<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg2').dialog('close')">取消</a>
</div>

<!--点击导入，弹出一个框；点击按钮，选择Excel，读取并显示-->
<div id="insert_dlg" class="easyui-dialog" closed="true" style="width:1000px;height:700px;padding:10px" data-options="buttons: '#insert_btn',toolbar:'#dlg-toolbar'">
    <form enctype="multipart/form-data" method="post" id="jurSubsystemMenu">
        <input id="FileUpload" name="FileUpload" type="file" style="height: 20px; background: White;margin-right:80px" class="easyui-validatebox" data-options="validType:'length[ 1,100]'" onchange="excelImport()" />
    </form>
    <table id="girdPreview" toolbar= "#uploadexcel"> </table>
</div>
<!--导入框里的按钮：点击确认，将保存的Excel内容写入Oracle-->
<div id="insert_btn">
        <a href="javascript:void(0)" class="easyui-linkbutton" onclick="openUrl()">确定</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#insert_dlg').dialog('close')">取消</a>
	</div>
<!--删除对话框-->
<div id="DelWin" class="easyui-window" title="提示" style="width:300px;height:200px" closed="true" data-options="iconCls:'icon-save',modal:true">       
            
    <div data-options="region:'north',title:'North Title',split:true" style="height:50px;">                                    
    <div id="DelTitle" data-options="multiline:true" style="width: 100%; height: 120px;margin-bottom:5px;"><span>确定是否删除!</span></div>                                   
    <a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" onclick="delForm();">确 定</a>
    <a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" onclick="closeDelWin();">取 消</a>                                 
    </div>               
</div>  
</body>
</html>
<script src="../../Scripts/jquery.form.js"></script>
<script src="../../Scripts/LQZY/LQ_WJKP.js"></script>
<script type="text/javascript">
    //$(document).ready(function () {
    //    //$('#designSelect .datagrid-pager').css({ 'width': '100%', 'position': 'absolute', 'bottom': '40'+"px" });
    //    var height = $(window).height() - $('#designSelect .panel-htop').offset().top - $(document).scrollTop();
    //    $('#designSelect .panel-htop').css({ 'height': height + 'px' });
    //    $('#designSelect .datagrid-wrap').css({ 'height': height - 2 + 'px', 'border-bottom': '1px solid #95B8E7', 'position': 'relative' });

    //     //子表查询页面
    //    //$('#designSelect2 .datagrid-pager').css({ 'width': '100%', 'position': 'absolute', 'bottom': '40'+"px" });
    //    var height = $(window).height() - $('#designSelect2 .panel-htop').offset().top - $(document).scrollTop();
    //    $('#designSelect2 .panel-htop').css({ 'height': height + 'px' });
    //    $('#designSelect2 .datagrid-wrap').css({ 'height': height - 2 + 'px', 'border-bottom': '1px solid #95B8E7', 'position': 'relative' });
    //});


    //$(window).resize(function () {
    //    //$('#designSelect .datagrid-pager').css({ 'width': '100%', 'position': 'absolute', 'bottom': '40'+"px" });
    //    var height = $(window).height() - $('#designSelect .panel-htop').offset().top - $(document).scrollTop();
    //    $('#designSelect .panel-htop').css({ 'height': height + 'px' });
    //    $('#designSelect .datagrid-wrap').css({ 'height': height - 2 + 'px', 'border-bottom': '1px solid #95B8E7', 'position': 'relative' });

    //    //子表查询页面
    //    //$('#designSelect2 .datagrid-pager').css({ 'width': '100%', 'position': 'absolute', 'bottom': '40'+"px" });
    //    var height = $(window).height() - $('#designSelect2 .panel-htop').offset().top - $(document).scrollTop();
    //    $('#designSelect2 .panel-htop').css({ 'height': height + 'px' });
    //    $('#designSelect2 .datagrid-wrap').css({ 'height': height - 2 + 'px', 'border-bottom': '1px solid #95B8E7', 'position': 'relative' });


    //});


    //点击回车触发搜索事件
    $("body").keydown(function () {
        if (event.keyCode == "13") {//keyCode=13是回车键
            $('#sousuo').click();
        }
    });

    </script>
