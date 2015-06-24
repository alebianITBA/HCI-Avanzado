using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public int score = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collider) {
		if (!collider.tag.Equals ("Cube") && !collider.tag.Equals("Sphere")) {
			return;
		}
		if (gameObject.CompareTag (collider.tag)) {
			score++;
		} else {
			score--;
		}
		TextMesh text;
		if (gameObject.tag.Equals ("Cube")) {
			text = GameObject.Find ("CubeScore").GetComponent<TextMesh> ();
		} else {
			text = GameObject.Find ("SphereScore").GetComponent<TextMesh> ();
		}
		text.text = score.ToString ();
		collider.gameObject.SetActive (false);
	}
}
