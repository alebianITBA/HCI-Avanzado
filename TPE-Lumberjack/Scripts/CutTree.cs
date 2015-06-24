using UnityEngine;
using System.Collections;
using Leap;

public class CutTree : MonoBehaviour {

	public int woodQuantity = 25;
	public GameObject woodType;
	private Controller controller;
	
	// Use this for initialization
	void Start () {
		controller = new Controller ();
		controller.EnableGesture (Gesture.GestureType.TYPE_SWIPE);
	}
	
	// Update is called once per frame
	void Update () {
		if (woodQuantity <= 0 && transform.rotation.eulerAngles.x < 80) {
			transform.Rotate(Vector3.right, 50 * Time.deltaTime);
		}
	}

	void OnTriggerStay(Collider collider) {
		if (woodQuantity > 0 && collider.tag.Equals("Axe")) {
			Frame frame = controller.Frame ();
			// Get gestures
			GestureList gestures = frame.Gestures ();
			for (int i = 0; i < gestures.Count; i++) {
				Gesture gesture = gestures [i];
				if (gesture.Type == Gesture.GestureType.TYPESWIPE) {
					Object wood = Object.Instantiate (woodType, gameObject.transform.position, new Quaternion ());
					((GameObject) wood).GetComponent<Rigidbody>().isKinematic = false;
					woodQuantity--;
				}
			}
		}
	}
}
