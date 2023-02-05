using UnityEngine;

public class TerminalsCollision : MonoBehaviour
{
    public GameObject parent;
    public GameObject terminalsAnchor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
