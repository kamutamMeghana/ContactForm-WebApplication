using Microsoft.AspNetCore.Mvc;
using ContactForm.Models;

public class ContactController : Controller
{
    private readonly BestStoreContext _context;

    public ContactController(BestStoreContext context)
    {
        _context = context;
    }

    // GET: Contact
    public IActionResult Index(int? id)
    {
        // Get all contacts for display
        var contacts = _context.Contacts.ToList();
        ViewBag.Contacts = contacts;

        // If editing, load that contact into the form
        ContactDto model = new ContactDto();
        if (id.HasValue)
        {
            var contact = _context.Contacts.Find(id.Value);
            if (contact != null)
            {
                model = new ContactDto
                {
                    uniqueid = contact.Uniqueid,
                    FirstName = contact.Firstname,
                    LastName = contact.Lastname,
                    Email = contact.Email,
                    Message = contact.Message
                };
            }
        }

        return View(model);
    }

    // POST: Create
    [HttpPost]
    public IActionResult Create(ContactDto contactDto)
    {
        var contact = new Contact
        {
            Firstname = contactDto.FirstName,
            Lastname = contactDto.LastName,
            Email = contactDto.Email,
            Message = contactDto.Message,
            Createddate = DateTime.UtcNow
        };

        _context.Contacts.Add(contact);
        _context.SaveChanges();

        TempData["SuccessMessage"] = "Contact created successfully!";
        return RedirectToAction("Index");
    }

    // GET: Edit (load into form)
    public IActionResult Edit(int id)
    {
        return RedirectToAction("Index", new { id });
    }

    // POST: Edit (update in DB)
    [HttpPost]
    public IActionResult Edit(ContactDto contactDto)
    {
        var contact = _context.Contacts.Find(contactDto.uniqueid);
        if (contact == null) return NotFound();

        contact.Firstname = contactDto.FirstName;
        contact.Lastname = contactDto.LastName;
        contact.Email = contactDto.Email;
        contact.Message = contactDto.Message;

        _context.Contacts.Update(contact);
        _context.SaveChanges();

        TempData["SuccessMessage"] = "Contact updated successfully!";
        return RedirectToAction("Index");
    }

    // POST: Delete
    [HttpPost]
    public IActionResult Delete(int uniqueid)
    {
        var contact = _context.Contacts.Find(uniqueid);
        if (contact == null) return NotFound();

        _context.Contacts.Remove(contact);
        _context.SaveChanges();

        TempData["SuccessMessage"] = "Contact deleted successfully!";
        return RedirectToAction("Index");
    }
}
