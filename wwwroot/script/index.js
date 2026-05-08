function handlerPassword() {
  const imgs = document.querySelectorAll(".form-container__img");
  const inputPassword = document.querySelectorAll(
    ".form-container__input-password",
  );

  imgs.forEach((img) => {
    let src = img.getAttribute("src");

    src === "public/icons/eye-slash-fill.svg"
      ? img.setAttribute("src", "public/icons/eye-fill.svg")
      : img.setAttribute("src", "public/icons/eye-slash-fill.svg");
    inputPassword.forEach((input) => {
      src === "public/icons/eye-slash-fill.svg"
        ? input.setAttribute("type", "text")
        : input.setAttribute("type", "password");
      input.focus();
    });
  });
}

function handlerLoginSwitch() {
  const btn = document.querySelector("button.signIn-and-signUp");
  const fieldsetSignIn = document.querySelector(
    "fieldset.form-container__sign-in",
  );
  const fieldsetSignUp = document.querySelector(
    "fieldset.form-container__sign-up",
  );

  btn.textContent === "" || btn.textContent === "login"
    ? (btn.textContent = "cadastra-se")
    : (btn.textContent = "login");

  if (
    fieldsetSignIn.style.display == "flex" ||
    fieldsetSignIn.style.display == ""
  ) {
    fieldsetSignIn.style.display = "none";
    fieldsetSignUp.style.display = "flex";
  } else if (fieldsetSignUp.style.display == "flex") {
    fieldsetSignUp.style.display = "none";
    fieldsetSignIn.style.display = "flex";
  }
}

function handlerLogin() {}

function handlerSignUp() {}
