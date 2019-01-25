using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorSystem
{
    public interface IObserver
    {
        void update(IObserver o);
    }
}
