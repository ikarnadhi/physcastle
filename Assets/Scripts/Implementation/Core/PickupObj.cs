using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObj : MonoBehaviour
{
    public float throwForce = 600;
    Vector3 objectPos;
    public float distance = 10;
    public GameObject[] weightmeasurer;

    public bool canHold = false;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;

    // Update is called once per frame
    void Update()
    {
        
        float distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if(distance > 2f)
        {
            isHolding = false;
        }
        if (isHolding)
        {
            canHold = false;
            item.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);
            if (Input.GetKeyUp(KeyCode.E))
            {
                isHolding = false;
            }
            if (Input.GetMouseButtonDown(0))
            {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }
            
        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
        if (Input.GetKeyUp(KeyCode.E) && canHold && !isHolding)
        {
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
        }
    }

    public void togglecanHold(bool able)
    {
        canHold = able;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == 8)
        {
            foreach(GameObject x in weightmeasurer)
            {
                x.GetComponent<WeightMeasure>().MeasureEnter();
            }
        }   
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.layer == 8)
        {
            foreach (GameObject x in weightmeasurer)
            {
                x.GetComponent<WeightMeasure>().MeasureEnter();
            }
        }
    }
}
