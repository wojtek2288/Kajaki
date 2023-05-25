using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kajaki;

public class EdgeComparer : EqualityComparer<(int v1, int v2)>
{
    public override bool Equals((int v1, int v2) e1, (int v1, int v2) e2)
    {
        return (e1.v1 == e2.v1 && e1.v2 == e2.v2) || (e1.v1 == e2.v2 && e1.v2 == e2.v1);
    }

    public override int GetHashCode((int v1, int v2) e)
    {
        int hCode = e.v1 ^ e.v2;
        return hCode.GetHashCode();
    }
}
