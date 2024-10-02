using Microsoft.AspNetCore.DataProtection;
using SampleApi.src;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


var itemList = new List<Item>
{
    new Item { Id = "001", Name = "Item-001", Description = "Description for first item" },
    new Item { Id = "002", Name = "Item-002", Description = "Description for second item" },
    new Item { Id = "003", Name = "Item-003", Description = "Description for third item" }
};

IResult GetList()
{
    return Results.Ok(itemList);
}

IResult GetItem(string id)
{
    var item = itemList.FirstOrDefault(item => item.Id == id);
    if (item == null) return Results.NotFound();
    return Results.Ok(item);
}

IResult AddItem(Item item)
{
    itemList.Add(new Item { Id = item.Id, Name = item.Name, Description = item.Description });
    var createdItem = GetItem(item.Id);
    return Results.Created($"/{item.Id}", createdItem);
}

IResult UpdateItem(Item item)
{
    var foundItem = itemList.FirstOrDefault(i => i.Id == item.Id);
    if (foundItem == null) return Results.NotFound();
    foundItem.Name = item.Name;
    foundItem.Description = item.Description;
    return Results.Ok(item);
}

IResult DeleteItem(string id)
{
    var item = itemList.FirstOrDefault(item => item.Id == id);
    if (item == null) return Results.NotFound();
    itemList.Remove(item);
    return Results.NoContent();
}

app.MapGet("/", () => GetList());
app.MapGet("/{id}", (string id) => GetItem(id));
app.MapPost("/", (Item item) => AddItem(item));
app.MapPut("/", (Item item) => UpdateItem(item));
app.MapDelete("/{id}", (string id) => DeleteItem(id));
app.Run();
