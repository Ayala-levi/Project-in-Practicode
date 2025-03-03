using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TodoApi;

//  אפליקציית ווב
var builder = WebApplication.CreateBuilder(args);

//הוספת שירותים
builder.Services.AddEndpointsApiExplorer();

// הוספת שירותים ליצירת תיעוד Swagger
builder.Services.AddSwaggerGen(c =>
{
    // הגדרת מסמך Swagger
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "A simple example ASP.NET Core Web API",
    });
});
// http://localhost:5137/swagger

// הוספת שירותים לטיפול ב-CORS
//שהקריאות מהאפליקציה לשרת לא יחסמו
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()// הרשאה לכל מקור (דומיין) - ב
                .AllowAnyMethod()// הרשאה לכל שיטת 
                .AllowAnyHeader();
        });
});


// הוספת שירותים לחיבור למסד הנתונים באמצעות Entity Framework Core
builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseMySql(
        // קבלת מחרוזת החיבור למסד הנתונים מהקונפיגורציה
        builder.Configuration.GetConnectionString("ToDoDB"),
        // הגדרת גרסת שרת ה-MySql
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql")
    )
);

// בניית האפליקציה
var app = builder.Build();

app.UseCors();

app.UseSwagger();

// שימוש בממשק המשתמש של Swagger
app.UseSwaggerUI();

// routes -API מספק להפעלת הפונקציות השונות.
app.MapGet("/", () => "Welcome to the ToDo API! Use /items to manage tasks.");

//שליפת כל הפריטים
app.MapGet("/items", async (ToDoDbContext dbContext) =>
{
    var items = await dbContext.Items.ToListAsync();
    return items;
});

//הוספת פריט חדש
app.MapPost("/items", async (ToDoDbContext dbContext, Item newItem) =>
{
    await dbContext.Items.AddAsync(newItem);// הוספת הפריט החדש למסד הנתונים
    await dbContext.SaveChangesAsync();//שמירת השינויים במסד
    return Results.Created($"/items/{newItem.Id}", newItem);
});

// עדכון פריט
app.MapPut("/items/{id}/{isCompleted}", async (int id, bool isCompleted, ToDoDbContext context) =>
{
    var item = await context.Items.FindAsync(id);// חיפוש הפריט לפי ID
    if (item == null) return Results.NotFound();

    item.IsComplete = isCompleted;

    await context.SaveChangesAsync();

    return Results.Ok(item);
});

app.MapDelete("/items/{id}", async (int id, ToDoDbContext dbContext) =>
{
    var item = await dbContext.Items.FindAsync(id);
    if (item == null) return Results.NotFound();

    dbContext.Items.Remove(item);// מחיקת הפריט ממסד הנתונים
    await dbContext.SaveChangesAsync();// שמירת השינויים במסד הנתונים
    return Results.Ok(item);
});

// הפעלת האפליקציה
app.Run();
