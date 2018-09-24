using Application.Api.Controllers;
using Application.Data;
using Application.Domain;
using System;
using System.Linq;
using System.Reflection;
using Xunit;

namespace Application.FunctionalTests
{
    public class DependenciesTests
    {
        [Theory]
        [InlineData(typeof(ApplicationDbContext), typeof(ValuesController))]
        [InlineData(typeof(IValues), typeof(ApplicationDbContext))]
        [InlineData(typeof(IValues), typeof(ValuesController))]
        [InlineData(typeof(ValuesController), typeof(ApplicationDbContext))]
        public void AssemblyOfTypeShouldNotReferenceAssemblyOfReferencedType(Type type, Type referencedType)
        {
            var references = type.Assembly.GetReferencedAssemblies();

            var referencedTypeAssemblyName = referencedType.Assembly.GetName();
            var assemblyName = type.Assembly.GetName();

            string message = string.Format("{0} should not be referenced by {1}", referencedTypeAssemblyName, assemblyName);
            var contains = references.Any(assembly => AssemblyName.ReferenceMatchesDefinition(referencedTypeAssemblyName, assembly));
            Assert.False(contains, message);
        }
    }
}