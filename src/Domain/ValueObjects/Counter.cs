using System.Collections.Generic;

namespace Domain.ValueObjects
{
    public class Counter<T>
    {
        public int TotalCount { get; set; }
        public List<T> CounterList { get; set; }
    }
}
