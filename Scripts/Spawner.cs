using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject spawnObject;
	public GameObject spawnField;

	public int count;

	private float offset, x, y;
	private float maxX, maxY;

	void Start () {
		SpriteRenderer spawnFieldSprite = spawnField.GetComponent<SpriteRenderer>();
		BoxCollider2D fieldCollider = spawnField.GetComponent<BoxCollider2D>();
		SpriteRenderer itemSprite = spawnObject.GetComponent<SpriteRenderer>();
		offset = Mathf.Min(fieldCollider.size.x, fieldCollider.size.y) + 
			Mathf.Max(itemSprite.sprite.bounds.size.x,itemSprite.sprite.bounds.size.y)/2 ;
		maxX = spawnFieldSprite.sprite.bounds.size.x/2 - offset;	
		maxY = spawnFieldSprite.sprite.bounds.size.y/2 - offset;	
		Spawn (count);
	}
	

	public void Spawn(int count)
	{
		
		for (int i = 0; i < count; i++) 
		{
			x = Random.Range (-maxX, maxX);
			y = Random.Range (-maxY, maxY);

			Instantiate(spawnObject, new Vector3 (x, y, 0), Quaternion.identity);

		}
	}
}
