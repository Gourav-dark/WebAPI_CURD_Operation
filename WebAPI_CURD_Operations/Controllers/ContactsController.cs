using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_CURD_Operations.Data;
using WebAPI_CURD_Operations.Models;
using WebAPI_CURD_Operations.Models.AddClassModels;
using WebAPI_CURD_Operations.Models.OperationModels;

namespace WebAPI_CURD_Operations.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly APIDbContext _context;
        public ContactsController(APIDbContext dbcontext )
        {
            this._context = dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            return Ok(await _context.Contacts.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddContacts(AddContact contact)
        {
            var contacts = new Contact() 
            {
                Id=Guid.NewGuid(),
                FullName = contact.FullName,
                Email = contact.Email,
                Phone = contact.Phone,
                Address = contact.Address,
            };
            await _context.Contacts.AddAsync(contacts);
            await _context.SaveChangesAsync();
            return Ok(contacts);
        }
        [HttpPut]
        [Route("id:guid")]
        public async Task<IActionResult> UpdateContacts([FromRoute] Guid id, UpdateContact update_contact)
        {
            var contact=await _context.Contacts.FindAsync(id);
            if(contact != null) 
            {
                contact.FullName = update_contact.FullName;
                contact.Email = update_contact.Email;
                contact.Phone = update_contact.Phone;
                contact.Address = update_contact.Address;

                await _context.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }
    }
}
