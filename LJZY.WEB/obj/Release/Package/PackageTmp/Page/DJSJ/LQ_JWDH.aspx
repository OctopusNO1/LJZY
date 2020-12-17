<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LQ_JWDH.aspx.cs" Inherits="LJZY.WEB.Page.LQ_JWDH" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["theme"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["icon"].ToString()%>" rel="stylesheet" type="text/css" />
 
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["jquery"].ToString()%>" type="text/javascript"></script>
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-min"].ToString()%>" type="text/javascript"></script>
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-zh_CN"].ToString()%>" type="text/javascript"></script>
    <%--<script src="<%=System.Configuration.ConfigurationManager.AppSettings["jquerycontrol"].ToString()%>" type="text/javascript"></script>--%>
    <%--<script src="../../Scripts/jquery-1.8.2.js"></script>--%>
    <script src="../../Scripts/Echarts/echarts.js"></script>
<%--    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=IDvNBsejl9oqMbPF316iKsXR"></script>--%>
    <script src="../../Scripts/map/map_load.js"></script>
    <link href="../../CSS/LQ_JWDH.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            var height1 = $(window).height() - 36;
            var w = $(window).width() - 230;
            $(".contentbox").attr("style", "overflow-x:auto;overflow-y:auto;height:" + height1 + "px");
            $(".contentbox").layout("resize", {
                width: w,
                height: height1
            });

        });


        $(window).resize(function () {
            var height1 = $(window).height() - 36;
            var w = $(window).width() - 230;

            $(".contentbox").attr("style", "overflow-x:auto;overflow-y:auto;height:" + height1 + "px");
            $(".contentbox").layout("resize", {
                width: w,
                height: height1
            });

        });
      
    </script>
