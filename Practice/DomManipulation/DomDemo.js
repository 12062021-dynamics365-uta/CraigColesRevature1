//console.log('hey, tiger!');

//create the input element
let inputElem = document.createElement('input');
//add the element to the body

document.body.appendChild(inputElem);



//create the submit element
let submitTodo = document.createElement('button');
document.body.appendChild(submitTodo);
//setting the inner text on the button
submitTodo.innerText = 'Submit a new ToDo!';

let inputListTitle = document.createElement('input');
document.body.appendChild(inputListTitle);

let submitTitle = document.createElement("button");

document.body.appendChild(submitTitle);
submitTitle.innerText = "New Title!";


//create the title element for the list
let title = document.createElement('h1');
//add the element to the body
document.body.appendChild(title);
//setting test for the h1 element
title.innerText = 'Your Todos!';

let todoList = document.createElement('ul');
document.body.appendChild(todoList);
todoList.innerHTML = `<li>This is the first list item</li>`;
todoList.innerHTML += `<li class="hoverDemo">This is the second list item</li>`;

//you can target the unordered list.
//let myUl = document.querySelector('ul');//this is getting another access ot that <ul> it is un-needed
todoList.classList.add('ulClass');

submitTitle.addEventListener('click', (e) =>{
    let newTitle = inputListTitle.value;
    title.innerHTML = newTitle;

});

//create the eventlistener to do the things with the content of the input
submitTodo.addEventListener('click', (e) =>{
    let newToDo = inputElem.value;

    //checking if input is empty
    if (newToDo == ""){
        alert("The field is empty!");
        return false;
    }

    //char limit with alert
    if (newToDo.length > 10){
        alert("too many chars!");
        return false;
    }

    //console.log(newToDo);
    let myLi = document.createElement('li');
    myLi.innerText = `${newToDo}`;
    todoList.appendChild(myLi);
    inputElem.value = ' ';
    inputElem.focus();
});
    
       
    
        
    

//allow user to input a new todo with the enter key
inputElem.addEventListener('keypress', (enterkey) => {
    if(enterkey.key === `Enter`){
     newToDo = inputElem.value;
    }

    //checking if input is empty
    if (newToDo == ""){
        alert("The field is empty!");
        return false;
    }

    //char limit with alert
    if (newToDo.length > 10){
        alert("too many chars!");
        return false;
    }

    //console.log(newToDo);
    let myLi = document.createElement('li');
    myLi.innerText = `${newToDo}`;
    todoList.appendChild(myLi);
    inputElem.value = ' ';
    inputElem.focus();

});




//still need to delete on click of the todo item.
document.body.addEventListener('click', (event) =>{
    console.log("the body click event was triggered");
})

//put an event listener on the ul.
todoList.addEventListener('click', (event) => {
    console.log(event.target);
    event.stopPropagation(); //use  this to stop the emission of the event up through the hiearcy
    event.target.parentNode.innerText = 'This is the parent of the element that the event happened on.'
});