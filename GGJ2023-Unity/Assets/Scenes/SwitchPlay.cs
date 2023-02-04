using UnityEngine;
using UnityEngine.UI;

public class SwitchPlay : MonoBehaviour
{
    public Button button;
    public static bool play = false;

    void Start()
    {
        button.onClick.AddListener(TogglePlay);
    }

    void TogglePlay()
    {
        play = !play;
    }
}
