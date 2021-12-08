using ContactApp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        public IContactRepository ContactRepository { get; private set; }

        public ContactController(IContactRepository contactRepository)
        {
            this.ContactRepository = contactRepository;
        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return this.ContactRepository.GetAll();
        }

        [HttpDelete]
        public void Delete([FromQuery] int contactId)
        {
            this.ContactRepository.Delete(contactId);
        }

        [HttpPut]
        public void Edit([FromBody]ContactViewModel vm)
        {
            var entity = new Contact
            {
                ContactId = (int)vm.ContactId,
                BirthDate = vm.BirthDate,
                CategoryOther = vm.CategoryOther,
                ContactCategoryId = vm.ContactCategoryId,
                ContactSubcategoryId = vm.ContactSubcategoryId,
                Name = vm.Name,
                Surname = vm.Surname,
                Password = vm.Password,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
            };

            this.ContactRepository.Edit(entity);
        }

        [HttpPost]
        public void Add([FromBody]ContactViewModel vm)
        {
            var entity = new Contact
            {
                BirthDate = vm.BirthDate,
                CategoryOther = vm.CategoryOther,
                ContactCategoryId = vm.ContactCategoryId,
                ContactSubcategoryId = vm.ContactSubcategoryId,
                Name = vm.Name,
                Surname = vm.Surname,
                Password = vm.Password,
                Email = vm.Email,
                PhoneNumber = vm.PhoneNumber,
            };

            this.ContactRepository.Add(entity);
        }
    }
}