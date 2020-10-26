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
		speed = _speed;
		direction = _direction;
    }

	public void ApplyColour(Color _colour)
    {
		GetComponentInChildren<SpriteRenderer>().color = _colour;
	}
}
