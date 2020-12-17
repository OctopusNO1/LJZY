function Trim(str) {
    return str.replace(/(^\s*)|(\s*$)/g, "");
}
var pageJB = '';
$(function () {
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
    showDG(pageJB);
    loadRemote_Home();
    //BD();
    //getKJ();


    //全选功能
    $("#one_check").click(function () {

        //  console.log($("#one_check").prop("checked"))
        if ($("#one_check").prop("checked") === true)
            $(".one_check").attr("checked", "checked");
        else
            $(".one_check").attr("checked", false);
    })

    //第二个全选
    $("#two_check").click(function () {
        //  console.log($("#one_check").prop("checked"))
        if ($("#two_check").prop("checked") === true)
            $(".two_check").attr("checked", "checked");
        else
            $(".two_check").attr("checked", false);
    })

    //第三个全选
    $("#three_check").click(function () {
        //  console.log($("#one_check").prop("checked"))
        if ($("#three_check").prop("checked") === true)
            $(".three_check").attr("checked", "checked");
        else
            $(".three_check").attr("checked", false);
    })

})
//===解析链接参数
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}


//===单井设计表格列表

function showDG(type) {
    layui.use('table', function () {
        table = layui.table;
        //方法级渲染
        var tableIns = table.render({
            elem: '#dg'
            , url: '../../Controllers/DJSJController.ashx?action=DJSJDataGrid'
            , where: {
                'TYPE': type
            }
            , cols: [[
                { field: 'TROW', title: '序号', sort: true, align: 'center', width: 95 }
                , { field: 'JH', title: '井号', sort: true, align: 'center', width: 130 }
                , { field: 'REPORT_TYPE', title: '井别', sort: true, align: 'center', width: 100 }
                , { title: '井位设计', toolbar: '#barDemo1', align: 'center', width: 130 }
                , { title: '钻井地质设计', toolbar: '#barDemo2', align: 'center', width: 130 }
                , { title: '钻井工程设计', toolbar: '#barDemo3', align: 'center', width: 130 }
                , { title: '附件', toolbar: '#barDemo4', align: 'center', width: 130 }
                , { title: '设计讨论多媒体', toolbar: '#barDemo5', align: 'center', width: 130 }
                , { field: 'SJR', title: '设计人', width: '25%', align: 'center', width: 100 }
                , { field: 'SJRQ_DG', title: '设计日期', align: 'center', width: 150 }
                , { field: 'SPR', title: '审核人', align: 'center', width: 100 }
                , { field: 'SPRQ_DG', title: '审核日期', align: 'center', width: 150 }
                , { field: 'BZ', title: '备注', align: 'center', width: 200 }
            ]]
            , id: 'testReload'
            , page: true
            , height: 'full-80'
        });

        table.on('tool(toolDG)', function (obj) {
            var data = obj.data;
            if (obj.event === 'view') {
                showPdf(data.ZJH, '井位设计');
            }
            if (obj.event === 'view1') {
                showPdf(data.ZJH, '钻井地质设计');
            }
            if (obj.event === 'view2') {
                showPdf(data.ZJH, '钻井工程设计');
            }
            if (obj.event === 'view3') {
                openFileWin(data.ZJH, '附件');
            }
            if (obj.event === 'view4') {
                showPdf(data.ZJH, '设计讨论多媒体');
            }
            if (obj.event === 'download') {
                if (data.JWSJList.length > 0) {
                    $(this).attr("href", data.JWSJList[0].FILEURL)
                    layer.msg('提示：' + data.JWSJList[0].FILENAME + '正在下载');
                }

            }
            if (obj.event === 'download1') {
                if (data.ZJDZSJList.length > 0) {
                    $(this).attr("href", data.ZJDZSJList[0].FILEURL)
                    layer.msg('提示：' + data.ZJDZSJList[0].FILENAME + '正在下载');
                }
            }
            if (obj.event === 'download2') {
                if (data.ZJGCSJList.length > 0) {
                    $(this).attr("href", data.ZJGCSJList[0].FILEURL)
                    layer.msg('提示：' + data.ZJGCSJList[0].FILENAME + '正在下载');
                }
            }
            if (obj.event === 'download3') {
                FileWindown(data.ZJH, '附件');
            }
            if (obj.event === 'download4') {
                if (data.SJTLDMTList.length > 0) {
                    $(this).attr("href", data.SJTLDMTList[0].FILEURL)
                    layer.msg('提示：' + data.SJTLDMTList[0].FILENAME + '正在下载');
                }
            }
        });
        //$('.demoTable .layui-btn').on('click', function () {
        //    var type = $(this).data('type');
        //    active[type] ? active[type].call(this) : '';
        //});

    });
}
//function dgList() {
//    $('#dg').datagrid({
//        url: '../../Controllers/DJSJController.ashx?action=DJSJDataGrid',
//        loadMsg: '数据加载中......',
//        fitColumns: true,//使列适应窗体大小
//        fit: true,//使grid适应窗体大小
//        rownumbers: true,
//        singleSelect: true,
//        autoRowHeight: false,
//        pagination: true,
//        pageSize: 30,
//        columns: [[
//            { field: 'ZJH', title: '井号', align: 'center', width: 100 },
//            { field: 'JB', title: '井别', align: 'center', width: 100 },
//            {
//                field: 'JWSJ', title: "井位设计", align: 'center', width: 150,
//                formatter: function (val, rec) {
//                    if (rec != null) {
//                        var Type1 = "'井位设计'";
//                        if (rec.JWSJList.length > 0) {
//                            //url = "'../../PDFjs/web/viewer.html?file=../../UpLoad/玛湖63/2018/井位设计/1.pdf'";
//                            var x = '<a target="pdfContainer" onclick="showPdf(\'' + rec.ZJH + '\',' + Type1 + ')">查看';
//                            var y = '<a href="' + rec.JWSJList[0].FILEURL + '" download="' + rec.JWSJList[0].FILENAME + '" class="easyui-linkbutton"  plain="true">下载';
//                            return x + '&nbsp' + y;
//                        } else {
//                            var x = '<a target="pdfContainer" >查看';
//                            var y = '<a href="javascript:void(0);" class="easyui-linkbutton"  plain="true">下载';
//                            return x + '&nbsp' + y;
//                        }

