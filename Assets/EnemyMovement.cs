using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;
    public float way;
    public float passedWay;
    public int direction;

    private void Awake()
    {
        MoveEnemyRepeatly();
    }

    // Use this for initialization
    void Start () {
        direction = 1;
        //speed = 0.5f * speed;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void MoveEnemyRepeatly() {

        float f = direction*speed * Time.deltaTime;
        transform.Translate(f, 0, 0);
        passedWay += speed;

        if (passedWay >= way){
            passedWay = 0;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            direction = -direction;
        }

        Invoke("MoveEnemyRepeatly", 0.1f);
    }
}
