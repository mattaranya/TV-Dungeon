var cancelled = false;

function hasNoSpaces(s)
{
    for (var i = 0; i < s.length; i++) {
        if (s.charAt(i) === " ") {
            return false;
        }
    }
    return true;
}

function isNull(s)
{
    return s.length==0;
}

function isValidString(str)
{
    var quot = "\"";
    var badChars = "$%^&*()+=;'[]{}_|<>\\";
    for (var i = 0; i < str.length; i++) {
        for (var j = 0; j < badChars.length; j++) {
            if (str.charAt(i) === badChars.charAt(j)) {
                return false;
            }
        }
    }
    if (str.indexOf(quot) != -1) {
        return false;
    }
    return true;
}

function isEmail(mail)
{
    var at = '@';
    for (var i = 0; i < mail.length; i++) {
        if (mail.charAt(i) === at)
        {
            return true;
        }
    }
    return false;
}

function goodPassword(password, username)//dont have less than 8 characters and
{
    return password.length >= 8 && password !== username;
}

function checkPasswords(p, c)
{
    return p === c;
}

function checkForm1(u,p){
    var msg = "";
    var u = document.getElementById("username").value;
    var p = document.getElementById("password").value;
    if (isNull(u)){
        msg += "Username is required<br />";
    }
    if (isNull(p)){
        msg += "Password is required<br />";
    }
    if (!hasNoSpaces(u)) {
        msg += "Username should have no spaces<br />";
    }
    if (!hasNoSpaces(p)) {
        msg += "Password should have no spaces<br />";
    }
    if (!goodPassword(p,u)){
        msg += "Password don't follow rules- too short and/or identicle to Username<br />";
    }
    if (msg.length === 0)
        return true;
    document.getElementById("message").innerHTML = msg;
    return false;
}

function checkForm2() {
    var u = document.getElementById("username").value;
    var p = document.getElementById("password").value;
    var c = document.getElementById("cpassword").value;
    var m = document.getElementById("email").value;
    var msg = "";

    if (isNull(u)) {
        msg += "Username is required<br />";
    }
    if (isNull(p) || isNull(c)) {
        msg += "Password is required<br />";
    }
    if (isNull(m)){
        msg += "Email is required<br />";
    }
    if (!hasNoSpaces(u)) {
        msg += "Username should have no spaces<br />";
    }
    if (!hasNoSpaces(p)) {
        msg += "Password should have no spaces<br />";
    }
    if (!hasNoSpaces(m)) {
        msg += "Email should have no spaces<br />";
    }
    if (!goodPassword(p, u)) {
        msg += "Password don't follow rules- too short and/or identicle to Username<br />";
    }
    if (!checkPasswords(p, c)){
        msg += "Passwords' aren't identicle<br />";
    }
    if (!isEmail(m)){
        msg += "Email hasn't got '@' in it<br />";
    }
    if (msg.length==0)
        return true;
    document.getElementById("message").innerHTML = msg;
    return false;
}
function isNull(s) {
    return s.length == 0;
}

function hasNull(s)
{
    return s === null || s === "";
}
/*function checkForm4() {
    var headline = document.getElementById("headline").value;
    var content = document.getElementById("postcontent").value;
    var tag = document.getElementById("tags").value;
    var st1 = "";
    var t = false;
    if (hassNull(headline)) {
        st1 += "Headline's missing<br/>";
    }
    if (hassNull(content)) {
        st1 += "Content's missing<br/>";
    }
    if (hassNull(tag)) {
        st1 += "Tag's missing<br/>";
    }
    if (!isValidString(headline)) {
        st1 += "Headline has unauthorized characters in it<br/>";
    }
    if (!isValidString(content)) {
        st1 += "Content has unauthorized characters in it<br/>";
    }
    if (st1.length == 0)
    { t= true; }
    document.getElementById("st").innerHTML = st1;
    return t;
}*/