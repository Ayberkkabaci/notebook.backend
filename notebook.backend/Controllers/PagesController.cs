using System.Linq;
using Microsoft.AspNetCore.Mvc;
using notebook.backend.Models;

namespace notebook.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController :ControllerBase
    {
        private notebookContext dbContext;
        public PagesController()
        {
            dbContext = new notebookContext();  
             // bellekte yer açıp tek bir yerde işlemleri yapmamızı sağlıyor
             // aksi takdirde yeni işlemler için her seferinde bellkete yer açmamız gerekir. 
        }

        [HttpPost("createpages")]
        public ActionResult<Pages> CreatePages(Pages page,long FolderId){
        dbContext.Pages.Add(page);
        dbContext.SaveChanges();
        return page;
        }
        [HttpDelete("deletepages")]
        public ActionResult<Pages> DeletePages(long id){
            Pages pages = dbContext.Pages.Where(p=> p.Id==id).SingleOrDefault();
            dbContext.Pages.Remove(pages);
            dbContext.SaveChanges();
            return pages;
        } 
        [HttpPost("updatepages")]
        public ActionResult<Pages> UpdatePages(string name){
            Pages page= dbContext.Pages.Where(f=> f.Name==name).SingleOrDefault();
            dbContext.SaveChanges();
            return page;
        }


    }
}