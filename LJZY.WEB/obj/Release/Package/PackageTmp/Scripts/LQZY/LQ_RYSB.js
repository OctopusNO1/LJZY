var app = new Vue({
    el: "#RYSB",
    data: {
        tips: false,
        position: 'absolute',
        top: 0,
        left: 0,
        list: [],
        count: [],
        XMBList: [],
        XMBName: '',
        //LJFGS: '',
        lis: [],
        changeDATA: '',
        RYList:'',
        DataTime: '',
        one: '#one',
        DZS: '#DZS',
        JGY: '#JGY',
        SBGLHSJ: '#SBGLHSJ',
        KF: '#KF',
        ZRS:'#ZRS',
        DZG1: '#DZG1',
        showEye:false
    },
    methods: {
        getData: function (XMB, Time) {
            _this = this;
            //  console.log(_this.XMBName, $('#datecheckbox').datebox('getValue'));
            // console.log(this);
            $.ajax({
                type: "POST",
                url: "../../Controllers/RYSBController.ashx?action=RYSB_List",
                data: { LJFGS: XMB, Time: $('#datecheckbox').datebox('getValue') },
                dataType: "json",
                success: function (msg) {
                     console.log(msg)
                    _this.DataTime = $('#datecheckbox').datebox('getValue');
                    // console.log(msg, $('#datecheckbox').datebox('getValue'))
                    _this.list = msg.List;
                    _this.count = msg.ListCount;
                    var dataList = msg.List;
                    var countList = msg.ListCount;
                    //数据表格
                    layui.use('table', function () {
                        var table = layui.table;

                        table.render({
                            elem: '#tableData'
                            , data: dataList
                            , page: false
                            , limit: 999999
                            // ,toolbar: true
                            //, width: $(document.body).width() - 100 + 'px'$(document.body).height() - 200 + 'px'
                            , height: $(document.body).height()-250+ 'px'
                           , totalRow: true
                           // ,page:true
                            , cols: [[
                                  
                                  { field: 'TROW', width: 120, align: 'center', unresize: true, fixed: 'left', rowspan: 2, sort: true, totalRowText: '合计', title: '序号', rowspan: 2 }
                                   //, { field: 'XQXMB', width: 100, align: 'center', title: '辖区项目部', rowspan: 2, totalRowText: '0' }
                                , { field: 'DWZBH', width: 100, align: 'center', title: '自编号', rowspan: 2, totalRowText: countList.DWZBHCount }
                                , { field: 'LJDH', width: 100, align: 'center', title: '队号', rowspan: 2, totalRowText: countList.LJDHCount }
                                , { field: 'LJYQXH', width: 120, align: 'center', title: '仪器型号', rowspan: 2, totalRowText: countList.LJYQXHCount }
                                , { field: 'JH', width: 100, align: 'center', title: '正录井', rowspan: 2, totalRowText: countList.ZJHCount }
                                , { field: 'SGDH', width: 100, align: 'center', title: '钻井队', rowspan: 2, totalRowText: countList.SGDHCount }
                                , { field: 'DQZT', width: 100, align: 'center', title: '设备状态', rowspan: 2, totalRowText: countList.DQZTCount }
                                , { field: 'HXJW', width: 100, align: 'center', title: '待录井', rowspan: 2, totalRowText: countList.HXJWCount }
                                , { field: 'Dzs', width: 100, align: 'center', title: '地质师', rowspan: 2, totalRowText: countList.DzsCount }
                                , { field: 'Dzzl', width: 100, align: 'center', title: '地质助理', rowspan: 2, totalRowText: countList.DzzlCount }
                                , { field: 'Gcs', width: 100, align: 'center', title: '工程师', rowspan: 2, totalRowText: countList.GcsCount }
                                , { field: '', width: 100, align: 'center', title: '操作员', colspan: 3, totalRowText: countList.DWZBHCount }
                                , { field: '', width: 120, align: 'center', title: '地质工', colspan: 4, totalRowText: countList.DzgListCount }
                                , { field: '', width: 100, align: 'center', title: '住房', colspan: 2, totalRowText: countList.ZfListCount }
                                , { field: 'Dzf', width: 100, align: 'center', title: '地质房', rowspan: 2, totalRowText: countList.DzfListCount }
                                , { field: 'SBSZD', width: 120, align: 'center', title: '设备所在地', fixed: 'right', rowspan: 2 }
                                
                            ], [
                                    { field: 'Czy1', width: 120, title: '一', align: 'center'  }
                                , { field: 'Czy2', width: 100, title: '二',align:'center' }
                                    , { field: 'Czy3', width: 100, title: '三', align: 'center' }
                                    , { field: 'Dzg1', width: 120, title: '一', align: 'center' }
                                , { field: 'Dzg2', width: 120, title: '二',align:'center'}
                                    , { field: 'Dzg3', width: 120, title: '三', align: 'center' }
                                    , { field: 'Dzg4', width: 120, title: '四', align: 'center' }
                                , { field: 'Zf1', width: 120, title: '一',align:'center' }
                                    , { field: 'Zf2', width: 120, title: '二', align: 'center' }
                            ]

                            ],
                        })
                    })
                  //  console.log($('.laytable-cell-1-0-10').html())
                }
            })

        

        },
        //showTable: function () {
        //    $('#tableContent').toggle();
        //},
        showEyeClick: function () {
            //$('#tableContent').toggle();
            //this.showEye = true;
          
            // this.showEye ==false?true:false
            var that = this;
            if (this.showEye == false) {
                that.showEye = true
                $('#tableContent').css('display','block')
            } else {
                this.showEye = false
                $('#tableContent').css('display', 'none')
            }
        },
        FOR1: function (data) {
            //console.log(data)
            var that = this;
            var len = 8;
            if (len > data.LD_List.length) {
                len = data.LD_List.length
            }
           
            for (var i = 0 ; i < len; i++) {
               
                $('#LD' + i + '').val(data.LD_List[i].XM)
               
            }       
        },
        //地质师
        FOR2: function (data) {
            var that = this;
            var len = 30
            if (len > data.Dzs_List.length) {
                len = data.Dzs_List.length
            }
            for (var i = 0 ; i < len; i++) {               
                $('.DZS' + i+'').val(data.Dzs_List[i].XM)
            }
        },
        //设备管理和设计
        FOR3: function (data) {
            var that = this;
            var len = 8;
            if (len > data.SBGL_List.length) {
                len = data.SBGL_List.length
            }
            for (var i = 0; i < len; i++) {
                $('.SBGL' + i + '').val(data.SBGL_List[i].XM)
            }
        },
        //经管员
        FOR4: function (data) {
            var that = this;
            var len = 8;
            if (len > data.JGY_List.length) {
                len = data.JGY_List.length
            }
            for (var i = 0; i < len; i++) {
                $('#JGY' + i).val(data.JGY_List[i].XM)
            }
        },
      
        //责任师
        FOR6: function (data) {
            var that = this;
            var len = 8;
            if (len > data.ZRS_List.length) {
                len = data.ZRS_List.length;
            }
            for (var i = 0; i < len;i++){
                $('.ZRS' + i).val(data.ZRS_List[i].XM)
            }
        },
        //工程师
        FOR7: function (data) {
            var len = 30;
            if (len > data.Gcs_List.length) {
                len = data.Gcs_List.length;
            }
            for (var i = 0; i <len;i++){
                $('.GCS' + i).val(data.Gcs_List[i].XM)
            }
        },
        //KF_List 开发
        FOR5: function (data) {
            var that = this;
            var html = '';
            for (var i = 0 ; i < 10; i++) {
                if (data.KF_List.length == 0) {
                    if (i < data.KF_List.length) {
                        // console.log(data.LD_List)
                        html += '<td><input type="text" name="name" value="' + data.KF_List[i].XM + '" /></td>'
                        // console.log(html)
                    } else {
                        html += '<td></td>'
                    }
                } else {
                    html += '<td></td>'
                }
            }

            $(that.KF).after(html)
        },
        //操作员
        FOR8: function (data) {
            var len = 50;
            if (len > data.Czy_List.length) {
                len = data.Czy_List.length;
            }
            for (var i = 0; i < len;i++){
                $('#CZY' + i).val(data.Czy_List[i].XM)
            }
        },
        FOR9: function (data) {
            var len = 20;
            if (len > data.Dzg_List.length) {
                len = data.Dzg_List.length;
            }
            for (var i = 0; i < len;i++){
                $('#DZG' + i).val(data.Dzg_List[i].XM)
            }
        },
        get: function () {
            var that = this;
            $.ajax({
                type: 'post',
                url: '../../Controllers/RYSBController.ashx?action=RY_List',
                dataType: 'json',
                success: function (data) {
                    console.log(data)
                    that.FOR1(data);
                    that.FOR2(data);
                    that.FOR3(data);
                    that.FOR4(data);
                    that.FOR5(data);
                    that.FOR6(data);
                   // that.FOR7(data);
                    that.FOR8(data);
                    that.FOR9(data);
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
                  //  console.log(msg)
                    _this.XMBList = msg;
                }
            })
        },
     
        CommitData: function () {
            _this = this;

           // console.log(_this.XMBName, $('#datecheckbox').datebox('getValue'));

            _this.getData(_this.XMBName, $('#datecheckbox').datebox('getValue'))
        }
    },
    created: function () {
  
        _this = this;
        $("#RYSBTitle").val('人员及设备动态表');
        _this.get()
        _this.getXMB();
        //_this.changeXMB();
        setTimeout(function () {
            _this.getData();
           
        }, 1000);

        // })
    },
    watch: {
        "changeDATA": function (n, o) {
           // console.log(n)
        }
    },
    mounted: function () {
        console.log($('.laytable-cell-1-0-10').html())
    }

})

//导出
function exportExcel() {

   // console.log($("#ff"))
    $('#ExportIframe').attr("src", "../../../Page/DownLoad/DownLoad.aspx?Source=OutExportExcel_RYSB&LJFGS=" + $("#SELECT_OPTION option:selected").val() + "&Time=" + $('#datecheckbox').datebox('getValue'));
}