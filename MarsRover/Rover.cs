using System;



namespace MarsRover
{
    public class Rover
    {
        public int x; // x coordinates of the rover
        public int y; // y coordinates of the rover
        public string direction; //The direction which the rover is facing
        public int xMax; // Max X Value for Grid
        public int yMax; // Max Y Value for Grid


        /*
            * Extracts the values from location and bounds, into  x,y,direction ; xmax, ymax
            * @param: location, @type: string
            * @param: bounds, @type: string
            
        */
        public Rover(string location,string bounds)
        {
            Int32.TryParse(location.Split(" ")[0], out x);
            Int32.TryParse(location.Split(" ")[1], out y);
            direction = location.Split(" ")[2];

            Int32.TryParse(bounds.Split(" ")[0], out xMax);
            Int32.TryParse(bounds.Split(" ")[1], out yMax);
        }

        /*
            * This function Updates x and y according to give command
            * @param: command, @type: string
            * returns: 
                 *  true, if x and y are updated correctly,
                 *  false, if there is an invalid directio, or path or exception
        */
        public Boolean executeInstruction(string command) // format: LMLMLMLMM || MMRMMRMRRM
        {
            Char[] instructions = command.ToCharArray();

            Console.WriteLine(xMax + " " + yMax);

            if(xMax<0 || yMax < 0)
            {
                Console.WriteLine("Invalid Grid Size!!");
                return false;
            }

            if (direction != "N" && direction != "S" && direction != "E" && direction != "W")
            {
                Console.WriteLine("Invalid Direction Entered!!. Please Enter One of the following N,S,E,W");
                return false;
            }

            if(x > xMax || y > yMax)
            {
                Console.WriteLine("Rover tried to move out of Grid!!");
                return false;
            }

            for (int i = 0; i < instructions.Length; i++)
            {
                switch (instructions[i])
                {
                    case 'L':
                        if (SpinLeft() == -1)
                        {
                            return false;
                        }
                        break;
                    case 'R':
                        if (SpinRight() == -1)
                        {
                            return false;
                        }
                        break;
                    case 'M':
                        if (MoveForward()==-1)
                        {
                            return false;
                        }

                        break;
                    default:
                        Console.WriteLine("Invalid Instruction Sent!!. Valid Instruction Moves are 'L','R','M'. Try Again!");
                        return false;

                }

            }
            return true;

        }


        /*
            * This function Updates Direction to "Perpendicular Right" given the current direction of Rover
            * returns:
                * -1: if direction change is invalid
                * 1: direction change is valid
        */
        public int SpinRight()
        {
            switch (direction)
            {
                case "N":
                    direction = "E";
                    break;
                case "E":
                    direction = "S";
                    break;
                case "S":
                    direction = "W";
                    break;
                case "W":
                    direction = "N";
                    break;

                default:
                    Console.WriteLine("Invalid Direction Sent!!. Valid Direction are 'N','S','E','W'. Try Again!");
                    return -1;

            }
            return 1;
        }



        /*
            * This function Updates Direction to "Perpendicular Left" given the current direction of Rover
            * returns:
                * -1: if direction change is invalid
                * 1: direction change is valid
        */
        public int SpinLeft()
        {
            switch (direction)
            {
                case "N":
                    direction = "W";
                    break;
                case "E":
                    direction = "N";
                    break;
                case "S":
                    direction = "E";
                    break;
                case "W":
                    direction = "S";
                    break;

                default:
                    Console.WriteLine("Invalid Direction Sent!!. Valid Direction are 'N','S','E','W'. Try Again!");
                    return -1;

            }
            return 1;

        }

        /*
            * This function Updates x and y according to the current Direction
            * returns: 
                 *  1, if x and y are updated correctly,
                 * -1, if Rover tried to move out of Grid i.e x and/or y are out of bounds
        */
        public int MoveForward()
        {
            switch (direction)
            {
                case "N":
                    y += 1;
                    if(y>yMax || y < 0)
                    {
                        Console.WriteLine("Rover tried to move out of Grid!!");
                        return -1;
                    }
                    break;
                case "E":
                    x += 1;
                    if (x > xMax || x < 0)
                    {
                        Console.WriteLine("Rover tried to move out of Grid!!");
                        return -1;
                    }
                    break;
                case "S":
                    y -= 1;
                    if (y > yMax || y < 0)
                    {
                        Console.WriteLine("Rover tried to move out of Grid!!");
                        return -1;
                    }
                    break;
                case "W":
                    x -= 1;
                    if(x > xMax || x < 0)
                    {
                        Console.WriteLine("Rover tried to move out of Grid!!");
                        return -1;
                    }
                    break;

                default:
                    throw new ArgumentException();
            }
            return 1;
        }


    }


}