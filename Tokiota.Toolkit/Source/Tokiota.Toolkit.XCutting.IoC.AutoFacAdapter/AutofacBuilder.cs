using System;
using System.Collections.Generic;
using System.Reflection;

using Autofac;

using Tokiota.Toolkit.XCutting.Helpers;

namespace Tokiota.Toolkit.XCutting.IoC.AutofacAdapter
{
    /// <summary>
    ///     Builder for desktop application with autofac
    /// </summary>
    public class AutofacBuilder : IBuilder
    {
        #region Fields

        private ContainerBuilder builder;

        #endregion

        #region Constructors and Destructors

        public AutofacBuilder()
        {
            builder = new ContainerBuilder();
        }

        #endregion

        #region Public Methods and Operators

        public IBuilder Register<TClass>() where TClass : class
        {
            builder.RegisterType<TClass>();
            return this;
        }

        public IBuilder Register<TInterface, TClass>() where TClass : TInterface where TInterface : class
        {
            builder.RegisterType<TClass>().As<TInterface>();
            return this;
        }

        public IBuilder Register<TClass>(string name) where TClass : class
        {
            builder.RegisterType<TClass>().Named<TClass>(name);
            return this;
        }

        public IBuilder Register<TInterface, TClass>(string name) where TClass : TInterface where TInterface : class
        {
            builder.RegisterType<TClass>().As<TInterface>().Named<TInterface>(name);
            return this;
        }

        public IBuilder RegisterAsRequestScoped<TClass>() where TClass : class
        {
            builder.RegisterType<TClass>().InstancePerLifetimeScope();
            return this;
        }

        public IBuilder RegisterAsRequestScoped<TInterface, TClass>() where TClass : TInterface where TInterface : class
        {
            builder.RegisterType<TClass>().As<TInterface>().InstancePerLifetimeScope();
            return this;
        }

        /// <summary>
        ///     This is useful for objects specific to a single unit of work that may need to nest additional logical units of
        ///     work.
        ///     Each nested lifetime scope will get a new instance of the registered dependency.
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="name"></param>
        public IBuilder RegisterAsRequestScoped<TClass>(string name) where TClass : class
        {
            builder.RegisterType<TClass>().Named<TClass>(name).InstancePerLifetimeScope();
            return this;
        }

        public IBuilder RegisterAsRequestScoped<TInterface, TClass>(string name) where TClass : TInterface where TInterface : class
        {
            builder.RegisterType<TClass>().As<TInterface>().Named<TInterface>(name).InstancePerLifetimeScope();
            return this;
        }

        public IBuilder RegisterAsSingleInstance<TClass>() where TClass : class
        {
            builder.RegisterType<TClass>().SingleInstance();
            return this;
        }

        public IBuilder RegisterAsSingleInstance(Type implementation, Type[] interfaces)
        {
            builder.RegisterType(implementation).As(interfaces);
            return this;
        }

        public IBuilder RegisterAsSingleInstance<TInterface, TClass>() where TClass : TInterface where TInterface : class
        {
            builder.RegisterType<TClass>().As<TInterface>().SingleInstance();
            return this;
        }

        public IBuilder RegisterAsSingleInstance<TClass>(string name) where TClass : class
        {
            builder.RegisterType<TClass>().Named<TClass>(name).SingleInstance();
            return this;
        }

        public IBuilder RegisterAsSingleInstance<TInterface, TClass>(string name) where TClass : TInterface where TInterface : class
        {
            builder.RegisterType<TClass>().As<TInterface>().Named<TInterface>(name).SingleInstance();
            return this;
        }

        public IBuilder RegisterAssembly(params string[] assemblyNames)
        {
            Ensure.Argument.NotNull(assemblyNames);
            foreach (string assemblyPath in assemblyNames)
            {
                var assemblyName = new AssemblyName(assemblyPath);
                Assembly assembly = Assembly.Load(assemblyName);
                builder.RegisterAssemblyTypes(assembly)
                    .Where(t => typeof(IModuleRegistration).IsAssignableFrom(t))
                    .As<IModuleRegistration>()
                    .PreserveExistingDefaults();
            }
            return this;
        }

        public IBuilder RegisterInstance<TInterface, TClass>(TClass instance) where TClass : class, TInterface where TInterface : class
        {
            builder.RegisterInstance(instance)
                .As<TInterface>()
                .SingleInstance();

            return this;
        }

        public IBuilder RegisterInstance(object instance)
        {
            builder.RegisterInstance(instance);
            return this;
        }

        public IBuilder RegisterTypesInAssemblyFilterByInterfaceType(Assembly assembly, Type filterName)
        {
            builder.RegisterAssemblyTypes(assembly)
                .AsClosedTypesOf(filterName);

            return this;
        }

        #endregion

        #region Methods

        internal AutofacContainer Build()
        {
            Autofac.IContainer container = builder.Build();
            builder = new ContainerBuilder();

            LoadModules(container);
            RegisterAsSingleInstance<IContainer, AutofacContainer>();
            return CreateContainer(container);
        }

        private AutofacContainer CreateContainer(Autofac.IContainer innerContainer)
        {
            builder.Update(innerContainer);
            var container = innerContainer.Resolve<IContainer>();
            return (AutofacContainer)container;
        }

        private void LoadModules(Autofac.IContainer container)
        {
            var modules = container.Resolve<IEnumerable<IModuleRegistration>>();
            foreach (IModuleRegistration module in modules)
                module.Register(this);
        }

        #endregion
    }
}