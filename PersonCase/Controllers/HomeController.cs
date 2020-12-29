using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonCase.Data;
using PersonCase.Models;

namespace PersonCase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        private readonly UserManager<User> _userManager;

        public HomeController(ApplicationContext applicationContext, UserManager<User> userManager)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var currentUserNotes = _applicationContext.Notes
                  .Where(note => note.User == currentUser)
                  .Include(note => note.NoteAdditions)
                  .ToArray();

                var result = !currentUserNotes.Any() ? Array.Empty<IEnumerable<Note>>() : currentUserNotes
                  .OrderByDescending(note => note.CreationDate)
                  .Select((note, index) => (note, index))
                  .GroupBy(couple => couple.index / 3)
                  .Select(group => group.Select(couple => couple.note))
                  .ToArray();

                return View(result);
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
