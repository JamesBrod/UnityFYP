using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pathfinder 
{	

	
	public static Stack<GameObject> AStar(GameObject start, GameObject end, Heuristic heuristic)
	{
		List<GameObject> connections = new List<GameObject>();
		GameObject endNode = start;
		float endNodeCost  = 0f;
		float endNodeHeuristic = 0.0f;
		NodeRecord endNodeRecord = new NodeRecord();
		
		NodeRecord startRecord = new NodeRecord();
		startRecord.node = start;
		startRecord.CostSoFar = 0.0f;
		startRecord.estimatedTotalCost = heuristic.euclideanDistanceEstimate(start);
		
		List<NodeRecord> openList = new List<NodeRecord>();
		List<NodeRecord> closedList = new List<NodeRecord>();
		openList.Add(startRecord);
		
		NodeRecord current = startRecord;
		
		while(openList.Count > 0)
		{
			current = getSmallestElement(openList);
			
			if(current.node.Equals(end))
			{
				break;
			}
			connections = current.node.GetComponent<Node>().connections;
			foreach(GameObject connection in connections)
			{
				endNode = connection.GetComponent<Connection>().toNode;
				endNodeCost = current.CostSoFar+connection.GetComponent<Connection>().playerCost + endNode.GetComponent<Node>().playerCost;
				
				if(isInList(endNode, closedList))
				{
					endNodeRecord = findNodeInList(endNode, closedList);
					
					if(endNodeRecord.CostSoFar <= endNodeCost)
					{
						continue;
					}
					closedList.Remove(endNodeRecord);
					
					endNodeHeuristic = endNodeRecord.estimatedTotalCost - endNodeRecord.CostSoFar;
				}
				else if(isInList(endNode, openList))
				{
					endNodeRecord = findNodeInList(endNode, openList);
					if(endNodeRecord.CostSoFar <= endNodeCost)
					{
						continue;
					}
					endNodeHeuristic = endNodeCost - endNodeRecord.CostSoFar;
				}
				else
				{
					endNodeRecord = new NodeRecord(endNode);
					endNodeHeuristic = heuristic.euclideanDistanceEstimate(endNode);
				}
				endNodeRecord.CostSoFar = endNodeCost;
				endNodeRecord.connection = connection;
				endNodeRecord.estimatedTotalCost = endNodeCost + endNodeHeuristic;
				
				if(!(isInList(endNode, openList)))
				{
					openList.Add(endNodeRecord);
				}
			}
			
			openList.Remove(current);
			closedList.Add(current);
		}
		if(current.node != end)
		{
			return null;
		}
		else
		{
			Stack<GameObject> path = new Stack<GameObject>();
			while(current.node != start)
			{
				path.Push(current.node);
				current = findNodeInList(current.connection.GetComponent<Connection>().fromNode, closedList);
			}
			//path.Reverse();
			return path;
		}
	}
		
	public static NodeRecord getSmallestElement(List<NodeRecord> l)
	{
		if(l.Count == 1)
		{
			foreach(NodeRecord nr in l)
			{
				return nr;
			}
		}
		NodeRecord min = l[0];
		float minCost = min.CostSoFar;
		foreach(NodeRecord nr in l)
		{
			if(minCost > nr.CostSoFar)
			{
				minCost = nr.CostSoFar;
				min = nr;
			}
		}
		//Debug.Log("get Min Node");
		//Debug.Log(min.node);
		return min;
	}
	
	public static NodeRecord findNodeRecordUsingFromNode(GameObject n, List<NodeRecord> l)
	{
		GameObject temp = null;
		foreach(NodeRecord nr in l)
		{
			temp = nr.connection;
			if(temp.GetComponent<Connection>().fromNode.Equals(n))
			{
				return nr;
			}
		}
		return null;
	}
	
	
	public static bool isInList(GameObject n, List<NodeRecord> l)
	{
		foreach(NodeRecord nr in l)
		{
			if(nr.node.Equals(n))
			{
				return true;
			}
		}
		return false;
	}
	
	private static NodeRecord findNodeInList(GameObject n, List<NodeRecord> l)
	{
		foreach(NodeRecord nr in l)
		{
			if(nr.node.Equals(n))
			{
				return nr;
			}
		}
		return null;
	}
	
	private static bool checkIsNodesEqual(GameObject n1, GameObject n2)
	{
		if(n1 == n2)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
}
