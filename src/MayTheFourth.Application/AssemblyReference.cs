using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace LotoBackend.Application
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
