using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	[SerializeField]
	private float powerupSpeed = 2;
	[SerializeField]
	private int powerupID; //0 = triple shot, 1 = speed boost, 2 = shild
	[SerializeField]
	private AudioClip _powerupSound;

	void Start () {

	}
	
	void Update () {
		transform.Translate(Vector3.down * powerupSpeed * Time.deltaTime);

		if (transform.position.y <= -6.5) {
			Destroy(this.gameObject);
		}

		//configurar escudos--
		//habilitar escudos
		//player vai poder levar 1 dano do inimigo
		//e se os escudos esterem ativos, ao inves de causar dano ao player
		//ira apenas deligar o escudo

	}

	private void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player")
		{
			//Acesso ao Player
			Player player = other.GetComponent<Player>();

			AudioSource.PlayClipAtPoint(_powerupSound, Camera.main.transform.position);

			if (player != null)
			{
				if (powerupID == 0)
				{
					player.CanTripleShotOn();
				}
				else if (powerupID == 1)
				{
					player.CanSpeedBoostOn();
				}
				else if (powerupID == 2)
				{
					player.CanShildOn();
				}
			}

			//Destroi o objeto power-up
			Destroy(this.gameObject);

		}

	}

}
