$(function () {
    SB_LJFGSChange();
    RY_LJFGSChange();
    getDFPList();
    ryzgList();
    ryxzList();
    sbzgList();
    sbxzList();
    dzfzgList();
    dzfxzList();
    zfzgList();
    zfxzList();
    kfzgList();
    kfxzList();
    getESCount();//显示设备状态统计表
    getRYCount();//显示人员统计表
});

//#region ====待分配列表
function getDFPList() {
    $.ajax({
        type: 'Post',
        url: "../../Controllers/SCPGController.ashx?action=JHList_DFP",
        dataType: 'json',
        async: false,
        success: function (data) {
            console.log(data)
            var ktList = data.KTJ;
            var pjList = data.PJJ;
            var kfList = data.KFJ;
            $('#kt').datagrid({
                singleSelect: true,
                autoRowHeight: false,
                pageSize: 5,
                data: ktList,
                onLoadSuccess: function (data) {
                    console.log(data)

                },
                columns: [[
                    { field: 'TROW', align: 'center', width: '30%', title: '序号' },
                    { field: 'JH', align: 'center', width: '75%', title: '井号' }
                ]],
                onClickRow: function () {    //单击进行操作的方法
                    var row = $('#kt').datagrid('getSelected');//获取选中行的数据 
                    $('#file_JH').text(row.JH);
                    $('#map_JH').text(row.JH);
                    $('#txtJH').textbox('setValue', row.JH);
                    rySelect();
                    sbSelect();
                    dzfSelect();
                    zfSelect();
                    kfSelect();
                    getMap(row.JH);
                    getFile(row.JH);
                }
            });

            $('#pj').datagrid({
                //singleSelect: true,
                autoRowHeight: false,
                pageSize: 5,
                data: pjList,
                onLoadSuccess: function (data) {
                    console.log(data)
                },
                columns: [[
                    { field: 'TROW', align: 'center', width: 80, title: '序号' },
                    { field: 'JH', align: 'center', width: 145, title: '井号' }
                ]],
                onClickRow: function () {    //单击进行操作的方法
                    var row = $('#pj').datagrid('getSelected');//获取选中行的数据 
                    $('#file_JH').text(row.JH);
                    $('#map_JH').text(row.JH);
                    $('#txtJH').textbox('setValue', row.JH);
                    rySelect();
                    sbSelect();
                    dzfSelect();
                    zfSelect();
                    kfSelect();
                    getMap(row.JH);
                    getFile(row.JH);
                }
            });

            $('#kf').datagrid({
                //singleSelect: true,
                autoRowHeight: false,
                pageSize: 5,
                data: kfList,
                onLoadSuccess: function (data) {
                    console.log(data)

                },
                columns: [[
                    { field: 'TROW', align: 'center', width: 80, title: '序号' },
                    { field: 'JH', align: 'center', width: 145, title: '井号' }
                ]],
                onClickRow: function () {    //单击进行操作的方法
                    var row = $('#kf').datagrid('getSelected');//获取选中行的数据 
                    $('#file_JH').text(row.JH);
                    $('#map_JH').text(row.JH);
                    $('#txtJH').textbox('setValue', row.JH);
                    rySelect();
                    sbSelect();
                    dzfSelect();
                    zfSelect();
                    kfSelect();
                    getMap(row.JH);
                    getFile(row.JH);
                }
            });
        }
    })
}
//#endregion

//#region ==人员调配


function rySelect() {

    var JH = $("#txtJH").textbox('getValue');
    var GW = $("#workerGW").combobox('getValue');
    var TJ = $("#workerTJ").combobox('getValue');
    var KW = $("#keyWords").textbox('getValue');

    $('#getWorkerL').datagrid({
        queryParams: {
            'JH': JH,
            'strGW': GW,
            'strColumn': TJ,
            'strWhere': KW
        }
    });

    $('#getWorkerR').datagrid({
        queryParams: {
            'strGW': GW,
            'strColumn': TJ,
            'strWhere': KW
        }

    });

}


function ryzgList() {
    $('#getWorkerL').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=RYZG_List',
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', align: 'center', checkbox: true },
            { field: 'RYBH', align: 'center', title: '员工编号', width: 80 },
            { field: 'XM', align: 'center', title: '员工姓名', width: 120 },
            { field: 'XMB', align: 'center', title: '所属项目部', width: 100 },
            { field: 'GW', align: 'center', title: '岗位', width: 100 },
            { field: 'LXDH', align: 'center', title: '电话', width: 100 },
            { field: 'JH', align: 'center', title: '人员状态', width: 100 },
            { field: 'BZ', align: 'center', title: '备注', width: 100 }
        ]]

    });
}

