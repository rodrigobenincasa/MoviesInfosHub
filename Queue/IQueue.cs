using System;
using System.Collections.Generic;
using System.Text;

namespace QueueMessager
{
    public interface IQueue<Queue>
    {
        IEnumerable<Queue> GetAll();
    }
}
