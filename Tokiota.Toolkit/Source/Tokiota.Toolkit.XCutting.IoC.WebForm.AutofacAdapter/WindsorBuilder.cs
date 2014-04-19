using System;
using System.Reflection;

using Castle.MicroKernel.Registration;
using Castle.Windsor;

using Tokiota.Toolkit.XCutting.Helpers;

namespace Tokiota.Toolkit.XCutting.IoC.WebForm.WindsorAdapter
{
    public class WindsorBuilder : IBuilder, IDisposable
    {
        #region Fields

        private IWindsorContainer container;

        #endregion

        #region Constructors and Destructors

        public WindsorBuilder()
        {
            container = new WindsorContainer();
        }

        #endregion

        #region Public Methods and Operators

        public IBuilder Register<TClass>() where TClass : class
        {
            container.Register(Component.For<TClass>().LifestyleTransient());
            return this;
        }

        public IBuilder Register<TInterface, TClass>() where TClass : TInterface where TInterface : class
        {
            container.Register(Component.For<TInterface>().ImplementedBy<TClass>().LifestyleTransient());
            return this;
        }

        public IBuilder Register<TClass>(string name) where TClass : class
        {
            container.Register(Component.For<TClass>().Named(name).LifestyleTransient());
            return this;
        }

        public IBuilder Register<TInterface, TClass>(string name) where TClass : TInterface where TInterface : class
        {
            container.Register(Component.For<TInterface>().ImplementedBy<TClass>().Named(name).LifestyleTransient());
            return this;
        }

        public IBuilder RegisterAsRequestScoped<TClass>() where TClass : class
        {
            container.Register(Component.For<TClass>().LifestylePerWebRequest());
            return this;
        }

        public IBuilder RegisterAsRequestScoped<TInterface, TClass>() where TClass : TInterface where TInterface : class
        {
            container.Register(Component.For<TInterface>().ImplementedBy<TClass>().LifestylePerWebRequest());
            return this;
        }

        public IBuilder RegisterAsRequestScoped<TClass>(string name) where TClass : class
        {
            container.Register(Component.For<TClass>().Named(name).LifestylePerWebRequest());
            return this;
        }

        public IBuilder RegisterAsRequestScoped<TInterface, TClass>(string name) where TClass : TInterface where TInterface : class
        {
            container.Register(Component.For<TInterface>().ImplementedBy<TClass>().Named(name).LifestylePerWebRequest());
            return this;
        }

        public IBuilder RegisterAsSingleInstance<TClass>() where TClass : class
        {
            container.Register(Component.For<TClass>().LifestyleSingleton());
            return this;
        }

        public IBuilder RegisterAsSingleInstance(Type implementation, Type[] interfaces)
        {
            Ensure.Argument.NotNull(interfaces);
            foreach (Type typeInterface in interfaces)
                container.Register(Component.For(typeInterface).ImplementedBy(implementation).LifestyleSingleton());
            return this;
        }

        public IBuilder RegisterAsSingleInstance<TInterface, TClass>() where TClass : TInterface where TInterface : class
        {
            container.Register(Component.For<TInterface>().ImplementedBy<TClass>().LifestyleSingleton());

            return this;
        }

        public IBuilder RegisterAsSingleInstance<TClass>(string name) where TClass : class
        {
            container.Register(Component.For<TClass>().LifestyleSingleton());
            return this;
        }

        public IBuilder RegisterAsSingleInstance<TInterface, TClass>(string name) where TClass : TInterface where TInterface : class
        {
            container.Register(Component.For<TInterface>().ImplementedBy<TClass>().Named(name).LifestyleSingleton());
            return this;
        }

        public IBuilder RegisterAssembly(params string[] assemblyNames)
        {
            Ensure.Argument.NotNull(assemblyNames);

            foreach (string assemblyName in assemblyNames)
            {
                container.Register(
                    Classes.FromAssemblyNamed(assemblyName)
                        .Where(t => !t.IsAbstract || !t.IsInterface)
                        .WithService.DefaultInterfaces()
                        .LifestylePerWebRequest());
            }

            return this;
        }

        public IBuilder RegisterInstance<TInterface, TClass>(TClass instance) where TClass : class, TInterface where TInterface : class
        {
            container.Register(
                Component.For<TInterface>()
                    .ImplementedBy<TClass>()
                    .Instance(instance)
                    .LifestyleTransient());
            return this;
        }

        public IBuilder RegisterInstance(object instance)
        {
            Ensure.Argument.NotNull(instance);

            Type serviceType = instance.GetType();
            container.Register(Component.For(serviceType).Instance(instance));
            return this;
        }

        public IBuilder RegisterTypesInAssemblyFilterByInterfaceType(Assembly assembly, Type filterName)
        {
            container.Register(
                Classes.FromAssembly(assembly)
                    .Where(t => t.IsAssignableFrom(filterName))
                    .WithService.DefaultInterfaces()
                    .LifestylePerWebRequest());

            return this;
        }

        #endregion

        #region Methods

        internal IContainer Build()
        {
            return new WindsorContainerAdapter(container);
        }

        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~WindsorBuilder()
        {
            Dispose(false);
        }
        static readonly object LockObject = new object();

        bool disposed;

        private void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(disposed)
                {
                    lock (LockObject)
                    {
                        if(disposed && container != null)
                        {
                            container.Dispose();
                            
                        }
                        container = null;
                        disposed = true;
                    }
                }
            }
        }
    }
}