using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationGap123 : MonoBehaviour
{
	private enum Position
	{
		Forward,
		Right,
		Back,
		Left
	}

	private Vector3 resetPosition;
	private bool isObjectMoved = false; 
	private Position position = Position.Forward;
	
	void OnMouseDown()
    {
		if (!isObjectMoved)
		{
			resetPosition = GameObject.Find("Gap3").transform.position;
			isObjectMoved = true; 
		}
    }
	
	void OnMouseUp()
    {
		if (AreObjectsClose(resetPosition, gameObject.transform.position))
		{
			if (position == Position.Forward)
			{
				transform.position = new Vector3(-5.5f, -2.3f, -0.6f);
				position = Position.Right;
			}
			else if (position == Position.Right)
			{
				transform.position = new Vector3(-8, -2.25f, -0.4f);
				position = Position.Back;
			}
			else if (position == Position.Back)
			{
				transform.position = new Vector3(-7.9f, -2.3f, -2.9f);
				position = Position.Left;
			}
			else if (position == Position.Left)
			{
				transform.position = new Vector3(-5.1f, -2.2f, -3);
				position = Position.Forward;
			}
			transform.Rotate(0.0f, -90.0f, 0.0f);
			resetPosition = GameObject.Find("Gap3").transform.position;
		}
	}
	
	private bool AreObjectsClose(Vector3 gap, Vector3 position)	
	{
		return Math.Abs(position.x - gap.x) < 0.7
			&& Math.Abs(position.y - gap.y) < 0.7
			&& Math.Abs(position.z - gap.z) < 0.7;
	}
}