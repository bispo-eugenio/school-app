import {
  handlerLoadClassroom,
  handlerAddClassroom,
  handlerUpdateClassroom,
} from "./classroom.js";

import { redirect } from "./utils.js";

function handlerSelectedMenuOption(input) {
  document.querySelectorAll("input.body-container__input").forEach((item) => {
    item.checked = false;
    item.classList.remove("option-select");
    const section = document.querySelector(`section.section-${item.value}`);
    section.style.display = "none";
  });
  input.checked = true;
  input.classList.add("option-select");
  const sectionSelected = document.querySelector(
    `section.section-${input.value}`,
  );
  sectionSelected.style.display = "flex";
  switch (parseInt(input.value)) {
    case 1:
      handlerLoadClassroom();
      break;
    case 2:
      break;
    case 3:
      break;
    case 4:
      break;
    case 5:
      break;
    default:
      break;
  }
}

document
  .querySelector("button.dialog-form__btn-update[name=classroom-btn-update]")
  .addEventListener("click", () => {
    const inputId = document.querySelector(
      "input.dialog-form__input[id=classroom-id]",
    );
    const inputName = document.querySelector(
      "input.dialog-form__input[id=classroom-name]",
    );
    handlerUpdateClassroom(inputId.value, inputName.value);
  });

document
  .querySelector("button.dialog-form__btn-close[name=classroom-btn-close]")
  .addEventListener("click", () => {
    const dialog = document.querySelector("dialog.section-container__dialog");
    dialog.close();
  });

document
  .querySelectorAll("input.body-container__input")
  .forEach((input) =>
    input.addEventListener("click", () => handlerSelectedMenuOption(input)),
  );

document
  .querySelector("button.section-container__btn[name=classroom-btn]")
  .addEventListener("click", () => handlerAddClassroom());

document
  .querySelector("form.section-container_form")
  .addEventListener("submit", (event) => event.preventDefault());

window.addEventListener("load", () => {
  handlerLoadClassroom();
});

redirect();
