using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour {

	public Transform target, target_Start;
	private Transform LocationReset;
    private float speed = 60;
    private float resize = 100;
    private float TotalSpeed, TotalSpeedTemp;

    float stepGoingBack,step;
    void Start(){
    	TotalSpeed = (Screen.width / 200.0f) * speed;
    	TotalSpeedTemp = TotalSpeed;
    }

    void FixedUpdate() {
        TotalSpeed =  TotalSpeedTemp; 
        step = TotalSpeed * Time.deltaTime;
        stepGoingBack = TotalSpeedTemp * Time.deltaTime;
		float target_position = target.position.x;
		float transform_position = transform.position.x;

		if(transform_position <= target_position){
           //transform.position = new Vector2(target_Start.position.x, target_Start.position.y);
        }
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "BackgroundScreenEnd")
		{
			transform.position = new Vector2(target_Start.position.x, target_Start.position.y);
			print("WHat the hek");
		}
	}
}
