using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public float speed = 1f;

    private Rigidbody2D myBody;

    public int scores = 0;
    
	public bool isDead = false;

	void Start ()
    {
        myBody = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * speed;
        float moveVertical = Input.GetAxis("Vertical") * speed;
        myBody.AddForce(new Vector2(moveHorizontal, moveVertical));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gem")
        {
            scores++;
            Destroy(collision.gameObject);
            Debug.Log(scores);
        }
    }

}
