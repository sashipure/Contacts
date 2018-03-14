using ContactsRestWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace ContactsRestWebAPI.Controllers
{
    public class MyContactsController : ApiController
    {
        #region Initialization
        static List<contact> contactList = new List<contact>() { };
        public MyContactsController()
        {
            FillContacts();

        }
        #endregion

        #region Rest API Actions methods

      

        //List a contact
        // GET api/MyContacts
        public IEnumerable<contact> GetContacts()
        {
            return contactList;
        }


        // GET: api/MyContacts/5
        [ResponseType(typeof(contact))]
        public IHttpActionResult GetContact(int id)
        {
            contact customer = contactList.Find(x => x.contactId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }


        //Add a contact - create new contact
        // POST api/MyContacts
        public void Post([FromBody]contact newContact)
        {
            contactList.Add(newContact);
        }


        //---------------------------Edit a contact---------------------------//
        // PUT api/MyContacts/5
        public void Put(int eidtId, [FromBody]contact objContact)
        {
            contact objEmpModify = contactList.Where(x => x.contactId == eidtId).Single();
            objEmpModify = objContact;
            
        }


        // DELETE: api/MyContacts/5
        [ResponseType(typeof(contact))]
        public IHttpActionResult DeleteContact(int id)
        {
            contact objEmpToRemove = contactList.Where(x => x.contactId == id).Single();
            if (objEmpToRemove == null)
            {
                return NotFound();
            }

            contactList.Remove(objEmpToRemove);

            return Ok(objEmpToRemove);
        }

        #endregion
        
        #region PrivateMethods
        //This is a static Contact List
        private static void FillContacts()
        {
            contactList.Clear();
            contact emp1 = new contact();
            emp1.contactId = 1;
            emp1.fname = "Shilpa";
            emp1.lname = "Shipure";
            emp1.email = "sashipure@gmail.com";
            emp1.phonenumber = "91-9898988819";
            emp1.status = "active";
            contactList.Add(emp1);
            emp1 = new contact();
            emp1.contactId = 2;
            emp1.fname = "Shilpa2";
            emp1.lname = "Shipure2";
            emp1.email = "sashipure@gmail.com";
            emp1.phonenumber = "91-9898988819";
            emp1.status = "active";
            contactList.Add(emp1);
        }
        #endregion
    }
}
