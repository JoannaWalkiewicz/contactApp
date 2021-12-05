namespace ContactApp
{
    public class ContactSubcategory
    {
        public short ContactSubcategoryId { get; set; }
        public string CategoryName { get; set; }
        
        public short ContactCategoryId { get; set; }
        public virtual ContactCategory ContactCategory { get; set; }
    }
}