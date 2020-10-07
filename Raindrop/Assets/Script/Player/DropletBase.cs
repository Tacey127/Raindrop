using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropletBase : MonoBehaviour
{
	[SerializeField] float speed = 1;
	public static float size;
	[SerializeField] float turnSmoothing = 0.125f;

	Quaternion rotation;
	protected Vector3 direction;

    #region base
    // Use this for initialization
    void Start()
	{
		direction = Vector3.zero;
		rotation = transform.rotation;
	}

	// DO NOT OVERRIDE UPDATE
	void Update()
	{
		RunUpdate();
	}

    #endregion

    protected virtual void RunUpdate()
    {
		transform.Translate(nextPosition(direction.y));
		transform.Rotate(nextRotation(direction.x) , Space.World);
    }

	Vector3 nextPosition(float direction)
    {
		Vector3 returnValue = Vector3.zero;
		returnValue.y = direction;
		return returnValue * speed * Time.deltaTime;
	}

	Vector3 nextRotation(float rotationDirection)
    {
		Quaternion desiredRotation = Quaternion.identity;
		
		desiredRotation.z += Mathf.Deg2Rad * 15 * rotationDirection * turnSmoothing * Time.deltaTime;

		return desiredRotation.eulerAngles;
    }

	void Absorb(ADroplet other)
	{
		transform.localScale += other.transform.localScale * 0.2f;
	}

}

