using UnityEngine;
using System.Collections;

public class CoverNode : MonoBehaviour 
{
	bool isUsed = false;
	
	public void setUsedTrue()
	{
		isUsed = true;
	}
	
	public void setUsedFalse()
	{
		isUsed = false;
	}
}
