using System.Collections.Generic;
using System.Linq;
using HotChocolate.Types;

namespace HotChocolate.Stitching.SchemaDefinitions;

public class SchemaDefinitionType : ObjectType<RemoteSchemaDefinition>
{
    protected override void Configure(IObjectTypeDescriptor<RemoteSchemaDefinition> descriptor)
    {
        descriptor
            .Name(Names.SchemaDefinition)
            .BindFieldsExplicitly();

        descriptor
            .Field(t => t.Name)
            .Name(Names.Name)
            .Type<NonNullType<StringType>>();

        descriptor
            .Field(t => t.Document)
            .Name(Names.Document)
            .ResolveWith<Resolvers>(t => t.GetDocument(default!))
            .Type<NonNullType<StringType>>();

        descriptor
            .Field(t => t.ExtensionDocuments)
            .Name(Names.ExtensionDocuments)
            .ResolveWith<Resolvers>(t => t.GetExtensionDocuments(default!))
            .Type<NonNullType<ListType<NonNullType<StringType>>>>();
    }

    private class Resolvers
    {
        public string GetDocument(
            [Parent] RemoteSchemaDefinition schemaDefinition) =>
            schemaDefinition.Document.ToString(false);

        public IEnumerable<string> GetExtensionDocuments(
            [Parent] RemoteSchemaDefinition schemaDefinition) =>
            schemaDefinition.ExtensionDocuments.Select(t => t.ToString(false));
    }

    public static class Names
    {
        public static string SchemaDefinition { get; } = "_SchemaDefinition";

        public static string Name { get; } = "name";

        public static string Document { get; } = "document";

        public static string ExtensionDocuments { get; } = "extensionDocuments";
    }
}
