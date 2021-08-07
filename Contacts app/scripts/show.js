let urlString = window.location.href;
let url = new URL(urlString);
let contactId = url.searchParams.get("contact");

let contactInfo = JSON.parse(localStorage.getItem(contactId));

document.getElementById("show-panel").innerHTML =
  '<div class="contact-item">First name:' +
  contactInfo.firstName +
  "<br>Last name:" +
  contactInfo.lastName +
  "<br>Address:" +
  contactInfo.address +
  "<br>City:" +
  contactInfo.city +
  "<br>Province:" +
  contactInfo.province +
  "<br>Postal Code:" +
  contactInfo.postalCode +
  "<br>Phone:" +
  contactInfo.phone +
  "<br>Email:" +
  contactInfo.email +
  "<br>Notes:" +
  contactInfo.notes +
  "</div><hr>";

var goHomeButton = document.getElementById("home");
goHomeButton.addEventListener("click", function () {
  url = new URL(window.location.origin);
  window.location.replace(url);
});

var removeContactButton = document.getElementById("remove");
removeContactButton.addEventListener("click", function () {
  let urlString = window.location.href;
  let url = new URL(urlString);
  let contactId = url.searchParams.get("contact");
  window.localStorage.removeItem(contactId);
  url = new URL(window.location.origin);
  window.location.replace(url);
});
