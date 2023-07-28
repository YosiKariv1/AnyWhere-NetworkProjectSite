
function showHidePaymentFields() {
    var paymentMethod = document.querySelector('input[name="paymentMethod"]:checked').value;
    if (paymentMethod == "creditCard") {
        document.getElementById("creditCardFields").style.display = "block";
        document.getElementById("paypalFields").style.display = "none";
    } else if (paymentMethod == "paypal") {
        document.getElementById("creditCardFields").style.display = "none";
        document.getElementById("paypalFields").style.display = "block";
    }
}



function showHideStudentCheckbox() {
    var ticketType = document.querySelector('input[name="exampleRadios"]:checked').value;
    if (ticketType == "option3") {
        document.getElementById("studentFields").style.display = "block";
    } else {
        document.getElementById("studentFields").style.display = "none";
    }
}


