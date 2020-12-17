$(function () {
    CountNum();
    map_init();
    ComboboxList();
})
var outputPath = 'maptile/';    //地图瓦片所在的文件夹
var fromat = ".jpg";    //格式
//声明地图
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
    if (xstj_2 != "" && tj_2 != "" && tj_4 != "''") {

        html += '<div class="groups"><span style="display:none">' + mark + '</span><span>' + xstj_2 + '</span><span>' + tj_3 + '</span><span>' + tj_4 + '</span><img class="close" onclick="closetj(this)" src="../../Image/no.png"/><p style="display:none">' + tj_2 + '</p></div>';
        $("#SelectWhere").append(html);
        $("#SelectColumn_List").combobox('setValue', '');
        $("#Symbol_List").combobox('setValue', '');
        $("#isvalue").textbox('setValue', '');
    }


}


function closetj(e) {
    $(e).parent().remove();
}

function ComboboxList() {
    $.ajax({
        url: '../../Controllers/ColumnListController.ashx?action=List_LJFGS',
        type: 'post',
        success: function (data) {
            var strList = [{ 'text': '全部', 'id': '' }];
            for (var i = 0; i < data.length; i++) {
                strList.push({ "text": data[i].NAME, "id": data[i].NAME });
            }
            $("#xmb").combobox("loadData", strList);
        }
    });
    $.ajax({
        url: '../../Controllers/ColumnListController.ashx?action=List_SC2',
        type: 'post',
        success: function (data) {
            var strList = [{ 'text': '全部', 'id': '' }];
            for (var i = 0; i < data.length; i++) {
                strList.push({ "text": data[i].NAME, "id": data[i].NAME });
            }
            $("#dq").combobox("loadData", strList);
        }
    });
    $.ajax({
        url: '../../Controllers/ColumnListController.ashx?action=List_TYPE',
        type: 'post',
        success: function (data) {
            var strList = [{ 'text': '全部', 'id': '' }];
            for (var i = 0; i < data.length; i++) {
                strList.push({ "text": data[i].NAME, "id": data[i].NAME });
            }
            $("#jb").combobox("loadData", strList);
        }
    });
}

