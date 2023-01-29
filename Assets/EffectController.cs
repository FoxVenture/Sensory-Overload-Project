using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    // This script controls the visual effects the player sees.
    // These are called in the timeline using signals.

    [SerializeField] bool effectScriptActive, jitter1, jitter2;
    [SerializeField] Kino.AnalogGlitch effectScript;

    [SerializeField] Light lightEffect;
    // Start is called before the first frame update
    void Start()
    {
        effectScriptActive = false;
        effectScript.enabled = false;
        SetJitter(0);
        SetDrift(0);
        //lightEffect = GetComponent<Light>();
    }

    // Change the intensity of the jitter effect.
    public void SetJitter(float nr)
    {
        effectScript.scanLineJitter = nr;
    }

    // Change the intensity of the colordrift effect.
    private void SetDrift(float nr)
    {
        //effectScript.colorDrift = Mathf.Lerp(effectScript.colorDrift, nr, Time.time/3);
        effectScript.colorDrift = nr;
    }

    private void Update()
    {
        if(effectScriptActive)
        {
            effectScript.enabled = true;
        }

        if(!effectScriptActive)
        {
            effectScript.enabled = false;
        }
    }

    public void DisableEffectScript()
    {
        effectScriptActive = false;
    }

    public void EnableJitter(float jitter)
    {
        SetJitter(jitter);
        //SetDrift(0);
        effectScriptActive = true;
    }

    public void EnableDraft(float draft)
    {
        SetJitter(0.2f);
        SetDrift(effectScript.colorDrift+draft);
        effectScriptActive = true;
    }

}
