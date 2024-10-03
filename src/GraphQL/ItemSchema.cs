using GraphQL.Types;

namespace SampleApi.src.GraphQL;

public class ItemSchema : Schema
{
    public ItemSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<ItemQuery>();
    }
}