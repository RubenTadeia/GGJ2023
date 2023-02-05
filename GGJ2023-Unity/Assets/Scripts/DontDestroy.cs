using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
	void Awake() {
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Start is called before the first frame update
	void Start()
	{
		Awake();
	}
}
