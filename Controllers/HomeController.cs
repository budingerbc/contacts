using Microsoft.AspNetCore.Mvc;
using Contacts.Models;
using System.Collections.Generic;
using System;

namespace Contacts.Contollers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      List<Contact> contacts = Contact.GetAll();
      return View(contacts);
    }

    [HttpGet("/contact/form")]
    public ActionResult AddContact()
    {
      return View();
    }

    [HttpPost("/contact/new")]
    public ActionResult NewContact()
    {
      Contact newContact = new Contact(Request.Form["first-name"], Request.Form["last-name"], Request.Form["phone-number"], Request.Form["address"]);
      return View(newContact);
    }

    [HttpGet("/contact/{id}")]
    public ActionResult ContactDetails(int id)
    {
      Contact contactDetails = Contact.Find(id);
      return View(contactDetails);
    }

    [HttpPost("/contacts/clear")]
    public ActionResult ClearContacts()
    {
      Contact.ClearContacts();
      return View();
    }

    [HttpPost("/contact/{id}/removed")]
    public ActionResult RemoveContact(int id)
    {
      Contact.RemoveContact(id);
      return View();
    }
  }
}
