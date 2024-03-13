using ExpenseTrackerAppService.Core.Contracts.Models;
using ExpenseTrackerAppService.Core.Contracts.Utils;
using ExpenseTrackerAppService.Core.Models.DataModels;
using ExpenseTrackerAppService.Core.Models.JWTModels;
using ExpenseTrackerAppService.Core.Utils;
using ExpenseTrackerAppService.DataAccess.Contracts.Data;
using ExpenseTrackerAppService.DataAccess.Contracts.DBAccess;
using ExpenseTrackerAppService.DataAccess.Data;
using ExpenseTrackerAppService.DataAccess.DBAccess;
using Microsoft.Extensions.Options;
using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace ExpenseTrackerAppService
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this WebApplicationBuilder builder)
        {
            //appsetting.json section binds
            builder.Services.Configure<ExpenseTrackerMongoDBSettings>(builder.Configuration.GetSection("ExpenseTrackerMongoDBConnection"));
            builder.Services.AddSingleton<IExpenseTrackerMongoDBSettings>(
                sp =>
                {
                    var settings = sp.GetRequiredService<IOptions<ExpenseTrackerMongoDBSettings>>().Value;
                    string? mongoDBconnectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");

                    if (mongoDBconnectionString is null)
                    {
                        throw new ArgumentNullException($"{nameof(mongoDBconnectionString)} is null.");
                    }

                    settings.ConnectionString = mongoDBconnectionString;
                    return settings;
                });

            builder.Services.Configure<JWTOptionsSettings>(builder.Configuration.GetSection("JwtOptions"));
            builder.Services.AddSingleton<IJWTOptionsSettings>(
                sp => {
                    var settings = sp.GetRequiredService<IOptions<JWTOptionsSettings>>().Value;
                    string? privateKey = Environment.GetEnvironmentVariable("PRIVATE_KEY");

                    if (privateKey is null)
                    {
                        throw new ArgumentNullException($"{nameof(privateKey)} is null.");
                    }

                    settings.Privatekey = privateKey;
                    return settings;
                });

            //database client injections
            builder.Services.AddSingleton<IMongoClient>(sp =>
            {
                string connectionString = sp.GetRequiredService<IExpenseTrackerMongoDBSettings>().ConnectionString;
                MongoClientSettings settings = MongoClientSettings.FromConnectionString(connectionString);
                settings.LinqProvider = LinqProvider.V3;
                return new MongoClient(settings);
            });

            //data Access injections
            builder.Services.AddTransient<IMongoDBDataAccess, MongoDBDataAccess>();

            //database request helpers injections
            builder.Services.AddScoped<IAuthAccess, MongoAuthAccess>();
            builder.Services.AddScoped<IExpenseAccess, MongoExpenseAccess>();

            //general handlers
            builder.Services.AddScoped<IJWTProvider, JWTProvider>();
            builder.Services.AddScoped<IBCryptProvider, BCryptProvider>();
        }
    }
}
