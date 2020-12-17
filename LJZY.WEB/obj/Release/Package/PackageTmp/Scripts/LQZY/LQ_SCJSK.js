$(function () {
    getKT();
    getPJ();
    getKF();
    getQT();

    DwCount();
    SgCount();
    wjList();
    jhBackList();
   
    
});



// #region ===勘探操作
var table_KT = '';

function getKT() {

    layui.use('table', function () {
        table_KT = layui.table;

        table_KT.render({
            elem: '#kt'
            , height: 255
            , url: '../../Controllers/SCPGController.ashx?action=JHList_DP'
            , id: 'ktList'
            , title: '勘探井'
            , where: {
                REPORT_TYPE: '探井'
            }
            , cols: [[
                { type: 'checkbox', width: 45 },
                { field: 'JH', title: '井号', event: 'setSign', width: 112 }
            ]]
            //, cols: [[
            //   { type: 'checkbox', width: 45 },
            //   { field: 'JH', title: '井号',  width: 130 }
            //]]
        });

        //监听单元格事件
        table_KT.on('tool(kt)', function (obj) {
            //console.log(obj);
            var data = obj.data;
            if (obj.event === 'setSign') {
                $('#file_JH').text(data.JH);
                $('#map_JH').text(data.JH);
                getMap(data.JH);
                getFile(data.JH);
                //console.log(obj);
                var tr = obj.tr; //获得当前行 tr 的DOM对象

                var tr1 = $("#react_JH2  tr")
                $.each(tr1, function (k, val) {
                    $(val).removeClass('layui-table-click');
                })

                var tr2 = $("#react_JH3  tr")
                $.each(tr2, function (k, val) {
                    $(val).removeClass('layui-table-click');
                })

                var tr3 = $("#react_JH4  tr")
                $.each(tr3, function (k, val) {
                    $(val).removeClass('layui-table-click');
                })
            }
        });


        //table_KT.on('row(kt)', function (obj) {
        //    console.log(obj);
        //    var data = obj.data;
        //    //if (obj.event === 'setSign') {
        //        $('#file_JH').text(data.JH);
        //        $('#map_JH').text(data.JH);
        //        getMap(data.JH);
        //        getFile(data.JH);
        //        console.log(obj);
        //        var tr = obj.tr; //获得当前行 tr 的DOM对象

        //    //}


        //});


    });

}

function LJCZ_KT(LJFGS) {
    var checkStatus = table_KT.checkStatus('ktList')
        , data = checkStatus.data;
    //layer.alert(JSON.stringify(data));
    var kt_list = JSON.stringify(data)

    $.ajax({
        type: 'post',
        url: "../../Controllers/SCPGController.ashx?action=SCPG_Insert",
        data: {
            'JHJson': kt_list,
            'LJFGS': LJFGS
        },
        dataType: 'json',
        async: false,
        success: function (msg) {
            //console.log(msg)
            if (msg.IsSuccess == "true") {
                $.messager.alert('提示', msg.Message);
                getKT();
                getQT();
                jhBackList();
            }
        }

    })
}

//#endregion 

// #region ===评价操作
var table_PJ = '';

function getPJ() {

    layui.use('table', function () {
        table_PJ = layui.table;

        table_PJ.render({
            elem: '#pj'
            , height: 255
            , url: '../../Controllers/SCPGController.ashx?action=JHList_DP'
            , id: 'pjList'
            , title: '油藏评价井'
            , where: {
                REPORT_TYPE: '评价井'
            }
            , cols: [[
                { type: 'checkbox', width: 45 },
                { field: 'JH', title: '井号', event: 'setSign', width: 112 }
            ]]
        });
        //监听单元格事件
        table_PJ.on('tool(pj)', function (obj) {
            //console.log(obj);
            var data = obj.data;
            if (obj.event === 'setSign') {
                $('#file_JH').text(data.JH);
                $('#map_JH').text(data.JH);
                getMap(data.JH);
                getFile(data.JH);
                //console.log(obj);
                var tr = obj.tr; //获得当前行 tr 的DOM对象

                var tr1 = $("#react_JH  tr")
                $.each(tr1, function (k, val) {
                    $(val).removeClass('layui-table-click');
                })

                var tr2 = $("#react_JH3  tr")
                $.each(tr2, function (k, val) {
                    $(val).removeClass('layui-table-click');
                })

                var tr3 = $("#react_JH4  tr")
                $.each(tr3, function (k, val) {
                    $(val).removeClass('layui-table-click');
                })
            }

        });
    });



}

