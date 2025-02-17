namespace Thor.WebApi.Requests;

public class AddEmployeeRequest
{
    public string Name { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
}