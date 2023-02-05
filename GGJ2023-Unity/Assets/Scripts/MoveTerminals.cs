using System;
using UnityEngine;

public class MoveTerminals : MonoBehaviour
{
    public Transform dendrites;
    public float initDistance = 2.0f;
    public float maxDistance = 2.0f;
    public float moveSpeed = 2.0f;
    public LineRenderer axonPrefab;
    public Transform axonJointPrefab;

    private Transform currJoint;
    private Vector3 direction;
    private LineRenderer axon;

    void Start()
    {
        currJoint = dendrites;

        CreateAxon(); // Starting @ currJoint

        direction = (transform.position - currJoint.position).normalized;
    }

    void Update()
    {
        bool isPlaying = SwitchPlay.play;

        if (isPlaying)
        {
            float currentDistance = Vector3.Distance(transform.position, currJoint.position);
            if (currentDistance < maxDistance)
            {
                Debug.Log("axon moving");
                transform.position += direction * moveSpeed * Time.deltaTime;
                axon.SetPosition(1, transform.position);
            }
        }
    }

private void CreateAxon()
{
    // Instantiate the Axon prefab
    axon = Instantiate(axonPrefab);

    // Make the LineRenderer a child of the currJoint GameObject
    axon.transform.SetParent(currJoint.transform);

    // Set the start position of the Axon LineRenderer to be the position of the currJoint GameObject
    axon.SetPosition(0, currJoint.transform.position);

    // Make the LineRenderer a child of the current GameObject
    axon.transform.SetParent(transform);

    // Set the end position of the Axon LineRenderer to be the position of the current GameObject
    axon.SetPosition(1, transform.position);
}

private void OnTriggerEnter2D(Collider2D collision)
{
    // Check if the circular object has collided with Comida
    if (collision.CompareTag("Comida"))
    {
        // Destroy food
        Destroy(collision.gameObject);

        currJoint = Instantiate(axonJointPrefab, transform.position, Quaternion.identity);

        CreateAxon();

        direction = (collision.transform.position - transform.position).normalized;


        //Debug.Log("Collision Comida");
        // Calculate the angle of collision
        //Vector2 collisionNormal = collision.GetContact(0).normal;
        //float angle = 50.0f;//Mathf.Atan2(collisionNormal.y, collisionNormal.x) * Mathf.Rad2Deg;
        //direction = CalcDirection(angle);
    }
}

private Transform CreateJoint()
{
    throw new NotImplementedException();
}

/*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the circular object has collided with Comida
        if (collision.CompareTag("Comida"))
        {
            DeleteFood();

            currJoint = CreateJoint();

            CreateAxon();

            direction = CalcDirection();





            //Debug.Log("Collision Comida");
            // Calculate the angle of collision
            //Vector2 collisionNormal = collision.GetContact(0).normal;
            //float angle = 50.0f;//Mathf.Atan2(collisionNormal.y, collisionNormal.x) * Mathf.Rad2Deg;
            //direction = CalcDirection(angle);
        }
    }

    Vector2 CalcDirection()
    {
        //float x = Mathf.Sin(angle) * initDistance;
        //float y = 0;
        //float z = Mathf.Cos(angle) * initDistance;
        //transform.position = dendrites.position + new Vector3(x, y, z);
        //return (transform.position - dendrites.position).normalized;
    }

    private void DeleteFood()
    {
        throw new NotImplementedException();
    }

    
*/
}