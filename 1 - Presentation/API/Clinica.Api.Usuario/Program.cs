using Clinica.Application.Usuario.Extension;

var builder = WebApplication.CreateBuilder(args);

var app = WebApplicationExtension.WebApplicationExtensionBuilder(builder);

app.Run();
