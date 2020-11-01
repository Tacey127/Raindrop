using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSky : MonoBehaviour {
	[SerializeField] float moveSpeed = 0;
    MeshRenderer offsetImage;

    float offsetTimer = 0;

    private void Awake()
    {
        offsetImage = GetComponent<MeshRenderer>();
    }

    void Update () {
        offsetTimer += Time.deltaTime;
		offsetImage.material.SetTextureOffset("_MainTex", new Vector2(0, offsetTimer * moveSpeed));
	}
}
