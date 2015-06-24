using UnityEngine;
using System.Collections;
using Leap;

public class Creator : MonoBehaviour {

	private Controller controller;
	public GameObject woodTypeA;
	public GameObject woodTypeB;

	// Use this for initialization
	void Start () {
		controller = new Controller ();
		controller.EnableGesture (Gesture.GestureType.TYPE_CIRCLE);
		controller.EnableGesture (Gesture.GestureType.TYPE_KEY_TAP);
		controller.EnableGesture (Gesture.GestureType.TYPE_SCREEN_TAP);
		controller.EnableGesture (Gesture.GestureType.TYPE_SWIPE);
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame ();
		// Get gestures
		GestureList gestures = frame.Gestures ();
		for (int i = 0; i < gestures.Count; i++) {
			Gesture gesture = gestures [i];
			switch (gesture.Type) {
			case Gesture.GestureType.TYPE_CIRCLE:
				CircleGesture circle = new CircleGesture (gesture);
				Object wood;
				if (circle.Pointable.Direction.AngleTo (circle.Normal) <= 3.14 / 2) {
					//Clockwise if angle is less than 90 degrees
					wood = Object.Instantiate (woodTypeA, new Vector3(0, 10, -3), new Quaternion ());
					((GameObject) wood).GetComponent<Rigidbody>().isKinematic = false;
//					GameObject instance = Instantiate(Resources.Load("Assets/Sphere", typeof(GameObject))) as GameObject;
//					instance.transform.position = new Vector3(0, 10, -3);
				} else {
					wood = Object.Instantiate (woodTypeB, new Vector3(0, 10, -3), new Quaternion ());
					((GameObject) wood).GetComponent<Rigidbody>().isKinematic = false;
//					GameObject instance = Instantiate(Resources.Load("Assets/Cube", typeof(GameObject))) as GameObject;
//					instance.transform.position = new Vector3(0, 10, -3);
				}
				break;
			case Gesture.GestureType.TYPE_SWIPE:
//				SwipeGesture swipe = new SwipeGesture (gesture);
//				Object cube = Object.Instantiate(GameObject.Find("Cube"), new Vector3(0, 10, -3), new Quaternion());
				break;
			case Gesture.GestureType.TYPE_KEY_TAP:
//				KeyTapGesture keytap = new KeyTapGesture (gesture);
				break;
			case Gesture.GestureType.TYPE_SCREEN_TAP:
//				ScreenTapGesture screentap = new ScreenTapGesture (gesture);
				break;
			default:
				Debug.Log ("  Unknown gesture type.");
				break;
			}
		}
	}
}
