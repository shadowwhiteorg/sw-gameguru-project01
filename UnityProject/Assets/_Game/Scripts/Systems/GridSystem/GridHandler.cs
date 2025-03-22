using System;
using _Game.Utils;
using JetBrains.Annotations;
using UnityEngine;

namespace _Game.Systems.GridSystem
{
    public class GridHandler : Singleton<GridHandler>
    {
        
        private Grid _currentGrid;
        

        public void SetCurrentGrid(Grid grid) => _currentGrid = grid;

        public void ClosestCell(Vector2 worldPosition)
        {
            _currentGrid.WorldToGridPosition(worldPosition);
            // Debug.log
        }
    }
}