



async function frutas()
{
    var url = "https://localhost:44314/Productos/GetTodo";
    var resp = await fetch(url);
    var data = await resp.json();
    console.log(data);
    console.log(data);

}

