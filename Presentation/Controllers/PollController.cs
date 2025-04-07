using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class PollController : Controller
    {

        public IActionResult Index([FromServices] PollRepository pollRepository)
        {
            var polls = pollRepository.GetPolls();
            return View(polls);
        }

        [HttpPost]
        public IActionResult CreatePoll([FromServices] PollRepository pollRepository, string title, string option1Text, string option2Text, string option3Text,
                                        int option1VotesCount = 0, int option2VotesCount = 0, int option3VotesCount = 0)
        {
            try
            {
                // Use the PollRepository to create and save the poll
                pollRepository.CreatePoll(title, option1Text,
                                          option2Text, option3Text,
                                          option1VotesCount, option2VotesCount, option3VotesCount);

                TempData["Message"] = "Poll created successfully!";
            } catch (Exception ex)
            {
                // Handle any exceptions that occur during the poll creation
                ModelState.AddModelError("", $"An error occurred while creating the poll: {ex.Message}");
                return View("Index");
            }



            // Redirect to index page
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult CreatePollForm()
        {
            return View();
        }
    }
}
