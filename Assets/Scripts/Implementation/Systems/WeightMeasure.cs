using UnityEngine;
using UnityEngine.Serialization;

namespace Implementation.Systems
{
    public class WeightMeasure : MonoBehaviour
    {
        [FormerlySerializedAs("mass")]
        public int totalMass = 0;
        [FormerlySerializedAs("weightcounter")]
        public GameObject weightCounter;
        public GameObject sphere;

        private int _stuffCount = 0;

        public void MeasureEnter()
        {
            Measure();
            weightCounter.GetComponent<TextMesh>().text = totalMass + " kg";
        }

        void Measure()
        {
            Collider[] hitColliders = Physics.OverlapBox(sphere.transform.position, new Vector3(0.75f, 5, 0.75f));
            _stuffCount = hitColliders.Length;

            var i = 0;
            float totalmass = 0;
            while (i < hitColliders.Length)
            {
                if (hitColliders[i].GetComponent<Rigidbody>() && hitColliders[i].GetComponent<Rigidbody>().useGravity)
                {
                    totalmass += hitColliders[i].GetComponent<Rigidbody>().mass;
                    /*Debug.Log(hitColliders[i].GetComponent<Rigidbody>().mass);*/
                }

                i++;
            }

            totalMass = (int)totalmass;
        }

        /*void OnCollisionEnter(Collision collision)
    {
        mass = collision.rigidbody.mass;
    }
    void OnCollisionExit(Collision collision)
    {
        mass = 0;
    }*/
    }
}