using UnityEngine;

public class CameraStop : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            camera1.gameObject.SetActive(false);
            camera2.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            camera1.gameObject.SetActive(true);
            camera2.gameObject.SetActive(false);
        }
    }
}
