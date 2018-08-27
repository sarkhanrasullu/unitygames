using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMaker : MonoBehaviour {

	public List<GameObject> places;
	public GameObject startPlace;
	public GameObject finishPlace;
	public GameObject character;



	// Use this for initialization
	void Start () {
		startX = 0;
		startY = 0;
		Genereate ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Genereate(){
		Debug.Log ("generate");
		if (places == null || places.Count == 0)
			return;
		
		InstantiatePlace (startPlace);
		for (int i = 0; i < 10; i++) {
		    int index = rnd.Next(0, places.Count); 
			GameObject obj = places [index];

			InstantiatePlace (obj);
		}
		InstantiatePlace (finishPlace);
	}

	private  System.Random rnd = new System.Random();
	private  GameObject lastPlace;
	private  int startX;
	private  int startY;

	public  void InstantiatePlace(GameObject obj){
		if (lastPlace!=null) {
			int lastPlaceWidth =(int) Get_Width (lastPlace);
			int lastPlaceHeight =(int) Get_Height (lastPlace);
			//int characterWidtdth = Get_Width (character);
			startX +=  lastPlaceWidth + rnd.Next (1, 4);
			int upOrDown = rnd.Next (0, 3);
			if (upOrDown == 0) {//up
				startY += lastPlaceHeight;
			} else if (upOrDown == 1) {//down
				startY -= lastPlaceHeight + rnd.Next (2, 5);
			}//stable
			Debug.Log ("last place width=" + lastPlaceWidth);
		}

		obj.transform.rotation = transform.rotation;
		obj.transform.position = new Vector3 (startX, startY, 0);
		Instantiate (obj);

		lastPlace = obj;
		Debug.Log ("startX=" + startX);
		Debug.Log ("obj.transform.position=" + obj.transform.position);
	}
 
	public static float Get_Width(GameObject gameObject)
	{
		var collider2D= gameObject.GetComponent<BoxCollider2D>();
		float width = collider2D.size.x; //Edit, thanks to Arttu's comment!

		return width;
	}

	public static float Get_Height(GameObject gameObject)
	{
		var collider2D= gameObject.GetComponent<BoxCollider2D>();
		float height = collider2D.size.y; //Edit, thanks to Arttu's comment!

		return height;
	}
}
