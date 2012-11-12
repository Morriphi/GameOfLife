using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class GameOfLife
    {
        private readonly bool[,] cells;

        public GameOfLife(bool[,] cells)
        {
            this.cells = cells;
        }

        public GameOfLife Tick()
        {
            var game = new bool[Width(), Height()];

            var survivors = Survivors().ToList();

            foreach (var survivor in survivors)
                game[survivor.X, survivor.Y] = true;

            return new GameOfLife(game);
        }

        private IEnumerable<Cell> Survivors()
        {
            var points = from x in Enumerable.Range(0, Width())
                         from y in Enumerable.Range(0, Height())
                         select new Cell(x, y);

            return from cell in points
                   let neighbours = CountLiveNeighbours(cell)
                   where neighbours == 3 || (cells[cell.X, cell.Y] && neighbours == 2)
                   select cell;
        }

        private int CountLiveNeighbours(Cell cell)
        {
            return cell.NeighbourCells(Width(), Height()).Count(c => cells[c.X, c.Y]);
        }

        public bool[,] CurrentState()
        {
            return cells.Clone() as bool[,];
        }

        private int Height()
        {
            return cells.GetUpperBound(1) + 1;
        }

        private int Width()
        {
            return cells.GetUpperBound(0) + 1;
        }
    }
}