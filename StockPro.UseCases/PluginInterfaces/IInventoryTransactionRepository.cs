using StockPro.CoreBusiness;

namespace StockPro.UseCases.PluginInterfaces
{
    public interface IInventoryTransactionRepository
    {
        void PurchaseAsync(string poNumber, Inventory inventory, int quantity, string doneBy, double price);
    }
}