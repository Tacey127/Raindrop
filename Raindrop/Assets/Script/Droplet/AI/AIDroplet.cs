using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDroplet : DropletBase
{
    //takes size, speed and direction
    AIDroplet(float _size, float _speed, Vector3 _direction)
    {
		direction = _direction;
		speed = _speed;
    }

	/*
	void Start () {
		GetComponent<SpriteRenderer> ().color = new Color (Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 0.9f));
	}
	
	void Update () {

		if (transform.localPosition.y > Screen.height + 1000)
			Destroy (gameObject);
	}
    */
}
