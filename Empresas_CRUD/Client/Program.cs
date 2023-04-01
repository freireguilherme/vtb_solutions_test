global using Empresas_CRUD.Client.Services.EmpresaService;
global using Empresas_CRUD.Shared;
using Empresas_CRUD.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Quando eu quero usar um Service Empresa, uso a interface IEmpresaService para isso. Facilita a mudança para outros serviços
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
await builder.Build().RunAsync();
