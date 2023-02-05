using UnityEngine;
using UnityEngine.UI;

public class WinningCondition : MonoBehaviour
{
    public static bool inputConnected = false;
    public static bool outputConnected = false;
    public static bool win = false;

    void Update()
    {
        if (!win & inputConnected && outputConnected) {
            Debug.Log("You Win!");
            win = true;
        }
    }
}
