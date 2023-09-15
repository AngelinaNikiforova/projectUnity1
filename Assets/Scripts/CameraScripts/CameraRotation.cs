using UnityEngine;

namespace CameraScripts
{
    public class CameraRotation : MonoBehaviour
    {
        [Header("Camera Properties")]
        [SerializeField] private Vector2 _sensitivity;
        public float smoothSpeed = 0.125f;
        
        
        [Header("Character Properties")]
        [SerializeField] private Transform _characterTranform;
        
        private float _mouseX;
        private float _mouseY;
        private float _verticalRotation;

        private void Start()
        {
            _verticalRotation = 0f;
            this.SetCursorState();
        }

        private void Update()
        {
            this.GetMouseInputs();
            
            this.VerticalCameraRotation();
            this.CharacterMouseRotation();
        }
        
        private void SetCursorState()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void GetMouseInputs()
        {
            this._mouseX = Input.GetAxis("Mouse X") * _sensitivity.x;
            this._mouseY = Input.GetAxis("Mouse Y") * _sensitivity.y;
        }

        private void VerticalCameraRotation()
        {
            this._verticalRotation += -this._mouseY * smoothSpeed;
            this._verticalRotation = Mathf.Clamp(this._verticalRotation, -80, 80);
            transform.localRotation = Quaternion.Euler(this._verticalRotation, 0, 0); 
        }
        
        private void CharacterMouseRotation()
        {
            float rotationAmount = _mouseX * smoothSpeed * Time.deltaTime;
            _characterTranform.transform.Rotate(Vector3.up, rotationAmount);
        }
    }
}
