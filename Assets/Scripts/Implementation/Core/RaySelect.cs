using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaySelect : MonoBehaviour
{
    Transform _selection;
    Transform _selectiont;
    // Update is called once per frame
    void Update()
    {
        if (_selection != null)
        {
            _selection.GetComponent<PickupObj>().togglecanHold(false);
        }
        if (_selectiont != null)
        {
            _selectiont.GetComponent<level3>().turnwheel(false);
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 2f))
        {
            Transform selection = hit.transform;

            if (selection != null)
            {
                if (selection.tag == "turnable")
                {
                    selection.GetComponent<level3>().turnwheel(true);
                    _selectiont = selection;
                }
                else
                if (selection.parent != null)
                {
                    if (selection.parent.tag == "turnable")
                    {
                        selection.parent.GetComponent<level3>().turnwheel(true);
                        _selectiont = selection.parent;
                    }
                }
                if (selection.tag == "selectable")
                {
                    selection.GetComponent<PickupObj>().togglecanHold(true);
                    _selection = selection;
                }
                else
                if (selection.parent != null)
                {
                    if (selection.parent.tag == "selectable")
                    {
                        selection.parent.GetComponent<PickupObj>().togglecanHold(true);
                        _selection = selection.parent;
                    }
                }
            }
        }
    }
}