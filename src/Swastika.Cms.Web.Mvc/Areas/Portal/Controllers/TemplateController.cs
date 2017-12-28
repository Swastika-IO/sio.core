using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Swastika.Cms.Mvc.Controllers;
using System.IO;
using System.Collections.Generic;
using Swastika.Cms.Lib.ViewModels;

namespace Swastika.Cms.Mvc.Areas.Portal.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("Portal")]
    [Route("{culture}/Portal/Template")]
    public class TemplateController : BaseController<TemplateController>
    {
        //private readonly IViewRenderService _viewRenderService;
        public TemplateController(IHostingEnvironment env
            //, IStringLocalizer<PortalController> templateLocalizer
            //, IViewRenderService viewRenderService
            //, IStringLocalizer<SharedResource> localizer
            )
            : base(env)
        {
        }

        [Route("")]
        public IActionResult Index(string keyword, int pageSize = 10, int pageIndex = 0)
        {
            DirectoryInfo d = new DirectoryInfo(@"Views\Shared\Modules");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.cshtml"); //Getting Text files
            List<FileViewModel> result = new List<FileViewModel>();
            foreach (var file in Files)
            {
                using (StreamReader s = Files[0].OpenText())
                {
                    result.Add(new FileViewModel()
                    {
                        Filename = file.Name,
                        Content = s.ReadToEnd()
                    });

                }
            }
            FileViewModel model = new FileViewModel();
            return View(result);
        }

        //[Route("Create")]
        //public IActionResult Create()
        //{
        //    //ViewData["Specificulture"] = new SelectList(_context.TtsCulture, "Specificulture", "Specificulture");
        //    var ttsMenu = new CategoryViewModel(_lang)
        //    {
        //        Id = _repo.GetNextId(),
        //        Specificulture = _lang,
        //        CreatedBy = "admin",
        //        CreatedDate = DateTime.UtcNow
        //    };
        //    return View(ttsMenu);
        //}

        //// POST: TtsMenu/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Route("Create")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(CategoryViewModel ttsMenu)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await ttsMenu.SaveModelAsync();
        //        if (result.IsSucceed)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            throw new Exception(result.Ex.StackTrace);
        //        }
        //    }
        //    return View(ttsMenu);
        //}

        //// GET: TtsMenu/Edit/5
        //[Route("Edit/{id}")]
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ttsMenu = await _repo.GetSingleModelAsync(m => m.Id == id && m.Specificulture == _lang, true);
        //    if (ttsMenu == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(ttsMenu);
        //}

        //// POST: TtsMenu/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Route("Edit/{id}")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, CategoryViewModel ttsMenu)
        //{
        //    if (id != ttsMenu.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var result = await ttsMenu.SaveModelAsync();
        //            if (result.IsSucceed)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError(string.Empty, result.Ex.Message);
        //                return View(ttsMenu);
        //            }
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!_repo.CheckIsExists(m => m.Id == ttsMenu.Id.Value))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        //return RedirectToAction("Index");
        //    }
        //    ViewData["Action"] = "Edit";
        //    ViewData["Controller"] = "Template";
        //    return View(ttsMenu);
        //}

        //[Route("Delete/{id}")]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    var ttsMenu = await _repo.RemoveModelAsync(m => m.Id == id && m.Specificulture == _lang);          
        //    return RedirectToAction("Index");
        //}
    }
    //public class FileViewModel
    //{
    //    public string Filename { get; set; }
    //    public string Content { get; set; }
    //}
}
