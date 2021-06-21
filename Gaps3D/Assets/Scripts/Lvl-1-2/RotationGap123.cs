using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
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
			_resetPosition = GameObject.Find("Gap3").transform.position;
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
				transform.position = new Vector3(-5.5f, -2.3f, -0.6f);
				_position = Position.Right;
			}
			else if (_position == Position.Right)
			{
				transform.position = new Vector3(-8, -2.25f, -0.4f);
				_position = Position.Back;
			}
			else if (_position == Position.Back)
			{
				transform.position = new Vector3(-7.9f, -2.3f, -2.9f);
				_position = Position.Left;
			}
			else if (_position == Position.Left)
			{
				transform.position = new Vector3(-5.1f, -2.2f, -3);
				_position = Position.Forward;
			}
			transform.Rotate(0.0f, -90.0f, 0.0f);
			_resetPosition = GameObject.Find("Gap3").transform.position;
		}
	}
	
	private bool AreObjectsClose(Vector3 gap, Vector3 position)	
	{
		return Math.Abs(position.x - gap.x) < 0.7
			&& Math.Abs(position.y - gap.y) < 0.7
			&& Math.Abs(position.z - gap.z) < 0.7;
	}
}