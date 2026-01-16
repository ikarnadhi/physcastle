using Implementation.Systems;
using UnityEngine;

namespace Implementation.Levels
{
    public class Level1 : MonoBehaviour
    {
        public OpenDoor doorController;
        public Collider targetCollider;

        private void OnTriggerEnter(Collider other)
        {
            if (other == targetCollider)
            {
                doorController.Open();
                TipController.jumpingtip();
            }
        }
    }
}