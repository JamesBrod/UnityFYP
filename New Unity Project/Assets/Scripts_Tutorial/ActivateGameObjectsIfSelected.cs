using UnityEngine;
using System.Collections;

public class ActivateGameObjectsIfSelected : MonoBehaviour
{
	
	public GameObject[] objectsToActivate;
	
	private UnitManager unitManager;

	// Use this for initialization
	void Start () 
	{
		GameObject unitManagerObject = GameObject.FindGameObjectWithTag("PlayerUnitManager");
		unitManager = unitManagerObject.GetComponent<UnitManager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(unitManager.IsSelected(gameObject))
		{
			foreach(GameObject obj in objectsToActivate)
			{
				obj.SetActiveRecursively(true);
			}
		}
		else
		{
			foreach(GameObject obj in objectsToActivate)
			{
				obj.SetActiveRecursively(false);
			}
		}
	}
}
