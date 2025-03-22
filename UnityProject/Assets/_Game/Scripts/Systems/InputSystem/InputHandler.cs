using System;
using _Game.Systems.GridSystem;
using UnityEngine;

namespace _Game.Systems.InputSystem
{
    public class InputHandler : MonoBehaviour
    {
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GridFactory.Instance.GenerateXObject(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }
}