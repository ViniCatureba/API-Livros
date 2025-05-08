using ProjetosLivros.Context;
using ProjetosLivros.Interface;
using ProjetosLivros.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

//Avisa que a aplicacao usa controllers
builder.Services.AddSwaggerGen();


//adiciono o gerador do swagger
builder.Services.AddControllers();


//Dotnet ef migrations add Inicial
//dotnet ef database update
builder.Services.AddDbContext<LivrosContext>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
var app = builder.Build();


//avisa a app que tenho controladores
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.Run();