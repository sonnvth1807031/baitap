using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Entity;
using App2.Utils;

namespace App2.Model
{
    class ContactModel
    {
        public bool Insert(Contact contact)
        {
            try
            {
                using (var stt = SQliteUltils.GetIntances().Connection.Prepare("INSERT INTO Contact (Name, PhoneNumber) VALUES (?, ?)"))
                {
                    stt.Bind(1, contact.Name);
                    stt.Bind(2, contact.PhoneNumber);
                    stt.Step();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

        public bool SeachContact(Contact contact)
        {
            try
            {
                List<Contact> contacts = new List<Contact>();
                using (var stt = SQliteUltils.GetIntances().Connection.Prepare("SELECT * from Contact WHERE (Name, PhoneNumber) VALUES (?, ?)"))
                {
                    stt.Bind(1, contact.Name);
                    stt.Bind(2, contact.PhoneNumber);
                    stt.Step();
                    while (stt.Step() == SQLitePCL.SQLiteResult.ROW)
                    {
                        var anhson = new Contact();
                        anhson.Name = (string)stt[1];
                        anhson.PhoneNumber = (string)stt[2];
                        contacts.Add(anhson);
                    }             
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

    }
}
