using UnityEngine;
using System.Collections;

public class ProjectileDamage: MonoBehaviour
{
	public string[] annihilationTags;

	void OnCollisionEnter(Collision collision)
	{
		foreach(string tag in annihilationTags)
		{
			if(collision.collider.tag == tag)
			{
				Destroy(collision.gameObject);
				return;
			}
		}
	}
}
