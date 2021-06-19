using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotationGap124 : MonoBehaviour
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
	private Stopwatch _stopWatch = new Stopwatch();
	
	void OnMouseDown()
    {
		_stopWatch.Reset();
		_stopWatch.Start();
		
		if (!isObjectMoved)
		{
			resetPosition = GameObject.Find("Gap4").transform.position;
			isObjectMoved = true; 
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
		
		if (AreObjectsClose(resetPosition, gameObject.transform.position))
		{
			if (position == Position.Forward)
			{
				transform.position = new Vector3(2.6f, gameObject.transform.position.y, 0.4f);
				position = Position.Right;
			}
			else if (position == Position.Right)
			{
				transform.position = new Vector3(-0.2f, gameObject.transform.position.y, -0.3f);
				position = Position.Back;
			}
			else if (position == Position.Back)
			{
				transform.position = new Vector3(0, gameObject.transform.position.y, -2.9f);
				position = Position.Left;
			}
			else if (position == Position.Left)
			{
				transform.position = new Vector3(3.2f, -2.25f, -2.7f);
				position = Position.Forward;
			}
			transform.Rotate(0.0f, -90.0f, 0.0f);
			resetPosition = GameObject.Find("Gap4").transform.position;
		}
	}
	
	private bool AreObjectsClose(Vector3 gap, Vector3 position)	
	{
		return Math.Abs(position.x - gap.x) < 0.7
			&& Math.Abs(position.y - gap.y) < 0.7
			&& Math.Abs(position.z - gap.z) < 0.7;
	}
}