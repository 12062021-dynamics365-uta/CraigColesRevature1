let threeAndFiveCounter = 0;
let threeCounter = 0;
let fiveCounter = 0;
var array = new Array();


for (var i = 1; i <= 1000; i++){
    
    if(i % 3 == 0 && i % 5 == 0){
        
        
        array.push("SweetN'Salty");
        threeAndFiveCounter++;
        
    }
    else if (i % 3 == 0){ 
        
        array.push("Sweet");
        threeCounter++;
        
    }
    else if (i % 5 == 0){
        
        array.push("Salty");
        fiveCounter++;
        
    }
    else{
        
        array.push(i);
        
    }
    if (i % 20 == 0)
    {
        console.log(array.toString());
        console.log("\n");
        array = []
    }
        
}

console.log(`There were ${threeCounter} sweeties`);
console.log(`There were ${fiveCounter} salties`);
console.log(`There were ${threeAndFiveCounter} sweetn'salties`);
