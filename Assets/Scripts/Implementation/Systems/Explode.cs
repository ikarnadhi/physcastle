using UnityEngine;

namespace Implementation.Systems
{
    public class Explode : MonoBehaviour
    {
        private bool _hasExploded;
        public GameObject explodeVFX;

        void Start()
        {
            explodeVFX.SetActive(false);
            _hasExploded = false;
        }

        private void Update()
        {
            if (_hasExploded)
            {
                return;
            } // guard clause

            if (Input.GetKeyUp(KeyCode.G))
            {
                Boom();
                _hasExploded = true;
            }
        }

        private void Boom()
        {
            explodeVFX.SetActive(true);
            Collider[] colliders = new Collider[] { };
            Physics.OverlapSphereNonAlloc(transform.position, 5f, colliders);

            foreach (Collider nearbyObject in colliders)
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(40000f, transform.position, 5f);
                }
            }

            _hasExploded = true;
            Destroy(gameObject);
        }
    }
}