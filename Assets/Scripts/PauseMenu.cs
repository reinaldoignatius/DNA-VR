﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	private const int SCENE_NUMBER_OFFSET = 1;

	[System.Serializable]
	public class SceneOption {
		public string name;
		public string title;
		public Sprite normalSprite;
		public Sprite hoverSprite;
		public string subtitle;
		public Sprite pageSprite;
	}

	[SerializeField]
	private int currentScene;
	[SerializeField]
	private float ROTATION = 20f;
	[SerializeField]
	private List <SceneOption> scenes; 
	[SerializeField]
	private GameObject options;
	[SerializeField]
	private Transform pivot;
	[SerializeField]
	private GameObject prevButton;
	[SerializeField]
	private GameObject nextButton;
	[SerializeField]
	private Text selectedSceneTitle;
	[SerializeField]
	private Image selectedSceneImage;
	[SerializeField]
	private HoverableButton selectedSceneHoverButton;
	[SerializeField]
	private Text selectedSceneSubtitle;
	[SerializeField]
	private Image selectedScenePage;

	private int selectedScene;

	void Start () {
		selectedScene = currentScene - SCENE_NUMBER_OFFSET;
		pivot.localEulerAngles = new Vector3 (0, -selectedScene * ROTATION, 0);
		if (selectedScene == 0) {
			prevButton.SetActive (false);
		} else if (selectedScene == scenes.Count - SCENE_NUMBER_OFFSET) {
			nextButton.SetActive (false);
		}
		UpdateSelectedScene ();
	}

	void UpdateSelectedScene () {
		selectedSceneTitle.text = scenes [selectedScene].title;
		selectedSceneImage.sprite = scenes [selectedScene].normalSprite;
		selectedSceneImage.SetNativeSize ();
		selectedSceneHoverButton.setNormalSprite (scenes [selectedScene].normalSprite);
		selectedSceneHoverButton.SetHoverSprite (scenes [selectedScene].hoverSprite);
		selectedSceneSubtitle.text = scenes [selectedScene].subtitle;
		selectedScenePage.sprite = scenes [selectedScene].pageSprite;
	}

	public void Show () {
		gameObject.SetActive (true);
		options.SetActive (false);
		Pointer.Instance.HideAllVrCanvas ();
	}

	public void NextScene () {
		pivot.localEulerAngles = new Vector3 (0, pivot.localEulerAngles.y - ROTATION, 0);
		if (selectedScene == 0) {
			prevButton.SetActive (true);
		}
		++selectedScene;
		if (selectedScene == scenes.Count - SCENE_NUMBER_OFFSET) {
			nextButton.SetActive (false);
		}
		UpdateSelectedScene ();
	}

	public void PrevScene () {
		pivot.localEulerAngles = new Vector3 (0, pivot.localEulerAngles.y + ROTATION, 0);
		if (selectedScene == scenes.Count - SCENE_NUMBER_OFFSET) {
			nextButton.SetActive (true);
		}
		--selectedScene;
		if (selectedScene == 0) {
			prevButton.SetActive (false);
		}
		UpdateSelectedScene ();
	}

	public void ChooseScene () {
		SceneController.Instance.LoadScene (scenes [selectedScene].name);
	}

	public void BackToHome () {
		StartCoroutine (VRController.Instance.BackToMainMenu ());
	}

}
