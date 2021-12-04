document.getElementById('enable-fields').onclick = function () {
    document.getElementById("enable-fields").remove();

    document.getElementById("form-input-1").removeAttribute("readonly");
    document.getElementById("form-input-2").removeAttribute("readonly");
    document.getElementById("form-input-3").removeAttribute("readonly");

    var newInput = document.createElement("input")
    newInput.value = "Confirmar";
    newInput.className = "form-button form-save-button"
    newInput.type = "submit";
    document.getElementById("update-form-buttons-div").appendChild(newInput);
};