using Equipment.API.Utils;
using Equipment.Application.Contracts.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Equipment.API.Controllers
{
    public class CompanyController(
      IMediator mediator,
      ICompanyRepository companyRepository,
      StrategyConverter strategyConverter
      ) : Controller
    {
        //public async Task<ActionResult> Index()
        //{
        //    GetCompanyListResponce responce = await mediator.Send(new GetCompanyListRequest());
        //    return View(responce.Companies);
        //}

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    ViewBag.Stages = strategyConverter.ConvertAllStagesToString();

        //    ViewBag.CreateMode = true;
        //    return View("CompanyEditor", new CompanyViewModel());
        //}

        //[HttpPost]
        //public async Task<ActionResult> Create(CompanyViewModel companyVM)
        //{
        //    var company = await companyRepository.Get(companyVM.Id);
        //    if (company == null && !string.IsNullOrEmpty(companyVM.Name))
        //    {
        //        company = new() { Name = companyVM.Name };
        //        company.SetTreatmentStrategy(strategyConverter.ConvertStagesToInt(companyVM.Stages));
        //        await companyRepository.Add(company);
        //    }
        //    return Redirect(HttpContext.Request.Headers.Referer);
        //}

        //public async Task<ActionResult> Edit(int id)
        //{
        //    ViewBag.Stages = strategyConverter.ConvertAllStagesToString();

        //    ViewBag.CreateMode = false;
        //    var company = await companyRepository.Get(id);
        //    CompanyViewModel companyViewModel = new() { Id = id, Name = company.Name, Stages = strategyConverter.ConvertStagesToString(company.GetTreatmentStrategy()) };


        //    return View("CompanyEditor", companyViewModel);
        //}

        //[HttpPost]
        //public async Task<ActionResult> Edit(CompanyViewModel companyVM)
        //{
        //    var company = await companyRepository.Get(companyVM.Id);
        //    if (company != null)
        //    {
        //        company.Name = companyVM.Name;
        //        //!!!нельзя всё сотрёт
        //        //company.SetTreatmentStrategy(strategyConverter.ConvertStagesToInt(companyVM.Stages));
        //        //не считывается из браузера, добавление происходит через метод AddStageToCompany, удаление через DeleteStage
        //        await companyRepository.Update(company);
        //    }
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpPost]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    await companyRepository.Delete(id);
        //    return RedirectToAction(nameof(Index));
        //}


        ////если кем-то изменено, и страница не обновлена - результат правильного удаления не гарантируется
        //public async Task<ActionResult> DeleteStage(long companyId, int j)
        //{
        //    var company = await companyRepository.Get(companyId);
        //    List<StageType> list = company.GetTreatmentStrategy();
        //    list.RemoveAt(j);
        //    company.SetTreatmentStrategy(list);
        //    await companyRepository.Update(company);
        //    return Redirect(HttpContext.Request.Headers.Referer);
        //}

        //[HttpGet]
        //public async Task<ActionResult> AddStageToCompany(long companyId, string stageType)
        //{
        //    StageType stage = strategyConverter.StringToStageType(stageType);

        //    if (stage != StageType.None)
        //    {
        //        CompanyEntity? company = await companyRepository.Get(companyId);
        //        if (company != null)
        //        {
        //            List<StageType> list = company.GetTreatmentStrategy();
        //            list.Add(stage);
        //            company.SetTreatmentStrategy(list);
        //            await companyRepository.Update(company);
        //        }
        //    }

        //    return Redirect(HttpContext.Request.Headers.Referer);
        //}


    }
}