////调用BD地图
function map_init() {
   
    if ($('#SelectWhere').children().length > 0) {
        $('#SelectWhere').children().each(function () {
            //console.log($(this));
            str += $(this).find("span").eq(0).html() + $(this).find("p").html() + $(this).find("span").eq(2).html() + $(this).find("span").eq(3).html();
        })

    }
    //console.log(str);
    //console.log(ljgs);
    $.ajax({
        type: "POST",
        url: "../../Controllers/MapController.ashx?action=MapList",
        data: {
            //'strWhere': str,
            //'LJFGS': ljgs
        },
        dataType: 'json',
        async: false,
        success: function (msg) {
            //console.log(msg)
            if (msg.IsSuccess == "true") {
                markerArr = msg.Data;
                console.log(markerArr)
                setMarkerArr(markerArr);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //console.log(errorThrown);
        }
    });

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

//--搜索
function search() {
     
    if ($('#SelectWhere').children().length > 0) {
        $('#SelectWhere').children().each(function () {
            //console.log($(this));
            str += $(this).find("span").eq(0).html() + $(this).find("p").html() + $(this).find("span").eq(2).html() + $(this).find("span").eq(3).html();
        })

    }

    $.ajax({
        type: "POST",
        url: "../../Controllers/MapController.ashx?action=MapList",
        data: {
            'JH': $("#isvalue").textbox('getValue')
        },
        dataType: 'json',
        async: false,
        success: function (msg) {
            markerArr = "";
            if (msg.IsSuccess == "true") {
                markerArr = msg.Data;
                //setMarkerArr(markerArr);
            }

            setMarkerArr(markerArr);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //console.log(errorThrown);
        }
    });

    
}


//--项目部选择
$('#xmb').combobox({
    onChange: function (n, o) {
        var ljgs = n;
       
        if ($('#SelectWhere').children().length > 0) {
            $('#SelectWhere').children().each(function () {
                //console.log($(this));
                str += $(this).find("span").eq(0).html() + $(this).find("p").html() + $(this).find("span").eq(2).html() + $(this).find("span").eq(3).html();
            })

        }

        $.ajax({
            type: "POST",
            url: "../../Controllers/MapController.ashx?action=MapList",
            data: {
                'LJFGS': ljgs
            },
            dataType: 'json',
            async: false,
            success: function (msg) {
                markerArr = "";
                if (msg.IsSuccess == "true") {
                    markerArr = msg.Data;
                    //setMarkerArr(markerArr);
                }

                setMarkerArr(markerArr);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //console.log(errorThrown);
            }
        });

       
    }
});

//--甲方单位选择
$('#jfdw').combobox({
    onChange: function (n, o) {
        var SC3 = n;
        
        if ($('#SelectWhere').children().length > 0) {
            $('#SelectWhere').children().each(function () {
                //console.log($(this));
                str += $(this).find("span").eq(0).html() + $(this).find("p").html() + $(this).find("span").eq(2).html() + $(this).find("span").eq(3).html();
            })

        }

        $.ajax({
            type: "POST",
            url: "../../Controllers/MapController.ashx?action=MapList",
            data: {
                'SC3': SC3
            },
            dataType: 'json',
            async: false,
            success: function (msg) {
                markerArr = "";
                if (msg.IsSuccess == "true") {
                    markerArr = msg.Data;
                    //setMarkerArr(markerArr);
                }

                setMarkerArr(markerArr);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //console.log(errorThrown);
            }
        });

        
    }
});

//--地区选择
$('#dq').combobox({
    onChange: function (n, o) {
        var SC2 = n;
        
        if ($('#SelectWhere').children().length > 0) {
            $('#SelectWhere').children().each(function () {
                //console.log($(this));
                str += $(this).find("span").eq(0).html() + $(this).find("p").html() + $(this).find("span").eq(2).html() + $(this).find("span").eq(3).html();
            })

        }

        $.ajax({
            type: "POST",
            url: "../../Controllers/MapController.ashx?action=MapList",
            data: {
                'SC2': SC2
            },
            dataType: 'json',
            async: false,
            success: function (msg) {
                //console.log(msg)
                markerArr = "";
                if (msg.IsSuccess == "true") {
                    markerArr = msg.Data;
                    //setMarkerArr(markerArr);
                }

                setMarkerArr(markerArr);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //console.log(errorThrown);
            }
        });

      
    }
});

//--井别选择
$('#jb').combobox({
    onChange: function (n, o) {
        var TYPE = n;
        
        if ($('#SelectWhere').children().length > 0) {
            $('#SelectWhere').children().each(function () {
                //console.log($(this));
                str += $(this).find("span").eq(0).html() + $(this).find("p").html() + $(this).find("span").eq(2).html() + $(this).find("span").eq(3).html();
            })

        }

        $.ajax({
            type: "POST",
            url: "../../Controllers/MapController.ashx?action=MapList",
            data: {
                'TYPE': TYPE
            },
            dataType: 'json',
            async: false,
            success: function (msg) {
                markerArr = "";
                if (msg.IsSuccess == "true") {
                    markerArr = msg.Data;
                    //setMarkerArr(markerArr);
                }

                setMarkerArr(markerArr);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //console.log(errorThrown);
            }
        });

         
    }
});

//--勘探点击
function KT_Click() {
    
    if ($('#SelectWhere').children().length > 0) {
        $('#SelectWhere').children().each(function () {
            //console.log($(this));
            str += $(this).find("span").eq(0).html() + $(this).find("p").html() + $(this).find("span").eq(2).html() + $(this).find("span").eq(3).html();
        })

    } 
    $.ajax({
        type: "POST",
        url: "../../Controllers/MapController.ashx?action=MapList",
        data: {
            "FL": "勘探"
        },
        dataType: 'json',
        async: false,
        success: function (msg) {
            //console.log(msg)
            markerArr = "";
            if (msg.IsSuccess == "true") {
                markerArr = msg.Data;
                //setMarkerArr(markerArr);
            }

            setMarkerArr(markerArr);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //console.log(errorThrown);
        }
    });

     
}

//--开发点击
function KF_Click() {
     
    if ($('#SelectWhere').children().length > 0) {
        $('#SelectWhere').children().each(function () {
            //console.log($(this));
            str += $(this).find("span").eq(0).html() + $(this).find("p").html() + $(this).find("span").eq(2).html() + $(this).find("span").eq(3).html();
        })

    }

    $.ajax({
        type: "POST",
        url: "../../Controllers/MapController.ashx?action=MapList",
        data: {
            "FL": "开发"
        },
        dataType: 'json',
        async: false,
        success: function (msg) {
            //console.log(msg)
            markerArr = "";
            if (msg.IsSuccess == "true") {
                markerArr = msg.Data;
                //setMarkerArr(markerArr);
            }

            setMarkerArr(markerArr);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //console.log(errorThrown);
        }
    });

     
}

//--正钻点击
function ZZ_Click() {
    
    if ($('#SelectWhere').children().length > 0) {
        $('#SelectWhere').children().each(function () {
            //console.log($(this));
            str += $(this).find("span").eq(0).html() + $(this).find("p").html() + $(this).find("span").eq(2).html() + $(this).find("span").eq(3).html();
        })

    }

    $.ajax({
        type: "POST",
        url: "../../Controllers/MapController.ashx?action=MapList",
        data: {
            "FL": "正钻"
        },
        dataType: 'json',
        async: false,
        success: function (msg) {
            //console.log(msg)
            markerArr = "";
            if (msg.IsSuccess == "true") {
                markerArr = msg.Data;
                //setMarkerArr(markerArr);
            }

            setMarkerArr(markerArr);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
             
        }
    });
     
}

//--待派点击
function DP_Click() {
     
    if ($('#SelectWhere').children().length > 0) {
        $('#SelectWhere').children().each(function () {
            //console.log($(this));
            str += $(this).find("span").eq(0).html() + $(this).find("p").html() + $(this).find("span").eq(2).html() + $(this).find("span").eq(3).html();
        })

    }

    $.ajax({
        type: "POST",
        url: "../../Controllers/MapController.ashx?action=MapList",
        data: {
            "SC3": $("#jfdw").combobox('getValue'),
            "LJFGS": $("#xmb").combobox('getValue'),
            "SC2": $("#dq").combobox('getValue'),
            "TYPE": $("#jb").combobox('getValue'),
            "FL": "待派"
        },
        dataType: 'json',
        async: false,
        success: function (msg) {
            //console.log(msg)
            markerArr = "";
            if (msg.IsSuccess == "true") {
                markerArr = msg.Data;
                //setMarkerArr(markerArr);
            }

            setMarkerArr(markerArr);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //console.log(errorThrown);
        }
    });

    
}

//--卫星点击
function WX_Click() {
     
    if ($('#SelectWhere').children().length > 0) {
        $('#SelectWhere').children().each(function () {
            //console.log($(this));
            str += $(this).find("span").eq(0).html() + $(this).find("p").html() + $(this).find("span").eq(2).html() + $(this).find("span").eq(3).html();
        })

    }

    $.ajax({
        type: "POST",
        url: "../../Controllers/MapController.ashx?action=MapList",
        data: {
            "SC3": $("#jfdw").combobox('getValue'),
            "LJFGS": $("#xmb").combobox('getValue'),
            "SC2": $("#dq").combobox('getValue'),
            "TYPE": $("#jb").combobox('getValue'),
            "FL": "卫星"
        },
        dataType: 'json',
        async: false,
        success: function (msg) {
            //console.log(msg)
            markerArr = "";
            if (msg.IsSuccess == "true") {
                markerArr = msg.Data;
                //setMarkerArr(markerArr);
            }

            setMarkerArr(markerArr);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //console.log(errorThrown);
        }
    });

    
}

//小地图中的动态svg


//添加小地图
$(function () {
    $("#btnYes").click(function () {
        //var showReact = $(".showReact") 
        //if (showReact.css("display") == "none") {
        //    showReact.css({
        //    "display": 'block',
        //    "top": '0px',
        //   // "right": '200px',
        //    "left":'0px'
        //    })
        //    $("#easy_map").css({
        //        "display": 'block',
        //        "top": '20px',
        //        // "right": '200px',
        //        "left": '65%'
        //    })
        //} else {
        //    showReact.css({
        //     "display":"none"
        //    })
        //}

        $("#easy_map").toggleClass("hide");
    })
    //$(".closeXDT").click(function () {
    //    $(".showReact").css("display", "none")
    //})
    ////拖放Api
    //var canMove = false;//开关
    //var offsetX, offsetY;
    //showRect.onmousedown = function (e) {
    //    canMove = true;
    //    offsetX = e.offsetX;
    //    offsetY = e.offsetY;
    //}
    //showRect.onmousemove = function (e) {
    //    if (canMove) {
    //        //e.clientX, e.clientY
    //        var left = e.pageX - offsetX;
    //        var top = e.pageY - offsetY;
    //        /* if (top == 99) { canMove = false; }
    //         //console.log(top)*/


    //        showRect.style.left = left + "px";
    //        showRect.style.top = top - 100 + "px";
    //        showRect.style.left = showRect.style.left <= 0 + "px" ? showRect.style.left = 0 + "px" : /*showRect.style.left >= 1200 + "px" ? showRect.style.left = 1200 + "px" :*/ showRect.style.left + "px";
    //        //showRect.style.left = showRect.style.left >= 1200 + "px" ? showRect.style.left = 1200 + "px" : showRect.style.left + "px";
    //        showRect.style.top = showRect.style.top <= 0 + "px" ? showRect.style.top = 0 + "px" :/*showRect.style.top>=248+"px"?showRect.style.top=248+"px":*/showRect.style.top + "px"
    //    }
    //    //if (showRect.style.left === 0 + "px" || showRect.style.top ===0+"px") {
    //    //          showRect.style.left =0+"px"
    //    //          canMove = false
    //    //    }      
    //    $("#smallMap_table input").focus(function () {
    //        canMove = false;
    //    })
    //    $("#smallMap_table td").click(function () {
    //        canMove = false;
    //    })
    //}
    //showRect.onmouseup = function () { canMove = false; }
    //showRect.ondragstart = function (e) {
    //    console.log('事件源p3开始拖动');
    //    //记录刚一拖动时，鼠标在飞机上的偏移量
    //    offsetX = e.offsetX;
    //    offsetY = e.offsetY;
    //}
    //showRect.ondrag = function (e) {
    //    console.log('事件源p3拖动中');
    //    var x = e.pageX;
    //    var y = e.pageY;
    //    console.log(x + '-' + y);
    //    //drag事件最后一刻，无法读取鼠标的坐标，pageX和pageY都变为0
    //    if (x == 0 && y == 0) {
    //        return; //不处理拖动最后一刻X和Y都为0的情形
    //    }
    //    x -= offsetX;
    //    y -= offsetY;

    //    showRect.style.left = x + 'px';
    //    showRect.style.top = y + 'px';
    //}
    //showRect.ondragend = function () {
    //    console.log('源对象p3拖动结束');
    //}


})
//点击图表上的X按钮
function clsEchartsMain() {
    $("#easy_map").addClass("hide");
}

//统计条参数
function CountNum() {
    $.ajax({
        type: "POST",
        url: "../../Controllers/MapController.ashx?action=CountNum",
        data: {
            //"FL": "卫星"
        },
        dataType: 'json',
        async: false,
        success: function (msg) {

            //console.log(msg);
            var Total = msg.Data;
            //var Qualified = msg.Qualified;
            //初始化echarts实例
            var myChart = echarts.init(document.getElementById('EChartsMain'));
            //设置图标配置项
            myChart.setOption({
                //title: {//标题
                //    text: '井位统计',
                //    x: 'left',
                //    y: 'top',
                //    textStyle: {
                //        color: '#1a5787'        // 值域文字颜色
                //    }
                //},
                tooltip: {
                    trigger: 'axis',
                    axisPointer: {            // 坐标轴指示器，坐标轴触发有效
                        type: 'shadow'        // 默认为直线，可选为：'line' | 'shadow'
                    }
                },
                //legend: {//数据类型
                //    //data: ['考核总人数','合格人数'],
                //    textStyle: {
                //        color: '#1a5787'           // 值域文字颜色
                //    }
                //},
                grid: {//图表边距
                    left: '3%',
                    right: '4%',
                    top: '5%',
                    bottom: '2%',
                    containLabel: true
                },
                xAxis: [//x轴
                    {
                        type: 'category',
                        axisTick: { show: true },
                        data: ['总井数', '正钻', '待派', '勘探', '开发'],
                        axisLabel: {
                            show: true,
                            textStyle: {
                                color: '#1a5787'
                            },
                            rotate: 30
                        },


                    }
                ],
                yAxis: [//y轴
                    {
                        type: 'value',
                        axisLabel: {
                            show: true,
                            textStyle: {
                                color: '#1a5787'
                            }
                        }
                    }
                ],
                series: [
                    {
                        name: '井数',
                        type: 'bar',
                        itemStyle: {
                            normal: {
                                //好，这里就是重头戏了，定义一个list，然后根据所以取得不同的值，这样就实现了，
                                color: function (params) {
                                    // build a color map as your need.
                                    var colorList = [
                                        '#C1232B', '#B5C334', '#FCCE10', '#E87C25', '#27727B',
                                        '#FE8463', '#9BCA63', '#FAD860', '#F3A43B', '#60C0DD',
                                        '#D7504B', '#C6E579', '#F4E001', '#F0805A', '#26C0C0'
                                    ];
                                    return colorList[params.dataIndex]
                                },
                                //以下为是否显示，显示位置和显示格式的设置了
                                label: {
                                    show: true,
                                    position: 'top',
                                    ////                             formatter: '{c}'
                                    //formatter: '{b}\n{c}'
                                }
                            }
                        },
                        data: Total

                    }
                ]
            });
            $("#Count_SY").val(Total[0]);
            $("#Count_ZZ").val(Total[1]);
            $("#Count_DP").val(Total[2]);
            $("#Count_KTDP").val(Total[3]);
            $("#Count_KF").val(Total[4]);
            //窗体自适应
            window.addEventListener("resize", function () {

                myChart.resize();

            });
            $("#easy_map").addClass("hide");
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            //console.log(errorThrown);
        }
    });
}





