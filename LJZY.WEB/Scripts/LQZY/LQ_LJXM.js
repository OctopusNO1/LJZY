//全局变量
var pageJB = '';
var rydata = new Array();
//页面加载-------------
$(function () {
    PreviewImport();
    //===判断页面井别
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
    //treeList();
    getDJSJ();
    //selectNode();
    //JH_List();
    loadRemote_Home();
    getWorkersPB();
    //   RYPB()
    // getWorkerL1()
    //aaa();
    aaa();
    bbb();
    getDZF();
    getZF();
    getKF();
    //getKJ();
    showDG();
    $('#accordion').accordion('getSelected').panel('collapse');



});
//window.onload = function () {
//    aaa();
//    bbb();
//    getDZF();
//    getZF()
//    getKF()
//    getKJ()
//    //getWorker();
//}

function Trim(str) {
    return str.replace(/(^\s*)|(\s*$)/g, "");
}

function showDG() {



    $('#dg').datagrid({
        loadMsg: '数据加载中......',
        fitColumns: false,
        fit: true,
        rownumbers: true,
        singleSelect: true,
        autoRowHeight: false,
        pagination: true,
        pageSize: 30,
        url: '../../Controllers/LJXMController.ashx?action=LJXMDataGrid',
        queryParams: { "REPORT_TYPE": pageJB },
        remoteSort: true,
        method: 'post',
        //onClickCell: onClickCell,
        //onLoadSuccess: function (data) {
        //    console.log(data)

        //},

        //columns: [[{ field: 'SC3', align: 'center', width: 160, sortable: true, title: '甲方单位' },
        //    { field: 'SC2', align: 'center', width: 80, sortable: true, title: '地区' },
        //    { field: 'QK', align: 'center', width: 80, sortable: true, title: '区块' },
        //    { field: 'ZJH', align: 'center', width: 80, sortable: true, title: '井号' },
        //    { field: 'REPORT_TYPE', align: 'center', width: 60, sortable: true, title: '井别' },
        //    { field: 'JH', align: 'center', width: 80, sortable: true, title: '井筒号' },
        //    { field: 'LJXL', align: 'center', width: 80, sortable: true, title: '录井系列' },
        //    { field: 'SJJS', align: 'center', width: 80, sortable: true, title: '设计井深' },
        //    { field: 'JSSJJS', align: 'center', width: 120, sortable: true, title: '加深设计井深' },
        //    { field: 'SCFL', align: 'center', width: 120, sortable: true, title: '市场类型' },
        //    { field: 'GJ', align: 'center', width: 80, hidden: true, sortable: true, title: '国家' },
        //    { field: 'SC1', align: 'center', width: 120, hidden: true, sortable: true, title: '一级市场' },
        //    { field: 'DZJDXM', align: 'center', width: 120, hidden: true, sortable: true, title: '地质监督姓名' },
        //    { field: 'DZJDZJH', align: 'center', width: 120, hidden: true, sortable: true, title: '地质监督证件号' },
        //    { field: 'DZJDSSGS', align: 'center', width: 120, hidden: true, sortable: true, title: '地质监督所属公司' },
        //    { field: 'ZJJDXM', align: 'center', width: 120, hidden: true, sortable: true, title: '钻井监督姓名' },
        //    { field: 'ZJJDZJH', align: 'center', width: 120, hidden: true, sortable: true, title: '钻井监督证件号' },
        //    { field: 'ZJJDSSGS', align: 'center', width: 120, hidden: true, sortable: true, title: '钻井监督所属公司' },
        //    { field: 'LJFGS', align: 'center', width: 120, hidden: true, sortable: true, title: '录井项目部' },
        //    { field: 'LJDWZZ', align: 'center', width: 120, hidden: true, sortable: true, title: '录井资质' },
        //    { field: 'LJDH', align: 'center', width: 120, hidden: true, sortable: true, title: '录井队号' },
        //    { field: 'LJYQXH', align: 'center', width: 120, hidden: true, sortable: true, title: '设备型号' },
        //    { field: 'YQZZ', align: 'center', width: 120, hidden: true, sortable: true, title: '仪器资质' },
        //    { field: 'DWZBH', align: 'center', width: 120, hidden: true, sortable: true, title: '队伍自编号' },
        //    { field: 'DZS', width: 120, align: 'center', hidden: true, sortable: true, title: '地质师' },
        //    { field: 'STARSTART_DG', align: 'center', width: 120, hidden: true, sortable: true, title: '装卫星时间' },
        //    { field: 'STARAZR', align: 'center', width: 120, hidden: true, sortable: true, title: '安装卫星人' },
        //    { field: 'STAREND_DG', align: 'center', width: 120, hidden: true, sortable: true, title: '拆卫星时间' },
        //    { field: 'STARCCR', align: 'center', width: 120, hidden: true, sortable: true, title: '拆卫星人' },
        //    { field: 'SGDW', align: 'center', width: 160, hidden: true, sortable: true, title: '施工单位' },
        //    { field: 'SGDH', align: 'center', width: 120, hidden: true, sortable: true, title: '施工队号' },
        //    { field: 'YJBASJ_DG', align: 'center', width: 120, hidden: true, sortable: true, title: '预计搬安时间' },
        //    { field: 'SJBASJ_DG', align: 'center', width: 120, hidden: true, sortable: true, title: '实际搬安时间' },
        //    { field: 'BQJL', align: 'center', width: 120, hidden: true, sortable: true, title: '搬迁距离' },
        //    { field: 'HQSJ_DG', align: 'center', width: 120, hidden: true, sortable: true, title: '回迁时间' },
        //    { field: 'DQZT', align: 'center', width: 120, hidden: true, sortable: true, title: '当前状态' },
        //    { field: 'CHOUXIYOU', align: 'center', width: 120, hidden: true, sortable: true, title: '稠油/稀油' },
        //    { field: 'HXJW', align: 'center', width: 120, hidden: true, sortable: true, title: '后续井位' },
        //    { field: 'HXJDH', align: 'center', width: 120, hidden: true, sortable: true, title: '后续井队号' },
        //    { field: 'JDDT', align: 'center', width: 120, hidden: true, sortable: true, title: '井队动态' },
        //    { field: 'LSDW', align: 'center', width: 120, hidden: true, sortable: true, title: '隶属单位' },
        //    { field: 'XMBJWXX', align: 'center', width: 120, hidden: true, sortable: true, title: '项目部井位信息' },
        //    { field: 'PGZDTS', align: 'center', width: 120, hidden: true, sortable: true, title: '派工重点提示' },
        //    { field: 'DRJS', align: 'center', width: 120, hidden: true, sortable: true, title: '当前井深' },
        //    { field: 'SGZT', align: 'center', width: 120, hidden: true, sortable: true, title: '当前动态' },
        //    { field: 'BZ', align: 'center', width: 120, hidden: true, sortable: true, title: '备注' }
        //]]
    });

}







