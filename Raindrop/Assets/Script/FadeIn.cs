using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {
	float alpha = 0;
	// Update is called once per frame
	void Update () {
		alpha += Time.deltaTime * 0.25f;
		alpha = Mathf.Min(1, alpha);
		GetComponent<Image> ().color = new Color (0.8f, 0.8f, 0.8f, alpha);
	}
}
