var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

#region cars endpoints
// cars endpoints

app.MapGet("api/cars", () => { }


).WithName("GetCars");

app.MapGet("api/cars/{id}", (int id) =>{ 

}).WithName("GetCar");

app.MapPost("api/cars", (Car car) => {

    return car;
}).WithName("CreateCar");

app.MapPut("api/cars/{id}", (int id) => {

    return id;
}).WithName("UpdateCar");

app.MapPost("api/cars", (Car car) => {

    return car;
}).WithName("CreateCar");

app.MapDelete("api/cars/{id}", (int id) => {

    return $"car with id {id} has been deleted";
}).WithName("DeleteCar");

#endregion

//motorbike endpoints

// default endpoint weather


app.Run();


// models
internal record Car //does not take parameters // record is new c#9 concept
{
    public int Id { get; set; }
    public string? TeamName { get; set; } // ? to declare as nullable
    public int Speed { get; set; }
    public double MalfunctionChance { get; set; }
    public int DistanceCoveredInMiles { get;  set; }
    public int FinishedRace { get; set; }
    public int RacedForHours { get; set; }
}

internal record Motorbike //does not take parameters // record is new c#9 concept
{
    public int Id { get; set; }
    public string? TeamName { get; set; } // ? to declare as nullable
    public int Speed { get; set; }
    public double MalfunctionChance { get; set; }
    public int DistanceCoveredInMiles { get; set; }
    public int FinishedRace { get; set; }
    public int RacedForHours { get; set; }
}