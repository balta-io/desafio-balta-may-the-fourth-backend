using System.Diagnostics.CodeAnalysis;

namespace LotoBackend.Infrastructure.Mongo.Utils
{
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CollectionNameAttribute(string name) : Attribute
    {
        public string Name { get; private set; } = name;
    }
}
