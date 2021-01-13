using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Card")
                {
                    hit.collider.gameObject.GetComponent<CardDisplay>().ToggleName();
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(mouseRay, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Card")
                {
                    hit.collider.gameObject.GetComponent<CardDisplay>().FlipCard();
                }
            }
        }
    }
}
