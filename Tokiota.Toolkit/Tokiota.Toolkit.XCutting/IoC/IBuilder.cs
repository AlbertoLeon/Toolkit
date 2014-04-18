using System;
using System.Reflection;

namespace Tokiota.Toolkit.XCutting.IoC
{
    public interface IBuilder
    {
        #region Public Methods and Operators

        IBuilder Register<TClass>();

        IBuilder Register<TInterface, TClass>() where TClass : TInterface;

        IBuilder Register<TClass>(string name);

        IBuilder Register<TInterface, TClass>(string name) where TClass : TInterface;

        IBuilder RegisterAsRequestScoped<TClass>();

        IBuilder RegisterAsRequestScoped<TInterface, TClass>() where TClass : TInterface;

        IBuilder RegisterAsRequestScoped<TClass>(string name);

        IBuilder RegisterAsRequestScoped<TInterface, TClass>(string name) where TClass : TInterface;

        IBuilder RegisterAsSingleInstance<TClass>();

        IBuilder RegisterAsSingleInstance(Type implementation, Type[] interfaces);

        IBuilder RegisterAsSingleInstance<TInterface, TClass>() where TClass : TInterface;

        IBuilder RegisterAsSingleInstance<TClass>(string name);

        IBuilder RegisterAsSingleInstance<TInterface, TClass>(string name) where TClass : TInterface;

        IBuilder RegisterAssembly(params string[] assemblyNames);

        IBuilder RegisterInstance<TInterface, TClass>(TClass instance) where TClass : class, TInterface;

        IBuilder RegisterInstance(object instance);

        IBuilder RegisterTypesInAssemblyFilterByInterfaceType(Assembly assembly, Type filterName);

        #endregion
    }
}