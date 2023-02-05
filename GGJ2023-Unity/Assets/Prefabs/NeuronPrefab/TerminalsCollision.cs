using UnityEngine;

public class TerminalsCollision : MonoBehaviour
{
    public GameObject parent;
    public GameObject terminalsAnchor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlaying = SwitchPlay.play;
        
        if (isPlaying) {
            if (collision.CompareTag("Comida"))
            {
                // Destroy food
                Destroy(collision.gameObject);
                
                Vector2 direction = (collision.transform.position - terminalsAnchor.transform.position).normalized;
                float angle = Vector2.SignedAngle(Vector2.right, direction);
                parent.transform.rotation = Quaternion.Euler(0, 0, angle);

                SendMessageUpwards("HandleTerminalsCollision", collision.gameObject.tag);
            }

            if (collision.CompareTag("Input") || collision.CompareTag("Output"))
            {
                Debug.Log("Collided with " + collision.gameObject.tag);

                SendMessageUpwards("HandleStopGrowth", transform.parent.name);

                SendMessageUpwards("HandleConnection", collision.gameObject.tag);
            }
        }
    }
}
