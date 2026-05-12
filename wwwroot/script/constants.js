//REGEX
export const NAME_REGEX = /^[A-Za-zÀ-ÖØ-öø-ÿ\s'-]{3,25}$/;
export const PASSWORD_REGEX =
  /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[#$%&@])[a-zA-Z0-9#$%&@]{12}$/;
export const EMAIL_REGEX = /^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$/;
//BUILD
export const API_URL = "http://localhost:5179/api";

export default 0;
