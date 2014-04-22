using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Tokiota.Toolkit.XCutting.Helpers
{
    public class ResultList<TEntity>
    {
        #region Constructors and Destructors

        public ResultList(IEnumerable<TEntity> added, IEnumerable<TEntity> deleted, IEnumerable<TEntity> modified, IEnumerable<TEntity> noChanged)
        {
            NoChanged = noChanged;
            Modified = modified;
            Deleted = deleted;
            Added = added;
        }

        #endregion

        #region Public Properties

        public IEnumerable<TEntity> Added { get; private set; }

        public IEnumerable<TEntity> Deleted { get; private set; }

        public IEnumerable<TEntity> Modified { get; private set; }

        public IEnumerable<TEntity> NoChanged { get; private set; }

        #endregion
    }

    public static class Common
    {
        //TODo: crear test unitario

        #region Public Methods and Operators

        public static bool AssignElement<T>(ICollection<T> bdList, T item) where T : class
        {
            Contract.Requires<ArgumentNullException>(bdList != null);

            //Ensure.Argument.NotNull(bdList,"bdList");

            if(bdList == null)
                throw new ArgumentNullException("bdList");
            bool rtv = false;
            // if (!bdList.Any()) return rtv;

            bool contiene = bdList.Contains(item);
            if(!contiene)
            {
                bdList.Add(item);
                rtv = true;
            }

            return rtv;
        }

        public static bool CanCreateNew<T>(T item, bool existItemWithSameName) where T : class
        {
            return item == null && !existItemWithSameName;
        }

        public static ResultList<T> GetInsertUpdateDeleteLists<T>(IEnumerable<T> uiList, IEnumerable<T> bdList) where T : class
        {
            var createList = new List<T>();
            var deleteList = new List<T>();
            var updateList = new List<T>();
            var noChangeList = new List<T>();
            if(bdList != null)
                deleteList.AddRange(bdList);

            if(uiList != null)
            {
                foreach (T uiEntity in uiList)
                {
                    int posicion = deleteList.IndexOf(uiEntity);
                    if(posicion < 0)
                        createList.Add(uiEntity);
                    else
                    {
                        T item = deleteList [posicion];
                        if(item.Equals(uiEntity))
                            noChangeList.Add(uiEntity);
                        else
                            updateList.Add(uiEntity);
                        deleteList.RemoveAt(posicion);
                    }
                }
            }

            return new ResultList<T>(createList, deleteList, updateList, noChangeList);
        }

        public static bool UnassignElement<T>(ICollection<T> bdList, T item) where T : class
        {
            Contract.Requires<ArgumentNullException>(bdList != null);

            bool rtv = false;
            if(bdList.Any())
                rtv = bdList.Remove(item);
            return rtv;
        }

        #endregion
    }
}