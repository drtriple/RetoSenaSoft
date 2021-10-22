
function validar(){

    const user = document.getElementById("username").value;
    const contrasena = document.getElementById("pass").value;

    const usuario = /^\d{10,11}$/ // 10 a 11 numeros.
    const password = /^.{4,12}$/; // 4 a 12 digitos.

    const mensaje = document.getElementById("retorno");
    const mensaje2 = document.getElementById("retorno2");
    const mensaje3 = document.getElementById("input-error");
    const mensaje4 = document.getElementById("input-error2");

    if(user == "" || user == null){   
        if(contrasena == "" || contrasena == null){
            mensaje.innerText = "El campo usuario esta vacío, por favor ingresar los datos.";
            mensaje3.innerText = "El campo contraseña esta vacío, por favor ingresar los datos.";
         
                }
                else{
                    mensaje.innerText = "El campo usuario esta vacío, por favor ingresar los datos.";
                }
                         
    } 
            if (user.match(usuario)){
        
            } else {
               mensaje2.innerText = "Recuerde que el usuario es su número de cédula.";
           }     
           
           if (contrasena.match(password)){
        
        } else {
           mensaje4.innerText = "La contraseña tiene que ser de 4 a 12 dígitos.";
       } 
}

