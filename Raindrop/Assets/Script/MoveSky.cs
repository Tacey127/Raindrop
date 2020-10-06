using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSky : MonoBehaviour {
	[SerializeField] float moveSpeed;
	// Update is called once per frame
	void Update () {
		GetComponent<Image> ().material.mainTextureOffset -= new Vector2(0, Time.deltaTime * moveSpeed);
	}
}
