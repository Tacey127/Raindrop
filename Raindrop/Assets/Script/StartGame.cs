using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

	public void StartGameNow()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (1);
	}
}
