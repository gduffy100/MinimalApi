using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// add the entity framework core db context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RaceDb>(options =>
options.UseSqlServer(connectionString));

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

app.MapGet("api/cars", (RaceDb db) => {

    var cars = db.Cars.ToList();

    return Results.Ok(cars);
}


).WithName("GetCars");

app.MapGet("api/cars/{id}", (int id, RaceDb db) =>{
    
    var car = db.Cars.FirstOrDefault(x => x.Id == id);

    if (car == null)
    {
        return Results.NotFound($"Car with id:{id} not found");
    }
    return Results.Ok(car);

}).WithName("GetCar");


app.MapPut("api/cars/{id}", (int id, RaceDb db, CarUpdateModel carModel) => {

    var dbCar = db.Cars.FirstOrDefault(x => x.Id == carModel.Id);

    if (dbCar == null)
    {
        return Results.NotFound($"Car with id:{carModel.Id} not found");
    }

    dbCar.TeamName = carModel.TeamName;
    dbCar.Speed = carModel.Speed;
    dbCar.MalfunctionChance = carModel.MalfunctionChance;

    db.SaveChanges();

    return Results.Ok(dbCar);

}).WithName("UpdateCar");

app.MapPost("api/cars", (CarCreateModel carModel, RaceDb db) => {

    var car = new Car
    {
        TeamName = carModel.TeamName,
        Speed = carModel.Speed,
        MalfunctionChance = carModel.MalfunctionChance
    };
    db.Cars.Add(car);
    db.SaveChanges();

    return Results.Ok(car);

 }).WithName("CreateCar");

app.MapDelete("api/cars/{id}", (int id, RaceDb db) => {

    var dbCar = db.Cars.FirstOrDefault(x => x.Id == id);

    if (dbCar == null)
    {
        return Results.NotFound($"Car with id:{id} not found");
    }
    db.Remove(dbCar);
    db.SaveChanges();

    return Results.Ok($"Car with ID: {id} has been deleted");
}).WithName("DeleteCar");

#endregion

#region motorbike endpoints

app.MapGet("api/motorbikes", (RaceDb db) => {

    var motorbikes = db.Motorbikes.ToList();

    return Results.Ok(motorbikes);
}


).WithName("GetMotorbikes");

app.MapGet("api/motorbikes/{id}", (int id, RaceDb db) => {

    var motorbike = db.Motorbikes.FirstOrDefault(x => x.Id == id);

    if (motorbike == null)
    {
        return Results.NotFound($"Car with id:{id} not found");
    }
    return Results.Ok(motorbike);

}).WithName("GetMotorbike");


app.MapPut("api/motorbikes/{id}", (int id, RaceDb db, MotorbikeUpdateModel motorbikeModel) => {

    var dbCar = db.Motorbikes.FirstOrDefault(x => x.Id == motorbikeModel.Id);

    if (dbCar == null)
    {
        return Results.NotFound($"Car with id:{motorbikeModel.Id} not found");
    }

    dbCar.TeamName = motorbikeModel.TeamName;
    dbCar.Speed = motorbikeModel.Speed;
    dbCar.MalfunctionChance = motorbikeModel.MalfunctionChance;

    db.SaveChanges();

    return Results.Ok(dbCar);

}).WithName("UpdateMotorbike");

app.MapPost("api/motorbikes", (MotorbikeCreateModel motorbikeModel, RaceDb db) => {

    var motorbike = new Motorbike
    {
        TeamName = motorbikeModel.TeamName,
        Speed = motorbikeModel.Speed,
        MalfunctionChance = motorbikeModel.MalfunctionChance
    };
    db.Motorbikes.Add(motorbike);
    db.SaveChanges();

    return Results.Ok(motorbike);

}).WithName("CreateMotorbike");

app.MapDelete("api/motorbikes/{id}", (int id, RaceDb db) => {

    var dbMotorbike = db.Motorbikes.FirstOrDefault(x => x.Id == id);

    if (dbMotorbike == null)
    {
        return Results.NotFound($"Motorbike with id:{id} not found");
    }
    db.Remove(dbMotorbike);
    db.SaveChanges();

    return Results.Ok($"Motorbike with ID: {id} has been deleted");
}).WithName("DeleteMotorbike");

#endregion

app.Run();


#region models
public record Car //does not take parameters // record is new c#9 concept
{
    public int Id { get; set; }
    public string? TeamName { get; set; } // ? to declare as nullable
    public int Speed { get; set; }
    public double MalfunctionChance { get; set; }
    public int DistanceCoveredInMiles { get;  set; }
    public int FinishedRace { get; set; }
    public int RacedForHours { get; set; }
}

public record CarUpdateModel //does not take parameters // record is new c#9 concept
{
    public int Id { get; set; }
    public string? TeamName { get; set; } // ? to declare as nullable
    public int Speed { get; set; }
    public double MalfunctionChance { get; set; }
}

public record CarCreateModel //does not take parameters // record is new c#9 concept
{
    public string? TeamName { get; set; } // ? to declare as nullable
    public int Speed { get; set; }
    public double MalfunctionChance { get; set; }
}


public record Motorbike //does not take parameters // record is new c#9 concept
{
    public int Id { get; set; }
    public string? TeamName { get; set; } // ? to declare as nullable
    public int Speed { get; set; }
    public double MalfunctionChance { get; set; }
    public int DistanceCoveredInMiles { get; set; }
    public int FinishedRace { get; set; }
    public int RacedForHours { get; set; }
}

public record MotorbikeUpdateModel //does not take parameters // record is new c#9 concept
{
    public int Id { get; set; }
    public string? TeamName { get; set; } // ? to declare as nullable
    public int Speed { get; set; }
    public double MalfunctionChance { get; set; }
}

public record MotorbikeCreateModel //does not take parameters // record is new c#9 concept
{
    public string? TeamName { get; set; } // ? to declare as nullable
    public int Speed { get; set; }
    public double MalfunctionChance { get; set; }
}


#endregion

#region persistence

public class RaceDb : DbContext // must inherit from this to be used in db connection
{
    //need constructor 
    public RaceDb(DbContextOptions<RaceDb> options) : base(options) // inherit base options
        {
    }
    public DbSet<Car>? Cars { get; set; }
    public DbSet<Motorbike>? Motorbikes { get; set; }

}

#endregion