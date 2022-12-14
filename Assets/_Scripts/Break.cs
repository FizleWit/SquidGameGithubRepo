﻿using UnityEngine;
using System.Collections;

public class Break : MonoBehaviour 
{
	public Transform brokenObject;
	public float magnitudeCol, radius, power, upwards;
	public AudioClip ShatterSound;
	public float volume;
	public AudioSource	audioListenerCamera;

	void Start()
	{
	//audioListenerCamera = GetComponent<"Audio Listener">();
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log(collision.relativeVelocity.magnitude);
		if (collision.relativeVelocity.magnitude > magnitudeCol)
		{
			Destroy(gameObject);
			Instantiate(brokenObject, transform.position, transform.rotation);
			brokenObject.localScale = transform.localScale;
			Vector3 explosionPos = transform.position;
			Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);

			foreach (Collider hit in colliders)
			{
				if (hit.GetComponent<Rigidbody>())
				{
					hit.GetComponent<Rigidbody>().AddExplosionForce(power*collision.relativeVelocity.magnitude, explosionPos, radius, upwards);
				}
			}
			audioListenerCamera.PlayOneShot(ShatterSound, volume);
		}
	}
}