//===解析链接参数
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}

function addTJ() {
    var xstj_2 = $("#SelectColumn_List").combobox('getText');
    var tj_2 = $("#SelectColumn_List").combobox('getValue');
    var tj_3 = $("#Symbol_List").combobox('getValue');
    var tj_4 = $("#isvalue").val();
    if (tj_3 == "like") {
        tj_3 = " like "
        tj_4 = "'%" + Trim(tj_4) + "%'"
    }
    else {
        tj_4 = "'" + Trim(tj_4) + "'";
    }

    var html = '';
    var mark = " AND ";
    if ($("#chkbox").is(':checked')) {
        mark = " OR ";
    }
    if (xstj_2 != "" && tj_2 != "") {

        html += '<div class="groups"><span>' + mark + '</span><span>' + xstj_2 + '</span><span>' + tj_3 + '</span><span>' + tj_4 + '</span><img class="close" onclick="closetj(this)" src="../../Image/no.png"/><p style="display:none">' + tj_2 + '</p></div>';
        $("#SelectWhere").append(html);
    }

}

function closetj(e) {
    $(e).parent().remove();
}


function doSearch1() {
    str = "";
    var xstj_2 = $("#SelectColumn_List").combobox('getText');
    var tj_2 = $("#SelectColumn_List").combobox('getValue');
    var tj_3 = $("#Symbol_List").combobox('getValue');
    var tj_4 = $("#isvalue").val();
    if (tj_3 == "like") {
        tj_3 = " like "
        tj_4 = "'%" + Trim(tj_4) + "%'"
    }
    else {
        tj_4 = "'" + Trim(tj_4) + "'";
    }

    var mark = " AND ";
    if ($("#chkbox").is(':checked')) {
        mark = " OR ";
    }
    if (xstj_2 != "" && tj_2 != "" && tj_4 != "''") {
        str = " " + mark + " " + tj_2 + " " + tj_3 + " " + tj_4 + "";
    }
    if ($('#SelectWhere').children().length > 0) {
        $('#SelectWhere').children().each(function () {
            console.log($(this));
            str += $(this).find("span").eq(0).html() + $(this).find("p").html() + $(this).find("span").eq(2).html() + $(this).find("span").eq(3).html();
        })
        console.log(str);
    }

    $('#dg').datagrid('load', {
        "strWhere": str,
        "REPORT_TYPE": pageJB
    });
    $('#dg').datagrid('reload');
}
//-------------输入井号获取表单数据
function ZJHChange() {
    $('#txtZJH').textbox({
        onChange: function () {
            var ZJH = $("#txtZJH").textbox('getValue');//井号框的值

            $("#txtJH").textbox('setValue', ZJH);
            $.ajax({
                type: "POST",
                url: "../../Controllers/LJXMController.ashx?action=LJXMInfoByZJH",
                data: {
                    "ZJH": ZJH
                },
                dataType: 'json',
                async: false,
                success: function (data) {
                    console.log(data)
                    if (data.ZJH != null) {
                        $('#ff').form('load', data);
                    }
                    aaa();

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(errorThrown);
                }
            });
        }
    })
}
//---------回车井号光标调到井筒号
function ZJH_enterToTab() {
    var t = $('#txtZJH');
    t.textbox('textbox').bind('keydown', function (e) {
        if (e.keyCode == 13) {
            $('#txtJH').next('span').find('input').focus();
        }
    });
}

//保存--------------------
function submitForm() {
    $('#ff').form('submit', {
        url: '../../Controllers/LJXMController.ashx?action=LJXM_Save',
        //onSubmit: function () {        //表单提交前的回调函数 
        //    return $(this).form('enableValidation').form('validate');
        //},
        success: function (data) {  //表单提交成功后的回调函数，里面参数data是我们调用/BasicClass/ModifyClassInfo方法的返回值。 
            console.log(data);
            var data = JSON.parse(data);
            console.log(typeof (data))
            if (data.IsSuccess == true) {
                $.messager.show({
                    title: '提示消息',
                    msg: data.Message,
                    showType: 'show',
                    timeout: 1000
                });
                $('#Editwin').window('close'); //关闭窗口 
            }
            else {
                $.messager.alert('提示信息', data.Message, 'warning');
            }
            //loadRemote_Home();  // 重新载入当前页面数据 
            $("#dg").datagrid('reload');
        }
    });
}

////二级目录菜单--------------
//function treeList() {
//    $('#tt').tree({
//        url: '../../Controllers/ColumnListController.ashx?action=EJML_List',
//        loadFilter: function (rows) {
//            return convert(rows);
//        }
//    });
//}



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
////二级目录菜单节点选择------------------
//function selectNode() {
//    $('#tt').tree({
//        onClick: function (node) {
//            $('#treeVal').html(node.text);
//            clearForm();
//            loadRemote_Home();
//            JH_List();
//            //getDesignUp();
//            console.log(node);
//            if (!node.children) {
//                $('#dg').datagrid('load', {
//                    strTree: $('#treeVal').text()
//                });
//            }

//        }

