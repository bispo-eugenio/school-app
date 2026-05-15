export function handlerCreateButtonToTable(text, type, func) {
  const td = document.createElement("td");
  const button = document.createElement("button");
  button.innerText = text;
  button.type = type;
  button.addEventListener("click", func);
  td.appendChild(button);
  return td;
}

export function redirect() {
  const token = localStorage.getItem("token");
  if (token == null || token == "") window.location.href = "../";
}

export default 0;
