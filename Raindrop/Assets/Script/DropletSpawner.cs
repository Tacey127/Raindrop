using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns droplets based on spawnRate at different positions
/// </summary>
public class DropletSpawner : MonoBehaviour {
	
	[SerializeField] float spawnRate = 1;
	[SerializeField] float spawnSizeVariance = 2;
	[SerializeField] float spawnXDistance = 3;
	//[SerializeField] GameObject spawnThing;
	[SerializeField] GameObject spawnObject;
	//[SerializeField] RectTransform spawnSpace;

	float timeSinceSpawn = 0;

	// Update is called once per frame
	void Update () {
		timeSinceSpawn += Time.deltaTime;
		if (timeSinceSpawn > 1 / spawnRate) {
			timeSinceSpawn = 0;
			//BasicSpawn();
			SpawnDroplet();
		}
	}

	/*
	void BasicSpawn()
	{
			ADroplet adrop;
			float spawnSizeMult = PlayerWater.size;
			adrop = Instantiate(spawnThing, Vector3.zero ,Quaternion.identity, transform).GetComponent<ADroplet>();
			adrop.transform.localPosition = new Vector3 (getSpawnLoc (), 0, 0);
			adrop.transform.localScale = Vector3.one * Random.Range (0, spawnSizeVariance * spawnSizeMult);
	}
	*/

	void SpawnDroplet()
    {
		Debug.Log("spawned");
		float _size = Random.Range(0.2f, spawnSizeVariance * PlayerController.instance.getSize());
		
		AIDroplet droplet = Instantiate(spawnObject, new Vector3(getSpawnLoc(), transform.position.y, 0), Quaternion.identity).GetComponent<AIDroplet>();
		droplet.ApplyParameters(_size, 1, Vector3.down);

	}

	float getSpawnLoc(){
		return (Random.Range (-spawnXDistance, spawnXDistance));
	}

}
