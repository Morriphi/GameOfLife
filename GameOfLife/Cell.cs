using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Cell
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public IEnumerable<Cell> NeighbourCells(int width, int height)
        {
            var cells = new[]
                            {
                                new Cell(X - 1, Y - 1),
                                new Cell(X - 1, Y),
                                new Cell(X - 1, Y + 1),
                                new Cell(X, Y - 1),
                                new Cell(X, Y + 1),
                                new Cell(X + 1, Y - 1),
                                new Cell(X + 1, Y),
                                new Cell(X + 1, Y + 1),
                            };

            return cells.Where(c =>
                               c.X >= 0 && c.X < width &&
                               c.Y >= 0 && c.Y < height);
        }
    }
}
