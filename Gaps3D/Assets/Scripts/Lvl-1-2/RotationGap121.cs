using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationGap121 : MonoBehaviour
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
	private Stopwatch _stopWatch = new Stopwatch();
	
	void OnMouseDown()
    {
		_stopWatch.Reset();
		_stopWatch.Start();
		
		if (!_isObjectMoved)
		{
			_resetPosition = GameObject.Find("Gap1").transform.position;
			_isObjectMoved = true; 
		}
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
		
		if (AreObjectsClose(_resetPosition, gameObject.transform.position))
		{
			if (_position == Position.Forward)
			{
				transform.position = new Vector3(6.9f, gameObject.transform.position.y, 0.5f);
				_position = Position.Right;
			}
			else if (_position == Position.Right)
			{
				transform.position = new Vector3(3.7f, -2.25f, -0.3f);
				_position = Position.Back;
			}
			else if (_position == Position.Back)
			{
				transform.position = new Vector3(4.7f, gameObject.transform.position.y, -3.5f);
				_position = Position.Left;
			}
			else if (_position == Position.Left)
			{
				transform.position = new Vector3(7.75f, -2.25f, -2.9f);
				_position = Position.Forward;
			}
			transform.Rotate(0.0f, -90.0f, 0.0f);
			_resetPosition = GameObject.Find("Gap1").transform.position;
		}
	}
	
	private bool AreObjectsClose(Vector3 gap, Vector3 position)	
	{
		return Math.Abs(position.x - gap.x) < 0.7
			&& Math.Abs(position.y - gap.y) < 0.7
			&& Math.Abs(position.z - gap.z) < 0.7;
	}
}