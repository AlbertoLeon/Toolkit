using System;
using System.Collections.Generic;

namespace Tokiota.Toolkit.XCutting.IoC
{
    public interface IContainer
    {
        #region Public Methods and Operators

        object Resolve(Type type);

        object Resolve(Type type, string name);

        TInterface Resolve<TInterface>();

        TInterface Resolve<TInterface>(string name);

        IEnumerable<TInterface> ResolveAll<TInterface>();

        #endregion
    }
}