﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrUi : MonoBehaviour {

	[SerializeField]
	private Transform nextObject;
	[SerializeField]
	private int nextObjectIndex;
	[SerializeField]
	private Transform prevObject;
	[SerializeField]
	private int prevObjectIndex;

	public void Open () {
		gameObject.SetActive (true);
	}

	public void Close () {
		gameObject.SetActive (false);
	}

	public void PointToNextObject () {
		Pointer.Instance.PointTo (nextObject.position, nextObjectIndex);
		Close ();
	}

	public void PointToPrevObject () {
		Pointer.Instance.PointTo (prevObject.position, prevObjectIndex);
		Close ();
	}
		
}
