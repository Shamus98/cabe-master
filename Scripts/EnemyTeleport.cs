using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeleport : MonoBehaviour {

	public GameObject spawnField;

	public float minTeleportTime , maxTeleportTime;
	private float offset, x, y;
	private float maxX, maxY;

	void Start () {
		SpriteRenderer spawnFieldSprite = spawnField.GetComponent<SpriteRenderer>();
		BoxCollider2D fieldCollider = spawnField.GetComponent<BoxCollider2D>();
		SpriteRenderer itemSprite = GetComponent<SpriteRenderer>();
		offset = Mathf.Min(fieldCollider.size.x, fieldCollider.size.y) + 
			Mathf.Max(itemSprite.sprite.bounds.size.x,itemSprite.sprite.bounds.size.y)/2 ;
		maxX = spawnFieldSprite.sprite.bounds.size.x/2 - offset;	
		maxY = spawnFieldSprite.sprite.bounds.size.y/2 - offset;	

		StartCoroutine (Teleport());
	}

	public IEnumerator Teleport()
	{
		while (true) {
			x = Random.Range (-maxX, maxX);
			y = Random.Range (-maxY, maxY);
			float randomTime = Random.Range (minTeleportTime, maxTeleportTime);
			yield return new WaitForSeconds (randomTime);
			transform.position = new Vector3 (x, y, transform.position.z);
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			collision.gameObject.GetComponent<HeroScript>().isDead = true;
		}
	}
 }
