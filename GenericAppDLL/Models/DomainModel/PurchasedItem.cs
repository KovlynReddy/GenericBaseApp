﻿namespace GenericAppDLL.Models.DomainModel;

public class PurchasedItem : BaseModel
{
    public string ItemName { get; set; }       = string.Empty;
    public string ItemImage { get; set; }       = string.Empty;
    public string DatePurchased { get; set; }       = string.Empty;
    public string ItemGuid { get; set; }            = string.Empty;
    public string VendorGuid { get; set; }            = string.Empty;
    public string CartId { get; set; }              = string.Empty;
    public int IsPaid { get; set; }
    public int Cost { get; set; }
    public int Amount { get; set; }
    public int Total { get; set; }

}
