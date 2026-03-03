using Hotel.Common;
using Hotel.Data;
using Hotel.Forms;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hotel;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    [STAThread]
    static void Main()
    {
        Application.ApplicationExit += OnApplicationExit!;

        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;
        ApplicationConfiguration.Initialize();

        using (var login = new FrmLogin())
        {
            if (login.ShowDialog() == DialogResult.OK)
            {
                var mainForm = host.Services.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
            else
            {
                Application.Exit();
            }
        }
    }

    private static void OnApplicationExit(object sender, EventArgs e)
    {
        LogApplicationClose();
    }

    private static void LogApplicationClose()
    {
        try
        {
            using (var context = new AppDbContext())
            {
                var activity = new TblActivity
                {
                    ActivityName = "Application",
                    ActivityDescription = "Application Closed",
                    Operation = "Close",
                    LoginUserID = AppSession.CurrentUser?.ID,       // if you track login
                    LoginUserName = AppSession.CurrentUser?.UserName,   // if you track login
                    ActivityTime = DateTime.UtcNow.GetIndianTime(),
                    TableName = null,
                    TableId = null,
                    Notes = "Application was closed by user"
                };

                context.Activities.Add(activity);
                context.SaveChanges();
            }
        }
        catch
        {
            // Do NOT throw exception during shutdown
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
                services.AddTransient<FrmAboutUs>();
                services.AddTransient<FrmActivity>();
            });
    }
}