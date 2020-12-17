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
    CZMC_Consistent();
    ZTMC_Consistent();
    //treeList();
    getGCJD();
    //selectNode();
    //JH_List();
    loadRemote_Home();

    var CZMC = $("#CZMC1").textbox('getValue');
    $("#CZMC2").textbox('setValue', CZMC);
    $("#CZMC3").textbox('setValue', CZMC);
    $("#CZMC4").textbox('setValue', CZMC);
    var ZTMC = $("#ZTMC1").textbox('getValue');
    $("#ZTMC2").textbox('setValue', ZTMC);
    dgList();
});



function Trim(str) {
    return str.replace(/(^\s*)|(\s*$)/g, "");
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
    });
    $('#dg').datagrid('reload');
}

//二级目录菜单--------------
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

//表单_井筒号下拉数据源
function JH_List() {
    $('#List_JH').combobox({
        valueField: 'JH',
        textField: 'JH',
        url: '../../Controllers/LJXMController.ashx?action=ZJH_List&REPORT_TYPE=' + pageJB
    });
}

//通过井筒号下拉值选择加载表单数据--------------
function getGCJD() {
    $('#List_JH').combobox({
        onChange: function (n, o) {
            $.ajax({
                type: "POST",
                url: "../../Controllers/GCJDController.ashx?action=GCJDInfoByJH",
                data: {
                    "JH": n
                },
                dataType: 'json',
                async: false,
                success: function (data) {
                    console.log(data)
                    $('#ff').form('load', data);
                    // SetCurrentTime();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    console.log(errorThrown);
                }
            });
        }
    });
}

//表格分页数据-------------------------
function dgList() {
    $('#dg').datagrid({
        loadMsg: '数据加载中......',
        fitColumns: false,
        fit: true,
        rownumbers: true,
        singleSelect: true,
        autoRowHeight: false,
        pagination: true,
        pageSize: 30,
        url: '../../Controllers/GCJDController.ashx?action=GCJDDataGrid',
        queryParams: { "REPORT_TYPE": pageJB },
        remoteSort: true,
        method: 'post',
        onLoadSuccess: function (data) {
            console.log(data)

        }

    });

}

