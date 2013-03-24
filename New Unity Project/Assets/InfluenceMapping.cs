using UnityEngine;
using System.Collections;

public class InfluenceMapping : MonoBehaviour 
{
	
	public Collider[] nodesToBeInfluencedNear;
	public Collider[] nodesToBeInfluencedMedium;
	public Collider[] nodesToBeInfluencedFar;
	public GameObject[] allNodes;
	public int count = 0;
	
	
	

	
	
	// Use this for initialization
	void Start () 
	{
		 nodesToBeInfluencedNear = Physics.OverlapSphere(transform.position, 3f);
		 nodesToBeInfluencedMedium = Physics.OverlapSphere(transform.position, 5f);
		 nodesToBeInfluencedFar = Physics.OverlapSphere(transform.position, 7f);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		nodesToBeInfluencedNear = Physics.OverlapSphere(transform.position, 3f);
		nodesToBeInfluencedMedium = Physics.OverlapSphere(transform.position, 5f);
		nodesToBeInfluencedFar = Physics.OverlapSphere(transform.position, 7f);
		
		foreach(Collider col in nodesToBeInfluencedFar)
		{
			if(col.gameObject.CompareTag("Node"))
			{
				if(col.gameObject.GetComponent<Node>().cost < 36 && col.gameObject.GetComponent<Node>().cost < 24)
				{
					col.gameObject.GetComponent<Node>().cost = 16;
				}
			}
		}
		
		foreach(Collider col in nodesToBeInfluencedMedium)
		{
			if(col.gameObject.CompareTag("Node"))
			{
				if(col.gameObject.GetComponent<Node>().cost < 36)
				{
				col.gameObject.GetComponent<Node>().cost = 24;
				}
			}
		}
		
		foreach(Collider col in nodesToBeInfluencedNear)
		{
			if(col.gameObject.CompareTag("Node"))
			{
				col.gameObject.GetComponent<Node>().cost = 36;
				
			}
		}
		
		if(count > 20)
		{
			
			allNodes = GameObject.FindGameObjectsWithTag("Node");
			
			foreach(GameObject col in allNodes)
			{
				col.GetComponent<Node>().cost = 1;
			}
			count = 0;
		//	Debug.Log("Cleared");
			
		}
		else
		{
			count++;
		}
		
	
	}
}
