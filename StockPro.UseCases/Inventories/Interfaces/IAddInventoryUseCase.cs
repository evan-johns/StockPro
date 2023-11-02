using StockPro.CoreBusiness;

namespace StockPro.UseCases.Inventories.Interfaces
{
    public interface IAddInventoryUseCase
    {
        Task ExecuteAsync(Inventory inventory);
    }
}