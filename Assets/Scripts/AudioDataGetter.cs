using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(AudioSource))]
public class AudioDataGetter : MonoBehaviour
{
    [SerializeField]
    private Text txtOutputVolume;

    private AudioSource audioSource;

    private float[] audioSamples;
    private const int audioSamplesSize = 512;

    private float outputVolume;
    public float OutputVolume { get => outputVolume; private set => outputVolume = value; }

    private void Awake()
    {
        Debug.Log("Awake");

        audioSource = GetComponent<AudioSource>();

        audioSamples = new float[audioSamplesSize];
    }

    public void Update()
    {
        if (audioSource.isPlaying == false)
            return;

        audioSource.GetOutputData(audioSamples, 0);

        float sum = 0;

        for (int i = 0; i < audioSamples.Length; i++)
        {
            sum += audioSamples[i] * audioSamples[i];
        }

        outputVolume = Mathf.Sqrt(sum / audioSamples.Length) * 100;

        LogOutputVolume();
    }

    private void LogOutputVolume()
    {
        string outputVolumeString = $"Output Volume: {outputVolume}";

        Debug.Log(outputVolumeString);
        txtOutputVolume.text = outputVolumeString;
    }
}