//    });
//}
//通过井筒号下拉值选择加载表单数据--------------
function getDJSJ() {
    $('#List_JH').combobox({
        onChange: function (n, o) {
            $.ajax({
                type: "POST",
                url: "../../Controllers/DJSJController.ashx?action=DJSJInfoByJH",
                data: {
                    "JH": n
                },
                dataType: 'json',
                async: false,
                success: function (data) {
                    console.log(data)
                    $('#ff').form('load', data);
                    //SetCurrentTime();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(errorThrown);
                }
            });
        }
    });
}


function saveXZ() {
    var list = [];
    var listAll = [];
    $("#ZD ul li").each(function () {
        if ($(this).children("input").is(':checked')) {
            list.push($(this).children("input").val())
        }
        listAll.push($(this).children("input").val())
    })
    for (var i = 0; i < listAll.length; i++) {
        $("#dg").datagrid('hideColumn', listAll[i]);
    }
    for (var i = 0; i < list.length; i++) {
        $("#dg").datagrid('showColumn', list[i]);
    }
    Closedialog();
}



//表格分页数据-------------------------
//function dgList() {
//    $('#dg').datagrid({
//        url: '../../Controllers/LJXMController.ashx?action=LJXMDataGrid',
//        loadMsg: '数据加载中......',
//        fitColumns: true,//使列适应窗体大小
//        fit: true,//使grid适应窗体大小
//        //fitColumns:true,
//        rownumbers: true,
//        singleSelect: true,
//        autoRowHeight: false,
//        pagination: true,
//        pageSize: 10,
//        columns: [[
//            { field: 'SC3', title: '甲方单位', align: "center", width: 80 },
//            { field: 'SC2', title: '地区', align: "center", width: 80 },
//            { field: 'ZJH', title: '井号', align: "center", width: 80 },
//            { field: 'REPORT_TYPE', title: '井别', align: "center", width: 80 },
//            { field: 'JH', title: '井筒号', align: "center", width: 80 },
//            { field: 'LJXL', title: '录井系列', align: "center", width: 80 },
//            { field: 'SJJS', title: '设计井深', align: "center", width: 80 },
//            { field: 'JSSJJS', title: '加深设计井深', align: "center", width: 80 },
//            { field: 'LJFGS', title: '录井项目部', align: "center", width: 80 },
//            { field: 'LJDH', title: '录井队号', align: "center", width: 80 },
//            { field: 'LJYQXH', title: '设备型号', align: "center" ,width:80}
//        ]]

//    });
//}

//表单_井筒号下拉数据源
function JH_List() {
    $('#List_JH').combobox({
        valueField: 'JH',
        textField: 'JH',
        url: '../../Controllers/LJXMController.ashx?action=ZJH_List&REPORT_TYPE=' + pageJB
    });
}

//表单翻页功能
//--首页
function loadRemote_Home() {
    $('#ff').form('load', '../../Controllers/LJXMController.ashx?action=LJXMInfo_Home&REPORT_TYPE=' + pageJB);
}
//--尾页
function loadRemote_End() {
    $('#ff').form('load', '../../Controllers/LJXMController.ashx?action=LJXMInfo_End&REPORT_TYPE=' + pageJB);
}
//--上页
function loadRemote_Up() {
    $('#ff').form('load', '../../Controllers/LJXMController.ashx?action=LJXMInfo_Up&REPORT_TYPE=' + pageJB + '&JH=' + $('#txtJH').textbox('getValue') + '&JX=' + $('#List_JX').combobox('getText'));
}
//--下页
function loadRemote_Down() {
    $('#ff').form('load', '../../Controllers/LJXMController.ashx?action=LJXMInfo_Down&REPORT_TYPE=' + pageJB + '&JH=' + $('#txtJH').textbox('getValue') + '&JX=' + $('#List_JX').combobox('getText'));
    console.log($("#txtID").val())
}
//--清理表单数据
function clearForm() {
    $('#ff').form('clear');
    //SetCurrentTime();
}

function delForm() {
    $.messager.confirm('提示框', '你确定要删除吗?', function () {
        $('#ff').form('submit', {
            url: '../../Controllers/LJXMController.ashx?action=LJXM_Del',
            onSubmit: function () {        //表单提交前的回调函数 
                var isValid = $(this).form('validate');//验证表单中的一些控件的值是否填写正确，比如某些文本框中的内容必须是数字 
                if (!isValid) {
                }
                return isValid; // 如果验证不通过，返回false终止表单提交 
            },
            success: function (meg) {  //表单提交成功后的回调函数，里面参数data是我们调用/BasicClass/ModifyClassInfo方法的返回值。 
                console.log(meg);
                var data = JSON.parse(meg);
                console.log(data);
                if (data.IsSuccess == "true") {
                    console.log(data);
                    $.messager.alert('提示信息', data.Message, 'warning');
                }
                else {
                    $.messager.alert('提示信息', data.Message, 'warning');
                }
                $("#dg").datagrid('reload');//表格数据重新加载
                loadRemote_Home();  // 重新载入首页数据  
            }
        }
        )
    });

}
//function getWorkersPB() {

