//Partially taken from 
//https://codepen.io/sola/pen/GyOReX

;(function(global){
   var AddressBook = function(firstName,lastName,address,city,province,postalCode,phone,email,notes){
     return new AddressBook.init(firstName,lastName,address,city,province,postalCode,phone,email,notes);
   };
   
   AddressBook.prototype = {
     //default functions
     data:[
       //add data here
     ],
     searchResults:[
       
     ],
     addNewContact:function(firstName,lastName,address,city,province,postalCode,phone,email,notes){
       this.data.push({
         firstName: firstName,
         lastName:lastName,
         address:address,
         city:city,
         province:province,
         postalCode:postalCode,
         phone:phone,
         email:email,
         notes:notes
       });
       return this;
     },
     save:function(){
       //save to local storage. This isn't hugely necessary
       localStorage.setItem(firstName, firstName);
     },
     returnAll:function(){
       return this.data;
     },
     displayData:function(){
       this.log(this.data);
       return this;
     },
     log:function(data){
       console.log(data);
       return this;
     },
     search:function(searchTerm){
       if(this.data.length){
         for(var i=0;i<this.data.length;i++){
           if(this.data[i].firstName.toLowerCase() == searchTerm.toLowerCase()){
             console.error(this.data[i]);
             this.searchResults.push(this.data[i]);
           }
         }
         
         return this.searchResults;
       }else{
         console.log("There are no results");
       }
       return this;
     },
     lastResults:function(){
       return this.searchResults;
     }
   } 
   
   AddressBook.init=function(firstName,lastName,address,city,province,postalCode,phone,email,notes){
     var self = this;
     //set up the address book
     if(firstName ||lastName || address ||city ||province||postalCode|| phone || email||notes){
       self.addNewContact(firstName || "",lastName||"", address||"", city || "",province||"",postalCode||"", phone ||"", email||"",notes||"");
     }
     
   }
   
   AddressBook.init.prototype = AddressBook.prototype;
  
  global.AddressBook = $ab = AddressBook;
})(window);

if(!window.contactList){ //check if we already have a contact list
   window.contactList=$ab();
  }

var form  = document.getElementById('contact');
form.addEventListener('submit', function(){
   if(!window.contactList){ //check if we already have a contact list
   window.contactList=$ab(form.firstName.value,
                         form.lastName.value,
                         form.address.value,
                         form.city.value,
                         form.province.value,
                         form.postalCode.value,
                         form.phone.value,
                         form.email.value,
                         form.notes.value);
  } else {
  //saves new values rather than deleting old ones as well
    contactList.addNewContact(form.firstName.value,
                         form.lastName.value,
                         form.address.value,
                         form.city.value,
                         form.province.value,
                         form.postalCode.value,
                         form.phone.value,
                         form.email.value,
                         form.notes.value);
  }
   

    document.getElementById('contact-panel').style.display = 'none';
    document.getElementById('new-panel').innerHTML += '<a href="show.html">'+
                                                        form.firstName.value+" "+
                                                        form.lastName.value+'</a>';
    
    form.firstName.value= '';
    form.lastName.value= '';
    form.address.value= '';
    form.city.value= '';
    form.province.value= '';
    form.postalCode.value= '';
    form.phone.value= '';
    form.email.value= '';
    form.notes.value= '';

    event.preventDefault();
});

document.getElementById('js-show-all').addEventListener('click', function(){
  if(window.contactList){ //check if we already have a contact list
     document.getElementById('show-panel').innerHTML = '';
   var contacts = contactList.returnAll();
    console.log(contacts);
    if(contacts.length>0){
      for(var i = 0;i<contacts.length;i++){
      document.getElementById('show-panel').innerHTML += '<div class="contact-item">First name:'+contacts[i].firstName+
                                                         '<br>Last name:'+contacts[i].lastName+
                                                         '<br>Address:'+contacts[i].address+
                                                         '<br>City:'+contacts[i].city+
                                                         '<br>Province:'+contacts[i].province+
                                                         '<br>Postal Code:'+contacts[i].postalCode+
                                                         '<br>Phone:'+contacts[i].phone+
                                                         '<br>Email:'+contacts[i].email+
                                                         '<br>Notes:'+contacts[i].notes+'</div><hr>';
      }
    }else{
      document.getElementById('show-panel').innerHTML += '<div class="contact-item">You have no contacts. Why not add  a few?</div><hr>';
    }
  }

  document.getElementById('show-panel').style.display = 'block';
  document.getElementById('contact-panel').style.display = 'none';
});

document.getElementById('js-add-new').addEventListener('click', function(){
  
  document.getElementById('show-panel').style.display = 'none';
  document.getElementById('contact-panel').style.display = 'block';
});

function validateForm() {
  let x = document.forms["contact"]["firstName"].value;
  if (x == "") {
    alert("First name must be filled out");
    return false;
  }

} 