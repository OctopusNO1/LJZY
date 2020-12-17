var start = null;
var end = null;
var rydata = new Array();
var currentno = 1;
var str = "";//查询拼接字符串

$(function () {

    PreviewImport();


    //表格数据源
    $('#dg').datagrid({
        url: '../../Controllers/SBGLController.ashx?action=SB_WXDataGrid',
        loadMsg: '数据加载中......',
        fitColumns: true,//使列适应窗体大小
        fit: true,//使grid适应窗体大小
        rownumbers: true,
        singleSelect: true,
        autoRowHeight: false,
        pagination: true,
        pageSize: 10,
        columns: [[
            { field: 'DW', title: '单位名称', align: 'center', width: 100 },
            { field: 'SBMC', title: '设备名称', align: 'center', width: 100 },
            { field: 'GGXH', title: "规格型号", align: 'center', width: 100, },
            { field: 'SCCJ', title: '生产厂家', align: 'center', width: 100 },
            { field: 'GB', title: '国别', align: 'center', width: 100 },
            { field: 'CCRQ_GD', title: '出厂日期', align: 'center', width: 100 },
            { field: 'CCBH', title: '出厂编号', align: 'center', width: 100 },
            { field: 'TCRQ_GD', title: '投产日期', align: 'center', width: 100 },
            { field: 'ZCBH', title: '资产编号', align: 'center', width: 100 },
            { field: 'ZBH', title: '自编号', align: 'center', width: 100 },
            { field: 'SBSZWZ', title: '安装地点', align: 'center', width: 100 },
            { field: 'SBZK', title: '设备状况', align: 'center', width: 100 },    
            { field: 'BZ', title: '备注', align: 'center', width: 100 },

        ]]
    });
})



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


//去除空格
function Trim(str) {
    return str.replace(/(^\s*)|(\s*$)/g, "");
}

//点击添加条件
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
    if (xstj_2 != "" && tj_2 != "" && tj_4 != "''") {

        html += '<div class="groups"><span style="display:none">' + mark + '</span><span>' + xstj_2 + '</span><span>' + tj_3 + '</span><span>' + tj_4 + '</span><img class="close" onclick="closetj(this)" src="../../Image/no.png"/><p style="display:none">' + tj_2 + '</p></div>';
        $("#SelectWhere").append(html);
        $("#SelectColumn_List").combobox('setValue', '');
        $("#Symbol_List").combobox('setValue', '');
        $("#isvalue").textbox('setValue', '');
    }

}
//添加条件删除
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
    });
    $('#dg').datagrid('reload');
    
}



//点击导入弹出窗口
function insert_one() {

    //加载时清除input type=file里的内容
    var obj = document.getElementById('FileUpload');
    obj.outerHTML = obj.outerHTML;
    $('#girdPreview').datagrid('loadData', { total: 0, rows: [] });
    //打开窗体
    $("#insert_dlg").dialog("open").dialog("setTitle", "人员信息导入");

}

//加载预览信息
function excelImport() {


    $('#jurSubsystemMenu').form('submit', {
        url: "../../Controllers/SBGLController.ashx?action=PreviewExcel_WX",
        onSubmit: function () {
            return true;
        },
        success: function (msg) {
            var msg = eval('(' + msg + ')');
            if (msg.IsSuccess == "true") {
                console.log(msg);
                rydata = JSON.parse(msg.Message);
                console.log(rydata);
                var sss = rydata.slice(0, 10);
                $("#girdPreview").datagrid('loadData', sss);
                start = 0;
                end = 10;

                $("#girdPreview").datagrid("getPager").pagination('refresh', {
                    total: rydata.length,
                    pageNumber: 1
                });
            } else {
                $.messager.alert("提示", msg.Message, "error");
                $('#girdPreview').datagrid('clear');
            }
        }
    });

}

//导入预览
function PreviewImport() {
    //员工信息列表初始化数据
    $('#girdPreview').datagrid({
        collapsible: true,
        singleSelect: true,
        fitColumns: true,//使列适应窗体大小
        rownumbers: true,
        remoteSort: true,
        multiSort: false,
        fit: true,//使grid适应窗体大小
        checkOnSelect: true,
        pagination: true,
        idField: 'ID',
        columns: [[
            { field: 'DW', title: '单位名称', align: 'center', width: 100 },
            { field: 'SBMC', title: '设备名称', align: 'center', width: 100 },
            { field: 'GGXH', title: "规格型号", align: 'center', width: 100, },
            { field: 'SCCJ', title: '生产厂家', align: 'center', width: 100 },
            { field: 'GB', title: '国别', align: 'center', width: 100 },
            { field: 'CCRQ_GD', title: '出厂日期', align: 'center', width: 100 },
            { field: 'CCBH', title: '出厂编号', align: 'center', width: 100 },
            { field: 'TCRQ_GD', title: '投产日期', align: 'center', width: 100 },
            { field: 'ZBH', title: '自编号', align: 'center', width: 100 },
            { field: 'SBSZWZ', title: '安装地点', align: 'center', width: 100 },
            { field: 'SBZK', title: '设备状况', align: 'center', width: 100 },      
            { field: 'BZ', title: '备注', align: 'center', width: 100 },



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
            url: '../../Controllers/SBGLController.ashx?action=ImportExcel_WX',
            data: { "Data": JSON.stringify(rydata) },
            dataType: 'json',
            success: function (msg) {
                var msg = eval('(' + msg + ')');
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


//导出
function exportExcel() {

    $('#ExportIframe').attr("src", "../../../Page/DownLoad/DownLoad.aspx?Source=OutExportExcel_SBWX&str=" + escape(str));
}




