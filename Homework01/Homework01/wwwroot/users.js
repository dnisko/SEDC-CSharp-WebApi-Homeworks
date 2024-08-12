let btnGetAll = document.getElementById("btnGetAll");
let btnGetById = document.getElementById("btnGetById");

let inputId = document.getElementById("inputId");

let result = document.getElementById("result");

let port = "7258";
let url = "https://localhost:" + port + "/api/users/";

let GetAll = async () => {
    result.innerText = "";

    let endpoint = url + "GetAll";

    let response = await fetch(endpoint);
    console.log(response);

    let data = await response.json();
    console.log(data);

    for (let i = 0; i < data.length; i++) {
        let li = document.createElement("li");
        li.innerText = data[i];
        result.appendChild(li);
    }
}

let GetById = async () => {
    //debugger;
    result.innerText = "";
    let endpoint = url + "GetById/" + inputId.valueAsNumber;

    let response = await fetch(endpoint);
    console.log(response);

    let data = await response.text();
    console.log(data);

    let li = document.createElement("li");
    li.innerText = data;
    result.appendChild(li);
}

btnGetAll.addEventListener("click", GetAll);
btnGetById.addEventListener("click", GetById);