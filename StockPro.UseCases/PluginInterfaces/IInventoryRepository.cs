﻿using StockPro.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPro.UseCases.PluginInterfaces
{
	public interface IInventoryRepository
	{
        Task AddInventoryAsync(Inventory inventory);
        Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
		Task UpdateInventoryAsync(Inventory inventory);
	}
}
