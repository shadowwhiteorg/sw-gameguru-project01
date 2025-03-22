using System;
using _Game.Utils;
using UnityEngine;

namespace _Game.Systems.GridSystem
{
    public class GridFactory : Singleton<GridFactory>
    {
        [SerializeField] private float cellSize = 1f;
        [SerializeField] private int gridSize = 3;
        [SerializeField] private GameObject backgroundPrefab;
        [SerializeField] private GameObject xPrefab;
        
        private Grid _grid;

        private void Start()
        {
            BuildGrid();
        }

        private void BuildGrid()
        {
            _grid = new Grid(gridSize,cellSize);
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    // TODO: Implement object pooling
                    Instantiate(backgroundPrefab, _grid.GridToWorldPosition(new Vector2Int(col,row)), Quaternion.identity, transform);
                    _grid.RegisterCell(new Vector2Int(col, row));
                }
            }
        }
        public void GenerateXObject(Vector3 position)
        {
            if(!_grid.IsCellAvailable(_grid.WorldToGridPosition(position)))
            {
                Debug.Log("Cell is full" + _grid.WorldToGridPosition(position));
                return;
            }
            // TODO: Implement Object Pooling
            Instantiate(xPrefab, (Vector2)_grid.GridToWorldPosition(_grid.WorldToGridPosition(position)), Quaternion.identity);
            _grid.RegisterCell(_grid.WorldToGridPosition(position),false);
        }
    }
}