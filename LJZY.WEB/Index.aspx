<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LJZY.WEB.Index" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>录井作业管理系统</title>
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["theme"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["icon"].ToString()%>" rel="stylesheet" type="text/css" />
    <link href="<%=System.Configuration.ConfigurationManager.AppSettings["demo"].ToString()%>" rel="stylesheet" type="text/css" />
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["jquery"].ToString()%>" type="text/javascript"></script>
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-min"].ToString()%>" type="text/javascript"></script>
    <script src="<%=System.Configuration.ConfigurationManager.AppSettings["easyui-zh_CN"].ToString()%>" type="text/javascript"></script>

    <link href="CSS/Index.css" rel="stylesheet" />
    <style>
        #topmenu .tabs-scroller-right {
            background: #E0ECFF url(Scripts/jquery-easyui-1.5.5.2/themes/default/images/tabs_icons.png) no-repeat -15px center;
        }

        #topmenu .tabs-scroller-left {
            background: #E0ECFF url(Scripts/jquery-easyui-1.5.5.2/themes/default/images/tabs_icons.png) no-repeat 1px center;
        }

        .ricon {
            background: #E0ECFF url(Scripts/jquery-easyui-1.5.5.2/themes/default/images/tabs_icons.png) no-repeat -15px center;
        }

        .lecon {
            background: #E0ECFF url(Scripts/jquery-easyui-1.5.5.2/themes/default/images/tabs_icons.png) no-repeat 1px center;
        }

        #topmenu .tabs-header, #topmenu .tabs {
            background: transparent;
        }

        #topmenulist li {
            float: left;
        }

            #topmenulist li a {
                display: inline-block;
                height: 33px;
                line-height: 33px;
                padding: 0 8px;
                cursor: pointer;
                font-weight: bold;
            }

            #topmenulist li:hover a {
                font-weight: bold;
                background: #BAD8FE;
            }

            #topmenulist li.active a {
                background: #1476C9;
                color: #fff;
                font-weight: bold;
            }
    </style>
