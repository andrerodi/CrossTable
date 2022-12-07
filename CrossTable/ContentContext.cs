
namespace CrossTable
{
    public sealed class ContentContext<THeader, TIndex, TContent> 
        where TIndex : notnull, IEquatable<TIndex>
        where THeader : notnull, IEquatable<THeader>
        where TContent : notnull, IEquatable<TContent>
    {
        public ContentContext(THeader headerContext, TIndex rowContext, TContent content)
        {
            HeaderContext = headerContext;
            IndexContext = rowContext;
            Content = content;
        }

        public THeader HeaderContext { get; }
        public TIndex IndexContext { get; }
        public TContent Content { get; }

    }
}
