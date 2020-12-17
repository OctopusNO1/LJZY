<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LQ_DJCH.aspx.cs" Inherits="LJZY.WEB.Page.DJSJ.LQ_DJCH" %>

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
    <link href="../../CSS/LQ_DJCH.css" rel="stylesheet" />
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
<body class="easyui-layout">
    <div id="loading" style="position:absolute;z-index:1000;top:0px;left:0px;width:100%;height:100%;background:#ffffff;text-align :center;padding-top:20%;">
     <h3><font color="#242b5f">加载中....</font></h3>
</div> 
    <!--二级目录树-->
    <%--<div data-options="region:'west',split:true" title="菜单" style="width: 200px;overflow-y:auto;">
        <ul id="tt" class="easyui-tree">
        </ul>
          <span id="treeVal" style="display:none;"></span>
    </div>--%>

    <div data-options="region:'center',iconCls:'icon-ok',border:false" >
        <div class="easyui-tabs" data-options="fit:true,plain:true">
    <!--人员查询-->
    <div title="单井策划查询">   
        <div class="search_div" style="padding-left:5px">
            <div style="height:4px;"></div>
                <%--<button class="easyui-linkbutton btnGetType" style="margin-left:5px" onclick="Showdailog()">选择字段</button>--%>
                 <input id="SelectColumn_List" class="easyui-combobox" data-options="
                            url:'../../Controllers/ColumnListController.ashx?action=DJCHYAQHSE_ZD',
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
                <input class="easyui-textbox" style="width: 150px; height: 32px" data-options="prompt:'请输入关键字'" id="isvalue"  />
                <input type="checkbox" id="chkbox"/><span>OR</span>
                <button class="easyui-linkbutton btnGetType" onclick="addTJ();">添加条件</button>                   
                         <div id="SelectWhere">                     
                         </div>    
                <button class="easyui-linkbutton btnGetType" id="sousuo" onclick="doSearch1()">搜索</button>
                <button class="easyui-linkbutton btnGetType" onclick="insert()">导入</button>
        </div>
        <div style="clear:both"></div>
        <div title="DataGrid"  border-style: "none" id="designSelect" data-options="closable:true;fit:true" style="height:100%;width:100%;padding:0px 0px 0 1px;">
            <table class="easyui-datagrid" id="dg">
			</table>
        </div>
	</div>
    </div>
    </div>
    <!--选择字段弹出框-->
<div id="dlg" class="easyui-dialog" title="Basic Dialog"  data-options="
    iconCls:'icon-save',toolbar: [{
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
                     }],buttons: '#dlg-buttons' " style="width:240px;height:300px;padding:10px;overflow-y:scroll;color:#000" closed="true">
                    <div id="ZD">
            		<ul style="list-style:none;padding:0;margin:0">
             <li><input type="checkbox" /><span>地区</span></li>
            <li><input type="checkbox" /><span>区块</span></li>
            <li><input type="checkbox" /><span>井别</span></li>
            <li><input type="checkbox" /><span>井型</span></li>
            <li><input type="checkbox" /><span>甲方单位</span></li>     
            <li><input type="checkbox" /><span>录井项目部</span></li>    
            <li><input type="checkbox" /><span>编制人</span></li>
            <li><input type="checkbox" /><span>编制日期</span></li>
            <li><input type="checkbox" /><span>备注</span></li>

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
<script src="../../Scripts/LQZY/LQ_DJCH.js"></script>
<script src="../../PDFjs/build/pdf.js"></script>
<script type="text/javascript">
        //获取二级目录树
        $('#tt').tree({
            url: '../../Controllers/ColumnListController.ashx?action=EJML_List',
            loadFilter: function (rows) {
                return convert(rows);
            }
        });
        function convert(rows) {
            function exists(rows, parentId) {
                for (var i = 0; i < rows.length; i++) {
                    if (rows[i].ID == parentId) return true;
                }
                return false;
            }

            var nodes = [];
            // get the top level nodes
            for (var i = 0; i < rows.length; i++) {
                var row = rows[i];
                if (!exists(rows, row.PID)) {
                    nodes.push({
                        id: row.ID,
                        text: row.MC
                    });
                }
            }

            var toDo = [];
            for (var i = 0; i < nodes.length; i++) {
                toDo.push(nodes[i]);
            }
            while (toDo.length) {
                var node = toDo.shift();	// the parent node
                // get the children nodes
                for (var i = 0; i < rows.length; i++) {
                    var row = rows[i];
                    if (row.PID == node.id) {
                        var child = { id: row.ID, text: row.MC };
                        if (node.children) {
                            node.children.push(child);
                        } else {
                            node.children = [child];
                        }
                        toDo.push(child);
                    }
                }
            }
            return nodes;
        }

        $('#tt').tree({
            onClick: function (node) {
                $('#treeVal').html(node.text);
                console.log(node);
                if (!node.children) {
                    $('#dg').datagrid('load', {
                        strTree: $('#treeVal').text()
                    });
                }

            }

        });

        //点击回车触发搜索事件
        $("body").keydown(function () {
            if (event.keyCode == "13") {//keyCode=13是回车键
                $('#sousuo').click();
            }
        });

    //function Showdailog()
    //{
    //    $("#dlg").dialog("open").dialog("setTitle", "选择字段");
    //}

    //function Closedialog()
    //{
    //    $('#dlg').dialog('close');
    //}
   
    //function saveXZ() {

    //    var arr = [];

    //    $("#ZD ul li").each(function () {
    //        if ($(this).children("input").is(':checked')) {
    //            arr.push($(this).find("span").html());
    //        }
           
    //    })
    //    console.log(arr);
    //    $.ajax({
    //        type: "POST",
    //        url: "../../Controllers/ColumnListController.ashx?action=getZD",
    //        data: {
    //            "zdlist": JSON.stringify(arr)
                
    //        },
    //        dataType: 'json',
    //        async: false,
    //        success: function (data) {
    //            console.log(data)
    //            $("#SelectColumn_List").combobox('reload', '../../Controllers/ColumnListController.ashx?action=getZD');
    //            Closedialog();
    //        },
    //        error: function (XMLHttpRequest, textStatus, errorThrown) {
    //            console.log(errorThrown);
    //        }
    //    });
    //}
</script>

