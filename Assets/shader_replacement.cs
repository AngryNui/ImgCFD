using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shader_replacement : MonoBehaviour
{

	public Shader replacementShader;

    // Start is called before the first frame update
    void Start()
    {   
        if (replacementShader != null){
            GetComponent<Camera>().SetReplacementShader(replacementShader, "RenderType");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
