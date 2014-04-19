using System;
using System.Collections.Generic;
using System.Linq;

using Castle.Windsor;

namespace Tokiota.Toolkit.XCutting.IoC.WebForm.WindsorAdapter
{
    public class WindsorContainerAdapter : IContainer
    {
        #region Fields

        private readonly IWindsorContainer container;

        #endregion

        #region Constructors and Destructors

        public WindsorContainerAdapter(IWindsorContainer container)
        {
            this.container = container;
        }

        #endregion

        #region Public Methods and Operators

        public object Resolve(Type type)
        {
            return container.Resolve(type);
        }

        public object Resolve(Type type, string name)
        {
            return container.Resolve(name, type);
        }

        public TInterface Resolve<TInterface>() where TInterface : class
        {
            return container.Resolve<TInterface>();
        }

        public TInterface Resolve<TInterface>(string name) where TInterface : class
        {
            return container.Resolve<TInterface>(name);
        }

        public IEnumerable<TInterface> ResolveAll<TInterface>() where TInterface : class
        {
            Array array = container.ResolveAll(typeof(TInterface));
            return from object item in array select item as TInterface;
        }

        #endregion
    }
}