using GraphQL.Types;
using SampleApi.src.Entities;

namespace SampleApi.src.GraphQL;

public class ItemQuery : ObjectGraphType
{
    public ItemQuery()
    {
        Field<ListGraphType<ItemType>>(
            "items",
            resolve: context => new List<Item>
            {
                new Item { Id = "1", Name = "Item A", Description = "Description of Item A" },
                new Item { Id = "2", Name = "Item B", Description = "Description of Item B" }
            }
        );
    }
}