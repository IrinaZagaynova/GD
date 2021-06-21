using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationGap112 : MonoBehaviour
{
	private enum Position
	{
		Forward,
		Right,
		Back,
		Left
	}

	private Vector3 _resetPosition;
	private Vector3 _currentPosition;
	private bool _isObjectMoved = false; 
	private Position _position = Position.Forward;
	private Stopwatch _stopWatch = new Stopwatch();
	
	void OnMouseDown()
    {
		_stopWatch.Reset();
		_stopWatch.Start();
		
		if (!_isObjectMoved)
		{
			_resetPosition = gameObject.transform.position;
			_isObjectMoved = true; 
		}
		
		_currentPosition = gameObject.transform.position;
    }
	
	void OnMouseUp()
    {			
		_stopWatch.Stop();
		TimeSpan ts = _stopWatch.Elapsed;
		TimeSpan delay = new TimeSpan(1700000);
		
		if (ts > delay)
		{
			return;
		}
		
		
		if (AreObjectsInSamePosition(_resetPosition, gameObject.transform.position))
		{
			if (_position == Position.Forward)
			{
				gameObject.transform.position = new Vector3(-3.5f, gameObject.transform.position.y, gameObject.transform.position.z);
				_position = Position.Right;
			}
			else if (_position == Position.Right)
			{
				gameObject.transform.position = new Vector3(-3.5f, gameObject.transform.position.y, -3.6f);
				_position = Position.Back;
			}
			else if (_position == Position.Back)
			{
				gameObject.transform.position = new Vector3(0.2f, gameObject.transform.position.y, -3.2f);
				_position = Position.Left;
			}
			else if (_position == Position.Left)
			{
				gameObject.transform.position = new Vector3(0.1f, -2.21f, 0.5f);
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