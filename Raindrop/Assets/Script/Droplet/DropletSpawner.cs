using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawns droplets based on spawnRate at different positions
/// </summary>
public class DropletSpawner : MonoBehaviour {
	
	[SerializeField] float spawnRate = 1;
	[SerializeField] float spawnSizeVariance = 3;

	//[SerializeField] float minSize = 0.2f;
	//[SerializeField] float maxSize = 4f;

	[SerializeField] float spawnXDistance = 2;

	//float timeSinceSpawn = 0;

	[SerializeField] public BulletSpawnVarient[] bullets;



    private void Start()
    {
		bullets = HUDManager.instance.info.themeSet.obstacles;    
    }


    // Update is called once per frame
    void Update () {

        for (int i = 0; i < bullets.Length; i++)
        {
			bullets[i].timeSinceSpawn += Time.deltaTime;
			if (bullets[i].timeSinceSpawn > 1 / bullets[i].spawnRate)
			{
				bullets[i].timeSinceSpawn = 0;
				SpawnDroplet(bullets[i].droplet ,bullets[i].minSize, bullets[i].maxSize);
			}
        }

	}

	void SpawnDroplet(GameObject spawnObject, float minSize, float maxSize)
    {
		float _size = Random.Range(minSize, maxSize);
		float _speed = (1 / _size) + 1;

		AIDroplet droplet = Instantiate(spawnObject, new Vector3(getSpawnLoc(), transform.position.y, 0), Quaternion.identity).GetComponent<AIDroplet>();
		droplet.ApplyParameters(_size, _speed, Vector3.down);

		//Apply colour
		droplet.ApplyColour(new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 0.9f)));
	}

	float getSpawnLoc(){
		return (Random.Range (-spawnXDistance, spawnXDistance));
	}

}

[System.Serializable]
public struct BulletSpawnVarient
{
	public float minSize;
	public float maxSize;
	public float spawnRate;
	public float timeSinceSpawn;

	public GameObject droplet;
}