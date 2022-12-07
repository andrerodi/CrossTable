using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossTable
{
    public interface ICrossTable<THeader, TIndex, TContent>
        where TIndex : notnull, IEquatable<TIndex>
        where THeader : notnull, IEquatable<THeader>
        where TContent : notnull, IEquatable<TContent>
    {
        /// <summary>
        /// Gets the table header. Will be ordered if an OrderBy function is provided.
        /// </summary>
        /// <returns>The table header as an <see cref="IEnumerable{THeaderContext}"/></returns>
        IEnumerable<THeader> GetHeader();

        void SetHeaderOrderFunc(Func<THeader, object> orderHeaderBy);
        void ResetHeaderOrderFunc();

        /// <summary>
        /// Gets the table indices. Will be ordered if an OrderBy function is provided.
        /// </summary>
        /// <returns>The table indices as an <see cref="IEnumerable{TIndexContext}"/></returns>
        IEnumerable<TIndex> GetIndices();

        void SetIndexOrderFunc(Func<TIndex, object> orderIndexBy);

        void ResetIndexOrderFunc();

        /// <summary>
        /// Gets the content row for the given index context
        /// </summary>
        /// <param name="indexContext"></param>
        /// <returns>The row contents as an <see cref="IEnumerable{TContent}"/></returns>
        IEnumerable<ContentContext<THeader, TIndex, TContent>> GetRowByIndex(TIndex indexContext);
        
        /// <summary>
        /// Add content by cross context
        /// </summary>
        /// <param name="headerContext"></param>
        /// <param name="indexContext"></param>
        /// <param name="content"></param>
        /// <returns>true if content was added, false content already exists</returns>
        bool AddContent(THeader headerContext, TIndex indexContext, TContent content);

    }
}