function ryxzList() {
    $('#getWorkerR').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=RYXZ_List',
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', align: 'center', checkbox: true },
            { field: 'RYBH', align: 'center', title: '员工编号', width: 80 },
            { field: 'XM', align: 'center', title: '员工姓名', width: 100 },
            { field: 'XMB', align: 'center', title: '所属项目部', width: 100 },
            { field: 'GW', align: 'center', title: '岗位', width: 100 },
            { field: 'LXDH', align: 'center', title: '电话', width: 100 },
            { field: 'JH', align: 'center', title: '人员状态', width: 100 },
            { field: 'BZ', align: 'center', title: '备注', width: 100 }
        ]]
    });

}


//待派转在岗
function CheckDataL() {
    var rybh = [];
    var rows = $('#getWorkerR').datagrid('getSelections');
    for (var i = 0; i < rows.length; i++) {
        rybh.push(rows[i].RYBH);
    }
    var JH = $("#txtJH").textbox('getValue');
    console.log(rybh);
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=RYFPTo_ZG',
        data: {
            'ToZGJson': JSON.stringify(rybh),
            'JH': JH
        },
        dataType: "json",
        async: false,
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getWorkerL").datagrid('reload');
                $("#getWorkerR").datagrid('reload');

            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}
//在岗转待派
function CheckDataR() {
    var rybh = [];
    var rows = $('#getWorkerL').datagrid('getSelections');
    for (var i = 0; i < rows.length; i++) {
        rybh.push(rows[i].RYBH);
    }
    var JH = $("#txtJH").textbox('getValue');
    console.log(rybh);
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=RYFPTo_DP',
        data: {
            'ToDPJson': JSON.stringify(rybh),
            'JH': JH
        },
        dataType: "json",
        async: false,
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getWorkerL").datagrid('reload');
                $("#getWorkerR").datagrid('reload');

            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}

//#endregion 

//#region ===设备调配


function sbSelect() {

    var JH = $("#txtJH").textbox('getValue');
    var sbFL = $("#equipmentFL").combobox('getValue');
    var TJ = $("#equipmentTJ").combobox('getValue');
    var KW = $("#keyEquipment").textbox('getValue');

    $('#getEquipmentL').datagrid({
        queryParams: {
            'JH': JH,
            'strFL': sbFL,
            'strColumn': TJ,
            'strWhere': KW
        }
    });

    $('#getEquipmentR').datagrid({
        queryParams: {
            'strFL': sbFL,
            'strColumn': TJ,
            'strWhere': KW
        }

    });

}

function sbzgList() {
    $('#getEquipmentL').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=SBZY_List',
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', align: 'center', checkbox: true },
            { field: 'CCBH', align: 'center', title: '设备型号', width: 80 },
            { field: 'SBMC', align: 'center', title: '设备名称', width: 80 },
            { field: 'SBFL', align: 'center', title: '设备分类', width: 80 },
            { field: 'SBZK', align: 'center', title: '设备状态', width: 60 },
            { field: 'JH', align: 'center', title: '设备所在位置', width: 80 },
            { field: 'BZ', align: 'center', title: '备注', width: 100 }
        ]]

    });
}

function sbxzList() {
    $('#getEquipmentR').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=SBXZ_List',
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', align: 'center', checkbox: true },
            { field: 'CCBH', align: 'center', title: '设备型号', width: 80 },
            { field: 'SBMC', align: 'center', title: '设备名称', width: 80 },
            { field: 'SBFL', align: 'center', title: '设备分类', width: 80 },
            { field: 'SBZK', align: 'center', title: '设备状态', width: 60 },
            { field: 'BZ', align: 'center', title: '备注', width: 100 }
        ]]
    });

}

