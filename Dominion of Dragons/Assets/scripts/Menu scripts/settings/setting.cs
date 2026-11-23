using UnityEngine;

public class setting : MonoBehaviour
{
    public AudioSource AudioSource;
    void sound()
    {
        if (AudioSource.mute = false)
        {
            AudioSource.mute = true;
        }
        AudioSource.mute = false;
    }
}
