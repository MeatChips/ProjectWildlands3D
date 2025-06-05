using UnityEngine;
using UnityEngine.Audio;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioMixerGroup masterMixerGroup;

    private Slider masterSlider;
    private AudioSource audioSource;
    private float MasterVolume;

    private PauseSystem pauseSystem;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (!PlayerPrefs.HasKey("mastervolume"))
        {
            PlayerPrefs.SetFloat("mastervolume", 0.75f);
        }
    }

    private void Start()
    {
        LoadAudioSettings();
    }

    private void LoadAudioSettings()
    {
        MasterVolume = PlayerPrefs.GetFloat("mastervolume");
        PlayerPrefs.Save();

        UpdateMixerVolume();
    }

    private void OnMasterValueChanged()
    {
        MasterVolume = masterSlider.value;
        PlayerPrefs.SetFloat("mastervolume", masterSlider.value);

        UpdateMixerVolume();
    }

    public void UpdateMixerVolume()
    {
        masterMixerGroup.audioMixer.SetFloat("VolumeMaster", Mathf.Log10(MasterVolume) * 20);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        // Add all 
        if (scene.name == "NEW TERRAIN")
        {
            pauseSystem = GameObject.Find("Canvas").GetComponent<PauseSystem>();
            masterSlider = pauseSystem.audioSlider;

            masterSlider.onValueChanged.AddListener(delegate { OnMasterValueChanged(); });

            masterSlider.value = PlayerPrefs.GetFloat("mastervolume");
        }

    }

     private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

