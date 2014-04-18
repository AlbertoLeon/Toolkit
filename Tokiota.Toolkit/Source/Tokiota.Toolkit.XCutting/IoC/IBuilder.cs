using System;
using System.Reflection;

namespace Tokiota.Toolkit.XCutting.IoC
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBuilder
    {
        #region Public Methods and Operators

        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <returns></returns>
        IBuilder Register<TClass>();

        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <returns></returns>
        IBuilder Register<TInterface, TClass>() where TClass : TInterface;

        /// <summary>
        /// Registers the specified name.
        /// </summary>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IBuilder Register<TClass>(string name) where TClass : class;

        /// <summary>
        /// Registers the specified name.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IBuilder Register<TInterface, TClass>(string name) where TClass : TInterface;

        /// <summary>
        /// Registers as request scoped.
        /// </summary>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <returns></returns>
        IBuilder RegisterAsRequestScoped<TClass>();

        /// <summary>
        /// Registers as request scoped.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <returns></returns>
        IBuilder RegisterAsRequestScoped<TInterface, TClass>() where TClass : TInterface;

        /// <summary>
        /// Registers as request scoped.
        /// </summary>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IBuilder RegisterAsRequestScoped<TClass>(string name) where TClass : class;

        /// <summary>
        /// Registers as request scoped.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IBuilder RegisterAsRequestScoped<TInterface, TClass>(string name) where TClass : TInterface;

        /// <summary>
        /// Registers as single instance.
        /// </summary>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <returns></returns>
        IBuilder RegisterAsSingleInstance<TClass>() where TClass : class;

        /// <summary>
        /// Registers as single instance.
        /// </summary>
        /// <param name="implementation">The implementation.</param>
        /// <param name="interfaces">The interfaces.</param>
        /// <returns></returns>
        IBuilder RegisterAsSingleInstance(Type implementation, Type[] interfaces);

        /// <summary>
        /// Registers as single instance.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <returns></returns>
        IBuilder RegisterAsSingleInstance<TInterface, TClass>() where TClass : TInterface;

        /// <summary>
        /// Registers as single instance.
        /// </summary>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IBuilder RegisterAsSingleInstance<TClass>(string name);

        /// <summary>
        /// Registers as single instance.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IBuilder RegisterAsSingleInstance<TInterface, TClass>(string name) where TClass : TInterface;

        /// <summary>
        /// Registers the assembly.
        /// </summary>
        /// <param name="assemblyNames">The assembly names.</param>
        /// <returns></returns>
        IBuilder RegisterAssembly(params string[] assemblyNames);

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <typeparam name="TClass">The type of the class.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        IBuilder RegisterInstance<TInterface, TClass>(TClass instance) where TClass : class, TInterface;

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        IBuilder RegisterInstance(object instance);

        /// <summary>
        /// Registers the type of the types in assembly filter by interface.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="filterName">Name of the filter.</param>
        /// <returns></returns>
        IBuilder RegisterTypesInAssemblyFilterByInterfaceType(Assembly assembly, Type filterName);

        #endregion
    }
}