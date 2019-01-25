using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ElevatorSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Elevator> elevatorList; User user;

            Console.WriteLine("Welcome to the elevator system.");

        Input:

            Facade facade = new Facade();

            //Initialize number of elevators 
            elevatorList = facade.InitializeElevators();
            //Initialize users
            user = facade.InitializeUsers();

            //Diplay suitable elevator
            facade.DisplaySuitableElevator(user, elevatorList);          

            Console.ReadLine();
            goto Input;
        }



    }
}



