using Core;
using UnityEngine;

namespace Implementation.Levels
{
    public class Level3 : MonoBehaviour, IInteractable
    {
        public GameObject wheel;

        private bool _canTurn = false;
        private Rigidbody _wheelRigidbody;

        // Update is called once per frame
        private void Start()
        {
            _wheelRigidbody = wheel.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (_canTurn && Input.GetKeyUp(KeyCode.E))
            {
                _wheelRigidbody.AddTorque(Vector3.forward * -50);
            }
        }

        public void OnReticuleEnter() => _canTurn = true;
        public void OnReticuleExit() => _canTurn = false;
    }
}