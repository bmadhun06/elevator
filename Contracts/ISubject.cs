using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorSystem
{
    public interface ISubject
    { 
        void addObserver(IObserver o); 
        void deleteObserver(IObserver o); 
    }
}
