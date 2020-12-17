var app = new Vue({
    el: "#SCDT",
    data: {
        tips: false,
        position: 'absolute',
        top: 0,
        left: 0,
        XMList: [],
        lineHeight: 40,
        XMBList: [],
        XMBName: '',
        LJFGS: '',
        changeData: '',
        changeTime: '',
        changeTIME: '',
        SGDHList: '',
        
    },
    
//    var _this = this;           
//$.ajax({
//    type: "POST",
//    url: "../../Controllers/SCDTController.ashx?action=SCDT_List",
//    data: { LJFGS: _this.XMBName, Time: $('#datecheckbox').datebox('getValue') },
//    dataType: "json",
//    success: function (msg) {
//        // console.log(msg)
//        _this.changeTime = $('#datecheckbox').datebox('getValue');
//        //console.log(msg, "日期：" + $('#datecheckbox').datebox('getValue'))   
//        //console.log(msg);

//        _this.XMList = msg;
//        if (msg.data !== 'undefined' && msg.data !== null && msg.data !== '') {
//            var dataList = '';
//            dataList = { "code": msg.code, "count": msg.count, "msg": msg.msg, "data": msg.data }
//        }
//        layui.use('table', function () {
//            var table = layui.table;

//            table.render({
//                elem: '#test'
//                , data: dataList.data
//                , page: false
//                , limit: 999999
//                , width: $(document.body).width() - 100 + 'px'
//                , height: $(document.body).height() - 200 + 'px'
//                , cols: [[
//                      { field: 'XQXMB', width: 120, title: '辖区项目部', fixed: 'left' }
//                    , { field: 'TROW', width: 100, title: '序号', fixed: 'left' }
//                    , { field: 'DWZBH', width: 100, title: '编号', fixed: 'left' }
//                    , { field: 'LJYQXH', width: 120, title: '仪器' }
//                    , { field: 'ZJH', width: 100, title: '井号' }
//                    , { field: 'LJDH', width: 100, title: '录井队号' }
//                    , { field: 'SGDH', width: 100, title: '施工队号' }
//                    , { field: 'XDT', width: 100, title: '井动态' }
//                    , { field: 'SJJS', width: 100, title: '设计井深' }
//                    , { field: 'DRJS', width: 100, title: '当日井深', }
//                    , { field: 'KZRQ', width: 100, title: '开钻日期' }
//                    , { field: 'YJWJRQ', width: 100, title: '预计完井日期' }
//                    , { field: 'HXJW', width: 120, title: '录井后续井位' }
//                    , { field: 'HXJDH', width: 100, title: '录井后续钻井队号' }
//                    , { field: 'JDDT', width: 100, title: '钻井队动态' }
//                    , { field: 'HXJW', width: 120, title: '钻井队后续井' }
//                    , { field: 'JB', width: 100, title: '井别' }
//                    , { field: 'LJFGS', width: 100, title: '隶属' }
//                    , { field: 'DQZT', width: 100, title: '状态' }
//                    , { field: 'BZ', width: 100, title: '备注', fixed: 'right' }
//                ]]
                           
                           
//            });
//        });

//    }
//})
    methods: {
        getData: function () {
            var _this = this;
            var SELECT_XMB = $("#SELECT_XMB option:selected");
            console.log(SELECT_XMB.text())

            $.ajax({
                type: "POST",
                url: "../../Controllers/SCDTController.ashx?action=SCDT_List",
                data: { LJFGS: _this.XMBName, Time: $('#datecheckbox').datebox('getValue') },
                dataType: "json",
                success: function (msg) {
                     console.log(msg)
                            _this.changeTime = $('#datecheckbox').datebox('getValue');
                            //console.log(msg, "日期：" + $('#datecheckbox').datebox('getValue'))   
                            //console.log(msg);

                            _this.XMList = msg;
                            if (msg.data !== 'undefined' && msg.data !== null && msg.data !== '') {
                                var dataList = '';
                                dataList = { "code": msg.code, "count": msg.count, "msg": msg.msg, "data": msg.data }
                            }
                            layui.use('table', function () {
                                var table = layui.table;

                                table.render({
                                    elem: '#test'
                                    , data: dataList.data
                                    , page: false
                                    , limit: 999999
                                    , width: $(document.body).width() - 100 + 'px'
                                    , height: $(document.body).height() - 200 + 'px'
                                    , cols: [[
                                        { field: 'XQXMB', width: 120, title: '辖区项目部', fixed: 'left', align: 'center' }
                                        , { field: 'TROW', width: 100, title: '序号', fixed: 'left', align: 'center'}
                                        , { field: 'DWZBH', width: 100, title: '编号', fixed: 'left', align: 'center'}
                                        , { field: 'LJYQXH', width: 120, title: '仪器', align: 'center'}
                                        , { field: 'ZJH', width: 100, title: '井号', align: 'center' }
                                        , { field: 'LJDH', width: 100, title: '录井队号', align: 'center' }
                                        , { field: 'SGDH', width: 100, title: '施工队号', align: 'center' }
                                        , { field: 'XDT', width: 100, title: '井动态', align: 'center'}
                                        , { field: 'SJJS', width: 100, title: '设计井深', align: 'center'}
                                        , { field: 'DRJS', width: 100, title: '当日井深', align: 'center' }
                                        , { field: 'KZRQ', width: 100, title: '开钻日期', align: 'center'}
                                        , { field: 'YJWJRQ', width: 120, title: '预计完井日期', align: 'center'}
                                        , { field: 'HXJW', width: 120, title: '录井后续井位', align: 'center' }
                                        , { field: 'HXJDH', width: 150, title: '录井后续钻井队号', align: 'center' }
                                        , { field: 'JDDT', width: 120, title: '钻井队动态', align: 'center'}
                                        , { field: 'HXJW', width: 120, title: '钻井队后续井', align: 'center' }
                                        , { field: 'REPORT_TYPE', width: 100, title: '井别', align: 'center'}
                                        , { field: 'LJFGS', width: 100, title: '隶属', align: 'center'}
                                        , { field: 'DQZT', width: 100, title: '状态', align: 'center' }
                                        , { field: 'BZ', width: 100, title: '备注', fixed: 'right', align: 'center' }
                                    ]]


                                });
                            });
                }
            })
        },
        getXMB: function () {
            _this = this;
            $.ajax({
                type: "POST",
                url: "../../Controllers/ColumnListController.ashx?action=List_LJFGS",
                dataType: "json",
                success: function (msg) {
                    console.log(msg);
                    _this.XMBList = msg;
                }
            })
        },


    },
    created: function () {
        var that = this; 
        that.getXMB();
    },

})



//导出
function exportExcel() {
    //console.log($("#ff"))
    //console.log($('#SELECT_XMB option:selected')[0].value, $('#SELECT_XMB option:selected'))
    $('#ExportIframe').attr("src", "../../../Page/DownLoad/DownLoad.aspx?Source=OutExportExcel_SCDT& LJFGS=" + $('#SELECT_XMB option:selected').val() + "&Time=" + $('#datecheckbox').datebox('getValue'));
}
