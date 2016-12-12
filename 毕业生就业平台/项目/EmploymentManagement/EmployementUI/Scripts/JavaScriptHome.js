
function aa(s_id) {
    for (i = 1; i < 6; i++) {
        if (i == s_id) {
            document.getElementById("s" + i).style.display = "block"; //内容的样式
            document.getElementById("m" + i).className = "c_" + i + " c_1"; //头部的样式
            //document.getElementById("m1").focus();
        }
        else {
            document.getElementById("s" + i).style.display = "none"; //内容不显示
            document.getElementById("m" + i).className = "c_0"; //
        }
    }
}

function bb(x_id) {
    for (i = 1; i < 5; i++) {
        if (i == x_id) {
            document.getElementById("x" + i).style.display = "block"; //内容的样式
            document.getElementById("n" + i).className = "d_" + i + " d_1"; //头部的样式                    
        }
        else {
            document.getElementById("x" + i).style.display = "none"; //内容不显示
            document.getElementById("n" + i).className = "d_0"; //
        }
    }
}

function cc(u_id) {
    for (i = 1; i < 4; i++) {
        if (i == u_id) {
            document.getElementById("u" + i).style.display = "block"; //内容的样式
            document.getElementById("p" + i).className = "d_" + i + " d_1"; //头部的样式                    
        }
        else {
            document.getElementById("u" + i).style.display = "none"; //内容不显示
            document.getElementById("p" + i).className = "d_0"; //
        }
    }
}


function ee(w_id) {
    for (i = 1; i < 4; i++) {
        if (i == w_id) {
            document.getElementById("w" + i).style.display = "block"; //内容的样式
            document.getElementById("q" + i).className = "d_" + i + " d_1"; //头部的样式                    
        }
        else {
            document.getElementById("w" + i).style.display = "none"; //内容不显示
            document.getElementById("q" + i).className = "d_0"; //
        }
    }
}

function ff(r_id) {
    for (i = 1; i < 5; i++) {
        if (i == r_id) {
            document.getElementById("r" + i).style.display = "block"; //内容的样式
            document.getElementById("v" + i).className = "d_" + i + " d_1"; //头部的样式                    
        }
        else {
            document.getElementById("r" + i).style.display = "none"; //内容不显示
            document.getElementById("v" + i).className = "d_0"; //
        }
    }
}

function goTopEx() {
    var obj = document.getElementById("goTopBtn");
    function getScrollTop() {
        return document.documentElement.scrollTop;
    }
    function setScrollTop(value) {
        document.documentElement.scrollTop = value;
    }
    window.onscroll = function () {
        getScrollTop() > 0 ? obj.style.display = "" : obj.style.display = "none";
    }
    obj.onclick = function () {
        var goTop = setInterval(scrollMove, 10);
        function scrollMove() {
            setScrollTop(getScrollTop() / 1.1);
            if (getScrollTop() < 1) clearInterval(goTop);
        }
    }
}

function getStyle(obj, name) {
    if (obj.currentStyle) {
        return obj.currentStyle[name]
    }
    else {
        return getComputedStyle(obj, false)[name]
    }
}

function getByClass(oParent, nClass) {
    var eLe = oParent.getElementsByTagName('*');
    var aRrent = [];
    for (var i = 0; i < eLe.length; i++) {
        if (eLe[i].className == nClass) {
            aRrent.push(eLe[i]);
        }
    }
    return aRrent;
}

function startMove(obj, att, add) {
    clearInterval(obj.timer)
    obj.timer = setInterval(function () {
        var cutt = 0;
        if (att == 'opacity') {
            cutt = Math.round(parseFloat(getStyle(obj, att)));
        }
        else {
            cutt = Math.round(parseInt(getStyle(obj, att)));
        }
        var speed = (add - cutt) / 4;
        speed = speed > 0 ? Math.ceil(speed) : Math.floor(speed);
        if (cutt == add) {
            clearInterval(obj.timer)
        }
        else {
            if (att == 'opacity') {
                obj.style.opacity = (cutt + speed) / 100;
                obj.style.filter = 'alpha(opacity:' + (cutt + speed) + ')';
            }
            else {
                obj.style[att] = cutt + speed + 'px';
            }
        }

    }, 30)
}

window.onload = function () {
    var oDiv = document.getElementById('playBox');
    var oPre = getByClass(oDiv, 'pre')[0];
    var oNext = getByClass(oDiv, 'next')[0];
    var oUlBig = getByClass(oDiv, 'oUlplay')[0];
    var aBigLi = oUlBig.getElementsByTagName('li');
    var oDivSmall = getByClass(oDiv, 'smalltitle')[0]
    var aLiSmall = oDivSmall.getElementsByTagName('li');

    function tab() {
        for (var i = 0; i < aLiSmall.length; i++) {
            aLiSmall[i].className = '';
        }
        aLiSmall[now].className = 'thistitle'
        startMove(oUlBig, 'left', -(now * aBigLi[0].offsetWidth))
    }
    var now = 0;
    for (var i = 0; i < aLiSmall.length; i++) {
        aLiSmall[i].index = i;
        aLiSmall[i].onclick = function () {
            now = this.index;
            tab();
        }
    }
    oPre.onclick = function () {
        now--
        if (now == -1) {
            now = aBigLi.length;
        }
        tab();
    }
    oNext.onclick = function () {
        now++
        if (now == aBigLi.length) {
            now = 0;
        }
        tab();
    }
    var timer = setInterval(oNext.onclick, 1000) //滚动间隔时间设置
    oDiv.onmouseover = function () {
        clearInterval(timer)
    }
    oDiv.onmouseout = function () {
        timer = setInterval(oNext.onclick, 1000) //滚动间隔时间设置
    }
}




