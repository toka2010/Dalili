var inputs = document.getElementsByClassName("form-control")
var edit = document.getElementById("edit");
var save = document.getElementById("save");
var can = document.getElementById("cancel");

edit.addEventListener("click",function(){
    edit.style.display ="none"
    save.style.display ="inline-block"
    can.style.display ="inline-block"
    for (let i = 0; i < inputs.length; i++) {
       inputs[i].disabled=false;
       inputs[i].style.backgroundColor = "#1e1e1e";
       inputs[i].style.color = "#fbc531";
       
    }
})
can.addEventListener("click",function(){
    edit.style.display ="inline-block"
    save.style.display="none"
    can.style.display ="none"
    for (let i = 0; i < inputs.length; i++) {
       inputs[i].disabled=true;
       inputs[i].style.color = "gray";

       
    }
})

save.addEventListener("click",function(){
    edit.style.display ="inline-block"
    save.style.display="none"
    can.style.display ="none"
    for (let i = 0; i < inputs.length; i++) {
       inputs[i].disabled=true;
       inputs[i].style.color = "gray";
    }
})