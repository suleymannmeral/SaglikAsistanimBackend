using SaglikAsistanim.Ai;
using SaglikAsistanim.API.Extensions;
using SaglikAsistanim.API.SaglikAsistanim.Application.Settings;
using SaglikAsistanim.Application.Extensions;
using SaglikAsistanim.Identity;
using SaglikAsistanim.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddPersistenceExt(builder.Configuration).AddIdentityExt().AddApplicationExt().AddUserExt(builder.Configuration).AddAiExt(builder.Configuration);
builder.Services.AddHttpClient();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();// Bu sat?r? builder.Build() den önce ekle

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
