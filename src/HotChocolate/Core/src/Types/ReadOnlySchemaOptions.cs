using System;
using System.Reflection;
using HotChocolate.Execution;
using HotChocolate.Types;

#nullable enable

namespace HotChocolate.Configuration;

/// <summary>
/// Represents read-only schema options.
/// </summary>
public class ReadOnlySchemaOptions : IReadOnlySchemaOptions
{
    /// <summary>
    /// Initializes a new instance of <see cref="ReadOnlySchemaOptions"/>.
    /// </summary>
    /// <param name="options">
    /// The options that shall be wrapped as read-only options.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="options"/> is <c>null</c>.
    /// </exception>
    public ReadOnlySchemaOptions(IReadOnlySchemaOptions options)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        QueryTypeName = options.QueryTypeName ?? "Query";
        MutationTypeName = options.MutationTypeName ?? "Mutation";
        SubscriptionTypeName = options.SubscriptionTypeName ?? "Subscription";
        StrictValidation = options.StrictValidation;
        SortFieldsByName = options.SortFieldsByName;
        UseXmlDocumentation = options.UseXmlDocumentation;
        ResolveXmlDocumentationFileName = options.ResolveXmlDocumentationFileName;
        RemoveUnreachableTypes = options.RemoveUnreachableTypes;
        DefaultBindingBehavior = options.DefaultBindingBehavior;
        DefaultFieldBindingFlags = options.DefaultFieldBindingFlags;
        FieldMiddleware = options.FieldMiddleware;
        PreserveSyntaxNodes = options.PreserveSyntaxNodes;
        EnableDirectiveIntrospection = options.EnableDirectiveIntrospection;
        DefaultDirectiveVisibility = options.DefaultDirectiveVisibility;
        DefaultResolverStrategy = options.DefaultResolverStrategy;
        ValidatePipelineOrder = options.ValidatePipelineOrder;
        StrictRuntimeTypeValidation = options.StrictRuntimeTypeValidation;
        DefaultIsOfTypeCheck = options.DefaultIsOfTypeCheck;
        EnableOneOf = options.EnableOneOf;
        EnsureAllNodesCanBeResolved = options.EnsureAllNodesCanBeResolved;
    }

    /// <summary>
    /// Gets the name of the query type.
    /// </summary>
    public string QueryTypeName { get; }

    /// <summary>
    /// Gets or sets the name of the mutation type.
    /// </summary>
    public string MutationTypeName { get; }

    /// <summary>
    /// Gets or sets the name of the subscription type.
    /// </summary>
    public string SubscriptionTypeName { get; }

    /// <summary>
    /// Defines if the schema allows the query type to be omitted.
    /// </summary>"
    public bool StrictValidation { get; }

    /// <summary>
    /// Defines if the CSharp XML documentation shall be integrated.
    /// </summary>
    public bool UseXmlDocumentation { get; }

    /// <summary>
    /// A delegate which resolves the name of the XML documentation file to be read.
    /// Only used if <seealso cref="UseXmlDocumentation"/> is true.
    /// </summary>
    public Func<Assembly, string>? ResolveXmlDocumentationFileName { get; }

    /// <summary>
    /// Defines if fields shall be sorted by name.
    /// Default: <c>false</c>
    /// </summary>
    public bool SortFieldsByName { get; }

    /// <summary>
    /// Defines if syntax nodes shall be preserved on the type system objects
    /// </summary>
    public bool PreserveSyntaxNodes { get; }

    /// <summary>
    /// Defines if types shall be removed from the schema that are
    /// unreachable from the root types.
    /// </summary>
    public bool RemoveUnreachableTypes { get; }

    /// <summary>
    /// Defines the default binding behavior.
    /// </summary>
    public BindingBehavior DefaultBindingBehavior { get; }

    /// <inheritdoc />
    public FieldBindingFlags DefaultFieldBindingFlags { get; }

    /// <summary>
    /// Defines on which fields a middleware pipeline can be applied on.
    /// </summary>
    public FieldMiddlewareApplication FieldMiddleware { get; }

    /// <summary>
    /// Defines if the experimental directive introspection feature shall be enabled.
    /// </summary>
    public bool EnableDirectiveIntrospection { get; }

    /// <summary>
    /// The default directive visibility when directive introspection is enabled.
    /// </summary>
    public DirectiveVisibility DefaultDirectiveVisibility { get; }

    /// <summary>
    /// Defines that the default resolver execution strategy.
    /// </summary>
    public ExecutionStrategy DefaultResolverStrategy { get; }

    /// <summary>
    /// Defines if the order of important middleware components shall be validated.
    /// </summary>
    public bool ValidatePipelineOrder { get; }

    /// <summary>
    /// Defines if the runtime types of types shall be validated.
    /// </summary>
    public bool StrictRuntimeTypeValidation { get; }

    /// <summary>
    /// Defines a delegate that determines if a runtime
    /// is an instance of an <see cref="ObjectType{T}"/>.
    /// </summary>
    public IsOfTypeFallback? DefaultIsOfTypeCheck { get; }

    /// <inheritdoc />
    public bool EnableOneOf { get; }

    /// <inheritdoc />
    public bool EnsureAllNodesCanBeResolved { get; }
}
