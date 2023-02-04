using UnityEngine;

public class GrowDendrites : MonoBehaviour
{
    public Transform dendrites;
    public float growSpeed = 1.0f;
    public float maxSize = 2.5f;

    void Update()
    {
        bool isPlaying = SwitchPlay.play;

        if (isPlaying)
        {
            float currentSize = dendrites.localScale.x;
            if (currentSize < maxSize) {
                dendrites.localScale += Vector3.one * growSpeed * Time.deltaTime;
            }
        }
    }
}
