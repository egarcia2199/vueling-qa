
function numPrimo(num) {

    if (num <= 1) {
        return false;
        }

        for (let i = 2; i < num; i++) {
            if (num % i == 0) {
                console.log("El numero "+num+" NO es primo");
                return false;
        }
    }
        console.log("El numero "+num+" es primo");
        return true;
}

console.log(numPrimo(5));
