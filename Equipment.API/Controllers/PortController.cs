using Equipment.Application.Contracts.Persistence;
using Equipment.Application.UseCases_CQRS.Port.Command;
using Equipment.Application.UseCases_CQRS.Port.Queries;
using Equipment.Application.UseCases_CQRS.Unit.Queries;
using Equipment.Domain.Entities.Ports;
using Equipment.Domain.Entities.Units;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Equipment.API.Controllers
{
    public class PortController(
       IMediator mediator,
       IPortRepository portRepository
       ) : Controller
    {
        public async Task<ActionResult> Index()
        {
            GetPortListResponce responce = await mediator.Send(new GetPortListRequest());
            return View(responce.Ports);
        }



        [HttpGet]
        public async Task<ActionResult> Create(long unitId, string portType)
        {
            ViewBag.CreateMode = true;
            var units = (await mediator.Send(new GetUnitListRequest())).Units;
            ViewBag.InlineUnits = units.Where(u => u is InlineUnit).ToList();
            ViewBag.ReturnURL = HttpContext.Request.Headers.Referer;

            //if (portType == "input")
            //    return View("InPortEditor", new InPort() { EquipmentUnitId = unitId });
            //else
            //    return View("OutPortEditor", new OutPort() { EquipmentUnitId = unitId });
            return Ok();
        }

        //[HttpGet]
        //public async Task<ActionResult> Edit(long id)
        //{
        //    ViewBag.CreateMode = false;
        //    ViewBag.ReturnURL = HttpContext.Request.Headers.Referer;

        //    Port? port = (await mediator.Send(new GetPortRequest(id))).Port;

        //    if (port != null)
        //    {
        //        long parentId = 0;
        //        InPort? inPort = null;
        //        OutPort? outPort = null;
        //        if (port is InPort port1)
        //        {
        //            inPort = port1;
        //            parentId = inPort.EquipmentUnitId;
        //        }
        //        else if (port is OutPort outPort1)
        //        {
        //            outPort = outPort1;
        //            parentId = outPort.EquipmentUnitId;
        //        }


        //        var units = (await mediator.Send(new GetUnitListRequest())).Units;

        //        var parentUnit = units.First(Unit => Unit.Id == parentId);

        //        //if (parentUnit is not InlineUnit)
        //        //    ViewBag.InlineUnits = units.Where(u => u is InlineUnit).ToList();


        //        if (inPort != null)
        //            return View("InPortEditor", inPort);
        //        else if (outPort != null)
        //            return View("OutPortEditor", outPort);

        //    }

        //    return Redirect(HttpContext.Request.Headers.Referer);

        //}


        //[HttpPost]
        //public async Task<ActionResult> CreateInPort(InPort port)
        //{
        //    return await CreatePort(port);
        //}

        //[HttpPost]
        //public async Task<ActionResult> CreateOutPort(OutPort port)
        //{
        //    return await CreatePort(port);
        //}


        //public async Task<ActionResult> EditInPort(InPort port)
        //{
        //    await mediator.Send(new PutPortCommand(port));
        //    return Redirect(Url.Action("Edit", "Unit") + "?id=" + port.EquipmentUnitId);
        //}
        //public async Task<ActionResult> EditOutPort(OutPort port)
        //{
        //    await mediator.Send(new PutPortCommand(port));
        //    return Redirect(Url.Action("Edit", "Unit") + "?id=" + port.EquipmentUnitId);
        //}


        //public async Task<ActionResult> CreatePort(Port port)
        //{
        //    ViewBag.CreateMode = false;

        //    await portRepository.Add(port);

        //    long EquipmentUnitId = 0;
        //    if (port is InPort inPort)
        //    {
        //        EquipmentUnitId = inPort.EquipmentUnitId;
        //        var unit = (await mediator.Send(new GetUnitRequest(EquipmentUnitId))).Unit;
        //        if (unit != null)
        //            return Redirect(Url.Action("Edit", "Unit") + "?id=" + unit.Id);
        //    }
        //    else if (port is OutPort outPort)
        //    {
        //        EquipmentUnitId = outPort.EquipmentUnitId;
        //        var unit = (await mediator.Send(new GetUnitRequest(EquipmentUnitId))).Unit;
        //        if (unit != null)
        //            return Redirect(Url.Action("Edit", "Unit") + "?id=" + unit.Id);
        //    }


        //    return RedirectToAction(nameof(Index), "Unit");
        //}






        //[HttpPost]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    await portRepository.Delete(id);
        //    return Redirect(HttpContext.Request.Headers.Referer);
        //}


        //public async Task<ActionResult> AddInlineUnit(long unit_id, long port_id)
        //{
        //    //EquipmentUnit unit = (await mediator.Send(new GetUnitRequest(unit_id))).Unit!;
        //    //Port port = (await mediator.Send(new GetPortRequest(port_id))).Port!;

        //    //port.InlineUnits.Add((InlineUnit)unit);
        //    //((InlineUnit)unit).PorstsAttachedTo.Add(port);

        //    //await mediator.Send(new PutPortCommand(port));

        //    //return Redirect(Url.Action(nameof(Edit), "Port") + "?id=" + port.Id);
        //    return Ok();

        //}

        //public async Task<ActionResult> DeleteInlineUnit(long unitId, long portId)
        //{
        //    EquipmentUnit unit = (await mediator.Send(new GetUnitRequest(unitId))).Unit!;
        //    Port port = (await mediator.Send(new GetPortRequest(portId))).Port!;

        //    //port.InlineUnits.Remove((InlineUnit)unit);
        //    //((InlineUnit)unit).PorstsAttachedTo.Remove(port);

        //    await mediator.Send(new PutPortCommand(port));

        //    return Redirect(HttpContext.Request.Headers.Referer);

        //}


    }
}
