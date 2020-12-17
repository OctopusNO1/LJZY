var start = null;
var end = null;
var rydata = new Array();
var currentno = 1;
var str = "";


$(function () {
    //调用导入预览
    PreviewImport();
    //初始化人员信息修改

    //表格数据源
    $('#dg').datagrid({
        url: '../../Controllers/WJKPController.ashx?action=WJKP_DataGrid',
        loadMsg: '数据加载中......',
        fitColumns: false,//使列适应窗体大小
        fit: false,//使grid适应窗体大小
        rownumbers: true,
        singleSelect: true,
        autoRowHeight: true,
        pagination: true,
        pageSize: 20,
        columns: [[
            // 01,35
            { field: 'AJSJ01_JH', title: '井号', align: 'center', width: 100 },
            { field: 'AJSJ01_JB', title: '井别', align: 'center', width: 100, editor: 'text' },
            { field: 'AJSJ01_JX', title: '井型', align: 'center', width: 100, editor: 'text' },
            { field: 'AJSJ01_SJZZBX', title: '纵坐标X(m)', align: 'center', width: 100, editor: 'text' },
            { field: 'AJSJ01_SJHZBY', title: '横坐标Y(m)', align: 'center', width: 100, editor: 'text' },
            { field: 'AJSJ01_SS', title: '水深', align: 'center', width: 100, editor: 'text' },
            { field: 'AJSJ01_ZTMD', title: '评价目的', align: 'center', width: 100, editor: 'text' },
            { field: 'AJSJ01_GZWZ', title: '构造位置', align: 'center', width: 100, editor: 'text' },
            { field: 'AJSJ01_DLWZ', title: '地理位置', align: 'center', width: 100, editor: 'text' },
            { field: 'AJSJ01_CXWZ', title: '测线位置', align: 'center', width: 100, editor: 'text' },
            { field: 'AJSJ01_DMHB', title: '地面海拔', align: 'center', width: 100, editor: 'text' },
            { field: 'AJSJ01_SJJS', title: '设计井深', align: 'center', width: 100, editor: 'text' },
            { field: 'AJSJ01_SJMDC', title: '主要目的层', align: 'center', width: 100, editor: 'text' },

            { field: 'ADLJ01_BXHB', title: '补心海拔', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ01_SGDW', title: '施工单位', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ01_SGDH', title: '施工队号', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ01_KZRQ', title: '开钻日期', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ01_WZRQ', title: '完钻日期', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ01_WJRQ', title: '完井日期', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ01_WZJS', title: '完钻井深', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ01_WZCS', title: '完钻垂深', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ01_WZCW', title: '完钻层位', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ01_WJFF', title: '完井方法', align: 'center', width: 100, editor: 'text' },
            //{ field: 'JX', title: '井型', align: 'center', width: 100, editor: 'text' },

            { field: 'ADLJ35_CDSD', title: '最大井斜深度', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ35_ZDJXJ', title: '最大井斜角', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ35_FWJ', title: '最大井斜方位角', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ35_BHFWJ', title: '总方位角', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ35_BHJ', title: '总位移', align: 'center', width: 100, editor: 'text' },

            // 09
            { field: 'ADLJ09_DJSD1', title: '钻井液井段顶界(m)', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ09_DJSD2', title: '钻井液井段底界(m)', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ09_ZJYMD1', title: '相对密度1(g/cm3)', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ09_ZJYMD2', title: '相对密度2(g/cm3)', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ09_ZJYND1', title: '钻井液粘度1（S）', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ09_ZJYND2', title: '钻井液粘度2(s)', align: 'center', width: 100, editor: 'text' },

            // 25
            { field: 'ADLJ25_CW', title: '层位', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ25_SJFC', title: '设计分层底界（m）', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ25_SZFC', title: '随钻分层底界（m）', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ25_DCFC', title: '电测分层底界（m）', align: 'center', width: 100, editor: 'text' },

            // 34,36
            //{ field: 'ADLJ34_ZTXH', title: '钻头序号', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ34_ZTZJ', title: '钻头直径', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ34_ZDJS2', title: '钻达井深(m)', align: 'center', width: 100, editor: 'text' },

            { field: 'ADLJ36_TGMC', title: '套管名称', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ36_TGWJ', title: '外径(mm)', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ36_XRJS', title: '下深(m)', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ36_SNFS', title: '水泥返深(m)', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ36_GJZL', title: '固井质量', align: 'center', width: 100, editor: 'text' },

            // 04
            { field: 'ADLJ04_TC', title: '取心筒次', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ04_DJSD1', title: '井段顶界(m)', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ04_DJSD2', title: '井段底界(m)', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ04_CW1', title: '取心层位', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ04_DJSD2_DJSD1', title: '进尺(m)', align: 'center', width: 100 },
            { field: 'ADLJ04_YXCD', title: '岩心长度(m)', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ04_YXCD_DJSD2_DJSD1', title: '收获率(%)', align: 'center', width: 100 },
            //{ field: 'ADLJ04_XSXC', title: '显示心长(m)', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ04_BZ', title: '备注', align: 'center', width: 100, editor: 'text' },

            // 75
            { field: 'ADLJ75_JSCH', title: '序号', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ75_CW', title: '层位', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ75_DJSD1', title: '井段顶界(m)', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ75_DJSD2', title: '井段底界(m)', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ75_DJSD2_DJSD1', title: '厚度(m)', align: 'center', width: 100 },
            { field: 'ADLJ75_HYJB', title: '显示级别', align: 'center', width: 100, editor: 'text' },
            { field: 'ADLJ75_YSMC', title: '岩性', align: 'center', width: 100, editor: 'text' },
        ]],

        // 双击单元格，进行编辑(行号-1，键/表头，值)
        onDblClickCell: function (index, field, value) {
            if (endEditing()) {
                $('#dg').datagrid('selectRow', index).datagrid('editCell', {
                    index: index,
                    field: field
                });
                editIndex = index;
            }
        },
        // 结束编辑，修改数据库表
        onAfterEdit: function (index, row, changes) {
            $.ajax({
                type: "POST",
                url: '../../Controllers/WJKPController.ashx?action=WJKP_Update',  //修改
                data: {
                    "AJSJ01_JH": row.AJSJ01_JH, "AJSJ01_JB": row.AJSJ01_JB, "AJSJ01_JX": row.AJSJ01_JX, "AJSJ01_SJZZBX": row.AJSJ01_SJZZBX, "AJSJ01_SJHZBY": row.AJSJ01_SJHZBY,
                    "AJSJ01_SS": row.AJSJ01_SS, "AJSJ01_ZTMD": row.AJSJ01_ZTMD, "AJSJ01_GZWZ": row.AJSJ01_GZWZ, "AJSJ01_DLWZ": row.AJSJ01_DLWZ, "AJSJ01_CXWZ": row.AJSJ01_CXWZ,
                    "AJSJ01_DMHB": row.AJSJ01_DMHB, "AJSJ01_SJJS": row.AJSJ01_SJJS, "AJSJ01_SJMDC": row.AJSJ01_SJMDC
                }, 
                dataType: "json",//响应结果为文本
                success: function (msg) {
                    $.messager.alert('消息', '修改成功');
                    query()//修改成功后掉用查询方法
                },
                error: function (msg) {
                    $.messager.alert('提示', msg.Message, "error");
                }
            });
        },
        //单击触发事件       
        onClickCell: function (index, field, value) {
            endEditing();
        },

        //fitColumns: true,
        pagination: true,
    });


    $('#dg2').datagrid({
        url: '../../Controllers/WJKPController.ashx?action=SJRZ_DataGrid',
        loadMsg: '数据加载中......',
        fitColumns: false,//使列适应窗体大小
        fit: false,//使grid适应窗体大小
        rownumbers: true,
        singleSelect: true,
        autoRowHeight: true,
        pagination: true,
        pageSize: 20,
        columns: [[

            { field: 'XM', title: "姓名", align: 'center', width: 100 },
            { field: 'JH', title: "井号", align: 'center', width: 100, },
            { field: 'REPORT_TYPE', title: "井别", align: 'center', width: 100, },
            {
                field: 'KSSJRQ', title: "开始上井时间", align: 'center', width: 100, formatter: function (val) {
                    return formattime(val);
                }
            },
            {
                field: 'JSSJRQ', title: "结束上井时间", align: 'center', width: 100, formatter: function (val) {
                    return formattime(val);
                }
            },
            { field: 'SJTS', title: "上井天数", align: 'center', width: 100 },
            { field: 'LJSJTS', title: "累计上井天数", align: 'center', width: 100 },
            { field: 'GWXS', title: "岗位系数", align: 'center', width: 100 },
            { field: 'JXS', title: "井系数", align: 'center', width: 100 },
            { field: 'BZ', title: '备注', align: 'center', width: 100 },

        ]]
    });

    loadRemote_Home();
    $("#previewSGZ>img").attr("src", $("#inputSGZ").val())
})


$.extend($.fn.datagrid.methods, {
    editCell: function (jq, param) {
        return jq.each(function () {
            var opts = $(this).datagrid('options');
            var fields = $(this).datagrid('getColumnFields', true).concat(
                $(this).datagrid('getColumnFields'));
            for (var i = 0; i < fields.length; i++) {
                var col = $(this).datagrid('getColumnOption', fields[i]);
                col.editor1 = col.editor;
                if (fields[i] != param.field) {
                    col.editor = null;
                }
            }
            $(this).datagrid('beginEdit', param.index);
            for (var i = 0; i < fields.length; i++) {
                var col = $(this).datagrid('getColumnOption', fields[i]);
                col.editor = col.editor1;
            }
        });
    }
});

var editIndex = undefined;
//结束编辑
function endEditing() {
    if (editIndex == undefined) {
        return true
    }
    if ($('#dg').datagrid('validateRow', editIndex)) {
        $('#dg').datagrid('endEdit', editIndex);
        editIndex = undefined;
        return true;
    } else {
        return false;
    }
}

//查询全部数据并绑定
function query() {
    $('#dg').datagrid({
        url: '../../Controllers/WJKPController.ashx?action=WJKP_DataGrid',
    });
}


function formattime(val) {
    //console.log(val);
    var str = val.substr(0, 10);
    if (str == "0001-01-01") {
        return "";
    }
    return str;
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



function Showdailog2() {
    $("#dlg2").dialog("open").dialog("setTitle", "选择字段");
}
//选择字段弹出框关闭
function Closedialog2() {
    $('#dlg2').dialog('close');
}
//选择字段保存
function saveXZ2() {

    var list2 = [];
    var listAll2 = [];
    $("#ZD2 ul li").each(function () {
        if ($(this).children("input").is(':checked')) {
            list2.push($(this).children("input").val())
        }
        listAll2.push($(this).children("input").val())
    })
    for (var i = 0; i < listAll2.length; i++) {
        $("#dg2").datagrid('hideColumn', listAll2[i]);
    }
    for (var i = 0; i < list2.length; i++) {
        $("#dg2").datagrid('showColumn', list2[i]);
    }
    Closedialog2();
}




$("body").keydown(function () {
    if (event.keyCode == "13") {//keyCode=13是回车键
        $('#searchbtn').click();
    }
});




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
            // console.log($(this));
            str += $(this).find("span").eq(0).html() + $(this).find("p").html() + $(this).find("span").eq(2).html() + $(this).find("span").eq(3).html();
        })
        console.log(str);
    }

    $('#dg').datagrid('load', {
        "strWhere": str,
    });
    //$('#dg').datagrid('reload');

}




//点击添加条件
function addTJ2() {
    var xstj_2 = $("#SelectColumn_List2").combobox('getText');
    var tj_2 = $("#SelectColumn_List2").combobox('getValue');
    var tj_3 = $("#Symbol_List2").combobox('getValue');
    var tj_4 = $("#isvalue2").val();
    if (tj_3 == "like") {
        tj_3 = " like "
        tj_4 = "'%" + Trim(tj_4) + "%'"
    }
    else {
        tj_4 = "'" + Trim(tj_4) + "'";
    }

    var html = '';
    var mark = " AND ";
    if ($("#chkbox2").is(':checked')) {
        mark = " OR ";
    }
    if (xstj_2 != "" && tj_2 != "" && tj_4 != "''") {

        html += '<div class="groups"><span style="display:none">' + mark + '</span><span>' + xstj_2 + '</span><span>' + tj_3 + '</span><span>' + tj_4 + '</span><img class="close" onclick="closetj(this)" src="../../Image/no.png"/><p style="display:none">' + tj_2 + '</p></div>';
        $("#SelectWhere2").append(html);
        $("#SelectColumn_List2").combobox('setValue', '');
        $("#Symbol_List2").combobox('setValue', '');
        $("#isvalue2").textbox('setValue', '');
    }

}
//添加条件删除
function closetj(e) {
    $(e).parent().remove();
}

function doSearch2() {

    str = "";
    var xstj_2 = $("#SelectColumn_List2").combobox('getText');
    var tj_2 = $("#SelectColumn_List2").combobox('getValue');
    var tj_3 = $("#Symbol_List2").combobox('getValue');
    var tj_4 = $("#isvalue2").val();
    if (tj_3 == "like") {
        tj_3 = " like "
        tj_4 = "'%" + Trim(tj_4) + "%'"
    }
    else {
        tj_4 = "'" + Trim(tj_4) + "'";
    }

    var mark = " AND ";
    if ($("#chkbox2").is(':checked')) {
        mark = " OR ";
    }
    if (xstj_2 != "" && tj_2 != "" && tj_4 != "''") {
        str = " " + mark + " " + tj_2 + " " + tj_3 + " " + tj_4 + "";
    }
    if ($('#SelectWhere2').children().length > 0) {
        $('#SelectWhere2').children().each(function () {
            // console.log($(this));
            str += $(this).find("span").eq(0).html() + $(this).find("p").html() + $(this).find("span").eq(2).html() + $(this).find("span").eq(3).html();
        })
        // console.log(str);
    }

    $('#dg2').datagrid('load', {
        "strWhere": str,
    });
    // $('#dg2').datagrid('reload');

}



//点击导入弹出窗口
function insert_one() {
    //加载时清除input type=file里的内容
    var obj = document.getElementById('FileUpload');
    obj.outerHTML = obj.outerHTML;
    $('#girdPreview').datagrid('loadData', { total: 0, rows: [] });
    //打开窗体
    $("#insert_dlg").dialog("open").dialog("setTitle", "完井统计信息导入");

}

//加载预览信息
function excelImport() {
    $('#jurSubsystemMenu').form('submit', {
        url: "../../Controllers/WJKPController.ashx?action=PreviewExcel",
        onSubmit: function () {
            return true;
        },
        success: function (msg) {
            var msg = eval('(' + msg + ')');
            if (msg.IsSuccess == "true") {
                // console.log(msg);
                rydata = JSON.parse(msg.Message);
                //console.log(rydata);
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

//初始化导入预览的表头
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
            { field: 'AJSJ01_JH', title: 'AJSJ01井号', width: $(this).width() * 0.1, align: 'center' },
            { field: 'AJSJ01_JB', title: 'AJSJ01井别', width: $(this).width() * 0.1, align: 'center' },
            { field: 'AJSJ01_JX', title: 'AJSJ01井型', width: $(this).width() * 0.1, align: 'center' },
            { field: 'AJSJ01_SJZZBX', title: 'AJSJ01纵坐标', width: $(this).width() * 0.1, align: 'center' },
            { field: 'AJSJ01_SJHZBY', title: 'AJSJ01横坐标', width: $(this).width() * 0.1, align: 'center' },
            { field: 'AJSJ01_SS', title: 'AJSJ01水深', width: $(this).width() * 0.1, align: 'center' },
            { field: 'AJSJ01_ZTMD', title: 'AJSJ01评价目的', width: $(this).width() * 0.1, align: 'center' },
            { field: 'AJSJ01_GZWZ', title: 'AJSJ01构造位置', width: $(this).width() * 0.1, align: 'center' },
            { field: 'AJSJ01_DLWZ', title: 'AJSJ01地理位置', width: $(this).width() * 0.1, align: 'center' },
            { field: 'AJSJ01_CXWZ', title: 'AJSJ01测线位置', width: $(this).width() * 0.1, align: 'center' },
            { field: 'AJSJ01_DMHB', title: 'AJSJ01地面海拔', width: $(this).width() * 0.1, align: 'center' },
            { field: 'AJSJ01_SJJS', title: 'AJSJ01设计井深', width: $(this).width() * 0.1, align: 'center' },
            { field: 'AJSJ01_SJMDC', title: 'AJSJ01主要目的层', width: $(this).width() * 0.1, align: 'center' },

            { field: 'ADLJ01_BXHB', title: 'ADLJ01补心海拔', width: $(this).width() * 0.1, align: 'center' },
            { field: 'ADLJ01_SGDW', title: 'ADLJ01施工单位', width: $(this).width() * 0.1, align: 'center' },
            { field: 'ADLJ01_SGDH', title: 'ADLJ01施工队号', width: $(this).width() * 0.1, align: 'center' },
            { field: 'ADLJ01_KZRQ', title: 'ADLJ01开钻日期', width: $(this).width() * 0.1, align: 'center' },
            { field: 'ADLJ01_WZRQ', title: 'ADLJ01完钻日期', width: $(this).width() * 0.1, align: 'center' },
            { field: 'ADLJ01_WJRQ', title: 'ADLJ01完井日期', width: $(this).width() * 0.1, align: 'center' },
            { field: 'ADLJ01_WZJS', title: 'ADLJ01完钻井深', width: $(this).width() * 0.1, align: 'center' },
            { field: 'ADLJ01_WZCS', title: 'ADLJ01完钻垂深', width: $(this).width() * 0.1, align: 'center' },
            { field: 'ADLJ01_WZCW', title: 'ADLJ01完钻层位', width: $(this).width() * 0.1, align: 'center' },
            { field: 'ADLJ01_WJFF', title: 'ADLJ01完井方法', width: $(this).width() * 0.1, align: 'center' },
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
            url: '../../Controllers/WJKPController.ashx?action=ImportExcel',    
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


//导出完井统计信息
function exportExcel() {
    var row = $("#dg").datagrid("getSelected");
    var JH = row["AJSJ01_JH"];
    $('#ExportIframe').attr("src", "../../../Page/DownLoad/DownLoad.aspx?Source=OutExportExcel_WJKP&JH=" + JH);
}

//导出
function exportExcelSJRZ() {
    console.log(str);
    $('#ExportIframe').attr("src", "../../../Page/DownLoad/DownLoad.aspx?Source=RYRZ_ExportExcel&str=" + escape(str));
}


function loadRemote_Home(bh) {
    $('#ff').form('load', '../../Controllers/WJKPController.ashx?action=WJKP_Home');
    //console.log($('#ff'));
}

function loadRemote_End() {

    $('#ff').form('load', '../../Controllers/WJKPController.ashx?action=WJKP_End');
}

function loadRemote_Up() {

    $('#ff').form('load', '../../Controllers/WJKPController.ashx?action=WJKP_Up&ID=' + $("#txtID").val());
}

function loadRemote_Down() {

    $('#ff').form('load', '../../Controllers/WJKPController.ashx?action=WJKP_Down&ID=' + $("#txtID").val());
}


function openDelWin() {
    $("#DelWin").window("open");
}
function closeDelWin() {
    $("#DelWin").window("close");
}

//删除
function delForm() {
    $('#ff').form('submit', {
        url: '../../Controllers/WJKPController.ashx?action=WJKP_Delete',
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
                loadRemote_Home();  // 重新载入当前页面数据 
                $('#dg').datagrid('reload');
                $('#dg2').datagrid('reload');
                closeDelWin(); //关闭窗口 

            }
            else {
                $.messager.alert('提示信息', data.Message, 'warning');
            }
        }
    });
}


function saveNDJZ() {
    $.ajax({
        type: "POST",
        url: '../../Controllers/WJKPController.ashx?action=insertNDJZ',
        data: { "ID": $('#txtID').val() },
        dataType: 'json',
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == "true") {

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



//修改
function submitForm() {
    $('#ff').form('submit', {
        url: '../../Controllers/WJKPController.ashx?action=WJKP_Update',
        success: function (data) {  //表单提交成功后的回调函数，里面参数data是我们调用/BasicClass/ModifyClassInfo方法的返回值。 
            console.log(data);
            var data = JSON.parse(data);
            console.log(typeof (data))
            if (data.IsSuccess == true) {
                $.messager.show({
                    title: '提示消息',
                    msg: data.Message,
                    showType: 'show',
                    timeout: 1000,
                    style: {
                        right: '',
                        bottom: ''
                    }
                });
                $('#dg').datagrid('reload');
                $('#dg2').datagrid('reload');
                loadRemote_Home();  // 重新载入当前页面数据  
            }
            else {
                $.messager.alert('提示信息', data.Message, 'warning');
            }
        }
    });
}
//function previewImageSGZ(file) {

//    $('#ff').form('submit', {
//        url: "../../Controllers/WJKPController.ashx?action=FileUpload",
//        onSubmit: function () {
//            return true;
//        },
//        success: function (msg) {
//            var msg = eval('(' + msg + ')');
//            $("#inputSGZ").val(msg.FileName);
//            console.log($("#inputSGZ").val());
//        }
//    });
//}
//function previewImageJCZ(file) {

//    $('#ff').form('submit', {
//        url: "../../Controllers/WJKPController.ashx?action=FileUpload",
//        onSubmit: function () {
//            return true;
//        },
//        success: function (msg) {
//            var msg = eval('(' + msg + ')');
//            $("#inputJCZ").val(msg.FileName);
//            console.log($("#inputJCZ").val());
//        }
//    });
//}
//function previewImageHSE(file) {

//    $('#ff').form('submit', {
//        url: "../../Controllers/WJKPController.ashx?action=FileUpload",
//        onSubmit: function () {
//            return true;
//        },
//        success: function (msg) {
//            var msg = eval('(' + msg + ')');
//            $("#inputHSE").val(msg.FileName);
//            console.log($("#inputHSE").val());

//        }
//    });    

//}
$("body").click(function checkPhoto(e) {
    if (e.target.id == "showPhotoHSE") {
        $("#previewHSE>img").attr("src", $("#inputHSE").val())
        $("#previewSGZ").css("display", "none");
        $("#previewJCZ").css("display", "none");
        if ($("#previewHSE").css("display", "none")) {
            $("#previewHSE").css("display", "block");
        } else {
            $("#previewHSE").css("display", "none")
        }
    } else if (e.target.id == "showPhotoSGZ") {
        $("#previewSGZ>img").attr("src", $("#inputSGZ").val())
        $("#previewJCZ").css("display", "none")
        $("#previewHSE").css("display", "none")
        if ($("#previewSGZ").css("display", "none")) {
            $("#previewSGZ").css("display", "block");
        } else {
            $("#previewSGZ").css("display", "none")
        }
    } else if (e.target.id == "showPhotoJCZ") {
        $("#previewJCZ>img").attr("src", $("#inputJCZ").val())
        $("#previewSGZ").css("display", "none")
        $("#previewHSE").css("display", "none")
        if ($("#previewJCZ").css("display", "none")) {
            $("#previewJCZ").css("display", "block");
        } else {
            $("#previewJCZ").css("display", "none")
        }
    } else if (e.target.id == "imgheadHSE" || e.target.id == "previewHSE") {
        $("#previewHSE").css("display", "block")
    } else if (e.target.id == "imgheadSGZ" || e.target.id == "previewSGZ") {
        $("#previewSGZ").css("display", "block")
    } else if (e.target.id == "imgheadJCZ" || e.target.id == "previewJCZ") {
        $("#previewJCZ").css("display", "block")
    } else {
        $("#previewHSE").css("display", "none");
        $("#previewSGZ").css("display", "none")
        $("#previewJCZ").css("display", "none")
    }

});


//点击回车触发搜索事件
$("body").keydown(function () {
    if (event.keyCode == "13") {//keyCode=13是回车键
        $('#sousuo').click();
    }
});


layui.use('upload', function () {
    var $ = layui.jquery
        , upload = layui.upload;

    //普通图片上传
    var uploadInstSGZ = upload.render({
        elem: '#previewImgSGZ'
        , url: '../../Controllers/WJKPController.ashx?action=FileUpload'
        , before: function (obj) {

        }
        , done: function (res) {
            console.log(res)
            $("#inputSGZ").val(res.FileName);
            $("#previewSGZ").html('<img src="' + res.FileName + '"/>')
            //如果上传失败
            if (res.code > 0) {
                return layer.msg('上传失败');
            }
            //上传成功
        }
        , error: function () {
            console.log('error')

        }
    });
    var uploadInstJCZ = upload.render({
        elem: '#previewImgJCZ'
        , url: '../../Controllers/WJKPController.ashx?action=FileUpload'
        , before: function (obj) {
            console.log(obj)
            $("#inputJCZ").val(obj.FileName);
        }
        , done: function (res) {
            $("#inputJCZ").val(res.FileName);
            $("#previewJCZ").html('<img src="' + res.FileName + '"/>')
            //如果上传失败
            if (res.code > 0) {
                return layer.msg('上传失败');
            }
            //上传成功
        }
        , error: function () {
            //console.log('error')

        }
    });
    var uploadInstHSE = upload.render({
        elem: '#previewImgHSE'
        , url: '../../Controllers/WJKPController.ashx?action=FileUpload'
        , before: function (obj) {

        }
        , done: function (res) {
            $("#inputHSE").val(res.FileName);
            $("#previewHSE").html('<img src="' + res.FileName + '"/>')
            //如果上传失败
            if (res.code > 0) {
                return layer.msg('上传失败');
            }
            //上传成功
        }
        , error: function () {
            console.log('error')

        }
    });
})


//点击查看打开pdf
function showPdf(a) {

    //console.log(a);
    window.open(a)
}
