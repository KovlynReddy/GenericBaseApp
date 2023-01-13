namespace GenericAppDLL.Models.Dto;

public class EditAddressDto : BaseDto
{
    public string Number { get; set; }
    public string Street { get; set; }
    public string MainStreet { get; set; }
    public string Suburb { get; set; }
    public string PostCode { get; set; }
    public string Country { get; set; }
    public string Lat { get; set; }
    public string lon { get; set; }
}
