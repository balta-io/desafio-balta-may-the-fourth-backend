using System.Diagnostics.CodeAnalysis;

namespace MayTheFourth.Infrastructure.Mongo.Utils
{
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CollectionNameAttribute(string name) : Attribute
    {
        public string Name { get; private set; } = name;
    }
}
