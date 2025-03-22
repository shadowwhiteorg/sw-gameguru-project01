using System;
using _Game.Utils;
using JetBrains.Annotations;
using UnityEngine;

namespace _Game.Systems.GridSystem
{
    public class GridHandler : Singleton<GridHandler>
    {
        private Grid _currentGrid;
        public Grid CurrentGrid => _currentGrid;
        public void SetCurrentGrid(Grid grid) => _currentGrid = grid;

        public void BlastX(Vector2Int gridPos)
        {
            if(!CurrentGrid.XObjects.ContainsKey(gridPos)) return;
            CurrentGrid.XObjects[gridPos].SetActive(false);
            CurrentGrid.GridElements[gridPos] = 0;
            _currentGrid.XObjects.Remove(gridPos);
        }
    }
}