using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scala.Interfaces2.Core.Interfaces
{
    public interface IMovable
    {
        float AverageSpeed { get; }
        string TransportationInfo { get; }
        TimeSpan Move(float kilometers);

    }
}
