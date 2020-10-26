using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns droplets based on spawnRate at different positions
/// </summary>
public class DropletSpawner : MonoBehaviour {
	
	[SerializeField] float spawnRate = 1;
	[SerializeField] float spawnSizeVariance = 3;
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
			SpawnDroplet();
		}
	}

	void SpawnDroplet()
    {
		Debug.Log("spawned");
		float _size = Random.Range(0.2f, spawnSizeVariance * PlayerHolder.instance.getSize());
		
		AIDroplet droplet = Instantiate(spawnObject, new Vector3(getSpawnLoc(), transform.position.y, 0), Quaternion.identity).GetComponent<AIDroplet>();
		droplet.ApplyParameters(_size, 1, Vector3.down);

		//Apply colour
		droplet.ApplyColour(new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 0.9f)));
	}

	float getSpawnLoc(){
		return (Random.Range (-spawnXDistance, spawnXDistance));
	}

}
