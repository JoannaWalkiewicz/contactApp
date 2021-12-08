using ContactApp.Repository;
using ContactApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DictionaryController : ControllerBase
    {
        public IDictionaryRepository DictionaryRepository { get; private set; }

        public DictionaryController(IDictionaryRepository dictionaryRepository)
        {
            this.DictionaryRepository = dictionaryRepository;
        }

        [HttpGet("categories")]
        public List<ListViewModel> GetCatagories()
        {
            return this.DictionaryRepository.GetCategories();
        }

        [HttpGet("subcategories")]
        public List<ListViewModel> GetSubcatagories()
        {
            return this.DictionaryRepository.GetSubCategories();
        }
    }
}