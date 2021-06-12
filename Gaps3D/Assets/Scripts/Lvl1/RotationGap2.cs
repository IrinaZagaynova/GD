using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationGap2 : MonoBehaviour
{
	private enum Position
	{
		Forward,
		Right,
		Back,
		Left
	}

	private Vector3 _resetPosition;
	private bool _isObjectMoved = false; 
	private Position _position = Position.Forward;
	
	void OnMouseDown()
    {
		if (!_isObjectMoved)
		{
			_resetPosition = GameObject.Find("Gap2").transform.position;
			_isObjectMoved = true; 
		}
    }
	
	void OnMouseUp()
    {
		if (AreObjectsClose(_resetPosition, gameObject.transform.position))
		{
			if (_position == Position.Forward)
			{
				transform.position = new Vector3(-3.5f, gameObject.transform.position.y, gameObject.transform.position.z);
				_position = Position.Right;
			}
			transform.Rotate(0.0f, -90.0f, 0.0f);
		}
	}
	
	private bool AreObjectsClose(Vector3 gap, Vector3 position)	
	{
		return Math.Abs(position.x - gap.x) < 0.7
			&& Math.Abs(position.y - gap.y) < 0.7
			&& Math.Abs(position.z - gap.z) < 0.7;
	}
}