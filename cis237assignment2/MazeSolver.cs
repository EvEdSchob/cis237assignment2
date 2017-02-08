using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    //This class is used for solving a char array maze.
    //You might want to add other methods to help you out.
    //A print maze method would be very useful, and probably neccessary to print the solution.
    //If you are real ambitious, you could make a seperate class to handle that.
    class MazeSolver
    {
        //Class level memeber variable for the mazesolver class
        char[,] maze;
        int xStart;
        int yStart;
        int width;
        int height;

        //Default Constuctor to setup a new maze solver.
        public MazeSolver()
        {}


        //This is the public method that will allow someone to use this class to solve the maze.
        //Feel free to change the return type, or add more parameters if you like, but it can be done
        //exactly as it is here without adding anything other than code in the body.
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {

            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;
            //Assign maze dimentions to class level variable for traversal and printing.
            width = maze.GetLength(0);
            height = maze.GetLength(1);

            //Do work needed to use mazeTraversal recursive call and solve the maze.
            mazeTraversal(maze, xStart, yStart);
        }

        //This should be the recursive method that gets called to solve the maze.
        //Feel free to change the return type if you like, or pass in parameters that you might need.
        //This is only a very small starting point.
        private void mazeTraversal(char[,] maze, int xPos, int yPos)
        {

            ////First Attempt
            ////Solves maze but cannot exit recrusive call. Goes outside the bounds of the array.
            //if ( 0 < xPos && xPos < width && 0 < yPos && yPos < height )
            //{
            //    maze[xPos, yPos] = 'X';
            //    printMaze();
            //    //Right
            //    if (maze[xPos + 1, yPos] == '.')
            //    {
            //        mazeTraversal(maze, xPos + 1, yPos);
            //    }
            //    //Down
            //    if (maze[xPos, yPos + 1] == '.')
            //    {
            //        mazeTraversal(maze, xPos, yPos + 1);
            //    }
            //    //Left
            //    if (maze[xPos - 1, yPos] == '.')
            //    {
            //        mazeTraversal(maze, xPos - 1, yPos);
            //    }
            //    //Up
            //    if (maze[xPos, yPos - 1] == '.')
            //    {
            //        mazeTraversal(maze, xPos, yPos - 1);
            //    }
            //    maze[xPos, yPos] = 'O';
            //    printMaze();
            //}
            //else
            //{
            //    printMaze();
            //}

            //Implement maze traversal recursive call

            //Second attempt
            //Also solves maze but is unable to return
            if (maze[xPos, yPos] == '.')
            {
                maze[xPos, yPos] = 'x';
                printMaze();
                if(0 < xPos && xPos < width && 0 < yPos && yPos < height)
                {
                    //Right
                    mazeTraversal(maze, xPos + 1, yPos);
                    //Down
                    mazeTraversal(maze, xPos, yPos + 1);
                    //Left
                    mazeTraversal(maze, xPos - 1, yPos);
                    //Up
                    mazeTraversal(maze, xPos, yPos - 1);
                    //Back Up
                    maze[xPos, yPos] = 'O';
                }
            }

            //Third Attempt
        }

        private void printMaze()
        {
            //Print the maze
            int x = 0;
            int y;
            for (y = 0; y < height; y++)
            {
                if (x == width)
                    Console.Write(Environment.NewLine);
                for (x = 0; x < width; x++)
                {
                    Console.Write(maze[x, y] + " ");
                }
            }
            Console.WriteLine(Environment.NewLine + Environment.NewLine);
        }
    }
}
