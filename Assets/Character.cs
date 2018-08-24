using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	public float hiz, maxHiz, ziplamaGucu;
	public bool yerdemi, ciftZipla;
	public Vector2 velocity;
	public Vector2 inc;
	public Vector2 up;
	public float h;
	public Rigidbody2D agirlik;
	Animator anim;
	public int can, maxCan;

	public GameObject[] canlar;

	// Use this for initialization
	void Start () {
		agirlik = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		can = maxCan;
		canSistemi ();
	}
	
	// Update is called once per frame
	void Update () {
		up = Vector2.up*ziplamaGucu;
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (yerdemi) {
				agirlik.AddForce (Vector2.up * ziplamaGucu);
				ciftZipla = true;
			} else if (ciftZipla) {
				agirlik.AddForce (Vector2.up * ziplamaGucu);
				ciftZipla = false;
			}
		}

		if (can <= 0) {
			olme ();
		}

		canSistemi ();
	}

	void FixedUpdate(){
		velocity = agirlik.velocity;
	    h = Input.GetAxis("Horizontal");
		agirlik.AddForce(Vector2.right * h * hiz);

		anim.SetFloat ("Hiz", Mathf.Abs(h));
		anim.SetBool ("Yerdemi", yerdemi);

		if(h > 0.1f) {
			transform.localScale = new Vector2 (1, 1);
		} 

		if (h < -0.1f) {
			transform.localScale = new Vector2 (-1, 1);
		} 

//		if(h==0){
//			agirlik.velocity = new Vector2 (0, 0);
//			return;
//		} 
			
		if (agirlik.velocity.x > maxHiz) {
			agirlik.velocity = new Vector2(maxHiz, agirlik.velocity.y);
		} 

		if (agirlik.velocity.x < -maxHiz) {
			agirlik.velocity = new Vector2(-maxHiz, agirlik.velocity.y);
		} 
	}

	void olme(){
		Application.LoadLevel (Application.loadedLevel);
	}


	void canSistemi(){
		for (int i = 0; i < maxCan; i++) {
			canlar [i].SetActive (false);
		}

		for (int i = 0; i < can; i++) {
			canlar [i].SetActive (true);
		}
	}
}
