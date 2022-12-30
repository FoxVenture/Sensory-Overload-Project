using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField] bool effectScriptActive, jitter1, jitter2;
    [SerializeField] Kino.AnalogGlitch effectScript;
    // Start is called before the first frame update
    void Start()
    {
        effectScriptActive = false;
        effectScript.enabled = false;
        SetJitter(0);
        SetDrift(0);
    }

    public void SetJitter(float nr)
    {
        effectScript.scanLineJitter = nr;
    }

    private void SetDrift(float nr)
    {
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
        SetDrift(0);
        effectScriptActive = true;
    }

    public void EnableDraft(float draft)
    {
        SetJitter(0);
        SetDrift(draft);
        effectScriptActive = true;
    }


}
