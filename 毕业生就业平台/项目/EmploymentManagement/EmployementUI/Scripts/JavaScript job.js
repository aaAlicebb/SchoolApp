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
