
$(function () {
    //GetHistoryList();
    //showJWDH();
    GetUserLastHistory();
});

//获取历史记录
//function GetHistoryList() {

//    html = '';
//    $.ajax({
//        type: "POST",
//        url: "../../Controllers/IndexController.ashx?action=GetHistoryList",
//        dataType: 'json',
//        success: function (msg) {
//            //console.log(msg);
//            if (msg) {
//                msg = eval('(' + msg + ')');
//                if (msg.IsSuccess == "true") {
//                    data = eval('(' + msg.Message + ')');
//                    //console.log(data);
//                    setTbody(data);
//                }
//            }
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {

//        }
//    });
//}


function setTbody(data) {

    setList(data);
    function setList(data) {
        $.each(data, function (index, h) {

            html += '<li id="' + h.ID + '"><a  href="javascript:void(0)" onclick="showTab(\'' + h.URL + '\',\'' + h.TITLE + '\')">' + h.TITLE + " " + h.TIME + '</a><a href="javascript:void(0)" onclick="Delhist(\'' + h.ID + '\')" style="margin-left:10px">×</a></li>';
        })
    }
    $('#his_list').html(html);

}




//添加历史记录
function histListADD(url, title) {

    $.ajax({
        type: "POST",
        url: "../../Controllers/IndexController.ashx?action=addHistory",
        data: {
            "URL": url,
            "TITLE": title
        },
        dataType: 'json',
        async: false,
        success: function (msg) {
            //console.log(msg)
            if (msg.IsSuccess == "true") {
                markerArr = msg.Data;
                //console.log(markerArr)
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}


//删除历史记录

function Delhist(id) {

    $.ajax({
        type: "POST",
        url: "../../Controllers/IndexController.ashx?action=DeleteHistory",
        data: {
            "ID": id
        },
        dataType: 'json',
        async: false,
        success: function (msg) {
            // console.log(msg)
            if (msg.IsSuccess == "true") {
                markerArr = msg.Data;
                // console.log(markerArr)
                GetHistoryList();
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}





//动态添加标签页
function showTab(url,parentAll,title) {
    var tab = $('#tab');
    if (tab.tabs('exists', parentAll)) {
        tab.tabs('select', parentAll);
    }
    else {
        tab.tabs('add', {
            title: parentAll,
            content: "<iframe scrolling='auto' frameborder='0' src='"
                + url + "' style='width:100%;height:100%;padding:0px 3px 0px 3px;'/>",
            closable: true,
            tools: [{
                iconCls: 'icon-mini-refresh',
                handler: function () {
                    var selectTab = $('#tab').tabs('getSelected');
                    tab.tabs('update', {
                        tab: selectTab,
                        options: {
                            href: url
                        }
                    })
                }
            }]

        });

    }
}

function showJWDH() {
    var tab = $('#tab');
    tab.tabs('add', {
        title: "井位导航",
        content: "<iframe scrolling='auto' frameborder='0' src='Page/DJSJ/LQ_JWDH.aspx' style='width:100%;height:100%;padding:0px 0px 3px 0px;'/>",
        closable: true,
        tools: [{
            iconCls: 'icon-mini-refresh',
            handler: function () {
                var selectTab = $('#tab').tabs('getSelected');
                tab.tabs('update', {
                    tab: selectTab,
                    options: {
                        href: 'Page/DJSJ/LQ_JWDH.aspx'
                    }
                })
            }
        }]
    });
}

//获取用户最后浏览的页面
function GetUserLastHistory() {
    $.ajax({
        type: "POST",
        url: "../../Controllers/IndexController.ashx?action=GetUserLastHistory",
        dataType: 'json',
        async: false,
        success: function (msg) {
            if (msg) {
                msg = eval('(' + msg + ')');
                if (msg.IsSuccess == "true") {
                    if (msg.Message == 'false') {//当用户没有浏览记录
                        showTab('Page/DJSJ/LQ_JWDH.aspx', '井位导航');
                    }
                    else {
                        var data = eval('(' + msg.Message + ')');
                        console.log(data);
                        $.each(data, function (index, h) {
                            showTab(h.URL, h.TITLE);
                        })
                    }
                }
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}


