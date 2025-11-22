using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackZone : MonoBehaviour
{
    public GameObject train;                  // The train GameObject
    public Transform trainStartPoint;         // Where the train starts
    public Transform trainEndPoint;           // Where the train ends
    public float trainSpeed = 20f;            // Units per second

    private bool playerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerInside)
        {
            playerInside = true;

            // Freeze the player's movement (non-invasive)
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }

            StartCoroutine(MoveTrain(other.gameObject));
        }
    }

    private IEnumerator MoveTrain(GameObject player)
    {
        train.transform.position = trainStartPoint.position;
        train.SetActive(true);

        float travelTime = Vector3.Distance(trainStartPoint.position, trainEndPoint.position) / trainSpeed;
        float elapsed = 0f;

        while (elapsed < travelTime)
        {
            train.transform.position = Vector3.Lerp(trainStartPoint.position, trainEndPoint.position, elapsed / travelTime);
            elapsed += Time.deltaTime;
            yield return null;
        }

        train.SetActive(false);
    }
}

