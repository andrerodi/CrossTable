using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CrossTableTester
{
    public sealed class TableHeader : IEquatable<TableHeader>
    {
        public TableHeader(string name, int index)
        {
            Name = name;
            Index = index;
        }

        public string Name { get; }
        public int Index { get; }


        public bool Equals(TableHeader? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true; 
            if (this.Name != other.Name) return false;
            if (this.Index != other.Index) return false;

            return true;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not TableHeader tableHeader) return false;
            return Equals(tableHeader);
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this);
        }
    }
}
