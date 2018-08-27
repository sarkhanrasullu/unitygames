using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Character : MonoBehaviour {
	
	public float hiz, ziplamaGucu;
	public bool yerdemi, ciftZipla;
	public float h;
	public Rigidbody2D agirlik;
	Animator anim;
	public int can, maxCan;
	public GameObject[] canlar;
	public Text altinMiktar, havucMiktar;
	public int altinMiktarInt, havucMiktarInt;
	public AudioClip[] audioClips;
	public Character cr;
	private bool stopped;

	// Use this for initialization
	void Start () {
		stopped = true;
		cr = GetComponent<Character> ();
		agirlik = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		can = maxCan;
		canSistemi ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (yerdemi) {
				agirlik.AddForce (Vector2.up * ziplamaGucu);
				ciftZipla = true;
			} else if (ciftZipla) {
				agirlik.AddForce (Vector2.up * ziplamaGucu);
				ciftZipla = false;
			}
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			olme ();
		}

		if (can <= 0) {
			olme ();
		}

		canSistemi ();
	}

	void FixedUpdate(){
			    h = Input.GetAxis("Horizontal");
//				if (h != 0) {
//					stopped = false;
//					agirlik.AddForce (Vector2.right * h * hiz);
//				}else if(!stopped){
//					stopped = true;
//					agirlik.velocity = new Vector3 (0, 0, 0);
//				}
//
//				if(h > 0.1f) {
//					transform.localScale = new Vector2 (1, 1);
//				} 
//
//				if (h < -0.1f) {
//					transform.localScale = new Vector2 (-1, 1);
//				} 

		if (h > 0) {
			transform.localScale = new Vector2 (1, 1);
		}
		if (h < 0) {
			transform.localScale = new Vector2 (-1, 1); 
		}
		if (h != 0) {
			float f = 	h * hiz * Time.deltaTime;
			transform.Translate (f, 0, 0);
		}

		anim.SetFloat ("Hiz", Mathf.Abs(h));
		anim.SetBool ("Yerdemi", yerdemi);
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

	void OnCollisionEnter2D(Collision2D nesne){
		cr.yerdemi = true;
		if (nesne.gameObject.tag == "tuzakTag") {
			PlaySound (2);
			can -= 1;
			agirlik.AddForce (Vector2.up * ziplamaGucu);
			GetComponent<SpriteRenderer> ().color = Color.red;
			Invoke ("Duzelt", 0.5f);
			canSistemi ();
		} 
	}

	void OnCollisionExit2D(Collision2D nesne){
		cr.yerdemi = false;
	}

	void OnTriggerEnter2D(Collider2D nesne){
		if (nesne.gameObject.tag == "havucTag") {
			PlaySound (0);

			havucMiktarInt++;
			havucMiktar.text = havucMiktarInt + "";

			Destroy (nesne.gameObject);
		}

		if (nesne.gameObject.tag == "coinTag") {
			PlaySound (1);
			
			altinMiktarInt++;
			altinMiktar.text = altinMiktarInt + "";

			Destroy (nesne.gameObject);
		}
	}

	void PlaySound(int index){
		AudioSource ass = GetComponent<AudioSource> ();
		ass.PlayOneShot (audioClips [index]);
	}


	void Duzelt(){
		GetComponent<SpriteRenderer> ().color = Color.white;
	}
 
}