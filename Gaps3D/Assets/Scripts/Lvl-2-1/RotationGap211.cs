using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationGap211 : MonoBehaviour
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
			resetPosition = GameObject.Find("Gap1").transform.position;
			isObjectMoved = true; 
		}
    }
	
	void OnMouseUp()
    {
		if (AreObjectsClose(resetPosition, gameObject.transform.position))
		{
			if (position == Position.Forward)
			{
				transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -0.6f);
				position = Position.Right;
			}
			else if (position == Position.Right)
			{
				transform.position = new Vector3(-6, -2.15f, -0.57f);
				position = Position.Back;
			}
			else if (position == Position.Back)
			{
				transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -2.8f);
				position = Position.Left;
			}
			else if (position == Position.Left)
			{
				transform.position = new Vector3(-4, -2.2f, -2.8f);
				position = Position.Forward;
			}
			transform.Rotate(0.0f, -90.0f, 0.0f);
			resetPosition = GameObject.Find("Gap1").transform.position;
		}
	}
	
	private bool AreObjectsClose(Vector3 gap, Vector3 position)	
	{
		return Math.Abs(position.x - gap.x) < 0.7
			&& Math.Abs(position.y - gap.y) < 0.7
			&& Math.Abs(position.z - gap.z) < 0.7;
	}
}