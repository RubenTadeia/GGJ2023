using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
	public string sceneName;
	public int secondsToWait;

	IEnumerator FunctionWait()
    {
        yield return new WaitForSeconds(secondsToWait);
    }

	public void ChangeToScene()
	{
		FunctionWait();
		UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
	}
}
