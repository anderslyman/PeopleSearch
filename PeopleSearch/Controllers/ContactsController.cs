using System.Threading.Tasks;
using System.Web.Mvc;
using PeopleSearch.Pocos;
using PeopleSearch.Services.Interfaces;

namespace PeopleSearch.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Search(Payload payload)
        {
            await Task.Yield();

            var contacts = _contactService.SearchContacts(payload.Text);

            return Json(contacts, JsonRequestBehavior.AllowGet);
        }
    }
}