using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour {

	public float speed = 3f;

	public float radiusToCheckRocks = 5f;
	public LayerMask whatIsRockLayer;
	public Transform rockPosition;
	public Transform rockParentOrg;

	public GameObject rockBullet;
	public float bulletSpeed;

	private Rigidbody2D _rigidBody;

	private GameObject _rock;

	private bool _currentlyHoldingARock = false;

	void Start () {
		_rigidBody = GetComponent<Rigidbody2D> ();
		EventManager.Instance.OnAssignPlayer.Invoke (this.gameObject);
	}

	public void Move(float inputX) {

		if (inputX > 0f) {
			transform.localScale = new Vector3 (1f, 2f, 1f);
		} else if (inputX < 0f) {
			transform.localScale = new Vector3 (-1f, 2f, 1f);
		}

		_rigidBody.velocity = new Vector2 (inputX *  speed * Time.deltaTime ,0f);

	}

	public void Pick() {
		
		if (ScanFor_rocks () && !_currentlyHoldingARock) {
			Destroy (_rock.GetComponent<Rigidbody2D> ());
			_rock.transform.parent = rockPosition;
			_rock.transform.position = rockPosition.position;
			_currentlyHoldingARock = true;
		}

	}

	bool ScanFor_rocks() {
		
		Collider2D col = Physics2D.OverlapCircle (transform.position, radiusToCheckRocks, whatIsRockLayer);

		if (col) {
			_rock = col.gameObject;
			return true;
		}
		return false;
	}

	public void Drop() {
		if (_currentlyHoldingARock) {
			_rock.transform.parent = rockParentOrg;
			_rock.AddComponent<Rigidbody2D> ();
			_currentlyHoldingARock = false;
		}
	}

	public void Fire() {
		if (!_currentlyHoldingARock) {
			GameObject bullet = Instantiate (rockBullet, rockPosition.position, Quaternion.identity) as GameObject;
			bullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * bulletSpeed * transform.localScale.x);
			bullet.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * bulletSpeed / 2f);
		}
	}
}
