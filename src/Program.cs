using GraphQL;
using GraphQL.Types;
using SampleApi.src.Rest;
using SampleApi.src.GraphQL;
using SampleApi.src.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<ItemType>();
builder.Services.AddSingleton<ItemQuery>();
builder.Services.AddSingleton<ISchema, ItemSchema>();
builder.Services.AddGraphQL(b => b
    .AddAutoSchema<ItemQuery>()
    .AddSystemTextJson());

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// GraphQL
app.UseGraphQL<ISchema>("/graphql");
app.UseGraphQLPlayground("/graphql-playground");

// Rest
app.MapGet("/", () => RestController.GetList());
app.MapGet("/{id}", (string id) => RestController.GetItem(id));
app.MapPost("/", (Item item) => RestController.AddItem(item));
app.MapPut("/", (Item item) => RestController.UpdateItem(item));
app.MapDelete("/{id}", (string id) => RestController.DeleteItem(id));

app.Run();