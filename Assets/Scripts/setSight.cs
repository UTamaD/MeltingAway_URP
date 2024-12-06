using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class setSight : MonoBehaviour
{
    public Volume globalVolume;
   // public GameObject myURP;
    private DepthOfField depthOfField;
    private Vignette _vignette;
    private Bloom _bloom;
    private LiftGammaGain _lift;
    private bool _isRace = false;

    private PlayerManager _myPM;
    public Color startColor = new Color(0.0f,0.0f, 254.0f, 254.0f);
    public Color endColor = new Color(254.0f, 254.0f, 254.0f, 254.0f);
    public GameObject myEye;
    void Start()
    {
        if (globalVolume != null && globalVolume.profile.TryGet(out depthOfField) && globalVolume.profile.TryGet(out _vignette) && globalVolume.profile.TryGet(out _bloom) && globalVolume.profile.TryGet(out _lift))
        {
            float focusDistance = depthOfField.focusDistance.value;
           // Debug.Log("Depth of field focus distance: " + focusDistance);
        }
        else
        {
           // Debug.LogWarning("Global volume or depth of field not found.");
        }
        _myPM = GetComponent<PlayerManager>();
        _isRace = _myPM.isRace;
    }

    void sunSet()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(_myPM.eyeNum == 1)
        {
            _vignette.intensity.value = 0.25f;


            Scene myS = SceneManager.GetActiveScene();

            if(myS.name == "VillageMap")
            {
                depthOfField.focusDistance.value = 0.1f;
                myEye.SetActive(false);

            }
            else if(myS.name == "RacingMap"||_isRace == true)
            {
                //depthOfField.focusDistance.value = 1.0f;
                _vignette.intensity.value = 0.75f;
            }
            else
            {
                depthOfField.focusDistance.value = 0.5f;
            }
          

 
        }
        else if(_myPM.eyeNum == 2)
        {
            //_vignette.intensity.value = 0.25f;
            depthOfField.focusDistance.value = 10.0f;
        }
        else if(_myPM.eyeNum == 0)
        {

            if(_isRace == true)
            {
                depthOfField.focusDistance.value = 1.0f;
                myEye.SetActive(true);
            }
        }


        if(_bloom != null &&_lift != null && _isRace == true)
        {
            float size = GetComponent<PlayerManager>().size;



            _lift.gamma.value = new Vector4(0,0,0,Mathf.Lerp(1, 0, size));
            _bloom.tint.value = Color.Lerp(endColor, startColor, size);
        }
   
    }

    
}
