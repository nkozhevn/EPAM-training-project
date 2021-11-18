using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour {

    [SerializeField] private float spawnEffectTime = 2;
    [SerializeField] private float pause = 1;
    [SerializeField] private AnimationCurve fadeIn;
    [SerializeField] private List<Renderer> renderers;

    [HideInInspector] public bool check = false;
    private ParticleSystem ps;
    private float timer = 0;
    private Renderer _renderer;

    private int shaderProperty;

	void Awake ()
    {
        shaderProperty = Shader.PropertyToID("_cutoff");
        ps = GetComponentInChildren <ParticleSystem>();

        var main = ps.main;
        main.duration = spawnEffectTime;


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
