using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	private float speed = -0.5f;
	private float deadLine = -10;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (this.speed, 0, 0);

		if (transform.position.x < this.deadLine) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "fieldTag" || other.gameObject.tag == "blockTag") {
			playSound ();
		}
	}

	void playSound(){
		audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.Play ();
	}

}

