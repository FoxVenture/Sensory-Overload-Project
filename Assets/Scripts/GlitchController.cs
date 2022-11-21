using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kino;

public class GlitchController : MonoBehaviour
{
    public AnalogGlitch glitchEffect;
    // Start is called before the first frame update
    void Start()
    {
        glitchEffect.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableGlitch()
    {
        glitchEffect.enabled = true;
    }
    public void DisableGlitch()
    {
        glitchEffect.enabled = false;
    }
}
