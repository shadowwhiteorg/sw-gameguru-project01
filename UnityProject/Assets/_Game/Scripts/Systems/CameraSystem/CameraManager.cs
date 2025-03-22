using _Game.Utils;
using UnityEngine;

namespace _Game.Systems.CameraSystem
{
    public class CameraManager : Singleton<CameraManager>
    {
        [SerializeField] private float sizeMultiplier = 3f;

        public void SetCameraSize(int column)
        {
            if(Camera.main == null) return;
            Camera.main.orthographicSize = column * sizeMultiplier;
        }
    }
}