using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWater : MonoBehaviour {

	float dir;
	[SerializeField]float spd = 1;
	[SerializeField]GameObject gameOver;
	public static float size;
	[SerializeField] AudioSource sounds;
	float score = 0;
	[SerializeField] Text scoreDisplay;
	[SerializeField] Text hiScoreDisplay;
	bool dead = false;
	[SerializeField] GameObject spawner = null;
	[SerializeField]float turnSmoothing = 0.125f;
	static float HiScore;


	Quaternion baseRot;
	// Use this for initialization
	void Start () {
		dir = 0;
		baseRot = transform.rotation;
	}
		
	// Update is called once per frame
	void Update () {

		if (!dead) {
			dir = Input.GetAxis ("Horizontal");
			size = transform.localScale.x;

			Quaternion desiredRotation = baseRot;

			if (dir > 0) {
				Quaternion s = baseRot;
				s.z += Mathf.Deg2Rad * 15;
				desiredRotation = s;
			}

			if (dir < 0) {
				Quaternion f = baseRot;
				f.z -= Mathf.Deg2Rad * 15;
				desiredRotation = f;
			}

			Quaternion smoothedRotation = Quaternion.Lerp (transform.rotation, desiredRotation, turnSmoothing);
			transform.rotation = smoothedRotation;


			transform.position = transform.position + (new Vector3 (dir * spd, 0, 0) * Time.deltaTime);
			transform.localScale -= Vector3.one * Time.deltaTime;
			score += Time.deltaTime * size * 0.1f;
			scoreDisplay.text = "Score: " + score.ToString ("0");
		}
		else {		//dead state
			if (score > HiScore) {
				HiScore = score;
			}
			hiScoreDisplay.text = "High Score: " + HiScore.ToString ("0");
			
		}

		if (size < 0) {
			gameOver.SetActive (true);
			dead = true;
			Debug.Log ("game over");
			spawner.SetActive (false);
			gameObject.SetActive (false);
		}

		if (score > HiScore) {
			HiScore = score;
		}
		hiScoreDisplay.text = "High Score: " + HiScore.ToString ("0");
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.localScale.x > transform.localScale.x) {
			//game over screen
			gameOver.SetActive(true);
			Debug.Log("game over");
			dead = true;
			spawner.SetActive (false);
			gameObject.SetActive (false);
		}

		if (other.transform.localScale.x < transform.localScale.x) {
			//grow
			Absorb(other.GetComponent<ADroplet>());
			sounds.Play ();
			Destroy (other.gameObject);
		}
	}

	void Absorb(ADroplet other){

		transform.localScale += other.transform.localScale * 0.2f;
	}

}
