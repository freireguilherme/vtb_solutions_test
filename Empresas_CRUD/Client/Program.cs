global using Empresas_CRUD.Client.Services.EmpresaService;
using Empresas_CRUD.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//Quando eu quero usar um Service Empresa, uso a interface IEmpresaService para isso. Facilita a mudan�a para outros servi�os
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
await builder.Build().RunAsync();
