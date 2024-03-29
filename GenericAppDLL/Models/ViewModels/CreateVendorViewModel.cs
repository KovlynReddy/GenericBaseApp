﻿namespace GenericAppDLL.Models.ViewModels;

public class CreateVendorViewModel : BaseViewModel
{
    public string VendorEmail { get; set; } = string.Empty;
    public string VendorName { get; set; } = string.Empty;
    public string VendorAddressGuid { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string MainStreet { get; set; } = string.Empty;
    public string Suburb { get; set; } = string.Empty;
    public string PostCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
    public string Caption { get; set; } = string.Empty;

    public string UserGuid { get; set; } = string.Empty;
    public IFormFile VendorImage { get; set; } 

    public string Lat { get; set; } = string.Empty;
    public string lon { get; set; } = string.Empty;
}
