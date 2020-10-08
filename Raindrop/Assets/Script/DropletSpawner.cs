using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns droplets based on spawnRate at different positions
/// </summary>
public class DropletSpawner : MonoBehaviour {
	
	[SerializeField] float spawnRate;
	[SerializeField] float spawnSizeVariance;
	[SerializeField] GameObject spawnThing;
	[SerializeField] RectTransform spawnSpace;
	float spawnSizeMult;
	int numDrops;

	float timeSinceSpawn = 0;

	// Update is called once per frame
	void Update () {
		spawnSizeMult = PlayerWater.size;
		timeSinceSpawn += Time.deltaTime;
		if (timeSinceSpawn > 1 / spawnRate) {
			timeSinceSpawn = 0;
			ADroplet adrop;
			adrop = Instantiate(spawnThing, Vector3.zero ,Quaternion.identity, transform).GetComponent<ADroplet>();
			adrop.transform.localPosition = new Vector3 (getSpawnLoc (), 0, 0);
			adrop.transform.localScale = Vector3.one * Random.Range (0, spawnSizeVariance * spawnSizeMult);
		}
	}

	float getSpawnLoc(){
		return (Random.Range (spawnSpace.rect.xMin, spawnSpace.rect.xMax));
	}
}
