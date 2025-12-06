using System.Collections;
using UnityEngine;

public class SelfDelete : MonoBehaviour
{
    public float deletionTime = 5.0f; // Time in seconds after which the GameObject will be deleted

    private void Start()
    {
        // Start the countdown coroutine
        StartCoroutine(DeleteAfterTime());
    }

    private IEnumerator DeleteAfterTime()
    {
        // Wait for the specified time before deleting the GameObject
        yield return new WaitForSeconds(deletionTime);

        // Delete the GameObject
        Destroy(gameObject);
    }
}
