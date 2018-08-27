using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMaker : MonoBehaviour {

	public List<GameObject> places;
	public GameObject character;

	private System.Random rnd = new System.Random();
	private GameObject lastPlace;

	// Use this for initialization
	void Start () {
		Genereate ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Genereate(){
		Debug.Log ("generate");
		if (places == null || places.Count == 0)
			return;
		
		int startX = 0;
		int startY = 0;
		int startZ = 0;

		for (int i = 0; i < 10; i++) {
		    int index = rnd.Next(0, places.Count); 
			GameObject obj = places [index];

			if (lastPlace!=null) {
				float lastPlaceWidth = Get_Width (lastPlace);
				//int characterWidtdth = Get_Width (character);
				startX += (int) lastPlaceWidth + 1;
				Debug.Log ("last place width=" + lastPlaceWidth);
				Debug.Log ("startX=" + startX);
			}

			obj.transform.rotation = transform.rotation;
			obj.transform.position = new Vector3 (startX, startY, startZ);
			Instantiate (obj);

			lastPlace = obj;
		}
	}
 
	public static float Get_Width(GameObject gameObject)
	{
		float width = 0;

		var collider2D= gameObject.GetComponent<BoxCollider2D>();
		width = collider2D.size.x; //Edit, thanks to Arttu's comment!

		return width;
	}
}
