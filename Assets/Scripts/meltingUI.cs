using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meltingUI : MonoBehaviour
{
    public GameObject _canvas;
    

    public Texture[] _texture;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float RValue = _canvas.GetComponent<UIRotate>().RValue+110.0f; 

        //Debug.Log("RV : " + RValue);
        if(RValue < 33f && _texture[4] != null)
        {
            gameObject.GetComponent<RawImage>().texture = _texture[5];
        }
        else if (RValue < 44f && _texture[3] != null)
        {
            gameObject.GetComponent<RawImage>().texture = _texture[4];
        }
        else if (RValue < 88f && _texture[2] != null)
        {
            gameObject.GetComponent<RawImage>().texture = _texture[3];
        }
        else if (RValue < 132f && _texture[1] != null)
        {
            gameObject.GetComponent<RawImage>().texture = _texture[2];
        }
        else if (RValue < 176 && _texture[0] != null)
        {
            gameObject.GetComponent<RawImage>().texture = _texture[1];
        }
        else if (RValue < 222 && _texture[0] != null)
        {
            gameObject.GetComponent<RawImage>().texture = _texture[0];
        }










    }
}