//                    }
//                }

//            },
//            {
//                field: 'ZJDZSJ', title: '钻井地质设计', align: 'center', width: 150,
//                formatter: function (val, rec) {
//                    if (rec != null) {
//                        var Type2 = "'钻井地质设计'";

//                        if (rec.ZJDZSJList.length > 0) {

//                            var x = '<a target="pdfContainer" onclick="showPdf(\'' + rec.ZJH + '\',' + Type2 + ')">查看';
//                            var y = '<a href="' + rec.ZJDZSJList[0].FILEURL + '" download="' + rec.ZJDZSJList[0].FILENAME + '" class="easyui-linkbutton" plain="true">下载';
//                            return x + '&nbsp' + y;
//                        } else {
//                            var x = '<a target="pdfContainer" >查看';
//                            var y = '<a href="javascript:void(0);" class="easyui-linkbutton"  plain="true">下载';
//                            return x + '&nbsp' + y;
//                        }
//                    }
//                }

//            },
//            {
//                field: 'ZJGCSJ', title: '钻井工程设计', align: 'center', width: 150,
//                formatter: function (val, rec) {
//                    if (rec != null) {
//                        var Type3 = "'钻井工程设计'";
//                        if (rec.ZJGCSJList.length > 0) {

//                            var x = '<a target="pdfContainer" onclick="showPdf(\'' + rec.ZJH + '\',' + Type3 + ')">查看';
//                            var y = '<a href="' + rec.ZJGCSJList[0].FILEURL + '" download="' + rec.ZJGCSJList[0].FILENAME + '" class="easyui-linkbutton"  plain="true">下载';
//                            return x + '&nbsp' + y;
//                        } else {
//                            var x = '<a target="pdfContainer">查看';
//                            var y = '<a href="javascript:void(0);" class="easyui-linkbutton"  plain="true">下载';
//                            return x + '&nbsp' + y;
//                        }
//                    }
//                }
//            },
//            {
//                field: 'File', title: '附件', align: 'center', width: 150,
//                formatter: function (val, rec) {
//                    if (rec != null) {
//                        var Type4 = "'附件'";
//                        var x = '<a target="pdfContainer" onclick="openFileWin(\'' + rec.ZJH + '\',' + Type4 + ')">查看';
//                        var y = '<a href="javascript:void(0);" class="easyui-linkbutton"  plain="true" onclick="FileWindown(\'' + rec.ZJH + '\',' + Type4 + ')">下载';
//                        return x + '&nbsp' + y;
//                    }
//                }

//            },
//            {
//                field: 'SJTLDMT', title: '设计讨论多媒体', align: 'center', width: 150,
//                formatter: function (val, rec) {
//                    if (rec != null) {
//                        var Type5 = "'设计讨论多媒体'";
//                        if (rec.SJTLDMTList.length > 0) {

//                            var x = '<a target="pdfContainer" onclick="showPdf(\'' + rec.ZJH + '\',' + Type5 + ')">查看';
//                            var y = '<a href="' + rec.SJTLDMTList[0].FILEURL + '" download="' + rec.SJTLDMTList[0].FILENAME + '" class="easyui-linkbutton"  plain="true">下载';
//                            return x + '&nbsp' + y;
//                        } else {
//                            var x = '<a target="pdfContainer" >查看';
//                            var y = '<a href="javascript:void(0);" class="easyui-linkbutton"  plain="true">下载';
//                            return x + '&nbsp' + y;
//                        }
//                    }
//                }

//            },
//            { field: 'SJR', title: '设计人', align: 'center', width: 100 },
//            { field: 'SJRQ_DG', title: '设计日期', align: 'center', width: 150 },
//            { field: 'SPR', title: '审核人', align: 'center', width: 100 },
//            { field: 'SPRQ_DG', title: '审核日期', align: 'center', width: 150 },
//            { field: 'BZ', title: '备注', align: 'center', width: 100 },
//        ]]
//    });


