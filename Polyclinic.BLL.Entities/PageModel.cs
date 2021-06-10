using System.Collections.Generic;

namespace Polyclinic.BLL.Entities
{
    public class PageModel<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }

        public int Count { get; set; }
    }
}
