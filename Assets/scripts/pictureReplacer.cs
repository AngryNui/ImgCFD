using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pictureReplacer : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject depthObject, projector;
    Camera depthCamera;
    Shader pShader;
    Renderer rend;    
    Texture2D picture;
    int counter, color;
    Material m_Material;
    
    void Start()
    {   
        depthObject  = GameObject.Find("/heightmapShader");
        depthCamera = depthObject.GetComponent(typeof(Camera)) as Camera;
        projector = GameObject.Find("/BlobLightProjector");
        //pShader = projector.GetComponent<>;
        color = Random.Range(0,255);
        Material[] matsArray = Resources.FindObjectsOfTypeAll(typeof(Material)) as Material[];
        for (int i = 0; i < matsArray.Length ; i++){
            if(matsArray[i].ToString().Contains("LightProjector")){
                m_Material=matsArray[i];
            }            
        }
        picture = m_Material.GetTexture("_ShadowTex") as Texture2D;
    }
    // Update is called once per frame
    void Update()
    {
        Texture2D pictureCopy = new Texture2D (picture.width, picture.height, TextureFormat.ARGB32, false);
        pictureCopy.SetPixels32(picture.GetPixels32());
        for (int x=0; x<picture.height; x++){
            for (int y=0; y<picture.width; y++){
                color+=Random.Range(1,20);
                if (color>=255) {
                   color-=255;
                   
                }
                Color pixelColor = pictureCopy.GetPixel(x,y);
                
                pixelColor.r = (pixelColor.r+color/255f)/2f; 
                pixelColor.g = (pixelColor.g+color/255f)/2f;
                pixelColor.b = (pixelColor.b+color/255f)/2f;
                
                pictureCopy.SetPixel(x,y,pixelColor);
            }
        }
        pictureCopy.Apply();
        m_Material.SetTexture("_ShadowTex", pictureCopy);
    }
    void OnApplicationQuit()
    {
        m_Material.SetTexture("_ShadowTex", picture);
    }
}


