//Evan Schober
//Class accepts the maze and start position then calls mazeTraversal()
//mazeTraversal calls itself to move through the maze.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class MazeSolver
    {
        //Class level memeber variable for the mazesolver class
        char[,] maze;
        int xStart;
        int yStart;
        int width;
        int height;
        bool solved;

        //Default Constuctor to setup a new maze solver.
        public MazeSolver()
        {}


        //Public method that allows outside classes to run the maze solving algorithm.
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

            solved = false;

            //Calls mazeTraversal for the first time with the starting parameters.
            mazeTraversal(maze, xStart, yStart);
        }


        //Maze Traversal 
        private void mazeTraversal(char[,] maze, int xPos, int yPos)
        {
            //Third Attempt
            //Completes maze and exits when solved.
            maze[xPos, yPos] = 'X';
            printMaze();
            if (0 < xPos && xPos < width - 1 && 0 < yPos && yPos < height - 1)
            {
                //Move Right
                if (!solved && maze[xPos + 1, yPos] == '.')
                {
                    mazeTraversal(maze, xPos + 1, yPos);
                }
                //Move Down
                if (!solved && maze[xPos, yPos + 1] == '.')
                {
                    mazeTraversal(maze, xPos, yPos + 1);
                }
                //Move Left
                if (!solved && maze[xPos - 1, yPos] == '.')
                {
                    mazeTraversal(maze, xPos - 1, yPos);
                }
                //Move Up
                if (!solved && maze[xPos, yPos - 1] == '.')
                {
                    mazeTraversal(maze, xPos, yPos - 1);
                }
                //Step Back
                if (!solved)
                {
                    maze[xPos, yPos] = 'O';
                    printMaze();
                }
                    
            }
            else
            {
                solved = true;
            }

            //First Attempt
            //Solves maze but cannot exit recrusive call. Goes outside the bounds of the array.
            //if (0 < xPos && xPos < width - 1 && 0 < yPos && yPos < height - 1)
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

            //Second attempt
            //Also solves maze but does not stop once the wall is reached.
            //if (maze[xPos, yPos] == '.')
            //{
            //    maze[xPos, yPos] = 'x';
            //    printMaze();
            //    if (0 < xPos && xPos < width - 1 && 0 < yPos && yPos < height - 1)
            //    {
            //        //Right
            //        mazeTraversal(maze, xPos + 1, yPos);
            //        //Down
            //        mazeTraversal(maze, xPos, yPos + 1);
            //        //Left
            //        mazeTraversal(maze, xPos - 1, yPos);
            //        //Up
            //        mazeTraversal(maze, xPos, yPos - 1);
            //        //Back Up
            //        maze[xPos, yPos] = 'O';
            //        printMaze();
            //    }
            //}
        }

        private void printMaze()
        {
            //Prints the maze
            Console.Clear();
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
            System.Threading.Thread.Sleep(150);
        }
    }
}
