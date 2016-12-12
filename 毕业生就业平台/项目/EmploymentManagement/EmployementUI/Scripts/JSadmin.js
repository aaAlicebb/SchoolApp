function show(id) {
    for (var i = 1; i < 7; i++) {

        if (i == id) {
            var itemtea = document.getElementById("top" + i).style;
            itemtea.color = "#ffffff";
            itemtea.background = "#453efa";
            //itemtea.border = "1px solid #ffffff";
            itemtea.borderTop = "1px solid #ffffff";
            itemtea.borderLeft = "1px solid #ffffff";
            itemtea.borderRight = "1px solid #ffffff";
            itemtea.borderBottom = "0px solid #ffffff";
        }
        else {
            var itemtea = document.getElementById("top" + i).style;
            itemtea.color = "#ffffff";
            itemtea.background = "none";
            itemtea.borderTop = "0px solid #ffffff";
            itemtea.borderLeft = "0px solid #ffffff";
            itemtea.borderRight = "0px solid #ffffff";
            itemtea.borderBottom = "1px solid #ffffff";
        }
    }
}
function toleft() {
    var toleft = document.getElementById("toleft").style;
    toleft.width = "0%";
    var tobig = document.getElementById("tobig").style;
    tobig.width = "99.1%";
    document.getElementById("kkleft").style.display = "none";
    document.getElementById("kkright").style.display = "block";
}
function toright() {
    var toright = document.getElementById("toleft").style;
    toright.width = "15%";
    var tobig = document.getElementById("tobig").style;
    tobig.width = "84.1%";
    document.getElementById("kkleft").style.display = "block";
    document.getElementById("kkright").style.display = "none";
}
function change(id) {
    if (id == 1) {
        document.getElementById("change").innerHTML = "-&nbsp &nbsp用户信息";
        document.getElementById("item6").style.display = "block";
        document.getElementById("item2").style.display = "none";
        document.getElementById("item3").style.display = "none";
        document.getElementById("item5").style.display = "none";
        document.getElementById("item4").style.display = "none";
        document.getElementById("item7").style.display = "none";
    }
    else if (id == 2) {
        document.getElementById("change").innerHTML = "-&nbsp &nbsp教师信息";
        document.getElementById("item2").style.display = "none";
        document.getElementById("item3").style.display = "none";
        document.getElementById("item5").style.display = "none";
        document.getElementById("item6").style.display = "none";
        document.getElementById("item4").style.display = "block";
        document.getElementById("item7").style.display = "none";
        //
        document.getElementById("emInfo").style.display = "none";
        document.getElementById("stuInfo").style.display = "none";
        document.getElementById("teaInfo").style.display = "block";
        document.getElementById("comInfo").style.display = "none";
        //document.getElementById("userInfo").style.display = "none";
        document.getElementById("classInfo").style.display = "none";
        document.getElementById("showtext").innerHTML = "教师管理"
    }
    else if (id == 3) {
        document.getElementById("change").innerHTML = "-&nbsp &nbsp学生信息";
        document.getElementById("item2").style.display = "block";
        document.getElementById("item3").style.display = "block";
        document.getElementById("item4").style.display = "none";
        document.getElementById("item5").style.display = "none";
        document.getElementById("item6").style.display = "none";
        document.getElementById("item7").style.display = "none";
        //
        document.getElementById("emInfo").style.display = "none";
        document.getElementById("stuInfo").style.display = "block";
        document.getElementById("teaInfo").style.display = "none";
        document.getElementById("comInfo").style.display = "none";
        //document.getElementById("userInfo").style.display = "none";
        document.getElementById("classInfo").style.display = "none";
        document.getElementById("showtext").innerHTML = "学生管理"
    }
    else if (id == 4) {
        document.getElementById("change").innerHTML = "-&nbsp &nbsp企业信息";
        document.getElementById("item2").style.display = "none";
        document.getElementById("item3").style.display = "none";
        document.getElementById("item4").style.display = "none";
        document.getElementById("item5").style.display = "block";
        document.getElementById("item6").style.display = "none";
        document.getElementById("item7").style.display = "none";
        //
        document.getElementById("emInfo").style.display = "none";
        document.getElementById("stuInfo").style.display = "none";
        document.getElementById("teaInfo").style.display = "none";
        //document.getElementById("userInfo").style.display = "none";
        document.getElementById("classInfo").style.display = "none";
        document.getElementById("comInfo").style.display = "block";
        document.getElementById("showtext").innerHTML = "企业管理"
    }
    else if (id == 5) {
        document.getElementById("change").innerHTML = "-&nbsp &nbsp招聘信息";
        document.getElementById("item6").style.display = "none";
    }
    else {
        document.getElementById("change").innerHTML = "-&nbsp &nbsp班级信息";
        document.getElementById("item2").style.display = "none";
        document.getElementById("item3").style.display = "none";
        document.getElementById("item4").style.display = "none";
        document.getElementById("item5").style.display = "none";
        document.getElementById("item6").style.display = "none";
        document.getElementById("item7").style.display = "block";
        //
        document.getElementById("emInfo").style.display = "none";
        document.getElementById("stuInfo").style.display = "none";
        document.getElementById("teaInfo").style.display = "none";
        document.getElementById("comInfo").style.display = "none";
        //document.getElementById("userInfo").style.display = "none";
        document.getElementById("classInfo").style.display = "block";
        document.getElementById("showtext").innerHTML = "班级管理"
    }
}
function changeem() {
    document.getElementById("stuInfo").style.display = "none";
    document.getElementById("emInfo").style.display = "block";
    document.getElementById("teaInfo").style.display = "none";
    document.getElementById("comInfo").style.display = "none";
    //document.getElementById("userInfo").style.display = "none";
    document.getElementById("classInfo").style.display = "none";
    document.getElementById("showtext").innerHTML = "就业管理";

}
function changestu() {
    document.getElementById("emInfo").style.display = "none";
    document.getElementById("stuInfo").style.display = "block";
    document.getElementById("teaInfo").style.display = "none";
    document.getElementById("comInfo").style.display = "none";
    //document.getElementById("userInfo").style.display = "none";
    document.getElementById("classInfo").style.display = "none";
    document.getElementById("showtext").innerHTML = "学生管理"
}
function changetea() {
    document.getElementById("emInfo").style.display = "none";
    document.getElementById("stuInfo").style.display = "none";
    document.getElementById("teaInfo").style.display = "block";
    document.getElementById("comInfo").style.display = "none";
    //document.getElementById("userInfo").style.display = "none";
    document.getElementById("classInfo").style.display = "none";
    document.getElementById("showtext").innerHTML = "教师管理"
}
function changecom() {
    document.getElementById("emInfo").style.display = "none";
    document.getElementById("stuInfo").style.display = "none";
    document.getElementById("teaInfo").style.display = "none";
    //document.getElementById("userInfo").style.display = "none";
    document.getElementById("classInfo").style.display = "none";
    document.getElementById("comInfo").style.display = "block";
    document.getElementById("showtext").innerHTML = "企业管理"
}
function changeuser() {
    document.getElementById("emInfo").style.display = "none";
    document.getElementById("stuInfo").style.display = "none";
    document.getElementById("teaInfo").style.display = "none";
    document.getElementById("comInfo").style.display = "none";
    //document.getElementById("userInfo").style.display = "block";
    document.getElementById("classInfo").style.display = "none";
    document.getElementById("showtext").innerHTML = "用户管理"
}
function changeclass() {
    document.getElementById("emInfo").style.display = "none";
    document.getElementById("stuInfo").style.display = "none";
    document.getElementById("teaInfo").style.display = "none";
    document.getElementById("comInfo").style.display = "none";
    //document.getElementById("userInfo").style.display = "none";
    document.getElementById("classInfo").style.display = "block";
    document.getElementById("showtext").innerHTML = "班级管理"
}