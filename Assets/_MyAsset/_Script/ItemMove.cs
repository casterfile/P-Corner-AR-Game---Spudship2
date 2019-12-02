using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMove : MonoBehaviour {
	private Transform ItemTargetStart, ItemTargetEnd;

	private float speed = 60;
	private float resize = 100;
	private float TotalSpeed, TotalSpeedTemp;
	float stepGoingBack,step;
	// Use this for initialization
	void Start () {
		ItemTargetStart = GameObject.Find ("ItemTargetStart").GetComponent<Transform>();


		transform.position = new Vector2(ItemTargetStart.position.x, ItemTargetStart.position.y);
		TotalSpeed = (Screen.width / 300.0f) * speed;
		TotalSpeedTemp = TotalSpeed;

		int ranData = Random.Range(0, 3);
		if(ranData == 1){
			ItemTargetEnd = GameObject.Find ("ItemTargetEnd1").GetComponent<Transform>();
		}else if(ranData == 2){
			ItemTargetEnd = GameObject.Find ("ItemTargetEnd2").GetComponent<Transform>();
		}else{
			ItemTargetEnd = GameObject.Find ("ItemTargetEnd3").GetComponent<Transform>();
		}

	}
	
	// Update is called once per frame
	void Update () {
		TotalSpeed =  TotalSpeedTemp; //(GameController.ScoreCount * 10) +
		step = TotalSpeed * Time.deltaTime;
		stepGoingBack = TotalSpeedTemp * Time.deltaTime;

		transform.position = Vector3.MoveTowards(transform.position, ItemTargetEnd.position, step);
	}


}
