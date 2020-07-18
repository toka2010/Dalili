//add active class in navbar
var header = document.getElementById("myDIV");
var btns = document.getElementsByClassName("btnnav");
for (var i = 0; i < btns.length; i++) {
    btns[i].addEventListener("click", function () {
        var current = document.getElementsByClassName("activee");
        current[0].className = current[0].className.replace(" activee", "");
        this.className += " activee";
        
    });
}
//translation
function googleTranslateElementInit() {
    new google.translate.TranslateElement({pageLanguage: 'en'}, 'google_translate_element');
}
//nav color
var myNav = document.getElementById('mynav');
window.onscroll = function () { 
    "use strict";
    if (window.scrollY >= 350 ) {
        myNav.classList.add("colnav");
        myNav.classList.remove("opacitynav");
    } 
    else {
        myNav.classList.add("opacitynav");
        myNav.classList.remove("colnav");
    }
};