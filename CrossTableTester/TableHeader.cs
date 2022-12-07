using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossTableTester
{
    public sealed class TableHeader : IEquatable<TableHeader>
    {
        public TableHeader(string name, uint index)
        {
            Name = name;
            Index = index;
        }


        public string Name { get; }
        public uint Index { get; }


        public bool Equals(TableHeader? other)
        {
            if (other is null)
            {
                return false;
            }


        }
    }
}
