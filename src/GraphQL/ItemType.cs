using GraphQL.Types;
using SampleApi.src.Entities;

namespace SampleApi.src.GraphQL;

public class ItemType : ObjectGraphType<Item>
{
    public ItemType()
    {
        Field(x => x.Id).Description("The ID of the item");
        Field(x => x.Name).Description("The name of the item");
        Field(x => x.Description).Description("The description of the item");
    }
}