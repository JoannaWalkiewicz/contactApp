namespace ContactApp
{
    public class ContactViewModel
    {
        public int? ContactId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password{ get; set; }

        public string? CategoryOther { get; set; }

        public string PhoneNumber { get; set; }
        
        public string BirthDate { get; set; }

        public short ContactCategoryId { get; set; }
       
        public short? ContactSubcategoryId { get; set; }
    }
}