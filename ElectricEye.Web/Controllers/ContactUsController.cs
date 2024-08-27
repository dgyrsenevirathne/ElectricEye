using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectricEye.Web.Controllers
{
    
    public class ContactUsController : Controller
    {
        // GET: ContactUs
        public IActionResult Index()
        {
            return View();
        }

        // POST: ContactUs/Send
        [HttpPost]
        public IActionResult Send(string name, string email, string subject, string message)
        {
            // Here you can handle the form submission
            // For example, you can save the data to the database or send an email

            // Display a success message or redirect to a confirmation page
            ViewBag.Message = "Thank you for contacting us. We will get back to you shortly.";
            return View("Index");
        }
    }
}
