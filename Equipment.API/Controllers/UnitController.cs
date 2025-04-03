using Equipment.Application.Contracts.Persistence;
using Equipment.Application.UseCases_CQRS.Company.Queries;
using Equipment.Application.UseCases_CQRS.Unit.Queries;
using Equipment.Domain.Entities.Units;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Equipment.API.Controllers
{
    public class UnitController(
        IMediator mediator,
        IUnitRepository unitRepository
        ) : Controller
    {
        public async Task<ActionResult> Index()
        {
            GetUnitListResponce responce = await mediator.Send(new GetUnitListRequest());
            //return View(responce.Units.Where(u=>u is not InlineUnit).ToList());
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.CreateMode = true;
            var companies = (await mediator.Send(new GetCompanyListRequest())).Companies;
            List<SelectListItem> items = companies.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                    Selected = false
                };
            });


            ViewBag.Companies = items;
            return View("UnitEditor", new EquipmentUnit());
        }

        [HttpPost]
        public async Task<ActionResult> Create(EquipmentUnit equipmentUnit)
        {
            equipmentUnit.CompanyId = equipmentUnit.Company.Id;
            equipmentUnit.Company = null;
            await unitRepository.Add(equipmentUnit);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            ViewBag.CreateMode = false;
            var companies = (await mediator.Send(new GetCompanyListRequest())).Companies;
            List<SelectListItem> items = companies.ConvertAll(a =>
            {
                return new SelectListItem()
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                    Selected = false
                };
            });

            ViewBag.Companies = items;
            return View("UnitEditor", await unitRepository.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(EquipmentUnit equipmentUnit)
        {
            equipmentUnit.CompanyId = equipmentUnit.Company.Id;
            unitRepository.Update(equipmentUnit);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await unitRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
