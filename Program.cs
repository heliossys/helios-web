using BlazorStatic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HeliosWeb.Components;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseStaticWebAssets();

builder.Services.AddBlazorStaticService(opt => {
    opt.ShouldGenerateSitemap = true;
    opt.SiteUrl = "https://heliossystems.net";

    // Register pages without markdown files for static generation
    opt.PagesToGenerate.Add(new PageToGenerate("/", "index.html"));
    opt.PagesToGenerate.Add(new PageToGenerate("/services", "services/index.html"));
    opt.PagesToGenerate.Add(new PageToGenerate("/about", "about/index.html"));
    opt.PagesToGenerate.Add(new PageToGenerate("/contact", "contact/index.html"));
    opt.PagesToGenerate.Add(new PageToGenerate("/privacy", "privacy/index.html"));
    opt.PagesToGenerate.Add(new PageToGenerate("/terms", "terms/index.html"));
    opt.PagesToGenerate.Add(new PageToGenerate("/tags", "tags/index.html"));
}
)
.AddBlazorStaticContentService<BlogFrontMatter>();

builder.Services.AddRazorComponents();

var app = builder.Build();

if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.UseBlazorStaticGenerator(shutdownApp: !app.Environment.IsDevelopment());

app.Run();

public static class WebsiteKeys
{
    public const string GitHubRepo = "https://github.com/heliossys";
    public const string Title = "Helios Systems";
    public const string Tagline = "Illuminating Your IT Infrastructure";
    public const string Description = "Expert IT consulting specializing in open source solutions, network security, and cloud infrastructure.";
    public const string BlogPostStorageAddress = $"{GitHubRepo}/tree/main/Content/Blog";
    public const string BlogLead = "Insights and expertise from the Helios Systems team";
    public const string Email = "info@heliossystems.net";
}
