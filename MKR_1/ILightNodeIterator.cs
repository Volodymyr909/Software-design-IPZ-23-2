using Composer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKR1
{
    public interface ILightNodeIterator : IEnumerator<LightNode>
    {
        void Reset();
    }
}
