using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Tarefas.Core.Handlers;
using Tarefas.Web;
using Tarefas.Web.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();

builder.Services
    .AddHttpClient(Configuration.HttpClientName, opt =>
    {
        opt.BaseAddress = new Uri(Configuration.BackendUrl); 
        
    });

 builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(Configuration.BackendUrl) });

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITodoHandler, TodoHandler>();

await builder.Build().RunAsync();
