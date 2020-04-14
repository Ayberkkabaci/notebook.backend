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
    public class PagesController :ControllerBase
    {
        private NotebookContext dbContext;
        public PagesController()
        {
            dbContext = new NotebookContext();  
             // bellekte yer açıp tek bir yerde işlemleri yapmamızı sağlıyor
             // aksi takdirde yeni işlemler için her seferinde bellkete yer açmamız gerekir. 
        }

         [HttpGet("get")]
        public ActionResult<IEnumerable<Pages>> Get()
        {
            List<Pages> pages = dbContext.Pages.ToList();
            return pages;
        }

        [HttpPost("createpages")]
        public ActionResult<Pages> CreatePages([FromBody] PagesRequest pagesRequest){
            Pages pages=new Pages();

            dbContext.Pages.Where(p=> p.Id==pagesRequest.id).SingleOrDefault();
            pages.FolderId = pagesRequest.folderId;
            //pages.Id=pagesRequest.id;
            pages.Name = pagesRequest.name;
            pages.CreatedOn = DateTime.Now;
            pages.ModifiedOn = DateTime.Now;
            dbContext.Pages.Add(pages);
            dbContext.SaveChanges();
            return pages;
        }

        [HttpDelete("deletepages")]
        public ActionResult<Pages> DeletePages([FromBody] PagesRequest pagesRequest){
            Pages pages = dbContext.Pages.Where(p=> p.Id==pagesRequest.id).SingleOrDefault();
            dbContext.Pages.Remove(pages);
            dbContext.SaveChanges();
            return pages;
        } 
        [HttpPost("updatepages")]
        public ActionResult<Pages> UpdatePages([FromBody] PagesRequest pagesRequest){
            
           Pages pages = dbContext.Pages.Where(p => p.Id==pagesRequest.id && p.FolderId==pagesRequest.folderId).SingleOrDefault();

            pages.Name = pagesRequest.newName;
            dbContext.SaveChanges();
            return pages;
           
          
               
           
           
            
            
          
        }


    }
}