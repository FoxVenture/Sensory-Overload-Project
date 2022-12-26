using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookingAt : MonoBehaviour
{
    float maxDistance = 10;
    public bool lookingAt = false;

    void FixedUpdate()
    {

        // Will contain the information of which object the raycast hit
        RaycastHit hit;

        // if raycast hits, it checks if it hit an object with the tag Tablet
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) &&
                    hit.collider.gameObject.CompareTag("Tablet"))

        {
            lookingAt = true;

        }

    }

}
