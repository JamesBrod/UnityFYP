using UnityEngine;
using System.Collections;

public class DestroyWhenFinished : MonoBehaviour
{
	void Update ()
	{
		if(!particleSystem.isPlaying)
		{
			Destroy(gameObject);
		}
	}
}
