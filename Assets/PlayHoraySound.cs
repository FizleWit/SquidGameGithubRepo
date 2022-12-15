using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHoraySound : MonoBehaviour
{
    public AudioClip HoraySound;
    public AudioSource AudioSourcePlatform;
    // Start is called before the first frame update
    void Start()
    {
        AudioSourcePlatform = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        AudioSourcePlatform.PlayOneShot(HoraySound, 10f);
    }
}
