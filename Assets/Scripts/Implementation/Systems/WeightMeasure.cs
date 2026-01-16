using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightMeasure : MonoBehaviour
{
    public float mass = 0;
    public GameObject weightcounter;
    public GameObject sphere;
    int stuffcount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MeasureEnter()
    {
        Measure();
        weightcounter.GetComponent<TextMesh>().text = mass + " kg";
    }

    public void MeasureExit()
    {
        Measure();
        if (stuffcount <= 4)
            mass = 0;
        weightcounter.GetComponent<TextMesh>().text = mass + " kg";
    }

    void Measure()
    {
        Collider[] hitColliders = Physics.OverlapBox(sphere.transform.position, new Vector3(0.75f,5,0.75f));
        stuffcount = hitColliders.Length;
        
        int i = 0;
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
        mass = totalmass;
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
