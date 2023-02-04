using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouseWheel : MonoBehaviour
{
	private bool isSelected;

    private void Update()
    {
        if (isSelected)
        {
            float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
            if (mouseWheel != 0)
            {
                transform.Rotate(Vector3.forward, mouseWheel * 180);
            }
        }
    }

    private void OnMouseDown()
    {
        isSelected = true;
    }

    private void OnMouseUp()
    {
        isSelected = false;
    }
}
