using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note obj)
        {
            if (ModelState.IsValid)
            {
                _workAction.Note.Add(obj);

                _workAction.AddEditDeleteLog.Add(new AddEditDeleteLog()
                {
                    NoteText = obj.NoteText,
                    Flag = "Create",
                    ActionDateTime = DateTime.Now
                });
                _workAction.Save();

                TempData["success"] = "Note created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note obj)
        {
            if (ModelState.IsValid)
            {
                _workAction.Note.Update(obj);
                _workAction.AddEditDeleteLog.Add(new AddEditDeleteLog()
                {
                    NoteText = obj.NoteText,
                    Flag = "Edit",
                    ActionDateTime = DateTime.Now
                });
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _workAction.Note.GetFirstOrDefault(u => u.ID == id);
            if (obj == null)
            {
                return NotFound();
            }
            try
            {
                _workAction.Note.Remove(obj);
                _workAction.AddEditDeleteLog.Add(new AddEditDeleteLog()
                {
                    NoteText = obj.NoteText,
                    Flag = "Delete",
                    ActionDateTime = DateTime.Now
                });
                _workAction.Save();
            }
            catch(Exception ex) 
            {
                TempData["success"] = "Note not Deleted " +ex.Message;
                return RedirectToAction("Index");
            }
           
            TempData["success"] = "Note deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
