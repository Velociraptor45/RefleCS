using AutoFixture.Kernel;
using RefleCS.Enums;

namespace ReflecCS.TestKit.Common.Selectors;

public class ClassComplexCtorQuery : IMethodQuery
{
    public IEnumerable<IMethod> SelectMethods(Type type)
    {
        var expectedType = typeof(IEnumerable<ClassModifier>);

        var ctors = type.GetConstructors();
        var ctor = ctors.Single(ctor => ctor.GetParameters().Any(p => p.ParameterType == expectedType));

        yield return new ConstructorMethod(ctor);
    }
}