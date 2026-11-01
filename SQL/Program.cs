using SQL.Models;
using SQL.Orm;

var db = new Database("app.db");

var category = new Category
{
    Name = "Электроника",
    Slug = "electronics",
};

category.Validate();          // бросает ValidationException при ошибке

db.CreateTable(category);
Console.WriteLine($"Таблица '{category.TableName}' создана.");

// Проверим валидацию:
try
{
    var bad = new Category { Name = new string('x', 200), Slug = "Bad Slug!" };
    bad.Validate();
}
catch (ValidationException ex)
{
    Console.WriteLine($"[Validation] {ex.Message}");
}