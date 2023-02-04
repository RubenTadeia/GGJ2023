using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
	public Slider volumeSlider;
	public AudioSource audioSource;

	private void Start()
	{
		volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
	}

	private void OnVolumeChanged(float value)
	{
		audioSource.volume = value;
	}
}