using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Utilities
    {
        public static bool[,] Map(string[] rows)
        {
            if (rows.Any(x => x.Length != rows[0].Length))
                throw new ArgumentException("Jagged arrays are not valid.");

            var cells = new bool[rows[0].Length, rows.Length];

            for (var y = 0; y < rows.Length; y++)
                for (var x = 0; x < rows[0].Length; x++)
                    cells[x, y] = rows[y][x] == 'X';

            return cells;
        }

        public static string[] AsStringArray(bool[,] cells)
        {
            var strings = new List<string>();
            var sb = new CustomStringBuilder();
            for (var y = 0; y < cells.GetUpperBound(1) + 1; y++)
            {
                for (var x = 0; x < cells.GetUpperBound(0) + 1; x++)
                    sb.Append(cells[x, y] ? "X" : "0");
                strings.Add(sb.Flush());
            }
            return strings.ToArray();
        }
    }
}