//    console.log($("#txtZJH").textbox('getValue'));
//    $.ajax({
//        type: "post",
//        url: "../../Controllers/LJXMController.ashx?action=RYZG_Lis",
//        data: { ZJH: $("#txtZJH").textbox('getValue') },
//        dataType: 'json',
//        async: false,
//        success: function (msg) {
//            console.log($("#txtZJH").textbox('getValue'), 1)
//        }
//    })
//}
function getRYPB() {
    var str = $("#txtJH").textbox('getValue');
    console.log(str)
    $.ajax({
        type: "POST",
        url: "../../Controllers/LJXMController.ashx?action=RYZG_List",
        data: {
            JH: str

        },
        dataType: 'json',
        async: false,
        success: function (data) {
            console.log(data);
            if (data.rows.length > 0) {
                var name = '';
                for (var i = 0; i < data.rows.length; i++) {
                    name += data.rows[i].XM + ',';
                }
                if (name.length > 0) {
                    name = name.substr(0, name.length - 1);
                }
                $('.workersPB').textbox('setValue', name);
            } else {
                $('.workersPB').textbox('setValue', '');
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}
function getSBPB() {
    var str = $("#txtJH").textbox('getValue');
    $.ajax({
        type: "POST",
        url: "../../Controllers/LJXMController.ashx?action=SBZY_List",
        data: {
            JH: str

        },
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.rows.length > 0) {
                var name = '';
                for (var i = 0; i < data.rows.length; i++) {
                    name += data.rows[i].CCBH + ',';
                }
                if (name.length > 0) {
                    name = name.substr(0, name.length - 1);
                }
                $('.equipmentPB').textbox('setValue', name);
            } else {
                $('.equipmentPB').textbox('setValue', '');
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}
function getDZFPB() {
    var str = $("#txtJH").textbox('getValue');
    $.ajax({
        type: "POST",
        url: "../../Controllers/LJXMController.ashx?action=FWZY_List",
        data: {
            JH: str,
            FL: '地质房'
        },
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.rows.length > 0) {
                var name = '';
                for (var i = 0; i < data.rows.length; i++) {
                    name += data.rows[i].CCBH + ',';
                }
                if (name.length > 0) {
                    name = name.substr(0, name.length - 1);
                }
                $('.dzfPB').textbox('setValue', name);
            } else {
                $('.dzfPB').textbox('setValue', '');
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}
function getZFPB() {
    var str = $("#txtJH").textbox('getValue');
    $.ajax({
        type: "POST",
        url: "../../Controllers/LJXMController.ashx?action=FWZY_List",
        data: {
            JH: str,
            FL: '住房'
        },
        dataType: 'json',
        async: false,
        success: function (data) {
            console.log(data)
            if (data.rows.length > 0) {
                var name = '';
                for (var i = 0; i < data.rows.length; i++) {
                    name += data.rows[i].CCBH + ',';
                }
                if (name.length > 0) {
                    name = name.substr(0, name.length - 1);
                }
                $('.zfPB').textbox('setValue', name);
            } else {
                $('.zfPB').textbox('setValue', '');
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}
function getKFPB() {
    var str = $("#txtJH").textbox('getValue');
    $.ajax({
        type: "POST",
        url: "../../Controllers/LJXMController.ashx?action=FWZY_List",
        data: {
            JH: str,
            FL: '库房'
        },
        dataType: 'json',
        async: false,
        success: function (data) {
            console.log(data)
            if (data.rows.length > 0) {
                var name = '';
                for (var i = 0; i < data.rows.length; i++) {
                    name += data.rows[i].CCBH + ',';
                }
                if (name.length > 0) {
                    name = name.substr(0, name.length - 1);
                }
                $('.kfPB').textbox('setValue', name);
            } else {
                $('.kfPB').textbox('setValue', '');
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}
function loadList() {
    $('#workerModel').hide()
    aaa();
}
function overSBPB() {
    $('#equipmentModel').hide()
    bbb();
}
function overDZ() {
    $('#dzfModel').hide()
    getDZF();

}
function overZF() {
    $("#zfModel").hide();
    getZF()
}
function getWorkersPB() {
    $('#txtJH').textbox({
        onChange: function () {
            getRYPB();
            getSBPB();
            getDZFPB();
            getZFPB();
            getKFPB();
        }
    })
}
function aaa() {
    $('#getWorkerL').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=RYZG_List&JH=' + $("#txtJH").val() + '&strGW=' + $("#workerGW").val() + '&strColumn=' + $("#workerTJ").val() + '&strWhere=' + $("#keyWords").val(),
        //data: { ZJH: $("#txtZJH").val() }, x
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', checkbox: true }
            , { field: 'RYBH', title: '员工编号', width: 60 }
            , { field: 'XM', title: '员工姓名', width: 60 }

            , { field: 'XMB', title: '所属项目部', width: 100 }
            , { field: 'GW', title: '岗位', width: 100 }
            , { field: 'LXDH', title: '电话', width: 100 }
            , { field: 'JH', title: '人员状态', width: 100 }
            , { field: 'BZ', title: '备注', width: 100 }
        ]]

    });
    $('#getWorkerL1').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=RYZG_List&JH=' + $("#txtJH").val() + '&strGW=' + $("#workerGW").val() + '&strColumn=' + $("#workerTJ").val() + '&strWhere=' + $("#keyWords").val(),
        //data: { ZJH: $("#txtZJH").val() },
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            //{ field: 'ck', checkbox: true },
            { field: 'RYBH', title: '员工编号', width: 60 }
            , { field: 'XM', title: '员工姓名', width: 60 }

            , { field: 'XMB', title: '所属项目部', width: 100 }
            , { field: 'GW', title: '岗位', width: 100 }
            , { field: 'LXDH', title: '电话', width: 100 }
            , { field: 'JH', title: '人员状态', width: 100 }
            , { field: 'BZ', title: '备注', width: 100 }
        ]]

    });
    $("#See .datagrid-view").css("min-height", "300" + "px")
    $("#See .datagrid-view .datagrid-view2 .datagrid-header").css("min-height", "34" + "px")
    $('#getWorkerR').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=RYXZ_List&strGW=' + $("#workerGW").val() + '&strColumn=' + $("#workerTJ").val() + '&strWhere=' + $("#keyWords").val(),
        loadMsg: '数据加载中......',
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', checkbox: true },
            { field: 'RYBH', title: '员工编号', width: 60 }
            , { field: 'XM', title: '员工姓名', width: 60 }

            , { field: 'XMB', title: '所属项目部', width: 100 }
            , { field: 'GW', title: '岗位', width: 100 }
            , { field: 'LXDH', title: '电话', width: 100 }
            , { field: 'JH', title: '人员状态', width: 100 }
            , { field: 'BZ', title: '备注', width: 100 }
        ]]

    });


}
//获取人员配备数据
function getWorker() {
    $(".contentBox").hide();
    $('#workerModel').show();
    aaa();
    //getWorkerL1()
}
//在岗转待派
function CheckDataR() {
    var rybh = [];
    var rows = $('#getWorkerL').datagrid('getSelections');
    for (var i = 0; i < rows.length; i++) {
        rybh.push(rows[i].RYBH);
    }
    console.log(rybh);
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=RYFPTo_DP',
        data: { ToDPJson: JSON.stringify(rybh), JH: $("#txtJH").val() },
        dataType: "json",
        async: false,
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getWorkerL").datagrid('reload');
                $("#getWorkerR").datagrid('reload');
                getRYPB()
            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}
//待派转在岗
function CheckDataL() {
    var rybh = [];
    var rows = $('#getWorkerR').datagrid('getSelections');
    for (var i = 0; i < rows.length; i++) {
        rybh.push(rows[i].RYBH);
    }
    console.log(rybh);
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=RYFPTo_ZG',
        data: { ToZGJson: JSON.stringify(rybh), JH: $("#txtJH").val() },
        dataType: "json",
        async: false,
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getWorkerL").datagrid('reload');
                $("#getWorkerR").datagrid('reload');
                getRYPB();
            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}

function selectWorkers() {
    //$.ajax({
    //    type: "POST",
    //    url: "../../Controllers/LJXMController.ashx?action=RYZG_List",
    //    data: { ZJH: $("#txtZJH").val(), strGW: $("#workerGW").val(), strColumn: $("#workerTJ").val(), strWhere: $("#keyWords").val() },
    //    dataType: "json",
    //    success: function (msg) {
    //        console.log(msg, $("#workerTJ").combobox('getValue'))
    //    }
    //})
    //$.ajax({
    //    type: "POST",
    //    url: "../../Controllers/LJXMController.ashx?action=RYXZ_List",
    //    data: {strGW: $("#workerGW").val(), strColumn: $("#workerTJ").val(), strWhere: $("#keyWords").val() },
    //    dataType: "json",
    //    success: function (msg) {
    //        console.log(msg, $("#workerTJ").combobox('getValue'))
    //    }
    //})
    aaa();

}
function bbb() {
    $('#getEquipmentL').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=SBZY_List&JH=' + $("#txtJH").val() + '&strFL=' + $("#equipmentFL").val() + '&strColumn=' + $("#equipmentTJ").val() + '&strWhere=' + $("#keyEquipment").val(),
        //data: { ZJH: $("#txtZJH").val() },
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', checkbox: true }
            , { field: 'CCBH', title: '设备型号', width: 80 }
            , { field: 'SBMC', title: '设备名称', width: 80 }
            , { field: 'SBFL', title: '设备分类', width: 80 }
            , { field: 'SBZK', title: '设备状态', width: 60 }
            , { field: 'JH', title: '设备所在位置', width: 80 }
            , { field: 'BZ', title: '备注', width: 40 }
        ]]

    });
    $('#getEquipmentL1').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=SBZY_List&JH=' + $("#txtJH").val() + '&strFL=' + $("#equipmentFL").val() + '&strColumn=' + $("#equipmentTJ").val() + '&strWhere=' + $("#keyEquipment").val(),
        //data: { ZJH: $("#txtZJH").val() },
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            //{ field: 'ck', checkbox: true }
            { field: 'CCBH', title: '设备型号', width: 80 }
            , { field: 'SBMC', title: '设备名称', width: 80 }

            , { field: 'SBFL', title: '设备分类', width: 80 }
            , { field: 'SBZK', title: '设备状态', width: 60 }
            , { field: 'JH', title: '设备所在位置', width: 80 }
            , { field: 'BZ', title: '备注', width: 40 }
        ]]

    });
    $('#getEquipmentR').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=SBXZ_List&strFL=' + $("#equipmentFL").val() + '&strColumn=' + $("#equipmentTJ").val() + '&strWhere=' + $("#keyEquipment").val(),
        loadMsg: '数据加载中......',
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', checkbox: true }
            , { field: 'CCBH', title: '设备型号', width: 80 }
            , { field: 'SBMC', title: '设备名称', width: 80 }
            , { field: 'SBFL', title: '设备分类', width: 100 }
            , { field: 'SBZK', title: '设备状态', width: 80 }
            , { field: 'BZ', title: '备注', width: 60 }
        ]]

    });
}
//获取设备配备数据
function getEquipment() {
    $(".contentBox").hide();
    $('#equipmentModel').show();
    bbb()


}
//在用转闲置
function CheckEquipmentR() {
    var sbpb = [];
    var rows = $('#getEquipmentL').datagrid('getSelections');
    var jh = '', sbmc = '', sbfl = '';
    console.log(1);
    for (var i = 0; i < rows.length; i++) {
        jh = rows[i].JH;
        sbid = rows[i].SBID;
        sbfl = rows[i].SBFL;
        sbpb.push({ "JH": jh, "SBID": sbid, "SBFL": sbfl })
    }
    console.log(sbpb);
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=SBFPToXZ',
        data: { ToXZJson: JSON.stringify(sbpb), JH: $("#txtJH").val() },
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getEquipmentL").datagrid('reload');
                $("#getEquipmentR").datagrid('reload');
                getSBPB();
            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}
