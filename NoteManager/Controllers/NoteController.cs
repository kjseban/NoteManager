using Microsoft.AspNetCore.Mvc;
using NoteManager.Data;
using NoteManager.Models;
using NoteManager.Repository.IRepository;

namespace NoteManager.Controllers
{
    public class NoteController : Controller
    {
        private readonly IWorkAction _workAction;

        public NoteController(IWorkAction workAction)
        {
                _workAction = workAction;
        }

        public IActionResult Index()
        {
            IEnumerable<Note> objNoteList = _workAction.Note.GetAll();
            return View(objNoteList);
        }

        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note obj)
        {
            if (ModelState.IsValid)
            {
                _workAction.Note.Add(obj);
                _workAction.Save();
                TempData["success"] = "Note created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var noteFromDbFirst = _workAction.Note.GetFirstOrDefault(u => u.ID == id);

            if (noteFromDbFirst == null)
            {
                return NotFound();
            }

            return View(noteFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note obj)
        {
            
            if (ModelState.IsValid)
            {
                _workAction.Note.Update(obj);
                _workAction.Save();
                TempData["success"] = "Note updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var noteFromDbFirst = _workAction.Note.GetFirstOrDefault(u => u.ID == id);

            if (noteFromDbFirst == null)
            {
                return NotFound();
            }

            return View(noteFromDbFirst);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _workAction.Note.GetFirstOrDefault(u => u.ID == id);
            if (obj == null)
            {
                return NotFound();
            }

            _workAction.Note.Remove(obj);
            _workAction.Save();
            TempData["success"] = "Note deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
