using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour {

    public float spawnEffectTime = 2;
    public float pause = 1;
    public AnimationCurve fadeIn;

    [HideInInspector] public bool check = false;
    ParticleSystem ps;
    float timer = 0;
    [SerializeField] private List<Renderer> renderers;
    Renderer _renderer;

    int shaderProperty;

	void Awake ()
    {
        shaderProperty = Shader.PropertyToID("_cutoff");
        //_renderer = GetComponent<Renderer>();
        ps = GetComponentInChildren <ParticleSystem>();

        var main = ps.main;
        main.duration = spawnEffectTime;

        //ps.Play();

    }
	
	void Update ()
    {
        if(check)
        {
            if (timer < spawnEffectTime + pause)
            {
                timer += Time.deltaTime;
            }
            else
            {
                ps.Play();
                timer = 0;
            }

            foreach (var renderer in renderers)
            {
                renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate( Mathf.InverseLerp(0, spawnEffectTime, timer)));
            }
        }
    }
}
