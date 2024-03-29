﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollText : MonoBehaviour {

	[SerializeField]
	private RectTransform viewportTransform;
	[SerializeField]
	private RectTransform contentTransform;
	[SerializeField]
	private Scrollbar scrollbar;

	private float scrollPercentage;

	void Start () {
		scrollPercentage = 1 / (contentTransform.rect.height / viewportTransform.rect.height - 1);
	}

	public void ScrollDown () {
		scrollbar.value -= scrollPercentage;
	}

	public void Reset () {
		scrollbar.value = 1f;
	}

}
