using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinningCondition : MonoBehaviour
{
    public static bool inputConnected = false;
    public static bool outputConnected = false;

    void Update()
    {
        if (inputConnected && outputConnected) {
            Debug.Log("You Win!");
            SwitchPlay.play = false;
            inputConnected = false;
            outputConnected = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
