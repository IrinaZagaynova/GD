using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationGap221 : MonoBehaviour
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
		
		if (_position == Position.Forward)
		{
			transform.position = new Vector3(-8.6f, -2, -3.2f);
			_position = Position.Right;
		}
		else if (_position == Position.Right)
		{
			transform.position = new Vector3(-6, gameObject.transform.position.y, -2.7f);
			_position = Position.Back;
		}
		else if (_position == Position.Back)
		{
			transform.position = new Vector3(-6.5f, gameObject.transform.position.y, -0.2f);
			_position = Position.Left;
		}
		else if (_position == Position.Left)
		{
			transform.position = new Vector3(-8.8f, -2, -0.6f);
			_position = Position.Forward;
		}	
		
		transform.Rotate(0.0f, -90.0f, 0.0f);
		_resetPosition = GameObject.Find("Gap1").transform.position;	
	}
	
	private bool AreObjectsClose(Vector3 gap, Vector3 position)	
	{
		return Math.Abs(position.x - gap.x) < 0.7
			&& Math.Abs(position.y - gap.y) < 0.7
			&& Math.Abs(position.z - gap.z) < 0.7;
	}
}