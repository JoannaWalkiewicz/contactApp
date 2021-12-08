using ContactApp.ViewModels;

namespace ContactApp.Repository
{
    public interface IDictionaryRepository
    {
        public List<ListViewModel> GetCategories();

        public List<ListViewModel> GetSubCategories();
    }
}
