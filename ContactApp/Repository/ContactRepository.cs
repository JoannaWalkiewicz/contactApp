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

        // Delete contact entity
        public void Delete(int contactId)
        {
            var contact = this.Context.Contacts.First(x => x.ContactId == contactId);
            this.Context.Contacts.Remove(contact); 
            this.Context.SaveChanges();
        }


        // Get all contacts from database
        public List<Contact> GetAll()
        {
            return this.Context.Contacts.ToList();
        }
    }
}
