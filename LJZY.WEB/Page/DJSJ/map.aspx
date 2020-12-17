<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="map.aspx.cs" Inherits="LJZY.WEB.Page.DJSJ.map" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 1600px; height: 600px; border: 1px solid gray; position: absolute;">
            <div style="width: 80%; height: 80%; border: 1px solid gray; position: absolute;" id="bmap">
            </div>
        </div>
    </form>
</body>
</html>
<script src="../../Scripts/jquery-1.8.2.min.js"></script>
<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=IDvNBsejl9oqMbPF316iKsXR"></script>

<script type="text/javascript">
    // 百度地图API功能
    var mp = new BMap.Map("bmap");
    mp.centerAndZoom(new BMap.Point(116.3964, 39.9093), 15);
    mp.enableScrollWheelZoom();
    // 复杂的自定义覆盖物
    function ComplexCustomOverlay(point, text) {
        this._point = point;
        this._text = text;
    }
    ComplexCustomOverlay.prototype = new BMap.Overlay();
    ComplexCustomOverlay.prototype.initialize = function (map) {
        var that = this;

        var arrow = this._arrow = document.createElement("div");
        arrow.style.background = "url(../../images/label.png) no-repeat";
        arrow.style.position = "absolute";
        arrow.style.width = "11px";
        arrow.style.height = "10px";
        arrow.style.top = "22px";
        arrow.style.left = "10px";
        //arrow.style.overflow = "hidden";
        
        this._map = map;
        var div = this._div = document.createElement("div");
        div.style.position = "absolute";
        div.style.zIndex = BMap.Overlay.getZIndex(this._point.lat);
        div.style.backgroundColor = "#EE5D5B";
        div.style.border = "1px solid #BC3B3A";
        div.style.color = "white";
        div.style.height = "18px";
        div.style.padding = "2px";
        div.style.lineHeight = "18px";
        div.style.whiteSpace = "nowrap";
        //div.style.MozUserSelect = "none";
        div.style.fontSize = "12px"
        var span = this._span = document.createElement("span");
        div.appendChild(span);
        div.appendChild(arrow);


        //div.onmouseover = function(){
        //  this.style.backgroundColor = "#6BADCA";
        //  this.style.borderColor = "#0000ff";
        //  this.getElementsByTagName("span")[0].innerHTML = that._overText;
        //  arrow.style.backgroundPosition = "0px -20px";
        //}

        div.onmouseout = function () {
            this.style.backgroundColor = "#EE5D5B";
            this.style.borderColor = "#BC3B3A";
            this.getElementsByTagName("span")[0].innerHTML = that._text;
            arrow.style.backgroundPosition = "0px 0px";
        }

        mp.getPanes().labelPane.appendChild(div);

        return div;
    }
    ComplexCustomOverlay.prototype.draw = function () {
        var map = this._map;
        var pixel = map.pointToOverlayPixel(this._point);
        this._div.style.left = pixel.x - parseInt(this._arrow.style.left) + "px";
        this._div.style.top = pixel.y - 30 + "px";
    }
    var txt = "银湖海岸城";

    var myCompOverlay = new ComplexCustomOverlay(new BMap.Point(116.407845, 39.914101), "银湖海岸城");

    mp.addOverlay(myCompOverlay);
</script>
