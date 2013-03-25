using UnityEngine;
using System.Collections;

public class RainDestroyerObject : MonoBehaviour
	{
	// CLASS VARIABLES ===============================
	public static RainDestroyerObject current;

	// MEMBER VARIABLES ==============================
	public Transform arMarker;
	public Transform colliderObject;

	void Start()
		{
		current = this;
		}

	void Update()
		{
		if (arMarker.position.y == 1000)
			{
			transform.position = new Vector3(0, 100, 20f);
			}
		else
			{
			Vector3 newPosition = Vector3.zero;
			float correction = arMarker.position.z / 20;
			colliderObject.localScale = new Vector3(150 / correction, 150 / correction, 5f);
			newPosition.x = arMarker.position.x / correction;
			newPosition.y = arMarker.position.y / correction;
			newPosition.z = 20f;
			transform.position = newPosition;
			}
		}
	}
