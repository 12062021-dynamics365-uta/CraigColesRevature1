"use strict"

console.log('Hello, world.. Nice to meet you.')
let five = 5
console.log(five);

var six = 6;
console.log(six);
var six = "six";
console.log(six);

//var is function (globally) scoped....
//let is block scoped
let num = 11;
function incrementing() {
  if (num%2 == 0) {
    var inc1 = ++num;
  }
  else {
    let inc2 = ++num;
    console.log(`The value of inc is ${inc2}`);// accessing inc2 is only allowed inside the block scope of the else{}
  }
  console.log(`The value of inc is ${inc1}`);
}

incrementing();
console.log(num);

//const doesn't allow reassignment.
const inc3 = 3;
//inc3 = 4;
let inc5 = inc3;
console.log(`The value of inc5 is ${inc5}`);
inc5 = 7;
console.log(`The value of inc5 is ${inc5}`);

//variable naming convention:
//don't start a variable with a number, 
//CONST variables are UPPERCASE
//all other variables are camelCase
//Functions are camelCase but can use PascalCase

//don't use keywords
let number1 = 5;

console.log(5 == 8);
console.log(true);
let undeclared;
console.log(undeclared);
let undeclared2 = null;
console.log(undeclared2);

let craig = {Myname:"Craig", age:28, street:"111 main"};

console.log(craig.Myname, craig.age);
console.log(craig);

console.log(typeof number1);

//an operand is the thing the operator acts on.
let operand1 = 5;
let operand2 = 6;
console.log(operand1 + operand2);

console.log(10/(3+2)*4+5**2+6-9);

let inc7 = 7;
inc7 += 3;
console.log(inc7);

let inc8 = 7;
inc8 /= 3;
console.log(Math.round(inc8));

let inc9 = 7;
inc9 **= 3;
console.log(Math.round(inc9));

//=(assignment), , 
let inc10 = 10;

//==(coersed equality)\
console.log(inc10 == "10");

//=== (strict equality)
console.log(inc10 === "10");
//!== (strict not equals)
console.log(inc10 !== "10");

//Truthy and Falsy
if(true){
    console.log(`This is true`);
}

if(false == false){
    console.log(`This is false`);
}

if(0 === 0){
    console.log(`This is true`);
}

if(`` === ``){
    console.log(`This is true`);
}

let inc11; //undefined
console.log(String(inc11));
console.log(Number(inc11));
console.log(Boolean(inc11));

let inc12 = 13;
console.log((Math.round(Math.random()*100)));

console.log(JSON.stringify(craig)); 
let stringyCraig = JSON.stringify(craig); 

console.log(stringyCraig);
console.log(stringyCraig.toUpperCase());

console.log(JSON.parse(stringyCraig));


//2nd day of JavaScript - Functions, classes, AJAX (XMLHttpRequest and Fetch())

//functions have a signature but no return type
//this is a function declaration
//no return type no type for on parameters
function doubles(){
    return 5;
}

let result = doubles();
console.log(`The result is => ${result}`);

function doubles1(param1 = 10, ...arr){
    return arr[2];
}

result = doubles1(11, 12, 13, 14);
console.log(`The result of doubles1 is => ${result}`);

//function expression
let doubles3 = function(param1){
    return param1;
}

console.log(doubles3(`Craig`));

//first-class function example
let doubles3Copy = doubles3;
console.log(doubles3Copy(`Emily`));
console.log(doubles3(`Rio`));

//callback function
let doubles4 = function(n, myFunc, param3, param4){
    for(let i = 0; i <= n; i++){
        myFunc(param3, param4);
    }
}

//console.log(doubles4);

//this will be sent to doubles 4
function doubles5(){
    console.log("this is doubles5");
}

//this is doubles 5 as an 'arrow functions'
let doubles6 = () => console.log("this is doubles5");
let doubles7 = (param1) => console.log('This is doubles 7 and the args was ${arg1}');

//this is a 'callback function'
doubles4(5, doubles7, "timey-whimey", 100);

//immediately invoked function expressions!! 
//this iife returns a function after writing to the console.
let iifeFunc = (function(){
    console.log(`this is a IIFE`)
    return function(param1){
        return param1*param1;
    }
})();

//then we can invoke the returned function.
console.log(iifeFunc(5));

//closure and scope
function doubles9(){
    let mySentence = '';
    return function(param1){
       mySentence += ' ' +  param1;
        return mySentence; 
    }
}

let doubles10 = doubles9();
console.log(doubles10);
console.log(doubles10('This'));
console.log(doubles10('is'));
console.log(doubles10('an'));
console.log(doubles10('example'));

try{
   
    throw new Error("This is an example of a try catch");

}
catch {

    console.error("This is the catch block");
}

let username = 'Craig';
localStorage.setItem("username", username);
let retreiveUsername = localStorage.getItem('username');
console.log(`This is the username ${retreiveUsername}`);


//objects!!
let craigDude1 = {name: 'Craig', age: '28'}; //object literal
console.log(craigDude1.age);

//user a function to return an object
function craigDudeFunc(fname, age){
    return{
        fname,
        age
    }
}

//create multiples of the object as needed
let craigDude2 = craigDudeFunc('Rio', 11);
console.log(craigDude2);

craigDude1.lname = 'Coles';
console.log(craigDude1.lname);

//craigDude1.craigsFunc = () => "This is the new function for craigDude1"
craigDude1.craigsFunc = function(){
    return "this is the new new function for craigDude1";
}

console.log(craigDude1.craigsFunc());

console.log('age' in craigDude1);//you can query to see if a property exists on an object

//Classes!!
class family{
    
    //you don't create properties in the class...
    //you do that in the constructor.
    constructor(dad, mom){
        //you have to use 'this' keyword to speecify that you
        // are creating these properties on THIS class.
        this.dad = dad;
        this.mom = mom;
    }

    sayItLoud(){
        return `fam.dad, fam.mom`
    }

    //getter and setter
    //use the 'get' keyword. This LOOKs like a function (and it is)
    //but you access the contends like a property
    get listOfFamily(){
        return `The parents are ${this.dad} and ${this.mom}`;
    }
    set familyMotto(value){
        this.motto = value;
    }
}

let fam = new family('Alan', 'Carol');
console.log(fam.dad, fam.mom);
console.log(fam.sayItLoud);
console.log(fam.listOfFamily); //access the getter prop.
fam.familyMotto = `We are faaaamily`;
console.log(fam.motto);


class newFamily extends family{
    constructor(dad, mom, ...children){
        super(dad, mom);//call the parent constructor
        this.childern = children//store the children into the class array

    }

    get listofChildren(){
        let listofChildrenString = '';
        this.children.forEach((xalue) => listofChildrenString += x);
        return listofChildrenString
    }
}





