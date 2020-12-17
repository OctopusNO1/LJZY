var start = null;
var end = null;
var rydata = new Array();
var currentno = 1;
var str = "";//查询拼接字符串


$(function () {

     //调用导入预览
    PreviewImport();
    //表格数据源
    $('#dg').datagrid({
        url: '../../Controllers/DJCHYAQHSEController.ashx?action=DJCHYAQSHE_DataGrid&type=2',
        loadMsg: '数据加载中......',
        fitColumns: true,//使列适应窗体大小
        fit: true,//使grid适应窗体大小
        rownumbers: true,
        singleSelect: true,
        autoRowHeight: false,
        pagination: true,
        pageSize: 10,
        columns: [[
            { field: 'SC2', title: '地区', align: 'center', width: 100 },
            { field: 'QK', title: '区块', align: 'center', width: 100 },
            { field: 'REPORT_TYPE', title: "井别", align: 'center', width: 100, },
            { field: 'JX', title: '井型', align: 'center', width: 100 },
            { field: 'ZJH', title: '井号', align: 'center', width: 100 },
            { field: 'SC3', title: '甲方单位', align: 'center', width: 100 },
            { field: 'LJFGS', title: '录井项目部', align: 'center', width: 100 },
            {
                field: 'DJYJYA', title: "QSHE作业计划书", align: 'center', width: 150,
                formatter: function (val, rec) {
                    //console.log(rec.FILEURL);
                    if (rec != null) {
                        var Type = "'QSHE作业计划书'";
                        if (rec.QSHEList.length > 0) {
                            //url = "'../../PDFjs/web/viewer.html?file=../../UpLoad/玛湖63/2018/井位设计/1.pdf'";
                            var x = '<a target="pdfContainer" onclick="showPdf(\'' + rec.ZJH + '\',' + Type + ')">查看';
                            var y = '<a href="' + rec.QSHEList[0].FILEURL + '" class="easyui-linkbutton"  plain="true">下载';
                            return x + '&nbsp' + y;
                        } else {
                            var x = '<a target="pdfContainer" onclick="showPdf(\'' + rec.ZJH + '\',' + Type + ')">查看';
                            var y = '<a href="javascript:void(0);" class="easyui-linkbutton"  plain="true">下载';
                            return x + '&nbsp' + y;
                        }

                    }
                }

            },
            { field: 'BZR', title: '编制人', align: 'center', width: 100 },
            { field: 'BZRQ_DG', title: '编制日期', align: 'center', width: 100 },
            { field: 'BZ', title: '备注', align: 'center', width: 100 },
        ]]
    });
})

//点击查看打开pdf
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
            console.log(list);
            for (var i = 0; i < list.length; i++) {
                console.log(list);
                var Url = list[i].PDFURL;
                window.open(Url);
            }

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });

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
    console.log(arr);
    $.ajax({
        type: "POST",
        url: "../../Controllers/ColumnListController.ashx?action=getZD",
        data: {
            "zdlist": JSON.stringify(arr)

        },
        dataType: 'json',
        async: false,
        success: function (data) {
            console.log(data)
            $("#SelectColumn_List").combobox('reload', '../../Controllers/ColumnListController.ashx?action=getZD');
            Closedialog();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
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

//删除字符串中的空格
function Trim(str) {
    return str.replace(/(^\s*)|(\s*$)/g, "");
}





//点击导入弹出窗口
function insert_one() {
    //加载时清除input type=file里的内容
    var obj = document.getElementById('FileUpload');
    obj.outerHTML = obj.outerHTML;
    $('#girdPreview').datagrid('loadData', { total: 0, rows: [] });
    //打开窗体
    $("#insert_dlg").dialog("open").dialog("setTitle", "QHSE作业计划书导入");

}

//加载预览信息
function excelImport() {


    $('#jurSubsystemMenu').form('submit', {
        url: "../../Controllers/DJCHYAQHSEController.ashx?action=PreviewExcel_DJCHYAHSE",
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
            { field: 'SC2', title: '地区', align: 'center', width: 100 },
            { field: 'QK', title: '区块', align: 'center', width: 100 },
            { field: 'REPORT_TYPE', title: "井别", align: 'center', width: 100, },
            { field: 'JX', title: '井型', align: 'center', width: 100 },
            { field: 'ZJH', title: '井号', align: 'center', width: 100 },
            { field: 'SC3', title: '甲方单位', align: 'center', width: 100 },
            { field: 'LJFGS', title: '录井项目部', align: 'center', width: 100 },
            { field: 'BZR', title: '编制人', align: 'center', width: 100 },
            { field: 'BZRQ_DG', title: '编制日期', align: 'center', width: 100 },
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
            url: '../../Controllers/DJCHYAQHSEController.ashx?action=ImportExcel_DJCHYAHSE&type=2',
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





