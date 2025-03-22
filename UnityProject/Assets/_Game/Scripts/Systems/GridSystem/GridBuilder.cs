using System;
using UnityEngine;

namespace _Game.Systems.GridSystem
{
    public class GridBuilder : MonoBehaviour
    {
        [SerializeField] private float cellSize = 1f;
        [SerializeField] private int gridSize = 3;
        [SerializeField] private GameObject backgroundPrefab;

        private void Start()
        {
            BuildGrid();
        }

        private void BuildGrid()
        {
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    var prefab = backgroundPrefab;
                    // SpawnBlock(row, col, prefab);
                    Instantiate(backgroundPrefab, GetWorldPosition(row, col), Quaternion.identity, transform);
                }
            }
        }

        private Vector3 GetWorldPosition(int row, int col)
        {
            float offsetX = (gridSize - 1) * cellSize / 2f;
            float offsetY = (gridSize - 1) * cellSize / 2f;
            return new Vector3(col * cellSize - offsetX, -row * cellSize + offsetY, 0);
        }
    }
}