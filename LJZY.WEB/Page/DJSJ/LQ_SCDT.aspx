<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LQ_SCDT.aspx.cs" Inherits="LJZY.WEB.Page.DJSJ.LQ_SCDT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["theme"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["icon"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["demo"].ToString()%>" rel="stylesheet" type="text/css" />
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["jquery"].ToString()%>" type="text/javascript"></script>
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-min"].ToString()%>" type="text/javascript"></script>
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-zh_CN"].ToString()%>" type="text/javascript"></script>
    <script src="../../Scripts/layui/layui.js"></script>
    <link href="../../Scripts/layui/css/layui.css" rel="stylesheet" />
    <link href="../../Scripts/layui/css/layui.css" rel="stylesheet" />
    <link href="../../CSS/LQ_SCDT.css" rel="stylesheet" />
    <script src="../../Scripts/vue.js"></script>
    <style>
        .dataList {
            border-collapse: collapse;
            border-spacing: 0;
            border: 1px solid #000;
            width: 1375px;
            text-align: center;
        }

            .dataList th {
                border: 1px solid #000;
            }

        table th, td {
            border: 1px solid #000;
            text-align: center;
        }

        table input {
            text-align: center;
            border: 0;
        }

        .wd73px input {
            border: none;
            text-align: center;
        }

        .HeaderFixed {
            margin-bottom:20px;
        }

            .HeaderFixed th {
                width: 130px;
            }

                .HeaderFixed th:nth-child(1) {
                    width: 127px;
                }

        #SCDT {
            font-family: "宋体",SimSuncss;
            /* font-size:29px; */
        }

        #contentCenter li {
            border-bottom: 1px solid #000;
        }
    </style>