//闲置转在用
function CheckEquipmentL() {
    var rows = $('#getEquipmentR').datagrid('getSelections');
    var sbpb = [];
    var jh = '', sbmc = '', sbfl = '';
    console.log(1);
    for (var i = 0; i < rows.length; i++) {
        jh = rows[i].JH;
        sbid = rows[i].SBID;
        sbfl = rows[i].SBFL;
        sbpb.push({ "JH": jh, "SBID": sbid, "SBFL": sbfl })
    }
    console.log(sbpb);
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=SBFPToZY',
        data: { ToZYJson: JSON.stringify(sbpb), JH: $("#txtJH").val() },
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getEquipmentL").datagrid('reload');
                $("#getEquipmentR").datagrid('reload');
                getSBPB();
            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}

function selectEquipment() {
    bbb()
}
function showDzfModel() {
    $('#dzfModel').show();
    getDZF()
}
//获取地质房配备数据
function getDZF() {
    //$.ajax({
    //    type: 'post',
    //    url: '../../Controllers/LJXMController.ashx?action=FWXZ_List',
    //    data:{FL:''}
    //})

    $('#getDZFL').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=FWZY_List&JH=' + $("#txtJH").val() + '&FL=地质房',
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', checkbox: true }
            , { field: 'GGXH ', title: '地质房型号', width: 80 }
            , { field: 'CCBH', title: '地质房编号', width: 80 }
            , { field: 'SBZK  ', title: '地质房状况', width: 80 }
            , { field: 'JH', title: '使用地点', width: 80 }
            , { field: 'BZ', title: '备注', width: 60 }
        ]]

    });
    $('#getDZFL1').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=FWZY_List&JH=' + $("#txtJH").val() + '&FL=地质房',
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            //{ field: 'ck', checkbox: true }
            { field: 'GGXH ', title: '地质房型号', width: 80 }
            , { field: 'CCBH', title: '地质房编号', width: 80 }

            , { field: 'SBZK  ', title: '地质房状况', width: 80 }
            , { field: 'JH', title: '使用地点', width: 80 }
            , { field: 'BZ', title: '备注', width: 60 }
        ]]

    });
    $('#getDZFR').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=FWXZ_List&FL=地质房',
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', checkbox: true }
            , { field: 'GGXH ', title: '地质房型号', width: 80 }
            , { field: 'CCBH', title: '地质房编号', width: 80 }

            , { field: 'SBZK  ', title: '地质房状况', width: 80 }
            , { field: 'JH', title: '使用地点', width: 80 }
            , { field: 'BZ', title: '备注', width: 60 }
        ]]

    });

}

