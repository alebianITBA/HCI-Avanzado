using UnityEngine;
using System.Collections;
using Leap;

public class HideIntro : MonoBehaviour {

	public GameObject countdownPanel;

	private Controller controller;
	// Use this for initialization
	void Start () {
		controller = new Controller ();
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame ();
		if (frame.Hands != null && !frame.Hands.IsEmpty) {
			this.gameObject.SetActive(false);
			countdownPanel.SetActive(true);
		}
	}
}