function LJCZ_PJ(LJFGS) {
    var checkStatus = table_PJ.checkStatus('pjList')
        , data = checkStatus.data;
    //layer.alert(JSON.stringify(data));
    var pj_list = JSON.stringify(data)

    $.ajax({
        type: 'post',
        url: "../../Controllers/SCPGController.ashx?action=SCPG_Insert",
        data: {
            'JHJson': pj_list,
            'LJFGS': LJFGS
        },
        dataType: 'json',
        async: false,
        success: function (msg) {
            //console.log(msg)
            if (msg.IsSuccess == "true") {
                $.messager.alert('提示', msg.Message);
                getPJ();
                getQT();
                jhBackList();
            }
        }

    })
}
//#endregion 

// #region ===开发操作
var table_KF = '';

function getKF() {

    layui.use('table', function () {
        table_KF = layui.table;

        table_KF.render({
            elem: '#kf'
            , height: 255
            , url: '../../Controllers/SCPGController.ashx?action=JHList_DP'
            , id: 'kfList'
            , title: '开发井'
            , where: {
                REPORT_TYPE: '开发井'
            }
            , cols: [[
                { type: 'checkbox', width: 45 },
                { field: 'JH', title: '井号', event: 'setSign', width: 112 }
            ]]
        });
        //监听单元格事件
        table_KF.on('tool(kf)', function (obj) {
            //console.log(obj);
            var data = obj.data;
            if (obj.event === 'setSign') {
                $('#file_JH').text(data.JH);
                $('#map_JH').text(data.JH);
                getMap(data.JH);
                getFile(data.JH);

                var tr1 = $("#react_JH  tr")
                $.each(tr1, function (k, val) {
                    $(val).removeClass('layui-table-click');
                })

                var tr2 = $("#react_JH2  tr")
                $.each(tr2, function (k, val) {
                    $(val).removeClass('layui-table-click');
                })

                var tr3 = $("#react_JH4  tr")
                $.each(tr3, function (k, val) {
                    $(val).removeClass('layui-table-click');
                })
            }
        });
    });



}

function LJCZ_KF(LJFGS) {
    var checkStatus = table_KF.checkStatus('kfList')
        , data = checkStatus.data;
    //layer.alert(JSON.stringify(data));
    var kf_list = JSON.stringify(data)

    $.ajax({
        type: 'post',
        url: "../../Controllers/SCPGController.ashx?action=SCPG_Insert",
        data: {
            'JHJson': kf_list,
            'LJFGS': LJFGS
        },
        dataType: 'json',
        async: false,
        success: function (msg) {
            // console.log(msg)
            if (msg.IsSuccess == "true") {
                $.messager.alert('提示', msg.Message);
                getKF();
                getQT();
                jhBackList();
            }
        }

    })
}

//#endregion 

// #region ===其他操作
var table_QT = '';

function getQT() {

    layui.use('table', function () {
        table_QT = layui.table;

        table_QT.render({
            elem: '#qt'
            , height: 255
            , url: '../../Controllers/SCPGController.ashx?action=JHList_QT'
            , id: 'qtList'
            , title: '其他'
            , cols: [[
                { type: 'checkbox', width: 45 },
                { field: 'JH', title: '井号', event: 'setSign', width: 112 }
            ]]
        });
        //监听单元格事件
        table_QT.on('tool(qt)', function (obj) {
            //console.log(obj);
            var data = obj.data;
            if (obj.event === 'setSign') {
                $('#file_JH').text(data.JH);
                $('#map_JH').text(data.JH);
                getMap(data.JH);
                getFile(data.JH);

                var tr1 = $("#react_JH  tr")
                $.each(tr1, function (k, val) {
                    $(val).removeClass('layui-table-click');
                })

                var tr2 = $("#react_JH2  tr")
                $.each(tr2, function (k, val) {
                    $(val).removeClass('layui-table-click');
                })

                var tr3 = $("#react_JH3  tr")
                $.each(tr3, function (k, val) {
                    $(val).removeClass('layui-table-click');
                })
            }
        });
    });



}

