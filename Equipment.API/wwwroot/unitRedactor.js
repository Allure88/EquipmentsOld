function add_input_click_handler(clicked_id) {

    const stringPortId = new String(clicked_id);
    var divElem = document.getElementById("in_ports")
    var newElem = document.createElement('div');


    var html_str = `
    <div class="row">
        <div class="col-auto border py-1" style="background-color: #EBEBEB ; min-width: 70px">${stringPortId}</div>
        <div class="col-2 border py-1" style="background-color: #EBEBEB">@unit.Name</div>
        <div class="col-2 border py-1" style="background-color: #EBEBEB">@unit.Company.Name</div>
        @*         <div class="col-1 border py-1" style="background-color: #EBEBEB">@unit.InPorts.Count</div>
        <div class="col-1 border py-1" style="background-color: #EBEBEB">@unit.OutPorts.Count</div> *@
        <div class="col-2 border py-1" style="background-color: #EBEBEB">
            <div class="d-flex mb-1">
                <a asp-action="Edit" class="btn btn-sm btn-outline-warning flex-fill me-1" asp-route-id="@unit.Id">Редактировать</a>
            </div>
        </div>
        <div class="col-2 border py-1" style="background-color: #EBEBEB">
            <form asp-action="Delete" method="post">
                <div class="d-flex mb-1">
                    <input type="hidden" name="id" value="@unit.Id" />
                    <button type="submit" class="btn btn-sm btn-outline-danger flex-fill me-1">Удалить</button>
                </div>
            </form>
        </div>
    </div>`;

    newElem.innerHTML = html_str;
    divElem.appendChild(newElem);
}


function AddEquipmentToUnit(port_id) {

    var e = document.getElementById("unit_selected");
    var unit_id = e.value;
    //var text = e.options[e.selectedIndex].text;
    var elem = document.getElementById('add_equipment');
    elem.href = elem.href + `Port/AddInlineUnit/?unit_id=${unit_id}&port_id=${port_id}`;
}
