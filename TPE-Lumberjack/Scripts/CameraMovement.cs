using UnityEngine;
using System.Collections;
using Leap;

public class CameraMovement : MonoBehaviour {

	private Controller controller;
	// Use this for initialization
	void Start () {
		controller = new Controller ();
		Physics.gravity = Physics.gravity * 2;
	}
	
	// Update is called once per frame
	void Update () {
		float height = Terrain.activeTerrain.SampleHeight (transform.position);
		transform.position = new Vector3(transform.position.x, height + 8, transform.position.z);
		Frame frame = controller.Frame ();
		foreach (Hand hand in frame.Hands) {
			float z = hand.PalmPosition.z;
			float x = hand.PalmPosition.x;
			bool handUp = z < -120;
			bool handDown = z > 120;
			Vector3 directionXZ = transform.forward;
			directionXZ.y = 0;
			if(handUp) {
				transform.position += directionXZ * Time.deltaTime * 8;
			} else if(handDown){
				transform.position -= directionXZ * Time.deltaTime * 8;
			}
			if(x < -120) {
				transform.Rotate(0, -30 * Time.deltaTime, 0, Space.World);
			} else if(x > 120) {
				transform.Rotate(0, 30 * Time.deltaTime, 0, Space.World);
			}
		}
	}
}
