using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockPro.Plugins.EFCoreSqlSever;
using StockPro.Plugins.InMemory;
using StockPro.UseCases.Activities;
using StockPro.UseCases.Activities.Interfaces;
using StockPro.UseCases.Inventories;
using StockPro.UseCases.Inventories.Interfaces;
using StockPro.UseCases.PluginInterfaces;
using StockPro.UseCases.Products;
using StockPro.UseCases.Products.Interfaces;
using StockPro.UseCases.Reports;
using StockPro.UseCases.Reports.Interfaces;
using StockPro.WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// configure authorizations
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim("Department", "Administration"));
    options.AddPolicy("Inventory", policy => policy.RequireClaim("Department", "InventoryManagement"));
    options.AddPolicy("Sales", policy => policy.RequireClaim("Department", "Sales"));
    options.AddPolicy("Purchasers", policy => policy.RequireClaim("Department", "Purchasing"));
    options.AddPolicy("Productions", policy => policy.RequireClaim("Department", "ProductionManagement"));
});


var constr = builder.Configuration.GetConnectionString("InventoryManagement");


//Configure EF Core for Identity
builder.Services.AddDbContext<AccountDbContext>(options =>
{
    options.UseSqlServer(constr);
});

//Configure Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
}).AddEntityFrameworkStores<AccountDbContext>();

builder.Services.AddDbContextFactory<StockProContext>(options =>
{
    options.UseSqlServer(constr);
});

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


if (builder.Environment.IsEnvironment("TESTING"))
{
	StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

	builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
	builder.Services.AddSingleton<IProductRepository, ProductRepository>();
	builder.Services.AddSingleton<IInventoryTransactionRepository, InventoryTransactionRepository>();
	builder.Services.AddSingleton<IProductTransactionRepository, ProductTransactionRepository>();
}


else
{
    builder.Services.AddTransient<IInventoryRepository, InventoryEFCoreRepository>();
    builder.Services.AddTransient<IProductRepository, ProductEFCoreRepository>();
    builder.Services.AddTransient<IInventoryTransactionRepository, InventoryTransactionEFCoreRepository>();
    builder.Services.AddTransient<IProductTransactionRepository, ProductTransactionEFCoreRepository>();
}

builder.Services.AddTransient<IViewInventoriesByNameUseCase, ViewInventoriesByNameUseCase>();
builder.Services.AddTransient<IAddInventoryUseCase, AddInventoryUseCase>();
builder.Services.AddTransient<IEditInventoryUseCase, EditInventoryUseCase>();
builder.Services.AddTransient<IViewInventoryByIdUseCase, ViewInventoryByIdUseCase>();

builder.Services.AddTransient<IViewProductsByNameUseCase, ViewProductsByNameUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IViewProductByIdUseCase, ViewProductByIdUseCase>();
builder.Services.AddTransient<IEditProductUseCase,  EditProductUseCase>();

builder.Services.AddTransient<IPurchaseInventoryUseCase, PurchaseInventoryUseCase>();
builder.Services.AddTransient<IProduceProductUseCase, ProduceProductUseCase>();
builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();

builder.Services.AddTransient<ISearchInventoryTransactionsUseCase, SearchInventoryTransactionsUseCase>();
builder.Services.AddTransient<ISearchProductTransactionsUseCase, SearchProductTransactionsUseCase>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
