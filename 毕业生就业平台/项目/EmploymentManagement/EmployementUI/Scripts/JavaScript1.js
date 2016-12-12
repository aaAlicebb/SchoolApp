function YC()
{
    document.getElementById("citys").style.display = "none";
    document.getElementById("more").style.display = "";
    document.getElementById("close").style.display = "none";
    document.getElementById("B3").style.height = "126px";
    document.getElementById("b4").style.marginTop = "240px";
}
function XS() {
    document.getElementById("citys").style.display = "";
    document.getElementById("more").style.display = "none";
    document.getElementById("close").style.display = "";
    document.getElementById("B3").style.height = "172px";
    document.getElementById("b4").style.marginTop="270px";
}
function change()
{
    document.getElementById("Bhidden").style.display = "";
    document.getElementById("Bshow").style.display = "none";
}
function changeleft() {
    document.getElementById("Bhidden").style.display = "none";
    document.getElementById("Bshow").style.display = "";
}
function majo()
{
     var op = document.getElementById("major").style.display="block";
     if (op.display == "block")
     {
                document.getElementById("ss").style.display = "block";
     }
}

function ontrue(id)
{
    document.getElementById("ontrue").value = id;
}
function majo1() {
    var op = document.getElementById("major1").style.display = "block";
    if (op.display == "block") {
        document.getElementById("ss1").style.display = "block";
    }
}

function ontrue(id)
{
    document.getElementById("ontrue1").value = id;
}
function Change() {
    document.getElementById("ck").style.fontSize = "16px";
    document.getElementById("ck").style.fontWeight = "bold";
    document.getElementById("ck").style.color= "red";
}