</head>
<body>
    <div title="井位导航" style="overflow-y: auto;">
        <!--井位导航-->
        <div data-options="region:'north',fit:true">
            <div class="easyui-panel" style="padding: 5px; border-left-style: none; border-right-style: none; border-top-style: none; border-bottom-style: none; background: #E0ECFF" data-options="fit:true">
                <label style="padding-left: 10px">年度</label>
                <input id="year" class="easyui-combobox" data-options="
                    url:'../../Controllers/ColumnListController.ashx?action=YL',
					method:'post',
					valueField:'Y',
					textField:'Y',
                    editable:false,
                    value:'<%=Year %>'"
                    style="width: 70px" />
                <%--<input id="SelectColumn_List" class="easyui-combobox" data-options="
                    url:'../../Controllers/ColumnListController.ashx?action=Column_List',
					method:'post',
					valueField:'CODE',
					textField:'NAME',
                    editable:false,
                    value:'ZJH'"
                    style="width: 150px" />
                <input id="Symbol_List" class="easyui-combobox" data-options="
                    url:'../../Controllers/ColumnListController.ashx?action=Symbol_List',
					method:'post',
					valueField:'CODE',
					textField:'NAME',
                    editable:false,
                    value:'='"
                    style="width: 70px" />--%>
                <span>井号=</span>
                <input class="easyui-textbox" data-options="prompt:'请输入井号'" style="width: 100px" id="isvalue" />
               <%-- <input type="checkbox" id="chkbox" /><span>OR</span>
                <button class="easyui-linkbutton btnGetType" onclick="addTJ();">添加条件</button>
                <div id="SelectWhere">
                        <div class="groups">
                                    <span>AND</span>
                                    <span>XJH</span>
                                    <span>"ckck"</span>
                                    <i class="close">X</i>
                                </div>
                              <div class="groups">
                                    <span>AND</span>
                                    <span>XJH</span>
                                    <span>"ckck"</span>
                                    <i class="close">X</i>
                                </div>
                </div>--%>
                <%--                        <input class="easyui-textbox" style="width: 150px" />--%>
                <%--<button  class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-search'">搜索</button>--%>
                <button class="easyui-linkbutton btnGetType" id="navSearch" onclick="search()">搜索</button>
            </div>
        </div>
        <div>
            <div class="easyui-panel" style="width: 1434px; padding: 5px 5px 5px 0px; border-left-style: none; border-right-style: none; background: #e3efff" data-options="fit:true">
                <%--<span style="padding-left: 3px"></span>--%>
                <%--<button class="easyui-linkbutton c5 btnGetType btnIndex" style="width: 100px; height: 30px;line-height:30px;" onclick="map_init();">全部</button>--%>
                <button class="easyui-linkbutton c5 btnGetType btnIndex" style="width: 100px; height: 30px; line-height: 30px;">甲方单位</button>
                <input id="jfdw" type="text" name="name" value=" " class="easyui-combobox" style="width: 120px; height: 26px" data-options="
                                        valueField: 'id',
		                                textField: 'text',
		                                data: [{
			                                id: '',
			                                text: '全部'
		                                },{
                                            id: '勘探公司',
			                                text: '勘探公司'
			                              
		                                },{
			                                id: '开发公司',
			                                text: '开发公司'
		                                }],
                                        value:'',
                                        editable:false"
                    style="width: 100px; height: 26px" panelheight="auto" />
                <button class="easyui-linkbutton c5 btnGetType btnIndex" style="width: 100px; height: 30px; line-height: 30px;">录井项目部</button>
                <input id="xmb" class="easyui-combobox" data-options="editable:false,value:'',valueField:'id', textField:'text'" style="width: 100px; height: 26px" panelheight="auto" />
                <button class="easyui-linkbutton c5 btnGetType btnIndex" style="width: 100px; height: 30px; line-height: 30px;">地区</button>
                <input id="dq" type="text" name="name" value=" " class="easyui-combobox" style="width: 120px; height: 26px" data-options="editable:false,value:'',valueField:'id', textField:'text'" panelheight="auto" />
                <button class="easyui-linkbutton c5 btnGetType btnIndex" style="width: 100px; height: 30px; line-height: 30px;">井别</button>
                <input id="jb" type="text" name="name" value=" " class="easyui-combobox" style="width: 120px; height: 26px" data-options="editable:false,value:'',valueField:'id', textField:'text'" panelheight="auto" />
                <%--<button class="easyui-linkbutton c5 btnGetType btnIndex" style="width: 100px; height: 30px;line-height:30px;" onclick="KT_Click()">勘探</button>--%>
                <%--       <button class="easyui-linkbutton c5 btnGetType btnIndex" style="width: 100px; height: 30px;line-height:30px;" onclick="KF_Click()">开发</button>--%>
                <button class="easyui-linkbutton c5 btnGetType btnIndex" style="width: 100px; height: 30px; line-height: 30px;" onclick="WX_Click()">卫星</button>
                <%--<button class="easyui-linkbutton c5 btnGetType btnIndex" style="width: 100px; height: 30px;line-height:30px;" onclick="ZZ_Click()">正钻</button>--%>
                <button class="easyui-linkbutton c5 btnGetType btnIndex" style="width: 100px; height: 30px; line-height: 30px;" onclick="DP_Click()">待派</button>
            </div>
        </div>
        <!--显示地图-->


        <div style="position: relative; overflow: hidden; height: 600px; width: 99%;" class="easyui-panel" id="showMap">
            <div style="position: absolute; top: 0; left: 0; height: 600px; width: 100%" id="map"></div>
            <div style="width: 30px; height: 600px" class="rightButton">
                <div class="smallButton">
                    <ul>
                        <li>
                            <button id="btnYes">动态统计</button>
                        </li>
                    </ul>
                </div>
            </div>
            <!--显示小地图-->
            <div class="easyui-draggable" id="easy_map" data-options="onDrag:onDrag" style="position: absolute; left: 65%; top: 20px; width: 500px; height: 356px; background: none; border: none;">
                <div class="showReact" id="showRect" style="left: 0; top: 0;">
                    <div class="closeXDT">
                        <img src="../../Image/close.jpg" alt="" style="border-radius: 50%; cursor: pointer;" width="20" height="20" onclick="clsEchartsMain()" />
                    </div>
                    <div class="JDTTJ">井动态统计</div>
                    <div id="EChartsMain" style="padding: 10px; height: 180px"></div>
                    <%-- <span class="showRectSpan1">34</span>
                            <span class="showRectSpan2">200</span>
                            <span class="showRectSpan3">50</span>
                            <span class="showRectSpan4">50</span>
                            <span class="showRectSpan5">勘探</span>
                            <span class="showRectSpan6">正钻</span>
                            <span class="showRectSpan7">待派</span>
                            <span class="showRectSpan8">总井数</span>
                            <svg id="svg_line" style="width: 200px; height: 214px;">
                            </svg>--%>
                    <table id="smallMap_table">
                        <tbody>
                            <tr>
                                <td class="tit">动态总井数据</td>
                                <td>
                                    <input id="Count_SY" style="width: 80px; height: 20px; box-sizing: border-box; background: none; outline: none; border: none" type="type" name="name" value=" " />
                                </td>
                            </tr>
                            <tr>
                                <td class="tit">正钻总井数</td>
                                <td>
                                    <input id="Count_ZZ" style="width: 80px; height: 20px; box-sizing: border-box; background: none; outline: none; border: none" type="type" name="name" value=" " />
                                </td>
                            </tr>
                            <tr>
                                <td class="tit">待派总井数</td>
                                <td>
                                    <input id="Count_DP" style="width: 80px; height: 20px; box-sizing: border-box; background: none; outline: none; border: none" type="type" name="name" value=" " />
                                </td>
                            </tr>
                            <tr>
                                <td class="tit" style="color: red">勘探正钻</td>
                                <td>
                                    <input id="Count_KTDP" style="width: 80px; height: 20px; box-sizing: border-box; background: none; outline: none; border: none" type="type" name="name" value=" " />
                                </td>
                            </tr>
                            <tr>
                                <td class="tit" style="color: red">开发正钻</td>
                                <td>
                                    <input id="Count_KF" style="width: 80px; height: 20px; box-sizing: border-box; background: none; outline: none; border: none" />
                                </td>
                            </tr>

                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <div class="easyui-accordion" style="width: 100%; height: auto;">
            <div title="重点提示" style="overflow: auto; padding: 10px;">
            </div>
            <div title="单井工程进度" style="padding: 10px;">
            </div>
        </div>

    </div>
    <script src="../../Scripts/LQZY/LQ_JWDH.js"></script>
    <script>
        function onDrag(e) {
            var d = e.data;
            if (d.left < 0) { d.left = 0 }
            if (d.top < 0) { d.top = 0 }
            if (d.left + $(d.target).outerWidth() > $(d.parent).width()) {
                d.left = $(d.parent).width() - $(d.target).outerWidth();
            }
            if (d.top + $(d.target).outerHeight() > $(d.parent).height()) {
                d.top = $(d.parent).height() - $(d.target).outerHeight();
            }
        }
        $("#navSearch>span").addClass("navSearchSpan"); 
    </script>
</body>
</html>
