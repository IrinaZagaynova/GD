using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationGap114 : MonoBehaviour
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
			_resetPosition = gameObject.transform.position;
			_isObjectMoved = true; 
		}
    }
	
	void OnMouseUp()
    {
		if (AreObjectsInSamePosition(_resetPosition, gameObject.transform.position))
		{
			if (_position == Position.Forward)
			{
				gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -0.35f);
				_position = Position.Right;
			}
			else if (_position == Position.Right)
			{
				gameObject.transform.position = new Vector3(4.2f, gameObject.transform.position.y, gameObject.transform.position.z);
				_position = Position.Back;
			}
			else if (_position == Position.Back)
			{
				gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -3.3f);
				_position = Position.Left;
			}
			else if (_position == Position.Left)
			{
				gameObject.transform.position = new Vector3(7.1f, -2.25f, -2.55f);
				_position = Position.Forward;
			}
			
			transform.Rotate(0.0f, -90.0f, 0.0f);
			_resetPosition = gameObject.transform.position;
		}
	}
	
	private bool AreObjectsInSamePosition(Vector3 gap, Vector3 position)	
	{
		return Math.Abs(position.x - gap.x) < 0.05f
			&& Math.Abs(position.y - gap.y) < 0.05f
			&& Math.Abs(position.z - gap.z) < 0.05f;
	}
}