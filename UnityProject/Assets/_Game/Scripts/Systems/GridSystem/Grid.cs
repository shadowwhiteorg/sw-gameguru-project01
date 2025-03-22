using System.Collections.Generic;
using UnityEngine;

namespace _Game.Systems.GridSystem
{
    public class Grid
    {
        private Dictionary<Vector2Int,int> _gridElements;
        public int GridSize { get; }
        public float CellSize { get; }

        public Grid(int gridSize, float cellSize)
        {
            GridSize = gridSize;
            CellSize = cellSize;
            _gridElements = new Dictionary<Vector2Int,int>();
        }

        public void RegisterCell(bool isEmpty,Vector2Int cellPosition)
        {
            _gridElements[cellPosition] = isEmpty ? 0 : 1;
        }

        private bool IsCellEmpty(int row, int col)
        {
            return _gridElements.TryGetValue(new Vector2Int(col, row), out _);
        }
    }
}