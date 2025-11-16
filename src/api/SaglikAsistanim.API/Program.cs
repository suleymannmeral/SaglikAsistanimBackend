using SaglikAsistanim.API.Extensions;
using SaglikAsistanim.Application.Extensions;
using SaglikAsistanim.Identity;
using SaglikAsistanim.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddPersistenceExt(builder.Configuration).AddIdentityExt().AddApplicationExt().AddUserExt(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
