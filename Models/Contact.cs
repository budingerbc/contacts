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
    public void SetId(int id)
    {
      _id = id;
    }
    public static Contact Find(int id)
    {
      return _contacts[id - 1];
    }
    public static void ClearContacts()
    {
      _contacts.Clear();
    }
    public static void RemoveContact(int id)
    {
      _contacts.RemoveAt(id - 1);
      for(int index = id - 1; index < _contacts.Count; index++)
      {
        _contacts[index].SetId(index + 1);
      }
    }
  }
}
