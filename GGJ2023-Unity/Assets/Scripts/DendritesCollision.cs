using UnityEngine;

public class DendritesCollision : MonoBehaviour
{
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
        bool isPlaying = SwitchPlay.play;

        //if (isPlaying && (collision.CompareTag("Input") || collision.CompareTag("Output")))
        if ((collision.CompareTag("Input") || collision.CompareTag("Output")))
        {
            Debug.Log("Collided with " + collision.gameObject.tag);

            SendMessageUpwards("HandleStopGrowth", transform.parent.name);

            SendMessageUpwards("HandleConnection", collision.gameObject.tag);
        }
}
}
