using HotChocolate.Configuration;
using HotChocolate.Data.Filters;
using HotChocolate.Types;

namespace HotChocolate.Data.Neo4J.Filtering;

public abstract class Neo4JStringOperationHandler
    : Neo4JFilterOperationHandlerBase
{
    public Neo4JStringOperationHandler(InputParser inputParser)
        : base(inputParser)
    {
    }

    protected abstract int Operation { get; }

    public override bool CanHandle(
        ITypeCompletionContext context,
        IFilterInputTypeDefinition typeDefinition,
        IFilterFieldDefinition fieldDefinition)
    {
        return context.Type is StringOperationFilterInputType &&
               fieldDefinition is FilterOperationFieldDefinition operationField &&
               operationField.Id == Operation;
    }
}