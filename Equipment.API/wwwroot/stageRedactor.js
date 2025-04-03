
function AddStageToCompany(company_id) {

    var e = document.getElementById("stage_selected");
    var stage = e.value;
    //var text = e.options[e.selectedIndex].text;
    var elem = document.getElementById('add_stage');
    elem.href = elem.href + `Company/AddStageToCompany/?companyId=${company_id}&stageType=${stage}`;
}
