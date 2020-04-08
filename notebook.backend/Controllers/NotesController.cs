using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using notebook.backend.Models;
using notebook.backend.Models.RequestModels;

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
         [HttpGet("get")]
        public ActionResult<IEnumerable<Notes>> Get()
        {
            List<Notes> notes = dbContext.Notes.ToList();
            return notes;
        }
        [HttpPost("createnotes")]
        public ActionResult<Notes> CreateNotes([FromBody] NotesRequest notesRequest){
            Notes notes= new Notes();
            notes.PageId=notesRequest.pageid;
            notes.Name=notesRequest.name;
            notes.CreatedOn = DateTime.Now;
            notes.ModifiedOn =DateTime.Now;
            dbContext.Notes.Add(notes);
            dbContext.SaveChanges();
            return notes;
        }
        [HttpPost("updatenotes")]
        public ActionResult<Notes> UpdateNotes([FromBody] NotesRequest notesRequest){
            Notes notes=dbContext.Notes.Where(n=> n.PageId == notesRequest.pageid && n.Id==notesRequest.id).SingleOrDefault();
            notes.Name=notesRequest.name;
            notes.Title=notesRequest.title;
            notes.ModifiedOn=DateTime.Now;
            dbContext.SaveChanges();
            return notes;
        }
        [HttpDelete("deletenotes")]
        public ActionResult<Notes> DeleteNotes([FromBody] NotesRequest notesRequest){
            Notes notes = dbContext.Notes.Where(n=> n.Id==notesRequest.id).SingleOrDefault();
            dbContext.Notes.Remove(notes);
            dbContext.SaveChanges();
            return notes;
        }
    }
}