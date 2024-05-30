using Microsoft.EntityFrameworkCore;
using SiteEncantadas.Business.LoginService;
using SiteEncantadas.Data.Connections;
using SiteEncantadas.Data.Contexts;
using SiteEncantadas.Helper.Session;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add DbContext configuration
builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add singleton services
builder.Services.AddSingleton<IConnectionManager, ConnectionManager>();
//builder.Services.AddSingleton<IContextData, ContextDataSqlServer>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// Add scoped services
builder.Services.AddScoped<ISessao, Sessao>();
builder.Services.AddScoped<ILoginService, LoginService>();

// Add session configuration
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession(); // para habilitar as sess�es dentro do projeto

app.MapControllerRoute(
    name: "_Layout",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
