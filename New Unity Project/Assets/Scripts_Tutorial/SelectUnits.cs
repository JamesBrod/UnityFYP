using UnityEngine;
using System.Collections;

public class SelectUnits : MonoBehaviour
{
	private UnitManager unitManager;
	
	void Start()
	{
		GameObject unitManagerObject = GameObject.FindGameObjectWithTag("PlayerUnitManager");
		unitManager = unitManagerObject.GetComponent<UnitManager>();
	}
	
	void Clicked()
	{
		if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			unitManager.SelectAdditionalUnit(gameObject);
		}
		else
		{
			unitManager.SelectSingleUnit(gameObject);
		}
	}
}
