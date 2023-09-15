using UnityEngine;

namespace CameraScripts
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private float _zoomSpeed;
        [SerializeField] private float _minFOV;
        [SerializeField] private float _maxFOV;

        private float _targetFOV;
        private float _originalFOV;

        private void Start()
        {
            _originalFOV = _mainCamera.fieldOfView;
            _targetFOV = _originalFOV;
        }

        private void Update()
        {
            this.CalculateFOV();
            this.SetTargetFOV();
        }

        private void CalculateFOV()
        {
            if (Input.GetKey(KeyCode.Z))
                _targetFOV = Mathf.Clamp(_mainCamera.fieldOfView - _zoomSpeed * Time.deltaTime, _minFOV, _maxFOV);
            else
                _targetFOV = Mathf.Clamp(_mainCamera.fieldOfView + _zoomSpeed * Time.deltaTime, _minFOV, _maxFOV);
        }

        private void SetTargetFOV() => _mainCamera.fieldOfView = Mathf.Lerp(_mainCamera.fieldOfView, _targetFOV, Time.deltaTime * _zoomSpeed);
    }
}