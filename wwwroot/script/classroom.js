import { API_URL, NAME_CLASSROOM_REGEX } from "./constants.js";
import { handlerCreateButtonToTable } from "./utils.js";

export function handlerAddClassroom() {
  const classroomName = document.querySelector(
    "input.section-container__input[id=classroom-name]",
  );
  const token = localStorage.getItem("token");

  if (!NAME_CLASSROOM_REGEX.test(classroomName.value)) {
    alert(
      "Classroom name deve ter apenas letras e números. (LAB1, INFO-3, CLASS-43A, etc",
    );
    return;
  }

  fetch(`${API_URL}/Classroom`, {
    method: "POST",
    headers: {
      "Content-type": "application/json",
      Authorization: `Bearer ${token}`,
    },
    body: JSON.stringify({
      name: classroomName.value,
    }),
  })
    .then((response) => {
      if (response.ok) handlerLoadClassroom();
    })
    .catch((e) => console.error(e.message));
}

export function handlerRemoveClassroom(id) {
  let idClassroom = parseInt(id);
  const token = localStorage.getItem("token");

  fetch(`${API_URL}/Classroom/${idClassroom}`, {
    method: "DELETE",
    headers: {
      "Content-type": "application/json",
      Authorization: `Bearer ${token}`,
    },
  })
    .then((response) => {
      if (response.ok) handlerLoadClassroom();
    })
    .catch((e) => console.error(e.message));
}

export function handlerUpdateClassroom(id, name) {
  let idClassroom = parseInt(id);
  const token = localStorage.getItem("token");
  if (!NAME_CLASSROOM_REGEX.test(name)) {
    alert(
      "Classroom name deve ter apenas letras e números. (LAB1, INFO-3, CLASS-43A, etc",
    );
    return;
  }

  fetch(`${API_URL}/Classroom/${idClassroom}`, {
    method: "PUT",
    headers: {
      "Content-type": "application/json",
      Authorization: `Bearer ${token}`,
    },
    body: JSON.stringify({
      name: name,
    }),
  })
    .then((response) => {
      if (response.ok) handlerLoadClassroom();
    })
    .catch((e) => console.error(e.message));
}

export function handlerCallDialogToClassroom(item) {
  const token = localStorage.getItem("token");
  const dialog = document.querySelector("dialog.section-container__dialog");
  const inputId = document.querySelector(
    "input.dialog-form__input[id=classroom-id]",
  );
  const inputName = document.querySelector(
    "input.dialog-form__input[id=classroom-name]",
  );

  fetch(`${API_URL}/Classroom/${item["id"]}`, {
    method: "GET",
    headers: {
      "Content-type": "application/json",
      Authorization: `Bearer ${token}`,
    },
  })
    .then((response) => response.json())
    .then((data) => {
      inputId.value = data.id;
      inputName.value = data.name;
      dialog.showModal();
    });
}

export function handlerLoadClassroom() {
  const token = localStorage.getItem("token");
  fetch(`${API_URL}/Classroom`, {
    method: "GET",
    headers: {
      "Content-type": "application/json",
      Authorization: `Bearer ${token}`,
    },
  })
    .then((response) => response.json())
    .then((data) => {
      const columnList = ["Register", "Name", "Update", "Delete"];
      const propsList = ["register", "name"];
      const section = document.querySelector("section.section-1");
      const table = document.querySelector("table.section-container__table");
      const newTable = document.createElement("table");
      const tr = document.createElement("tr");

      if (table != null) section.removeChild(table);
      newTable.classList.add("section-container__table");
      columnList.forEach((index) => {
        const td = document.createElement("td");
        td.innerText = index;
        tr.appendChild(td);
      });
      newTable.appendChild(tr);
      data.forEach((item) => {
        const tr = document.createElement("tr");
        propsList.forEach((props) => {
          const td = document.createElement("td");
          td.innerText = item[props];
          tr.appendChild(td);
        });
        let tdUpdate = handlerCreateButtonToTable("Update", "Button", () =>
          handlerCallDialogToClassroom(item),
        );
        let tdDelete = handlerCreateButtonToTable("Delete", "Button", () =>
          handlerRemoveClassroom(item["id"]),
        );
        tr.appendChild(tdUpdate);
        tr.appendChild(tdDelete);
        newTable.appendChild(tr);
      });
      section.appendChild(newTable);
    })
    .catch((e) => console.error(e.message));
}

export default 0;