function LJCZ_QT(TYPE) {
    var checkStatus = table_QT.checkStatus('qtList')
        , data = checkStatus.data;
    //layer.alert(JSON.stringify(data));
    var qt_list = JSON.stringify(data)

    $.ajax({
        type: 'post',
        url: "../../Controllers/SCPGController.ashx?action=QTPG_Del",
        data: {
            'REPORT_TYPE': TYPE,
            'JHJson': qt_list
        },
        dataType: 'json',
        async: false,
        success: function (msg) {
            // console.log(msg)
            if (msg.IsSuccess == "true") {
                $.messager.alert('提示', msg.Message);
                getKT();
                getPJ();
                getKF();
                getQT();
                jhBackList();
            } else {
                $.messager.alert('提示', msg.Message);
            }
        }

    })
}

//#endregion 


//#region ===队伍统计
function DwCount() {
    $.ajax({
        type: 'post',
        url: "../../Controllers/SCPGController.ashx?action=DWCountList",
        dataType: 'json',
        async: false,
        success: function (msg) {
             console.log(msg)
            var arr = [];
            var arr1 = {
                "Type": "动用",
                "firstItem": 0,
                "secondItem": 0,
                "thirdItem": 0,
                "zdItem": 0,
                "dlmItem": 0,
                "hwItem": 0,
                "otherItem": 0

            }
            if (msg.dy.length > 0) {


                $.each(msg.dy, function (key, val) {
                    arr1.Type = val.TYPE
                    if (val.LJFGS == "第一项目部") {
                        arr1.firstItem = val.TOTAL;
                    }
                    if (val.LJFGS == "第二项目部") {
                        arr1.secondItem = val.TOTAL;
                    }
                    if (val.LJFGS == "第三项目部") {
                        arr1.thirdItem = val.TOTAL;
                    }
                    if (val.LJFGS == "准东项目部") {
                        arr1.zdItem = val.TOTAL;
                    }
                    if (val.LJFGS == "塔里木项目部") {
                        arr1.dlmItem = val.TOTAL;
                    }
                    if (val.LJFGS == "海外项目部") {
                        arr1.hwItem = val.TOTAL;
                    }
                    if (val.LJFGS == "其他") {
                        arr1.otherItem = val.TOTAL;
                    }
                })
            } else {
                arr1 = {
                    "Type": "动用",
                    "firstItem": 0,
                    "secondItem": 0,
                    "thirdItem": 0,
                    "zdItem": 0,
                    "dlmItem": 0,
                    "hwItem": 0,
                    "otherItem": 0

                }
            }
            arr.push(JSON.parse(JSON.stringify(arr1)));
            if (msg.xz.length > 0) {
                $.each(msg.xz, function (key, val) {
                    arr1.Type = val.TYPE
                    if (val.LJFGS == "第一项目部") {
                        arr1.firstItem = val.TOTAL;
                    }
                    if (val.LJFGS == "第二项目部") {
                        arr1.secondItem = val.TOTAL;
                    }
                    if (val.LJFGS == "第三项目部") {
                        arr1.thirdItem = val.TOTAL;
                    }
                    if (val.LJFGS == "准东项目部") {
                        arr1.zdItem = val.TOTAL;
                    }
                    if (val.LJFGS == "塔里木项目部") {
                        arr1.dlmItem = val.TOTAL;
                    }
                    if (val.LJFGS == "海外项目部") {
                        arr1.hwItem = val.TOTAL;
                    }
                    if (val.LJFGS == "其他") {
                        arr1.otherItem = val.TOTAL;
                    }
                })
            } else {
                arr1 = {
                    "Type": "闲置",
                    "firstItem": 0,
                    "secondItem": 0,
                    "thirdItem": 0,
                    "zdItem": 0,
                    "dlmItem": 0,
                    "hwItem": 0,
                    "otherItem": 0

                }
            }
            arr.push(JSON.parse(JSON.stringify(arr1)));
            //console.log(arr);



            $('#item1').datagrid({
                loadMsg: '数据加载中......',
                //rownumbers: true,
                //singleSelect: true,
                autoRowHeight: false,

                //fitColumns: true,
                pageSize: 5,
                data: arr,
                //url: '../../Controllers/LJXMController.ashx?action=LJXMDataGrid',
                //queryParams: { "JB": pageJB },
                //remoteSort: false,
                // method: 'post',
                onLoadSuccess: function (data) {
                    // console.log(data)

                },

                columns: [[{ field: 'Type', align: 'center', width: 80, title: '类别' },
                { field: 'firstItem', align: 'center', width: 100, title: '第一项目部' },
                { field: 'secondItem', align: 'center', width: 100, title: '第二项目部' },
                { field: 'thirdItem', align: 'center', width: 100, title: '第三项目部' },
                { field: 'zdItem', align: 'center', width: 100, title: '准东项目部' },
                { field: 'dlmItem', align: 'center', width: 100, title: '塔里木项目部' },
                { field: 'hwItem', align: 'center', width: 100, title: '海外项目部' },
                { field: 'otherItem', align: 'center', width: 100, title: '其他' }
                ]]
            });
        }

    })
}

