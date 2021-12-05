namespace ContactApp.Repository
{
    public interface IContactRepository
    {
        public List<Contact> GetAll();
        void Delete(int contactId);
    }
}
