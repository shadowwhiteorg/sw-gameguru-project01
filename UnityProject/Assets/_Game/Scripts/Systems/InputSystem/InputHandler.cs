using System;
using _Game.Systems.GridSystem;
using UnityEngine;

namespace _Game.Systems.InputSystem
{
    public class InputHandler : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_camera)
                    GridFactory.Instance.GenerateXObject(_camera.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }
}