//#endregion 

//#region ===施工统计
function SgCount() {
    $.ajax({
        type: 'post',
        url: "../../Controllers/SCPGController.ashx?action=SGCountList",
        dataType: 'json',
        async: false,
        success: function (msg) {
            //console.log(msg)
            var arr = [];
            var arr1 = {
                "Type": "正钻",
                "firstItem": 0,
                "secondItem": 0,
                "thirdItem": 0,
                "zdItem": 0,
                "dlmItem": 0,
                "hwItem": 0,
                "otherItem": 0
            }
            if (msg.zz.length > 0) {


                $.each(msg.zz, function (key, val) {
                    arr1.Type = val.TYPE
                    if (val.LJFGS == "第一项目部") {
                        arr1.firstItem = val.TOTAL;
                    }
                    if (val.LJFGS == "第二项目部") {
                        arr1.secondItem = val.TOTAL;
                    }
                    if (val.LJFGS == "第三项目部") {
                        arr1.thirdItem = val.TOTAL;
                    }
                    if (val.LJFGS == "准东项目部") {
                        arr1.zdItem = val.TOTAL;
                    }
                    if (val.LJFGS == "塔里木项目部") {
                        arr1.dlmItem = val.TOTAL;
                    }
                    if (val.LJFGS == "海外项目部") {
                        arr1.hwItem = val.TOTAL;
                    }
                    if (val.LJFGS == "其他") {
                        arr1.otherItem = val.TOTAL;
                    }
                })
            } else {
                arr1 = {
                    "Type": "正钻",
                    "firstItem": 0,
                    "secondItem": 0,
                    "thirdItem": 0,
                    "zdItem": 0,
                    "dlmItem": 0,
                    "hwItem": 0,
                    "otherItem": 0
                }
            }
            arr.push(JSON.parse(JSON.stringify(arr1)));
            if (msg.wz.length > 0) {
                $.each(msg.wz, function (key, val) {
                    arr1.Type = val.TYPE
                    if (val.LJFGS == "第一项目部") {
                        arr1.firstItem = val.TOTAL;
                    }
                    if (val.LJFGS == "第二项目部") {
                        arr1.secondItem = val.TOTAL;
                    }
                    if (val.LJFGS == "第三项目部") {
                        arr1.thirdItem = val.TOTAL;
                    }
                    if (val.LJFGS == "准东项目部") {
                        arr1.zdItem = val.TOTAL;
                    }
                    if (val.LJFGS == "塔里木项目部") {
                        arr1.dlmItem = val.TOTAL;
                    }
                    if (val.LJFGS == "海外项目部") {
                        arr1.hwItem = val.TOTAL;
                    }
                    if (val.LJFGS == "其他") {
                        arr1.otherItem = val.TOTAL;
                    }
                })
            } else {
                arr1 = {
                    "Type": "完钻",
                    "firstItem": 0,
                    "secondItem": 0,
                    "thirdItem": 0,
                    "zdItem": 0,
                    "dlmItem": 0,
                    "hwItem": 0,
                    "otherItem": 0
                }
            }
            arr.push(JSON.parse(JSON.stringify(arr1)));
            //console.log(arr);



            $('#item2').datagrid({
                loadMsg: '数据加载中......',
                //rownumbers: true,
                //singleSelect: true,
                autoRowHeight: false,

                //fitColumns: true,
                pageSize: 5,
                data: arr,
                //url: '../../Controllers/LJXMController.ashx?action=LJXMDataGrid',
                //queryParams: { "JB": pageJB },
                //remoteSort: false,
                // method: 'post',
                onLoadSuccess: function (data) {
                    // console.log(data)

                },

                columns: [[{ field: 'Type', align: 'center', width: 80, title: '类别' },
                { field: 'firstItem', align: 'center', width: 100, title: '第一项目部' },
                { field: 'secondItem', align: 'center', width: 100, title: '第二项目部' },
                { field: 'thirdItem', align: 'center', width: 100, title: '第三项目部' },
                { field: 'zdItem', align: 'center', width: 100, title: '准东项目部' },
                { field: 'dlmItem', align: 'center', width: 100, title: '塔里木项目部' },
                { field: 'hwItem', align: 'center', width: 100, title: '海外项目部' },
                { field: 'otherItem', align: 'center', width: 100, title: '其他' }
                ]]
            });
        }

    })
}

