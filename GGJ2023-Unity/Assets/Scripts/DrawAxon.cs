using UnityEngine;

public class DrawAxon : MonoBehaviour
{
    public Transform dendrites;
    public Transform terminals;
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (dendrites == null || terminals == null)
        {
            return;
        }

        Vector3 dendritesPos = dendrites.position;
        Vector3 terminalsPos = terminals.position;

        lineRenderer.SetPosition(0, dendritesPos);
        lineRenderer.SetPosition(1, terminalsPos);
    }
}
