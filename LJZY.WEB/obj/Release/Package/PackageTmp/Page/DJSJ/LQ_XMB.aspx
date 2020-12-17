<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LQ_XMB.aspx.cs" Inherits="LJZY.WEB.Page.DJSJ.LQ_XMB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["theme"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["icon"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["demo"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/layui/css/layui.css" rel="stylesheet" />
    <link href="../../CSS/LQ_XMB.css" rel="stylesheet" />
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["jquery"].ToString()%>" type="text/javascript"></script>
    <script src="../../Scripts/layui/layui.js"></script>
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-min"].ToString()%>" type="text/javascript"></script>
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-zh_CN"].ToString()%>" type="text/javascript"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=IDvNBsejl9oqMbPF316iKsXR"></script>
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
    <script src="../../Scripts/LQZY/LQ_XMB.js"></script>
    <style>
        .anchorBL, .BMap_cpyCtrl, .BMap_scaleCtrl {
            display: none;
        }

        .panel-header {
            z-index: 9;
        }
       .table-box-title .textbox .textbox-text{
            height:21px;
            line-height:21px;
        }
       .filename{
           overflow: hidden;
        display: inline-block;
        margin-right: 5px;
        max-width: 235px;
        text-overflow: ellipsis;
        white-space: nowrap;
        vertical-align: middle;
       }
    </style>
</head>
<body class="easyui-layout">
    <div id="loading" style="position: absolute; z-index: 1000; top: 0px; left: 0px; width: 100%; height: 100%; background: #ffffff; text-align: center; padding-top: 20%;">
        <h3><font color="#242b5f">加载中....</font></h3>
    </div>
    <div data-options="region:'center',iconCls:'icon-ok',border:false">
        <div class="easyui-tabs" data-options="fit:true,plain:true">
            <div title="项目部" style="overflow-x: auto; overflow-y: auto;">
                <div id="SCPG_content" style="width: 2050px; min-height: 800px; margin: auto; position: relative; padding: 10px;">
                    <!--左侧-->
                    <div style="display: inline-block; vertical-align: top">
                        <ul class="lf-t-box">
                            <li style="display: none;">
                                <table class="easyui-datagrid" title="无效datagrid" style="width: 230px; height: 310px"></table>
                            </li>
                            <li>
                                <%--<div class="easyui-panel " title="勘探" style="width: 230px; height: 310px; padding: 5px;">--%>
                                <%--<div class="panelbody-box">--%>
                                <%--<p>皋27</p>--%>
                                <table class="easyui-datagrid" title="勘探" style="width: 230px; height: 310px" id="kt"></table>
                                <%-- </div>--%>
                                <%--</div>--%>
                            </li>
                            <li style="display: none;">
                                <table class="easyui-datagrid" title="无效datagrid" style="width: 230px; height: 310px" id="es"></table>
                            </li>
                            <li>
                                <%-- <div class="easyui-panel " title="油藏评价" style="width: 230px; height: 310px; padding: 5px;">
                                    <div class="panelbody-box">
                                        <p>玛湖403</p>
                                    </div>
                                </div>--%>

                                <table class="easyui-datagrid" title="油藏评价" style="width: 230px; height: 310px" id="pj"></table>
                            </li>
                            <li>
                                <%-- <div class="easyui-panel " title="开发" style="width: 230px; height: 310px; padding: 5px;">
                                    <div class="panelbody-box">
                                        <p>井号1</p>
                                    </div>
                                </div>--%>
                                <table class="easyui-datagrid" title="开发" style="width: 230px; height: 310px" id="kf"></table>
                            </li>
                        </ul>

                        <div class="table-box">
                            <div class="table-box-title">
                                <select class="easyui-combobox" id="SB_LJFGS"  data-options="select:'第一项目部'">
                                    <option value="第一项目部">第一项目部</option>
                                    <option value="第二项目部">第二项目部</option>
                                    <option value="第三项目部">第三项目部</option>
                                    <option value="准东项目部">准东项目部</option>
                                    <option value="塔里木目部">塔里木目部</option>
                                    <option value="海外项目部">海外项目部</option>
                                </select>
                                <b>设备状态统计</b>
                            </div>
                            <table class="easyui-datagrid" title="项目部" style="width: 700px; height: 200px" id="ESCount"></table>
                           <%-- <table class="easyui-datagrid" title="项目部" style="width: 700px; height: 200px"
                                data-options="singleSelect:true,url:' ',method:'get'">
                                <thead>
                                    <tr>
                                        <th data-options="field:'itemid',width:80,align:'center'">类别</th>
                                        <th data-options="field:'productid',width:100,align:'center'">综合仪(气测)</th>
                                        <th data-options="field:'listprice',width:100,align:'center'">地质房</th>
                                        <th data-options="field:'unitcost',width:100,align:'center'">仪器房</th>
                                        <th data-options="field:'unitcost',width:100,align:'center'">住房</th>
                                        <th data-options="field:'attr1',width:100,align:'center'">库房</th>
                                    </tr>
                                </thead>
                            </table>--%>
                        </div>
                        <div class="table-box">
                            <div class="table-box-title">
                                <select class="easyui-combobox" id="RY_LJFGS"  data-options="select:'第一项目部'">
                                    <option value="第一项目部">第一项目部</option>
                                    <option value="第二项目部">第二项目部</option>
                                    <option value="第三项目部">第三项目部</option>
                                    <option value="准东项目部">准东项目部</option>
                                    <option value="塔里木目部">塔里木目部</option>
                                    <option value="海外项目部">海外项目部</option>
                                </select>
                                <b>前线人员状态统计</b>
                            </div>
                            <table class="easyui-datagrid" title="项目部" style="width: 700px; height: 200px" id="RYCount"></table>
                           <%-- <table class="easyui-datagrid" title="项目部" style="width: 700px; height: 200px"
                                data-options="singleSelect:true,url:'',method:'get'">
                                <thead>
                                    <tr>
                                        <th data-options="field:'itemid',width:70,align:'center'">类别</th>
                                        <th data-options="field:'productid',width:90,align:'center'">录井地质师</th>
                                        <th data-options="field:'listprice',width:90,align:'center'">录井工程师</th>
                                        <th data-options="field:'unitcost',width:90,align:'center'">操作员</th>
                                        <th data-options="field:'attr1',width:90,align:'center'">地质工</th>
                                        <th data-options="field:'status',width:90,align:'center'">实习生</th>
                                        <th data-options="field:'status',width:90,align:'center'">地质助理</th>
                                        <th data-options="field:'status',width:90,align:'center'">开发井地质师</th>
                                    </tr>
                                </thead>
                            </table>--%>
                        </div>

                    </div>
                    <!--中间-->
                    <div style="display: inline-block; vertical-align: top; margin: 0 10px;">
                        <div style="position: relative;">
                            <p style="position: absolute; top: 7px; right: 110px; color: #0E2D5F; font-weight: bold; z-index: 10;">井号：<label id="file_JH"></label></p>
                            <div class="easyui-panel" title="钻井地质设计" style="width: 300px; height: 365px; padding: 10px; overflow-y: auto;" id="fileList">
                               <%-- <span class="filename" title="content">content</span><a href="#" class="layui-btn layui-btn-primary layui-btn-xs" download="">下载</a>--%>
                              
                                <%--<iframe width="100%" height="98%" src="http://www.baidu.com" frameborder="0" id="fileList_iframe" seamless=""></iframe>--%>
                            </div>
                        </div>
                        <div style="position: relative;">
                            <p style="position: absolute; top: 7px; right: 110px; color: #0E2D5F; font-weight: bold; z-index: 10;">井号：<label id="map_JH"></label></p>
                            <div class="easyui-panel " title="地图" style="width: 300px; height: 365px; padding: 10px; overflow-y: auto;">
                                <div style="position: absolute; top: 0; left: 1px; height: 364px; width: calc(100% - 2px)" id="map"></div>
                            </div>
                        </div>
                    </div>
                    <!--右侧-->
                    <div style="display: inline-block; vertical-align: top">
                        <%--人员选择--%>
                        <div class="easyui-panel" title="人员选择" style="width: 1000px;">
                            <%--搜索条件--%>
                            <div class="layui-form-item" style="padding-top: 15px;">
                                <div class="layui-inline">
                                    <label class="layui-form-label" style="padding: 5px 0px;">井号：</label>
                                    <div class="layui-input-inline" style="width: 130px">
                                        <input id="txtJH" value="" readonly="readonly" class="easyui-textbox" style="width: 130px;" />
                                    </div>

                                </div>
                                <div class="layui-inline">
                                    <label class="layui-form-label" style="padding: 5px 0px;">选择岗位：</label>
                                    <div class="layui-input-inline" style="width: 130px">

                                        <input id="workerGW" name="" class="easyui-combobox" data-options="
                                                    url:'../../Controllers/ColumnListController.ashx?action=List_XMBGW',
					                                method:'post',
					                                valueField:'NAME',
					                                textField:'NAME',
                                                    editable:false,
                                                    value:'全部'
                                                    "
                                            style="width: 130px;" />
                                    </div>
                                </div>
                                <div class="layui-inline">

                                    <label class="layui-form-label" style="padding: 5px 0px;">查询条件：</label>
                                    <div class="layui-input-inline" style="margin-right: 10px; width: 150px;">

                                        <input id="workerTJ" name="" class="easyui-combobox" data-options="
                                                    url:'../../Controllers/ColumnListController.ashx?action=List_RYTJ',
					                                method:'post',
					                                valueField:'CODE',
					                                textField:'NAME',
                                                    editable:false,
                                                    "
                                            style="width: 130px;" />
                                    </div>
                                </div>
                                <div class="layui-inline">
                                    <input id="keyWords" type="text" name="" class="easyui-textbox" style="width: 130px; margin-right: 50px;" />
                                </div>
                                <div class="layui-inline">
                                    <a href="#" class="easyui-linkbutton  btnGetType" data-options="iconCls:'icon-search'" style="width: 80px" onclick="rySelect()">搜索</a>
                                </div>

                            </div>

                            <div style="overflow: auto; margin-left: 1%">
                                <div style="width: 1000px;">
                                    <div style="width: 450px; display: inline-block; float: left; margin-bottom: 10px">
                                        <table id="getWorkerL" class="easyui-datagrid" title="在岗人员" style="width: 450px; height: 370px;">
                                        </table>
                                    </div>
                                    <div style="width: 80px; display: inline-block; float: left; margin-top: 5%; text-align: center;">
                                        <p style="font-size: 16px;">人员安排</p>
                                        <div class="tableBtn" style="width: 70px; height: 200px; border: 1px solid #e6e6e6; margin-left: 4px;">
                                            <div>
                                                <i class="layui-icon layui-icon-left" style="font-size: 48px; color: #FF5722; margin: 30px 0px; display: block; cursor: pointer;" onclick="CheckDataL()"></i>
                                            </div>
                                            <div>
                                                <i class="layui-icon layui-icon-right" style="font-size: 48px; color: #1E9FFF; margin: 30px 0px; display: block; cursor: pointer;" onclick="CheckDataR()"></i>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="width: 450px; display: inline-block; float: left; margin-bottom: 10px">
                                        <table id="getWorkerR" class="easyui-datagrid" title="待派人员" style="width: 450px; height: 370px">
                                        </table>
                                    </div>
                                    <%--<div class="layui-layer-btn layui-layer-btn-c " style="text-align:center;margin: 5px 0;background:white">
                                        <a  href="#" class="easyui-linkbutton btnGetType" style="width:80px" onclick="loadList()">确认</a>
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                        <%--设备选择--%>
                        <div class="easyui-panel" title="设备选择" style="width: 1000px;">
                            <%--搜索条件--%>
                            <div class="layui-form-item" style="padding-top: 15px;">
                                <div class="layui-inline" style="margin-left: 13%">
                                    <label class="layui-form-label" style="padding: 5px 0px;">选择设备：</label>
                                    <div class="layui-input-inline" style="width: 130px">

                                        <input id="equipmentFL" name="" class="easyui-combobox" data-options="
                                                    url:'../../Controllers/ColumnListController.ashx?action=List_SBFL',
					                                method:'post',
					                                valueField:'NAME',
					                                textField:'NAME',
                                                    editable:false,
                                                    value:'全部'"
                                            style="width: 130px;" />
                                    </div>
                                </div>
                                <div class="layui-inline">
                                    <label class="layui-form-label" style="padding: 5px 0px;">查询条件：</label>
                                    <div class="layui-input-inline" style="margin-right: 10px; width: 150px;">

                                        <input id="equipmentTJ" name="" class="easyui-combobox" data-options="
                                                    url:'../../Controllers/ColumnListController.ashx?action=List_SBTJ',
					                                method:'post',
					                                valueField:'CODE',
					                                textField:'NAME',
                                                    editable:false,"
                                            style="width: 130px;" />
                                    </div>
                                </div>
                                <div class="layui-inline">
                                    <input id="keyEquipment" type="text" name="" class="easyui-textbox" style="width: 130px; margin-right: 50px;" />
                                </div>
                                <div class="layui-inline">
                                    <a href="#" class="easyui-linkbutton  btnGetType" data-options="iconCls:'icon-search'" style="width: 80px" onclick="selectEquipment()">搜索</a>
                                </div>
                            </div>

                            <div style="overflow: auto; margin-left: 1%">
                                <div style="width: 1000px;">
                                    <div style="width: 450px; display: inline-block; float: left; margin-bottom: 10px">
                                        <table id="getEquipmentL" class="easyui-datagrid" title="在用设备" style="width: 450px; height: 370px;">
                                        </table>
                                    </div>
                                    <div style="width: 80px; display: inline-block; float: left; margin-top: 5%; text-align: center;">
                                        <p style="font-size: 16px;">设备安排</p>
                                        <div class="tableBtn" style="width: 70px; height: 200px; border: 1px solid #e6e6e6; margin-left: 4px;">
                                            <div>
                                                <i class="layui-icon layui-icon-left" style="font-size: 48px; color: #FF5722; margin: 30px 0px; display: block;" onclick="CheckEquipmentL()"></i>
                                            </div>
                                            <div>
                                                <i class="layui-icon layui-icon-right" style="font-size: 48px; color: #1E9FFF; margin: 30px 0px; display: block;" onclick="CheckEquipmentR()"></i>
                                            </div>

                                        </div>
                                    </div>
                                    <div style="width: 450px; display: inline-block; float: left; margin-bottom: 10px">
                                        <table id="getEquipmentR" class="easyui-datagrid" title="闲置设备" style="width: 450px; height: 370px">
                                        </table>
                                    </div>
                                </div>
                            </div>

                            <%-- <div class="layui-layer-btn layui-layer-btn-c " style="text-align: center; margin: 5px 0; background: white">
                                <a href="#" class="easyui-linkbutton btnGetType" style="width: 80px" onclick="overSBPB()">确定</a>
                            </div>--%>
                        </div>
                        <!--地质房选择-->
                        <div class="easyui-panel" title="地质房选择" style="width: 1000px;">
                            <div style="overflow: auto; margin-left: 1%;">
                                <div style="width: 1000px;">
                                    <div style="width: 450px; display: inline-block; float: left; margin: 10px 0;">
                                        <table id="getDZFL" class="easyui-datagrid" title="在用地质房" style="width: 450px; height: 370px;">
                                        </table>
                                    </div>
                                    <div style="width: 80px; display: inline-block; float: left; margin-top: 5%; text-align: center;">
                                        <p style="font-size: 16px;">地质房安排</p>
                                        <div class="tableBtn" style="width: 70px; height: 200px; border: 1px solid #e6e6e6; margin-left: 4px;">
                                            <div>
                                                <i class="layui-icon layui-icon-left" style="font-size: 48px; color: #FF5722; margin: 30px 0px; display: block;" onclick="CheckDZFL()"></i>
                                            </div>
                                            <div>
                                                <i class="layui-icon layui-icon-right" style="font-size: 48px; color: #1E9FFF; margin: 30px 0px; display: block;" onclick="CheckDZFR()"></i>
                                            </div>

                                        </div>
                                    </div>
                                    <div style="width: 450px; display: inline-block; float: left; margin: 10px 0;">
                                        <table id="getDZFR" class="easyui-datagrid" title="闲置地质房" style="width: 450px; height: 370px">
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <%-- <div class="layui-layer-btn layui-layer-btn-c " style="text-align: center; margin: 5px 0; background: white">
                                <a href="#" class="easyui-linkbutton btnGetType" style="width: 80px" onclick="overDZ()">确定</a>
                            </div>--%>
                        </div>
                        <!--住房选择-->
                        <div class="easyui-panel" title="住房选择" style="width: 1000px;">
                            <div style="overflow: auto; margin-left: 1%;">
                                <div style="width: 1000px;">
                                    <div style="width: 450px; display: inline-block; float: left; margin: 10px 0;">
                                        <table id="getZFL" class="easyui-datagrid" title="在用住房" style="width: 450px; height: 370px;">
                                        </table>
                                    </div>
                                    <div style="width: 80px; display: inline-block; float: left; margin-top: 5%; text-align: center;">
                                        <p style="font-size: 16px;">住房安排</p>
                                        <div class="tableBtn" style="width: 70px; height: 200px; border: 1px solid #e6e6e6; margin-left: 4px;">
                                            <div>
                                                <i class="layui-icon layui-icon-left" style="font-size: 48px; color: #FF5722; margin: 30px 0px; display: block;" onclick="CheckZFL()"></i>
                                            </div>
                                            <div>
                                                <i class="layui-icon layui-icon-right" style="font-size: 48px; color: #1E9FFF; margin: 30px 0px; display: block;" onclick="CheckZFR()"></i>
                                            </div>

                                        </div>
                                    </div>
                                    <div style="width: 450px; display: inline-block; float: left; margin: 10px 0;">
                                        <table id="getZFR" class="easyui-datagrid" title="闲置住房" style="width: 450px; height: 370px">
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <%--<div class="layui-layer-btn layui-layer-btn-c " style="text-align: center; margin: 5px 0; background: white">
                                <a href="#" class="easyui-linkbutton btnGetType" style="width: 80px" onclick="overZF()">确定</a>
                            </div>--%>
                        </div>
                        <%--库房分配--%>
                        <div class="easyui-panel" title="库房分配" style="width: 1000px;">
                            <div style="overflow: auto; margin-left: 1%;">
                                <div style="width: 1000px;">
                                    <div style="width: 450px; display: inline-block; float: left; margin: 10px 0;">
                                        <table id="getKFL" class="easyui-datagrid" title="在用库房" style="width: 450px; height: 370px;">
                                        </table>
                                    </div>
                                    <div style="width: 80px; display: inline-block; float: left; margin-top: 5%; text-align: center;">
                                        <p style="font-size: 16px;">库房安排</p>
                                        <div class="tableBtn" style="width: 70px; height: 200px; border: 1px solid #e6e6e6; margin-left: 4px;">
                                            <div>
                                                <i class="layui-icon layui-icon-left" style="font-size: 48px; color: #FF5722; margin: 30px 0px; display: block;" onclick="CheckKFL()"></i>
                                            </div>
                                            <div>
                                                <i class="layui-icon layui-icon-right" style="font-size: 48px; color: #1E9FFF; margin: 30px 0px; display: block;" onclick="CheckKFR()"></i>
                                            </div>

                                        </div>
                                    </div>
                                    <div style="width: 450px; display: inline-block; float: left; margin: 10px 0;">
                                        <table id="getKFR" class="easyui-datagrid" title="闲置库房" style="width: 450px; height: 370px">
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <%-- <div class="layui-layer-btn layui-layer-btn-c " style="text-align: center; margin: 5px 0; background: white">
                                <a href="#" class="easyui-linkbutton btnGetType" style="width: 80px" onclick="overKF()">确定</a>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
