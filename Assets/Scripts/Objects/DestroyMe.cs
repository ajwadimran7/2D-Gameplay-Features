using UnityEngine;
using System.Collections;

public class DestroyMe : MonoBehaviour {

	public float time;

	void Start () {
		Destroy (this.gameObject, time);
	}
}
