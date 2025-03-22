using System;
using _Game.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.Systems.GridSystem
{
    public class GridFactory : Singleton<GridFactory>
    {
        [SerializeField] private float cellSize = 1f;
        [SerializeField] private int gridSize = 3;
        [SerializeField] private int minGridSize = 3;
        [SerializeField] private GameObject backgroundPrefab;
        [SerializeField] private GameObject xPrefab;
        [SerializeField] private Slider gridSizeSlider; 
        private Grid _grid;

        private void Start()
        {
            BuildGrid();
        }

        private void BuildGrid()
        {
            if(gridSize<minGridSize)
                gridSize = minGridSize;
            _grid?.ResetGrid();
            _grid = new Grid(gridSize,cellSize);
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    // TODO: Implement object pooling
                    var element =Instantiate(backgroundPrefab, _grid.GridToWorldPosition(new Vector2Int(col,row)), Quaternion.identity, transform);
                    _grid.RegisterCell(new Vector2Int(col, row),true,element);
                }
            }
        }
      
        public void GenerateXObject(Vector3 position)
        {
            if(!_grid.IsCellAvailable(_grid.WorldToGridPosition(position))) return;
            
            // TODO: Implement Object Pooling
            var xElement = Instantiate(xPrefab, (Vector2)_grid.GridToWorldPosition(_grid.WorldToGridPosition(position)), Quaternion.identity);
            _grid.RegisterCell(_grid.WorldToGridPosition(position),false, xElement);
        }
        
        private void OnGridSizeChanged(int size)
        {
            gridSize = size;
            BuildGrid();
        }
        
        private void OnEnable()
        {
            gridSizeSlider?.onValueChanged.RemoveAllListeners();
            gridSizeSlider?.onValueChanged.AddListener(value => OnGridSizeChanged((int)value));
        }
    }
}