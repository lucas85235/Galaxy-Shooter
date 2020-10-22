using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int playerLifes = 3;

	// Power-Ups
	public bool canTripleShot = false;
	public bool canSpeedBoost = false;
	public bool canShild = false;
	// Power-Ups Prefabs
	[SerializeField]
	private GameObject _tripleLaserPrefab;
	[SerializeField]
	private GameObject _laserPrefab;
	[SerializeField]
	private GameObject _shidls;

	[SerializeField]
	private GameObject[] _engine;
	private int _hitCount = 0;

	[SerializeField]
	private GameObject _explosionAnimation;

	[SerializeField]
	private float _fireRate = 0.2f;
	[SerializeField]
	private float _naveSpeed = 5.0f;
	[SerializeField]
	private float _speedBoost = 10.0f;
	private float _canFire = 0.0f;

	[SerializeField]
	private AudioClip _clip;
	private AudioSource _audioSource;

	private UIManager _uiManager;
	private GameController _gameController;

	void Start () {

		transform.position = new Vector3(0, 0, 0);

		_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
		_gameController = GameObject.Find("Game_Controller").GetComponent<GameController>();
		_audioSource = GetComponent<AudioSource>();

		if (_uiManager != null)
		{
			_uiManager.UpdateLives(playerLifes);
		}

	}

	void Update() {

		Movement();

		if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
		{
			Shoot();
		}

	}

	private void Shoot () {

		if (Time.time > _canFire)
		{
			_canFire = Time.time + _fireRate;
			_audioSource.Play();
			if (canTripleShot == false)
			{
				Instantiate(_laserPrefab, transform.position + new Vector3 (0, 0.94f, 0), Quaternion.identity);
			} else
			{
				Instantiate(_tripleLaserPrefab, transform.position + new Vector3(0, 0.94f, 0), Quaternion.identity);
			}
			_canFire = Time.time + _fireRate;
		}

	}

	private void Movement () {

		//Movimentação
		float horinzontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
		//Com velocidade normal e com speed boosst
		if (canSpeedBoost == false)
		{
			transform.Translate(Vector3.right * _naveSpeed * horinzontalInput * Time.deltaTime);
			transform.Translate(Vector3.up * _naveSpeed * verticalInput * Time.deltaTime);
		}
		else
		{
			transform.Translate(Vector3.right * _speedBoost * horinzontalInput * Time.deltaTime);
			transform.Translate(Vector3.up * _speedBoost * verticalInput * Time.deltaTime);
		}

		// Limites de cime e baixo.
		if (transform.position.y > 0) {
			transform.position = new Vector3(transform.position.x, 0, 0);
		}
        else if (transform.position.y < -4.2f)
        {
			transform.position = new Vector3(transform.position.x, -4.2f, 0);
		}

		// Sistema de Wrapping
		if (transform.position.x > 9.3f) {
			transform.position = new Vector3(-8.2f, transform.position.y, 0);
		}
        else if (transform.position.x < -9.3f)
        {
			transform.position = new Vector3(8.2f, transform.position.y, 0);
		}

	}

	public void Damage () {

		if (canShild == true)
		{
			CanShildOff();
			return;
		}

		playerLifes--;
		_uiManager.UpdateLives(playerLifes);

		_hitCount++;

		if (_hitCount == 1)
		{
			_engine[0].SetActive(true);

		}
		else if (_hitCount == 2)
		{
			_engine[1].SetActive(true);
		}


		if (playerLifes < 1)
		{
			AudioSource.PlayClipAtPoint(_clip, transform.position);
			Instantiate(_explosionAnimation, transform.position, Quaternion.identity);
			_uiManager.ShowTitleScreen();
			_gameController.gameOver = true;
			Destroy(this.gameObject);
		}
	}

	public void CanTripleShotOn () {
		canTripleShot = true;
		StartCoroutine("TripleShotCaroutine");
	}

	public IEnumerator TripleShotCaroutine() {
		yield return new WaitForSeconds(5.0f);
		canTripleShot = false;
	}

	public IEnumerator SpeedBoostCaroutine() {
		yield return new WaitForSeconds(5.0f);
		canSpeedBoost = false;
	}

	public void CanSpeedBoostOn() {
		canSpeedBoost = true;
		StartCoroutine("SpeedBoostCaroutine");
	}

	public void CanShildOn () {
		_shidls.SetActive(true);
		canShild = true;
	}
	public void CanShildOff() {
		_shidls.SetActive(false);
		canShild = false;
	}

}
