using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlay : MonoBehaviour
{
    public ParticleSystem p;

    private void Start()
    {
        if (p == null && GetComponent<ParticleSystem>())
        {
            p = GetComponent<ParticleSystem>();
        }
        else if (GetComponentInChildren<ParticleSystem>())
        {
            p = GetComponentInChildren<ParticleSystem>();
        }
    }
    public void _Play()
    {
        p.Play();
    }
}
