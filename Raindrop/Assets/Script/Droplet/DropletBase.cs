using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropletBase : MonoBehaviour
{
	[SerializeField] protected GameObject spriteHolder;
	[SerializeField] protected float speed = 1;

	//z axis rotation
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

    #region collision

    private void OnTriggerEnter2D(Collider2D other)
	{

		DropletBase otherDroplet = other.GetComponent<DropletBase>();


		if (transform.localScale.x > other.transform.localScale.x)
		{
			OnAbsorb(otherDroplet);
		}

		if (transform.localScale.x < other.transform.localScale.x)
		{
			OnAbsorbed();
		}

	}

	protected void OnAbsorb(DropletBase other)
	{
		transform.localScale += other.transform.localScale * 0.2f;
		Destroy(other.gameObject);
	}

	protected void OnAbsorbed()
    {

    }

    #endregion
}

