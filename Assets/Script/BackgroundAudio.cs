using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{

    public AudioSource ambientAudio;

    // Start is called before the first frame update
    void Start()
    {
        ambientAudio = GetComponent<AudioSource>();
        ambientAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
