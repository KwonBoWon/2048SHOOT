using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public static Effect instance;
    public static AudioSource audioSoure;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSoure = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void  MergeScreen()
    {
        audioSoure.Play();

    }

    

 }
