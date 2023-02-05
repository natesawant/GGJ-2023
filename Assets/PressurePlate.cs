using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    int activeItems;
    bool activated = false;
    public List<ActivatableInterface> activatableObjects;
    
    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("ENTERED: " + col.gameObject.tag);
        if (col.gameObject.tag == "Pullable" || col.gameObject.tag == "Player") {
            activeItems++;
            if (!activated && activeItems > 0) {
                activated = true;
                foreach (ActivatableInterface obj in activatableObjects) {
                    obj.Activate();
                    Debug.Log(obj.name + " activated");
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        Debug.Log("EXITED: " + col.gameObject.tag);
        if (col.gameObject.tag == "Pullable" || col.gameObject.tag == "Player") {
            activeItems--;
            if (activated && activeItems == 0) {
                activated = false;
                foreach (ActivatableInterface obj in activatableObjects) {
                    obj.Deactivate();
                    Debug.Log(obj.name + " deactivated");
                }
            }
        }
    }
}
