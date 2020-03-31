using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using notebook.backend.Models;

namespace notebook.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController :ControllerBase
    {
        private notebookContext dbContext;
        public FolderController()
        {
            dbContext = new notebookContext();  
             // bellekte yer açıp tek bir yerde işlemleri yapmamızı sağlıyor
             // aksi takdirde yeni işlemler için her seferinde bellekte yer açmamız gerekir. 
        }

        [HttpPost("createfolder")]
        public ActionResult<Folder> CreateFolder(long userId, string name){
            Folder folder = new notebook.backend.Models.Folder();
            folder.UserId = userId;
            folder.Name = name;
            folder.CreatedOn = DateTime.Now;
            folder.ModifiedOn = DateTime.Now;
            
            dbContext.Folder.Add(folder);
            dbContext.SaveChanges();
            
            return folder;
        }
        [HttpDelete("deletefolder")]
        public ActionResult<Folder> DeleteFolder(long id){
            Folder folder = dbContext.Folder.Where(f=> f.Id==id).SingleOrDefault();
            dbContext.Folder.Remove(folder);
            dbContext.SaveChanges();
            return folder;
        }
        [HttpPost("updatefolder")]
        public ActionResult<Folder> UpdateFolder(string name){
            Folder folder= dbContext.Folder.Where(f=> f.Name==name).SingleOrDefault();
            dbContext.SaveChanges();
            return folder;
        }
    }
}