</head>
<body id="container" class="easyui-layout">

    <div id="north" data-options="region:'north'" style="background: #e3efff; height: 83px">
        <%--<span style="margin-left: 10px">录井作业管理系统</span>--%>
        <form runat="server">
            <div id="TPback" style="background: url('Image/topbg.png'); position: relative; height: 83px; line-height: 24px; border: 1px solid #95B8E7; border-top-style: none; border-left-style: none; border-right-style: none" data-options="fit:true">
                <%--<img src="Image/KTSC.png" style="width: 100%; height: 100%" />--%>
                <div style="width: 100%; height: 83px; overflow: hidden;">
                    <img src="Image/KTSC01.png" style="width: 100%; height: 135%; margin: -15px 0 0 0" alt="Alternate Text" />
                </div>

                <%--<img src="Image/YT_jb.png" style="width:100%; height: 100%;margin:-15px 0 0 0" alt="Alternate Text" />--%>
                <div style="position: absolute; top: -9px; left: 10px; width: 65px; height: 65px; cursor: pointer;">
                    <img id="TPbackimg" src="Image/YT_logo.png" style="width: 100%; height: 100%" alt="Alternate Text" />
                </div>
                <img src="Image/title.png" alt="Alternate Text" style="position: absolute; top: 9px; left: 77px;" />
                <span style="position: absolute; top: 9px; left: 77px; display: inline-block; font-weight: bold; font-size: 26px; display: none">克拉玛依远程录井一体化信息平台</span>


                <%--<asp:Button type="button" ID="sigout" Style="position: absolute; right: 40px;" class="easyui-linkbutton c5 btnGetType btnIndex" runat="server" Text="退出" OnClick="sigout_Click" ></asp:Button>--%>

                <div id="topmenu" style="position: absolute; top: 50px; height: 33px; width: 100%; overflow: hidden">
                    <ul style="width: 100%; list-style: none; padding: 0; margin: 0" id="topmenulist">
                        <li class="active"><a>井位导航</a></li>
                        <li><a>单井设计</a></li>
                        <li><a>录井项目</a></li>
                        <li><a>工程进度</a></li>
                        <li><a>单井策划</a></li>
                        <li><a>单井应急预案</a></li>
                        <li><a>QSHE作业计划书</a></li>
                        <li><a>人员管理</a></li>
                        <li><a>设备管理</a></li>
                        <li><a>录前统计</a></li>
                    </ul>

                </div>

                <%--<div class="easyui-tabs"  id="topmenu"   >
                    <div class="easyui-linkbutton" data-options="plain:true" title="井位导航"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="单井设计"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="录井项目"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="工程进度"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="单井策划"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="单井应急预案"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="QSHE作业计划书"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="人员管理"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="设备管理"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="录前统计"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="材料管理"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="验收巡查与检查"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="文件传达"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="资料检查和验收"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="重点提示"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="卫星小站"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="录井综合统计"></div>
                    <div class="easyui-linkbutton" data-options="plain:true" title="信息资源集成"></div>
                </div>--%>

                <div style="position: absolute; right: 50px; width: 23px; height: 23px; top: 14px; cursor: pointer;">
                    <%--<asp:Image runat="server" ID="sigout" style='width: 100%; height: 100%;' alt="退出" ImageUrl="~/Image/out.png" OnClick="sigout_Click" ></asp:Image>--%>
                    <asp:ImageButton runat="server" ID="sigout" Style='width: 100%; height: 100%;' alt="退出" ImageUrl="~/Image/out.png" OnClick="sigout_Click" />
                    <asp:LinkButton runat="server" ID="logOut" Style="position: absolute; top: 0; right: -37px; width: 30px; cursor: pointer; text-decoration: none" OnClick="sigout_Click" ForeColor="Black">退出</asp:LinkButton>
                </div>

                <%--<button type="button" id="back" style="position: absolute; right: 100px" class="easyui-linkbutton c5 btnGetType btnIndex">返回</button>--%>
                <div style="position: absolute; right: 150px; width: 23px; height: 23px; top: 14px; cursor: pointer;" id="back">
                    <img style='width: 100%; height: 100%;' src="Image/ennter.png" alt="返回" />
                    <label style="text-decoration: none; position: absolute; top: 0; right: -37px; width: 30px; cursor: pointer;">返回</label>
                </div>

                <div style="position: absolute; right: 200px; top: 14px;">
                    <img src="Image/person.png" style="width: 23px; height: 23px; vertical-align: middle" />
                    <label id="USER">用户</label>
                </div>
            </div>
        </form>
        <%-- <div data-options="fit:true" style="padding: 4px 0">
            <button type="button" onclick="getType()" class="easyui-linkbutton c5 btnGetType btnIndex">录井作业</button>
            <button type="button" onclick="getType(this)" class="easyui-linkbutton c5 btnGetType btnIndex">
                <p style="display: none">LQ</p>
                录前管理</button>
            <button type="button" onclick="getType(this)" class="easyui-linkbutton c5 btnGetType btnIndex">
                <p style="display: none">LZ</p>
                录中管理</button>
        </div>--%>
    </div>
    <div data-options="region:'west',split:true" style="width: 200px; min-width: 163px;" title="菜单">
        <!--west开始-->
        <div class="easyui-panel" data-options="fit:true,border:false" id="tree" style="overflow-y: auto;">
            <ul class="easyui-tree" id="tt">
            </ul>
        </div>
    </div>
    <!--west结束-->
    <div data-options="region:'center',iconCls:'icon-ok'">
        <!--center开始-->
        <div id="tab" class="easyui-tabs" data-options="fit:true,border:false,plain:true" style="background: #e3efff;">
            <!--tab开始-->
            <!--tab结束-->
        </div>
    </div>
    <!--center结束-->
    <%-- <div data-options="region:'east',split:true,collapsed:true" style="width: 200px; margin-top: -12px; height: 500px; overflow-y: scroll" title="浏览历史">
        <!--east开始-->
        <ul id="his_list">
        </ul>
    </div>--%>
    <script src="Scripts/Admin/Index.js"></script>
    <script>

        var type = '';
        $(function () {
            UserInfo();
            getMenuList();
        });

        function UserInfo() {
            //var Url = "http://10.142.33.218:8015/login.html";
            var Url = "<%=System.Configuration.ConfigurationManager.AppSettings["loginUrl"].ToString()%>";
            $.ajax({
                type: 'post',
                url: '../../Controllers/IndexController.ashx?action=getUser',
                dataType: 'json',
                success: function (msg) {
                    //console.log(msg);
                    if (msg.USERNAME !== null) {
                        $('#USER').html(msg.USERNAME)
                    } else {

                        window.location.href = Url;
                    }
                },
                error: function (err) {

                    window.location.href = Url;
                }
            })
        }
        //$('#sigout').click(function () {
        //    $.ajax({
        //        type: 'post',
        //        url: '../../Controllers/LoginController.ashx?action=logOut',
        //        success: function (msg) {
        //            console.log(msg);
        //            if (msg.IsSuccess == 'true') {
        //                //var url = "http://10.142.33.218:8015/login.html"
        //                var url = "http://www.shiwensoft.com:8020/login.html"
        //                window.location.href = url;
        //            }
        //        }
        //    })

        //});

        //$('#back,#TPback').click(function () {
        //    //var url = "http://10.142.33.218:8015/showModule.html"
        //    var url = "http://www.shiwensoft.com:8020/showModule.html"
        //   // window.location.href = url;

        //});
        $('#back,#TPbackimg').click(function () {
            var url = "<%=System.Configuration.ConfigurationManager.AppSettings["showModule"].ToString()%>";
            //var url = "http://www.shiwensoft.com:8020/showModule.html"
            window.location.href = url;

        });
        function getType(e) {
            type = $(e).children().find("p").html();
            return getMenuList(type);
        }
        function getMenuList(type) {
            $('#tt').tree({
                //url: '../../Controllers/IndexController.ashx?action=MenuList&param=' + type + '',
                url: '../../Controllers/IndexController.ashx?action=getRoleMenu&param=' + type + '',
                loadFilter: function (rows) {
                    return convert(rows);
                }
            });
        }

        function convert(rows) {
            //console.log(rows);
            function exists(rows, parentId) {
                for (var i = 0; i < rows.length; i++) {
                    if (rows[i].MENUID == parentId)
                        return true;
                }
                return false;
            }

            var nodes = [];
            for (var i = 0; i < rows.length; i++) {
                var row = rows[i];
                if (!exists(rows, row.PID)) {
                    nodes.push({
                        id: row.MENUID,
                        text: row.NAME,
                        url: row.ADDRESS
                    });
                }
            }

            var toDo = [];
            for (var i = 0; i < nodes.length; i++) {
                toDo.push(nodes[i]);
            }
            while (toDo.length) {
                var node = toDo.shift();
                for (var i = 0; i < rows.length; i++) {
                    var row = rows[i];
                    if (row.PID == node.id) {
                        var child = { id: row.MENUID, text: row.NAME, url: row.ADDRESS };
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
                //console.log(node);
                var str = "";
                var parentAll = "";
                parentAll = node.text;
                parentAll = parentAll.replace(/\[[^\)]*\]/g, ""); //获得所需的节点文本
                var flag = ">";
                var parent = $('#tt').tree('getParent', node.target); //获取选中节点的父节点
                for (i = 0; i < 5; i++) { //可以视树的层级合理设置I
                    if (parent != null) {
                        parentAll = flag.concat(parentAll);
                        str = (parent.text).replace(/\[[^\)]*\]/g, "");
                        parentAll = (str).concat(parentAll);
                        var parent = $('#tt').tree('getParent', parent.target);
                    }
                }
                if (!node.children) {
                    showTab(node.url, parentAll, node.text);
                    histListADD(node.url, parentAll, node.text);
                }

            }
        });
        function adds() {
            var ht = parseFloat($("#north").css("height"));//98
            var htpback = parseFloat($("#TPback").css("height"));//60
            var h1 = parseFloat($("#topmenu").css("height"));//29
            var h2 = parseFloat($("#topmenu div").css("height"));//auto
            var hc = h2 - h1;


            $("#container").layout('panel', 'north').panel("resize", { height: ht + hc + 2 + "px" });
            $("#TPback").css("height", htpback + hc + "px");
            $("#topmenu").css("height", h1 + hc + "px");
            $("#container").layout("resize");
            $(".ricon").css("display", "block");


            //$('body').layout('resize');
        }
        $("#topmenulist").on("click", "li", function () {
            $(this).addClass("active").siblings().removeClass("active");
            var title = $(this).text();
            closeTabs();
            if (title == "井位导航") {
                showTab("Page/DJSJ/LQ_JWDH.aspx", "井位导航") 
            }
            if (title == "单井设计") {
                //addTabs("单井基础信息>单井设计>探井", "Page/DJSJ/LQ_DJSJ.aspx?type=1");
                //addTabs("单井基础信息>单井设计>评价井", "Page/DJSJ/LQ_DJSJ.aspx?type=2");
                //addTabs("单井基础信息>单井设计>开发井", "Page/DJSJ/LQ_DJSJ.aspx?type=3");
                showTab("Page/DJSJ/LQ_DJSJ.aspx?type=1", "单井基础信息>单井设计>探井")
                showTab("Page/DJSJ/LQ_DJSJ.aspx?type=2", "单井基础信息>单井设计>评价井")
                showTab("Page/DJSJ/LQ_DJSJ.aspx?type=3", "单井基础信息>单井设计>开发井")
            }
            if (title == "录井项目") {
                showTab("Page/DJSJ/LQ_LJXM.aspx?type=1", "单井基础信息>录井项目>探井")
                showTab("Page/DJSJ/LQ_LJXM.aspx?type=2", "单井基础信息>录井项目>评价井")
                showTab("Page/DJSJ/LQ_LJXM.aspx?type=3", "单井基础信息>录井项目>开发井")
            }
            if (title == "工程进度") {
                showTab("Page/DJSJ/LQ_GCJD.aspx?type=1", "单井基础信息>工程进度>探井")
                showTab("Page/DJSJ/LQ_GCJD.aspx?type=2", "单井基础信息>工程进度>评价井")
                showTab("Page/DJSJ/LQ_GCJD.aspx?type=3", "单井基础信息>工程进度>开发井")
            }
            if (title == "单井策划") {
                showTab("Page/DJSJ/LQ_DJCH.aspx", "单井策划")
            }
            if (title == "单井应急预案") {
                showTab("Page/DJSJ/LQ_DJYJYA.aspx", "单井应急预案")
            }
            if (title == "QSHE作业计划书") {
                showTab("Page/DJSJ/LQ_QSHE.aspx", "QSHE作业计划书")
            }
            if (title == "人员管理") {
                showTab("Page/DJSJ/LQ_RYSJK.aspx", "人员管理")
            }
            if (title == "设备管理") {
                showTab("Page/DJSJ/LQ_SB_ZHY.aspx", "设备管理>综合录井仪(气测)")
            }
            if (title == "录前统计") {
                showTab("Page/DJSJ/LQ_SCDT.aspx", "录前统计>生产动态")
            }
            //if (title == "完井卡片") {
            //    showTab("Page/DJSJ/Report1.aspx", "完井卡片")
            //}
        })
        //添加Tabs
        function addTabs(treeNode, dataurl) {

            $('#tab').tabs('select', treeNode.name);
            $('#tab').tabs('add', {
                title: treeNode.name,
                selected: true,
                content: "<iframe scrolling='auto' frameborder='0' src='"
                    + dataurl + "' style='width:100%;height:100%;padding:0px 3px 0px 3px;'/>",
                closable: true
            });
        }
        //关闭Tabs
        function closeTabs() {
            var allTabs = $("#tab").tabs('tabs');
            console.log(allTabs);
            var allTabtitle = [];
            $.each(allTabs, function (i, n) {
                var opt = $(n).panel('options');
                if (opt.closable)
                    allTabtitle.push(opt.title);
            });
            //var curTabTitle = title;
            for (var i = 0; i < allTabtitle.length; i++) {
                $('#tab').tabs('close', allTabtitle[i]);
            }

        }

        function loginOut() {

            PageMethods.sigout();
        }
       // $("#topmenu").tabs({
         //   selected:'',
        //    onSelect: function (title, index) {
         //       if (title == "井位导航") {
         //           showTab("Page/DJSJ/LQ_JWDH.aspx", "井位导航")
        //        }
        //        if (title == "单井策划") {
            //        showTab("Page/DJSJ/LQ_DJCH.aspx", "单井策划")
          //      }
         //      if (title == "单井应急预案") {
       //             showTab("Page/DJSJ/LQ_DJYJYA.aspx", "单井应急预案")
       //         }
      //         if (title == "QSHE作业计划书") {
       //             showTab("Page/DJSJ/LQ_QSHE.aspx", "QSHE作业计划书")
      //          }
     //          if (title == "人员管理") {
      //              showTab("Page/DJSJ/LQ_RYSJK.aspx", "人员管理")
     //           }
     //           $("#topmenu").tabs("unselect", index);
    //        }
  //      })
    </script>

</body>
</html>
