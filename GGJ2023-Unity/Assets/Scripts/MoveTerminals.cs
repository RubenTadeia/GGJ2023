using UnityEngine;

public class MoveTerminals : MonoBehaviour
{
    public Transform dendrites;
    public float initDistance = 2.0f;
    public float maxDistance = 2.0f;
    public float moveSpeed = 2.0f;

    private Vector3 direction;

    void Start()
    {
        float angle = 360.0f;//Random.Range(0.0f, 360.0f);

        direction = CalcDirection(angle);
    }

    Vector3 CalcDirection(float angle)
    {
        float x = Mathf.Sin(angle) * initDistance;
        float y = 0;
        float z = Mathf.Cos(angle) * initDistance;

        transform.position = dendrites.position + new Vector3(x, y, z);

        return (transform.position - dendrites.position).normalized;
    }

    void Update()
    {
        bool isPlaying = SwitchPlay.play;

        if (isPlaying)
        {
            float currentDistance = Vector3.Distance(transform.position, dendrites.position);
            if (currentDistance < maxDistance)
            {
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the circular object has collided with another object
        if (collision.CompareTag("Comida"))
        {
            Debug.Log("Collision Comida");
            // Calculate the angle of collision
            //Vector2 collisionNormal = collision.GetContact(0).normal;
            float angle = 50.0f;//Mathf.Atan2(collisionNormal.y, collisionNormal.x) * Mathf.Rad2Deg;

            direction = CalcDirection(angle);
        }
    }

}
