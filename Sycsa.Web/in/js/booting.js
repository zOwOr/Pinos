/*
 * Archivo de petición de llamadas
 * 
 * Resumen:
 * Este archivo contiene las funciones para tomar las peticiones de un callback y su termino del mismo,
 * con esto se puede tomar valores que retorna el servidor y presentarlas al usuario de mas que mas convenga
 * 
 * ------------------------------------------------------------
 *   Notas: 
 *   Los tiempos que se manejan estan en milisegundos
 *   1 segundo = 1000 milisegundos
 * -----------------------------------------------------------
 * 
 * Fecha: 30/09/2015
 * Autor: Juan Carlos López R.
 * 
 */


var pbControl = null;

var varSettimerBegin                    // Incio de una petición 
var varSettimerEnd                      // Termino de la petición

var box_process = "box_process"         // Cuadro de mensaje en el cual indica que se esta procesado la solicitud
var box_process_text = "Atendiendo ..."  // Texto que aparecera al usuario 
var box_process_timer = 350             // Tiempo de espera antes de mandar el mensaje de proceso

var box_messenger = "box_messenger"     // Cuadro de mensajes de Error, alertas, etc..
var box_messenger_timer = 500           // Tiempo de espera antes de mandar el cuadro de mensajes

var tiempoOcultar = 3000               // Tiempo para ocultar los cuadros de mensajes
var tiempoAparece  = 800                // Tiempo para mostrar los cuadros de mensajes

var tiempoEfectoAparece = 400
var tiempoEfectoOcultar = 400

/* cuando inicia una peticion del cliente hacia el servidor */
function BeginRequestHandler(sender, args) {

    pbControl = args.get_postBackElement();  //El control que causo el PostBack
    pbControl.disabled = true;

    clearTimeout(varSettimerEnd); //Elimina la funcion del termino de la llamada

    varSettimerBegin = setTimeout(
            function () {
                $("#" + box_messenger).hide( 0,
                    function () {
                        process(); // muestra caja de proceso
                    });
            }
        , box_process_timer);
}

/* cuando termina una peticion del cliente hacia el servidor */
function EndRequestHandler(sender, args) {

    pbControl.disabled = false;
    pbControl = null;

    clearTimeout(varSettimerBegin); // Elimina la primera funcion de la llamada, si todavia esta en ejecucion

    varSettimerEnd = setTimeout(
            function () {

                $("#" + box_process).hide(0);

                // si existe un mensaje de tipo error
                if (args.get_error() != undefined) {

                    args.set_errorHandled(true);
                    var exception = (args.get_error().message.replace("Sys.WebForms.PageRequestManagerServerErrorException:", ""));

                    messenger(box_messenger, "alert alert-danger", exception);
                }
                // else --> aqui se puede agregar condicion para recibir cualquier tipo de respuesta por parte del servidor
            }
            , box_messenger_timer
        );
}


function messenger(div, clas, text) {
     
    $("#" + div).attr("class", clas);
    $("#" + div).html(text);

    $("#" + div).show(tiempoEfectoAparece, function () {
        setTimeout(function () { $("#" + div).hide(tiempoEfectoOcultar); }, tiempoOcultar);
    });
      
}

function process() {

    $("#" + box_process).html(box_process_text);
    $("#" + box_process).show(tiempoEfectoAparece);

}



