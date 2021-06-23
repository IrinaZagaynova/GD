using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialGragGap1 : MonoBehaviour
{
    private Vector3 _mOffset;
    private float _mZCoord;
    private Vector3 _resetPosition;
	private bool _isObjectMoved = false; 
	public string _objectName = "";
	private const string _transparentPrefix = "Transparent";
		
    void OnMouseDown()
    {
        _mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		if (!_isObjectMoved)
		{
			_resetPosition = GameObject.Find(_objectName).transform.position;
		}
        _mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }
    
    void OnMouseUp()
    {
		Vector3 gap1 = GameObject.Find(_transparentPrefix + _objectName).transform.position;

				
		if (AreObjectsClose(gap1, gameObject.transform.position))
		{
			transform.position = gap1;
			_isObjectMoved = true;
			
			if (GameObject.Find("Gap2").transform.position.x == -1.7f 
				&& GameObject.Find("Gap2").transform.position.y == -2.25f 
				&& GameObject.Find("Gap2").transform.position.z == -0.5f)
			{
				GameObject.Find("Touch").transform.position = new Vector3(-2.25f, -1.25f, -3.5f);
				GameObject.Find("TouchArea").transform.position = new Vector3(-2.8f, -1, -3f);
			}
		}
		else
		{
			transform.position = _resetPosition;
			_isObjectMoved = false;
		}	      

		CheckWin();		
    }
	
	private void CheckWin()
	{
		if (AreObjectsClose(GameObject.Find("Gap1").transform.position, GameObject.Find("TransparentGap1").transform.position)
			&& AreObjectsClose(GameObject.Find("Gap2").transform.position, GameObject.Find("TransparentGap2").transform.position))
		{
			StartCoroutine(ProcessWin());
		}
	}
	
	private IEnumerator ProcessWin()
	{
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene(7);
	}
	
	private bool AreObjectsClose(Vector3 gap, Vector3 position)	
	{
		return Math.Abs(position.x - gap.x) < 1
			&& Math.Abs(position.y - gap.y) < 1
			&& Math.Abs(position.z - gap.z) < 1;
	}

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = _mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + _mOffset;
    }
}