function CheckDZFR() {
    var dzfpb = [];
    var rows = $('#getDZFL').datagrid('getSelections');
    var zjh = '', sbmc = '', sbfl = '';
    console.log(1);
    for (var i = 0; i < rows.length; i++) {
        fwid = rows[i].FWID;
        dzfpb.push({ "FWID": fwid })
    }
    console.log(dzfpb);
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=FWFPToXZ',
        data: { ToXZJson: JSON.stringify(dzfpb), JH: $("#txtJH").val() },
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getDZFL").datagrid('reload');
                $("#getDZFR").datagrid('reload');
                getDZFPB();
            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}

function CheckDZFL() {
    var rows = $('#getDZFR').datagrid('getSelections');
    var dzfpb = [];
    var zjh = '', sbmc = '', sbfl = '';
    console.log(1);
    for (var i = 0; i < rows.length; i++) {
        fwid = rows[i].FWID;
        dzfpb.push({ "FWID": fwid })
    }
    console.log(dzfpb);
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=FWFPToZY',
        data: { ToZYJson: JSON.stringify(dzfpb), JH: $("#txtJH").val() },
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getDZFL").datagrid('reload');
                $("#getDZFR").datagrid('reload');
                getDZFPB();
            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}
function showZF() {
    $('#zfModel').show();
    getZF()
}
//获取住房配备数据
function getZF() {

    $('#getZFL').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=FWZY_List&JH=' + $("#txtJH").val() + '&FL=住房',
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', checkbox: true }
            , { field: 'CCBH', title: '住房编号', width: 80 }
            , { field: 'GGXH ', title: '住房型号', width: 80 }
            , { field: 'SBZK  ', title: '住房状况', width: 80 }
            , { field: 'JH', title: '使用地点', width: 80 }
            , { field: 'BZ', title: '备注', width: 60 }
        ]]

    });
    $('#getZFL1').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=FWZY_List&JH=' + $("#txtJH").val() + '&FL=住房',
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            //{ field: 'ck', checkbox: true }
            { field: 'CCBH', title: '住房编号', width: 80 }
            , { field: 'GGXH ', title: '住房型号', width: 80 }
            , { field: 'SBZK  ', title: '住房状况', width: 80 }
            , { field: 'JH', title: '使用地点', width: 80 }
            , { field: 'BZ', title: '备注', width: 60 }
        ]]

    });
    $('#getZFR').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=FWXZ_List&FL=住房',
        loadMsg: '数据加载中......',
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', checkbox: true }
            , { field: 'CCBH', title: '住房编号', width: 80 }
            , { field: 'GGXH ', title: '住房型号', width: 100 }
            , { field: 'SBZK  ', title: '住房状况', width: 100 }
            , { field: 'JH', title: '使用地点', width: 80 }
            , { field: 'BZ', title: '备注', width: 60 }
        ]]

    });

}

function CheckZFR() {
    var zfpb = [];
    var rows = $('#getZFL').datagrid('getSelections');
    var zjh = '', sbmc = '', sbfl = '';
    console.log(1);
    for (var i = 0; i < rows.length; i++) {
        fwid = rows[i].FWID;
        zfpb.push({ "FWID": fwid })
    }
    console.log(zfpb);
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=FWFPToXZ',
        data: { ToXZJson: JSON.stringify(zfpb), JH: $("#txtJH").val() },
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getZFL").datagrid('reload');
                $("#getZFR").datagrid('reload');
                getZFPB();
            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}

function CheckZFL() {
    var rows = $('#getZFR').datagrid('getSelections');
    var zfpb = [];
    var zjh = '', sbmc = '', sbfl = '';
    console.log(1);
    for (var i = 0; i < rows.length; i++) {
        fwid = rows[i].FWID;
        zfpb.push({ "FWID": fwid })
    }
    console.log(zfpb);
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=FWFPToZY',
        data: { ToZYJson: JSON.stringify(zfpb), JH: $("#txtJH").val() },
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getZFL").datagrid('reload');
                $("#getZFR").datagrid('reload');
                getZFPB();
            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}
