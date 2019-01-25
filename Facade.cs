using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ElevatorSystem.Business;

namespace ElevatorSystem
{
    public class Facade
    {
        Main _main;

        public Facade()
        {
            this._main = new Main();
        }


        public List<Elevator> InitializeElevators()
        {
           return _main.ElevatorInitialization();
        
        }

        public User InitializeUsers()
        {
            return _main.UserInitialization();
        }

        public void DisplaySuitableElevator(User user, List<Elevator> elevator)
        {
            _main.SearchForAnElevator(user,elevator);
        
        }
    }
}
