using UnityEngine;

public class Jumpscare2 : MonoBehaviour
{

    public GameObject jumpscareObject;
    public float jumpscareDuration;

    private bool isJumpscaring = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isJumpscaring)
            {
                isJumpscaring = true;
                jumpscareObject.SetActive(true);

                Invoke("CloseGame", jumpscareDuration);
            }
        }
    }

    private void CloseGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
