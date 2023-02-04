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
        float angle = Random.Range(0.0f, 360.0f);
        float x = Mathf.Sin(angle) * initDistance;
        float y = 0;
        float z = Mathf.Cos(angle) * initDistance;

        transform.position = dendrites.position + new Vector3(x, y, z);

        direction = (transform.position - dendrites.position).normalized;
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
}
