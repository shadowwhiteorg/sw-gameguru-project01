using System.Collections.Generic;
using _Game.Systems.GridSystem;
using _Game.Utils;
using UnityEngine;

namespace _Game.Scripts.Systems.BlastSystem
{
    public class GroupDetector : Singleton<GroupDetector>
    {
        [SerializeField] private int minGroupSize = 3;
        public void BlastConnectedSquares(Vector2Int startPos)
        {
            if (!GridHandler.Instance.CurrentGrid.XObjects.ContainsKey(startPos)) return;
            
            HashSet<Vector2Int> squaresToBlast = new();
            FindConnectedX(startPos, squaresToBlast);
            if(squaresToBlast.Count < minGroupSize) return;
            foreach (var square in squaresToBlast)
            {
                GridHandler.Instance.BlastX(square);
            }
        }
        
        private void FindConnectedX(Vector2Int startPos, HashSet<Vector2Int> visited)
        {
            Stack<Vector2Int> stack = new();
            stack.Push(startPos);

            while (stack.Count > 0)
            {
                Vector2Int current = stack.Pop();
                if (!visited.Add(current)) continue; // Skip if already visited
                
                foreach (Vector2Int neighbor in GetXNeighbors(current))
                {
                    if (GridHandler.Instance.CurrentGrid.XObjects.ContainsKey(neighbor) && !visited.Contains(neighbor))
                    {
                        stack.Push(neighbor);
                    }
                }
            }
        }
        
        private List<Vector2Int> GetXNeighbors(Vector2Int squarePos)
        {
            List<Vector2Int> neighbors = new();

            Vector2Int[] directions =
            {
                new(squarePos.x + 1, squarePos.y), // Right
                new(squarePos.x - 1, squarePos.y), // Left
                new(squarePos.x, squarePos.y + 1), // Up
                new(squarePos.x, squarePos.y - 1)  // Down
            };
            foreach (Vector2Int dir in directions)
            {
                if (GridHandler.Instance.CurrentGrid.XObjects.ContainsKey(dir))
                    neighbors.Add(dir);
            }
            return neighbors;
        }
    }
}