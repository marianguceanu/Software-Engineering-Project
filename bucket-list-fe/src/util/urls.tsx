const accountController = "http://localhost:5000/api/Account";
export const register = `${accountController}/register`;
export const remove = `${accountController}/remove`;
export const login = `${accountController}/login`;
export const logout = `${accountController}/logout`;

// On all of the above you must add the username to the urls
const destinationControllerAdmin =
  "http://localhost:5000/api/DestinationControllerAdmin/admin";
export const adminAdd = `${destinationControllerAdmin}/add`;
export const adminRemove = `${destinationControllerAdmin}/remove`;
export const adminModify = `${destinationControllerAdmin}/modify`; // + destinationId

const destinationControllerUser =
  "http://localhost:5000/api/DestinationControllerUser/normal";
export const userAddPublic = `${destinationControllerUser}/add/public`;
export const userAddPrivate = `${destinationControllerUser}/add/private`;
export const userRemove = `${destinationControllerUser}/remove`;
export const userModify = `${destinationControllerUser}/modify`;

const displayDestinationsController =
  "http://localhost:5000/api/DisplayDestinations/get";
export const getPublicDestinations = `${displayDestinationsController}/public`; // No username needed
export const getPrivateDestinations = `${displayDestinationsController}/private`;

export const headers = {
  "Content-Type": "application/json",
  Accept: "text/plain",
};
