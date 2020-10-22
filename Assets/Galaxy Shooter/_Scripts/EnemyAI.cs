using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	[SerializeField]
	private float _speedDown;
	[SerializeField]
	private GameObject _enemyExplosion;

	[SerializeField]
	private AudioClip _clip;

	private UIManager _uiManager;
	private GameController _gameController;

	// Use this for initialization
	void Start () {

		_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
		_gameController = GameObject.Find("Game_Controller").GetComponent<GameController>();

	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(Vector3.down * _speedDown * Time.deltaTime);

		//respawn em cima em local aleatorio
		if (transform.position.y <= -6.5f)
		{
			float randomX = Random.Range(-8.0f, 8.0f);
			transform.position = new Vector3 (randomX, 6.5f, 0);
		}

		if (transform.position.y <= 6.5 && _gameController.gameOver == true)
		{
			Destroy(this.gameObject);
		}

	}

	public void EnemyExplosion() {
		AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
		Destroy(this.gameObject);
		_uiManager.score += 10;
		Instantiate(_enemyExplosion, transform.position, Quaternion.identity);
	}

	public void OnTriggerEnter2D(Collider2D other) {

		Player player = other.GetComponent<Player>();

		if (other.tag == "Laser")
		{
			if (other.transform.parent != null)
			{
				Destroy(other.transform.parent.gameObject);
			}
			Destroy(other.gameObject);
			EnemyExplosion();
		}
		else if (other.tag == "Player")
		{
			EnemyExplosion();
			player.Damage();
		}

	}

}