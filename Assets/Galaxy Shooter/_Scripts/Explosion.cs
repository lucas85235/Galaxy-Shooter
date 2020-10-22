using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	[SerializeField]
	private float speed = 1.5f;
	[SerializeField]
	private int animationID;

	private float countTime = 2.9f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (animationID == 0)
		{
			transform.Translate(Vector3.down * speed * Time.deltaTime);
		}
		else if (animationID == 1)
		{
			transform.Translate(Vector3.up * speed * 2 * Time.deltaTime);
		}
		countTime -= Time.deltaTime;

		if (countTime < 0)
		{
			Destroy(this.gameObject);
		}

	}
}
