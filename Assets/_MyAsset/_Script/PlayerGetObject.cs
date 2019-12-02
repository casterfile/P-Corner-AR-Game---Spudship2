using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetObject : MonoBehaviour {
	GameObject Catch01,Catch02,Catch03;
	bool isCatch;
	// Use this for initialization
	void Start () {
		Catch01 = GameObject.Find ("Catch0 (1)");
		Catch02 = GameObject.Find ("Catch0 (2)");
		Catch03 = GameObject.Find ("Catch0 (3)");

		isCatch = false;


		Catch01.SetActive (false);
		Catch02.SetActive (false);
		Catch03.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(isCatch == false){
			if (col.gameObject.tag == "Item0 (1)") {
				Destroy(col.gameObject);
				StartCoroutine(FuncCatch(3,1));
			}
			if (col.gameObject.tag == "Item0 (2)") {
				Destroy(col.gameObject);
				StartCoroutine(FuncCatch(3,2));
			}
			if (col.gameObject.tag == "Item0 (3)") {
				Destroy(col.gameObject);
				StartCoroutine(FuncCatch(3,3));
			}
		}

	}

	IEnumerator FuncCatch(float time, int Object)
	{
		isCatch = true;
		Catch01.SetActive (false);
		Catch02.SetActive (false);
		Catch03.SetActive (false);

		if(Object == 1){
			Catch01.SetActive (true);
		}
		if(Object == 2){
			Catch02.SetActive (true);
		}
		if(Object == 3){
			Catch03.SetActive (true);
		}
		yield return new WaitForSeconds(time);
		isCatch = false;
		Catch01.SetActive (false);
		Catch02.SetActive (false);
		Catch03.SetActive (false);
	}
}
