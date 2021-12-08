using ContactApp.Data;
using ContactApp.ViewModels;

namespace ContactApp.Repository
{
    public class DictionaryRepository : IDictionaryRepository
    {
        public DictionaryRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }

        public ApplicationDbContext Context { get; }

        public List<ListViewModel> GetCategories()
        {
            return this.Context.ContactCategories.Select(c => new ListViewModel
            {
                Name = c.CategoryName,
                Value = c.ContactCategoryId
            }).ToList();
        }

        public List<ListViewModel> GetSubCategories()
        {
            return this.Context.ContactSubcategories.Select(c => new ListViewModel
            {
                Name = c.CategoryName,
                Value = c.ContactCategoryId
            }).ToList();
        }
    }
}
