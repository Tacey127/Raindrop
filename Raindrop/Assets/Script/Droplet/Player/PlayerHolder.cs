using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolder : MonoBehaviour
{

    #region singleton

    public static PlayerHolder instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

	#endregion

	[SerializeField] protected Transform spriteHolder;

	[SerializeField] protected float speed = 1;


	protected Vector3 direction = Vector3.zero;
	protected Vector3 position = Vector3.zero;

    #region base

    private void Start()
    {
		RunStart();
    }

    // DO NOT OVERRIDE UPDATE
    void Update()
	{
		RunUpdate();
	}

	#endregion

	protected virtual void RunStart()
    {
		
    }

    #region Update

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

    #endregion

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
		HUDManager.instance.UpdateScoreUI(other.Score);
		transform.localScale += other.transform.localScale * 0.2f;
		Destroy(other.gameObject);
	}

	protected virtual void OnAbsorbed()
	{
		Debug.Log("Player is Dead.");
	}

    #endregion


    public float getSize()
    {
        return spriteHolder.transform.localScale.x;
    }
}
