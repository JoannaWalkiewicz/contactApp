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
    }
}