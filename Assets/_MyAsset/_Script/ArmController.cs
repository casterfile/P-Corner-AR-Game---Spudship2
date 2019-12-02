using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour {
	private Transform ObjectArm, target_Start,target_Left,target_Right, target_UpDown,target_GetObject;

	private float speed = 60;
	private float resize = 100;
	private float TotalSpeed, TotalSpeedTemp;
	float stepGoingBack,step;
	public static bool isLeft, isRight, isDownUp,isNoMarker;
	private GameObject NoMarker;
	Vector3 newYPos;
	private Animator ArmAnimator;
	private string TempBoolName;

	// Use this for initialization
	void Start () {

		ObjectArm = GameObject.Find ("Crane").GetComponent<Transform>();
		target_Start = GameObject.Find ("target_Start").GetComponent<Transform>();
		target_Left = GameObject.Find ("target_Left").GetComponent<Transform>();
		target_Right = GameObject.Find ("target_Right").GetComponent<Transform>();
		target_UpDown = GameObject.Find ("target_UpDown").GetComponent<Transform>();
		target_GetObject = GameObject.Find ("target_GetObject").GetComponent<Transform>();


		ArmAnimator = GameObject.Find ("Crane").GetComponent<Animator>();

		NoMarker = GameObject.Find ("NotActivated");
		isLeft = false;
		isRight = false;
		isDownUp = false;

		ObjectArm.position = new Vector2(ObjectArm.position.x, target_Start.position.y);

		TotalSpeed = (Screen.width / 200.0f) * speed;
		TotalSpeedTemp = TotalSpeed;
		isLeft = true;
	}
	
	// Update is called once per frame
	void Update () {
		TotalSpeed =  TotalSpeedTemp; //(GameController.ScoreCount * 10) +
		step = TotalSpeed * Time.deltaTime;
		stepGoingBack = TotalSpeedTemp * Time.deltaTime;

		if (isNoMarker == true) {
			NoMarker.SetActive(false);
		} else {
			NoMarker.SetActive(true);
		}

		if(isDownUp == false){
			if(isLeft == true){
				if(ObjectArm.position == target_Left.position){
					isLeft = false;
					isRight = true;
				}
				ObjectArm.position = Vector3.MoveTowards(ObjectArm.position, target_Left.position, step);
			}
			else if(isRight == true){
				if(ObjectArm.position == target_Right.position){
					isLeft = true;
					isRight = false;
				}
				ObjectArm.position = Vector3.MoveTowards(ObjectArm.position, target_Right.position, step);
			}
		}

		if (isDownUp == true) {
			ArmAnimator.SetBool("isCraneOn", true);
			if(isLeft = true){
				TempBoolName = "isLeft";
			}
			if(isRight = true){
				TempBoolName = "isRight";
			}
			isLeft = false;
			isRight = false;
			StartCoroutine(FuncDownUp(2));
		}
	}

	IEnumerator FuncDownUp(float time)
	{
		ObjectArm.position = Vector3.MoveTowards (ObjectArm.position, new Vector3(ObjectArm.position.x,target_UpDown.position.y,ObjectArm.position.z), step);
		yield return new WaitForSeconds(time);
		ObjectArm.position = Vector3.MoveTowards (ObjectArm.position, new Vector3(ObjectArm.position.x,target_GetObject.position.y,ObjectArm.position.z), step);

		StartCoroutine(FuncGetObject(2));
	}

	IEnumerator FuncGetObject(float time)
	{
		isDownUp = false;
		yield return new WaitForSeconds(time);
		ArmAnimator.SetBool("isCraneOn", false);
		ObjectArm.position = Vector3.MoveTowards (ObjectArm.position, new Vector3(ObjectArm.position.x,target_GetObject.position.y,ObjectArm.position.z), step);

		if (TempBoolName == "isRight") {
			isRight = true;
			isLeft = false;
		}
		else if (TempBoolName == "isLeft") {
			isRight = false;
			isLeft = true;
		}
	}

	public void FuncBTNController(string NameControll){
		if(NameControll == "left"){
			isLeft = true;
		}
		if(NameControll == "right"){
			isRight = true;
		}
		if(NameControll == "down"){
			isDownUp = true;
		}
	}

	public void FuncBTNControllerExit(string NameControll){
		if(NameControll == "left"){
			isLeft = false;
		}
		if(NameControll == "right"){
			isRight = false;
		}

	}


}
