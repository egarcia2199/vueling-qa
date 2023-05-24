
function PalabraMasLarga(string) {

    let palabras = string.split(" ");
    console.log(palabras);
    let maslarga = palabras[0];

    for(let i = 1; i < palabras.length; i++) {

        if(palabras[i].length > maslarga.length) {

            maslarga = palabras[i];
        }
    }

    return maslarga;
}

console.log(PalabraMasLarga("Hola que tal estamos todos"));

