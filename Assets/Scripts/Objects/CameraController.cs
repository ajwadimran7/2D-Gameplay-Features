using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float speed;

	private Transform _target;

	void Start() {
		EventHandler ();
	}

	void Update () {
		if (_target) {
			Vector3 newPosition = Vector3.Lerp (transform.position, _target.position, speed * Time.deltaTime);
			transform.position = new Vector3 (newPosition.x, newPosition.y, transform.position.z);
			//transform.position = Vector2.Lerp (transform.position, _target.position, speed * Time.deltaTime);
		}
	}

	void AssignTarget(GameObject Player) {
		_target = Player.transform;
	}

	void EventHandler() {
		EventManager.Instance.OnAssignPlayer.AddListener (AssignTarget);
	}
}
