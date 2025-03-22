using System.Collections.Generic;
using UnityEngine;

namespace _Game.Systems.GridSystem
{
    public class Grid
    {
        private Dictionary<Vector2Int,int> _gridElements;
        private Dictionary<Vector2Int, GameObject> _xObjects;

        private List<GameObject> _elements = new List<GameObject>();
        public Dictionary<Vector2Int, int> GridElements => _gridElements;
        public Dictionary<Vector2Int, GameObject> XObjects => _xObjects; 
        public int GridSize { get; }
        public float CellSize { get; }

        public Grid(int gridSize, float cellSize)
        {
            GridSize = gridSize;
            CellSize = cellSize;
            _gridElements = new Dictionary<Vector2Int,int>();
            _xObjects = new Dictionary<Vector2Int, GameObject>();
        }

        public void RegisterCell(Vector2Int cellPosition,bool isEmpty = true, GameObject element = null)
        {
            _gridElements[cellPosition] = isEmpty ? 0 : 1;
            if(element) _elements.Add(element);
            if(!isEmpty) _xObjects[cellPosition] = element;
        }

        public void ResetGrid()
        {
            foreach (var element in _elements)
            {
                element.SetActive(false);
            }
        }

        public bool IsCellAvailable(Vector2Int cellPosition)
        {
            return _gridElements.ContainsKey(cellPosition) && _gridElements[cellPosition]==0;
            // return !( _gridElements.TryGetValue(cellPosition, out var result) && result != 0 );
        }
    }
}