//Evan Schober
//Main program stores and creates the maze.
//Uses transposeMaze to flip maze.
//Calls MazeSolver to solve original maze.
//Calls MazeSolver to solve transposed maze.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// You are free to add anything else you would like to this program,
        /// however the maze solving part needs to occur in the MazeSolver class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Set console buffer height to see all printed mazes.
            Console.BufferHeight = 5000;

            //Starting Coordinates.
            char[,] maze;
            char[,] maze2;

            //Define mazes
            int[] smallStartCoord = {1,1};
            char[,] smallMaze =
            { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
              { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
              { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
              { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
              { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '#' },
              { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
              { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
              { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
              { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
              { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '.' },
              { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
              { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };
            //Smaller maze for testing
            //char[,] maze1 =
            //{ { '#','#','#','#','#','#'},
            //  { '#','.','#','#','.','#'},
            //  { '#','.','.','#','.','#'},
            //  { '#','#','.','.','.','#'},
            //  { '#','#','#','#','.','#'},
            //  { '#','#','#','#','.','#'},};

            //Big maze... just because
            int[] largeStartCoord = {1,35}; 
            char[,] largeMaze =
            {{'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
             {'#','.','#','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','#','.','.','.','.','.','#','.','.','.','.','.','.','.','.','.','#','.','#'},
             {'#','.','#','.','#','#','#','#','#','.','#','.','#','#','#','.','#','#','#','#','#','.','#','#','#','.','#','#','#','.','#','#','#','.','#','.','#'},
             {'#','.','.','.','.','.','.','.','#','.','.','.','#','.','#','.','.','.','.','.','#','.','.','.','.','.','#','.','#','.','#','.','.','.','#','.','#'},
             {'#','#','#','#','#','.','#','.','#','#','#','#','#','.','#','#','#','#','#','.','#','#','#','.','#','.','#','.','#','.','#','#','#','#','#','.','#'},
             {'#','.','.','.','#','.','#','.','.','.','.','.','.','.','#','.','.','.','.','.','#','.','#','.','#','.','#','.','#','.','.','.','.','.','#','.','#'},
             {'#','.','#','.','#','#','#','#','#','#','#','.','#','.','#','.','#','#','#','#','#','.','#','#','#','.','#','.','#','#','#','#','#','.','#','.','#'},
             {'#','.','#','.','.','.','.','.','.','.','#','.','#','.','#','.','.','.','#','.','.','.','.','.','#','.','.','.','.','.','#','.','.','.','#','.','#'},
             {'#','.','#','#','#','#','#','#','#','.','#','#','#','.','#','#','#','.','#','.','#','#','#','.','#','#','#','#','#','.','#','.','#','#','#','.','#'},
             {'#','.','.','.','.','.','#','.','.','.','#','.','#','.','.','.','#','.','#','.','.','.','#','.','.','.','.','.','#','.','#','.','.','.','.','.','#'},
             {'#','.','#','#','#','.','#','#','#','.','#','.','#','#','#','.','#','.','#','#','#','#','#','.','#','.','#','.','#','.','#','#','#','#','#','#','#'},
             {'#','.','.','.','#','.','.','.','#','.','#','.','#','.','.','.','#','.','.','.','#','.','.','.','#','.','#','.','#','.','.','.','#','.','.','.','#'},
             {'#','#','#','#','#','#','#','.','#','.','#','.','#','.','#','#','#','#','#','.','#','.','#','#','#','.','#','.','#','#','#','.','#','#','#','.','#'},
             {'#','.','.','.','.','.','#','.','#','.','.','.','.','.','#','.','.','.','#','.','#','.','.','.','#','.','#','.','.','.','#','.','.','.','.','.','#'},
             {'#','.','#','#','#','.','#','.','#','#','#','#','#','.','#','#','#','.','#','.','#','#','#','.','#','#','#','.','#','#','#','#','#','#','#','.','#'},
             {'#','.','#','.','.','.','#','.','.','.','.','.','#','.','.','.','.','.','#','.','.','.','#','.','#','.','#','.','.','.','.','.','.','.','#','.','#'},
             {'#','.','#','.','#','#','#','#','#','.','#','.','#','#','#','.','#','#','#','#','#','.','#','.','#','.','#','#','#','#','#','#','#','.','#','.','#'},
             {'#','.','#','.','.','.','.','.','#','.','#','.','#','.','#','.','#','.','.','.','.','.','#','.','.','.','.','.','.','.','#','.','#','.','.','.','#'},
             {'#','.','#','#','#','#','#','.','#','.','#','.','#','.','#','#','#','.','#','#','#','#','#','.','#','#','#','#','#','.','#','.','#','#','#','#','#'},
             {'#','.','#','.','.','.','#','.','#','.','#','.','.','.','.','.','#','.','.','.','.','.','#','.','#','.','.','.','#','.','.','.','.','.','.','.','#'},
             {'#','.','#','.','#','#','#','.','#','#','#','.','#','#','#','.','#','#','#','#','#','.','#','#','#','.','#','.','#','#','#','#','#','.','#','.','#'},
             {'#','.','#','.','.','.','.','.','.','.','.','.','#','.','.','.','.','.','#','.','.','.','.','.','.','.','#','.','.','.','.','.','.','.','#','.','#'},
             {'#','.','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'}};

            //Create a new instance of a mazeSolver.
            MazeSolver mazeSolver = new MazeSolver();
            Console.WriteLine("***************************************************************");
            Console.WriteLine("*******                  Maze Solver                   ********");
            Console.WriteLine("***************************************************************" + Environment.NewLine);
            Console.WriteLine("Which maze would you like to solve?");
            Console.WriteLine("1. Small Maze");
            Console.WriteLine("2. Large Maze");
            string input = Console.ReadLine();
            int mazeSelect = Int32.Parse(input);

            switch(mazeSelect)
            {
                case 1:
                    maze = smallMaze;
                    //Create the second maze by transposing the first maze
                    maze2 = transposeMaze(maze);

                    //Tell the instance to solve the first maze with the passed maze, and start coordinates.
                    mazeSolver.SolveMaze(maze, smallStartCoord[0], smallStartCoord[1]);

                    Console.WriteLine("Maze #1 Solved!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.WriteLine(Environment.NewLine + "Transposing maze... Please Wait.");
                    System.Threading.Thread.Sleep(1000);

                    //Solve the transposed maze.
                    mazeSolver.SolveMaze(maze2, smallStartCoord[1], smallStartCoord[1]);

                    Console.WriteLine("Maze #2 Solved!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case 2:
                    maze = largeMaze;
                    //Create the second maze by transposing the first maze
                    maze2 = transposeMaze(maze);

                    //Tell the instance to solve the first maze with the passed maze, and start coordinates.
                    mazeSolver.SolveMaze(maze, largeStartCoord[0], largeStartCoord[1]);

                    Console.WriteLine("Maze #1 Solved!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.WriteLine(Environment.NewLine + "Transposing maze... Please Wait.");
                    System.Threading.Thread.Sleep(1000);

                    //Solve the transposed maze.
                    mazeSolver.SolveMaze(maze2, largeStartCoord[1], largeStartCoord[0]);

                    Console.WriteLine("Maze #2 Solved!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }

        }



        //This method will take in a 2 dimensional char array and return
        //a char array maze that is flipped along the diagonal, or in mathematical
        //terms, transposed.
        //ie. if the array looks like 1, 2, 3
        //                            4, 5, 6
        //                            7, 8, 9
        //The returned result will be:
        //                            1, 4, 7
        //                            2, 5, 8
        //                            3, 6, 9
        static char[,] transposeMaze(char[,] mazeToTranspose)
        {
            int width = mazeToTranspose.GetLength(0);
            int height = mazeToTranspose.GetLength(1);
            char[,] transposedMaze = new char[height, width];

            for(int x = 0 ; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    transposedMaze[y, x] = mazeToTranspose[x, y];
                }
            }

            return transposedMaze;
        }
    }
}
