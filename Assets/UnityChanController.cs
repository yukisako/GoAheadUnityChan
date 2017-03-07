using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

	//アニメーションをするためのコンポーネント
	Animator animator;

	Rigidbody2D righd2D;

	//地面の位置
	private float groundLevel = -3.0f;

	private float dump = 0.8f;

	float jumpVelocity = 20;

	private float deadLine = -9;


	// Use this for initialization
	void Start () {
		this.animator = GetComponent<Animator> ();

		this.righd2D = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		this.animator.SetFloat ("Horizontal", 1);

		bool isGround = (transform.position.y > this.groundLevel) ? false : true;
		this.animator.SetBool ("isGround", isGround);

		GetComponent<AudioSource> ().volume = (isGround) ? 1 : 0;


		if (Input.GetMouseButtonDown (0) && isGround) {
			this.righd2D.velocity = new Vector2 (0, this.jumpVelocity);
		}

		if (Input.GetMouseButton (0) == false) {
			if (this.righd2D.velocity.y > 0) {
				this.righd2D.velocity *= this.dump;
			}
		}

		if (transform.position.x < this.deadLine) {
			GameObject.Find ("Canvas").GetComponent<UIController> ().GameOver ();

			Destroy (gameObject);
		}

	}
}
