namespace ContactApp
{
    public class ContactCategory
    {
        public short ContactCategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<ContactSubcategory> ContactSubcategories { get; set; }
    }
}