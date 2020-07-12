using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSounds : MonoBehaviour
{

    private AudioSource audioSource;

    public AudioClip menuClick;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void menuClickSound()
    {
        audioSource.clip = menuClick;
        audioSource.Play();
        print("menuclick play");
    }

}
