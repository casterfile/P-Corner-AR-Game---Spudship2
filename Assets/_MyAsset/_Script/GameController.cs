using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	private GameObject NoMarker;
	public static bool isNoMarker;
	// Use this for initialization
	void Start () {
		NoMarker = GameObject.Find ("NotActivated");
	}
	
	// Update is called once per frame
	void Update () {
		if (isNoMarker == true) {
			NoMarker.SetActive(false);
		} else {
			NoMarker.SetActive(true);
		}
	}
}
