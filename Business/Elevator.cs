using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;

namespace ElevatorSystem
{
    public class Elevator : ISubject
    { // object observed
        private List<IObserver> observers = new List<IObserver>();
        private String name;
        private int currentFloor;
        private int elevatorWay;

        public Elevator(String name, int currentFloor)
        {
            this.name = name;
            this.currentFloor = currentFloor;
        }

        public String getName()
        {
            return name;
        }
        public void addObserver(IObserver o)
        { // Adding a user
            observers.Add(o);
            Console.WriteLine("-------------------------");
            Console.WriteLine("Go to Elevator - >  " + name + " !!!");
            Console.WriteLine("-------------------------");
        }

        public void deleteObserver(IObserver o)
        { // Removing user
            observers.Remove(o);
        }

        public int getElevatorPosition()
        {
            return currentFloor;
        } // picking up the lift positions

        public void whereIsElevator()
        { // checking where the elevator is
            Console.WriteLine("Elevator " + name + "is currently on the floor no:" + currentFloor);
        }

        public void rideElevator(int choosenFloor, int elevatorPosition)
        { //Driving the elevator
            int floors = floorDifference(choosenFloor, elevatorPosition);
            try
            {

                // checks the direction of travel
                if (choosenFloor > currentFloor)
                {
                    Console.WriteLine("The elevator is going");
                    Thread.Sleep(floors);
                    elevatorWay = 1;

                }
                else
                {
                    Console.WriteLine("The elevator is going...");
                    Thread.Sleep(floors);
                    elevatorWay = -1;

                }
                currentFloor = choosenFloor;

            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void whereElevatorRides()
        { // where the elevator last rode
            if (elevatorWay == 1)
            {
                Console.WriteLine("The elevator was going up");
            }
            else if (elevatorWay == -1)
            {
                Console.WriteLine("The elevator was going down");
            }
            else
            {
                Console.WriteLine("The elevator is standing");
            }
        }

        private int floorDifference(int floorA, int floorB)
        { // checking the difference between floors (floor and elevator)
            if (floorA < floorB)
                return (floorB - floorA);
            else
                return (floorA - floorB);
        }

        public void goToUserPosition(int myFloor, int elevatorPosition)
        { // Elevator call by the user
            int floors = floorDifference(myFloor, elevatorPosition); // number of floors to determine the time of the lift

            try
            {
                if (floors == 0)
                {
                    Console.WriteLine("The elevator is on your floor, you can enter the elevator!");
                }
                else
                {
                    Thread.Sleep(floors);
                }
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
