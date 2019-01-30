using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	private PlayerController _player;

	void Start() {
		EventHandler ();
	}

	void Update () {

		if (_player) {

			if (Input.GetAxis ("Horizontal") > 0f || Input.GetAxis ("Horizontal") < 0f) {
				_player.Move (Input.GetAxis ("Horizontal"));
			}

			if (Input.GetButtonDown ("Pick")) {
				_player.Pick ();
			}

			if (Input.GetButtonDown ("Drop")) {
				_player.Drop ();
			}

			if (Input.GetButtonDown ("Fire")) {
				_player.Fire ();
			}
		}

	}

	void AssignPlayer(GameObject Player) {
		if (Player.GetComponent<PlayerController> ()) {
			_player = Player.GetComponent<PlayerController> ();
		}
	}

	void EventHandler() {
		EventManager.Instance.OnAssignPlayer.AddListener (AssignPlayer);
	}
}
