using UnityEngine;
using UnityEngine.UI;

public class WinningCondition : MonoBehaviour
{
    public static bool inputConnected = false;
    public static bool outputConnected = false;
    public static bool win = false;

    void Update()
    {
        if (inputConnected && outputConnected) {
            win = true;
            Debug.Log("You Win!");
        }
    }
}
