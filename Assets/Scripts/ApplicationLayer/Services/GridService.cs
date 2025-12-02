using System;

namespace ApplicationLayer.Services
{
    public class GridService
    {
        public class GridCell
        {
            public int X { get; }
            public int Y { get; }
            public bool IsOccupied { get; set; }

            public GridCell(int x, int y)
            {
                X = x;
                Y = y;
                IsOccupied = false;
            }
        }

        private readonly int _width;
        private readonly int _height;
        private readonly GridCell[,] _cells;

        public GridService(int width = 8, int height = 8)
        {
            _width = width;
            _height = height;
            _cells = new GridCell[_width, _height];

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _cells[x, y] = new GridCell(x, y);
                }
            }
        }
        
        public bool IsCellOccupied(int x, int y) => 
            GetCell(x, y).IsOccupied;

        public GridCell GetCell(int x, int y)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height)
                throw new ArgumentOutOfRangeException($"Invalid cell position ({x},{y})");

            return _cells[x, y];
        }
    }
}