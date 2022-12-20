using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCheck : MonoBehaviour
{
    [SerializeField] GameSequence gameSequence;

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.tag=="LookAt")
        {
            gameSequence.LookCollission();
        }
    }
}
