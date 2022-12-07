using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CrossTableTester
{
    public sealed class TableIndex : IEquatable<TableIndex>
    {
        public TableIndex(string name, int index)
        {
            Name = name;
            Index = index;
        }

        public string Name { get; }
        public int Index { get; }

        public bool Equals(TableIndex? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (Name != other.Name) return false;
            if (Index != other.Index) return false;

            return true;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not TableIndex tableIndex) return false;
            return Equals(tableIndex);
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this);
        }
    }
}
