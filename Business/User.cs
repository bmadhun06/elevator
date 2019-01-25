using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElevatorSystem
{
    public class User : IObserver
    {
        private String name;
        private int currentFloor;


        public User(String name, int currentFloor)
        {
            this.name = name;
            this.currentFloor = currentFloor;
        }

        public String getName()
        {
            return name;
        }
        public void update(IObserver o)
        {
            //TBI
        }

        public int getUserPosition()
        {
            return currentFloor;
        }

        public void whereIsUser()
        { // checking where the elevator is
            Console.WriteLine("User " + name + " is currently on the floor no: " + currentFloor);
        }

    }
}
