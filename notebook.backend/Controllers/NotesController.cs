using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using notebook.backend.Models;

namespace notebook.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
         private notebookContext dbContext;
        public NotesController()
        {
            dbContext = new notebookContext();  
             // bellekte yer açıp tek bir yerde işlemleri yapmamızı sağlıyor
             // aksi takdirde yeni işlemler için her seferinde bellekte yer açmamız gerekir. 
        }
        [HttpPost("createnotes")]
        public ActionResult<Notes> CreateNotes(Notes notes){
            notes.CreatedOn = DateTime.Now;
            notes.ModifiedOn =DateTime.Now;
            dbContext.Notes.Add(notes);
            dbContext.SaveChanges();
            return notes;
        }
        [HttpPost("updatenotes")]
        public ActionResult<Notes> UpdateNotes(Notes notes,string name,string title){
            notes.ModifiedOn=DateTime.Now;
            notes=dbContext.Notes.Where(n=> n.Name==name).SingleOrDefault();
            notes=dbContext.Notes.Where(t=> t.Title==title).SingleOrDefault();
            dbContext.SaveChanges();
            return notes;
        }
        [HttpDelete("deletenotes")]
        public ActionResult<Notes> DeleteNotes(long id){
            Notes notes = dbContext.Notes.Where(n=> n.Id==id).SingleOrDefault();
            dbContext.Notes.Remove(notes);
            dbContext.SaveChanges();
            return notes;
        }
        }
}