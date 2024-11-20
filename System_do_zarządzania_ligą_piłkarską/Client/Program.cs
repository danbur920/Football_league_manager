using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System_do_zarządzania_ligą_piłkarską.Client;
using System_do_zarządzania_ligą_piłkarską.Client.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("System_do_zarządzania_ligą_piłkarską.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("System_do_zarządzania_ligą_piłkarską.ServerAPI"));

builder.Services.AddTransient<SearchQueryManager>();
builder.Services.AddTransient<AlertManager>(); // transient aby każdy komponent miał własną instancję 
builder.Services.AddTransient<PaginationManager>();

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
