using UnityEngine;
using UnityEngine.Serialization;

namespace Implementation.Core
{
    public class MouseLook : MonoBehaviour
    {
        public float mouseSens = 100f;

        [FormerlySerializedAs("PlayerBody")]
        [FormerlySerializedAs("Playerbody")]
        public Transform playerBody;

        public GameObject flashlight;

        [FormerlySerializedAs("flashonlogo")]
        public GameObject flashOnLogo;

        [FormerlySerializedAs("flashofflogo")]
        public GameObject flashOffLogo;

        private float _xRot = 0;
        private bool _isFlashlightOn;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _isFlashlightOn = false;
        }

        private void Update()
        {
            UpdateLook();
            UpdateFlashlight();
        }

        private void UpdateFlashlight()
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                _isFlashlightOn = !_isFlashlightOn;
            }

            if (_isFlashlightOn)
            {
                flashlight.SetActive(true);
                flashOnLogo.SetActive(true);
                flashOffLogo.SetActive(false);
            }
            else
            {
                flashlight.SetActive(false);
                flashOnLogo.SetActive(false);
                flashOffLogo.SetActive(true);
            }
        }

        private void UpdateLook()
        {
            var mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
            playerBody.rotation = Quaternion.Euler(0, playerBody.eulerAngles.y + mouseX, 0);
            // playerBody.Rotate(Vector3.up * mouseX);
            _xRot -= mouseY;
            _xRot = Mathf.Clamp(_xRot, -90f, 90f);
            transform.localRotation = Quaternion.Euler(_xRot, 0, 0);
        }
    }
}