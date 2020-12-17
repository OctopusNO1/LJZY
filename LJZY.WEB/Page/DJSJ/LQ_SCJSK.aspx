<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LQ_SCJSK.aspx.cs" Inherits="LJZY.WEB.Page.DJSJ.LQ_SCJSK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=IDvNBsejl9oqMbPF316iKsXR"></script>
    <script src="../../Scripts/LQZY/LQ_SCJSK.js"></script>
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

        .tdiv-rightbox {
            position: relative;
        }

            .tdiv-rightbox > p {
                position: absolute;
                top: 7px;
                right: 190px;
                font-weight: bold;
                color: #0E2D5F;
                z-index: 10;
            }

        #SCPG_content .layui-table-view {
            margin: 0;
        }

        .anchorBL, .BMap_cpyCtrl, .BMap_scaleCtrl {
            display: none;
        }

        .panel-header {
            z-index: 9;
        }
        .checkboxlist li{
            padding: 0 10px;
        }
        .checkboxlist li input{
           cursor:pointer;
           vertical-align:middle;
        }
        .checkboxlist li>span{
                display: inline-block;
    width: 136px;
    overflow: hidden;
    text-overflow: ellipsis;
    white-space: nowrap;
    vertical-align:middle;
        }
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
    <div id="loading" style="position: absolute; z-index: 1000; top: 0px; left: 0px; width: 100%; height: 100%; background: #ffffff; text-align: center; padding-top: 20%;">
        <h3><font color="#242b5f">加载中....</font></h3>
    </div>

    <div data-options="region:'center',iconCls:'icon-ok',border:false">
        <div id="tab" class="easyui-tabs" data-options="fit:true,plain:true">
            <div title="生产派工" style="overflow-x: auto; overflow-y: auto;">
                <div id="SCPG_content" style="width: 1412px; min-height: 800px; margin: auto; position: relative">
                    <%-- 左侧 --%>
                    <div style="display: inline-block;">


                        <div class="easyui-panel clear" title="勘探" style="width: 300px; height: 310px; padding: 10px">

                            <div class="react_JH" id="react_JH" style="overflow: hidden; overflow: auto; width: 160px; height: 255px; float: left; border: 1px solid #95B8E7;">
                                <table class="layui-hide" id="kt" lay-filter="kt"></table>
                            </div>
                            <ul style="width: 100px; min-height: 150px; float: left; margin-left: 10px" id="one_CZ">
                                <li style="">
                                    <a href="#" class="easyui-linkbutton" onclick="LJCZ_KT('第一项目部')" style="background: #e3efff; width: 100%; border-radius: 5px">第一项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_KT('第二项目部')">第二项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_KT('第三项目部')">第三项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_KT('准东项目部')">准东项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_KT('塔里木项目部')">塔里木项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_KT('海外项目部')">海外项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_KT('其他')">其他</a>
                                </li>
                            </ul>
                        </div>
                        <div class="easyui-panel clear" title="油藏评价" style="width: 300px; height: 310px; padding: 10px">

                            <div class="react_JH" id="react_JH2" style="overflow: hidden; overflow: auto; width: 160px; height: 255px; float: left; border: 1px solid #95B8E7;">
                                <table class="layui-hide" id="pj" lay-filter="pj"></table>
                            </div>
                            <ul style="width: 100px; min-height: 150px; float: left; margin-left: 10px" id="two_CZ">
                                <li style="">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_PJ('第一项目部')">第一项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_PJ('第二项目部')">第二项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_PJ('第三项目部')">第三项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_PJ('准东项目部')">准东项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_PJ('塔里木项目')">塔里木项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_PJ('海外项目')">海外项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_PJ('其他')">其他</a>
                                </li>
                            </ul>
                        </div>
                        <div class="easyui-panel clear" title="开发" style="width: 300px; height: 310px; padding: 10px">

                            <div class="react_JH" id="react_JH3" style="overflow: hidden; overflow: auto; width: 160px; height: 255px; float: left; border: 1px solid #95B8E7;">
                                <table class="layui-hide" id="kf" lay-filter="kf"></table>
                            </div>
                            <ul style="width: 100px; min-height: 150px; float: left; margin-left: 10px" id="three_CZ">
                                <li style="">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_KF('第一项目部')">第一项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_KF('第二项目部')">第二项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_KF('第三项目部')">第三项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_KF('准东项目部')">准东项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_KF('塔里木项目')">塔里木项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_KF('海外项目')">海外项目部</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_KF('其他')">其他</a>
                                </li>
                            </ul>
                        </div>
                        <div class="easyui-panel clear" title="其他" style="width: 300px; height: 310px; padding: 10px">

                            <div class="react_JH" id="react_JH4" style="overflow: hidden; overflow: auto; width: 160px; height: 255px; float: left; border: 1px solid #95B8E7;">
                                <table class="layui-hide" id="qt" lay-filter="qt"></table>
                            </div>
                            <ul style="width: 100px; min-height: 150px; float: left; margin-left: 10px" id="four_CZ">
                                <li style="">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_QT('勘探')">勘探</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_QT('油藏评价')">油藏评价</a>
                                </li>
                                <li style="margin-top: 8px">
                                    <a href="#" class="easyui-linkbutton" style="background: #e3efff; width: 100%; border-radius: 5px" onclick="LJCZ_QT('开发')">开发</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <%-- 中间-1 --%>
                    <div style="display: inline-block; vertical-align: top; margin: 0 10px;">
                        <div style="position: relative;">
                            <%--<p style="position: absolute; top: 7px; right: 110px; color: #0E2D5F; font-weight: bold; z-index: 10;">井号：<label id="file_JH"></label></p>--%>
                            <div class="easyui-panel" title="钻井地质设计" style="width: 300px; height: 412px; padding: 10px; overflow-y: auto;" id="fileList" data-options="collapsible:true">
                            </div>
                        </div>
                        <div style="position: relative;">
                            <p style="position: absolute; top: 7px; right: 110px; color: #0E2D5F; font-weight: bold; z-index: 10;">井号：<label id="map_JH"></label></p>
                            <div class="easyui-panel " title="地图" style="width: 300px; height: 412px; padding: 10px; overflow-y: auto;" data-options="collapsible:true">
                                <div style="position: absolute; top: 0; left: 1px; height: 411px; width: calc(100% - 2px)" id="map"></div>
                            </div>
                        </div>

                    </div>
                    <%-- 中间-2 --%>
                    <div style="display: inline-block; vertical-align: top; margin-right: 10px;">
                        <%--<a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" style="height: 30px; margin: 5px 0;" onclick="jumptourl('人员设备统计')">人员设备统计</a>--%>

                        <div class="tdiv-rightbox">
                            <p onclick="jumptourl('人员设备统计')" style="cursor:pointer">队伍动用统计</p>
                            <table class="easyui-datagrid" title="项目部" style="width: 470px; height: 206px" id="item1" data-options="collapsible:true"></table>
                            <%--<table class="easyui-datagrid" title="项目部" style="width: 470px; height: 200px"
                                data-options="singleSelect:true,url:'',method:'get'">
                                <thead>
                                    <tr>
                                        <th data-options="field:'itemid',width:80,align:'center'">类别</th>
                                        <th data-options="field:'productid',width:100,align:'center'">一项目部</th>
                                        <th data-options="field:'listprice',width:100,align:'center'">二项目部</th>
                                        <th data-options="field:'unitcost',width:100,align:'center'">三项目部</th>
                                        <th data-options="field:'attr1',width:100,align:'center'">准东</th>
                                        <th data-options="field:'status',width:100,align:'center'">塔里木</th>
                                        <th data-options="field:'status',width:100,align:'center'">海外</th>
                                    </tr>
                                </thead>
                            </table>--%>
                        </div>

                        <%--<a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" style="height: 30px; margin: 5px 0;" onclick="jumptourl('生产动态统计')">生产动态统计</a>--%>
                        <div class="tdiv-rightbox">
                            <p onclick="jumptourl('生产动态统计')" style="cursor:pointer">施工状态统计</p>
                            <table class="easyui-datagrid" title="项目部" style="width: 470px; height: 206px" id="item2" data-options="collapsible:true"></table>
                            <%--  <thead>
                                    <tr>
                                        <th data-options="field:'itemid',width:80,align:'center'">类别</th>
                                        <th data-options="field:'productid',width:100,align:'center'">一项目部</th>
                                        <th data-options="field:'listprice',width:100,align:'center'">二项目部</th>
                                        <th data-options="field:'unitcost',width:100,align:'center'">三项目部</th>
                                        <th data-options="field:'attr1',width:100,align:'center'">准东</th>
                                        <th data-options="field:'status',width:100,align:'center'">塔里木</th>
                                        <th data-options="field:'status',width:100,align:'center'">海外</th>
                                    </tr>
                                </thead>
                            </table>--%>
                        </div>
                         <div class="tdiv-rightbox">
                            <p>完钻井明细表</p>
                            <table class="easyui-datagrid" title="项目部" style="width: 470px; height: 412px" id="item3" data-options="collapsible:true"></table>
                            <%--  <thead>
                                    <tr>
                                        <th data-options="field:'itemid',width:80,align:'center'">类别</th>
                                        <th data-options="field:'productid',width:100,align:'center'">一项目部</th>
                                        <th data-options="field:'listprice',width:100,align:'center'">二项目部</th>
                                        <th data-options="field:'unitcost',width:100,align:'center'">三项目部</th>
                                        <th data-options="field:'attr1',width:100,align:'center'">准东</th>
                                        <th data-options="field:'status',width:100,align:'center'">塔里木</th>
                                        <th data-options="field:'status',width:100,align:'center'">海外</th>
                                    </tr>
                                </thead>
                            </table>--%>
                        </div>

                    </div>
                    <%-- 右侧 --%>
                    <div style="display: inline-block; vertical-align: top;">

                        <div class="easyui-panel" title="第一项目部" style="width:300px; min-height: 206px; border: 1px solid #95B8E7;" data-options="collapsible:true">
                            <span style="position: absolute; top: 6px; left: 100px; font-weight: bold; color: #0E2D5F;">队伍总数<span class="one_total"></span></span>

                            <span style="position: absolute; top: 6px; left: 180px; font-weight: bold; color: #0E2D5F;">待命队伍<span class="one_DMD"></span></span>
                            <ul id="OneHT">
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">勘探井</li>
                                        <li id="KTJ_one" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="dyxmb_kt" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                                <%--<li>
                                                    <input type="checkbox" name="dyxmb_kt" value="content" checked/>
                                                    <span>content</span>
                                                </li>
                                                <li>
                                                    <input type="checkbox" name="dyxmb_kt" value="content2" />
                                                    <span>content2</span>
                                                </li>
                                                <li>
                                                    <input type="checkbox" name="dyxmb_kt" value="content3" checked/>
                                                    <span>content3</span>
                                                </li>
                                                   <li>
                                                    <input type="checkbox" name="dyxmb_kt" value="content4" />
                                                    <span>content4</span>
                                                </li>--%>
                                            </ul>
                                        
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('dyxmb_kt')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>

                                </li>
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">评价井</li>
                                        <li id="PJJ_one" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="dyxmb_pj" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('dyxmb_pj')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">开发井</li>
                                        <li id="KFJ_one" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="dyxmb_kf" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('dyxmb_kf')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <div class="easyui-panel " title="第二项目部" style="position: relative; width: 300px; min-height: 206px; border: 1px solid #95B8E7;" data-options="collapsible:true">
                            <span style="position: absolute; top: -26px; left: 100px; font-weight: bold; color: #0E2D5F;">队伍总数<span class="two_total"></span></span>

                            <span style="position: absolute; top: -26px; left: 180px; font-weight: bold; color: #0E2D5F;">待命队<span class="two_DMD"></span></span>
                            <ul id="TwoHT">
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">勘探井</li>
                                        <li id="KTJ_two" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="dexmb_kt" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('dexmb_kt')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">评价井</li>
                                        <li id="PJJ_two" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="dexmb_pj" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('dexmb_pj')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">开发井</li>
                                        <li id="KFJ_two" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="dexmb_kf" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('dexmb_kf')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <div class="easyui-panel " title="第三项目部" style="position: relative; width: 300px; min-height: 206px; border: 1px solid #95B8E7;" data-options="collapsible:true">
                            <span style="position: absolute; top: -26px; left: 100px; font-weight: bold; color: #0E2D5F;">队伍总数<span class="three_total"></span></span>

                            <span style="position: absolute; top: -26px; left: 180px; font-weight: bold; color: #0E2D5F;">待命队伍<span class="three_DMD"></span></span>
                            <ul id="ThreeHT">
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">勘探井</li>
                                        <li id="KTJ_three" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="dsxmb_kt" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('dsxmb_kt')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">评价井</li>
                                        <li id="PJJ_three" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="dsxmb_pj" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('dsxmb_pj')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">开发井</li>
                                        <li id="KFJ_three" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="dsxmb_kf" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('dsxmb_kf')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <div class="easyui-panel " title="准东项目部" style="position: relative; width: 300px; min-height: 206px; border: 1px solid #95B8E7;" data-options="collapsible:true">
                            <span style="position: absolute; top: -26px; left: 100px; font-weight: bold; color: #0E2D5F;">队伍总数<span class="ZD_total"></span></span>

                            <span style="position: absolute; top: -26px; left: 180px; font-weight: bold; color: #0E2D5F;">待命队伍<span class="ZD_DMD"></span> </span>
                            <ul id="ZDHT">
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">勘探井</li>
                                        <li id="KTJ_ZD" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="zdxmb_kt" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('zdxmb_kt')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>

                                </li>
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">评价井</li>
                                        <li id="PJJ_ZD" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="zdxmb_pj" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('zdxmb_pj')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">开发井</li>
                                        <li id="KFJ_ZD" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="zdxmb_kf" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('zdxmb_kf')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <div class="easyui-panel " title="塔里木项目部" style="position: relative; width: 300px; min-height: 206px; border: 1px solid #95B8E7;" data-options="collapsible:true">
                            <span style="position: absolute; top: -26px; left: 100px; font-weight: bold; color: #0E2D5F;">队伍总数<span class="TL_total"></span></span>

                            <span style="position: absolute; top: -26px; left: 180px; font-weight: bold; color: #0E2D5F;">待命队伍<span class="TL_DMD"></span></span>
                            <ul id="TLHT">
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">勘探井</li>
                                        <li id="KTJ_TL" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="tlmxmb_kt" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('tlmxmb_kt')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">评价井</li>
                                        <li id="PJJ_TL" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="tlmxmb_pj" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('tlmxmb_pj')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">开发井</li>
                                        <li id="KFJ_TL" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="tlmxmb_kf" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('tlmxmb_kf')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <div class="easyui-panel " title="海外项目部" style="position: relative; width: 300px; min-height: 206px; border: 1px solid #95B8E7;" data-options="collapsible:true">
                            <span style="position: absolute; top: -26px; left: 100px; font-weight: bold; color: #0E2D5F;">队伍总数<span class="HW_total"></span></span>

                            <span style="position: absolute; top: -26px; left: 180px; font-weight: bold; color: #0E2D5F;">待命队伍<span class="HW_DMD"></span></span>
                            <ul id="HWHT">
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">勘探井</li>
                                        <li id="KTJ_HW" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="hwxmb_kt" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('hwxmb_kt')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">评价井</li>
                                        <li id="PJJ_HW" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="hwxmb_pj" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('hwxmb_pj')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                                <li style="height: 56px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 56px; background: #e3efff; text-align: center; line-height: 50px">开发井</li>
                                        <li id="KFJ_HW" style="float: left; width: 200px; height: 56px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto">
                                            <ul id="hwxmb_kf" style="overflow: auto; width: 197px; height: 56px;" class="checkboxlist">
                                            </ul>
                                        </li>
                                        <li style="float: left; width: 40px; height: 56px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="li_check('hwxmb_kf')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                        <%--<div class="easyui-panel " title="其他项目部" style="position: relative; width: 300px; min-height: 200px; border: 1px solid #95B8E7;">
                            <span style="position: absolute; top: -26px; left: 100px; font-weight: bold; color: #0E2D5F;">队伍总数<span class="QT_total"></span></span>

                            <span style="position: absolute; top: -26px; left: 180px; font-weight: bold; color: #0E2D5F;">待命队伍<span class="QT_DMD"></span></span>
                            <ul id="QTHT">
                                <li style="height: 53px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 50px; background: #e3efff; text-align: center; line-height: 50px">勘探井</li>
                                        <li id="KTJ_QT" style="float: left; width: 200px; height: 50px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto"></li>
                                        <li style="float: left; width: 40px; height: 50px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="HTClick('d7KTJ')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                                <li style="height: 53px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 50px; background: #e3efff; text-align: center; line-height: 50px">评价井</li>
                                        <li id="PJJ_QT" style="float: left; width: 200px; height: 50px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto"></li>
                                        <li style="float: left; width: 40px; height: 50px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="HTClick('d7PJJ')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                                <li style="height: 53px; border-bottom: 1px solid #95B8E7">
                                    <ul class="clear">
                                        <li style="float: left; width: 50px; height: 50px; background: #e3efff; text-align: center; line-height: 50px">开发井</li>
                                        <li id="KFJ_QT" style="float: left; width: 200px; height: 50px; border-left: 1px solid #95B8E7; border-right: 1px solid #95B8E7; overflow-y: auto"></li>
                                        <li style="float: left; width: 40px; height: 50px; box-sizing: border-box; padding-top: 13px; padding-left: 13px">
                                            <img onclick="HTClick('d7KFJ')" src="/Image/xia.png" alt="" style="transform: rotate(180deg)" /></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>--%>

                    </div>
                </div>

            </div>
        </div>

    </div>

</body>
</html>
<script type="text/javascript">



</script>
