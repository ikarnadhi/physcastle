using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Level1 : MonoBehaviour
{
    public OpenDoor doorController;
    public Collider targetCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other == targetCollider)
        {
            doorController.Open();
            tipcontroller.jumpingtip();
        }
    }

}
