using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragObjectCylinder2Gap2 : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public Vector3 resetPosition;
	bool isObjectMoved = false; 
		
    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		if (!isObjectMoved)
		{
			resetPosition = GameObject.Find("Cylinder2").transform.position;
		}
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }
    
    void OnMouseUp()
    {
		Vector3 gap1 = GameObject.Find("Gap1").transform.position;
		Vector3 gap2 = GameObject.Find("Gap2").transform.position;
		Vector3 gap3 = GameObject.Find("Gap3").transform.position;
		Vector3 gap4 = GameObject.Find("Gap4").transform.position;
		Vector3 gap5 = GameObject.Find("Gap5").transform.position;
		Vector3 gap6 = GameObject.Find("Gap6").transform.position;
		
		
		if (AreObjectsClose(gap1, gameObject.transform.position))
		{
			transform.position = gap1;
			isObjectMoved = true;
		}
		else if (AreObjectsClose(gap2, gameObject.transform.position))
		{
			transform.position = gap2;
			isObjectMoved = true;
		}
		else if (AreObjectsClose(gap3, gameObject.transform.position))
		{
			transform.position = gap3;
			isObjectMoved = true;
		}
		else if (AreObjectsClose(gap4, gameObject.transform.position))
		{
			transform.position = gap4;
			isObjectMoved = true;
		}
		else if (AreObjectsClose(gap5, gameObject.transform.position))
		{
			transform.position = gap5;
			isObjectMoved = true;
		}
		else if (AreObjectsClose(gap6, gameObject.transform.position))
		{
			transform.position = gap6;
			isObjectMoved = true;
		}
		else
		{
			transform.position = resetPosition;
			isObjectMoved = false;
		}	      

		CheckWin();		     
    }
	
	private void CheckWin()
	{
		if (AreObjectsClose(GameObject.Find("Gap1").transform.position, GameObject.Find("Cylinder1").transform.position)
			&& AreObjectsClose(GameObject.Find("Gap2").transform.position, GameObject.Find("Cylinder2").transform.position)
			&& AreObjectsClose(GameObject.Find("Gap3").transform.position, GameObject.Find("Cylinder4").transform.position)
			&& AreObjectsClose(GameObject.Find("Gap4").transform.position, GameObject.Find("Cylinder5").transform.position)
			&& AreObjectsClose(GameObject.Find("Gap5").transform.position, GameObject.Find("Cylinder6").transform.position)
			&& AreObjectsClose(GameObject.Find("Gap6").transform.position, GameObject.Find("Cylinder3").transform.position))
		{
			SceneManager.LoadScene(2);
		}
	}
	
	private bool AreObjectsClose(Vector3 gap, Vector3 position)	
	{
		return Math.Abs(position.x - gap.x) < 0.7
			&& Math.Abs(position.y - gap.y) < 0.7
			&& Math.Abs(position.z - gap.z) < 0.7;
	}

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }
}