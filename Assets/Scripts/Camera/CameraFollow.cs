#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBasedRPG
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private Camera _camera;

        private Vector3 _offset;
        private Vector3 _position;

        private void Awake()
        {
            _camera = FindObjectOfType<Camera>();
            _offset = _camera.transform.position;
        }

        private void LateUpdate()
        {
            AdjustCamera();
        }

        private void AdjustCamera()
        {
            _position = target.position;
            _camera.transform.position = new Vector3(RoundToNearestPixel(_position.x), RoundToNearestPixel(_position.y), 0f) + _offset;
        }

        private float RoundToNearestPixel(float position)
        {
            float screenPixelsPerUnit = Screen.height / (_camera.orthographicSize * 2f);
            float value = Mathf.Round(position * screenPixelsPerUnit);

            return value / screenPixelsPerUnit;
        }
    }
}
