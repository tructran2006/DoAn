using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using DoAn.Services;

var builder = WebApplication.CreateBuilder(args);

// --- KHỞI TẠO FIREBASE ---
// Đảm bảo file "key.json" đã được Copy to Output Directory
string credentialPath = Path.Combine(AppContext.BaseDirectory, "key.json");

if (FirebaseApp.DefaultInstance == null)
{
    FirebaseApp.Create(new AppOptions()
    {
        Credential = GoogleCredential.FromFile(credentialPath)
    });
}

// Đăng ký Service vào DI container
builder.Services.AddSingleton<FirebaseService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();