//    $('#dg').datagrid('load', {
//        JB: pageJB
//    });
//}




//添加条件
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
            str += $(this).find("span").eq(0).html() + $(this).find("p").html() + $(this).find("span").eq(2).html() + $(this).find("span").eq(3).html();
        })
        //console.log(str);
    }

    //$('#dg').datagrid('load', {
    //    "strWhere": str,
    //});
    //$('#dg').datagrid('reload');
    table.reload('testReload', {
        page: {
            curr: 1 //重新从第 1 页开始
        }
        , where: {
            "strWhere": str,
            "REPORT_TYPE": pageJB
        }
    });
}


function loadRemote_Home() {
    //console.log(pageJB);
    $('#ff').form('load', '../../Controllers/DJSJController.ashx?action=DJSJInfo_Home&REPORT_TYPE=' + pageJB);
}

function loadRemote_End() {

    $('#ff').form('load', '../../Controllers/DJSJController.ashx?action=DJSJInfo_End&REPORT_TYPE=' + pageJB);
}

function loadRemote_Up() {
    // console.log($('#txtJH').textbox('getValue'));
    // console.log($('#List_JX').combobox('getText'));
    $('#ff').form('load', '../../Controllers/DJSJController.ashx?action=DJSJInfo_Up&REPORT_TYPE=' + pageJB + '&JH=' + $('#txtJH').textbox('getValue') + '&JX=' + $('#List_JX').combobox('getText'));
}

function loadRemote_Down() {
    //console.log($('#txtJH').textbox('getValue'));
    //console.log($('#List_JX').combobox('getText'));
    $('#ff').form('load', '../../Controllers/DJSJController.ashx?action=DJSJInfo_Down&REPORT_TYPE=' + pageJB + '&JH=' + $('#txtJH').textbox('getValue') + '&JX=' + $('#List_JX').combobox('getText'));
}

function clearForm() {
    $('#ff').form('clear');
    $('#ISLATESTRECORD').combobox('select',1);
    //formatterDate = function (date) {

    //    var day = date.getDate() > 9 ? date.getDate() : "0" + date.getDate();

    //    var month = (date.getMonth() + 1) > 9 ? (date.getMonth() + 1) : "0"

    //        + (date.getMonth() + 1);

    //    return date.getFullYear() + '-' + month + '-' + day;

    //};

    //$('#SJRQTime').datebox('setValue', formatterDate(new Date()));
    //$('#SPRQTime').datebox('setValue', formatterDate(new Date()));
}


function submitForm() {
    var ISFINISH = $('#ISFINISH').combobox('getValue');
    //console.log(ISFINISH);
    if (ISFINISH == 1) {
        $.messager.alert('提示信息', '派工完成状态无法操作!', 'warning');
        //$.messager.show({
        //    title: '提示消息',
        //    msg: '已派工状态无法操作!',
        //    showType: 'show',
        //    timeout: 1000,
        //    style: {
        //        right: '',
        //        bottom: ''
        //    }
        //});
        return false;

    } else {
        $('#ff').form('submit', {
            url: '../../Controllers/DJSJController.ashx?action=DJSJ_Save',
            //onSubmit: function () {        //表单提交前的回调函数 
            //    return $(this).form('enableValidation').form('validate');
            //},
            dataType: 'json',
            async: false,
            success: function (msg) {  //表单提交成功后的回调函数，里面参数data是我们调用/BasicClass/ModifyClassInfo方法的返回值。 
                var data = JSON.parse(msg);
                //console.log(data);

                //console.log(data.IsSuccess);
                //console.log(data.Message);
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
                    //$('#dg').datagrid('reload');
                    table.reload('testReload', {
                        page: {
                            curr: 1 //重新从第 1 页开始
                        }
                        , where: {
                            "strWhere": str,
                            "REPORT_TYPE": pageJB
                        }
                    });
                    window.parent.refreshTabData("任务列表", window.top.tt);
                    $('#Editwin').window('close'); //关闭窗口 
                }
                else {
                    $.messager.alert('提示信息', data.Message, 'warning');
                }
            }
        });
    }

}

////--删除
function delForm() {
    var de = '';
    var de = confirm('确定删除此条信息么！');
    if (de == true) {
        var str = $("#txtJH").textbox('getValue');
        $.ajax({
            type: "POST",
            url: "../../Controllers/DJSJController.ashx?action=DJSJ_Del",
            data: {
                "JH": str
            },
            dataType: 'json',
            async: false,
            success: function (data) {
                //var data = JSON.parse(meg);
                //console.log(data);
                if (data.IsSuccess == "true") {
                    $.messager.alert('提示信息', data.Message, 'warning');
                    loadRemote_Home();  // 重新载入当前页面数据 
                    //$('#dg').datagrid('reload');
                    table.reload('testReload', {
                        page: {
                            curr: 1 //重新从第 1 页开始
                        }
                        , where: {
                            "strWhere": str,
                            "REPORT_TYPE": pageJB
                        }
                    });
                }
                else {
                    $.messager.alert('提示信息', data.Message, 'warning');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //console.log(errorThrown);
            }
        });
    } else {
        return false;

    }

}
