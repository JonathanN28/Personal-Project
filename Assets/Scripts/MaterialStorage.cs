using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class MaterialStorage : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public ParticleSystem bootParticle;
    public MeshRenderer my_renderer;
    
    private float startDelay = 1f;
    private float randomNumber;

    private Counting Counting;

    // Start is called before the first frame update
    void Start()
    { 
        randomNumber = Random.Range(10f, 20f);
        my_renderer = GetComponent<MeshRenderer>();
        my_renderer.material = material1;
        InvokeRepeating("autoTurnOn", startDelay, randomNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleMaterial()
    {
        my_renderer.material = material2;
        bootParticle.transform.position = transform.position;
        bootParticle.Play();
    }

    public void autoTurnOn()
    {
        
        my_renderer.material = material1;
        gameObject.GetComponent<Collider>().enabled = true;
    }
    
}
