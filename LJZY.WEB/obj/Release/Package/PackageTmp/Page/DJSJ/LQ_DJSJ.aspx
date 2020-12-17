<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LQ_DJSJ.aspx.cs" Inherits="LJZY.WEB.Page.DJSJ.LQ_DJSJ" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>Basic Layout - jQuery EasyUI Demo</title>
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["theme"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["icon"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["demo"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/layui/css/layui.css" rel="stylesheet" />
    <link href="../../CSS/LQ_DJSJ.css" rel="stylesheet" />
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["jquery"].ToString()%>" type="text/javascript"></script>   
    <script src="../../Scripts/layui/layui.js"></script> 
      <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-min"].ToString()%>" type="text/javascript"></script>
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-zh_CN"].ToString()%>" type="text/javascript"></script>
    <script src="../../PDFjs/build/pdf.js"></script>
    <script src="../../Scripts/LQZY/LQ_DJSJ.js"></script>
    <style>
        .processcontainer {
            width: 100%;
            border: 1px solid #6C9C2C;
            height: 16px;
            margin: 4px 0;
        }

        #processbar {
            background: #95CA0D;
            float: left;
            height: 100%;
            text-align: center;
            line-height: 150%;
        }

        .clear {
            display: block;
            content: "";
            clear: both;
        }
        #designSelect .layui-table-view{
            margin:0 0 10px 0;
        }
        #designSelect .layui-table thead tr{
            background-color: #e3efff;
            border-top:1px solid #95B8E7;
            /*border-left:1px solid #95B8E7;
            border-right:1px solid #95B8E7;*/
        }
         /*#designSelect .layui-table-body{
             border-left:1px solid #95B8E7;
            border-right:1px solid #95B8E7;
         }
         #designSelect .layui-table-page{
              border-bottom:1px solid #95B8E7;
            border-left:1px solid #95B8E7;
            border-right:1px solid #95B8E7;
         }*/
    </style>
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
            var height = $(window).height() - $(document).scrollTop();
            //var height = $(window).height() - $('#designSelect .panel-htop').offset().top - $(document).scrollTop();
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
            //$("#dg").datagrid('resize', { height: parent.$('.layout-panel-center').height() - mwidth });
            $('#designSelect .datagrid-pager').css({ 'width': '100%', 'position': 'absolute', 'bottom': '0' });
            var height = $(window).height() - $(document).scrollTop();
            //var height = $(window).height() - $('#designSelect .panel-htop').offset().top - $(document).scrollTop();
            $('#designSelect .panel-htop').css({ 'height': height + 'px' });
            $('#designSelect .datagrid-wrap').css({ 'height': height - 2 + 'px', 'border-bottom': '1px solid #95B8E7', 'position': 'relative' });


        });

        var Type = getUrlParam('type');
        function getUrlParam(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
            var r = window.location.search.substr(1).match(reg);  //匹配目标参数
            if (r != null) return unescape(r[2]); return null; //返回参数值
        }
        //console.log(Type)
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

</script>
</head>
<body class="easyui-layout">
    <div id="loading" style="position:absolute;z-index:1000;top:0px;left:0px;width:100%;height:100%;background:#ffffff;text-align :center;padding-top:20%;">
     <h3><font color="#242b5f">加载中....</font></h3>