//保存--------------------
function submitForm() {
    $('#ff').form('submit', {
        url: '../../Controllers/GCJDController.ashx?action=GCJD_Save',
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


//表单翻页功能
//--首页
function loadRemote_Home() {
    $('#ff').form('load', '../../Controllers/GCJDController.ashx?action=GCJDInfo_Home&REPORT_TYPE=' + pageJB);
}
//--尾页
function loadRemote_End() {
    $('#ff').form('load', '../../Controllers/GCJDController.ashx?action=GCJDInfo_End&REPORT_TYPE=' + pageJB);
}
//--上页
function loadRemote_Up() {
    $('#ff').form('load', '../../Controllers/GCJDController.ashx?action=GCJDInfo_Up&REPORT_TYPE=' + pageJB + '&JH=' + $('#txtJH').textbox('getValue') + '&JX=' + $('#List_JX').combobox('getText'));
}
//--下页
function loadRemote_Down() {
    $('#ff').form('load', '../../Controllers/GCJDController.ashx?action=GCJDInfo_Down&REPORT_TYPE=' + pageJB + '&JH=' + $('#txtJH').textbox('getValue') + '&JX=' + $('#List_JX').combobox('getText'));
    console.log($("#txtID").val())
}
//--删除
function delForm() {
    $.messager.confirm('提示框', '你确定要删除吗?', function () {
        $('#ff').form('submit', {
            url: '../../Controllers/GCJDController.ashx?action=GCJD_Del',
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
//--清理表单数据
function clearForm() {
    $('#ff').form('clear');
    //SetCurrentTime();
}

///侧钻名称一致
function CZMC_Consistent() {
    $('#CZMC1').combobox({
        onChange: function () {
            var str = $("#CZMC1").textbox('getValue');
            $("#CZMC2").textbox('setValue', str);
            $("#CZMC3").textbox('setValue', str);
            $("#CZMC4").textbox('setValue', str);

        }
    })
}

///中停名称一致
function ZTMC_Consistent() {
    $('#ZTMC1').combobox({
        onChange: function () {
            var str = $("#ZTMC1").textbox('getValue');
            $("#ZTMC2").textbox('setValue', str);

        }
    })
}

//设置日期显示格式
formatterDate = function (date) {

    var day = date.getDate() > 9 ? date.getDate() : "0" + date.getDate();

    var month = (date.getMonth() + 1) > 9 ? (date.getMonth() + 1) : "0"

        + (date.getMonth() + 1);

    return date.getFullYear() + '-' + month + '-' + day;

};

//设置日期为当前日期
//function SetCurrentTime()
//{
//    $('#DZLJKSSJ').datebox('setValue', formatterDate(new Date()));
//    $('#YXLJKSSJ').datebox('setValue', formatterDate(new Date()));
//    $('#QCLJKSSJ').datebox('setValue', formatterDate(new Date()));
//    $('#ZHLJKSSJ').datebox('setValue', formatterDate(new Date()));
//    $('#KZRQ').datebox('setValue', formatterDate(new Date()));
//    $('#GJRQ').datebox('setValue', formatterDate(new Date()));
//    $('#WZRQ').datebox('setValue', formatterDate(new Date()));
//    $('#WJRQ').datebox('setValue', formatterDate(new Date()));
//    $('#YJWJRQ').datebox('setValue', formatterDate(new Date()));
//    $('#CZKSLJSJ1').datebox('setValue', formatterDate(new Date()));
//    $('#CZKSLJSJ2').datebox('setValue', formatterDate(new Date()));
//    $('#CZJSSJ1').datebox('setValue', formatterDate(new Date()));
//    $('#CZJSSJ2').datebox('setValue', formatterDate(new Date()));
//    $('#CZKSLJSJ3').datebox('setValue', formatterDate(new Date()));
//    $('#CZJSSJ3').datebox('setValue', formatterDate(new Date()));
//    $('#ZTSJ1').datebox('setValue', formatterDate(new Date()));
//    $('#ZTJSSJ1').datebox('setValue', formatterDate(new Date()));
//    $('#ZTSJ2').datebox('setValue', formatterDate(new Date()));
//    $('#ZTJSSJ2').datebox('setValue', formatterDate(new Date()));
//    $('#ZTSJ3').datebox('setValue', formatterDate(new Date()));
//    $('#ZTJSSJ3').datebox('setValue', formatterDate(new Date()));
//    $('#STARSTART').datebox('setValue', formatterDate(new Date()));
//    $('#STAREND').datebox('setValue', formatterDate(new Date()));
//    $('#ZTJSSJ').datebox('setValue', formatterDate(new Date()));
//    $('#ZTKSSJ').datebox('setValue', formatterDate(new Date()));
//    $('#CZJSSJ').datebox('setValue', formatterDate(new Date()));
//    $('#GCFZCLSJ').datebox('setValue', formatterDate(new Date()));
//    $('#YJWJRQ').datebox('setValue', formatterDate(new Date()));

//}




//////////////////////////////////////////////////////导入功能star
//点击导入弹出窗口
function importbtn() {
    //加载时清除input type=file里的内容
    var obj = document.getElementById('FileUpload');
    obj.outerHTML = obj.outerHTML;
    $('#girdPreview').datagrid('loadData', { total: 0, rows: [] });
    //打开窗体
    $("#insert_dlg").dialog("open").dialog("setTitle", "工程进度信息导入");

}


//加载预览信息
function excelImport() {

    $('#jurSubsystemMenu').form('submit', {
        url: "../../Controllers/GCJDController.ashx?action=PreviewExcel",
        onSubmit: function () {
            return true;
        },
        success: function (msg) {
            rydata = JSON.parse(msg).list;
             
            $("#girdPreview").datagrid('loadData', rydata);
            start = 0;
            end = 10;

            $("#girdPreview").datagrid("getPager").pagination('refresh', {
                total: rydata.length,
                pageNumber: 1
            });

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
            { field: 'LJXL', title: '录井系列', width: 100, align: 'center' },
            { field: 'SJJS', title: '设计井深', width: 100, align: 'center' },
            { field: 'DRJS', title: '当前井深', width: 100, align: 'center' },
            { field: 'JX', title: '井型', width: 100, align: 'center' },
            { field: 'REPORT_TYPE', title: '井别', width: 100, align: 'center' },
            { field: 'QK', title: '区块', width: 100, align: 'center' },
            { field: 'SGZT', title: '当前动态', width: 100, align: 'center' },
            { field: 'DZLJKSJS', title: '地质录井开始井深', width: 100, align: 'center' },      
            { field: 'DZLJKSSJ', title: '地质录井开始时间', width: 100, align: 'center' },      
            { field: 'YXLJKSJS', title: '岩屑录井开始井深', width: 100, align: 'center' },      
            { field: 'YXLJKSSJ', title: '岩屑录井开始时间', width: 100, align: 'center' },      
            { field: 'QCLJKSJS', title: '气测录井开始井深', width: 100, align: 'center' },      
            { field: 'QCLJKSSJ', title: '气测录井开始时间', width: 100, align: 'center' },   
            { field: 'ZHLJKSJS', title: '综合录井开始井深', width: 100, align: 'center' },      
            { field: 'ZHLJKSSJ', title: '综合录井开始时间', width: 100, align: 'center' },      
            { field: 'JSSJJS', title: '加深设计井深', width: 100, align: 'center' },      
            { field: 'WZJS', title: '完钻井深', width: 100, align: 'center' },      
            { field: 'SJWZYZ', title: '设计完钻原则', width: 100, align: 'center' },      
            { field: 'WZYJ', title: '完钻依据', width: 100, align: 'center' },      
            { field: 'SJZZB', title: '实测纵坐标', width: 100, align: 'center' },      
            { field: 'SJHZB', title: '实测横坐标', width: 100, align: 'center' },      
            { field: 'DMHB', title: '地面海拔', width: 100, align: 'center' },      
            { field: 'BXG', title: '补心高', width: 100, align: 'center' },      
            { field: 'SGDW', title: '施工单位', width: 100, align: 'center' },      
            { field: 'SGDH', title: '施工队号', width: 100, align: 'center' },      
            { field: 'SGDDH', title: '施工队电话', width: 100, align: 'center' },      
            { field: 'LJFGS', title: '录井项目部', width: 100, align: 'center' },      
            { field: 'LJDH', title: '录井队号', width: 100, align: 'center' },      
            { field: 'KZRQ', title: '开钻日期', width: 100, align: 'center' },      
            { field: 'WZRQ', title: '完钻日期', width: 100, align: 'center' },      
            { field: 'GJRQ', title: '固井日期', width: 100, align: 'center' },      
            { field: 'WJRQ', title: '完井日期', width: 100, align: 'center' },      
            { field: 'ZYMDC', title: '主要目的层', width: 100, align: 'center' },      
            { field: 'WZCW', title: '完钻层位', width: 100, align: 'center' },      
            { field: 'WJFF', title: '完井方法', width: 100, align: 'center' },      
            { field: 'DYNZDJS', title: '分支点（第一年）井深', width: 100, align: 'center' },      
            { field: 'DENZDJS', title: '第二年钻达井深', width: 100, align: 'center' },      
            { field: 'SFJJYQXS', title: '是否见油气', width: 100, align: 'center' },      
            { field: 'SFQX', title: '是否取心', width: 100, align: 'center' },      
            { field: 'SFJSYQC', title: '解释油气层否', width: 100, align: 'center' },      
            { field: 'SFCXGCFZ', title: '是否出现工程复杂', width: 100, align: 'center' },      
            { field: 'CXGCFZLX', title: '出现工程复杂类型', width: 100, align: 'center' },      
            { field: 'GCFZCLSJ', title: '工程复杂处理时间', width: 100, align: 'center' },      
            { field: 'SFXYCTG', title: '下油套否', width: 100, align: 'center' },    
            { field: 'LJYQXH', title: '设备型号', width: 100, align: 'center' }, 
            { field: 'STARSTART', title: '装卫星时间', width: 100, align: 'center' }, 
            { field: 'STAREND', title: '拆卫星时间', width: 100, align: 'center' }, 
            { field: 'SFBF', title: '是否报废', width: 100, align: 'center' }, 
            { field: 'BFLX', title: '报废类型', width: 100, align: 'center' }, 
            { field: 'YJWJRQ', title: '预计完井日期', width: 100, align: 'center' },  
            { field: 'BZ', title: '工程备注', width: 100, align: 'center', fixed: true }


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
            url: '../../Controllers/GCJDController.ashx?action=GCJD_Import',
            data: { "Data": JSON.stringify(rydata) },
            dataType: 'json',
            success: function (msg) {
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
    $('#ExportIframe').attr("src", "../../../Page/DownLoad/DownLoad.aspx?Source=OutExportExcel_GCJD&str=" + str + "&REPORT_TYPE=" + pageJB);
}