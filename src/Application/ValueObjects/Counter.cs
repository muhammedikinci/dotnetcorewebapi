using System.Collections.Generic;

namespace Application.ValueObjects
{
    public class Counter<T>
    {
        public int TotalCount { get; set; }
        public List<T> CounterList { get; set; }
    }
}
