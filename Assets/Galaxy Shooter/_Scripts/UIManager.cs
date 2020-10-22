using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	public Sprite[] lifes;
	public Image lifesImageDisplay;
	public Text scoreText;
	public int score;
	public GameObject title;

    public void Start() {
        lifesImageDisplay.enabled = false;
        scoreText.enabled = false;
    }
    public void Update() {
		UpdateScore();
	}

	public void UpdateLives(int currentLives) {

		lifesImageDisplay.sprite = lifes[currentLives];

	}

	public void UpdateScore() {

		scoreText.text = "Score: " + score;

	}

	public void ShowTitleScreen() {
		title.SetActive(true);
	}

	public void HideTitleScreen() {
		title.SetActive(false);
		lifesImageDisplay.enabled = true;
		scoreText.enabled = true;
	}

}
