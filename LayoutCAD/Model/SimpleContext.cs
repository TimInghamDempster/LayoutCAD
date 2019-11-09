using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutCAD.Model
{
    public class SimpleContext<ContainedType> : IContext<ContainedType>
    {
        public ContainedType Object { get; set; }

        public SimpleContext(ContainedType initialObject)
        {
            Object = initialObject;
        }
    }
}
