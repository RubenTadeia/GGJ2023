using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventOverlap : MonoBehaviour
{
	private Vector2 previousPosition;

	private void Start()
	{
		// Store the initial position of the object
		previousPosition = transform.position;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// Check if the collider's tag is the one you want to avoid overlapping with
		if (collision.CompareTag("Obstacle"))
		{
			// Move the object back to its previous position to avoid overlap
			transform.position = previousPosition;
		}
	}
}
