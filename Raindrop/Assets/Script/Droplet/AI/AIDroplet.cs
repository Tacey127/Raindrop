using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDroplet : DropletBase
{
	Vector3 size;

    //takes size, speed and direction
    public void ApplyParameters(float _size, float _speed, Vector3 _direction)
    {
		transform.localScale = Vector3.one * _size;
		direction = _direction;
		speed = _speed;
    }

	public void ApplyColour(Color _colour)
    {
		GetComponentInChildren<SpriteRenderer>().color = _colour;
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
