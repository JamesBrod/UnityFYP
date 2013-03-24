using UnityEngine;
using System.Collections;

public class SetEnemyGoal : MonoBehaviour
{
	public GameObject currentNode;
	public bool  IsAi =true;
	
	// Use this for initialization
	void Start ()
	{
		float shortestDistance = Mathf.Infinity;
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Node"))
		{
			float dist = (obj.transform.position - transform.position).magnitude;
			if(dist < shortestDistance)
			{
				shortestDistance = dist;
				currentNode = obj;
			}
		}
		SetCurrentNode();
	}
	
	void SetCurrentNode()
	{
		float shortestDistance = Mathf.Infinity;
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Node"))
		{
			float dist = (obj.transform.position - transform.position).magnitude;
			if(dist < shortestDistance)
			{
				shortestDistance = dist;
				currentNode = obj;
			}
		}
		//currentNode.GetComponent<Node>().tag = "EnemyGoal";
	}
	
	
	
	
}
