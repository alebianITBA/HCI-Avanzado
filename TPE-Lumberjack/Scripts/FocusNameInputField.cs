using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FocusNameInputField : MonoBehaviour {

	private InputField input;
	public GameObject leaderboardPanel;

	// Use this for initialization
	void Start () {
		input = gameObject.GetComponentsInChildren<InputField>()[0];
		input.ActivateInputField();
		input.onEndEdit.AddListener (OnSubmit);
		input.Select();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnSubmit(string s) {
		leaderboardPanel.SetActive (true);
		leaderboardPanel.GetComponent<UpdateLeaderboard> ().playerName = s;
		gameObject.SetActive(false);
	}

}
