using UnityEngine;
using System.Collections;

public class BasicUnitMovement : MonoBehaviour
{
	public float moveSpeed = 1.0f;
	public float goalRadius = 0.1f;
	private GameObject goal;
	
	void Start()
	{
		goal = gameObject.GetComponent<CurrentNode>().currentNode;
	}
	
	public void MoveOrder(GameObject newGoal)
	{
		goal = newGoal;
		gameObject.GetComponent<NavAgent>().setObjective(newGoal);
		gameObject.GetComponent<NavAgent>().ifGivenGoal = true;
	}
	
	void Update()
	{
		
	
		
		
		
		
	}
}
