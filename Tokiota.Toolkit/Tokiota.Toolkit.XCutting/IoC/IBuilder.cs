using System;

namespace Tokiota.Toolkit.XCutting.IoC
{
    public interface IBuilder
    {
        #region Public Methods and Operators

        void Register<TClass>();

        void Register<TInterface, TClass>() where TClass : TInterface;

        void Register<TClass>(string name);

        void Register<TInterface, TClass>(string name) where TClass : TInterface;

        void RegisterAsRequestScoped<TClass>();

        void RegisterAsRequestScoped<TInterface, TClass>() where TClass : TInterface;

        void RegisterAsRequestScoped<TClass>(string name);

        void RegisterAsRequestScoped<TInterface, TClass>(string name) where TClass : TInterface;

        void RegisterAsSingleInstance<TClass>();

        void RegisterAsSingleInstance(Type implementation, Type[] interfaces);

        void RegisterAsSingleInstance<TInterface, TClass>() where TClass : TInterface;

        void RegisterAsSingleInstance<TClass>(string name);

        void RegisterAsSingleInstance<TInterface, TClass>(string name) where TClass : TInterface;

        void RegisterAssembly(params string[] assemblyNames);

        void RegisterInstance<TInterface, TClass>(TClass instance) where TClass : class, TInterface;

        void RegisterInstance(object instance);

        #endregion
    }
}