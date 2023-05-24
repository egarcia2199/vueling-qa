
function numPrimo(num) {

    if (num <= 1) {
        return false;
        }

        for (let i = 2; i < num; i++) {
            if (num % i == 0) {
                return false;
        }
    }
        return true;
}

function listadoNumPrimos() {
    let array = [];
    let num = 0;
    
    while (array.length < 10) {
        if (numPrimo(num)) {
            array.push(num)
        }
        num++;    
    }
    return array;
}


console.log(listadoNumPrimos());
