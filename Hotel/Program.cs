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
    [STAThread]
    static void Main()
    {
        var host = CreateHostBuilder().Build();
        ApplicationConfiguration.Initialize();

        // Resolve MainForm from DI so dependencies are injected
        //var mainForm = host.Services.GetRequiredService<Forms.MainForm>();
        //Application.Run(mainForm);

        using (var login = new FrmLogin())
        {
            if (login.ShowDialog() == DialogResult.OK)
            {
                // 2. Login successful, now run the main app
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
                // EF Core
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DefaultConnection")));

                // Repositories
                //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                
                services.RegisterDependencies();
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