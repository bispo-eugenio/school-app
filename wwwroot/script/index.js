import {
  NAME_REGEX,
  PASSWORD_REGEX,
  EMAIL_REGEX,
  API_URL,
} from "./constants.js";

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
  /**
   * Obs: a função foi escrita dessa forma
   * por causa de alguns erros em relação ao
   * navegador, por isso vai ter algumas
   * atribuições de valores duplicados.
   * */
  const btn = document.querySelector("button.signIn-and-signUp");
  const fieldsetSignIn = document.querySelector(
    "fieldset.form-container__sign-in",
  );
  const fieldsetSignUp = document.querySelector(
    "fieldset.form-container__sign-up",
  );

  btn.textContent === "login"
    ? (btn.textContent = "cadastra-se")
    : (btn.textContent = "login");
  if (
    fieldsetSignIn.style.display == "flex" ||
    fieldsetSignIn.style.display == ""
  ) {
    fieldsetSignIn.setAttribute("display", "none");
    fieldsetSignIn.style.display = "none";
    document.querySelector("#username-sign-in[name=username]").disabled = true;
    document.querySelector("#password-sign-in[name=password]").disabled = true;
    fieldsetSignUp.setAttribute("display", "flex");
    fieldsetSignUp.style.display = "flex";
    document.querySelector("#username-sign-up[name=username").disabled = false;
    document.querySelector("#password-sign-up[name=password]").disabled = false;
    document.querySelector("#email[name=email]").disabled = false;
    document.querySelector("#email-check[name=email-check").disabled = false;
  } else if (fieldsetSignUp.style.display == "flex") {
    fieldsetSignUp.setAttribute("display", "none");
    fieldsetSignUp.style.display = "none";
    document.querySelector("#username-sign-up[name=username").disabled = true;
    document.querySelector("#password-sign-up[name=password]").disabled = true;
    document.querySelector("#email[name=email]").disabled = true;
    document.querySelector("#email-check[name=email-check").disabled = true;
    fieldsetSignIn.setAttribute("display", "flex");
    fieldsetSignIn.style.display = "flex";
    document.querySelector("#username-sign-in[name=username]").disabled = false;
    document.querySelector("#password-sign-in[name=password]").disabled = false;
  }
}

function handlerSignIn() {
  const username = document.querySelector("#username-sign-in[name=username]");
  const password = document.querySelector("#password-sign-in[name=password]");
  let usernameStr = username.value.replace(/\s+/g, "");

  if (usernameStr.length < 3 || usernameStr.length > 25) {
    alert("Nome deve estar entre 3 a 25 caracteres.");
    return false;
  }

  if (!password.length == 12) {
    alert("Senha deve conter 12 caracteres.");
    return;
  }

  if (!NAME_REGEX.test(username.value)) {
    alert("Nome deve ter apenas letras.");
    return false;
  }

  if (!PASSWORD_REGEX.test(password.value)) {
    alert("Senha deve ter letras, números e um caracter especial.");
    return;
  }

  fetch(`${API_URL}/Account/login`, {
    method: "POST",
    headers: {
      "Content-type": "Application/json",
    },
    body: JSON.stringify({
      username: usernameStr,
      password: password.value,
    }),
  })
    .then((response) => {
      if (!response.ok) {
        alert("Conta não existe! Falha ao tentar realizar login.");
        throw new Error(`Http Error: ${response.status}`);
      }
      return response.json();
    })
    .then((data) => {
      if (data !== undefined) {
        localStorage.setItem("token", data.token);
        window.location.href = "/pages/home.html";
      }
    })
    .catch((e) => console.error(e.message));
}

function handlerSignUp() {
  const username = document.querySelector("#username-sign-up[name=username]");
  const password = document.querySelector("#password-sign-up[name=password]");
  const form = document.querySelector("form.form-container");
  const email = document.querySelector("#email[name=email]");
  const emailCheck = document.querySelector("#email-check[name=email-check");
  let usernameStr = username.value.replace(/\s+/g, "");

  if (usernameStr.length < 3 || usernameStr.length > 25) {
    alert("Nome deve ter entre 3 a 25 caracteres.");
    return;
  }

  if (!NAME_REGEX.test(username.value)) {
    alert("Nome deve ter apenas letras.");
    return;
  }

  if (!EMAIL_REGEX.test(email.value)) {
    alert("Email inválido.");
    return;
  }

  if (!email.value === emailCheck.value) {
    alert("Email de verificação não é igual ao email digitado.");
    return;
  }

  if (!password.length == 12) {
    alert("Senha deve conter 12 caracteres.");
    return;
  }

  if (!PASSWORD_REGEX.test(password.value)) {
    alert("Senha deve ter letras, números e um caracter especial.");
    return;
  }

  fetch(`${API_URL}/Account/register/admin`, {
    method: "POST",
    headers: {
      "Content-type": "application/json",
    },
    body: JSON.stringify({
      username: usernameStr,
      email: email.value,
      emailConfirmed: email.value === emailCheck.value ? true : false,
      password: password.value,
    }),
  }).catch((e) => {
    return console.error(e.message);
  });

  form.reset();
  return alert("Conta cadastrada com sucesso!");
}

document
  .querySelector("form.form-container")
  .addEventListener("submit", (event) => event.preventDefault());

document
  .querySelector("button.form-container__btn[name=password-sign-in]")
  .addEventListener("click", () => handlerPassword());

document
  .querySelector("button.form-container__btn[name=password-sign-up]")
  .addEventListener("click", () => handlerPassword());

document
  .querySelector("button.signIn-and-signUp")
  .addEventListener("click", () => handlerLoginSwitch());

document
  .querySelector("button.generic-btn[name=sign-up]")
  .addEventListener("click", () => handlerSignUp());

document
  .querySelector("button.generic-btn[name=sign-in]")
  .addEventListener("click", () => handlerSignIn());
