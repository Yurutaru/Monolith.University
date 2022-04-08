using Autofac;
using Autofac.Extensions.DependencyInjection;
using Monolith.University.API.Extensions;
using Monolith.University.API.Filters.ExceptionFilters;
using Monolith.University.API.Modules;
using Monolith.University.Core.Exceptions;
using Monolith.University.Infrastructure.Persistence.Settings;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule<UpdaterModule>();
    builder.RegisterModule<MappingModule>();
    builder.RegisterModule<HelperModule>();
    builder.RegisterModule<FactoryModule>();
    builder.RegisterModule<ServiceModule>();
    builder.RegisterModule<ValidationModule>();
    builder.RegisterModule<PersistenceModule>();
});

builder.Services.AddControllers(config =>
{
    config.Filters.Add(new BadRequestOnExceptionAttribute(typeof(ValidationException), typeof(ArgumentNullException), typeof(ArgumentOutOfRangeException)));
    config.Filters.Add(new NotFoundOnExceptionAttribute(typeof(ResourceNotFoundException)));
});

builder.Services.AddOptions();
builder.Services.Configure<DatabaseSettings>(configuration.GetSection(nameof(DatabaseSettings)));
builder.Services.AddSwaggerGen();


var app = builder.Build();

//if (env.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}

app.ApplyMigrations();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();