//闲置转在用
function CheckEquipmentL() {
    var rows = $('#getEquipmentR').datagrid('getSelections');
    var sbpb = [];
    var jh = '', sbmc = '', sbfl = '';
    //console.log(1);
    for (var i = 0; i < rows.length; i++) {
        jh = rows[i].JH;
        sbid = rows[i].SBID;
        sbfl = rows[i].SBFL;
        sbpb.push({ "JH": jh, "SBID": sbid, "SBFL": sbfl })
    }
    var JH = $("#txtJH").textbox('getValue');
    // console.log(sbpb);
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=SBFPToZY',
        data: {
            'ToZYJson': JSON.stringify(sbpb),
            'JH': JH
        },
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getEquipmentL").datagrid('reload');
                $("#getEquipmentR").datagrid('reload');

            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
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
    //console.log(sbpb);
    var JH = $("#txtJH").textbox('getValue');
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=SBFPToXZ',
        data: {
            'ToZYJson': JSON.stringify(sbpb),
            'JH': JH
        },
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getEquipmentL").datagrid('reload');
                $("#getEquipmentR").datagrid('reload');
                //getSBPB();
            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}

//#endregion 

//#region ===地质房调配

function dzfSelect() {

    var JH = $("#txtJH").textbox('getValue');
    var dzfFL = $("#equipmentFL").combobox('getValue');
    var TJ = $("#equipmentTJ").combobox('getValue');
    var KW = $("#keyEquipment").textbox('getValue');

    $('#getDZFL').datagrid({
        queryParams: {
            'JH': JH,
            'FL': '地质房'
        }
    });

    $('#getDZFR').datagrid({
        queryParams: {
            'FL': '地质房'
        }

    });

}

function dzfzgList() {
    $('#getDZFL').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=FWZY_List',
        queryParams: {
            'FL': '地质房',
        },
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', align: 'center', checkbox: true },
            { field: 'GGXH', align: 'center', title: '地质房型号', width: 80 },
            { field: 'CCBH', align: 'center', title: '地质房编号', width: 80 },
            { field: 'SBZK', align: 'center', title: '地质房状况', width: 80 },
            { field: 'JH', align: 'center', title: '使用地点', width: 80 },
            { field: 'BZ', align: 'center', title: '备注', width: 100 }
        ]]

    });
}

function dzfxzList() {
    $('#getDZFR').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=FWXZ_List',
        queryParams: {
            'FL': '地质房',
        },
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', align: 'center', checkbox: true },
            { field: 'GGXH', align: 'center', title: '地质房型号', width: 80 },
            { field: 'CCBH', align: 'center', title: '地质房编号', width: 80 },
            { field: 'SBZK', align: 'center', title: '地质房状况', width: 80 },
            //{ field: 'JH', align: 'center', title: '使用地点', width: 80 },
            { field: 'BZ', align: 'center', title: '备注', width: 100 }
        ]]
    });

}


function CheckDZFL() {
    var rows = $('#getDZFR').datagrid('getSelections');
    var dzfpb = [];
    var zjh = '', sbmc = '', sbfl = '';
    for (var i = 0; i < rows.length; i++) {
        fwid = rows[i].FWID;
        dzfpb.push({ "FWID": fwid })
    }
    var JH = $("#txtJH").textbox('getValue');
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=FWFPToZY',
        data: {
            'ToZYJson': JSON.stringify(dzfpb),
            'JH': JH
        },
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getDZFL").datagrid('reload');
                $("#getDZFR").datagrid('reload');
                //getDZFPB();
            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}
//在用地质房转闲置
function CheckDZFR() {
    var dzfpb = [];
    var rows = $('#getDZFL').datagrid('getSelections');
    var zjh = '', sbmc = '', sbfl = '';

    for (var i = 0; i < rows.length; i++) {
        fwid = rows[i].FWID;
        dzfpb.push({ "FWID": fwid })
    }
    var JH = $("#txtJH").textbox('getValue');
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=FWFPToXZ',
        data: {
            'ToZYJson': JSON.stringify(dzfpb),
            'JH': JH
        },
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getDZFL").datagrid('reload');
                $("#getDZFR").datagrid('reload');
                //getDZFPB();
            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}
//#endregion

//#region ===住房调配

function zfSelect() {

    var JH = $("#txtJH").textbox('getValue');

    $('#getZFL').datagrid({
        queryParams: {
            'JH': JH,
            'FL': '住房'
        }
    });

    $('#getZFR').datagrid({
        queryParams: {
            'FL': '住房'
        }

    });

}

function zfzgList() {
    $('#getZFL').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=FWZY_List',
        queryParams: {
            'FL': '住房',
        },
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', align: 'center', checkbox: true },
            { field: 'GGXH', align: 'center', title: '地质房型号', width: 80 },
            { field: 'CCBH', align: 'center', title: '地质房编号', width: 80 },
            { field: 'SBZK', align: 'center', title: '地质房状况', width: 80 },
            { field: 'JH', align: 'center', title: '使用地点', width: 80 },
            { field: 'BZ', align: 'center', title: '备注', width: 100 }
        ]]

    });
}