</div> 
    <%--<div data-options="region:'west',split:true" title="菜单" style="width: 200px;overflow-y:auto;min-width:163px;">
        <ul id="tt" class="easyui-tree">
        </ul>
        <span id="treeVal" style="display:none;"></span>
    </div>--%>
    <div data-options="region:'center',iconCls:'icon-ok',border:false" >
        <div class="easyui-tabs" data-options="fit:true,plain:true">
           
            <div title="设计查询" >
                <div class="contentbox" id="abcdedg">
                    <div style="height: 40px;background: #e3efff;padding:5px 0 0 6px;box-sizing:border-box">
                        <%--<button class="easyui-linkbutton btnGetType" onclick="Showdailog()">选择字段</button>--%>
                        <input id="SelectColumn_List" class="easyui-combobox" data-options="
                        url:'../../Controllers/ColumnListController.ashx?action=DJSJ_ZD',
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
                    </div>
                    <div  title="DataGrid" id="designSelect" style="border-style:none" data-options="closable:true;fit:true">
                        <%--<div style="padding:0px 3px 0 1px;"> --%>                
                            <%--<table id="dg" style="width:100%;height:100%" class="easyui-datagrid">                      
                            </table>--%>
                            <table class="layui-bg-blue"  style="width:100%;height:100%;" lay-filter="toolDG" id="dg"></table>
                            <script type="text/html" id="barDemo1">
                                <a class="layui-btn layui-btn-danger layui-btn-xs" lay-event="view">查看</a>
                                <a href="#" class="layui-btn layui-btn-primary layui-btn-xs" lay-event="download" download>下载</a> 
                            </script>                         
                            <script type="text/html" id="barDemo2">
                                <a class="layui-btn layui-btn-danger layui-btn-xs" lay-event="view1">查看</a>
                                <a href="#" class="layui-btn layui-btn-primary layui-btn-xs" lay-event="download1" download>下载</a> 
                            </script>
                         <script type="text/html" id="barDemo3">
                                <a class="layui-btn layui-btn-danger layui-btn-xs" lay-event="view2">查看</a>
                                <a href="#" class="layui-btn layui-btn-primary layui-btn-xs" lay-event="download2" download>下载</a> 
                            </script> 
                         <script type="text/html" id="barDemo4">
                                <a class="layui-btn layui-btn-danger layui-btn-xs" lay-event="view3">查看</a>
                                <a href="#" class="layui-btn layui-btn-primary layui-btn-xs" lay-event="download3">下载</a> 
                            </script> 
                         <script type="text/html" id="barDemo5">
                                <a class="layui-btn layui-btn-danger layui-btn-xs" lay-event="view4">查看</a>
                                <a href="#" class="layui-btn layui-btn-primary layui-btn-xs" lay-event="download4" download>下载</a> 
                            </script> 
                        <%--</div>--%>
                    </div>
                </div>     
            </div>
            <div title="设计入库">
                <div class="contentbox">
                    <div style="height: 80px;margin: 0 auto;width: 780px;padding-top:20px;padding-left: 8px;">
                        <table style="background: #C4D6EE;">
                            <tr>
                                <td style="padding:0 15px"><button  class="easyui-linkbutton btnAdd" onclick="clearForm()" style="background:url(/Image/add.png) no-repeat center center;width:100px;height:30px"></button></td>
                                <td style="padding:0 14px"><button  class="easyui-linkbutton btnShou" onclick="loadRemote_Home()" style="background:url(/Image/shou.png) no-repeat center center;width:100px;height:30px"></button></td>
                                <td style="padding:0 14px"><button  class="easyui-linkbutton btnShang" onclick="loadRemote_Up()" style="background:url(/Image/shang.png) no-repeat center center;width:100px;height:30px"></button></td>
                                <td style="padding:0 14px"><button  class="easyui-linkbutton btnXia" onclick="loadRemote_Down()" style="background:url(/Image/xia.png) no-repeat center center;width:100px;height:30px"></button></td>
                                <td style="padding:0 14px"><button  class="easyui-linkbutton btnWei" onclick="loadRemote_End()" style="background:url(/Image/wei.png) no-repeat center center;width:100px;height:30px"></button></td>
                                <td style="padding:0 15px 0 14px "><button  class="easyui-linkbutton btnDel" onclick="delForm()" style="background:url(/Image/del.png) no-repeat center center;width:100px;height:30px"></button></td>
                            </tr>
                        </table>
                    </div>
                    <form id="ff" method="post" data-options="novalidate:true" name="contractForm">
                        <div style="width:780px;margin:0 auto;">
                            <div>
                                <table style="border-collapse: inherit;border-spacing: 4px;">
                                    <tr>
                                        <td>
                                            <div class="bx bxCompany">甲方单位</div>                                         
                                        </td>
                                        <td>
                                            <input id="List_SC3" name="SC3" class="easyui-combobox" data-options="
                    url:'../../Controllers/ColumnListController.ashx?action=List_SC3',
					method:'post',
					valueField:'NAME',
					textField:'NAME',
                    editable:false,
                    value:'勘探公司'" style="width:248px;"/>
                                        </td>
                                        <td style="display:none;">
                                            <input name="ID" id="txtID" value="" style="height: 32px" />
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    
                                </table>
                            </div>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <div class="bx">井号</div>
                                        </td>
                                        <td>
                                            <input name="ZJH" id="txtZJH" class="easyui-textbox" style="width: 150px; height: 32px" data-options="required:true,validType:'length[1,10]'" />
                                        </td>
                                        <td>
                                            <div class="bx">井筒号</div>
                                        </td>
                                        <td>
                                            <input name="JH" id="txtJH" class="easyui-textbox" style="width:150px; height: 32px" data-options="required:true,validType:'length[1,10]'" />
                                        </td>
                                        <td>
                                            <div class="bx">地区</div>
                                        </td>
                                        <td>
                                            <input name="SC2" id="List_SC2" class="easyui-combobox" style="width: 150px; height: 32px" data-options="
                    url:'../../Controllers/ColumnListController.ashx?action=List_SC2',
					method:'post',
					valueField:'NAME',
					textField:'NAME',
                    editable:false,
                    value:'西北缘'" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <div class="bx">井型</div>
                                        </td>
                                        <td>

                                            <input name="JX" id="List_JX" class="easyui-combobox" style="width: 150px;  height: 32px" data-options="
                    url:'../../Controllers/ColumnListController.ashx?action=List_JX',
					method:'post',
					valueField:'NAME',
					textField:'NAME',
                    editable:false,
                    required:true,
                    value:'直井'" />

                                        </td>
                                        <td>
                                            <div class="bx">井别</div>
                                        </td>
                                        <td>

                                            <input name="REPORT_TYPE" id="List_TYPE" class="easyui-combobox" style="width: 150px; height: 32px" data-options="
                    url:'../../Controllers/ColumnListController.ashx?action=List_TYPE',
					method:'post',
					valueField:'NAME',
					textField:'NAME',
                    editable:false,
                    value:'取心井'" />
                                        </td>
                                        <td>
                                            <div class="bx">区块</div>
                                        </td>
                                        <td>
                                            <input name="QK" id="List_QK" class="easyui-combobox" style="width: 150px; height: 32px" data-options="
                    url:'../../Controllers/ColumnListController.ashx?action=List_QK',
					method:'post',
					valueField:'NAME',
					textField:'NAME',
                    editable:true,
                    value:'玛湖'" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table>
                                    <tr>
                                        <td >
                                            <div class="bx">地理位置</div>
                                        </td>
                                        <td colspan="5">
                                            <input name="DLWZ" id="txtDLWZ" class="easyui-textbox" style="width: 670px; height: 32px;">
                                        </td>

                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <div class="bx">构造位置</div></td>
                                        <td colspan="5">
                                            <input name="GZWZ" id="txtGZWZ" class="easyui-textbox" style="width: 670px; height: 32px">
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <div class="bx">测线位置</div></td>
                                        <td colspan="5">
                                            <input name="CXWZ" id="txtCXWZ" class="easyui-textbox" style="width: 670px; height: 32px">
                                        </td>
                                    </tr>

                                </table>
                            </div>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <div class="bx">设计井深</div></td>
                                        <td>
                                            <input name="SJJS" id="numSJJS" class="easyui-numberbox" style="width: 150px;  height: 32px" data-options="max:99999,precision:2">
                                        </td>
                                        <td>
                                            <div class="bx">加深设计井深</div></td>
                                        <td>
                                            <input name="JSSJJS" id="numJSSJJS" class="easyui-numberbox" style="width: 150px; height: 32px" data-options="max:99999,precision:2">
                                        </td>
                                        <td>
                                            <div class="bx">完钻井深</div></td>
                                        <td>
                                            <input name="WZJS" id="numWZJS" class="easyui-numberbox" style="width: 150px; height: 32px" data-options="max:99999,precision:2">
                                        </td>

                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <div class="bx">目的层</div></td>
                                        <td colspan="4">
                                            <input name="ZYMDC" id="txtMDC" class="easyui-textbox" style="width: 670px; height: 32px"></td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <div class="bx">设计横坐标(北京)</div></td>
                                        <td>
                                            <input name="SJHZBB" id="numSJHZBB" class="easyui-numberbox" style="width: 150px;  height: 32px" data-options="precision:2">
                                        </td>
                                        <td>
                                            <div class="bx">设计横坐标(西安)</div></td>
                                        <td>
                                            <input name="SJHZBX" id="numSJHZBX" class="easyui-numberbox" style="width: 150px; height: 32px" data-options="precision:2">
                                        </td>
                                        <td>
                                            <div class="bx">实测横坐标</div></td>
                                        <td>
                                            <input name="SJHZB" id="numSJHZB" class="easyui-numberbox" style="width:150px; height: 32px" data-options="precision:2">
                                        </td>

                                    </tr>

                                </table>
                            </div>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <div class="bx">设计纵坐标(北京)</div></td>
                                        <td>
                                            <input name="SJZZBB" id="numSJZZBB" class="easyui-numberbox" style="width: 150px;  height: 32px" data-options="precision:2">
                                        </td>
                                        <td>
                                            <div class="bx">设计纵坐标(西安)</div></td>
                                        <td>
                                            <input name="SJZZBX" id="numSJZZBX" class="easyui-numberbox" style="width:150px; height: 32px" data-options="precision:2">
                                        </td>
                                        <td>
                                            <div class="bx">实测纵坐标</div></td>
                                        <td>
                                            <input name="SJZZB" id="numSJZZB" class="easyui-numberbox" style="width: 150px; height: 32px" data-options="precision:2">
                                        </td>

                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table>
                                    <tr>
                                        <td>
                                            <div class="bx">地面海拔</div></td>
                                        <td>
                                            <input name="DMHB" id="numDMHB" class="easyui-numberbox" style="width: 150px;  height: 32px" data-options="max:99999,precision:2">
                                        </td>
                                        <td>
                                            <div class="bx">设计人</div></td>
                                        <td>
                                            <input name="SJR" id="txtSJR" class="easyui-textbox" style="width: 150px; height: 32px">
                                        </td>
                                       
                                        <td>
                                            <div class="bx">设计日期</div></td>
                                        <td>
                                            <input id="SJRQTime" name="SJRQ" class="easyui-datebox" style="width: 150px; height: 32px"  />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table>
                                    <tr>
                                         <td>
                                             <div class="bx">补心高</div></td>
                                        <td>
                                            <input name="BXG" id="numBXG" class="easyui-numberbox" style="width: 150px;  height: 32px" data-options="max:99999,precision:2">
                                        </td>
                                       
                                        <td>
                                            <div class="bx">审批人</div></td>
                                        <td>
                                            <input name="SPR" id="txtSPR" class="easyui-textbox" style="width: 150px; height: 32px" />
                                        </td>
                                        <td>
                                            <div class="bx">审批日期</div></td>
                                        <td>
                                            <input id="SPRQTime" name="SPRQ" class="easyui-datebox" style="width: 150px; height: 32px"  />
                                        </td>

                                    </tr>

                                </table>
                            </div>
                            <div>
                                <table>
                                    <tr>
                                         <td>
                                            <div class="bx">录井项目部</div>
                                        </td>
                                        <td>
                                            <input name="LJFGS" id="List_LJFGS" class="easyui-combobox" style="width: 150px;  height: 32px" data-options="
                    url:'../../Controllers/ColumnListController.ashx?action=List_LJFGS',
					method:'post',
					valueField:'NAME',
					textField:'NAME',
                    editable:false,
                    value:'第一项目部'" />
                                        </td>
                                        <td>
                                            <div class="bx">是否派工</div>
                                        </td>
                                        <td> 
                                            <select class="easyui-combobox" name="ISLATESTRECORD" id="ISLATESTRECORD" style="width:150px;  height: 32px" data-options="select:'1'">
		                                    <option value="0">否</option>
		                                    <option value="1">是</option>   
	                                    </select>
                                        </td>
                                        <td><div class="bx">完成派工</div></td>
                                        <td><select class="easyui-combobox" name="ISFINISH" id="ISFINISH" style="width: 150px;  height: 32px" data-options="select:0,disabled:true">
		                                    <option value="0">否</option>
		                                    <option value="1">是</option></select>  </td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table>
                                    <tr>
                                        <td>备注</td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </table>
                            </div>
                            <div>
                                <table>
                                    <tr>

                                        <td style="width: 660px;">
                                            <input name="BZ" id="txtBZ" class="easyui-textbox" data-options="multiline:true" value="" style="width: 660px; height: 150px">
                                        </td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            
                                            <a href="/Template/设计导入模板.docx" class="easyui-linkbutton bx btnGetType" style="width:92px;margin-bottom:10px;line-height:28px;color:#000" lay-event="download" download>模板下载</a>
                                            <a href="#" onclick="openWin()" class="easyui-linkbutton bx btnGetType" style="width:92px;margin-bottom:10px;line-height:28px;color:#000">设计导入</a>
                                            <a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" onclick="submitForm();" style="width:92px;line-height:28px;color:#000">保 存</a>
                                        </td>

                                    </tr>
                                </table>
                            </div>

                            <div id="win" class="easyui-window" title="提示" style="width:600px;height:400px" closed="true" data-options="iconCls:'icon-save',modal:true">       
            
                                <div data-options="region:'north',title:'North Title',split:true" style="height:50px;">                                    
                                    <input name="fatherId" id="fatherId" class="easyui-textbox" data-options="multiline:true" value="" style="width: 100%; height: 320px;margin-bottom:5px;"> 
                                   
                                    <a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" onclick="assgVal();" style="width:50px;line-height:28px;color:#000;display:block;margin:0 auto;">确 定</a>                                
                                </div>              
                            </div>  

                            <div id="DelWin" class="easyui-window" title="提示" style="width:300px;height:200px" closed="true" data-options="iconCls:'icon-save',modal:true">       
            
                                <div data-options="region:'north',title:'North Title',split:true" style="height:50px;">                                    
                                    <div id="DelTitle" data-options="multiline:true" style="width: 100%; height: 120px;margin-bottom:5px;"><span>确定是否删除!</span></div>                                   
                                    <a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" onclick="delForm();">确 定</a>
                                    <a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" onclick="closeDelWin();">取 消</a>                                 
                                </div>               
                            </div>  
                        </div>
                    </form>             
                </div>
            </div>
            <div title="设计上传">
                <div id="designUp" class="contentbox">
                    <div style="width:70%;margin:20px auto;margin-bottom: 0;">
                            <table style="width:100%;min-width:780px;table-layout:fixed;">
                                <tr>
                                    <td class="bx">井号</td>
                                    <td class="bxinput">
                                        
                                            <%--  <div style="width: 100%; height: 33px;">
                                            <select id="zjhVal" style="width:100%;height:34px;border:1px solid #95B8E7;">
                                                <option value=""></option>
                                            </select>--%>
                                            <input name="zjhVal" id="zjhVal" class="easyui-combobox" style="width: 100%; height: 32px" />
                                        <%--</div>--%>
                                    </td>
                                    <%--<td class="bx">井型</td>--%>
                                    <%--<td  class="bxinput"> 
                                        <input name="jxVal" id="jxVal" class="easyui-combobox" style="width: 100%; height: 32px" data-options="
                                                url:'../../Controllers/ColumnListController.ashx?action=JX_UpList',
					                            method:'post',
					                            valueField:'NAME',
					                            textField:'NAME',
                                                value:'预探井'" />
                                    </td>--%>
                                    <td class="bx">井别</td>
                                    <td  class="bxinput"> 
                                        <input name="typeVal" id="typeVal" class="easyui-combobox" style="width: 100%; height: 32px" data-options="
                    url:'../../Controllers/ColumnListController.ashx?action=TYPE_UpList',
					method:'post',
					valueField:'NAME',
					textField:'NAME', 
                    value:'探井'" />
                                    </td>
                                    <td class="bx">年度</td>
                                    <td  class="bxinput">
                                        <input type="text" class="jeasy-combobox" name="year" id="yearChoose">                                 
                                    </td>
                                </tr>
                            </table>
                    </div>                 
                    <div style="width:70%;margin:0 auto;">
                        <table style="width:100%;min-width:780px;table-layout:fixed;">
                            <tr>
                                <td class="bx">井位设计</td>
                                <td  style="width:100%">
                                    <div id="inputContent">
                                        <span></span>
                                        <button type="button" class=" easyui-linkbutton btnGetType" id="testList">选择文件</button>
                                    </div>
                                </td>
                                <td style="width:58px"><button type="button" class="easyui-linkbutton btnGetType" id="testListAction">上传</button></td>
                            </tr>
                            <tr>
                                <td class="bx">钻井地质设计</td>
                                <td  style="width:100%">
                                    <div id="inputContent1">
                                        <span></span>
                                        <button type="button" class="easyui-linkbutton btnGetType" id="testList1">选择文件</button>
                                    </div>
                                </td>
                                <td style="width:58px"><button type="button" class="easyui-linkbutton btnGetType" id="testListAction1">上传</button></td>
                            </tr>
                            <tr>
                                <td class="bx">附件</td>
                                <td  style="width:100%">
                                    <div id="inputContent2">
                                        <span></span>
                                        <button type="button" class="easyui-linkbutton btnGetType" id="testList2">选择文件</button>
                                    </div>
                                </td>
                                <td style="width:58px"><button type="button" class="easyui-linkbutton btnGetType" id="testListAction2">上传</button></td>
                            </tr>
                            <tr>
                                <td class="bx">设计讨论多媒体</td>
                                <td  style="width:100%">
                                    <div id="inputContent3">
                                        <span></span>
                                        <button type="button" class="easyui-linkbutton btnGetType" id="testList3">选择文件</button>
                                    </div>
                                </td>
                                <td style="width:58px"><button type="button" class="easyui-linkbutton btnGetType" id="testListAction3">上传</button></td>
                            </tr>
                            <tr>
                                <td class="bx">钻井工程设计</td>
                                <td  style="width:100%">
                                    <div id="inputContent4">
                                        <span></span>
                                        <button type="button" class="easyui-linkbutton btnGetType" id="testList4">选择文件</button>
                                    </div>
                                </td>
                                <td style="width:58px"><button type="button" class="easyui-linkbutton btnGetType" id="testListAction4">上传</button></td>
                            </tr>
                            <tr>
                                <td class="bx">单井策划</td>
                                <td  style="width:100%">
                                    <div id="inputContent5">
                                        <span></span>
                                        <button type="button" class="easyui-linkbutton btnGetType" id="testList5">选择文件</button>
                                    </div>
                                </td>
                                <td style="width:58px"><button type="button" class="easyui-linkbutton btnGetType" id="testListAction5">上传</button></td>
                            </tr>
                            <tr>
                                <td class="bx">单井应急预案</td>
                                <td  style="width:100%">
                                    <div id="inputContent6">
                                        <span></span>
                                        <button type="button" class="easyui-linkbutton btnGetType" id="testList6">选择文件</button>
                                    </div>
                                </td>
                                <td style="width:58px"><button type="button" class="easyui-linkbutton btnGetType" id="testListAction6">上传</button></td>
                            </tr>
                            <tr>
                                <td class="bx">QSHE作业计划书</td>
                                <td  style="width:100%">
                                    <div id="inputContent7">
                                        <span></span>
                                        <button type="button" class="easyui-linkbutton btnGetType" id="testList7">选择文件</button>
                                    </div>
                                </td>
                                <td style="width:58px"><button type="button" class="easyui-linkbutton btnGetType" id="testListAction7">上传</button></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <div style="overflow-y: auto; height: 100px;">
                                    <table id="demoListBaba">
                                        <thead>
                                        <tr>
                                            <th>序号</th>
                                            <th>所属</th>
                                            <th>文件名</th>
                                            <th>大小</th>
                                            <th>进度</th>
                                            <th>状态</th>
                                        </tr>
                                        </thead>
                                        <tbody id="demoList">                                                
                                        </tbody>
                                    </table>
                                    </div>
                                </td>
                            </tr>

                        </table>
                    </div>
                    <div style="width:70%;margin:0 auto;">
                        <div title="DataGrid" style="padding:2px; border-style: none" data-options="closable:true;fit:true">
                            
                            <table class="layui-hide" id="LAY_table_user" lay-filter="user" style="min-width:780px;"></table>
                            <script type="text/html" id="barDemo">
                                <a href="#" class="layui-btn layui-btn-primary layui-btn-xs" lay-event="download" download>下载</a>
                                <a class="layui-btn layui-btn-danger layui-btn-xs" lay-event="del">删除</a>
                            </script>

                        </div>
                    </div>
                </div>
            </div>
            <%--#region 生产派工--%>
            <%--  <div title="生产派工" style="overflow-x:auto;overflow-y:auto;">
                <div id="SCPG_content" style="width:80%;min-height:800px;margin:auto;position:relative">
                      <div class="easyui-panel clear" title="勘探井" style="width:400px;height:310px;padding:10px">
                             <div style="position:absolute;top:40px;left:10px">
                          <span><input type="checkbox" id="one_check"/>全选</span></div>
                       <div class="react_JH" id="react_JH" style="overflow:hidden;overflow-y:auto;width:200px;overflow-x:auto;height:240px;float:left;border:1px solid #95B8E7;margin-top:20px"></div>
		                            <ul style="width:160px;min-height:150px;float:left;margin-left:10px" id="one_CZ">
			                            <li style="">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('第一项目部','one_check')">第一项目部</a>
			                            </li>
                                          <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('第二项目部','one_check')">第二项目部</a>
			                            </li>
                                         <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('第三项目部','one_check')">第三项目部</a>
			                            </li>
                                          <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('准东项目部','one_check')">准东项目部</a>
			                            </li>
                                          <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('塔里木项目部','one_check')">塔里木项目</a>
			                            </li>
                                         <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('海外项目部','one_check')">海外项目</a>
			                            </li>
                                          <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('其他','one_check')">其他</a>
			                            </li>
		                            </ul>
	                </div>
                      <div class="easyui-panel clear" title="评价井" style="width:400px;height:330px;padding:10px">
                       <div style="position:relative;top:-4px;left:10px">
                          <span><input type="checkbox" id="two_check"/>全选</span></div>
                       <div class="react_JH" id="react_JH2" style="overflow:hidden;overflow-y:auto;width:200px;height:240px;float:left;border:1px solid #95B8E7;">
                               
                       </div>
		                            <ul style="width:160px;min-height:150px;float:left;margin-left:10px" id="two_CZ">
			                            <li style="">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('第一项目部','two_check')">第一项目部</a>
			                            </li>
                                          <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('第二项目部','two_check')">第二项目部</a>
			                            </li>
                                         <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('第三项目部','two_check')">第三项目部</a>
			                            </li>
                                          <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('准东项目部','two_check')">准东项目部</a>
			                            </li>
                                          <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('塔里木项目','two_check')">塔里木项目</a>
			                            </li>
                                         <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('海外项目','two_check')">海外项目</a>
			                            </li>
                                          <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('其他','two_check')">其他</a>
			                            </li>
		                            </ul>
	                </div>
                      <div  class="easyui-panel clear" title="开发井" style="width:400px;height:330px;padding:10px">
                           <div style="position:relative;top:-4px;left:10px">
                          <span><input type="checkbox" id="three_check" />全选</span></div>
                       <div class="react_JH" id="react_JH3"  style="overflow:hidden;overflow-y:auto;width:200px;height:240px;float:left;border:1px solid #95B8E7;"></div>
		                            <ul style="width:160px;min-height:150px;float:left;margin-left:10px" id="three_CZ">
			                            <li style="">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px"onclick="LJCZ('第一项目部','three_check')">第一项目部</a>
			                            </li>
                                          <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('第二项目部','three_check')">第二项目部</a>
			                            </li>
                                         <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('第三项目部','three_check')">第三项目部</a>
			                            </li>
                                          <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('准东项目部','three_check')">准东项目部</a>
			                            </li>
                                          <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('塔里木项目','three_check')">塔里木项目</a>
			                            </li>
                                         <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('海外项目','three_check')">海外项目</a>
			                            </li>
                                          <li style="margin-top:8px">
                                            <a href="#" class="easyui-linkbutton" style="background:#e3efff;width:100%;border-radius:5px" onclick="LJCZ('其他','three_check')">其他</a>
			                            </li>
		                            </ul>
	                </div>
                     <%-- 右侧 --%>
            <%--<div style="position:absolute;right:30px;top:0" id="right_BZ">
                            
                        <div  class="easyui-panel " title="第一项目部"  style="width:300px;min-height:200px;border:1px solid #95B8E7;">
                            <span style="position:absolute;top:6px;left:100px;font-weight: bold;color: #0E2D5F;">队伍总数<span class="one_total"></span></span>
    
                            <span style="position:absolute;top:6px;left:180px;font-weight: bold;color: #0E2D5F;">待命队伍<span class="one_DMD"></span></span>
                           <ul id="OneHT">
                               <li style="height:50px;border-bottom:1px solid #95B8E7"  >
                                   <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">勘探井</li>    
                                     <li   id="KTJ_one" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d1KTJ')" src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                                  
                               </li>
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                    <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff ;text-align:center;line-height:50px">评价井</li>    
                                     <li  id="PJJ_one" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                        
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d1PJJ')" src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                    <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">开发井</li>    
                                     <li  id="KFJ_one" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                       
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d1KFJ')" src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                           </ul>
                        </div>
                        <div  class="easyui-panel " title="第二项目部" style="position:relative;width:300px;min-height:200px;border:1px solid #95B8E7;">
                           <span style="position:absolute;top:-26px;left:100px;font-weight: bold;color: #0E2D5F;">队伍总数<span class="two_total"></span></span>
    
                            <span style="position:absolute;top:-26px;left:180px;font-weight: bold;color: #0E2D5F;">待命队<span class="two_DMD"></span></span>
                            <ul id="TwoHT">
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                    <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">勘探井</li>    
                                     <li id="KTJ_two"  style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img  onclick="HTClick('d2KTJ')"   src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                    <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">评价井</li>    
                                     <li  id="PJJ_two" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                      
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d2PJJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                    <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">开发井</li>    
                                     <li  id="KFJ_two" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d2KFJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                           </ul>
                        </div>
                        <div  class="easyui-panel " title="第三项目部" style="position:relative;width:300px;min-height:200px;border:1px solid #95B8E7;">
                                  <span style="position:absolute;top:-26px;left:100px;font-weight: bold;color: #0E2D5F;">队伍总数<span class="three_total"></span></span>
    
                            <span style="position:absolute;top:-26px;left:180px;font-weight: bold;color: #0E2D5F;">待命队伍<span class="three_DMD"></span></span>
                             <ul id="ThreeHT">
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                  <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">勘探井</li>    
                                     <li  id="KTJ_three" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d3KTJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                    <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">评价井</li>    
                                     <li  id="PJJ_three" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d3PJJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                    <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">开发井</li>    
                                     <li  id="KFJ_three" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d3KFJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                           </ul>
                        </div>
                        <div  class="easyui-panel " title="准东项目部"  style="position:relative;width:300px;min-height:200px;border:1px solid #95B8E7;">
                            <span style="position:absolute;top:-26px;left:100px;font-weight: bold;color: #0E2D5F;">队伍总数<span class="ZD_total"></span></span>
    
                            <span style="position:absolute;top:-26px;left:180px;font-weight: bold;color: #0E2D5F;">待命队伍<span class="ZD_DMD"></span> </span>
                           <ul id="ZDHT">
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                   <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">勘探井</li>    
                                     <li  id="KTJ_ZD" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d4KTJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                                  
                               </li>
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                    <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">评价井</li>    
                                     <li  id="PJJ_ZD"  style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d4PJJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                    <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">开发井</li>    
                                     <li  id="KFJ_ZD"  style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d4KFJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                           </ul>
                        </div>
                        <div  class="easyui-panel " title="塔里木项目部" style="position:relative;width:300px;min-height:200px;border:1px solid #95B8E7;">
                                  <span style="position:absolute;top:-26px;left:100px;font-weight: bold;color: #0E2D5F;">队伍总数<span class="TL_total"></span></span>
    
                            <span style="position:absolute;top:-26px;left:180px;font-weight: bold;color: #0E2D5F;">待命队伍<span class="TL_DMD"></span></span>
                            <ul id="TLHT">
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                    <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">勘探井</li>    
                                     <li  id="KTJ_TL"  style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d5KTJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                    <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">评价井</li>    
                                     <li  id="PJJ_TL" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d5PJJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                   <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">开发井</li>    
                                     <li  id="KFJ_TL" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d5KFJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                           </ul>
                        </div>
                        <div  class="easyui-panel " title="海外项目部" style="position:relative;width:300px;min-height:200px;border:1px solid #95B8E7;">
                             <span style="position:absolute;top:-26px;left:100px;font-weight: bold;color: #0E2D5F;">队伍总数<span class="HW_total"></span></span>
    
                            <span style="position:absolute;top:-26px;left:180px;font-weight: bold;color: #0E2D5F;">待命队伍<span class="HW_DMD"></span></span>
                            <ul id="HWHT">
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                    <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">勘探井</li>    
                                     <li  id="KTJ_HW" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d6KTJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                    <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">评价井</li>    
                                     <li   id="PJJ_HW" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d6PJJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                    <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">开发井</li>    
                                     <li   id="KFJ_HW" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d6KFJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                           </ul>
                        </div>
                        <div  class="easyui-panel " title="其他项目部" style="position:relative;width:300px;min-height:200px;border:1px solid #95B8E7;">
                               <span style="position:absolute;top:-26px;left:100px;font-weight: bold;color: #0E2D5F;">队伍总数<span class="QT_total"></span></span>
    
                            <span style="position:absolute;top:-26px;left:180px;font-weight: bold;color: #0E2D5F;">待命队伍<span class="QT_DMD"></span></span>
                            <ul id="QTHT">
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                   <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">勘探井</li>    
                                     <li   id="KTJ_QT" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d7KTJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                    <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">评价井</li>    
                                     <li   id="PJJ_QT" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d7PJJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                               <li style="height:50px;border-bottom:1px solid #95B8E7">
                                    <ul class="clear">
                                     <li  style="float:left;width:50px;height:50px;background:#e3efff;text-align:center;line-height:50px">开发井</li>    
                                     <li   id="KFJ_QT" style="float:left;width:200px;height:50px;border-left:1px solid #95B8E7;border-right:1px solid #95B8E7;overflow-y:auto">                                      
                                         
                                     </li>  
                                       <li  style="float:left;width:40px;height:50px;box-sizing:border-box;padding-top:13px;padding-left:13px"><img onclick="HTClick('d7KFJ')"  src="/Image/xia.png" alt="" style="transform:rotate(180deg)"/></li>  
                                   </ul>
                               </li>
                           </ul>
                        </div>

                   </div>
                 </div>
                 
            </div>--%>
            <%--#endregion--%>
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
                    <div id="ZD">
            		<ul>
            <li><input type="checkbox" value="ZJH"/><span>井号</span></li>
            <li><input type="checkbox"  value="SC3"/><span>甲方单位</span></li>
            <li><input type="checkbox" value="SC2"/><span>地区</span></li>
            <li><input type="checkbox" value="QK"/><span>区块</span></li>
            <li><input type="checkbox" value="REPORT_TYPE" /><span>井别</span></li>
            <li><input type="checkbox" value="JX" /><span>井型</span></li>
            <li><input type="checkbox" value="JH" /><span>井筒号</span></li>
            <li><input type="checkbox" value="SJJS" /><span>设计井深</span></li>
            <li><input type="checkbox" value="JSSJJS" /><span>加深设计井深</span></li>
            <li><input type="checkbox" value="WZJS"/><span>完钻井深</span></li>
            <li><input type="checkbox" value="DLWZ" /><span>地理位置</span></li>
            <li><input type="checkbox" value="GZWZ" /><span>构造位置</span></li>
            <li><input type="checkbox" value="CXWZ" /><span>测线位置</span></li>
            <li><input type="checkbox" value="SJZZBB" /><span>设计纵坐标(北京)</span></li>
            <li><input type="checkbox" value="SJHZBB" /><span>设计横坐标(北京)</span></li>
            <li><input type="checkbox" value="SJZZBX" /><span>设计纵坐标(西安)</span></li>
            <li><input type="checkbox" value="SJHZBX" /><span>设计横坐标(西安)</span></li>
            <li><input type="checkbox" value="SJZZB" /><span>实测纵坐标</span></li>
            <li><input type="checkbox" value="SJHZB" /><span>实测横坐标</span></li>
            <li><input type="checkbox" value="DMHB" /><span>地面海拔</span></li>
            <li><input type="checkbox" value="BXG" /><span>补心高</span></li>
            <li><input type="checkbox" value="ZYMDC" /><span>目的层</span></li>
            <li><input type="checkbox" value="SJR" /><span>设计人</span></li>
            <li><input type="checkbox" value="SPR" /><span>审批人</span></li>
            <li><input type="checkbox" value="SJRQ_DG" /><span>设计日期</span></li>
            <li><input type="checkbox" value="SPRQ_DG" /><span>审批日期</span></li>
            <li><input type="checkbox" value="BZ" /><span>备注</span></li>
            <li><input type="checkbox" value="LJFGS" /><span>录井项目部</span></li>

		</ul>
        </div>
	</div>
    <div id="dlg-buttons">
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="saveXZ()">确定</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg').dialog('close')">取消</a>
	</div>
    <!--文件查看-->
    <div id="fileWin" class="easyui-dialog" title="Basic Dialog" data-options="iconCls:'icon-save',buttons: '#fileWin-buttons' " style="width:500px;height:300px;padding:10px;overflow-y:scroll" closed="true">
            <ul id="urlname">
		    </ul>
	</div>
    <div id="fileWin-buttons">
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#fileWin').dialog('close')">关闭</a>
	</div>
     <!--下载-->
    <div id="fileWindown" class="easyui-dialog" title="Basic Dialog" data-options="iconCls:'icon-save',buttons: '#fileWindown-buttons' " style="width:500px;height:300px;padding:10px;overflow-y:scroll" closed="true">
            <ul id="urlnamedown">
		    </ul>
	</div>
    <div id="fileWindown-buttons">
		<a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#fileWindown').dialog('close')">关闭</a>
	</div>
