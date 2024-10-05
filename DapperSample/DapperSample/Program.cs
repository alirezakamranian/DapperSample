using DapperSample.DataAccess;

var builder = WebApplication.CreateBuilder(args);

//                                    services container.

builder.Services.AddControllers();

//DapperContext
builder.Services.AddScoped<IDataContext, DataContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//                                   HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
