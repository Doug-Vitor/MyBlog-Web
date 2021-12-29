/**
 * Returns the element assigned to the specified id.
 * @param {string} id The element id.
 * @returns {HTMLElement}
 */
function getElementById(id) {
    return document.getElementById(id);
}

/**
 * Append multiple elements to the specified parent div.
 * @param {HTMLElement} parentDiv The parent div.
 * @param {HTMLCollectionOf<HTMLElement>} children The children.
 */
function appendChildren(parentDiv, children) {
    if (parentDiv == null || children == null) {
        return;
    }

    for (var count = 0; count < children.length; count++) {
        parentDiv.appendChild(children[count]);
    }
}

/**
 * Removes all div's children and return the parent div.
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

/**
 * Adjust the profile page to update the authenticated user.
 * */
function adjustFieldsToEdit() {
    adjustFieldsDivToEdit();

    getElementById("form-title").textContent = "Editar perfil";

    var buttonsDiv = removeDivChildren('buttons-div');
    buttonsDiv.remove();

    var warningDiv = createElement('div', 'warning-div');
    warningDiv.id = "warning-div";
    var warning = createElement('p', 'update-form-warning');
    warning.textContent = "Campos marcados com * são obrigatórios.";
    warningDiv.appendChild(warning);

    var mainDiv = getElementById("update-form");
    appendChildren(mainDiv, [warningDiv, buttonsDiv]);

    var saveButtonDiv = createElement('div', 'update-form-button-div');
    var saveButton = createElement('input', 'form-button form-save-button');
    saveButton.type = "submit";
    saveButton.value = "Confirmar";
    saveButtonDiv.appendChild(saveButton);

    var cancelButtonDiv = createElement('div', 'update-form-button-div');
    var cancelButton = createElement('button', 'form-button form-cancel-button');
    cancelButton.type = "button";
    cancelButton.textContent = "Cancelar";
    cancelButton.addEventListener('click', () => avoidFieldsFromEdit());

    cancelButtonDiv.appendChild(cancelButton);
    appendChildren(buttonsDiv, [saveButtonDiv, cancelButtonDiv]);
}

/**
 * Remove input's readonly attributes and set required class to labels.
 * */
function adjustFieldsDivToEdit() {
    var datasDivChildren = getElementById('datas-div').children;

    for (var count1 = 0; count1 < datasDivChildren.length; count1++) {
        var fieldDivChildren = datasDivChildren[count1].children;

        for (var count2 = 0; count2 < fieldDivChildren.length; count2++) {
            var child = fieldDivChildren[count2];
            var childTagName = child.tagName.toLowerCase();

            if (childTagName === 'input') {
                child.removeAttribute('readonly');
            } else if (childTagName === 'label') {
                child.className += ' required';
            }
        }
    }
}

/**
 * Adjust the profile page to avoid the update to authenticated user.
 * */
function avoidFieldsFromEdit() {
    avoidFieldsDivFromEdit();
    getElementById("form-title").textContent = "Meu perfil";;

    var warningDiv = removeDivChildren('warning-div');
    warningDiv.remove();

    var buttonsDiv = removeDivChildren('buttons-div');

    var editButton = createElement('button', 'form-button');
    editButton.textContent = "Editar";
    editButton.type = "button";
    editButton.id = "edit-profile-button"
    editButton.addEventListener('click', () => adjustFieldsToEdit());
    buttonsDiv.appendChild(editButton);
}

/**
 * Set input fields with readonly attributes and remove label's required class.
 * */
function avoidFieldsDivFromEdit() {
    var datasDivChildren = getElementById('datas-div').children;

    for (var count1 = 0; count1 < datasDivChildren.length; count1++) {
        var fieldDivChildren = datasDivChildren[count1].children;

        for (var count2 = 0; count2 < fieldDivChildren.length; count2++) {
            var child = fieldDivChildren[count2];
            var childTagName = child.tagName.toLowerCase();

            if (childTagName === 'input') {
                child.setAttribute('readonly', true);
            } else if (childTagName === 'label') {
                child.className = 'form-input-label';
            }
        }
    }
}

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

    appendChildren(buttonsDiv, [submitButton, cancelButton]);
    appendChildren(updatePostForm, [textArea, buttonsDiv]);
    appendChildren(getElementById(String.prototype.concat('post-', id, '-content-div')), [updatePostForm]);
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