</head>
<body style="margin: 0 auto">
    <div class="easyui-tabs" data-options="fit:true,plain:true">

        <!--生产动态报表-->
        <div id="SCDT" title="动态生产" style="padding: 0 28px; overflow: auto;">
            <div >
                <div class="HeaderFixed">
                    <div style="padding-top: 20px; text-align: right">
                        <h1 style="text-align: center; font-family: '黑体'">克拉玛依录井工程公司生产运行表</h1>
                    </div>
                    <div style="padding-top:20px;">
                        <div style="float: left; margin-right: 20px">
                            <div style="width: 100px;height:25px;line-height:25px; float: left; text-align: center">
                                <span style="font-weight:bold;display:inline-block;height:25px">录井项目部</span>
                            </div>
                            <div style="float: left;">
                                <select style="width: 120px;height:25px;" v-model="XMBName" id="SELECT_XMB">
                                    <option value="" style="display: none" id="Qb">全部</option>
                                    <option v-for="val in XMBList" v-bind:value="val.NAME">{{val.NAME}}</option>
                                </select>
                            </div>
                        </div>
                        <div style="height: 23px;margin-left:15px">
                            <span style="font-weight:bold;display:inline-block;height:25px">日期</span>
                            <input class="easyui-datebox" id="datecheckbox" style="width: 140px; height:25px" data-options="onSelect:onSelect" v-model="changeData" v-on:change="changeTIME" />
                            <span>
                                <button v-on:click="getData" id="upCommit">提交</button></span>
                            <div style="float: right">
                                <a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" onclick="exportExcel();" style="margin-right: 35px; height: 19px; width: 50px;">导出
                                <iframe id="ExportIframe" class="J_iframe" name="iframe0" width="100%" height="100%" src="" frameborder="0" data-id="DownLoad.aspx"
                                    seamless="" style="display: none;"></iframe>
                                </a>
                            </div>
                        </div>
                        <div style="text-align: right; padding-right: 203px">
                            <span style="vertical-align: bottom; font-size: 16px;" id="resultDate"></span>
                        </div>

                    </div>

                    <%--<table class="contentCenter" id="contentCenter1">
                   <thead>
                    <tr>
                        <th class="wd73px" style="height:50px;width:130px">辖区项目部</th>
                        <th class="wd40px XH" data-class="XH">序号</th>
                        <th class="wd60px" data-class="BH">编号</th>
                        <th class="wd60px" data-class="YQ">仪器</th>
                        <th class="wd60px" data-class="JH">井号</th>
                        <th class="wd60px" data-class="LJDH">录井队号</th>
                        <th class="wd60px" data-class="SGDH">施工队号</th>
                        <th class="wd60px" data-class="JDT">井动态</th>
                        <th class="wd60px" data-class="SJJS">设计井深<h3>m</h3></th>
                        <th class="wd60px" data-class="DRJS">当日井深<h3>m</h3></th>
                        <th class="wd60px" data-class="KZRQ">开钻日期</th>
                        <th class="wd60px" data-class="YJWJRQ">预计完井日期</th>
                        <th class="wd60px" data-class="LJHXJW">录井后续井位</th>
                        <th class="wd60px" data-class="LJHXZJDH">录井后续钻井队号</th>
                        <th class="wd60px" data-class="ZJDDT">钻井队动态</th>
                        <th class="wd60px" data-class="LJHXJW">录井后续井位</th>
                        <th class="wd60px" data-class="JB">井别</th>
                        <th class="wd60px" data-class="LS">隶属</th>
                        <th class="wd60px" data-class="ZT">状态</th>
                        <th class="wd120px" data-class="BZ">备注</th>
                    </tr>
                </thead> 
                 </table>--%>
                </div>
                <table class="layui-hide" id="test"></table>



                <%-- <div>
                  <div style="padding-top:20px;text-align:right">
                    <h1 style="text-align:center;font-family:'黑体'">克拉玛依录井工程公司生产运行表</h1>                
                </div>
                <div>
                    <div style="float:left;margin-right:20px">
                        <div style="width:100px;float:left;text-align:center">
                            <span>录井项目部</span>
                        </div>
                        <div style="float:left">
                            <select style="width:120px" v-on:change="changeXMB" v-model="XMBName">
                                <option value="" style="display:none">全部</option>
                                
                            </select>
                        </div>
                    </div>
                    <div>
                        <span>日期</span>
                        <input class="easyui-datebox" id="datecheckbox" style="width: 140px; height: 17px"  data-options="onSelect:onSelect" />
                         
                        <div style="float:right">
                            <a href="javascript:void(0)" class="easyui-linkbutton bx btnGetType" onclick="exportExcel();" style="margin-right:35px;height: 25px;
                width: 60px;">导出
                                <iframe id="ExportIframe" class="J_iframe" name="iframe0" width="100%" height="100%" src="" frameborder="0" data-id="DownLoad.aspx"
                                  seamless="" style="display:none;"></iframe>
                            </a>
                        </div>
                    </div>
                    <div style="text-align:right;padding-right:203px">
                        <span style="vertical-align:bottom;font-size: 16px;" id="resultDate"></span>
                    </div>

                </div>--%>

                <%--<form id ="ff" action="/" method="post">  
                <table id="contentCenter">
                <tbody>
                    <tr v-for="(val,index) in XMList">
                        <td class="wd73px" >
                            <ul>
                                <li style="border-bottom:none">
                                    <input class="QKTitle" type="text" name="" :value="val.XQXMB"/>
                                </li>
                            </ul>
                        </td>
                        <td class="wd40px XH" >
                            <ul >
                                <li v-for="(val1,index1) in val.ItemList" data-class="XH">
                                    <input type="text" name="name" :value="++index1" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="BH">
                                    <input type="text" name="name" :value="val1.DWZBH" :title="val1.DWZBH" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="YQ">
                                    <input type="text" name="name" :value="val1.LJYQXH" :title="val1.LJYQXH" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="JH">
                                    <input type="text" name="name" :value="val1.ZJH" :title="val1.ZJH" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="LJDH">
                                    <input type="text" name="name" :value="val1.LJDH" :title="val1.LJDH" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="SGDH">
                                    <input type="text" name="name" :value="val1.SGDH" :title="val1.SGDH"/>
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="JDT">
                                    <input type="text" name="name" :value="val1.XDT" :title="val1.XDT" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="SJJS">
                                    <input type="text" name="name" :value="val1.SJJS" :title="val1.SJJS" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="DRJS">
                                    <input type="text" name="name" :value="val1.DRJS" :title="val1.DRJS" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="KZRQ">
                                    <input type="text" name="name" :value="val1.KZRQ" :title="val1.KZRQ" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="YJWJRQ">
                                    <input type="text" name="name" :value="val1.YJWJRQ" :title="val1.YJWJRQ" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="LJHXJW">
                                    <input type="text" name="name" :value="val1.HXJW" :title="val1.HXJW" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="LJHXZJDH">
                                    <input type="text" name="name" :value="val1.HXJDH" :title="val1.HXJDH" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="ZJDDT">
                                    <input type="text" name="name" :value="val1.JDDT" :title="val1.JDDT" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="LJHXJW">
                                    <input type="text" name="name" :value="val1.HXJW" title="'测试：123" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="JB">
                                    <input type="text" name="name" :value="val1.JB" :title="val1.JB" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="LS">
                                    <input type="text" name="name" :value="val1.LSDW" :title="val1.LSDW" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd60px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="ZT">
                                    <input type="text" name="name" :value="val1.DQZT" :title="val1.DQZT" />
                                </li>
                            </ul>
                        </td>
                        <td class="wd120px" >
                            <ul>
                                <li v-for="(val1,index1) in val.ItemList" data-class="BZ">
                                    <input type="text" name="name" :value="val1.BZ" :title="val1.BZ" />
                                </li>
                            </ul>
                        </td>
                    </tr>
               
               
                </tbody>
            </table>
               
               
                </form>--%>
            </div>
        </div>
    </div>


    <script src="../../Scripts/layui/layui.js"></script>
    <script src="../../Scripts/LQZY/LQ_SCDT.js"></script>
    <script>
        

        $(function () {

          
            var SELECT_XMB = $("#SELECT_XMB");
            console.log(SELECT_XMB.text())
            SELECT_XMB.change(function () {
                var Qb = $("#Qb")
                Qb.css("display", "block");
                if ($("#SELECT_XMB option:selected").text() == "全部") {
                    Qb.css("display", "none")
                }
            })

        })
        window.onload = function () {
            SetCurrentTime();
            var a = $('#datecheckbox').datebox('getValue');          
            $('#resultDate').text(a)
           // var _this = this;
         //   console.log($('#datecheckbox').datebox('getValue'))
            $.ajax({
                type: "POST",
                url: "../../Controllers/SCDTController.ashx?action=SCDT_List",
                data: { LJFGS: '', Time: $('#datecheckbox').datebox('getValue') },
                dataType: "json",
                success: function (msg) {
                    console.log(msg)
                 
                    if (msg.data !== 'undefined' && msg.data !== null && msg.data !== '') {
                        var dataList = '';
                        dataList = { "code": msg.code, "count": msg.count, "msg": msg.msg, "data": msg.data }
                    }
                    layui.use('table', function () {
                        var table = layui.table;

                        table.render({
                            elem: '#test'
                            , data: dataList.data
                            , page: false
                            , limit: 999999
                            , width: $(document.body).width() - 100 + 'px'
                            , height: $(document.body).height() - 200 + 'px'
                            , cols: [[
                                  { field: 'XQXMB', width: 120, title: '辖区项目部', fixed: 'left' }
                                , { field: 'TROW', width: 100, title: '序号', fixed: 'left' }
                                , { field: 'DWZBH', width: 100, title: '编号', fixed: 'left' }
                                , { field: 'LJYQXH', width: 120, title: '仪器' }
                                , { field: 'ZJH', width: 100, title: '井号' }
                                , { field: 'LJDH', width: 100, title: '录井队号' }
                                , { field: 'SGDH', width: 100, title: '施工队号' }
                                , { field: 'XDT', width: 100, title: '井动态' }
                                , { field: 'SJJS', width: 100, title: '设计井深' }
                                , { field: 'DRJS', width: 100, title: '当日井深', }
                                , { field: 'KZRQ', width: 100, title: '开钻日期' }
                                , { field: 'YJWJRQ', width: 100, title: '预计完井日期' }
                                , { field: 'HXJW', width: 120, title: '录井后续井位' }
                                , { field: 'HXJDH', width: 100, title: '录井后续钻井队号' }
                                , { field: 'JDDT', width: 100, title: '钻井队动态' }
                                , { field: 'HXJW', width: 120, title: '钻井队后续井' }
                                , { field: 'REPORT_TYPE', width: 100, title: '井别' }
                                , { field: 'LJFGS', width: 100, title: '隶属' }
                                , { field: 'DQZT', width: 100, title: '状态' }
                                , { field: 'BZ', width: 100, title: '备注', fixed: 'right' }
                            ]]


                        });
                    });
                }
            })
        }
        //设置日期显示格式
        formatterDate = function (date) {

            var day = date.getDate() > 9 ? date.getDate() : "0" + date.getDate();

            var month = (date.getMonth() + 1) > 9 ? (date.getMonth() + 1) : "0"

                + (date.getMonth() + 1);

            return date.getFullYear() + '-' + month + '-' + day;

        }

        //设置日期为当前日期
        function SetCurrentTime() {
            //formatterDate(new Date())
            $('#datecheckbox').datebox('setValue', formatterDate(new Date()));
        }
        function onSelect(date) {
            var d = new Date(date);
            var da = d.getFullYear() + '-' + (d.getMonth() + 1) + '-' + d.getDate();
            $('#resultDate').text(da)
        }
       
    </script>
</body>
</html>
