using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level3 : MonoBehaviour
{
    public GameObject wheel;
    bool canTurn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canTurn && Input.GetKeyUp(KeyCode.E))
        {
            wheel.GetComponent<Rigidbody>().AddTorque(Vector3.forward * -50);
        }
    }

    public void turnwheel(bool willTurn)
    {
        canTurn = willTurn;
    }
}
