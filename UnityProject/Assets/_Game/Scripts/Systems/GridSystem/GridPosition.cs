using UnityEngine;

namespace _Game.Systems.GridSystem
{
    public static class GridPosition
    {
        public static Vector2Int WorldToGridPosition(this Grid grid, Vector3 worldPosition)
        {
            float centerY = -(grid.GridSize * grid.CellSize) / 2f;
            float centerX = -(grid.GridSize * grid.CellSize) / 2f;
            int x = Mathf.FloorToInt((worldPosition.x - centerX) / grid.CellSize);
            int y = Mathf.FloorToInt((worldPosition.y - centerY) / grid.CellSize);
            return new Vector2Int(x, y);
        }

        public static Vector2 GridToWorldPosition(this Grid grid, Vector2Int gridPosition)
        {
            float x = gridPosition.x * grid.CellSize;
            float y = gridPosition.y * grid.CellSize;
            float centerY = (grid.GridSize -1) * grid.CellSize/2f ;
            float centerX = (grid.GridSize -1) * grid.CellSize/2f;
            return new Vector2(x - centerX, y- centerY);
        }
    }
}