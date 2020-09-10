using System;

/*  
 
 *  ------ MARS ROVER MISSION MANUAL -------

    * Simulated User Inputs
    
    * In one simulation user should enter, in the below exact format or else invalid input will be generated
        * Bounds, Format - X Y
        * Initial Location, Format - x y D  , Note: D is one of the following only < N , S , E , W >
        * Instruction String, Format - combination of "L, M or R" only example: LMLMLMMM, RMLMMRL etc.
        
    * At the end of each simulation an output will be generated which will show the final location for the instruction -> x y D
    
    * You will be asked to answer "yes" to continue the above simulation from starting, if you press anything else then you will be exited 
 
    -------- *

*/


/*

    * Provide Unit Tests in RoverOutputTest.cs for the two Sample Test Cases
    * Checking Valid Inputs and Valid Paths have been handled in Program.cs and Rover.cs
    
*/ 

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine(" --------------------- Welcome to Mars Rover Mission!! --------------  ");

            do
            {
                Console.WriteLine("Input: Enter Bounds *Note add a space after bound -> (X Y) ");

                string bounds = Console.ReadLine();


                Console.WriteLine("\nInput: Enter Initial Location *Note add a space after each Character and allowed directions are (N,S,E or W)-> (x y E)");
                string coordinates = Console.ReadLine().ToUpper();

                if (coordinates.Length != 5)
                {
                    Console.WriteLine("Invalid Coordinates assigned for the Rover!!");
                    break;

                }


                Rover currRover = new Rover(coordinates, bounds);

                Console.WriteLine("\nInput: Please enter Rover's commands | *Note add a space after each Character and allowed format L = left R = right M = move");
                string coms = Console.ReadLine();

                Boolean isValid = currRover.executeInstruction(coms);

                if (!isValid)
                {
                    break;
                }


                Console.WriteLine("\nOutput Final Location:");
                Console.WriteLine(currRover.x + " " + currRover.y + " " + currRover.direction);

                Console.Write("\nEnter 'yes' to continue , if you enter anything else then you will be exited from the Mission ");
                string answer = Console.ReadLine();
                if (!answer.Equals("yes"))
                {
                    break;
                }


            } while (true);

            Console.WriteLine("\n --------------------- END MISSION!! --------------  ");

        }
    }
}
