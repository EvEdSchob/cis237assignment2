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
            const int X_START = 1;
            const int Y_START = 1;

            //The first maze that needs to be solved.
            //Note: You may want to make a smaller version to test and debug with.
            //You don't have to, but it might make your life easier.
            char[,] maze1 = 
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


            //Create a new instance of a mazeSolver.
            MazeSolver mazeSolver = new MazeSolver();

            //Tell the instance to solve the first maze with the passed maze, and start coordinates.
            mazeSolver.SolveMaze(maze1, X_START, Y_START);

            //Create the second maze by transposing the first maze
            char[,] maze2 = transposeMaze(maze1);

            //Solve the transposed maze.
            mazeSolver.SolveMaze(maze2, X_START, Y_START);

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
