using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMaker : MonoBehaviour {

	public GameObject gameObject;
	public Vector3 position;
	public Quaternion rotation;

	// Use this for initialization
	void Start () {
		position = transform.position;
		rotation = transform.rotation;
		Instantiate (gameObject,new Vector3(transform.position.x,transform.position.y,transform.position.z),transform.rotation);
		Instantiate (gameObject,new Vector3(transform.position.x+6.60f,transform.position.y,transform.position.z),transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
