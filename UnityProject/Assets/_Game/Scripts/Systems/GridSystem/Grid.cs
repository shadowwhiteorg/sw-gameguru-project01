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

        public void RegisterCell(Vector2Int cellPosition,bool isEmpty = true)
        {
            _gridElements[cellPosition] = isEmpty ? 0 : 1;
        }

        public bool IsCellAvailable(Vector2Int cellPosition)
        {
            return !( _gridElements.TryGetValue(cellPosition, out var result) && result != 0 );
        }
    }
}