//#endregion 

//#region ===完井列表
function wjList() {
    $.ajax({
        type: 'post',
        url: "../../Controllers/SCPGController.ashx?action=WJList",
        dataType: 'json',
        async: false,
        success: function (msg) {
            //console.log(msg)

            $('#item3').datagrid({
                loadMsg: '数据加载中......',
                autoRowHeight: false,
                pageSize: 5,
                data: msg.list,
                onLoadSuccess: function (data) {
                    //console.log(data)

                },

                columns: [[
                    { field: 'TROW', align: 'center', width: 80, title: '序号'},
                    { field: 'LJFGS', align: 'center', width: 100, title: '录井项目部' , fixed: true},
                    { field: 'JH', align: 'center', width: 100, title: '井号' },
                    { field: 'LJDH', align: 'center', width: 100, title: '录井队号' },
                    { field: 'SGDH', align: 'center', width: 100, title: '施工队号' },
                    { field: 'YJWJRQ', align: 'center', width: 100, title: '预计完井日期', fixed: true }
                ]]
            });
        }

    })
}

//#endregion 

//#region =====共用方法====
function getFile(JH) {
    $.ajax({
        type: "POST",
        url: "../../Controllers/FilesController.ashx?action=FileInfoByJH",
        data: {
            'JH': JH,
        },
        dataType: 'json',
        async: false,
        success: function (msg) {
            //console.log(msg);
            if (msg.FileName != "" && msg.FileName != null) {
                if (msg.View == 1) {

                    var fhtml = '<iframe width="100%" height="98%" src="' + msg.FileURL + '" frameborder="0" id="fileList_iframe" seamless=""></iframe>'
                    $("#fileList").html(fhtml);
                } else {

                    var fhtml = ' <span class="filename" title="' + msg.FileName + '">' + msg.FileName + '</span><a href="' + msg.FileURL + '" class="layui-btn layui-btn-primary layui-btn-xs" download="">下载</a>'
                    $("#fileList").html(fhtml);
                }

            } else {
                var fhtml = "<span>暂无上传文件</span>"
                $("#fileList").html(fhtml);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });

}


function getMap(JH) {
     
    $.ajax({
        type: "POST",
        url: "../../Controllers/MapController.ashx?action=MapListByJH",
        data: {
            'JH': JH,
        },
        dataType: 'json',
        async: false,
        success: function (msg) {
            markerArr = "";
            if (msg.IsSuccess == "true") {
                markerArr = msg.Data; 
            } 
            setMarkerArr(markerArr);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });

     
     
}
//#endregion 



function jumptourl(e) {
    if (e == "人员设备统计") {
        showTab("Page/DJSJ/LQ_RYSB.aspx", "录前统计>人员设备")
    }
    if (e == "生产动态统计") {
        showTab("Page/DJSJ/LQ_SCDT.aspx", "录前统计>生产动态")
    }
}


//动态添加标签页
function showTab(url, parentAll, title) {
    var tab = window.parent.$('#tab');
    if (tab.tabs('exists', parentAll)) {
        tab.tabs('select', parentAll);
    }
    else {
        tab.tabs('add', {
            title: parentAll,
            content: "<iframe scrolling='auto' frameborder='0' src='"
                + url + "' style='width:100%;height:100%;padding:0px 3px 0px 3px;'/>",
            closable: true,
            tools: [{
                iconCls: 'icon-mini-refresh',
                handler: function () {
                    var selectTab = $('#tab').tabs('getSelected');
                    tab.tabs('update', {
                        tab: selectTab,
                        options: {
                            href: url
                        }
                    })
                }
            }]

        });

    }
}

//分配井号列表 
function jhBackList() {
    $.ajax({
        type: "POST",
        url: "../../Controllers/SCPGController.ashx?action=JHList_XMBPG",
        dataType: 'json',
        async: false,
        success: function (msg) {
            // console.log(msg);
            //#region 第一项目部
            var dyxmb_kt = msg.DYXMB.KTJ_List;
            if (dyxmb_kt.length > 0) {
                setTobody('dyxmb_kt', dyxmb_kt);
            }
            var dyxmb_pj = msg.DYXMB.PJJ_List;
            if (dyxmb_pj.length > 0) {
                setTobody('dyxmb_pj', dyxmb_pj);
            }
            var dyxmb_kf = msg.DYXMB.KFJ_List;
            if (dyxmb_kf.length > 0) {
                setTobody('dyxmb_kf', dyxmb_kf);
            }
            //#endregion 

            //#region 第二项目部
            var dexmb_kt = msg.DEXMB.KTJ_List;
            if (dexmb_kt.length > 0) {
                setTobody('dexmb_kt', dexmb_kt);
            }
            var dexmb_pj = msg.DEXMB.PJJ_List;
            if (dexmb_pj.length > 0) {
                setTobody('dexmb_pj', dexmb_pj);
            }
            var dexmb_kf = msg.DEXMB.KFJ_List;
            if (dexmb_kf.length > 0) {
                setTobody('dexmb_kf', dexmb_kf);
            }
            //#endregion 

            //#region 第三项目部
            var dsxmb_kt = msg.DSXMB.KTJ_List;
            if (dsxmb_kt.length > 0) {
                setTobody('dsxmb_kt', dsxmb_kt);
            }
            var dsxmb_pj = msg.DSXMB.PJJ_List;
            if (dsxmb_pj.length > 0) {
                setTobody('dsxmb_pj', dsxmb_pj);
            }
            var dsxmb_kf = msg.DSXMB.KFJ_List;
            if (dsxmb_kf.length > 0) {
                setTobody('dsxmb_kf', dsxmb_kf);
            }
            //#endregion 

            //#region 准东项目部
            var zdxmb_kt = msg.ZDXMB.KTJ_List;
            if (zdxmb_kt.length > 0) {
                setTobody('zdxmb_kt', zdxmb_kt);
            }
            var zdxmb_pj = msg.ZDXMB.PJJ_List;
            if (zdxmb_pj.length > 0) {
                setTobody('zdxmb_pj', zdxmb_pj);
            }
            var zdxmb_kf = msg.ZDXMB.KFJ_List;
            if (zdxmb_kf.length > 0) {
                setTobody('zdxmb_kf', zdxmb_kf);
            }
            //#endregion 

            //#region 塔里木项目部
            var tlmxmb_kt = msg.TLMXMB.KTJ_List;
            if (tlmxmb_kt.length > 0) {
                setTobody('tlmxmb_kt', tlmxmb_kt);
            }
            var tlmxmb_pj = msg.TLMXMB.PJJ_List;
            if (tlmxmb_pj.length > 0) {
                setTobody('tlmxmb_pj', tlmxmb_pj);
            }
            var tlmxmb_kf = msg.TLMXMB.KFJ_List;
            if (tlmxmb_kf.length > 0) {
                setTobody('tlmxmb_kf', tlmxmb_kf);
            }
            //#endregion 

            //#region 海外项目部
            var hwxmb_kt = msg.HWXMB.KTJ_List;
            if (hwxmb_kt.length > 0) {
                setTobody('hwxmb_kt', hwxmb_kt);
            }
            var hwxmb_pj = msg.HWXMB.PJJ_List;
            if (hwxmb_pj.length > 0) {
                setTobody('hwxmb_pj', hwxmb_pj);
            }
            var hwxmb_kf = msg.HWXMB.KFJ_List;
            if (hwxmb_kf.length > 0) {
                setTobody('hwxmb_kf', hwxmb_kf);
            }
            //#endregion 
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {

        }
    });
}

//生成li标签
function setTobody(ulName, data) {
    var Content = '';
    for (var i = 0; i < data.length; i++) {
        Content += '<li><input type="checkbox" name= "' + ulName + '" value= "' + data[i].JH + '" /><span>' + data[i].JH + '</span></li>';
    }
    //console.log(Content);
    $('#' + ulName + '').html(Content);
}

//根据li name获取多选值
function li_check(liName) {
    //var c = $("#dyxmb_kt input:checked");
    var obj = document.getElementsByName(liName);
    var arr = [];
    for (k in obj) {
        if (obj[k].checked)
            arr.push(obj[k].value);
    }
    if (arr.length > 0) {
        $.ajax({
            type: "POST",
            url: "../../Controllers/SCPGController.ashx?action=SCPG_Del",
            dataType: 'json',
            data: {
                'JHJson': JSON.stringify(arr),
            },
            async: false,
            success: function (msg) {
                if (msg.IsSuccess == "true") {
                    $.messager.alert('提示', msg.Message);
                    getKT();
                    getPJ();
                    getKF();
                    jhBackList();
                }

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {

            }
        });
    } else {
        $.messager.alert('提示', '请选择井号!');
    }

}


//地图创建
var map = new BMap.Map(); //初始化时默认使用混合地图
var Point = new Array(); //存放标注点经纬信息的数组
var markerArr = "";
var opts = {
    width: 100,     // 信息窗口宽度
    height: 300,     // 信息窗口高度
    title: "<font>提示信息:</font>", // 信息窗口标题
    //enableMessage: true,//设置允许信息窗发送短息
    //message: " "
}

//生成地图标注
function setMarkerArr(markerArr) {
    map = new BMap.Map("map", {
        mapType: BMAP_HYBRID_MAP,
        minZoom: 5,
        maxZoom: 10
    }); //初始化时默认使用混合地图
    map.centerAndZoom(Point, 15); // 初始化地图,设置中心点坐标和地图级别。
    map.enableScrollWheelZoom(true); //启用滚轮放大缩小
    //地图、卫星、混合模式切换
    //map.addControl(new BMap.MapTypeControl({
    //    mapTypes: [BMAP_NORMAL_MAP, BMAP_SATELLITE_MAP,
    //            BMAP_HYBRID_MAP]
    //}));
    //向地图中添加缩放控件
    var ctrlNav = new window.BMap.NavigationControl({
        anchor: BMAP_ANCHOR_TOP_LEFT,
        type: BMAP_NAVIGATION_CONTROL_LARGE
    });
    map.addControl(ctrlNav);
    //向地图中添加缩略图控件
    var ctrlOve = new window.BMap.OverviewMapControl({
        anchor: BMAP_ANCHOR_BOTTOM_RIGHT,
        isOpen: 1
    });
    map.addControl(ctrlOve);
    //向地图中添加比例尺控件
    var ctrlSca = new window.BMap.ScaleControl({
        anchor: BMAP_ANCHOR_BOTTOM_LEFT
    });
    map.addControl(ctrlSca);
    if (markerArr.length > 0) {
        for (var i = 0; i < markerArr.length; i++) {
            var p0 = markerArr[i].Point.split(",")[0]; //
            var p1 = markerArr[i].Point.split(",")[1]; //按照原数组的Point格式将地图点坐标的经纬度分别提出来  
            var Js = parseInt(markerArr[i].DRJS)
            if (Js > 0) {
                var marker = new BMap.Marker(new BMap.Point(p0, p1), { icon: new BMap.Icon("../../images/red.png", new BMap.Size(32, 37)), title: markerArr[i].JH });  // 创建标注
            } else {
                var marker = new BMap.Marker(new BMap.Point(p0, p1), { icon: new BMap.Icon("../../images/blue.png", new BMap.Size(32, 37)), title: markerArr[i].JH });  // 创建标注
            }

            var XM = "";
            var LXDH = "";
            if (markerArr[i].RyList.length > 0) {
                XM = markerArr[i].RyList[0].XM
                LXDH = markerArr[i].RyList[0].LXDH
            }
            var content = "<p style='font-size: 2px; height: 10px'>井号:" + markerArr[i].JH + "</p><p style='font-size: 2px; height: 10px'>当前状态:" + markerArr[i].JFL + "</p><p style='font-size: 2px; height: 10px'>录井小队:" + markerArr[i].LJDH + "</p><p style='font-size: 2px; height: 10px'>设计井深:" + markerArr[i].SJJS + "</p><p style='font-size: 2px; height: 10px'>当前井深:" + markerArr[i].DRJS + "</p><p style='font-size: 2px; height: 10px'>地质工程师:" + XM + "</p><p style='font-size: 2px; height: 10px'>联系电话:" + LXDH + "</p><p style='font-size: 2px; height: 10px'>施工队号:" + markerArr[i].SGDH + "</p><p style='font-size: 2px; height: 10px'>施工队电话:" + markerArr[i].SGDDH + "</p><p style='font-size: 2px; height: 10px'>已装卫星:" + markerArr[i].STARTS + "</p>";  // 创建信息窗口对象 

            map.addOverlay(marker);               // 将标注添加到地图中
            addClickHandler(content, marker);

            var label = new window.BMap.Label(markerArr[i].JH, {
                offset: new window.BMap.Size(25, 5)
            });
            marker.setLabel(label);
            var Points = new BMap.Point(p0, p1); //地图中心点
            map.centerAndZoom(Points, 10); // 初始化地图,设置中心点坐标和地图级别。

        }
    } else {
        var Points = new BMap.Point(85.370223330779, 45.6978600780269); //地图中心点
        map.centerAndZoom(Points, 10); // 初始化地图,设置中心点坐标和地图级别。
    }
}

function addClickHandler(content, marker) {
    marker.addEventListener("click", function (e) {
        openInfo(content, e)
    }
    );
}
function openInfo(content, e) {
    var p = e.target;
    var point = new BMap.Point(p.getPosition().lng, p.getPosition().lat);
    var infoWindow = new BMap.InfoWindow(content, opts);  // 创建信息窗口对象 
    map.openInfoWindow(infoWindow, point); //开启信息窗口
}