using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

	public float minutesLeft = 5;
	private float secondsLeft;
	public GameObject gameOverPanel;
	// Use this for initialization
	void Start () {
		secondsLeft = minutesLeft * 60;
	}
	
	// Update is called once per frame
	void Update () {
		secondsLeft -= Time.deltaTime;
		if (secondsLeft >= 0) {
			minutesLeft = secondsLeft / 60;
			int minutes = (int)minutesLeft;
			int seconds = ((int)secondsLeft) % 60;
			gameObject.GetComponentInChildren<Text> ().text = minutes.ToString () + ":" + ((seconds < 10) ? "0" : "") + seconds.ToString ();
		} else {
			gameOverPanel.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
