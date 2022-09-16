using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioDataGetter : MonoBehaviour
{
    private AudioSource audioSource;

    private float[] audioSamples;
    private const int audioSamplesSize = 512;

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

        float outputVolume = Mathf.Sqrt(sum / audioSamples.Length) * 100;

        Debug.Log($"Volume: {outputVolume}");
    }
}
