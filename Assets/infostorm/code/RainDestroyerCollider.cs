using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class RainDestroyerCollider : MonoBehaviour {

	void OnTriggerStay(Collider other)
		{
		if (other.tag == "RainDrop")
			other.GetComponent<RainDrop>().getFiltered();
			//Destroy(other.gameObject);
		}
}