</body>
</html>
<script type="text/javascript">
    var pageJB = '';
    $(function () {
        var pageType = getUrlParam('type');
        switch (pageType) {
            case "1":
                pageJB = '探井';
                break;
            case "2":
                pageJB = '评价井';
                break;
            case "3":
                pageJB = '开发井';
                break; 
        }
        
        ZJHChange();
        loadRemote_Home();
        SC3_enterToTab();
        ZJH_enterToTab();
        JH_enterToTab();
        SC2_enterToTab();
        JX_enterToTab();
        TYPE_enterToTab();
        QK_enterToTab();
        DLWZ_enterToTab();
        GZWZ_enterToTab();
        CXWZ_enterToTab();
        SJJS_enterToTab();
        JSSJJS_enterToTab();
        WZJS_enterToTab();
        MDC_enterToTab();
        SJHZBB_enterToTab();
        SJHZBX_enterToTab();
        SJHZB_enterToTab();
        SJZZBB_enterToTab();
        SJZZBX_enterToTab();
        SJZZB_enterToTab();
        DMHB_enterToTab();
        BXG_enterToTab();
        LJFGS_enterToTab();
        SJR_enterToTab();
        SPR_enterToTab();
        zjhValChange();
    })
    //window.onload = function () {

    //    //getDesignUp();
    //    //showTable();
    //}

    //获取url中的参数
    function getUrlParam(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
        var r = window.location.search.substr(1).match(reg);  //匹配目标参数
        if (r != null) return unescape(r[2]); return null; //返回参数值
    }
    //#region 设计查询


    //#endregion

    //#region 设计入库


    //#endregion

    //#region 设计上传

    //====井号模糊匹配
    function zjhValChange() {
        $("#zjhVal").combobox({
            valueField: 'ZJH',
            textField: 'ZJH',
            panelHeight: 'auto',
            onChange: function (values, o) {
                var url = '../../Controllers/DJSJController.ashx?action=ZJH_List&ZJH=' + values.trim();
                $("#zjhVal").combobox("reload", url);
                showTable();
            }
        })
    }


    $("#yearChoose").combobox({
        url: '../../Controllers/ColumnListController.ashx?action=YL',
        valueField: 'Y',
        textField: 'Y',
        editable: false

    });

    var thisYear = new Date().getUTCFullYear();//今年    
    $("#yearChoose").combobox("setValue", thisYear);//设置默认值为今年

    //#endregion





    ////获取二级目录树
    //$('#tt').tree({
    //    url: '../../Controllers/ColumnListController.ashx?action=EJML_List',
    //    loadFilter: function (rows) {
    //        return convert(rows);
    //    }
    //});
    //function convert(rows) {
    //    function exists(rows, parentId) {
    //        for (var i = 0; i < rows.length; i++) {
    //            if (rows[i].ID == parentId) return true;
    //        }
    //        return false;
    //    }

    //    var nodes = [];
    //    // get the top level nodes
    //    for (var i = 0; i < rows.length; i++) {
    //        var row = rows[i];
    //        if (!exists(rows, row.PID)) {
    //            nodes.push({
    //                id: row.ID,
    //                text: row.MC
    //            });
    //        }
    //    }

    //    var toDo = [];
    //    for (var i = 0; i < nodes.length; i++) {
    //        toDo.push(nodes[i]);
    //    }
    //    while (toDo.length) {
    //        var node = toDo.shift();	// the parent node
    //        // get the children nodes
    //        for (var i = 0; i < rows.length; i++) {
    //            var row = rows[i];
    //            if (row.PID == node.id) {
    //                var child = { id: row.ID, text: row.MC };
    //                if (node.children) {
    //                    node.children.push(child);
    //                } else {
    //                    node.children = [child];
    //                }
    //                toDo.push(child);
    //            }
    //        }
    //    }
    //    return nodes;
    //}

    //$('#tt').tree({
    //    onClick: function (node) {
    //        $('#treeVal').html(node.text);
    //        $('#zjhVal').empty();
    //        loadRemote_Home();
    //        //getDesignUp();
    //        if (!node.children) {
    //            $('#dg').datagrid('load', {
    //                strTree: $('#treeVal').text()
    //            });
    //        }
    //        var Pnode = $('#tt').tree('getParent', node.target);
    //        console.log(Pnode.text);
    //        console.log(node.text);
    //        data2 = Pnode.text;
    //        data3 = node.text;
    //        data4 = $("#year option:selected").val();
    //        $('#jxVal').combobox('setValue', Pnode.text);
    //        $('#typeVal').combobox('setValue', node.text);


    //    }

    //});
    

    function showPdf(ZJH, TYPE) {
        $.ajax({
            type: "POST",
            url: "../../Controllers/FilesController.ashx?action=FileInfoList",
            data: {
                'ZJH': ZJH,
                'TYPE': TYPE
            },
            dataType: 'json',
            async: false,
            success: function (data) {

                var list = data.Data;
                for (var i = 0; i < list.length; i++) {
                    //var Url = '../../PDFjs/web/viewer.html?file=' + list[i].PDFURL;
                    window.open(list[i].PDFURL);
                }

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //console.log(errorThrown);
            }
        });

    }


    //附件查看列表
    function openFileWin(ZJH, TYPE) {
        $.ajax({
            type: "POST",
            url: "../../Controllers/FilesController.ashx?action=FileInfoList",
            data: {
                'ZJH': ZJH,
                'TYPE': TYPE
            },
            dataType: 'json',
            async: false,
            success: function (data) {
                $("#fileWin").window("open");
                var list = data.Data;
                setUrl(list);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //console.log(errorThrown);
            }
        });

    }

    function setUrl(data) {
        var html = '';
        setList(data);
        function setList(data) {
            $.each(data, function (index, h) {
                html += '<li id="' + h.ID + '"><a href="javascript:void(0);" onclick="openPDF(\'' + h.PDFURL + '\')">' + h.FILENAME + '</a></li>';
            })
        }
        $('#urlname').html(html);
    }

    //附件下载列表
    function FileWindown(ZJH, TYPE) {
        $.ajax({
            type: "POST",
            url: "../../Controllers/FilesController.ashx?action=FileInfoList",
            data: {
                'ZJH': ZJH,
                'TYPE': TYPE
            },
            dataType: 'json',
            async: false,
            success: function (data) {
                $("#fileWindown").window("open");
                var list = data.Data;
                setUrldown(list);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                ////console.log(errorThrown);
            }
        });

    }
    function setUrldown(data) {
        var html = '';
        setList(data);
        function setList(data) {
            $.each(data, function (index, h) {
                html += '<li id="' + h.ID + '"><a href="' + h.FILEURL + '" download="' + h.FILENAME + '" >' + h.FILENAME + '</a></li>';
            })
        }
        $('#urlnamedown').html(html);
    }


    function openPDF(strUrl) {
        var Path = strUrl;
        window.open(Path);
    }


    //选择字段弹出框
    function Showdailog() {
        $("#dlg").dialog("open").dialog("setTitle", "选择字段");
    }
    //选择字段弹出框关闭
    function Closedialog() {
        $('#dlg').dialog('close');
    }
    //选择字段保存
    function saveXZ() {

        var arr = [];
        $("#ZD ul li").each(function () {
            if ($(this).children("input").is(':checked')) {
                arr.push($(this).find("span").html());
            }

        })
        $.ajax({
            type: "POST",
            url: "../../Controllers/ColumnListController.ashx?action=getZD",
            data: {
                "zdlist": JSON.stringify(arr)

            },
            dataType: 'json',
            async: false,
            success: function (data) {
                $("#SelectColumn_List").combobox('reload', '../../Controllers/ColumnListController.ashx?action=getZD');
                Closedialog();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //console.log(errorThrown);
            }
        });
    }
    //点击回车触发搜索事件
    $("body").keydown(function () {
        if (event.keyCode == "13") {//keyCode=13是回车键
            $('#sousuo').click();
        }
    });

    //设计上传中设置显示默认当前年份
    //function setnowYear() {
    //    var isnow = new Date();
    //    var isyear = isnow.getFullYear();
    //    $("#year option").each(function () {
    //        ////console.log($(this).text());
    //        ////console.log($(this).val());
    //        if ($(this).text() == isyear) {
    //            $(this).attr("selected", true);

    //        }
    //    })
    //}



    var data1 = '', data2 = '', data3 = '', data4;
    var table;
    //function getDesignUp() {
    //    $.ajax({
    //        type: 'POST',
    //        url: '../../Controllers/DJSJController.ashx?action=ZJH_List',
    //        dataType: "json",
    //        data: {
    //            strTree: $('#treeVal').text()
    //        },
    //        success: function (result) {

    //            if (result.length > 0) {
    //                var html = '';
    //                for (var i = 0; i < result.length; i++) {
    //                    html += '<option>' + result[i].ZJH + '</option>';
    //                }

    //                $("#zjhVal").append(html);
    //            }
    //            //$("#zjhVal").change(function () {
    //            //    var zjhVal = $(this).val();
    //            //    $.ajax({
    //            //        type: 'POST',
    //            //        url: '../../Controllers/DJSJController.ashx?action=DJSJInfoByZJH',
    //            //        data: { ZJH: zjhVal },
    //            //        dataType: "json",
    //            //        async: false,
    //            //        success: function (result) {

    //            //            $("#jxVal>span").html(result.JX);
    //            //            $("#typeVal>span").html(result.JB);
    //            //            $("#demoList").html('');
    //            //            $("#inputContent>span").html('');
    //            //            $("#inputContent1>span").html('');
    //            //            $("#inputContent2>span").html('');
    //            //            $("#inputContent3>span").html('');
    //            //            $("#inputContent4>span").html('');
    //            //            $("#inputContent5>span").html('');
    //            //            $("#inputContent6>span").html('');
    //            //            $("#inputContent7>span").html('');

    //            //            data1 = $("#zjhVal").val();
    //            //            //data2 = result.JX;
    //            //            //data2 = $("#jxVal").combobox('getValue');
    //            //            //data3 = $("#typeVal").combobox('getValue');
    //            //            //data3 = result.JB;
    //            //            //data4 = $("#year option:selected").val();

    //            //            function delHsCode(index) {
    //            //                $('#dgdg').datagrid('selectRow', index);
    //            //                var row = $('#dgdg').datagrid('getSelected');
    //            //                if (row.Id != null && row.Id !== undefined)
    //            //                    alert(row.Id);
    //            //            }
    //            //            showTable();
    //            //            layui.use('table', function () {
    //            //                table = layui.table;
    //            //                //方法级渲染
    //            //                var tableIns = table.render({
    //            //                    elem: '#LAY_table_user'
    //            //                    , url: '../../Controllers/FilesController.ashx?action=FileList&ZJH=' + data1
    //            //                    , cols: [[
    //            //                        { checkbox: true, fixed: true }
    //            //                        , { field: 'FILENAME', title: '文件名', sort: true, width: '30%' }
    //            //                        , { field: 'TYPE', title: '类型', width: '25%' }
    //            //                        , { field: 'ND', title: '年度', width: '10%' }
    //            //                        , { title: '操作', toolbar: '#barDemo', width: '20%' }
    //            //                    ]]
    //            //                    , id: 'LAY_table_user'
    //            //                    , page: true
    //            //                    , height: 315
    //            //                });

    //            //                table.on('tool(user)', function (obj) {
    //            //                    var data = obj.data;
    //            //                    if (obj.event === 'download') {
    //            //                        $(this).attr("href", data.FILEURL)
    //            //                        layer.msg('提示：' + data.FILENAME + '正在下载');
    //            //                    } else if (obj.event === 'del') {
    //            //                        layer.confirm('确认删除' + data.FILENAME + '吗？', function (index) {
    //            //                            //obj.del();
    //            //                            if (index) {
    //            //                                $.ajax({
    //            //                                    type: 'POST',
    //            //                                    url: '../../Controllers/FilesController.ashx?action=DelFileById',
    //            //                                    data: { ID: data.ID },
    //            //                                    dataType: "json",
    //            //                                    async: false,
    //            //                                    success: function (result) {

    //            //                                        table.reload('testReload', {
    //            //                                            page: {
    //            //                                                curr: 1 //重新从第 1 页开始
    //            //                                            }
    //            //                                        });
    //            //                                    }
    //            //                                })
    //            //                            }
    //            //                            layer.close(index);
    //            //                        });
    //            //                    }
    //            //                });

    //            //                $('.demoTable .layui-btn').on('click', function () {
    //            //                    var type = $(this).data('type');
    //            //                    active[type] ? active[type].call(this) : '';
    //            //                });


    //            //            });

    //            //        }
    //            //    })
    //            //})
    //        }
    //    })
    //    $.ajax({
    //        type: 'POST',
    //        url: '../../Controllers/ColumnListController.ashx?action=YL',
    //        dataType: "json",
    //        success: function (result) {
    //            if (result.length > 0) {
    //                var html = '';
    //                for (var i = 0; i < result.length; i++) {
    //                    html += '<option>' + result[i].Y + '</option>';
    //                }

    //                $("#year").append(html);
    //                setnowYear();
    //            }
    //        }
    //    })


    //    $("#year").change(function () {
    //        data4 = $(this).val();

    //    })
    //    //data2 = $("#jxVal").combobox('getValue');
    //    //data3 = $("#typeVal").combobox('getValue');
    //    //data3 = result.JB;
    //    //data4 = $("#year option:selected").val();
    //    ////console.log(data2,data3,data4)
    //}


    function showTable() {
        layui.use('table', function () {
            table = layui.table;
            //方法级渲染
            var tableIns = table.render({
                elem: '#LAY_table_user'
                , url: '../../Controllers/FilesController.ashx?action=FileList'
                , where: {
                    ZJH: function () {
                        return $("#zjhVal").val()
                    }
                }
                , cols: [[
                    { checkbox: true, fixed: true }
                    , { field: 'FILENAME', title: '文件名', sort: true, width: '30%' }
                    , { field: 'TYPE', title: '类型', width: '25%' }
                    , { field: 'REPORT_TYPE', title: '井别', width: '15%' }
                    , { field: 'ND', title: '年度', width: '10%' }
                    , { title: '操作', toolbar: '#barDemo', width: '20%' }
                ]]
                , id: 'testReload'
                , page: true
                , height: 315
            });

            table.on('tool(user)', function (obj) {
                var data = obj.data;
                if (obj.event === 'download') {
                    $(this).attr("href", data.FILEURL)
                    layer.msg('提示：' + data.FILENAME + '正在下载');
                } else if (obj.event === 'del') {
                    layer.confirm('确认删除' + data.FILENAME + '吗？', function (index) {
                        //obj.del();
                        if (index) {
                            $.ajax({
                                type: 'POST',
                                url: '../../Controllers/FilesController.ashx?action=DelFileById',
                                data: { ID: data.ID },
                                dataType: "json",
                                async: false,
                                success: function (result) {

                                    table.reload('testReload', {
                                        page: {
                                            curr: 1 //重新从第 1 页开始
                                        }
                                    });
                                }
                            })
                        }
                        layer.close(index);
                    });
                }
            });

            $('.demoTable .layui-btn').on('click', function () {
                var type = $(this).data('type');
                active[type] ? active[type].call(this) : '';
            });


        });
    }
    function ZJHChange() {
        $('#txtZJH').textbox({
            onChange: function () {
                var str = $("#txtZJH").textbox('getValue');
                $("#txtJH").textbox('setValue', str);
                $.ajax({
                    type: "POST",
                    url: "../../Controllers/DJSJController.ashx?action=DJSJInfoByZJH",
                    data: {
                        "ZJH": str
                    },
                    dataType: 'json',
                    async: false,
                    success: function (data) {
                        //console.log(data);
                        if (data.ZJH != null) {
                            $('#ff').form('load', data);
                           
                        }

                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        //console.log(errorThrown);
                    }
                });
            }
        })
    }


    function SC3_enterToTab() {
        var t = $('#List_SC3');
        t.combobox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#txtZJH').next('span').find('input').focus();
            }
        });
    }

    function ZJH_enterToTab() {
        var t = $('#txtZJH');
        t.textbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#txtJH').next('span').find('input').focus();
            }
        });
    }

    function JH_enterToTab() {
        var t = $('#txtJH');
        t.textbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#List_SC2').next('span').find('input').focus();
                $('#List_SC2').combobox('showPanel');
            }
        });
    }

    function SC2_enterToTab() {
        var t = $('#List_SC2');
        t.combobox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#List_JX').next('span').find('input').focus();
                $('#List_JX').combobox('showPanel');
            }
        });
    }

    function JX_enterToTab() {
        var t = $('#List_JX');
        t.combobox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#List_TYPE').next('span').find('input').focus();
                $('#List_TYPE').combobox('showPanel');
            }
        });
    }

    function TYPE_enterToTab() {
        var t = $('#List_TYPE');
        t.combobox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#List_QK').next('span').find('input').focus();
                $('#List_QK').combobox('showPanel');
            }
        });
    }

    function QK_enterToTab() {
        var t = $('#List_QK');
        t.combobox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#txtDLWZ').next('span').find('input').focus();
            }
        });
    }

    function DLWZ_enterToTab() {
        var t = $('#txtDLWZ');
        t.textbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#txtGZWZ').next('span').find('input').focus();
            }
        });
    }

    function GZWZ_enterToTab() {
        var t = $('#txtGZWZ');
        t.textbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#txtCXWZ').next('span').find('input').focus();
            }
        });
    }

    function CXWZ_enterToTab() {
        var t = $('#txtCXWZ');
        t.textbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#numSJJS').next('span').find('input').focus();
            }
        });
    }

    function SJJS_enterToTab() {
        var t = $('#numSJJS');
        t.numberbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#numJSSJJS').next('span').find('input').focus();
            }
        });
    }

    function JSSJJS_enterToTab() {
        var t = $('#numJSSJJS');
        t.numberbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#numWZJS').next('span').find('input').focus();
            }
        });
    }

    function WZJS_enterToTab() {
        var t = $('#numWZJS');
        t.numberbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#txtMDC').next('span').find('input').focus();
            }
        });
    }

    function MDC_enterToTab() {
        var t = $('#txtMDC');
        t.numberbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#numSJHZBB').next('span').find('input').focus();
            }
        });
    }

    function SJHZBB_enterToTab() {
        var t = $('#numSJHZBB');
        t.numberbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#numSJZZBB').next('span').find('input').focus();
            }
        });
    }

    function SJHZBX_enterToTab() {
        var t = $('#numSJHZBX');
        t.numberbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#numSJZZBX').next('span').find('input').focus();
            }
        });
    }

    function SJHZB_enterToTab() {
        var t = $('#numSJHZB');
        t.numberbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#numSJZZB').next('span').find('input').focus();
            }
        });
    }

    function SJZZBB_enterToTab() {
        var t = $('#numSJZZBB');
        t.numberbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#numSJHZBX').next('span').find('input').focus();
            }
        });
    }

    function SJZZBX_enterToTab() {
        var t = $('#numSJZZBX');
        t.numberbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#numSJHZB').next('span').find('input').focus();
            }
        });
    }

    function SJZZB_enterToTab() {
        var t = $('#numSJZZB');
        t.numberbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#numDMHB').next('span').find('input').focus();
            }
        });
    }

    function DMHB_enterToTab() {
        var t = $('#numDMHB');
        t.numberbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#txtSJR').next('span').find('input').focus();
            }
        });
    }

    function BXG_enterToTab() {
        var t = $('#numBXG');
        t.numberbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#txtSPR').next('span').find('input').focus();
            }
        });
    }

    function LJFGS_enterToTab() {
        var t = $('#List_LJFGS');
        t.combobox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                event.returnValue = false;
                $('#txtBZ').next('span').find('textarea').focus();
            }
        });
    }

    function SJR_enterToTab() {
        var t = $('#txtSJR');
        t.textbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {
                $('#numBXG').next('span').find('input').focus();
            }
        });
    }

    function SPR_enterToTab() {
        var t = $('#txtSPR');
        t.textbox('textbox').bind('keydown', function (e) {
            if (e.keyCode == 13) {

                $('#List_LJFGS').next('span').find('input').focus();
                $('#List_LJFGS').combobox('showPanel');
            }
        });
    }

    function yearFormatter(date) {
        var y = date.getFullYear();
        var m = date.getMonth() + 1;
        var d = date.getDate();
        return y;
    };

    function yearParser(s) {
        if (!s) return new Date();
        var y = s;
        var date;
        if (!isNaN(y)) {
            return new Date(y, 0, 1);
        } else {
            return new Date();
        }
    };
    //-----------------日期控件显示格式------------------
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
    //----------------------------------------------------

    formatterDate = function (date) {

        var day = date.getDate() > 9 ? date.getDate() : "0" + date.getDate();

        var month = (date.getMonth() + 1) > 9 ? (date.getMonth() + 1) : "0"

            + (date.getMonth() + 1);

        return date.getFullYear() + '-' + month + '-' + day;

    };

    ////模板下载
    //function WordDownLoad() {


    //}



    function openWin() {
        //$("#fatherId").val() = "";
        $("#fatherId").textbox('setValue', '')
        $("#win").window("open");
    }


    //文本框中的值转换    
    function assgVal() {
        var content = $("#fatherId").val();
        $.ajax({
            type: "POST",
            url: "../../Controllers/DJSJController.ashx?action=DJSJ_Import",
            data: {
                "Content": content
            },
            dataType: 'json',
            async: false,
            success: function (data) {
                $('#ff').form('load', data);
                closeWin();
                //$('#SJRQTime').datebox('setValue', formatterDate(new Date()));//默认为当前日期
                //$('#SPRQTime').datebox('setValue', formatterDate(new Date()));
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //console.log(errorThrown);
            }
        });
    }

    //关闭window窗口    
    function closeWin() {
        $("#win").window("close");
    }
    //----------------------------------------------------

    function openDelWin() {
        //$("#fatherId").val() = "";
        $("#DelWin").window("open");
    }
    function closeDelWin() {
        $("#DelWin").window("close");
    }

