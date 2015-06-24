using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using Leap;

public class UpdateLeaderboard : MonoBehaviour {

	public string playerName;

	private static int maxNameLength = 10;
	private Controller controller;

	// Use this for initialization
	void Start () {
		controller = new Controller ();
		controller.EnableGesture (Gesture.GestureType.TYPE_CIRCLE);
	}
	
	// Update is called once per frame
	void Update () {
		if (playerName != null) {
			int score = 0;
			score += GameObject.Find("CubeBox").GetComponentInChildren<Goal>().score;
			score += GameObject.Find("SphereBox").GetComponentInChildren<Goal>().score;
			saveScore(playerName, score);
			printLeaderboard();
			playerName = null;
		}

		// Get gestures
		Frame frame = controller.Frame ();
		GestureList gestures = frame.Gestures ();
		for (int i = 0; i < gestures.Count; i++) {
			Gesture gesture = gestures [i];
			if (gesture.Type == Gesture.GestureType.TYPE_CIRCLE) {
				Application.LoadLevel(Application.loadedLevel);
				break;
			}
		}
	}

	private void saveScore(string player, int score) {
		player = player.Trim();
		if (!PlayerPrefs.HasKey (player)) {
			int i = 1;
			while (PlayerPrefs.HasKey(i.ToString())) {
				i++;
			}
			PlayerPrefs.SetString(i.ToString(), player);
			PlayerPrefs.SetInt(player, 0);
		}
		if (score > PlayerPrefs.GetInt(player)) {
			PlayerPrefs.SetInt(player, score);
		}
	}

	private void printLeaderboard() {
		Text text = GetComponentInChildren<Text>();
		text.text = "LEADERBOARD\n\n";
		ArrayList leaderBoard = new ArrayList();
		int k = 1;
		while (PlayerPrefs.HasKey(k.ToString())) {
			string player = PlayerPrefs.GetString(k.ToString());
			int score = PlayerPrefs.GetInt(player);
			leaderBoard.Add(new PlayerScore(player, score));
			k++;
		}
		leaderBoard.Sort ();
		for(int i = 0; i < 5; i++) {
			if(PlayerPrefs.HasKey((i+1).ToString())) {
				PlayerScore player = (PlayerScore)leaderBoard[i];
				int spaces = player.getPlayerName().Length;
				string playerName = player.getPlayerName();
				if(spaces < maxNameLength) {
					for(int j = 0; j < maxNameLength - spaces; j++) {
						playerName += " ";
					}
				}
				string score;
				if(player.getScore() < 10) {
					score = "0" + player.getScore().ToString();
				} else {
					score = player.getScore().ToString();
				}
				text.text += (i+1).ToString() + ". " + playerName.Substring(0,10) + " " + score + "\n";
			}
		}
		text.text += "\nMake a circle with your finger to play again.";
	}

	public class PlayerScore : IComparable {
		private int score;
		private string playerName;

		public PlayerScore(string playerName, int score) {
			this.score = score;
			this.playerName = playerName;
		}

		public int CompareTo(System.Object obj) {
			return ((PlayerScore) obj).score - score;
		}

		public int getScore() {
			return score;
		}

		public string getPlayerName() {
			return playerName;
		}
	}

}
