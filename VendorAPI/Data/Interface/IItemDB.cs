using GenericAppDLL.Models.DomainModel;

namespace VendorAPI.Data.Interface
{
    public interface IItemDB : IBase<MenuItemDto>
    {
        Task<MenuItemDto> UpdateItem(string Id);
    }
}
