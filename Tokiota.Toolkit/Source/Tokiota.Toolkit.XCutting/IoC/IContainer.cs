using System;
using System.Collections.Generic;

namespace Tokiota.Toolkit.XCutting.IoC
{
    /// <summary>
    /// </summary>
    public interface IContainer
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Resolves the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        ///     Resolves the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        object Resolve(Type type, string name);

        /// <summary>
        ///     Resolves this instance.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <returns></returns>
        TInterface Resolve<TInterface>() where TInterface : class;

        /// <summary>
        ///     Resolves the specified name.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        TInterface Resolve<TInterface>(string name) where TInterface : class;

        /// <summary>
        ///     Resolves all.
        /// </summary>
        /// <typeparam name="TInterface">The type of the interface.</typeparam>
        /// <returns></returns>
        IEnumerable<TInterface> ResolveAll<TInterface>() where TInterface : class;

        #endregion
    }
}