</script>

<script>
    var type = ($('#inputContent').parent().prev().html()),
        type1 = ($('#inputContent1').parent().prev().html()),
        type2 = ($('#inputContent2').parent().prev().html()),
        type3 = ($('#inputContent3').parent().prev().html()),
        type4 = ($('#inputContent4').parent().prev().html()),
        type5 = ($('#inputContent5').parent().prev().html()),
        type6 = ($('#inputContent6').parent().prev().html()),
        type7 = ($('#inputContent7').parent().prev().html());
    layui.use(['upload', 'element'], function () {
        var $ = layui.jquery
            , upload = layui.upload;
        var element = layui.element;
        var demoListView = $('#demoList')
            , inputContent = $('#inputContent>span')
            , inputContent1 = $('#inputContent1>span')
            , inputContent2 = $('#inputContent2>span')
            , inputContent3 = $('#inputContent3>span')
            , inputContent4 = $('#inputContent4>span')
            , inputContent5 = $('#inputContent5>span')
            , inputContent6 = $('#inputContent6>span')
            , inputContent7 = $('#inputContent7>span');
        var uploadListIns = upload.render({
            elem: '#testList'
            , url: '../../Controllers/FilesController.ashx?action=FileUpload'
            , data: {
                ZJH: function () {
                    return $("#zjhVal").val()
                },
                REPORT_TYPE: function () {
                    return $("#typeVal").val()
                },
                ND: function () {
                    return $("#yearChoose").val()
                },
                TYPE: function () {
                    return type
                }
            }
            , accept: 'file'
            , drag: true
            , multiple: true
            , auto: false
            , bindAction: '#testListAction'
            , choose: function (obj) {
                var files = this.files = obj.pushFile(); //将每次选择的文件追加到文件队列
                //读取本地文件
                obj.preview(function (index, file, result) {
                    //console.log(index, file, result)
                    //var v = '';
                    //v += file[index].name;
                    var belong = $('#inputContent').parent().prev().html();
                    var tr = $(['<tr id="upload-' + index + '">'
                        , '<td>' + index + '</td>'
                        , '<td>' + belong + '</td>'
                        , '<td>' + file.name + '</td>'
                        , '<td>' + (file.size / 1014).toFixed(1) + 'kb</td>'
                        , '<td><div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar" lay-percent="0%"><span class="layui-progress-text"></span></div></div></td>'
                        , '<td>'
                        , '<button class="layui-btn btnGetType layui-btn-danger demo-delete" style="line-height: 26px;width:45%;">删除</button>'
                        , '</td>'
                        , '</tr>'].join(''));

                    //单个重传
                    //tr.find('.demo-reload').on('click', function () {
                    //    obj.upload(index, file);
                    //});

                    //删除
                    tr.find('.demo-delete').on('click', function () {
                        delete files[index]; //删除对应的文件
                        tr.remove();
                        uploadListIns.config.elem.next()[0].value = ''; //清空 input file 值，以免删除后出现同名文件不可选
                        inputContent.html('');
                    });

                    demoListView.append(tr);
                    inputContent.html(file.name);
                });
            }
            , before: function (obj) {
                if (inputContent.html() != '') {
                    obj.preview(function (index, file, result) {
                        element.progress('demo' + index, '90%');
                    })
                }
            }
            , done: function (res, index, upload) {
                //console.log(data2, data3, data4)
                inputContent.html('');
                var tr = demoListView.find('tr#upload-' + index)
                    , tds = tr.children();
                if ($("#zjhVal").val() == '') {
                    $.messager.alert('提示', '请先选择井号！!', 'info');
                    return;
                }
                if (res.IsSuccess == 'true') { //上传成功
                    element.progress('demo' + index, '100%');
                    tds.eq(5).html('<span style="color:green;">上传成功！</span>');
                    data1 = $("#zjhVal").val()
                    showTable();
                    //table.reload('testReload', {
                    //    page: {
                    //        curr: 1 //重新从第 1 页开始
                    //    }
                    //});
                    return delete this.files[index]; //删除文件队列已经上传成功的文件
                } else {
                    tds.eq(4).html('<div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar layui-bg-red" lay-percent="99%"><span class="layui-progress-text"></span></div></div>')
                    tds.eq(5).html('<span style="color: red;">上传失败</span>');
                }
                this.error(index, upload);
            }
            , error: function (index, upload) {
                var tr = demoListView.find('tr#upload-' + index)
                    , tds = tr.children();
                tds.eq(4).html('<div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar layui-bg-red" lay-percent="99%"><span class="layui-progress-text"></span></div></div>')
                tds.eq(5).html('<span style="color: red;">上传失败</span>');
                //tds.eq(5).find('.demo-reload').removeClass('layui-hide'); //显示重传
            }
        });
        //console.log($("#zjhVal").combobox('getValue'));
        var uploadListIns1 = upload.render({

            elem: '#testList1'
            , url: '../../Controllers/FilesController.ashx?action=FileUpload'
            , data: {
                ZJH: function () {
                    return $("#zjhVal").val()
                },
                REPORT_TYPE: function () {
                    return $("#typeVal").val()
                },
                ND: function () {
                    return $("#yearChoose").val()
                },
                TYPE: function () {
                    return type1
                }
            }
            , accept: 'file'
            , drag: true
            , multiple: true
            , auto: false
            , bindAction: '#testListAction1'
            , choose: function (obj) {
                var files = this.files = obj.pushFile(); //将每次选择的文件追加到文件队列
                //读取本地文件
                obj.preview(function (index, file, result) {
                    //console.log(index, file, result)
                    var belong1 = $('#inputContent1').parent().prev().html();
                    var tr = $(['<tr id="upload-' + index + '">'
                        , '<td>' + index + '</td>'
                        , '<td>' + belong1 + '</td>'
                        , '<td>' + file.name + '</td>'
                        , '<td>' + (file.size / 1014).toFixed(1) + 'kb</td>'
                        , '<td><div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar" lay-percent="0%"><span class="layui-progress-text"></span></div></div></td>'
                        , '<td>'
                        , '<button class="layui-btn btnGetType layui-btn-danger demo-delete" style="line-height: 26px;width:45%;">删除</button>'
                        , '</td>'
                        , '</tr>'].join(''));

                    //单个重传
                    tr.find('.demo-reload').on('click', function () {
                        obj.upload(index, file);
                    });

                    //删除
                    tr.find('.demo-delete').on('click', function () {
                        delete files[index]; //删除对应的文件
                        tr.remove();
                        uploadListIns.config.elem.next()[0].value = ''; //清空 input file 值，以免删除后出现同名文件不可选
                        inputContent1.html('');
                    });

                    demoListView.append(tr);
                    inputContent1.html(file.name);
                });
            }
            , before: function (obj) {
                if (inputContent1.html() != '') {
                    obj.preview(function (index, file, result) {
                        element.progress('demo' + index, '90%');
                    })
                }
            }
            , done: function (res, index, upload) {
                inputContent1.html('');
                var tr = demoListView.find('tr#upload-' + index)
                    , tds = tr.children();
                if ($("#zjhVal").val() == '') {
                    $.messager.alert('提示', '请先选择井号！!', 'info');
                    return;
                }
                if (res.IsSuccess == 'true') { //上传成功
                    element.progress('demo' + index, '100%');
                    tds.eq(5).html('<span style="color:green;">上传成功！</span>');
                    table.reload('testReload', {
                        page: {
                            curr: 1 //重新从第 1 页开始
                        }
                    });
                    return delete this.files[index]; //删除文件队列已经上传成功的文件
                } else {
                    tds.eq(4).html('<div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar layui-bg-red" lay-percent="99%"><span class="layui-progress-text"></span></div></div>')
                    tds.eq(5).html('<span style="color: red;">上传失败</span>');
                }
                this.error(index, upload);
            }
            , error: function (index, upload) {
                var tr = demoListView.find('tr#upload-' + index)
                    , tds = tr.children();
                tds.eq(4).html('<div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar layui-bg-red" lay-percent="99%"><span class="layui-progress-text"></span></div></div>')
                tds.eq(5).html('<span style="color: red;">上传失败</span>');
                //tds.eq(5).find('.demo-reload').removeClass('layui-hide'); //显示重传
            }
        });
        var uploadListIns2 = upload.render({
            elem: '#testList2'
            , url: '../../Controllers/FilesController.ashx?action=FileUpload'
            , data: {
                ZJH: function () {
                    return $("#zjhVal").val()
                },
                REPORT_TYPE: function () {
                    return $("#typeVal").val()
                },
                ND: function () {
                    return $("#yearChoose").val()
                },
                TYPE: function () {
                    return type2
                }
            }
            , accept: 'file'
            , drag: true
            , multiple: true
            , auto: false
            , bindAction: '#testListAction2'
            , choose: function (obj) {
                var files = this.files = obj.pushFile(); //将每次选择的文件追加到文件队列
                //读取本地文件
                obj.preview(function (index, file, result) {
                    var belong2 = $('#inputContent2').parent().prev().html();
                    var tr = $(['<tr id="upload-' + index + '">'
                        , '<td>' + index + '</td>'
                        , '<td>' + belong2 + '</td>'
                        , '<td>' + file.name + '</td>'
                        , '<td>' + (file.size / 1014).toFixed(1) + 'kb</td>'
                        , '<td><div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar" lay-percent="0%"><span class="layui-progress-text"></span></div></div></td>'
                        , '<td>'
                        , '<button class="layui-btn btnGetType layui-btn-danger demo-delete" style="line-height: 26px;width:45%;">删除</button>'
                        , '</td>'
                        , '</tr>'].join(''));

                    //单个重传
                    tr.find('.demo-reload').on('click', function () {
                        obj.upload(index, file);
                    });

                    //删除
                    tr.find('.demo-delete').on('click', function () {
                        delete files[index]; //删除对应的文件
                        tr.remove();
                        uploadListIns.config.elem.next()[0].value = ''; //清空 input file 值，以免删除后出现同名文件不可选
                        inputContent2.html('');
                    });

                    demoListView.append(tr);
                    inputContent2.html(file.name);
                });
            }
            , before: function (obj) {
                if (inputContent2.html() != '') {
                    obj.preview(function (index, file, result) {
                        element.progress('demo' + index, '90%');
                    })
                }
            }
            , done: function (res, index, upload) {
                inputContent2.html('');
                var tr = demoListView.find('tr#upload-' + index)
                    , tds = tr.children();
                if ($("#zjhVal").val() == '') {
                    $.messager.alert('提示', '请先选择井号！!', 'info');
                    return;
                }
                if (res.IsSuccess == 'true') { //上传成功
                    element.progress('demo' + index, '100%');
                    tds.eq(5).html('<span style="color:green;">上传成功！</span>');
                    table.reload('testReload', {
                        page: {
                            curr: 1 //重新从第 1 页开始
                        }
                    });
                    return delete this.files[index]; //删除文件队列已经上传成功的文件
                } else {
                    tds.eq(4).html('<div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar layui-bg-red" lay-percent="99%"><span class="layui-progress-text"></span></div></div>')
                    tds.eq(5).html('<span style="color: red;">上传失败</span>');
                }
                this.error(index, upload);
            }
            , error: function (index, upload) {
                var tr = demoListView.find('tr#upload-' + index)
                    , tds = tr.children();
                tds.eq(4).html('<div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar layui-bg-red" lay-percent="99%"><span class="layui-progress-text"></span></div></div>')
                tds.eq(5).html('<span style="color: red;">上传失败</span>');
                //tds.eq(5).find('.demo-reload').removeClass('layui-hide'); //显示重传
            }
        });
        var uploadListIns3 = upload.render({
            elem: '#testList3'
            , url: '../../Controllers/FilesController.ashx?action=FileUpload'
            , data: {
                ZJH: function () {
                    return $("#zjhVal").val()
                },
                REPORT_TYPE: function () {
                    return $("#typeVal").val()
                },
                ND: function () {
                    return $("#yearChoose").val()
                },
                TYPE: $('#inputContent3').parent().prev().html()
            }
            , accept: 'file'
            , drag: true
            , multiple: true
            , auto: false
            , bindAction: '#testListAction3'
            , choose: function (obj) {
                var files = this.files = obj.pushFile(); //将每次选择的文件追加到文件队列
                //读取本地文件
                obj.preview(function (index, file, result) {
                    var belong3 = $('#inputContent3').parent().prev().html();
                    var tr = $(['<tr id="upload-' + index + '">'
                        , '<td>' + index + '</td>'
                        , '<td>' + belong3 + '</td>'
                        , '<td>' + file.name + '</td>'
                        , '<td>' + (file.size / 1014).toFixed(1) + 'kb</td>'
                        , '<td><div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar" lay-percent="0%"><span class="layui-progress-text"></span></div></div></td>'
                        , '<td>'
                        , '<button class="layui-btn btnGetType layui-btn-danger demo-delete" style="line-height: 26px;width:45%;">删除</button>'
                        , '</td>'
                        , '</tr>'].join(''));

                    //单个重传
                    tr.find('.demo-reload').on('click', function () {
                        obj.upload(index, file);
                    });

                    //删除
                    tr.find('.demo-delete').on('click', function () {
                        delete files[index]; //删除对应的文件
                        tr.remove();
                        uploadListIns.config.elem.next()[0].value = ''; //清空 input file 值，以免删除后出现同名文件不可选
                        inputContent3.html('');
                    });

                    demoListView.append(tr);
                    inputContent3.html(file.name);
                });
            }
            , before: function (obj) {
                if (inputContent3.html() != '') {
                    obj.preview(function (index, file, result) {
                        element.progress('demo' + index, '90%');
                    })
                }
            }
            , done: function (res, index, upload) {
                inputContent3.html('');
                var tr = demoListView.find('tr#upload-' + index)
                    , tds = tr.children();
                if ($("#zjhVal").val() == '') {
                    $.messager.alert('提示', '请先选择井号！!', 'info');
                    return;
                }
                if (res.IsSuccess == 'true') { //上传成功
                    element.progress('demo' + index, '100%');
                    tds.eq(5).html('<span style="color:green;">上传成功！</span>');
                    table.reload('testReload', {
                        page: {
                            curr: 1 //重新从第 1 页开始
                        }
                    });
                    return delete this.files[index]; //删除文件队列已经上传成功的文件
                } else {
                    tds.eq(4).html('<div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar layui-bg-red" lay-percent="99%"><span class="layui-progress-text"></span></div></div>')
                    tds.eq(5).html('<span style="color: red;">上传失败</span>');
                }
                this.error(index, upload);
            }
            , error: function (index, upload) {
                var tr = demoListView.find('tr#upload-' + index)
                    , tds = tr.children();
                tds.eq(4).html('<div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar layui-bg-red" lay-percent="99%"><span class="layui-progress-text"></span></div></div>')
                tds.eq(5).html('<span style="color: red;">上传失败</span>');
                //tds.eq(5).find('.demo-reload').removeClass('layui-hide'); //显示重传
            }
        });
        var uploadListIns4 = upload.render({
            elem: '#testList4'
            , url: '../../Controllers/FilesController.ashx?action=FileUpload'
            , data: {
                ZJH: function () {
                    return $("#zjhVal").val()
                },
                REPORT_TYPE: function () {
                    return $("#typeVal").val()
                },
                ND: function () {
                    return $("#yearChoose").val()
                },
                TYPE: $('#inputContent4').parent().prev().html()
            }
            , accept: 'file'
            , drag: true
            , multiple: true
            , auto: false
            , bindAction: '#testListAction4'
            , choose: function (obj) {
                var files = this.files = obj.pushFile(); //将每次选择的文件追加到文件队列
                //读取本地文件
                obj.preview(function (index, file, result) {
                    var belong4 = $('#inputContent4').parent().prev().html();
                    var tr = $(['<tr id="upload-' + index + '">'
                        , '<td>' + index + '</td>'
                        , '<td>' + belong4 + '</td>'
                        , '<td>' + file.name + '</td>'
                        , '<td>' + (file.size / 1014).toFixed(1) + 'kb</td>'
                        , '<td><div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar" lay-percent="0%"><span class="layui-progress-text"></span></div></div></td>'
                        , '<td>'
                        , '<button class="layui-btn btnGetType layui-btn-danger demo-delete" style="line-height: 26px;width:45%;">删除</button>'
                        , '</td>'
                        , '</tr>'].join(''));

                    //单个重传
                    tr.find('.demo-reload').on('click', function () {
                        obj.upload(index, file);
                    });

                    //删除
                    tr.find('.demo-delete').on('click', function () {
                        delete files[index]; //删除对应的文件
                        tr.remove();
                        uploadListIns.config.elem.next()[0].value = ''; //清空 input file 值，以免删除后出现同名文件不可选
                        inputContent4.html('');
                    });

                    demoListView.append(tr);
                    inputContent4.html(file.name);
                });
            }
            , before: function (obj) {
                if (inputContent4.html() != '') {
                    obj.preview(function (index, file, result) {
                        element.progress('demo' + index, '90%');
                    })
                }
            }
            , done: function (res, index, upload) {
                inputContent4.html('');
                var tr = demoListView.find('tr#upload-' + index)
                    , tds = tr.children();
                if ($("#zjhVal").val() == '') {
                    $.messager.alert('提示', '请先选择井号！!', 'info');
                    return;
                }
                if (res.IsSuccess == 'true') { //上传成功
                    element.progress('demo' + index, '100%');
                    tds.eq(5).html('<span style="color:green;">上传成功！</span>');
                    table.reload('testReload', {
                        page: {
                            curr: 1 //重新从第 1 页开始
                        }
                    });
                    return delete this.files[index]; //删除文件队列已经上传成功的文件
                } else {
                    tds.eq(4).html('<div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar layui-bg-red" lay-percent="99%"><span class="layui-progress-text"></span></div></div>')
                    tds.eq(5).html('<span style="color: red;">上传失败</span>');
                }
                this.error(index, upload);
            }
            , error: function (index, upload) {
                var tr = demoListView.find('tr#upload-' + index)
                    , tds = tr.children();
                tds.eq(4).html('<div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar layui-bg-red" lay-percent="99%"><span class="layui-progress-text"></span></div></div>')
                tds.eq(5).html('<span style="color: red;">上传失败</span>');
                //tds.eq(5).find('.demo-reload').removeClass('layui-hide'); //显示重传
            }
        });
        var uploadListIns5 = upload.render({
            elem: '#testList5'
            , url: '../../Controllers/FilesController.ashx?action=FileUpload'
            , data: {
                ZJH: function () {
                    return $("#zjhVal").val()
                },
                REPORT_TYPE: function () {
                    return $("#typeVal").val()
                },
                ND: function () {
                    return $("#yearChoose").val()
                },
                TYPE: $('#inputContent5').parent().prev().html()
            }
            , accept: 'file'
            , drag: true
            , multiple: true
            , auto: false
            , bindAction: '#testListAction5'
            , choose: function (obj) {
                var files = this.files = obj.pushFile(); //将每次选择的文件追加到文件队列
                //读取本地文件
                obj.preview(function (index, file, result) {
                    var belong5 = $('#inputContent5').parent().prev().html();
                    var tr = $(['<tr id="upload-' + index + '">'
                        , '<td>' + index + '</td>'
                        , '<td>' + belong5 + '</td>'
                        , '<td>' + file.name + '</td>'
                        , '<td>' + (file.size / 1014).toFixed(1) + 'kb</td>'
                        , '<td><div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar" lay-percent="0%"><span class="layui-progress-text"></span></div></div></td>'
                        , '<td>'
                        , '<button class="layui-btn btnGetType layui-btn-danger demo-delete" style="line-height: 26px;width:45%;">删除</button>'
                        , '</td>'
                        , '</tr>'].join(''));

                    //单个重传
                    tr.find('.demo-reload').on('click', function () {
                        obj.upload(index, file);
                    });

                    //删除
                    tr.find('.demo-delete').on('click', function () {
                        delete files[index]; //删除对应的文件
                        tr.remove();
                        uploadListIns.config.elem.next()[0].value = ''; //清空 input file 值，以免删除后出现同名文件不可选
                        inputContent5.html('');
                    });

                    demoListView.append(tr);
                    inputContent5.html(file.name);
                });
            }
            , before: function (obj) {
                if (inputContent5.html() != '') {
                    obj.preview(function (index, file, result) {
                        element.progress('demo' + index, '90%');
                    })
                }
            }
            , done: function (res, index, upload) {
                inputContent5.html('');
                var tr = demoListView.find('tr#upload-' + index)
                    , tds = tr.children();
                if ($("#zjhVal").val() == '') {
                    $.messager.alert('提示', '请先选择井号！!', 'info');
                    return;
                }
                if (res.IsSuccess == 'true') { //上传成功
                    element.progress('demo' + index, '100%');
                    tds.eq(5).html('<span style="color:green;">上传成功！</span>');
                    table.reload('testReload', {
                        page: {
                            curr: 1 //重新从第 1 页开始
                        }
                    });
                    return delete this.files[index]; //删除文件队列已经上传成功的文件
                } else {
                    tds.eq(4).html('<div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar layui-bg-red" lay-percent="99%"><span class="layui-progress-text"></span></div></div>')
                    tds.eq(5).html('<span style="color: red;">上传失败</span>');
                }
                this.error(index, upload);
            }
            , error: function (index, upload) {
                var tr = demoListView.find('tr#upload-' + index)
                    , tds = tr.children();
                tds.eq(4).html('<div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar layui-bg-red" lay-percent="99%"><span class="layui-progress-text"></span></div></div>')
                tds.eq(5).html('<span style="color: red;">上传失败</span>');
                //tds.eq(5).find('.demo-reload').removeClass('layui-hide'); //显示重传
            }
        });
        var uploadListIns6 = upload.render({
            elem: '#testList6'
            , url: '../../Controllers/FilesController.ashx?action=FileUpload'
            , data: {
                ZJH: function () {
                    return $("#zjhVal").val()
                },
                REPORT_TYPE: function () {
                    return $("#typeVal").val()
                },
                ND: function () {
                    return $("#yearChoose").val()
                },
                TYPE: $('#inputContent6').parent().prev().html()
            }
            , accept: 'file'
            , drag: true
            , multiple: true
            , auto: false
            , bindAction: '#testListAction6'
            , choose: function (obj) {
                var files = this.files = obj.pushFile(); //将每次选择的文件追加到文件队列
                //读取本地文件
                obj.preview(function (index, file, result) {
                    var belong6 = $('#inputContent6').parent().prev().html();
                    var tr = $(['<tr id="upload-' + index + '">'
                        , '<td>' + index + '</td>'
                        , '<td>' + belong6 + '</td>'
                        , '<td>' + file.name + '</td>'
                        , '<td>' + (file.size / 1014).toFixed(1) + 'kb</td>'
                        , '<td><div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar" lay-percent="0%"><span class="layui-progress-text"></span></div></div></td>'
                        , '<td>'
                        , '<button class="layui-btn btnGetType layui-btn-danger demo-delete" style="line-height: 26px;width:45%;">删除</button>'
                        , '</td>'
                        , '</tr>'].join(''));

                    //单个重传
                    tr.find('.demo-reload').on('click', function () {
                        obj.upload(index, file);
                    });

                    //删除
                    tr.find('.demo-delete').on('click', function () {
                        delete files[index]; //删除对应的文件
                        tr.remove();
                        uploadListIns.config.elem.next()[0].value = ''; //清空 input file 值，以免删除后出现同名文件不可选
                        inputContent6.html('');
                    });

                    demoListView.append(tr);
                    inputContent6.html(file.name);
                });
            }
            , before: function (obj) {
                if (inputContent6.html() != '') {
                    obj.preview(function (index, file, result) {
                        element.progress('demo' + index, '90%');
                    })
                }
            }
            , done: function (res, index, upload) {
                inputContent6.html('');
                var tr = demoListView.find('tr#upload-' + index)
                    , tds = tr.children();
                if ($("#zjhVal").val() == '') {
                    $.messager.alert('提示', '请先选择井号！!', 'info');
                    return;
                }
                if (res.IsSuccess == 'true') { //上传成功
                    element.progress('demo' + index, '100%');
                    tds.eq(5).html('<span style="color:green;">上传成功！</span>');
                    table.reload('testReload', {
                        page: {
                            curr: 1 //重新从第 1 页开始
                        }
                    });
                    return delete this.files[index]; //删除文件队列已经上传成功的文件
                } else {
                    tds.eq(4).html('<div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar layui-bg-red" lay-percent="99%"><span class="layui-progress-text"></span></div></div>')
                    tds.eq(5).html('<span style="color: red;">上传失败</span>');
                }
                this.error(index, upload);
            }
            , error: function (index, upload) {
                var tr = demoListView.find('tr#upload-' + index)
                    , tds = tr.children();
                tds.eq(4).html('<div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar layui-bg-red" lay-percent="99%"><span class="layui-progress-text"></span></div></div>')
                tds.eq(5).html('<span style="color: red;">上传失败</span>');
                //tds.eq(5).find('.demo-reload').removeClass('layui-hide'); //显示重传
            }
        });
        var uploadListIns7 = upload.render({
            elem: '#testList7'
            , url: '../../Controllers/FilesController.ashx?action=FileUpload'
            , data: {
                ZJH: function () {
                    return $("#zjhVal").val()
                },
                REPORT_TYPE: function () {
                    return $("#typeVal").val()
                },
                ND: function () {
                    return $("#yearChoose").val()
                },
                TYPE: $('#inputContent7').parent().prev().html()
            }
            , accept: 'file'
            , drag: true
            , multiple: true
            , auto: false
            , bindAction: '#testListAction7'
            , choose: function (obj) {
                var files = this.files = obj.pushFile(); //将每次选择的文件追加到文件队列
                //读取本地文件
                obj.preview(function (index, file, result) {
                    var belong7 = $('#inputContent7').parent().prev().html();
                    var tr = $(['<tr id="upload-' + index + '">'
                        , '<td>' + index + '</td>'
                        , '<td>' + belong7 + '</td>'
                        , '<td>' + file.name + '</td>'
                        , '<td>' + (file.size / 1014).toFixed(1) + 'kb</td>'
                        , '<td><div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar" lay-percent="0%"><span class="layui-progress-text"></span></div></div></td>'
                        , '<td>'
                        , '<button class="layui-btn btnGetType layui-btn-danger demo-delete" style="line-height: 26px;width:45%;">删除</button>'
                        , '</td>'
                        , '</tr>'].join(''));

                    //单个重传
                    tr.find('.demo-reload').on('click', function () {
                        obj.upload(index, file);
                    });

                    //删除
                    tr.find('.demo-delete').on('click', function () {
                        delete files[index]; //删除对应的文件
                        tr.remove();
                        uploadListIns.config.elem.next()[0].value = ''; //清空 input file 值，以免删除后出现同名文件不可选
                        inputContent7.html('');
                    });

                    demoListView.append(tr);
                    inputContent7.html(file.name);
                });
            }
            , before: function (obj) {
                if (inputContent7.html() != '') {
                    obj.preview(function (index, file, result) {
                        element.progress('demo' + index, '90%');
                    })
                }
            }
            , done: function (res, index, upload) {
                inputContent7.html('');
                var tr = demoListView.find('tr#upload-' + index)
                    , tds = tr.children();
                if ($("#zjhVal").val() == '') {
                    $.messager.alert('提示', '请先选择井号！!', 'info');
                    return;
                }
                if (res.IsSuccess == 'true') { //上传成功
                    element.progress('demo' + index, '100%');
                    tds.eq(5).html('<span style="color:green;">上传成功！</span>');
                    table.reload('testReload', {
                        page: {
                            curr: 1 //重新从第 1 页开始
                        }
                    });
                    return delete this.files[index]; //删除文件队列已经上传成功的文件
                } else {
                    tds.eq(4).html('<div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar layui-bg-red" lay-percent="99%"><span class="layui-progress-text"></span></div></div>')
                    tds.eq(5).html('<span style="color: red;">上传失败</span>');
                }
                this.error(index, upload);
            }
            , error: function (index, upload) {
                var tr = demoListView.find('tr#upload-' + index)
                    , tds = tr.children();
                tds.eq(4).html('<div class="layui-progress layui-progress-big" lay-filter="demo' + index + '" lay-showPercent="yes"><div class="layui-progress-bar layui-bg-red" lay-percent="99%"><span class="layui-progress-text"></span></div></div>')
                tds.eq(5).html('<span style="color: red;">上传失败</span>');
                //tds.eq(5).find('.demo-reload').removeClass('layui-hide'); //显示重传
            }
        });
    })

</script>

