using BuberBreakfast.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IBreakfastService, BreakfastService>();
}
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

{
    /**
    Adds a middleware to the pipeline that will catch exceptions, log them, reset the request path, and re-execute the request. The request will not be re-executed if the response has already started.
    */
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();

    // app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
