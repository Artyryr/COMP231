var ingredientNum = 1;
var directionNum = 1;

function addIngredient() {
    var description = document.createElement("textarea");
    var amount = document.createElement("input");
    var measure = document.createElement("select");
    var removeButton = document.createElement("input");

    var mainDiv = document.createElement("div");
    var amountDiv = document.createElement("div");
    var measureDiv = document.createElement("div");
    var descriptionDiv = document.createElement("div");
    var removeButtonDiv = document.createElement("div");

    var leftDiv = document.createElement("div");
    var rightDiv = document.createElement("div");
    var bottomDiv = document.createElement("div");

    var hr = document.createElement("hr");

    var elements = ["teaspoon", "tablespoon", "cup", "ml", "l", "mg", "g", "kg", "pound", "ounce", "fluid ounce ", "gill", "pint"];

    leftDiv.setAttribute("class", "col-md-4");
    rightDiv.setAttribute("class", "col-md-4");
    bottomDiv.setAttribute("class", "col-md-12");
    descriptionDiv.setAttribute("class", "form-group");
    amountDiv.setAttribute("class", "form-group");
    measureDiv.setAttribute("class", "form-group");
    removeButtonDiv.setAttribute("class", "form-group");

    amount.setAttribute("type", "number");
    amount.setAttribute("Placeholder", "Amount");
    amount.setAttribute("class", "form-control");
    amount.setAttribute("id", "IngredientAmount");
    amount.setAttribute("name", "IngredientAmount");
    amount.setAttribute("data-val", "true");
    amount.setAttribute("data-val-required", "The Amount of Ingredient is required.");

    measure.setAttribute("Placeholder", "Measure");
    measure.setAttribute("class", "form-control");
    measure.setAttribute("id", "IngredientMeasure");
    measure.setAttribute("name", "IngredientMeasure");

    removeButton.setAttribute("type", "button");
    removeButton.setAttribute("value", "Remove Ingredient");
    removeButton.setAttribute("class", "btn text-center btn-danger");
    removeButton.setAttribute("onclick", "removeIngredient(1" + ingredientNum + ")");

    for (var i = 0; i < elements.length; i++) {
        var option = document.createElement("option");
        option.value = elements[i];
        option.text = elements[i];
        measure.appendChild(option);
    }

    description.setAttribute("rows", "2");
    description.setAttribute("Placeholder", "Description");
    description.setAttribute("class", "form-control");
    description.setAttribute("id", "IngredientDescription");
    description.setAttribute("name", "IngredientDescription");

    mainDiv.setAttribute("class", "col-md-12");
    mainDiv.setAttribute("id", "1" + ingredientNum);

    amountDiv.appendChild(amount);
    measureDiv.appendChild(measure);
    leftDiv.appendChild(amountDiv);
    rightDiv.appendChild(measureDiv);
    descriptionDiv.appendChild(description);
    removeButtonDiv.appendChild(removeButton);
    bottomDiv.appendChild(descriptionDiv);
    bottomDiv.appendChild(removeButtonDiv);

    mainDiv.appendChild(hr);
    mainDiv.appendChild(leftDiv);
    mainDiv.appendChild(rightDiv);
    mainDiv.appendChild(bottomDiv);
    mainDiv.appendChild(hr);

    document.getElementById("Ingredients").appendChild(mainDiv);

    ingredientNum++;
}

function addDirection() {
    var input = document.createElement("INPUT");
    var div = document.createElement("div");
    var directionDiv = document.createElement("div");
    var removeButtonDiv = document.createElement("div");
    var removeButton = document.createElement("input");
    var hr = document.createElement("hr");

    input.setAttribute("type", "text");
    input.setAttribute("Placeholder", "Direction text");
    input.setAttribute("class", "form-control");
    input.setAttribute("id", "Directions");
    input.setAttribute("name", "Directions");

    removeButtonDiv.setAttribute("class", "form-group");
    directionDiv.setAttribute("class", "form-group");

    removeButton.setAttribute("type", "button");
    removeButton.setAttribute("value", "Remove Direction");
    removeButton.setAttribute("class", "btn text-center btn-danger");
    removeButton.setAttribute("onclick", "removeIngredient(2" + directionNum + ")");

    removeButtonDiv.appendChild(removeButton);
    directionDiv.appendChild(input);

    div.setAttribute("id", "2" + directionNum);
    div.setAttribute("class", "col-md-12");
    div.appendChild(directionDiv);
    div.appendChild(removeButtonDiv);
    div.appendChild(hr);
    document.getElementById("Directions").appendChild(div);
    directionNum++;
}

function removeIngredient(elementId) {
    var element = document.getElementById(elementId);
    element.parentNode.removeChild(element);
}