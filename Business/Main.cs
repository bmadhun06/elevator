using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ElevatorSystem.Business
{
    public class Main
    {

        public List<Elevator> ElevatorInitialization()
        {
            int elevatorCount;
            List<Elevator> elevatorList = new List<Elevator>();

            try
            {
                Console.WriteLine("Enter number of elevators required : ");
                string elevatorCountinput = Console.ReadLine();               

                if (Int32.TryParse(elevatorCountinput, out elevatorCount))
                {
                    Console.WriteLine("Enter elevators and its current position in the format -> <ElevatorName>,<ElevatorPosition> ");
                    string elevatorName = string.Empty;
                    int elevatorPosition;

                    while (elevatorCount > 0)
                    {
                        string line = Console.ReadLine();
                        if (line != string.Empty)
                        {
                            elevatorName = line.Split(',')[0].ToString();
                            elevatorPosition = Convert.ToInt32(line.Split(',')[1]);
                            elevatorList.Add(new Elevator(elevatorName, elevatorPosition));

                        }
                        elevatorCount--;
                    }
                }

                
            }
            catch (Exception e)
            { 
            }

            return elevatorList;
        }

        public User UserInitialization()
        {

            int floor; string floorInput; User user;
        Start:
            Console.WriteLine("Enter the floor number to which elevator has to come: ");

            floorInput = Console.ReadLine();

            if (Int32.TryParse(floorInput, out floor))
                user = new User("- 1", floor);
            else
            {
                Console.WriteLine("That' doesn't make sense...");
                Console.Beep();
                Thread.Sleep(2000);
                Console.Clear();
                goto Start;

            }

            /* We can have a list of multiple users at different floors */
            //User user2 = new User("- 2", 7);
            //User user3 = new User("- 3", 5);
            /* --------------------- */

            user.whereIsUser();
            return user;
        }

        public void SearchForAnElevator(User user, List<Elevator> elevatorList)
        {
            Console.WriteLine("User " + user.getName() + " you are on " + user.getUserPosition() + " floor, type 'x' to call the elevator!");
            String button = Console.ReadLine();
            if (button.Equals("x"))
            {

                Elevator suitableElevator = GetShortestPathElevator(elevatorList, user);

                suitableElevator.addObserver(user); // register the observer  
                suitableElevator.goToUserPosition(user.getUserPosition(), suitableElevator.getElevatorPosition());
                suitableElevator.deleteObserver(user);
                suitableElevator.rideElevator(user.getUserPosition(), suitableElevator.getElevatorPosition());
                suitableElevator.whereElevatorRides();
            }
            else
            {
                Console.WriteLine("You did not call the elevator!");
            }

        }
        private static Elevator GetShortestPathElevator(List<Elevator> elevatorList, User user)
        {
            Dictionary<Elevator, int> elevatorsWithDistance = new Dictionary<Elevator, int>();

            try
            {
                int elevatorDistance;

                foreach (Elevator elevator in elevatorList)
                {
                    elevatorDistance = floorDifference(user.getUserPosition(), elevator.getElevatorPosition());
                    elevatorsWithDistance.Add(elevator, elevatorDistance);

                }

                //Sorting to get shortest path Elevator
                elevatorsWithDistance = elevatorsWithDistance.OrderBy(key => key.Value).ToDictionary(x => x.Key, x => x.Value);
            }
            catch(Exception ex)
            {}

            return elevatorsWithDistance.First().Key;

        }

        private static int floorDifference(int floorA, int floorB)
        { // checking the difference between floors (floor and elevator)
            if (floorA < floorB)
                return (floorB - floorA);
            else
                return (floorA - floorB);
        }
    }
}
