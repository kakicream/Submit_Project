using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private float playTime;

    public AudioClip[] expSound;
    private new AudioSource audio;
    [SerializeField] private float volume;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        /***** Abstraction *****/
        PlaySound(); // Method 1
        StartCoroutine(DurationTime()); // IEnumerator 1
    }

    #region Method 1
    void PlaySound()
    {
        int soundIndex = Random.Range(0, expSound.Length);
        if (expSound.Length > 1)
        {
            float distance = (transform.position - Vector3.zero).magnitude;
            volume /= distance;
            audio.PlayOneShot(expSound[soundIndex], volume);
            /***** Abstraction *****/
            SoundOn(soundIndex, volume); // Method 1-1
        }
        else
        {
            audio.PlayOneShot(expSound[soundIndex], volume);
            SoundOn(soundIndex, volume); /***** Abstraction *****/
        }
    }

    // Method 1-1
    void SoundOn(int index, float vol)
    {
        audio.PlayOneShot(expSound[index], vol);
    }
    #endregion

    #region IEnumerator 1
    IEnumerator DurationTime()
    {
        yield return new WaitForSeconds(playTime);
        Destroy(gameObject);
    }
    #endregion
}