using System;
using System.Linq;
using System.Reflection;

namespace Shared.Infrastructure
{
    public static class AssemblyExtensions
    {
        public static Assembly[] GetSolutionAssemblies()
        {
            var solutionPrefix = new string(Assembly.GetCallingAssembly().GetName().Name
                .TakeWhile(c => c != '.').ToArray());

            return Assembly.GetCallingAssembly().GetReferencedAssemblies()
                .Where(assemblyName => assemblyName.FullName.Contains(solutionPrefix))
                .Select(Assembly.Load)
                .Append(Assembly.GetCallingAssembly())
                .ToArray();
        }
	}
}
