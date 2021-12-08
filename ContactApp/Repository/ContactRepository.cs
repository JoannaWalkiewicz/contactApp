using ContactApp.Data;

namespace ContactApp.Repository
{
    public class ContactRepository : IContactRepository
    {
        public ContactRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public ApplicationDbContext Context { get; }

        public void Add(Contact contact)
        {
            this.Context.Contacts.Add(contact);
            this.Context.SaveChanges();
        }

        // Delete contact entity
        public void Delete(int contactId)
        {
            var contact = this.Context.Contacts.First(x => x.ContactId == contactId);
            this.Context.Contacts.Remove(contact); 
            this.Context.SaveChanges();
        }

        public void Edit(Contact contact)
        {
            var contactEntity = this.Context.Contacts.First(x => x.ContactId == contact.ContactId);
            contactEntity.ContactCategory = contact.ContactCategory;
            contactEntity.BirthDate = contact.BirthDate;  
            contactEntity.Name = contact.Name;
            contactEntity.Surname = contact.Surname;
            contactEntity.ContactCategory = contact.ContactCategory;
            contactEntity.PhoneNumber = contact.PhoneNumber;    
            contactEntity.ContactCategoryId = contact.ContactCategoryId;
            contactEntity.ContactSubcategoryId = contact.ContactSubcategoryId;
            contactEntity.CategoryOther = contact.CategoryOther;

            this.Context.SaveChanges();
        }


        // Get all contacts from database
        public List<Contact> GetAll()
        {
            return this.Context.Contacts.ToList();
        }
    }
}
