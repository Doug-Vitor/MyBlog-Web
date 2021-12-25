/**
 * Returns the element assigned to the specified id.
 * @param {string} id The element id.
 * @returns {HTMLElement}
 */
function getElementById(id) {
    return document.getElementById(id);
}

/**
 * Removes all div's children and return it.
 * @param {string} id The div's id.
 * @returns {HTMLElement}
 */
function removeDivChildren(id) {
    var div = getElementById(id);
    while (div.lastChild) {
        div.removeChild(div.firstChild);
    }

    return div;
}

/**
 * Creates and returns a element with specified values.
 * @param {string} tagName The element tag name.
 * @param {string} className The class to assign to the element.
 * @returns {HTMLElement}
 */
function createElement(tagName, className) {
    var element = document.createElement(tagName);
    element.className = className;

    return element;
}

/**
 * Return the base URL off the application 
 * @returns {String}
 */
function getBaseUrl() {
    return window.location.origin;
}

/* Bad practises bellow. It'll be fixed. */
function adjustFieldsToEdit() {
    getElementById("form-input-1").removeAttribute('readonly');
    getElementById("form-input-2").removeAttribute('readonly');
    getElementById("form-input-3").removeAttribute('readonly');
    getElementById("form-label-1").className += " required";
    getElementById("form-label-2").className += " required";
    var formTitle = getElementById("form-title");
    formTitle.textContent = "Editar perfil";

    var buttonsDiv = removeDivChildren('buttons-div');
    buttonsDiv.remove();

    var warningDiv = createElement('div', 'warning-div');
    warningDiv.id = "warning-div";
    var warning = createElement('p', 'update-form-warning');
    warning.textContent = "Campos marcados com * são obrigatórios.";
    warningDiv.appendChild(warning);

    var mainDiv = getElementById("update-form");
    mainDiv.appendChild(warningDiv);
    mainDiv.appendChild(buttonsDiv);

    var saveButtonDiv = createElement('div', 'update-form-button-div');
    var saveButton = createElement('input', 'form-button form-save-button');
    saveButton.type = "submit";
    saveButton.value = "Confirmar";
    saveButtonDiv.appendChild(saveButton);
    buttonsDiv.appendChild(saveButtonDiv);

    var cancelButtonDiv = createElement('div', 'update-form-button-div');
    var cancelButton = document.createElement('button', 'form-button form-cancel-button');
    cancelButton.type = "button";
    cancelButton.textContent = "Cancelar";
    cancelButton.addEventListener('click', () => avoidFieldsFromEdit());
    cancelButtonDiv.appendChild(cancelButton);
    buttonsDiv.appendChild(cancelButtonDiv);
}

function avoidFieldsFromEdit() {
    document.getElementById("form-input-1").setAttribute("readonly", true);
    document.getElementById("form-input-2").setAttribute("readonly", true);
    document.getElementById("form-input-3").setAttribute("readonly", true);
    document.getElementById("form-label-1").className = "form-input-label";
    document.getElementById("form-label-2").className = "form-input-label";
    var formTitle = getElementById("form-title");
    formTitle.textContent = "Meu perfil";

    var warningDiv = removeDivChildren('warning-div');
    warningDiv.remove();

    removeDivChildren('buttons-div');

    var editButton = createElement('button', 'form-button');
    editButton.textContent = "Editar";
    editButton.type = "button";
    editButton.id = "edit-profile-button"
    editButton.addEventListener('click', () => adjustFieldsToEdit());
    buttonsDiv.appendChild(editButton);
}
/* Until here */

/**
 * Enable post inputs to edit.
 * @param {number} id The post id.
 * */
function adjustPostToEdit(id) {
    document.getElementById(String.prototype.concat('post-', id, '-actions-top-div')).className += ' hidden';

    var currentParagraphElement = getElementById(String.prototype.concat('post-', id, '-content'));

    var updatePostForm = createElement('form', null);
    updatePostForm.method = 'post';
    updatePostForm.action = String.prototype.concat(getBaseUrl(), '/Posts/Edit/', id);

    var textArea = createElement('textarea', 'post-input');
    textArea.textContent = currentParagraphElement.textContent;
    textArea.rows = "16";
    textArea.name = 'Content';
    textArea.id = 'post-input'

    currentParagraphElement.remove();

    var buttonsDiv = createElement('div', 'update-post-buttons-div');

    var submitButton = createElement('input', 'form-button post-save-button');
    submitButton.textContent = "Confirmar";
    submitButton.type = 'submit';

    var cancelButton = createElement('button', 'form-button form-cancel-button');
    cancelButton.textContent = "Cancelar";
    cancelButton.type = 'button';
    cancelButton.addEventListener('click', () => avoidPostFromEdit(id.valueOf()));

    buttonsDiv.appendChild(submitButton);
    buttonsDiv.appendChild(cancelButton);

    updatePostForm.appendChild(textArea);
    updatePostForm.appendChild(buttonsDiv);
    getElementById(String.prototype.concat('post-', id, '-content-div')).appendChild(updatePostForm);
}

/**
 * Disable post edit inputs.
 * @param {Number} id The post id.
 */
function avoidPostFromEdit(id) {
    var currentInput = getElementById('post-input').textContent;
    var contentDiv = removeDivChildren(String.prototype.concat('post-', id, '-content-div'));

    var contentParagraph = createElement('p', 'class-content');
    contentParagraph.id = String.prototype.concat('post-', id, '-content')
    contentParagraph.textContent = currentInput;
    contentDiv.appendChild(contentParagraph);

    getElementById(String.prototype.concat('post-', id, '-actions-top-div')).className = 'post-actions-top-div';
}

/**
 * Delete the post assigned to the specified id
 * @param {Number} id The post id to delete.
 */
function deletePost(id) {
    var showAlert = confirm('Isso excluirá a publicação. Você tem certeza?')
    if (showAlert == true) {
        location.href = String.prototype.concat(getBaseUrl(), '/Posts/Delete/', id);
    }
}