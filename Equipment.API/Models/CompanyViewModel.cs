namespace Equipment.API.Models;

public class CompanyViewModel
{
    public long Id {  get; set; }
    public string Name { get; set; }
    public List<string> Stages { get; set; } = [];
}
