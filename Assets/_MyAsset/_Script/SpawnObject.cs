using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

using System.Security.Cryptography;
using System.Text;

public class SpawnObject : MonoBehaviour {
	//	public Transform prefab;
	public GameObject prefab1,prefab2,prefab3;
	int ranData;
//	public Transform parentOfHint;
	// Use this for initialization
	void Start () {
		

		InvokeRepeating("fallingObject", 2f, 2f);

	}

	private void fallingObject(){
		ranData = Random.Range(0, 3);

		if(ranData == 0){
			GameObject instantiatedHint = Instantiate(prefab1, transform.position, Quaternion.identity);
			instantiatedHint.transform.parent = transform;
		}

		if(ranData == 1){
			GameObject instantiatedHint = Instantiate(prefab2, transform.position, Quaternion.identity);
			instantiatedHint.transform.parent = transform;
		}

		if(ranData == 2){
			GameObject instantiatedHint = Instantiate(prefab3, transform.position, Quaternion.identity);
			instantiatedHint.transform.parent = transform;
		}

	}


}


