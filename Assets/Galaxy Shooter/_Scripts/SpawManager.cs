using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawManager : MonoBehaviour {

	[SerializeField]
	private GameObject _enemyShipPrefab;
	[SerializeField]
	private GameObject[] _powerups;

	[SerializeField]
	private float spawEnemy = 2.5f;
	[SerializeField]
	private float spawPowerups = 9.0f;

	private GameController _gameController;

	// Use this for initialization
	void Start() {

		_gameController = GameObject.Find("Game_Controller").GetComponent<GameController>();

		InvokeRepeating("SpawEnemy", 2.0f, spawEnemy);
		InvokeRepeating("SpawPowerups", 6.0f, spawPowerups);
	}

	private void SpawEnemy() {
		if (_gameController.gameOver == false)
		{
			float randomX = Random.Range(-8, 8);
			GameObject.Instantiate(_enemyShipPrefab, new Vector3(randomX, 6.5f, 0), Quaternion.identity);
		}
	}

	private void SpawPowerups()
	{
		if (_gameController.gameOver == false)
		{
			float randomX = Random.Range(-8, 8);
			Instantiate(_powerups[Random.Range(0, 3)], new Vector3(randomX, 6.5f, 0), Quaternion.identity);
		}
	}
}
