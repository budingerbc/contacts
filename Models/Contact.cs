using System.Collections.Generic;
using System;

namespace Contacts.Models
{
  public class Contact
  {
    private string _firstName;
    private string _lastName;
    private string _phoneNumber;
    private string _address;
    private int _id;
    private static List<Contact> _contacts = new List<Contact> {};

    public Contact(string first, string last, string phone, string address)
    {
      _firstName = first;
      _lastName = last;
      _phoneNumber = phone;
      _address = address;
      _contacts.Add(this);
      _id = _contacts.Count;
    }

    // Mostly created accessors for returning instance properties since contact data is not being modified
    public string GetFirstName()
    {
      return _firstName;
    }
    public string GetLastName()
    {
      return _lastName;
    }
    public string GetPhoneNumber()
    {
      return _phoneNumber;
    }
    public string GetAddress()
    {
      return _address;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Contact> GetAll()
    {
      return _contacts;
    }
    // Mutator for assistance with removing single contacts, as the ID has to be updated when removing from the static list of contacts
    public void SetId(int id)
    {
      _id = id;
    }
    public static Contact Find(int id)
    {
      return _contacts[id - 1];
    }
    // Clears all contacts out of the static list using a List method
    public static void ClearContacts()
    {
      _contacts.Clear();
    }
    // Removes a single contact from the list and updates all subsequent contact id fields
    public static void RemoveContact(int id)
    {
      // Accounting for the fact that the index and id of the contact are offset by 1
      _contacts.RemoveAt(id - 1);
      // Loops through the rest of the list and updates the id on each contact
      for(int index = id - 1; index < _contacts.Count; index++)
      {
        _contacts[index].SetId(index + 1);
      }
    }
  }
}
