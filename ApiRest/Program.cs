using ApiRest.Data;
using ApiRest.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//AUTOMAPPER
builder.Services.AddAutoMapper(typeof(Program));

//ADGREGAR CONTEXTO DE BASE DE DATOS
var cadena = builder.Configuration.GetConnectionString("MiCadenaConexion");
builder.Services.AddDbContext<AplicationDbContext>(o => o.UseSqlServer(cadena));

//AGREGAR REPOSITORIOS
builder.Services.AddScoped<CitaRepositorio>();

//CONFIGURACION DE SERVICIO DE ATENTICACION JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(option =>
	{
		option.TokenValidationParameters = new TokenValidationParameters()
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,

			ValidIssuer = builder.Configuration["JWT:Issuer"],
			ValidAudience = builder.Configuration["JWT:Audience"],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:ClaveSecreta"])),
			ClockSkew = TimeSpan.Zero
		};
	});



//AGREGAR SERVICIOS AL CONTENEDOR
//builder.Services.AddControllers();
builder.Services.AddControllers(o =>
{
	o.Conventions.Add(new ConvencionVersionPorNamespace());
});


//COFIGURACION PARA SWAGGER (DOCUMENTACION)
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(swagger =>
{
	var versionesApi = new[] { "v1", "v2", "v3" };
	foreach (var version in versionesApi)
	{
		swagger.SwaggerDoc(version, new OpenApiInfo { Title = "Mi Curso Api: S2 PNP MIRANDA LUNA, Juvelio Bladimir", Version = version });
	}

	var esquemaSeguridad = new OpenApiSecurityScheme
	{
		Name = "Authorization",
		Type = SecuritySchemeType.ApiKey,
		Scheme = "Bearer",
		BearerFormat = "JWT",
		In = ParameterLocation.Header,
		Description = "Encabezado de autorizacion JWT ...."
	};

	//AÑADIR DEFINICION DE SEGURIDAD
	swagger.AddSecurityDefinition("Bearer", esquemaSeguridad);

	//AÑADIR REQUISITO DE SEGURIDAD
	swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id ="Bearer"
				}
			}, Array.Empty<string>()
		}

	});

});


var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//SWAGGER
app.UseSwagger();
//app.UseSwaggerUI();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "CursoApi v1");
	c.SwaggerEndpoint("/swagger/v2/swagger.json", "CursoApi v2");
	c.SwaggerEndpoint("/swagger/v3/swagger.json", "CursoApi v3");
});

app.UseCors(builder =>
	   builder.AllowAnyOrigin()
			  .AllowAnyMethod()
			  .AllowAnyHeader());

//CONFIGURAR LA CANALIZACION DES SOLICITUDES HTTP.
app.MapControllers();
app.Run();

public class ConvencionVersionPorNamespace : IControllerModelConvention
{
	public void Apply(ControllerModel controller)
	{
		var controllerNameSpace = controller.ControllerType.Namespace ?? "";
		var defaulVersion = "v1";

		//obtener la version por el primer segmentro con "v"
		var apiVersion = controllerNameSpace.Split('.')
			.FirstOrDefault(segmento => segmento.StartsWith("v", StringComparison.OrdinalIgnoreCase))
			?? defaulVersion;

		controller.ApiExplorer.GroupName = apiVersion.ToLower();
	}
}
