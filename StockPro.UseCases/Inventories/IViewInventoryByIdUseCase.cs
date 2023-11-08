using StockPro.CoreBusiness;

namespace StockPro.UseCases.Inventories
{
    public interface IViewInventoryByIdUseCase
    {
        Task<Inventory> ExecuteAsync(int inventoryId);
    }
}