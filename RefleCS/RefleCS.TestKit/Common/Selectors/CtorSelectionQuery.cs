using AutoFixture.Kernel;

namespace RefleCS.TestKit.Common.Selectors;

public class CtorSelectionQuery : IMethodQuery
{
    private readonly Type _parameterType;

    public CtorSelectionQuery(Type parameterType)
    {
        _parameterType = parameterType;
    }

    public IEnumerable<IMethod> SelectMethods(Type type)
    {
        var ctors = type.GetConstructors();
        var ctor = ctors.Single(ctor => ctor.GetParameters().Any(p => p.ParameterType == _parameterType));

        yield return new ConstructorMethod(ctor);
    }
}