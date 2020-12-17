<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LQ_SB_ZHY.aspx.cs" Inherits="LJZY.WEB.Page.DJSJ.LQ_SB_ZHY" %>

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
    <link href="../../CSS/LQ_RYSJK.css" rel="stylesheet" />
    <style>
        a{color:#000;}
    </style>
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
<div class="easyui-tabs" data-options="fit:true,plain:true">
    <!--人员查询-->
    <div title="综合录井仪(气测)查询">   
        <div class="search_div">
            <div style="height:4px"></div>
                  <button class="easyui-linkbutton btnGetType" onclick="Showdailog()" style="margin-left:5px">选择字段</button>
                <input id="SelectColumn_List" class="easyui-combobox" style="width:150px" panelHeight="auto" data-options="
                            url:'../../Controllers/ColumnListController.ashx?action=ZHY_ZD',
					        method:'post',
					        valueField:'CODE',
					        textField:'NAME',
                            editable:false,
                            value:'SBMC'" style="width:150px"/>
                <input id="Symbol_List" class="easyui-combobox"  style="width:70px" panelHeight="auto" data-options="
                            url:'../../Controllers/ColumnListController.ashx?action=Symbol_List',
					        method:'post',
					        valueField:'CODE',
					        textField:'NAME',
                            editable:false,
                            value:'='" style="width:70px"/>
                <input class="easyui-textbox" style="width: 150px; height: 32px" data-options="prompt:'请输入关键字'" id="isvalue"  />
                <input type="checkbox" id="chkbox"/><span>OR</span>
                <button class="easyui-linkbutton btnGetType" onclick="addTJ();">添加条件</button>                   
                         <div id="SelectWhere">                     
                         </div>    
                <button class="easyui-linkbutton btnGetType" id="sousuo" onclick="doSearch1()">搜索</button>
                <button class="easyui-linkbutton btnGetType" id="daoru_one" onclick="insert_one()">导入</button>
                <a class="easyui-linkbutton btnGetType" id="daochu_one" onclick="exportExcel()">导出<iframe id="ExportIframe" class="J_iframe" name="iframe0" width="100%" height="100%" src="" frameborder="0" data-id="DownLoad.aspx" seamless="" style="display: none;"></iframe></a>
        </div>
        <div style="clear:both"></div>
        <div  title="DataGrid"  border-style: "none" id="designSelect" data-options="closable:true;fit:true" style="height:100%;width:100%">
            <table class="easyui-datagrid" id="dg">
				
			</table>
        </div>
	</div>
     <!--人员入库-->
<%--    <div title="综合录井仪(气测)信息修改">
                <div style="height: 80px;padding-top:20px;">
                    <table style="background: #C4D6EE;margin: 0 auto;width:49%; ">
                        <tr>
                            <td style="padding:0 15px"><button  class="easyui-linkbutton btnAdd" style="background:url(/Image/add.png) no-repeat center center;width:100px;height:30px"></button></td>
                            <td style="padding:0 14px"><button  class="easyui-linkbutton btnShou" style="background:url(/Image/shou.png) no-repeat center center;width:100px;height:30px"></button></td>
                            <td style="padding:0 14px"><button  class="easyui-linkbutton btnShang" style="background:url(/Image/shang.png) no-repeat center center;width:100px;height:30px"></button></td>
                            <td style="padding:0 14px"><button  class="easyui-linkbutton btnXia"  style="background:url(/Image/xia.png) no-repeat center center;width:100px;height:30px"></button></td>
                            <td style="padding:0 14px"><button  class="easyui-linkbutton btnWei"  style="background:url(/Image/wei.png) no-repeat center center;width:100px;height:30px"></button></td>
                            <td style="padding:0 15px 0 14px "><button  class="easyui-linkbutton btnDel"  style="background:url(/Image/del.png) no-repeat center center;width:100px;height:30px"></button></td>
                        </tr>
                    </table>
</div>
    <div>
        <table  style="margin:0 auto">
        <tr>  
            <td class="bx">单位名称</td>
            <td>
                <input class="easyui-textbox" style="width: 100%; height: 32px" />
            </td>
            <td class="bx">设备名称</td>
            <td>
                <input class="easyui-textbox" style="width: 100%; height: 32px" />
            </td>
          <td class="bx">所属小队</td>
            <td>
                <input class="easyui-combobox" style="width: 100%; height: 32px" panelHeight="auto"/>
            </td>
        </tr>
            <tr>
                  <td class="bx">资质</td>
                 <td>
                     <input class="easyui-textbox" style="width: 100%; height: 32px" />
                 </td>
            
                <td class="bx">规格</td>
                <td>
                     <input class="easyui-textbox" style="width: 100%; height: 32px" />
                </td>
               
                <td class="bx">型号</td>
                <td>
                    <input class="easyui-textbox" style="width: 100%; height: 32px" />
                </td>
              
            </tr>
             <tr>
                  <td class="bx">生产厂家</td>
                <td>
                     <input class="easyui-textbox" style="width: 100%; height: 32px" />
                </td>
                 <td class="bx">国别</td>
                 <td>
                     <input class="easyui-combobox" style="width: 100%; height: 32px"  panelHeight="auto" />
                 </td>
                   <td class="bx">出厂日期</td>
                <td>
                      <input class="easyui-datebox" style="width: 100%; height: 32px"  />
                </td>
            </tr>

               <tr>
                   <td class="bx">出厂编号</td>
                <td>
                     <input class="easyui-textbox" style="width: 100%; height: 32px" />
                </td>
                <td class="bx">投产日期</td>
                <td>
                    <input class="easyui-datebox" style="width: 100%; height: 32px"  />
                </td>
                <td class="bx">设备现编号</td>
                <td>
                     <input class="easyui-textbox" style="width: 100%; height: 32px" />
                </td>
               
            </tr>
            <tr>
                 <td class="bx">设备自编号</td>
                    <td>
                        <input class="easyui-textbox" style="width: 100%; height: 32px" />
                    </td>
                <td class="bx">色谱</td>
                <td>
                         <input class="easyui-textbox" style="width: 100%; height: 32px" />
                </td>
                <td class="bx">
                   设备状况
                </td>
                <td>
                      <input class="easyui-combobox" style="width: 100%; height: 32px"  panelHeight="auto" />
                </td>
               
            </tr>
            <tr>
               <td class="bx">
                  所属单位
                </td>
                <td>
                     <input class="easyui-textbox" style="width: 100%; height: 32px" />
                </td>
                <td class="bx">设备所在位置</td>
                <td>
               <input class="easyui-textbox" style="width: 100%; height: 32px" />
                </td>     
                 <td class="bx">大修时间</td>
                <td>
                     <input class="easyui-datebox" style="width: 100%; height: 32px"  />
                </td>
            </tr>
             <tr>
               <td class="bx">
                  硫化氢探头
                </td>
                <td>
                     <input class="easyui-textbox" style="width: 100%; height: 32px" />
                </td>
                <td class="bx">硫化氢年检</td>
                <td>
                  <input class="easyui-textbox" style="width: 100%; height: 32px" />
                </td>     
                 <td class="bx">气体标样</td>
                <td>
                      <input class="easyui-textbox" style="width: 100%; height: 32px" />
                </td>
              
            </tr>
            <tr>
                   <td class="bx">备注</td>
                <td>
                      <input class="easyui-textbox" style="width: 100%; height: 32px" />
                </td>
            </tr>
            <tr>
                <td colspan="6"> 
                    <a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" style="width:92px;line-height:28px;color:#000">保 存</a>
                </td>
            </tr>
    </table>
    </div>
    </div>--%>

</div>
            <!--选择字段弹出框-->
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
                <div id="ZD">
            	<ul style="list-style:none;padding:0;margin:0">
                    <li><input type="checkbox" value="SBMC" /><span>设备名称</span></li>
                    <li><input type="checkbox" value="DW" /><span>单位名称</span></li>
                    <li><input type="checkbox" value="SSXD" /><span>所属小队</span></li>
                    <li><input type="checkbox" value="ZZ" /><span>资质</span></li>
                    <li><input type="checkbox" value="GGXH" /><span>规格型号</span></li>
                    <li><input type="checkbox" value="SCCJ" /><span>生产厂家</span></li>
                    <li><input type="checkbox" value="GB" /><span>国别</span></li>
                    <li><input type="checkbox" value="CCRQ_DG" /><span>出厂日期</span></li>
                    <li><input type="checkbox" value="CCBH" /><span>出厂编号</span></li>
                    <li><input type="checkbox" value="TCRQ_DG" /><span>投产日期</span></li>
                    <li><input type="checkbox" value="SBXBH" /><span>设备现编号</span></li>
                    <li><input type="checkbox" value="SBZBH" /><span>设备自编号</span></li>
                    <li><input type="checkbox" value="SP" /><span>色谱</span></li>
                    <li><input type="checkbox" value="SPFXZQ" /><span>色谱分析周期</span></li>
                    <li><input type="checkbox" value="SBZK" /><span>设备状况</span></li>
                    <li><input type="checkbox" value="SSDW" /><span>所属单位</span></li>
                    <li><input type="checkbox" value="SBSZWZ" /><span>设备所在位置</span></li>
                    <li><input type="checkbox" value="DXSJ" /><span>大修时间</span></li>
                    <li><input type="checkbox" value="LHQTT" /><span>硫化氢探头</span></li>
                    <li><input type="checkbox" value="LHQNJ" /><span>硫化氢年检</span></li>
                    <li><input type="checkbox" value="QTBY" /><span>气体标样</span></li>
                    <li><input type="checkbox" value="BZ" /><span>备注</span></li>
	</ul>
    </div>
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
<script src="../../Scripts/LQZY/LQ_SB_ZHY.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $('#designSelect .datagrid-pager').css({ 'width': '100%', 'position': 'absolute', 'bottom': '40'+"px" });
        var height = $(window).height() - $('#designSelect .panel-htop').offset().top - $(document).scrollTop();
        $('#designSelect .panel-htop').css({ 'height': height + 'px' });
        $('#designSelect .datagrid-wrap').css({ 'height': height - 2 + 'px', 'border-bottom': '1px solid #95B8E7', 'position': 'relative' });
    });


    $(window).resize(function () {
        $('#designSelect .datagrid-pager').css({ 'width': '100%', 'position': 'absolute', 'bottom': '40'+"px" });
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

    </script>
