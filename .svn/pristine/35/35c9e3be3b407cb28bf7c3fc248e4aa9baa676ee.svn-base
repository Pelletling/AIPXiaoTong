//判断是否为数字
function IsDigit(value) {
    if (event.keyCode == 46 && value.indexOf('.') > -1)
        return false;

    return (((event.keyCode >= 48) && (event.keyCode <= 57)) || event.keyCode == 46);
}

jQuery.fn.outerHTML = function (s) {
    return (s) ? this.before(s).remove() : $("<Hill_man>").append(this.eq(0).clone()).html();
}

//获取GUID
function newGuid() {
    var S4 = function () {
        return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    };
    return (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
}



//String.prototype.getUrlParam = function (name) { 
//    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
//    var r = this.toString().substr(1).match(reg);
//    if (r != null) return unescape(r[2]); return null;
//};

function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = location.href.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

String.prototype.addUrlParam = function (name, value) {
    
    var str = this.toString();
    if (str.indexOf("?") > -1) {
        str += "&" + name + "=" + value;
    }
    else {
        str += "?" + name + "=" + value;
    }
    return str;
};

function alertError(error) {
    //layer.msg(error, { time: 5000, icon: 5 });
    layer.alert(error, {        
        closeBtn: 0})
}

function alertSuccess(msg) {
    if (typeof msg == "undefined") {
        msg = "保存成功";
    }
    layer.msg(msg);
}

function alertWarn(msg) {
    layer.msg(msg, { icon: 0 });
}

Date.prototype.getLongDateString = function () {
    var m = this.getMonth() + 1;
    if (m < 10) { m = '0' + m; }
    var d = this.getDate();
    if (d < 10) { d = '0' + d; }
    var h = this.getHours();
    if (h < 10) { h = '0' + h; }
    var mi = this.getMinutes();
    if (mi < 10) { mi = '0' + mi; }
    var s = this.getSeconds();
    if (s < 10) { s = '0' + s; }
    return '' + this.getFullYear() + m + d + h + mi + s;
}

Date.prototype.getMillisecondsDateString = function () {
    var m = this.getMonth() + 1;
    if (m < 10) { m = '0' + m; }
    var d = this.getDate();
    if (d < 10) { d = '0' + d; }
    var h = this.getHours();
    if (h < 10) { h = '0' + h; }
    var mi = this.getMinutes();
    if (mi < 10) { mi = '0' + mi; }
    var s = this.getSeconds();
    if (s < 10) { s = '0' + s; }
    return '' + this.getFullYear() + m + d + h + mi + s+this.getMilliseconds();
}



function BindProvince() {
    $("#ProvinceCode").change(function () {
        var parentCode = $(this).val();

        LoadCity(parentCode);
    });
}

function LoadCity(parentCode, value, callback) {

    $("#CityCode option[value!='']").remove();
    $("#DistrictCode option[value!='']").remove();
    $("#StreetCode option[value!='']").remove();

    if (parentCode != "" && parentCode != null) {
        $.get("/Area/GetChildren", { ParentCode: parentCode }, function (data) {
            $(data).each(function (index) {
                $("#CityCode").append('<option value="' + data[index].Code + '">' + data[index].Name + '</option>');
            });
            $("#CityCode").find("option[value=" + value + "]").attr("selected", true);

            if (typeof callback === "function") {
                callback();
            }
        });
    }
}

function BindCity() {
    $("#CityCode").change(function () {
        var parentCode = $(this).val();

        LoadDistrict(parentCode);
    });
}

function LoadDistrict(parentCode, value, callback) {

    $("#DistrictCode option[value!='']").remove();
    $("#StreetCode option[value!='']").remove();

    if (parentCode != "" && parentCode != null) {
        $.get("/Area/GetChildren", { ParentCode: parentCode }, function (data) {
            $(data).each(function (index) {
                $("#DistrictCode").append('<option value="' + data[index].Code + '">' + data[index].Name + '</option>');
            });
            $("#DistrictCode").find("option[value=" + value + "]").attr("selected", true);
            if (typeof callback === "function") {
                callback();
            }
        });
    }
}