function zfxzList() {
    $('#getZFR').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=FWXZ_List',
        queryParams: {
            'FL': '住房',
        },
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', align: 'center', checkbox: true },
            { field: 'GGXH', align: 'center', title: '地质房型号', width: 80 },
            { field: 'CCBH', align: 'center', title: '地质房编号', width: 80 },
            { field: 'SBZK', align: 'center', title: '地质房状况', width: 80 },
            //{ field: 'JH', align: 'center', title: '使用地点', width: 80 },
            { field: 'BZ', align: 'center', title: '备注', width: 100 }
        ]]
    });

}


//闲置住房转在用
function CheckZFL() {
    var rows = $('#getZFR').datagrid('getSelections');
    var zfpb = [];
    var zjh = '', sbmc = '', sbfl = '';
    for (var i = 0; i < rows.length; i++) {
        fwid = rows[i].FWID;
        zfpb.push({ "FWID": fwid })
    }
    var JH = $("#txtJH").textbox('getValue');
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=FWFPToZY',
        data: {
            'ToZYJson': JSON.stringify(zfpb),
            'JH': JH
        },
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getZFL").datagrid('reload');
                $("#getZFR").datagrid('reload');
                //getZFPB();
            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}
//在用住房转闲置
function CheckZFR() {
    var zfpb = [];
    var rows = $('#getZFL').datagrid('getSelections');
    var zjh = '', sbmc = '', sbfl = '';

    for (var i = 0; i < rows.length; i++) {
        fwid = rows[i].FWID;
        zfpb.push({ "FWID": fwid })
    }
    var JH = $("#txtJH").textbox('getValue');
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=FWFPToXZ',
        data: {
            'ToZYJson': JSON.stringify(zfpb),
            'JH': JH
        },
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getZFL").datagrid('reload');
                $("#getZFR").datagrid('reload');
                //getZFPB();
            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}
//#endregion


//#region ===库房调配

function kfSelect() {

    var JH = $("#txtJH").textbox('getValue');

    $('#getKFL').datagrid({
        queryParams: {
            'JH': JH,
            'FL': '库房'
        }
    });

    $('#getKFR').datagrid({
        queryParams: {
            'FL': '库房'
        }

    });

}

function kfzgList() {
    $('#getKFL').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=FWZY_List',
        queryParams: {
            'FL': '库房',
        },
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', align: 'center', checkbox: true },
            { field: 'GGXH', align: 'center', title: '地质房型号', width: 80 },
            { field: 'CCBH', align: 'center', title: '地质房编号', width: 80 },
            { field: 'SBZK', align: 'center', title: '地质房状况', width: 80 },
            { field: 'JH', align: 'center', title: '使用地点', width: 80 },
            { field: 'BZ', align: 'center', title: '备注', width: 100 }
        ]]

    });
}

function kfxzList() {
    $('#getKFR').datagrid({
        url: '../../Controllers/LJXMController.ashx?action=FWXZ_List',
        queryParams: {
            'FL': '库房',
        },
        rownumbers: true,
        singleSelect: false,
        autoRowHeight: true,
        columns: [[
            { field: 'ck', align: 'center', checkbox: true },
            { field: 'GGXH', align: 'center', title: '地质房型号', width: 80 },
            { field: 'CCBH', align: 'center', title: '地质房编号', width: 80 },
            { field: 'SBZK', align: 'center', title: '地质房状况', width: 80 },
            //{ field: 'JH', align: 'center', title: '使用地点', width: 80 },
            { field: 'BZ', align: 'center', title: '备注', width: 100 }
        ]]
    });

}


