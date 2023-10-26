using StockPro.CoreBusiness;

namespace StockPro.UseCases.Inventories
{
	public interface IViewInventoriesByNameUseCase
	{
		Task<IEnumerable<Inventory>> ExecuteAsync(string name = "");
	}
}