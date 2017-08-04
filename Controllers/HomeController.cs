using Microsoft.AspNetCore.Mvc;
using Contacts.Models;
using System.Collections.Generic;
using System;

namespace Contacts.Contollers
{
  public class HomeController : Controller
  {
    // Home page
    [HttpGet("/")]
    public ActionResult Index()
    {
      // Passing the list of all contacts to the view in order to display all contacts
      List<Contact> contacts = Contact.GetAll();
      return View(contacts);
    }

    [HttpGet("/contact/form")]
    public ActionResult AddContact()
    {
      return View();
    }

    // Pulls the data from the new contact form and creates a new contact.  The contact is added to the static list of contacts in the Model constructor
    [HttpPost("/contact/new")]
    public ActionResult NewContact()
    {
      Contact newContact = new Contact(Request.Form["first-name"], Request.Form["last-name"], Request.Form["phone-number"], Request.Form["address"]);
      return View(newContact);
    }

    // Shows the contact's details based on its id
    [HttpGet("/contact/{id}")]
    public ActionResult ContactDetails(int id)
    {
      Contact contactDetails = Contact.Find(id);
      return View(contactDetails);
    }

    // Clears all contacts in the list
    [HttpPost("/contacts/clear")]
    public ActionResult ClearContacts()
    {
      Contact.ClearContacts();
      return View();
    }

    // Removes a single contact from the list
    [HttpPost("/contact/{id}/removed")]
    public ActionResult RemoveContact(int id)
    {
      Contact.RemoveContact(id);
      return View();
    }
  }
}
