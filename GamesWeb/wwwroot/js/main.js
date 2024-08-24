
var curr_sect = 0;

function onScroll() {
    var sections = document.getElementsByClassName("section");
    let i;
    for (i = 0; i < sections.length; i++) {
        if (sections[i].getBoundingClientRect().top >= document.getElementById("main-nav").getBoundingClientRect().height * 2 - sections[i].getBoundingClientRect().height) {
            break;
        }
    }

    if (curr_sect == i) return;

    document.getElementsByClassName("nav-link")[curr_sect].classList.remove("active");
    document.getElementsByClassName("nav-link")[i].classList.add("active");

    var element = document.getElementById("main-nav");
    element.style.background = (i % 2 == 0) ? "linear-gradient(150deg, rgb(31, 31, 31), rgb(0, 0, 54))" : "linear-gradient(60deg, rgb(29, 0, 0), rgb(31, 31, 31))";
    element.style.boxShadow = (i % 2 == 0) ? "0px 1px 10px rgb(35, 0, 99)" : "0px 1px 10px rgb(136, 0, 0)";

    curr_sect = i;
}

function purchaseModalOpening(item_name) {
    let elem = document.getElementById("purchase-modal").getElementsByClassName("modal-body")[0];

    elem.innerHTML = document.getElementById(item_name + "-membership").getElementsByClassName("card-body")[0].getElementsByClassName("row")[1].innerHTML + "<label class='form-label'>Would you like to subscribe monthly or yearly?</label><div class='form-check'><input class='form-check-input' type='radio' name='subscription-style' id='monthly'><label class='form-check-label' for='monthly'>Monthly</label></div><div class='form-check'><input class='form-check-input' type='radio' name='subscription-style' id='yearly'><label class='form-check-label' for='yearly'>Yearly</label></div>";
}