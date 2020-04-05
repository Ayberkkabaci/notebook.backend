using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using notebook.backend.Models;
using notebook.backend.Models.RequestModels;

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
        [HttpGet("get")]
        public ActionResult<IEnumerable<Folder>> Get()
        {
            List<Folder> folders = dbContext.Folder.ToList();
            return folders;
        }
        
        [HttpPost("createfolder")]
        public ActionResult<Folder> CreateFolder([FromBody]FolderRequest folderRequest){
            Folder folder = new Folder();
            dbContext.Users.Where(u=> u.Id==folderRequest.userId).SingleOrDefault();
            folder.UserId = folderRequest.userId;
            folder.Id= (long)folderRequest.id;
            folder.Name = folderRequest.name;
            folder.CreatedOn = DateTime.Now;
            folder.ModifiedOn = DateTime.Now;
            
            dbContext.Folder.Add(folder);
            dbContext.SaveChanges();
            return folder;
        }
        [HttpDelete("deletefolder")]
        public ActionResult<Folder> DeleteFolder([FromBody]FolderRequest folderRequest){
            Folder folder = dbContext.Folder.Where(f=> f.Id==folderRequest.id && f.UserId==folderRequest.userId).SingleOrDefault();
            dbContext.Folder.Remove(folder);
            dbContext.SaveChanges();
            return folder;
        }
        [HttpPost("updatefolder")]
        public Boolean UpdateFolder([FromBody]FolderRequest folderRequest)
        {
            Folder folder = dbContext.Folder.Where(f => f.Name==folderRequest.newName && f.Id==folderRequest.id && f.UserId==folderRequest.userId).SingleOrDefault();
            return true;
           /* if(folder != null)
            {
                folder.Name = folderRequest.newName;
                dbContext.SaveChanges();
                return true;
            }
            return false;*/
        }
    }
}