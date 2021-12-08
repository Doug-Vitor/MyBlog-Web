/* Bad practises bellow. It'll be fixed. */

function adjustFieldsToEdit() {
    document.getElementById("form-input-1").removeAttribute("readonly");
    document.getElementById("form-input-2").removeAttribute("readonly");
    document.getElementById("form-input-3").removeAttribute("readonly");
    document.getElementById("form-label-1").className += " required";
    document.getElementById("form-label-2").className += " required";
    var formTitle = document.getElementById("form-title");
    formTitle.textContent = "Editar perfil";

    var buttonsDiv = document.getElementById("buttons-div");
    while (buttonsDiv.firstChild) {
        buttonsDiv.removeChild(buttonsDiv.lastChild);
    }
    buttonsDiv.remove();

    var warningDiv = document.createElement("div");
    warningDiv.className = "warning-div";
    warningDiv.id = "warning-div";
    var warning = document.createElement("p");
    warning.className = "update-form-warning";
    warning.textContent = "Campos marcados com * são obrigatórios.";
    warningDiv.appendChild(warning);

    var mainDiv = document.getElementById("update-form");
    mainDiv.appendChild(warningDiv);
    mainDiv.appendChild(buttonsDiv);

    var saveButtonDiv = document.createElement("div");
    saveButtonDiv.className = "update-form-button-div";
    var saveButton = document.createElement("input");
    saveButton.type = "submit";
    saveButton.value = "Confirmar";
    saveButton.className = "form-button form-save-button";
    saveButtonDiv.appendChild(saveButton);
    buttonsDiv.appendChild(saveButtonDiv);

    var cancelButtonDiv = document.createElement("div");
    cancelButtonDiv.className = "update-form-button-div";
    var cancelButton = document.createElement("button");
    cancelButton.type = "button";
    cancelButton.textContent = "Cancelar";
    cancelButton.className = "form-button form-cancel-button";
    cancelButton.addEventListener('click', () => avoidFieldsFromEdit());
    cancelButtonDiv.appendChild(cancelButton);
    buttonsDiv.appendChild(cancelButtonDiv);
};

function avoidFieldsFromEdit() {
    document.getElementById("form-input-1").setAttribute("readonly", true);
    document.getElementById("form-input-2").setAttribute("readonly", true);
    document.getElementById("form-input-3").setAttribute("readonly", true);
    document.getElementById("form-label-1").className = "form-input-label";
    document.getElementById("form-label-2").className = "form-input-label";
    var formTitle = document.getElementById("form-title");
    formTitle.textContent = "Meu perfil";

    var warningDiv = document.getElementById("warning-div");
    while (warningDiv.firstChild) {
        warningDiv.removeChild(warningDiv.lastChild);
    }
    warningDiv.remove();

    var buttonsDiv = document.getElementById("buttons-div");
    while (buttonsDiv.firstChild) {
        buttonsDiv.removeChild(buttonsDiv.lastChild);
    }

    var editButton = document.createElement("button");
    editButton.textContent = "Editar";
    editButton.className = "form-button";
    editButton.type = "button";
    editButton.id = "edit-profile-button"
    editButton.addEventListener('click', () => adjustFieldsToEdit());
    buttonsDiv.appendChild(editButton);
};