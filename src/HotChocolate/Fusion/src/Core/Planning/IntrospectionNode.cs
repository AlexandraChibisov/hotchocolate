using System.Collections.Immutable;
using HotChocolate.Execution.Processing;
using HotChocolate.Fusion.Execution;

namespace HotChocolate.Fusion.Planning;

internal sealed class IntrospectionNode : QueryPlanNode
{
    private readonly ISelectionSet _selectionSet;

    public IntrospectionNode(int id, ISelectionSet selectionSet) : base(id)
    {
        _selectionSet = selectionSet ?? throw new ArgumentNullException(nameof(selectionSet));
    }

    public override QueryPlanNodeKind Kind => QueryPlanNodeKind.Introspection;

    protected override async Task OnExecuteAsync(
        IFederationContext context,
        IExecutionState state,
        CancellationToken cancellationToken)
    {
        if (state.TryGetState(_selectionSet, out var values))
        {
            var operationContext = context.OperationContext;
            var rootSelections = _selectionSet.Selections;
            var value = values.Single();

            for (var i = 0; i < rootSelections.Count; i++)
            {
                var selection = rootSelections[i];

                if (selection.Field.IsIntrospectionField)
                {
                    var resolverTask = operationContext.CreateResolverTask(
                        selection,
                        operationContext.RootValue,
                        value.Result,
                        i,
                        operationContext.PathFactory.Append(Path.Root, selection.ResponseName),
                        ImmutableDictionary<string, object?>.Empty);
                    resolverTask.BeginExecute(cancellationToken);

                    await resolverTask.WaitForCompletionAsync(cancellationToken);
                }
            }
        }
    }
}
