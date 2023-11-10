using StockPro.CoreBusiness;
using StockPro.UseCases.PluginInterfaces;
using StockPro.UseCases.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPro.UseCases.Products
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository productRepository;

        public AddProductUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

            public async Task ExecuteAsync(Product product)
        {
            if (product == null) return;

            await this.productRepository.AddProductAsync(product);
        }
    }
}
