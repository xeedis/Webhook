using Webhook.Application;
using Webhook.Core;
using Webhook.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddCore()
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddControllers();

var app = builder.Build();

app.UseInfrastructure();
app.Run();

