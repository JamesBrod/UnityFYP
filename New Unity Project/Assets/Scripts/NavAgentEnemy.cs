using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavAgentEnemy : MonoBehaviour
{
	public float speed = 2.0f;
	public float turnSpeed = 60.0f;
	[HideInInspector]
	public GameObject currentNode;
	[HideInInspector]
	public GameObject previousNode;
	[HideInInspector]
	public GameObject ObjectiveCurrentNode;
	[HideInInspector]
	public GameObject ObjectivePreviousNode;
	public bool goalreached = false;
	public bool ifGivenGoal = false;
	
	Stack<GameObject> path = null;
//	int count = 0;
	
	GameObject goal;
	
	Heuristic hr;
	
	public GameObject objectiveNode;
	// Use this for initialization
	void Start ()
	{
		
		objectiveNode = GameObject.FindGameObjectWithTag("EnemyGoal").GetComponent<SetEnemyGoal>().currentNode;
		
		currentNode = gameObject.GetComponent<CurrentNode>().currentNode;
		
		previousNode = gameObject.GetComponent<CurrentNode>().currentNode;
		
		hr = new Heuristic(objectiveNode);
		
		path = new Stack<GameObject>();
	}
	
	
	// Update is called once per frame
	void Update()
	{ 
		if(ifGivenGoal.Equals(true))
		{
		if (goalreached)
		{
			path.Clear ();
			
		}
		else
		{
			if(gameObject.GetComponent<CurrentNode>().currentNode.Equals(objectiveNode))
			{
				goalreached = true;
			}
			if(path.Count == 0)
			{
					
				path = new Stack<GameObject>();
				hr = new Heuristic(objectiveNode);
				path = pathfinderEnemy.AStar(gameObject.GetComponent<CurrentNode>().currentNode,objectiveNode, hr);
				
				try
				{
						
					goal = path.Pop();
				}
				finally
				{
					movement();
				}
				
			}
			else if(currentNode != previousNode)
			{
				try
				{	
					goal = path.Pop();
					
				}
				finally
				{
					currentNode = gameObject.GetComponent<CurrentNode>().currentNode;
					previousNode = gameObject.GetComponent<CurrentNode>().currentNode;
					movement();
				}
			}
			else
			{
				
				movement();
				currentNode = gameObject.GetComponent<CurrentNode>().currentNode;
			}
		}
		}
	}
	
	
	
	public void movement()
	{
		Vector3 goalPosition = goal.transform.position;
		Vector3 goalDirection = goalPosition - transform.position;
		goalDirection.y = 0.0f;
		Vector3 normalizedGoalDirection = goalDirection.normalized;
		transform.position += transform.forward * speed * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(normalizedGoalDirection), turnSpeed*Time.deltaTime);
	}
}