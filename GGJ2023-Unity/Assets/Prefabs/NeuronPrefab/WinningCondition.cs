using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinningCondition : MonoBehaviour
{
    public static bool inputConnected = false;
    public static bool outputConnected = false;
    public static bool win = false;

    void Update()
    {
        if (!win & inputConnected && outputConnected) {
            Debug.Log("You Win!");
            SwitchPlay.play = false;
            win = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
