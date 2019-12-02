using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

	public Transform target, target_Start;
	public GameObject FireObject,ParentFire;
	private Transform LocationReset;
    private float speed = 60;
    private float resize = 100;
    private float TotalSpeed, TotalSpeedTemp;
    private bool isTargetEnd = false;
    float stepGoingBack,step;
	public static int CountScore = 0;
	public static bool isFire = false,isFire2 = false;
	private GameObject Score1, Score2, Score3;

    void Start(){
		Score1 = GameObject.Find ("Score1");
		Score2 = GameObject.Find ("Score2");
		Score3 = GameObject.Find ("Score3");

		CountScore = 0;
		isFire = false;
		isFire2 = true;
		Score1.SetActive (false);
		Score2.SetActive (false);
		Score3.SetActive (false);

		isTargetEnd = true;
    	TotalSpeed = (Screen.width / 200.0f) * speed;
    	TotalSpeedTemp = TotalSpeed;
    }

    void FixedUpdate() {
        TotalSpeed =  TotalSpeedTemp; 
        step = TotalSpeed * Time.deltaTime;
        stepGoingBack = TotalSpeedTemp * Time.deltaTime;
//		if(transform.position.y <= target.position.y){
//           isTargetEnd = true;
//        }
//		else if(transform.position.y >= target_Start.position.y){
//           isTargetEnd = false;
//        }

        if(isTargetEnd == false){
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }else{
             transform.position = Vector3.MoveTowards(transform.position, target_Start.position, step);
        }

		if (CountScore >= 5 && CountScore < 9) {
			Score1.SetActive (true);
			Score2.SetActive (false);
			Score3.SetActive (false);
		}else if (CountScore >= 10 && CountScore < 14) {
			Score1.SetActive (true);
			Score2.SetActive (true);
			Score3.SetActive (false);
		}else if (CountScore >= 15) {
			Score1.SetActive (true);
			Score2.SetActive (true);
			Score3.SetActive (true);
		}

		if(isFire == true){
			if(isFire2 == true){
				StartCoroutine(FuncDownUp(0.7f));
			}
		}
    }

	public void PlayerFire(){
		isFire = true;
	}

	private void Fire(){
		GameObject instantiatedHint = Instantiate(FireObject, transform.position, Quaternion.identity);
		instantiatedHint.transform.parent = ParentFire.transform;
	}

	IEnumerator FuncDownUp(float time)
	{
		isFire2 = false;
		yield return new WaitForSeconds(time);
		Fire ();
		isFire2 = true;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "PlayerBorder")
		{
			isTargetEnd = !isTargetEnd;
		}
//
//		if(col.gameObject.tag == "PlayerBorder2")
//		{
//			isTargetEnd = true;
//		}
	}
}
