
function duplicarNums(array) {
    
    const array2=[];

    for (i=0; i<array.length; i++) {
        array2.push(array[i]*2);
        
    } 
    return array2;
}
console.log(duplicarNums([1,4,6]));


