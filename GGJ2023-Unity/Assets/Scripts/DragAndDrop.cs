using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
	bool canMove;
	bool dragging;
	Collider2D colliderVar;

	private Camera mainCamera;
	private float objectWidth;
	private float objectHeight;

	private Vector2 startPos;

	public bool colliding = false;

	void Start()
	{
		colliderVar = GetComponent<Collider2D>();
		canMove = false;
		dragging = false;

		mainCamera = Camera.main;
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		objectWidth = spriteRenderer.bounds.size.x / 2;
		objectHeight = spriteRenderer.bounds.size.y / 2;

		startPos = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (Input.GetMouseButtonDown(0))
		{
			if (colliderVar == Physics2D.OverlapPoint(mousePos))
			{
				canMove = true;
			}
			else
			{
				canMove = false;
			}
			if (canMove)
			{
				dragging = true;
			}
		}
		if (dragging)
		{
			startPos = transform.position;
			transform.position = mousePos;
		}
		if (Input.GetMouseButtonUp(0))
		{
			canMove = false;
			dragging = false;
		}
	}

	private void LateUpdate()
	{
		Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);
		viewPos.x = Mathf.Clamp01(viewPos.x);
		viewPos.y = Mathf.Clamp01(viewPos.y);
		transform.position = mainCamera.ViewportToWorldPoint(viewPos);

		Vector3 clampedPosition = transform.position;
		clampedPosition.x = Mathf.Clamp(clampedPosition.x, mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + objectWidth, mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0)).x - objectWidth);
		clampedPosition.y = Mathf.Clamp(clampedPosition.y, mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + objectHeight, mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0)).y - objectHeight);
		transform.position = clampedPosition;
	}

	private void OnCollisionEnter2D(Collision2D other) {
		dragging = false;
		transform.position = startPos;
	}
}
