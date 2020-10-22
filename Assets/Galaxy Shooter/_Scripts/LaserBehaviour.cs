using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour {

	[SerializeField]
	private float _laserSpeed = 10.0f;

	void Start () {
		
	}
	
	void Update () {

		transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);
		
		if (transform.position.y >= 6f)
		{
			Destroy(this.gameObject);
		}

	}
}
