using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour {


	public Transform karakter;
	public Material material;
	public float x,y;
	public int xVelocity, yVelocity;
	Vector2 offset;

//	private void Awake(){
//		material = transform.GetComponent<Renderer> ().material;
//	}

	// Use this for initialization
	void Start () {
	//	karakter = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(karakter.position.x+x,karakter.position.y+y,-10f);
		offset = new Vector2 (karakter.position.x+x,karakter.position.y+y);
		//material.mainTextureOffset = offset * Time.deltaTime;
	}
}
