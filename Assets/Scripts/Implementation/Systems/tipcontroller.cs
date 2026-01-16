using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tipcontroller : MonoBehaviour
{
    public GameObject movetip;
    public GameObject usetip;
    public GameObject throwtip;
    public GameObject jumptip;
    public GameObject flashtip;
    static bool jumped = false;
    // Start is called before the first frame update
    void Start()
    {
        throwtip.SetActive(false);
        jumptip.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            movetip.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            usetip.SetActive(false);
            throwtip.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            throwtip.SetActive(false);
        }
        if(jumped)
        {
            jumptip.SetActive(true);
            if (Input.GetButtonDown("Jump"))
            {
                jumptip.SetActive(false);
                jumped = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            flashtip.SetActive(false);
        }
    }

    public static void jumpingtip()
    {
        jumped = true;
    }
}
