using Equipment.Application.Contracts.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Equipment.API.Controllers
{
    public class PumpInlineUnitController(
      IMediator mediator,
      IPumpInlineUnitRepository unitRepository
      ) : Controller
    {
        //public async Task<ActionResult> Index()
        //{
        //    GetPumpInlineUnitListResponce responce = await mediator.Send(new GetPumpInlineUnitListRequest());
        //    return View(responce.Units);
        //}

        //[HttpGet]
        //public async Task<ActionResult> Create()
        //{
        //    ViewBag.CreateMode = true;
        //    var companies = (await mediator.Send(new GetCompanyListRequest())).Companies;
        //    List<SelectListItem> items = companies.ConvertAll(a =>
        //    {
        //        return new SelectListItem()
        //        {
        //            Text = a.Name,
        //            Value = a.Id.ToString(),
        //            Selected = false
        //        };
        //    });


        //    ViewBag.Companies = items;
        //    var newUnit = new PumpInlineUnitEntity();
        //    newUnit.PumpPorts.Add(new PumpInlinePort() { PortNumber = 1 });
        //    newUnit.PumpPorts.Add(new PumpInlinePort() { PortNumber = 2 });
        //    return View("PumpInlineUnitEditor", newUnit);
        //}

        //[HttpPost]
        //public async Task<ActionResult> Create(PumpInlineUnitEntity inlineUnit)
        //{
        //    inlineUnit.CompanyId = inlineUnit.Company.Id;
        //    inlineUnit.Company = null;
        //    await unitRepository.Add(inlineUnit);
        //    return RedirectToAction("Index");
        //}

        //public async Task<ActionResult> Edit(int id)
        //{
        //    ViewBag.CreateMode = false;
        //    var companies = (await mediator.Send(new GetCompanyListRequest())).Companies;
        //    List<SelectListItem> items = companies.ConvertAll(a =>
        //    {
        //        return new SelectListItem()
        //        {
        //            Text = a.Name,
        //            Value = a.Id.ToString(),
        //            Selected = false
        //        };
        //    });

        //    ViewBag.Companies = items;
        //    return View("PumpInlineUnitEditor", await unitRepository.Get(id));
        //}

        //[HttpPost]
        //public async Task<ActionResult> Edit(PumpInlineUnitEntity inlineUnit)
        //{
        //    if ((await mediator.Send(new GetPumpInlineUnitRequest(inlineUnit.Id))).Unit is PumpInlineUnitEntity existedUnit)
        //    {
        //        existedUnit.Name = inlineUnit.Name;
        //        existedUnit.CompanyId = inlineUnit.Company.Id;
        //        existedUnit.PumpPorts[0] = inlineUnit.PumpPorts[0];
        //        existedUnit.PumpPorts[^1] = inlineUnit.PumpPorts[^1];
        //        await unitRepository.Update(existedUnit);
        //    }
        //    return Redirect(HttpContext.Request.Headers.Referer);
        //}

        //[HttpPost]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    await unitRepository.Delete(id);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
