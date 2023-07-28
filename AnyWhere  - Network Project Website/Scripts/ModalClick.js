
//This Script Is For The Poping Modal In BootStarp

var myModal1 = document.getElementById('ModalLogIn')
var myInput1 = document.getElementById('myInput')

var myModal2 = document.getElementById('ModalSignUp')
var myInput2 = document.getElementById('myInput')

var myModal3 = document.getElementById('BuyTicket')
var myInput3 = document.getElementById('myInput')

myModal1.addEventListener('shown.bs.modal', function () {
    console.log("Hii")
})

myModal2.addEventListener('shown.bs.modal', function () {
    myInput2.focus()
})

myModal3.addEventListener('shown.bs.modal', function () {
    myInput3.focus()
})


