using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<PlayerStats>().RespawnPoint();


            // Unfreeze player after respawning
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.constraints = RigidbodyConstraints.FreezeRotation; // Optional: allow rotation freeze
                rb.velocity = Vector3.zero;
            }
        }
    }
}

