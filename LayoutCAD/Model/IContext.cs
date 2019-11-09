using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutCAD.Model
{
    public interface IContext<ContainedType>
    {
        ContainedType Object { get; }
    }
}
