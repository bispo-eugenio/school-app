import {
  handlerLoginSwitch,
  handlerSignIn,
  handlerSignUp,
  handlerPassword,
} from "./login.js";

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