function showKF() {
    $('#kfModel').show();
    getKF()
}
function overKF() {
    $('#kfModel').hide()
    getKF()
}
//获取库房配备数据
function getKF() {

    $('#getKFL').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=FWZY_List&JH=' + $("#txtJH").val() + '&FL=库房',
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', checkbox: true }
            , { field: 'CCBH', title: '库房编号', width: 80 }
            , { field: 'GGXH ', title: '库房型号', width: 80 }
            , { field: 'SBZK  ', title: '库房状况', width: 100 }
            , { field: 'JH', title: '使用地点', width: 80 }
            , { field: 'BZ', title: '备注', width: 60 }
        ]]

    });
    $('#getKFL1').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=FWZY_List&JH=' + $("#txtJH").val() + '&FL=库房',
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            //{ field: 'ck', checkbox: true }
            { field: 'CCBH', title: '库房编号', width: 80 }
            , { field: 'GGXH ', title: '库房型号', width: 80 }
            , { field: 'SBZK  ', title: '库房状况', width: 100 }
            , { field: 'JH', title: '使用地点', width: 80 }
            , { field: 'BZ', title: '备注', width: 60 }
        ]]

    });
    $('#getKFR').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=FWXZ_List&FL=库房',
        loadMsg: '数据加载中......',
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', checkbox: true }
            , { field: 'CCBH', title: '库房编号', width: 80 }
            , { field: 'GGXH ', title: '库房型号', width: 80 }
            , { field: 'SBZK  ', title: '库房状况', width: 100 }
            , { field: 'JH', title: '使用地点', width: 80 }
            , { field: 'BZ', title: '备注', width: 60 }
        ]]

    });

}

function CheckKFR() {
    var kfpb = [];
    var rows = $('#getKFL').datagrid('getSelections');
    var zjh = '', sbmc = '', sbfl = '';
    console.log(1);
    for (var i = 0; i < rows.length; i++) {
        fwid = rows[i].FWID;
        kfpb.push({ "FWID": fwid })
    }
    console.log(kfpb);
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=FWFPToXZ',
        data: { ToXZJson: JSON.stringify(kfpb), JH: $("#txtJH").val() },
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getKFL").datagrid('reload');
                $("#getKFR").datagrid('reload');
                getKFPB();
            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}

function CheckKFL() {
    var rows = $('#getKFR').datagrid('getSelections');
    var kfpb = [];
    var jh = '', sbmc = '', sbfl = '';
    for (var i = 0; i < rows.length; i++) {
        fwid = rows[i].FWID;
        kfpb.push({ "FWID": fwid })
    }
    console.log(kfpb);
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=FWFPToZY',
        data: { ToZYJson: JSON.stringify(kfpb), JH: $("#txtJH").val() },
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getKFL").datagrid('reload');
                $("#getKFR").datagrid('reload');
                getKFPB();
            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}

//设置日期格式
formatterDate = function (date) {

    var day = date.getDate() > 9 ? date.getDate() : "0" + date.getDate();

    var month = (date.getMonth() + 1) > 9 ? (date.getMonth() + 1) : "0"

        + (date.getMonth() + 1);

    return date.getFullYear() + '-' + month + '-' + day;

};
//设置默认为当前日期
//function SetCurrentTime() {
//    $('#STARSTART').datebox('setValue', formatterDate(new Date()));
//    $('#STAREND').datebox('setValue', formatterDate(new Date()));
//    $('#YJBASJ').datebox('setValue', formatterDate(new Date()));
//    $('#SJBASJ').datebox('setValue', formatterDate(new Date()));
//    $('#HQSJ').datebox('setValue', formatterDate(new Date()));
//}
//function getKJ() {
//    $.ajax({
//        type: 'get',
//        url: "../../Controllers/SCPGController.ashx?action=JHList_DFP",
//        dataType: 'json',
//        async: false,
//        success: function (data) {

//            console.log(data)
//            var KFJ = data.KFJ;
//            var PJJ = data.PJJ;
//            var KTJ = data.KTJ;
//            KJ_setTobody(KTJ, "react_JH", "one_check");
//            KJ_setTobody(PJJ, "react_JH2", "two_check");
//            KJ_setTobody(KFJ, "react_JH3", "three_check");

//        }
//    })
//}

function KJ_setTobody(data, tagName, tagClass) {

    var html = "";
    for (var i = 0; i < data.length; i++) {
        html += '<div style="border-bottom:1px dashed #95B8E7"><span>' + data[i].JH + '</span></div>'
    }

    $("#" + tagName + "").html(html);
}

//////////////////////////////////////////////////////导入功能star
//点击导入弹出窗口
function importbtn() {
    //加载时清除input type=file里的内容
    var obj = document.getElementById('FileUpload');
    obj.outerHTML = obj.outerHTML;
    $('#girdPreview').datagrid('loadData', { total: 0, rows: [] });
    //打开窗体
    $("#insert_dlg").dialog("open").dialog("setTitle", "录井项目信息导入");

}


//加载预览信息
function excelImport() {
    $('#jurSubsystemMenu').form('submit', {
        url: "../../Controllers/LJXMController.ashx?action=PreviewExcel",
        onSubmit: function () {
            return true;
        },
        success: function (msg) {
            rydata = JSON.parse(msg).list;
            console.log(rydata);
            $("#girdPreview").datagrid('loadData', rydata);
            start = 0;
            end = 10;

            $("#girdPreview").datagrid("getPager").pagination('refresh', {
                total: rydata.length,
                pageNumber: 1
            });
            //} else {
            //    $.messager.alert("提示", msg.Message, "error");
            //    $('#girdPreview').datagrid('clear');
            //}
        }
    });

}

