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
        url: '../../Controllers/RYSJKController.ashx?action=RYSJK_DataGrid',
        loadMsg: '数据加载中......',
        fitColumns: false,//使列适应窗体大小
        fit: false,//使grid适应窗体大小
        rownumbers: true,
        singleSelect: true,
        autoRowHeight: true,
        pagination: true,
        pageSize: 20,
        columns: [[
            { field: 'XMB', title: '所属项目部', align: 'center', width: 100 },
            { field: 'GW', title: '岗位类别', align: 'center', width: 100 },
            { field: 'RYBH', title: '人员编号', align: 'center', width: 100 },
            { field: 'XM', title: "姓名", align: 'center', width: 100, },
            { field: 'LXDH', title: '联系电话', align: 'center', width: 150 },
            { field: 'XB', title: '性别', align: 'center', width: 100 },
            { field: 'NL', title: '年龄', align: 'center', width: 100 },  
            { field: 'XL', title: '学历', align: 'center', width: 100 },
            { field: 'YGXZ', title: '用工性质', align: 'center', width: 100 },
            { field: 'JKZK', title: '健康状况', align: 'center', width: 100 },
            { field: 'ZC', title: '职称', align: 'center', width: 100 },
            { field: 'RYZT', title: '人员状态', align: 'center', width: 100 },
            { field: 'NDSJTS', title: '年度上井天数', align: 'center', width: 100 },
            { field: 'SJJH', title: '上井井号', align: 'center', width: 100 },
            { field: 'KSSJRQ_DG', title: '开始上井日期', align: 'center', width: 100 },
            { field: 'JSSJRQ_DG', title: '结束上井日期', align: 'center', width: 100 },
            { field: 'GWXS', title: '岗位系数', align: 'center', width: 100 }, 
            {
                field: 'JCZIMAGE', title: '井控证', align: 'center', width: 100,
                formatter: function (val, rec) {
                    if (rec != null) {
                        if (rec.JCZIMG != null) {
                            var x = '<a target="pdfContainer" onclick="showPdf(\'' + rec.JCZIMG + '\')">查看';
                            return x;
                        } else {
                            var x = '<a target="pdfContainer">查看';

                            return x;
                        }

                    }
                }

            },
            {
                field: 'HSEIMG', title: '安全环保健康证(HSE)', align: 'center', width: 100,
                formatter: function (val, rec) {
                    if (rec != null) {
                        if (rec.HSEIMG != null) {
                            //console.log(rec.HSEIMG);
                            var x = '<a target="pdfContainer" onclick="showPdf(\'' + rec.HSEIMG + '\')">查看';
                            return x;
                        } else {
                            var x = '<a target="pdfContainer">查看';

                            return x;
                        }

                    }
                }},
            {
                field: 'SGZIMG', title: '上岗证', align: 'center', width: 100,
                formatter: function (val, rec) {
                    if (rec != null) {
                        if (rec.SGZIMG != null) {
                            var x = '<a target="pdfContainer" onclick="showPdf(\'' + rec.SGZIMG + '\')">查看';
                            return x;
                        } else {
                            var x = '<a target="pdfContainer">查看';

                            return x;
                        }

                    }
                }
            },   
            { field: 'BZ', title: '备注', align: 'center', width: 150 },

        ]]
    });

    $('#dg2').datagrid({
        url: '../../Controllers/RYSJKController.ashx?action=SJRZ_DataGrid',
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
                field: 'KSSJRQ', title: "开始上井时间", align: 'center', width: 100, formatter: function (val)
                {
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

function formattime(val) {
    //console.log(val);
    var str = val.substr(0, 10);
    if (str =="0001-01-01") {
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
    $("#insert_dlg").dialog("open").dialog("setTitle", "人员信息导入");

}

//加载预览信息
function excelImport() {


    $('#jurSubsystemMenu').form('submit', {
        url: "../../Controllers/RYSJKController.ashx?action=PreviewExcel",
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
            { field: 'XMB', title: '所属项目部', width: $(this).width() * 0.1, align: 'center' },
            { field: 'GW', title: '岗位类别', width: $(this).width() * 0.1, align: 'center' },
            { field: 'XM', title: '姓名', width: $(this).width() * 0.1, align: 'center'},
            { field: 'LXDH', title: '联系电话', width: $(this).width() * 0.1, align: 'center' },
            { field: 'XB', title: '性别', width: $(this).width() * 0.1, align: 'center'},
            { field: 'NL', title: '年龄', width: $(this).width() * 0.1, align: 'center' },
            { field: 'XL', title: '学历', width: $(this).width() * 0.1, align: 'center' },
            { field: 'YGXZ', title: '用工性质', width: $(this).width() * 0.1, align: 'center'},
            { field: 'JKZK', title: '健康状况', width: $(this).width() * 0.1, align: 'center'},
            { field: 'ZC', title: '职称', width: $(this).width() * 0.1, align: 'center'},
            //{ field: 'RYZT', title: '人员状态', width: $(this).width() * 0.1, align: 'center' },
            //{ field: 'NDSJTS', title: '年度上井天数', width: $(this).width() * 0.1, align: 'center' },      
            { field: 'BZ', title: '备注', width: $(this).width() * 0.1, align: 'center' },


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
            url: '../../Controllers/RYSJKController.ashx?action=ImportExcel',
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
   // console.log(str);
    $('#ExportIframe').attr("src", "../../../Page/DownLoad/DownLoad.aspx?Source=OutExportExcel&str=" + escape(str));
}

//导出
function exportExcelSJRZ() {
    console.log(str);
    $('#ExportIframe').attr("src", "../../../Page/DownLoad/DownLoad.aspx?Source=RYRZ_ExportExcel&str=" + escape(str));
}


function loadRemote_Home(bh) {
    $('#ff').form('load', '../../Controllers/RYSJKController.ashx?action=RYSJK_Home');
    //console.log($('#ff'));
}

function loadRemote_End() {

    $('#ff').form('load', '../../Controllers/RYSJKController.ashx?action=RYSJK_End');
}

function loadRemote_Up() {

    $('#ff').form('load', '../../Controllers/RYSJKController.ashx?action=RYSJK_Up&ID=' + $("#txtID").val());
}

function loadRemote_Down() {

    $('#ff').form('load', '../../Controllers/RYSJKController.ashx?action=RYSJK_Down&ID=' + $("#txtID").val());
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
        url: '../../Controllers/RYSJKController.ashx?action=RYSJK_Delete',
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


function saveNDJZ()
{
    $.ajax({
        type: "POST",
        url: '../../Controllers/RYSJKController.ashx?action=insertNDJZ',
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
        url: '../../Controllers/RYSJKController.ashx?action=RYSJK_Update',
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
//        url: "../../Controllers/RYSJKController.ashx?action=FileUpload",
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
//        url: "../../Controllers/RYSJKController.ashx?action=FileUpload",
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
//        url: "../../Controllers/RYSJKController.ashx?action=FileUpload",
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
    }else if (e.target.id == "imgheadHSE" || e.target.id == "previewHSE") {
        $("#previewHSE").css("display", "block")
    }else if (e.target.id == "imgheadSGZ" || e.target.id == "previewSGZ") {
        $("#previewSGZ").css("display", "block")
    } else if (e.target.id == "imgheadJCZ" || e.target.id == "previewJCZ") {
        $("#previewJCZ").css("display", "block")
    }else {
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
      , url: '../../Controllers/RYSJKController.ashx?action=FileUpload'
        , before: function (obj) {
           
      }
      , done: function (res) {
          console.log(res)
          $("#inputSGZ").val(res.FileName);
          $("#previewSGZ").html('<img src="'+res.FileName+'"/>')
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
      , url: '../../Controllers/RYSJKController.ashx?action=FileUpload'
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
      , url: '../../Controllers/RYSJKController.ashx?action=FileUpload'
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
