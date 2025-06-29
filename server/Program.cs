using System;
using
    Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using client.Pages;
using bartr.Components;
using bartr.Components.Account;
using bartr.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using server.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services
    .AddCascadingAuthenticationState();
builder.Services
    .AddScoped<IdentityUserAccessor>();
builder.Services
    .AddScoped<IdentityRedirectManager>();
builder.Services
    .AddScoped<AuthenticationStateProvider,
        PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme
            = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme
            = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString
    = builder.Configuration.GetConnectionString(
          "PostgresConnection") ??
      throw new InvalidOperationException(
          "Connection string not found.");
builder.Services
    .AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(connectionString));
builder.Services
    .AddDatabaseDeveloperPageExceptionFilter();

builder.Services
    .AddIdentityCore<ApplicationUser>(options =>
        options.SignIn.RequireConfirmedAccount
            = true)
    .AddEntityFrameworkStores<
        ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services
    .AddSingleton<IEmailSender<ApplicationUser>,
        IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error"
        , createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();

