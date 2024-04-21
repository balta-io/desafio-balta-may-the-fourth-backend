using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace MayTheFourth.Application
{
    [ExcludeFromCodeCoverage]
    public class AssemblyReference
    {
        public Assembly GetAssembly()
        {
            return GetType().Assembly;
        }
    }
}
