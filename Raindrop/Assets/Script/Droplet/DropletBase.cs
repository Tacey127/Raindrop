using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropletBase : MonoBehaviour
{
	[SerializeField] protected GameObject spriteHolder = null;
	[SerializeField] protected float speed = 1;
	[SerializeField] public int Score = 0;

	float rotation = 0;

	protected Vector3 direction = Vector3.zero;
	protected Vector3 position = Vector3.zero;

    #region base

	// DO NOT OVERRIDE UPDATE
	void Update()
	{
		RunUpdate();
	}

    #endregion

    protected virtual void RunUpdate()
    {
		UpdatePosition();
    }

	protected void UpdatePosition()
    {
		transform.Translate(nextPosition(direction));
	}

	Vector3 nextPosition(Vector3 direction)
    {
		return direction * speed * Time.deltaTime;
	}
}

