function handlerPassword() {
  const img = document.querySelector(".form-container__img");
  const inputPassword = document.querySelector(
    ".form-container__input-password",
  );

  let src = img.getAttribute("src");

  src === "public/icons/eye-slash-fill.svg"
    ? img.setAttribute("src", "public/icons/eye-fill.svg")
    : img.setAttribute("src", "public/icons/eye-slash-fill.svg");

  src === "public/icons/eye-slash-fill.svg"
    ? inputPassword.setAttribute("type", "text")
    : inputPassword.setAttribute("type", "password");

  inputPassword.focus();
}
