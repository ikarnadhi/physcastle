using Core;
using Implementation.Systems;
using UnityEngine;
using UnityEngine.Serialization;

namespace Implementation.Core
{
    public class PickupObj : MonoBehaviour, IInteractable
    {
        public float throwForce = 600;
        public float maxHoldDistance = 2;

        [FormerlySerializedAs("weightmeasurer")]
        public GameObject[] weightMeasurer;

        public GameObject item;
        public GameObject tempParent;
        public bool canHold;
        public bool isHolding;

        private Vector3 _objectPos;
        private Rigidbody _itemRigidbody;

        private void Start()
        {
            _itemRigidbody = item.GetComponent<Rigidbody>();
        }

        private void Update()
        {
            var distance = Vector3.Distance(item.transform.position, tempParent.transform.position);

            if (distance > maxHoldDistance)
            {
                isHolding = false;
            }

            if (isHolding)
            {
                canHold = false;
                _itemRigidbody.linearVelocity = Vector3.zero;
                _itemRigidbody.angularVelocity = Vector3.zero;
                item.transform.SetParent(tempParent.transform);

                if (Input.GetKeyUp(KeyCode.E))
                {
                    isHolding = false;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    _itemRigidbody.AddForce(tempParent.transform.forward * throwForce);
                    isHolding = false;
                }
            }
            else
            {
                _objectPos = item.transform.position;
                item.transform.SetParent(null);
                _itemRigidbody.useGravity = true;
                item.transform.position = _objectPos;
            }

            if (Input.GetKeyUp(KeyCode.E) && canHold && !isHolding)
            {
                isHolding = true;
                _itemRigidbody.useGravity = false;
                _itemRigidbody.detectCollisions = true;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.gameObject.layer != 8) return; // only check for objects in layer 8

            foreach (var obj in weightMeasurer)
            {
                obj.GetComponent<WeightMeasure>().MeasureEnter();
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.gameObject.layer != 8) return; // only check for objects in layer 8

            foreach (var obj in weightMeasurer)
            {
                obj.GetComponent<WeightMeasure>().MeasureEnter();
            }
        }

        public void OnReticuleEnter() => canHold = true;

        public void OnReticuleExit() => canHold = false;
    }
}