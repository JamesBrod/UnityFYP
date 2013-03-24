

using UnityEngine;
using System.Collections;

public class DetectClicksAndTouches : MonoBehaviour
{	
	
	
	
	public bool debug = true;
	

	private Camera _camera;
	
	void Start()
	{
	
			_camera = Camera.main;
		
	}
	

	void Update ()
	{
		Ray ray;
		RaycastHit hit;
	
		
		
			if(Input.GetMouseButtonDown(0)) //LeftClick
			{
				
				ray = _camera.ScreenPointToRay(Input.mousePosition); 
				
				
				if(Physics.Raycast (ray, out hit, Mathf.Infinity))
				{
					
					if(debug)
					{
						Debug.Log("You clicked " + hit.collider.gameObject.name,hit.collider.gameObject);
					}
					hit.transform.gameObject.SendMessage("Clicked", hit.point, SendMessageOptions.DontRequireReceiver);
				}			
			}
			
			if(Input.GetMouseButtonDown(1))  //RightClick
			{
				
				ray = _camera.ScreenPointToRay(Input.mousePosition); 
			
				
				
				
				
				
				
				if(Physics.Raycast (ray, out hit, Mathf.Infinity))
				{
					Vector3 target = hit.point;
					Collider[] col = Physics.OverlapSphere(target, 2);
					
					GameObject closestNode = col[1].gameObject;
					float closestDis = Mathf.Infinity;
					Vector3 test;
				
					foreach(Collider coll in col)
					{
						if(coll.gameObject.CompareTag("Node"))
						{
							test = coll.gameObject.transform.position - target;
							float dis = test.sqrMagnitude;
							
							if(dis < closestDis)
							{
								closestNode = coll.gameObject;
							}
						}
					}
					
						
					if(debug)
					{
						Debug.Log("You right clicked " + hit.collider.gameObject.name,hit.collider.gameObject);
					}
					
					hit.transform.gameObject.SendMessage("RightClicked", closestNode, SendMessageOptions.DontRequireReceiver);
				}			
			}
		
	}
}
