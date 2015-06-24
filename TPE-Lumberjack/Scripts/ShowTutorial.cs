using UnityEngine;
using System.Collections;

public class ShowTutorial : MonoBehaviour {

	private bool alreadyShown = false;

	public GameObject tutorialPanel;

	public int showingTime = 5;

	private static GameObject lastTutorial;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Example() {
		if (lastTutorial != null) {
			lastTutorial.SetActive(false);
		}
		lastTutorial = tutorialPanel;
		tutorialPanel.SetActive(true);
		yield return new WaitForSeconds(showingTime);
		tutorialPanel.SetActive(false);
		lastTutorial = null;
	}

	void OnTriggerEnter(Collider collider) {
		if (!alreadyShown && collider.tag.Equals("Palm")) {
			alreadyShown = true;
			StartCoroutine(Example());
		}

	}
}
