using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CrossTableTester
{
    public sealed class TableContent : IEquatable<TableContent>
    {
        public TableContent(string content, int row, int column)
        {
            Content = content;
            Row = row;
            Column = column;
        }

        public string Content { get; }
        public int Row { get; }
        public int Column { get; }


        public bool Equals(TableContent? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (Content != other.Content) return false;
            if (Row != other.Row) return false;
            if (Column != other.Column) return false;
            return true;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not TableContent tableContent) return false;
            return Equals(tableContent);
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this);
        }
    }
}
