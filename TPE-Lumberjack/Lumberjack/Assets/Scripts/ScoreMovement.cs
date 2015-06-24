using UnityEngine;
using System.Collections;

public class ScoreMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(2 * transform.position - Camera.main.transform.position);
	}
}
