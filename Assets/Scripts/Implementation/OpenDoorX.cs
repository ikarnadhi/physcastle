using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorX : MonoBehaviour
{
    float newX = 0;
    static float newXcoord = 0;
    static float speed = 0;
    static bool dooropening = false;
    static GameObject door;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (door != null)
        {
            if (dooropening)
            {
                newX = door.transform.position.x;
                newX += speed * Time.deltaTime;
                door.transform.position = new Vector3(newX, door.transform.position.y, door.transform.position.z);
            }
            if (door.transform.position.x >= newXcoord)
            {
                dooropening = false;
            }
        }
    }

    public static void Open(GameObject doorObject, float XCoord, float openSpeed)
    {
        door = doorObject;
        newXcoord = XCoord;
        speed = openSpeed;
        dooropening = true;
    }
}
