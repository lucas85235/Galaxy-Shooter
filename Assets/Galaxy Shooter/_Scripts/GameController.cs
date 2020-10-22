using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public bool gameOver = true;

	public GameObject player;

	private UIManager _uiManager;

	//se gamer over for verdadeiro
	//se aperta space
	//instanciar o player
	//gamerOver = false
	//esconder o title

	void Start() {
		_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
		_uiManager.lifesImageDisplay.enabled = false;
		_uiManager.scoreText.enabled = false;
	}

	void Update() {

		if (gameOver == true)
		{
			if (Input.GetKeyUp(KeyCode.Space))
			{
				Instantiate(player, Vector3.zero, Quaternion.identity);
				_uiManager.HideTitleScreen();
				_uiManager.score = 0;
				gameOver = false;
			}
		} 

	}

}
