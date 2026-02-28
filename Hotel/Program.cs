using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Hotel.Data;
using Hotel.Common;
using Hotel.Forms;

namespace Hotel;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    [STAThread]
    static void Main()
    {
        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;
        ApplicationConfiguration.Initialize();
     
        using (var login = new FrmLogin())
        {
            if (login.ShowDialog() == DialogResult.OK)
            {
                var mainForm = host.Services.GetRequiredService<Forms.MainForm>();
                Application.Run(mainForm);
            }
            else
            {
                Application.Exit();
            }
        }
    }

    static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetConnectionString("DefaultConnection");

                services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(connectionString));
                services.AddDbContextFactory<AppDbContext>(options => options.UseSqlServer(connectionString));

                services.RegisterDependencies(); // Extension method to register services and repositories
                // Forms
                services.AddSingleton<Forms.MainForm>();
                services.AddTransient<Forms.frmBooking>();
                services.AddTransient<Forms.frmBookNow>();
                services.AddTransient<Forms.frmGuest>();
                services.AddTransient<Forms.frmPayment>();
                services.AddTransient<FrmDateWiseRoomView>();
                services.AddTransient<frmPaymentCollectionReport>();
                services.AddTransient<FrmRoomBookingEdit>();
                services.AddTransient<FrmRoomBookingMasterEdit>();
                services.AddTransient<FrmChangePassword>();
                services.AddTransient<FrmIDUpload>();
            });
    }
}