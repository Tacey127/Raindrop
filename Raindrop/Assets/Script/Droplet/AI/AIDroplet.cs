using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDroplet : DropletBase
{
    [Header("Rotation")]
    [SerializeField] bool isRotating = false;
    [SerializeField] float rotationAmount = 0;

	Vector3 size;

    protected override void RunUpdate()
    {
        base.RunUpdate();
        RotateSprite(rotationAmount);
    }

    //takes size, speed and direction
    public void ApplyParameters(float _size, float _speed, Vector3 _direction)
    {
		transform.localScale = Vector3.one * _size;
		speed = _speed;
		direction = _direction;

        rotationAmount *= (Random.Range(0, 2) * 2 - 1);
    }

	public void ApplyColour(Color _colour)
    {
		GetComponentInChildren<SpriteRenderer>().color = _colour;
	}

    void RotateSprite(float dir)
    {
        spriteHolder.transform.Rotate(0, 0, dir * Time.deltaTime);
    }

}
