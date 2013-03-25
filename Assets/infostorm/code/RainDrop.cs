using UnityEngine;
using System.Collections;

public class RainDrop : MonoBehaviour
	{
	// CLASS VARIABLES ===========================
	private static float filterCoolDownTimer;

	// MEMBER VARIABLES ==========================
	private bool hasBeenFiltered = false;

	void Start()
		{
		gameObject.GetComponent<TextMesh>().text = RainCreator.tweets[Random.Range(0, RainCreator.tweets.Length)];
		}

	void Update()
		{
		if (!hasBeenFiltered)
			transform.Translate(0.5f, 0f, 0f);
		else
			transform.Translate(0.0f, -0.1f, 0.0f);
		if (transform.position.y < -10)
			Destroy(gameObject);
		}

	public void getFiltered()
		{
		if (!hasBeenFiltered)
			{
			if (Time.time > filterCoolDownTimer)
				{
				transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
				transform.position = RainDestroyerObject.current.transform.position;
				hasBeenFiltered = true;
				Destroy(gameObject.GetComponent<Collider>());
				Destroy(gameObject, 3.0f);
				filterCoolDownTimer = Time.time + 1.0f;
				}
			else
				Destroy(gameObject);
			}
		}
	}
