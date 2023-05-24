function mayorEdad(edad) {

    if (edad >= 18) {
        return "Mayor de edad"

    } else {
        return "Menor de edad"
    }
}

const listaEdades = [13,12,19,26,15];

function PromedioDeEdad(edades){
    let totalEdad = 0;
    let cont = 0;

    edades.forEach(edad => { 
        
        if(mayorEdad(edad)){

            cont++;
            totalEdad += edad;
        }
    });
    let avg = totalEdad / cont;
    console.log("Promedio de edad de "+ cont +" personas: " + avg + " años")
}


PromedioDeEdad(listaEdades);