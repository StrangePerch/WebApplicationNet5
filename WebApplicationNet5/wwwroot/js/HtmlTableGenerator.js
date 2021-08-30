let refresh = function () {
    document.location.reload();
}

function setRefresh(callback) {
    refresh = callback;
}

function GetHtmlTable(options) {
    let table = CreateElementWithClass("table", "table");
    //Creating table headers by prop names
    let tableHead = document.createElement("thead");
    let tr = document.createElement("tr");
    let collection = options.collection;
    for (const prop in collection[0]) {
        if (options.hidden !== undefined && options.hidden.includes(prop)) continue;
        if (options.renamed !== undefined)
        {
            let newName = options.renamed[prop];
            if(newName !== undefined)
            {
                tr.append(CreateTh(newName));
                continue;
            }
        }
        tr.append(CreateTh(prop));
    }
    tr.append(CreateTh("Actions"));
    tableHead.append(tr);
    table.append(tableHead);
    //Creating rows with data
    let tableBody = document.createElement("tbody");
    for (const item of collection) {
        //Data
        tr = document.createElement("tr");
        let inputs = [];
        for (const prop in item) {
            if (options.hidden !== undefined && options.hidden.includes(prop)) continue;
            let col = document.createElement("td");
            let editableProp;
            if(options.editable === undefined) editableProp = undefined;
            else editableProp = options.editable[prop];

            if (editableProp !== undefined) {
                if(editableProp.type === "text")
                {
                    let input = CreateElementWithClass("input", "form-control");
                    input.readOnly = true;
                    input.value = item[prop];
                    inputs.push({input: input, for: prop});
                    col.append(input);
                }
                else if(editableProp.type === "dropDown" && editableProp.source === "api")
                {
                    let path = editableProp.path;
                    let select = document.createElement("select");
                    let option = document.createElement("option");
                    option.innerText = item[editableProp.defaultText];
                    option.value = item[editableProp.defaultValue];
                    option.selected = true;
                    select.append(option)
                    select.disabled = true;
                    col.append(select);
                    FetchGetJson(path,
                        (collection) =>
                        {
                            if(editableProp.filter !== undefined)
                                collection = collection.filter(editableProp.filter);
                            for (const collectionElement of collection) {
                                let option = document.createElement("option");
                                option.value = collectionElement[editableProp.value];
                                option.innerText = collectionElement[editableProp.text];
                                select.append(option)
                            }
                            inputs.push({input: select, for: prop});
                        });
                }
            }
            else
                col.innerText = item[prop];
            tr.append(col);
        }
        //Actions
        let col = document.createElement("td");
        //RemoveButton
        let RemoveButton = document.createElement("button");
        RemoveButton.className = "btn btn-danger";
        RemoveButton.append(CreateElementWithClass("i", "fas fa-trash-alt"))
        RemoveButton.onclick = () => Remove(options.path + item.id)
        col.append(RemoveButton)
        //EditButton
        let EditButton = document.createElement("button");
        EditButton.className = "btn btn-warning";
        EditButton.append(CreateElementWithClass("i", "fas fa-edit"))
        EditButton.onclick = () => Edit(item, EditButton, inputs, options.path + item.id)
        col.append(EditButton);
        
        tr.append(col);
        tableBody.append(tr);
    }
    table.append(tableBody);
    return table;
}

function CreateTh(name) {
    let th = CreateElementWithClass("th", "text-capitalize");
    th.scope = "col";
    th.innerText = name;
    return th;
}

function CreateElementWithClass(name, className) {
    let el = document.createElement(name);
    el.className = className;
    return el;
}

function Remove(path) {
    fetch(path, {
        method: 'DELETE'
        })
        .then(() => refresh())
        .catch((ex) => { // обрабатываем возможную ошибку
            console.log("Error: " + ex.message);
            console.log("Response: " + ex.response);
        });
}

function Create(item, path) {

    fetch(path ,
        {
            method: "POST",
            headers: {
                'Content-type': "application/json"
            },
            body: JSON.stringify(item)
        })
        .then(() => refresh())
        .catch((ex) => {
            console.log("Error: " + ex.message);
            console.log("Response: " + ex.response);
        })
}

function Edit(item, button, inputs, path) {
    if (inputs[0].input.readOnly) {
        for (let input of inputs) {
            input.input.readOnly = false;
            input.input.disabled = false;
        }
        button.className = "btn btn-success";
        button.firstChild.className = "fas fa-save";
        return;
    } else {
        for (let input of inputs) {
            input.input.readOnly = true;
            input.input.disabled = true;
            item[input.for] = input.input.value;
        }
        button.className = "btn btn-warning";
        button.firstChild.className = "fas fa-edit";
    }

    fetch(path, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
            // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        body: JSON.stringify(item)
        })
        .then(() => refresh())
        .catch((ex) => { // обрабатываем возможную ошибку
        console.log("Error: " + ex.message);
        console.log("Response: " + ex.response);
        });
}

function RenderTable(table, containerId) {
    let id = "#" + containerId;
    let Container = document.querySelector(id);
    if(Container === null)
    {
        console.log("Wrong container id: " + id);
        return;
    }
    Container.innerHTML = "";
    Container.append(table);
}

function FetchGetJson(path, resultHandler) {
    fetch(path) // Пошлем запрос GET (по умолчанию) по марштуру на сервер
        .then(response => response.json()) // Преобразуем ответ в json
        .then(result => resultHandler(result)) // Передадим данные в метод
        .catch((ex) => { // обрабатываем возможную ошибку
            console.log("FetchError: " + ex.message);
            console.log("FetchResponse: " + ex.response);
        });
}