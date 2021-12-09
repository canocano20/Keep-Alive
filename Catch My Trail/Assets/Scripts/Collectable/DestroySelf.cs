using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
    }
}
