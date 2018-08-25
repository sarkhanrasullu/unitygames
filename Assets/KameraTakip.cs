using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour {


	public Transform karakter;
	public float x,y;
	// Use this for initialization
	void Start () {
		karakter = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(karakter.position.x+x,karakter.position.y+y,-10f);
	}
}
