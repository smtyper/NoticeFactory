using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonCase.Data;
using PersonCase.Models;
using PersonCase.ViewModels;

namespace PersonCase.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly ApplicationContext _dbContext;
        private readonly UserManager<User> _userManager;

        public NoteController(ApplicationContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Add() => View();

        [HttpGet("Note/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _dbContext.Notes
                .Include(note => note.NoteAdditions)
                .FirstOrDefaultAsync(note => note.Id == id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNote(NoteViewModel noteModel)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var note = new Note(Guid.NewGuid(), noteModel.Title, noteModel.Text, DateTime.Now, currentUser.Id);
            var entityEntry = _dbContext.Add(note);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("GetById", new { id = entityEntry.Entity.Id });
        }

        [HttpPost("Note/{id}")]
        public async Task<IActionResult> AddAddition(Guid id, NoteAdditionViewModel noteAdditionViewModel)
        {
            var addition = new NoteAddition(Guid.NewGuid(), noteAdditionViewModel.Text, DateTime.Now, id);
            _dbContext.Add(addition);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("GetById", new { id });
        }
    }
}
