using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyboxLerp : MonoBehaviour
{

    public Material startSky;
    public Material endSky;

    public GameObject _Camera;


    private Skybox _sky;
    private PlayerManager _PL;
    
    // Start is called before the first frame update
    void Start()
    {
        _PL = gameObject.GetComponent<PlayerManager>();
        _sky = _Camera.GetComponent<Skybox>();
    }

    // Update is called once per frame
    void Update()
    {

        if(_PL.size < 0.9)
        {
            _sky.material = endSky;
        }
        else
        {
            _sky.material = startSky;
        }
        
    }
}
