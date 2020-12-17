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

        DataTime: '',

    },
    methods: {
        getData: function (XMB, Time) {
            _this = this;
            console.log(_this.XMBName, $('#datecheckbox').datebox('getValue'));
            console.log(this);
            $.ajax({
                type: "POST",
                url: "../../Controllers/RYSBController.ashx?action=RYSB_List",
                data: { LJFGS: XMB, Time: $('#datecheckbox').datebox('getValue') },
                dataType: "json",
                success: function (msg) {
                    console.log(msg)
                    _this.DataTime = $('#datecheckbox').datebox('getValue');
                    console.log(msg, $('#datecheckbox').datebox('getValue'))
                    _this.list = msg.List;
                    _this.count = msg.ListCount;

                    //flow.load({
                    //    elem: '#LAY_demo2' //流加载容器
                    //    //, scrollElem: '#LAY_demo2' //滚动条所在元素，一般不用填，此处只是演示需要。
                    //    , isAuto: false
                    //    , isLazyimg: true
                    //    , done: function (page, next) { //加载下一页
                    //        //模拟插入
                    //        setTimeout(function () {
                    //            for (var i = 0; i < 10; i++) {
                    //                _this.list.push(_this.lis[i])



                    //                //lis.push('<li><img lay-src="http://s17.mogucdn.com/p2/161011/upload_279h87jbc9l0hkl54djjjh42dc7i1_800x480.jpg?v=' + ((page - 1) * 6 + i + 1) + '"></li>')
                    //            }
                    //            next(_this.list.join(''), page < _this.lis.length/10); //假设总页数为 6
                    //        }, 500);
                    //    }
                    //});
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
                    console.log(msg)
                    _this.XMBList = msg;
                }
            })
        },
        //changeXMB: function () {
        //    _this = this;
        //    console.log(_this.XMBName);
        //    _this.getData(_this.XMBName)
        //    //$("#dataList > tbody table td").css({ "border-top": "none", "border-bottom": "none" });
        //    setTimeout(function () {
        //        //$(".tableBody table").css("border", "none")
        //        $(".tableBody table").each(function () {
        //            $(this).find("tr").not(":has(td)").html('<td><input type="text" name="" value="" /></td>')
        //            $(this).find("td").css({ "border-top": "none", "border-bottom": "none" });
        //            $(this).find("td:first").css("border-left", "none");
        //            $(this).find("td:last").css("border-right", "none")
        //        })

        //    }, 50)
        //},
        CommitData: function () {
            _this = this;

            console.log(_this.XMBName, $('#datecheckbox').datebox('getValue'));

            _this.getData(_this.XMBName, $('#datecheckbox').datebox('getValue'))



        }


    },

    created: function () {
        //layui.use('flow', function(){
        //    var flow = layui.flow;
        console.log('使用vue');
        _this = this;
        $("#RYSBTitle").val('人员及设备动态表');

        _this.getXMB();
        //_this.changeXMB();
        setTimeout(function () {
            _this.getData();
        }, 1000);

        // })
    },
    watch: {
        "changeDATA": function (n, o) {
            console.log(n)
        }
    },
})

//导出
function exportExcel() {

    console.log($("#ff"))
    $('#ExportIframe').attr("src", "../../../Page/DownLoad/DownLoad.aspx?Source=OutExportExcel_RYSB&LJFGS=" + $("#SELECT_OPTION option:selected").val() + "&Time=" + $('#datecheckbox').datebox('getValue'));
}