//闲置库房转在用
function CheckKFL() {
    var rows = $('#getKFR').datagrid('getSelections');
    var kfpb = [];
    var jh = '', sbmc = '', sbfl = '';
    for (var i = 0; i < rows.length; i++) {
        fwid = rows[i].FWID;
        kfpb.push({ "FWID": fwid })
    }
    var JH = $("#txtJH").textbox('getValue');
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=FWFPToZY',
        data: {
            'ToZYJson': JSON.stringify(kfpb),
            'JH': JH
        },
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getKFL").datagrid('reload');
                $("#getKFR").datagrid('reload');
                //getKFPB();
            } else {
                $.messager.alert('提示:', msg.Message);
            }
        }
    })
}
//在用库房转闲置
function CheckKFR() {
    var kfpb = [];
    var rows = $('#getKFL').datagrid('getSelections');
    var zjh = '', sbmc = '', sbfl = '';

    for (var i = 0; i < rows.length; i++) {
        fwid = rows[i].FWID;
        kfpb.push({ "FWID": fwid })
    }
    var JH = $("#txtJH").textbox('getValue');
    $.ajax({
        type: "POST",
        url: '../../Controllers/LJXMController.ashx?action=FWFPToXZ',
        data: {
            'ToZYJson': JSON.stringify(kfpb),
            'JH': JH
        },
        dataType: "json",
        success: function (msg) {
            console.log(msg);
            if (msg.IsSuccess == 'true') {
                $("#getKFL").datagrid('reload');
                $("#getKFR").datagrid('reload');
                //getKFPB();
            } else {
                $.messager.alert('提示:', msg.Message);
            }
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
            console.log(msg);
            if (msg.FileName != "" && msg.FileName !=null) {
                if (msg.View == 1) {
                   
                    var fhtml = '<iframe width="100%" height="98%" src="' + msg.FileURL + '" frameborder="0" id="fileList_iframe" seamless=""></iframe>'
                    $("#fileList").html(fhtml);
                } else {
                   
                    var fhtml = ' <span class="filename" title="' + msg.FileName + '">' + msg.FileName + '</span><a href="' + msg.FileURL + '" class="layui-btn layui-btn-primary layui-btn-xs" download="">下载</a>'
                    $("#fileList").html(fhtml);
                }

            } else {
                var fhtml="<span>暂无上传文件</span>"
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

//#region ====设备动态统计
function SB_LJFGSChange() {
    $('#SB_LJFGS').combobox({
        onChange: function () {
            getESCount()
        }
    })
}

//显示设备状态统计表
function getESCount() {
    var LJFGS = $("#SB_LJFGS").combobox('getValue');
    console.log(LJFGS);
    $.ajax({
        type: 'post',
        url: "../../Controllers/LJXMController.ashx?action=SBFW_CountList",
        data: {
            'LJFGS': LJFGS
        },
        dataType: 'json',
        async: false,
        success: function (msg) {

            $('#ESCount').datagrid({
                //singleSelect: true,
                autoRowHeight: false,
                pageSize: 5,
                data: msg,
                onLoadSuccess: function (data) {
                    console.log(data)
                },
                columns: [[
                    { field: 'TYPE', align: 'center', width: '80', title: '类别' },
                    { field: 'ZHY', align: 'center', width: '100', title: '综合仪(气测)' },
                    { field: 'DZF', align: 'center', width: '100', title: '地质房' },
                    { field: 'YQF', align: 'center', width: '100', title: '仪器房' },
                    { field: 'ZF', align: 'center', width: '100', title: '住房' },
                    { field: 'KF', align: 'center', width: '100', title: '库房' }
                ]]

            });
        }

    })
}

function RY_LJFGSChange() {
    $('#RY_LJFGS').combobox({
        onChange: function () {
            getRYCount()
        }
    })
}

//显示人员统计表
function getRYCount() {
    var LJFGS = $("#RY_LJFGS").combobox('getValue');
    console.log(LJFGS);
    $.ajax({
        type: 'post',
        url: "../../Controllers/LJXMController.ashx?action=RY_CountList",
        data: {
            'LJFGS': LJFGS
        },
        dataType: 'json',
        async: false,
        success: function (msg) {

            $('#RYCount').datagrid({
                singleSelect: true,
                autoRowHeight: false,
                pageSize: 5,
                data: msg,
                onLoadSuccess: function (data) {
                    console.log(data)
                },
                columns: [[
                    { field: 'TYPE', align: 'center', width: '80', title: '类别' },
                    { field: 'LJDZS', align: 'center', width: '100', title: '录井地质师' },
                    { field: 'LJGCS', align: 'center', width: '100', title: '录井工程师' },
                    { field: 'CZY', align: 'center', width: '100', title: '操作员' },
                    { field: 'DZG', align: 'center', width: '100', title: '地质工' },
                    { field: 'SXS', align: 'center', width: '100', title: '实习生' },
                    { field: 'DZZL', align: 'center', width: '100', title: '地质助理' },
                    { field: 'KFJDZS', align: 'center', width: '100', title: '开发井地质师' }
                ]]

            });
        }

    })
}
//#endregion


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