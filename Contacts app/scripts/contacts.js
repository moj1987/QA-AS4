//Partially taken from
//https://codepen.io/sola/pen/GyOReX

(function (global) {
  var AddressBook = function (
    firstName,
    lastName,
    address,
    city,
    province,
    postalCode,
    phone,
    email,
    notes
  ) {
    return new AddressBook.init(
      firstName,
      lastName,
      address,
      city,
      province,
      postalCode,
      phone,
      email,
      notes
    );
  };

  AddressBook.prototype = {
    //default functions
    data: [
      //add data here
    ],
    searchResults: [],
    addNewContact: function (
      firstName,
      lastName,
      address,
      city,
      province,
      postalCode,
      phone,
      email,
      notes
    ) {
      this.data.push({
        firstName: firstName,
        lastName: lastName,
        address: address,
        city: city,
        province: province,
        postalCode: postalCode,
        phone: phone,
        email: email,
        notes: notes,
      });
      return this;
    },
    save: function (
      firstName,
      lastName,
      address,
      city,
      province,
      postalCode,
      phone,
      email,
      notes
    ) {
      //save to local storage. This isn't hugely necessary
      let ContactInfo = {
        firstName: firstName,
        lastName: lastName,
        address: address,
        city: city,
        province: province,
        postalCode: postalCode,
        phone: phone,
        email: email,
        notes: notes,
      };
      localStorage.setItem(firstName, JSON.stringify(ContactInfo));
      var x = this.returnAll();
      console.log(x);
    },

    // displayData: function () {
    //   this.log(this.data);
    //   return this;
    // },
    // log: function (data) {
    //   console.log(data);
    //   return this;
    // },
    returnAll: function () {
      let Contacts = Object.keys(window.localStorage);
      let ContactLength = Contacts.length;
      let i = ContactLength;
      let tempData = [];
      if (ContactLength) {
        while (i--) {
          tempData.push(JSON.parse(localStorage.getItem(Contacts[i])));
        }
        return tempData;
      } else {
        console.log("There are no results");
      }
      //return this;
    },
    lastResults: function () {
      return this.searchResults;
    },
  };

  AddressBook.init = function (
    firstName,
    lastName,
    address,
    city,
    province,
    postalCode,
    phone,
    email,
    notes
  ) {
    var self = this;
    //set up the address book
    if (
      firstName ||
      lastName ||
      address ||
      city ||
      province ||
      postalCode ||
      phone ||
      email ||
      notes
    ) {
      self.addNewContact(
        firstName || "",
        lastName || "",
        address || "",
        city || "",
        province || "",
        postalCode || "",
        phone || "",
        email || "",
        notes || ""
      );
    }
  };

  AddressBook.init.prototype = AddressBook.prototype;

  global.AddressBook = $ab = AddressBook;
})(window);

if (!window.contactList) {
  //check if we already have a contact list
  window.contactList = $ab();
}

var form = document.getElementById("contact");

form.addEventListener("submit", function () {
  //Check Postal code
  let postalPattern = /[A-Za-z]\d[A-Za-z] ?\d[A-Za-z]\d/;
  var isPostalCodeFormatted = postalPattern.test(form.postalCode.value);
  if (!isPostalCodeFormatted) {
    alert("Postal code");
    return;
  }

  //Check phone number
  let phonePattern = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
  var isPhoneNumberFormatted = phonePattern.test(form.phone.value);
  if (!isPhoneNumberFormatted) {
    alert("Phone number");
    return;
  }

  //Check email
  let emailPattern = /\S+@\S+\.\S+/;
  var isEmailFormatted = emailPattern.test(form.email.value);
  if (!isEmailFormatted) {
    alert("Email!");
    return;
  }

  if (!window.contactList) {
    //check if we already have a contact list
    window.contactList = $ab(
      form.firstName.value,
      form.lastName.value,
      form.address.value,
      form.city.value,
      form.province.value,
      form.postalCode.value,
      form.phone.value,
      form.email.value,
      form.notes.value
    );
  } else {
    //saves new values rather than deleting old ones as well
    contactList.addNewContact(
      form.firstName.value,
      form.lastName.value,
      form.address.value,
      form.city.value,
      form.province.value,
      form.postalCode.value,
      form.phone.value,
      form.email.value,
      form.notes.value
    );
    contactList.save(
      form.firstName.value,
      form.lastName.value,
      form.address.value,
      form.city.value,
      form.province.value,
      form.postalCode.value,
      form.phone.value,
      form.email.value,
      form.notes.value
    );
  }

  document.getElementById("contact-panel").style.display = "none";
  document.getElementById("new-panel").innerHTML =
    '<a href="show.html?contact=' +
    form.firstName.value +
    '">' +
    form.firstName.value +
    " " +
    form.lastName.value +
    "</a>";

  form.firstName.value = "";
  form.lastName.value = "";
  form.address.value = "";
  form.city.value = "";
  form.province.value = "";
  form.postalCode.value = "";
  form.phone.value = "";
  form.email.value = "";
  form.notes.value = "";

  event.preventDefault();
});

document.getElementById("js-show-all").addEventListener("click", function () {
  document.getElementById("contact-panel").style.display = "none";

  //check if we already have a contact list
  document.getElementById("show-panel").innerHTML = "";
  var contacts = window.contactList.returnAll();
  console.log(contacts);
  if (contacts.length > 0) {
    for (var i = 0; i < contacts.length; i++) {
      document.getElementById("show-panel").innerHTML +=
        '<div class="contact-item">First name:' +
        contacts[i].firstName +
        "<br>Last name:" +
        contacts[i].lastName +
        "<br>Address:" +
        contacts[i].address +
        "<br>City:" +
        contacts[i].city +
        "<br>Province:" +
        contacts[i].province +
        "<br>Postal Code:" +
        contacts[i].postalCode +
        "<br>Phone:" +
        contacts[i].phone +
        "<br>Email:" +
        contacts[i].email +
        "<br>Notes:" +
        contacts[i].notes +
        "</div><hr>";
    }
  } else {
    document.getElementById("show-panel").innerHTML +=
      '<div class="contact-item">You have no contacts.</div><hr>';
  }

  document.getElementById("show-panel").style.display = "block";
});

document.getElementById("js-add-new").addEventListener("click", function () {
  document.getElementById("show-panel").style.display = "none";
  document.getElementById("contact-panel").style.display = "block";
  //  window.localStorage.clear();
});

function validateForm() {
  let x = document.forms["contact"]["firstName"].value;
  if (x == "") {
    alert("First name must be filled out");
    return false;
  }
}
