using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

public class EventManager : MonoBehaviour {

	public static EventManager Instance;

	public GameObjectEvent OnAssignPlayer;

	void Awake () {
		Instance = this;
	}
}

[Serializable]
public class GameObjectEvent : UnityEvent<GameObject> {
	
}
