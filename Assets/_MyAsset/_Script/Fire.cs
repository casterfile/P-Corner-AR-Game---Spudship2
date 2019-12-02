using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {



	void Start(){
		
	}
	void Update() {
		transform.position += new Vector3 (28, 0, 0);
//		print ("CountScore: "+ CharacterController.CountScore);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			CharacterController.CountScore++;
			Destroy(col.gameObject);
			Destroy(gameObject);
		}

		if(col.gameObject.tag == "FireEnd")
		{
			Destroy(gameObject);
		}
	}
}
