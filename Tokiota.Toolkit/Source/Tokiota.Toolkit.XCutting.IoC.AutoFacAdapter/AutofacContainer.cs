using System;
using System.Collections.Generic;

using Autofac;

namespace Tokiota.Toolkit.XCutting.IoC.AutofacAdapter
{
    /// <summary>
    ///     Container
    /// </summary>
    public class AutofacContainer : IContainer
    {
        #region Fields

        private readonly IComponentContext context;

        private readonly ILifetimeScope lifetimeScope;

        #endregion

        #region Constructors and Destructors

        public AutofacContainer(IComponentContext context, ILifetimeScope lifetimeScope)
        {
            this.context = context;
            this.lifetimeScope = lifetimeScope;
        }

        #endregion

        #region Properties

        internal IComponentContext Context
        {
            get { return context; }
        }

        #endregion

        //internal ILifetimeScope LifetimeScope
        //{
        //    get { return lifetimeScope; }
        //}

        #region Public Methods and Operators

        public object Resolve(Type type)
        {
            return Context.Resolve(type);
        }

        public object Resolve(Type type, string name)
        {
            return Context.ResolveNamed(name, type);
        }

        public TInterface Resolve<TInterface>() where TInterface : class
        {
            return Context.Resolve<TInterface>();
        }

        public TInterface Resolve<TInterface>(string name) where TInterface : class
        {
            return Context.ResolveNamed<TInterface>(name);
        }

        public IEnumerable<TInterface> ResolveAll<TInterface>() where TInterface : class
        {
            return Context.Resolve<IEnumerable<TInterface>>();
        }

        #endregion
    }
}