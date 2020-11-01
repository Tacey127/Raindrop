using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADroplet : MonoBehaviour {

	float spd;
	[SerializeField]float spdmlt = 1;

	[SerializeField] float heavyMult = 1;

	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer> ().color = new Color (Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 0.9f));
	}
	
	// Update is called once per frame
	void Update () {
		spd = Mathf.Min(5,  PlayerWater.size / (transform.localScale.x * heavyMult));

		transform.position = transform.position + (new Vector3 (0, spd * spdmlt, 0) * Time.deltaTime);

		if (transform.localPosition.y > Screen.height + 1000)
			Destroy (gameObject);
	}
}
