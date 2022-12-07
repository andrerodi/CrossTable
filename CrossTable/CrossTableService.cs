using System.Data;

namespace CrossTable
{
    public class CrossTableService<THeader, TIndex, TContent> : ICrossTable<THeader, TIndex, TContent>
        where TIndex : notnull, IEquatable<TIndex>
        where THeader : notnull, IEquatable<THeader>
        where TContent : notnull, IEquatable<TContent>
    {
        private Func<THeader, object>? _headerOrderByFunc;
        private Func<TIndex, object>? _indexOrderByFunc;

        private readonly HashSet<ContentContext<THeader, TIndex, TContent>> _contentContext = new();

        public bool AddContent(ContentContext<THeader, TIndex, TContent> contentContext)
        {
            return _contentContext.Add(contentContext);
        }

        public bool AddContent(THeader headerContext, TIndex indexContext, TContent content)
        {
            // Return early if content already exists
            ContentContext<THeader, TIndex, TContent> context = new(headerContext, indexContext, content);

            return AddContent(context);
        }


        public IEnumerable<THeader> GetHeader()
        {
            var enumerable = _contentContext
                .Select(x => x.HeaderContext)
                .Distinct();

            if (_headerOrderByFunc is null)
            {
                return enumerable;
            }

            return enumerable.OrderBy(_headerOrderByFunc);
        }

        public IEnumerable<TIndex> GetIndices()
        {
            var enumerable = _contentContext
                .Select(x => x.IndexContext)
                .Distinct();

            if (_indexOrderByFunc is null)
            {
                return enumerable;
            }

            return enumerable.OrderBy(_indexOrderByFunc);
        }

        public IEnumerable<ContentContext<THeader, TIndex, TContent>> GetRowByIndex(TIndex indexContext)
        {
            return _contentContext.Where(x => x.IndexContext.Equals(indexContext));
        }


        public IEnumerable<ContentContext<THeader, TIndex, TContent>> GetRowByIndex(int index)
        {
            var element = GetIndices().ElementAt(index);

            return GetRowByIndex(element);
        }


        public void SetHeaderOrderFunc(Func<THeader, object> orderHeaderBy)
        {
            _headerOrderByFunc = orderHeaderBy;
        }

        public void ResetHeaderOrderFunc()
        {
            _headerOrderByFunc = null;
        }

        public void SetIndexOrderFunc(Func<TIndex, object> orderIndexBy)
        {
            _indexOrderByFunc = orderIndexBy;
        }

        public void ResetIndexOrderFunc()
        {
            _indexOrderByFunc = null;
        }

        public IEnumerable<IEnumerable<ContentContext<THeader, TIndex, TContent>>> GetRows()
        {
            var indices = GetIndices();

            foreach (var index in indices)
            {
                yield return GetRowByIndex(index);
            }
        }
    }

    /// <summary>
    /// Exception is thrown when constructor for CrossTableBase had invalid context parsed
    /// </summary>
    public class CrossTableInvalidContextException : Exception
    {
        public CrossTableInvalidContextException() : base("Can't create table with invalid context") { }
    }
}