//导入预览
function PreviewImport() {
    //员工信息列表初始化数据
    $('#girdPreview').datagrid({
        collapsible: true,
        singleSelect: true,
        //fitColumns: true,//使列适应窗体大小
        rownumbers: true,
        remoteSort: true,
        multiSort: false,
        fit: true,//使grid适应窗体大小
        checkOnSelect: true,
        pagination: true,
        idField: 'ID',
        columns: [[
            { field: 'ZJH', title: '井号', width: 100, align: 'center', fixed: true },
            { field: 'JH', title: '井筒号', width: 100, align: 'center' },
            { field: 'SC3', title: '甲方单位', width: 100, align: 'center' },
            { field: 'SC2', title: '地区', width: 100, align: 'center' },
            { field: 'JX', title: '井型', width: 100, align: 'center' },
            { field: 'REPORT_TYPE', title: '井别', width: 100, align: 'center' },
            { field: 'LJFGS', title: '录井项目部', width: 100, align: 'center' },
            { field: 'QK', title: '区块', width: 100, align: 'center' },
            { field: 'GJ', title: '国家', width: 100, align: 'center' },
            { field: 'SJJS', title: '设计井深', width: 100, align: 'center' },
            { field: 'JSSJJS', title: '加深设计井深', width: 100, align: 'center' },
            { field: 'SCFL', title: '市场类型', width: 100, align: 'center' },
            { field: 'SC1', title: '一级市场', width: 100, align: 'center' },
            { field: 'DRJS', title: '当前井深', width: 100, align: 'center' },
            { field: 'SGZT', title: '当前动态', width: 100, align: 'center' },
            { field: 'DZJDXM', title: '地质监督姓名', width: 100, align: 'center' },
            { field: 'DZJDZJH', title: '地质监督证件号', width: 100, align: 'center' },
            { field: 'DZJDSSGS', title: '地质监督所属公司', width: 100, align: 'center' },
            { field: 'LJDWZZ', title: '录井资质', width: 100, align: 'center' },
            { field: 'ZJJDXM', title: '钻井监督姓名', width: 100, align: 'center' },
            { field: 'ZJJDZJH', title: '钻井监督证件号', width: 100, align: 'center' },
            { field: 'ZJJDSSGS', title: '钻井监督所属公司', width: 100, align: 'center' },
            { field: 'LJDH', title: '录井队号', width: 100, align: 'center' },
            { field: 'LJYQXH', title: '设备型号', width: 100, align: 'center' },
            { field: 'YQZZ', title: '仪器资质', width: 100, align: 'center' },
            { field: 'DWZBH', title: '队伍自编号', width: 100, align: 'center' },
            { field: 'DZS', title: '地质师', width: 100, align: 'center' },
            { field: 'STARSTART', title: '装卫星时间', width: 100, align: 'center' },
            { field: 'STARAZR', title: '安装卫星人', width: 100, align: 'center' },
            { field: 'STAREND', title: '拆卫星时间', width: 100, align: 'center' },
            { field: 'STARCCR', title: '拆卫星人', width: 100, align: 'center' },
            { field: 'SGDW', title: '施工单位', width: 100, align: 'center' },
            { field: 'SGDH', title: '施工队号', width: 100, align: 'center' },
            { field: 'YJBASJ', title: '预计搬安时间', width: 100, align: 'center' },
            { field: 'SJBASJ', title: '实际搬安时间', width: 100, align: 'center' },
            { field: 'BQJL', title: '搬迁距离', width: 100, align: 'center' },
            { field: 'HQSJ', title: '回迁时间', width: 100, align: 'center' },
            { field: 'DQZT', title: '当前状态', width: 100, align: 'center' },
            { field: 'CHOUXIYOU', title: '稠油/稀油', width: 100, align: 'center' },
            { field: 'HXJW', title: '后续井位', width: 100, align: 'center' },
            { field: 'HXJDH', title: '后续井队号', width: 100, align: 'center' },
            { field: 'JDDT', title: '井队动态', width: 100, align: 'center' },
            { field: 'LSDW', title: '隶属单位', width: 100, align: 'center' },
            { field: 'XMBJWXX', title: '项目部井位信息', width: 100, align: 'center' },
            { field: 'LJXL', title: '录井系列', width: 100, align: 'center' },
            { field: 'XQXMB', title: '辖区项目部', width: 100, align: 'center' },
            { field: 'PGZDTS', title: '派工重点提示', width: 100, align: 'center', fixed: true }

        ]]
    });

    var pager = $("#girdPreview").datagrid("getPager");
    pager.pagination({
        total: rydata.length,
        pageSize: 10,
        onSelectPage: function (pageNo, pageSize) {
            currentno = pageNo;
            start = (pageNo - 1) * pageSize;
            end = start + pageSize;
            $("#girdPreview").datagrid("loadData", rydata.slice(start, end));
            pager.pagination('refresh', {
                total: rydata.length,
                pageNumber: pageNo
            });
        }
    });

}

//导入
function openUrl() {
    if (rydata.length > 0) {
        $.ajax({
            type: "POST",
            url: '../../Controllers/LJXMController.ashx?action=LJXM_Import',
            data: { "Data": JSON.stringify(rydata) },
            dataType: 'json',
            success: function (msg) {
                //var msg = eval('(' + msg + ')');
                if (msg.IsSuccess == "true") {

                    $("#insert_dlg").dialog('close');
                    $.messager.alert("提示", "导入成功");
                    $('#dg').datagrid('reload');

                }
                else {
                    $.messager.alert('提示', msg.Message, 'info')
                }

            },
            error: function (msg) {
                $.messager.alert('提示', msg.Message, "error");
            }
        });

    }
    else {
        $.messager.alert("提示", "还未进行预览无法导入！", "info");
    }
}
///////////////////////////////////////////////////////////////导入功能end


////导出 
function exportExcel() {
    var str = "";
    var xstj_2 = $("#SelectColumn_List").combobox('getText');
    var tj_2 = $("#SelectColumn_List").combobox('getValue');
    var tj_3 = $("#Symbol_List").combobox('getValue');
    var tj_4 = $("#isvalue").val();
    if (tj_3 == "like") {
        tj_3 = " like "
        tj_4 = "'%" + Trim(tj_4) + "%'"
    }
    else {
        tj_4 = "'" + Trim(tj_4) + "'";
    }

    var mark = " AND ";
    if ($("#chkbox").is(':checked')) {
        mark = " OR ";
    }
    if (xstj_2 != "" && tj_2 != "" && tj_4 != "''") {
        str = " " + mark + " " + tj_2 + " " + tj_3 + " " + tj_4 + "";
    }
    if ($('#SelectWhere').children().length > 0) {
        $('#SelectWhere').children().each(function () {
            console.log($(this));
            str += $(this).find("span").eq(0).html() + $(this).find("p").html() + $(this).find("span").eq(2).html() + $(this).find("span").eq(3).html();
        })
        console.log(str);
    }
    $('#ExportIframe').attr("src", "../../../Page/DownLoad/DownLoad.aspx?Source=OutExportExcel_LJXM&str=" + str + "&REPORT_TYPE=" + pageJB);
}