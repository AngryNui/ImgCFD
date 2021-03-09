using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calibration : MonoBehaviour
{
    public bool showHeightCal;
    public bool showCamCal;
     [Range(1f, 50f)]
    public float normalDistance = 21.7f;
    [Range(1f, 20f)]
    public float minMax=5f
    ;
    // Start is called before the first frame update
    void Start()
    {
        LineRenderer lr = gameObject.AddComponent(typeof(LineRenderer)) as LineRenderer;
        lr.startColor = lr.endColor = new Color(1f,0,0);
        lr.material = new Material(Shader.Find("Particles/Additive"));
        lr.startWidth = lr.endWidth = 1;
        lr.SetPosition(0,gameObject.transform.position);
        lr.SetPosition(1,Vector3.one);
        lr.receiveShadows = false;
        lr.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        //lr.SetPosition(,gameObject.transform.position)

        //todo get to the shader
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
