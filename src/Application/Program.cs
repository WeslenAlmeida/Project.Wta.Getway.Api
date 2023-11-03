using Application.Configuration;
using Application.Handlers;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Kubernetes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddOcelot(BuilderConfiguration.Builder()).AddDelegatingHandler<ApiKeyHandler>(true).AddKubernetes();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

var configuration = new OcelotPipelineConfiguration
        {
            AuthenticationMiddleware = async (cpt, est) =>
            {
                await est.Invoke();
            }
        };
app.UseOcelot(configuration).Wait();

app.Run();
