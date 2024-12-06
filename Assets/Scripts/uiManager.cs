using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{

    public GameObject _player;

    public GameObject leftStick;
    public GameObject rightStick;

    public GameObject leftTrigger;
    public GameObject rightTrigger;
    public GameObject eyeBlink;

    public GameObject pannel;

    public GameObject timeline;
    public GameObject endTimeline;
    public GameObject carrotTimeline;
    public GameObject eyeTimeline;
    public GameObject itemTimeline;

    public GameObject mesh;

    

    private bool jumpOnce = true;
    private bool endOnce = true;
    private bool carrotOnce = true;
    private bool leftEyeOnce = true;
    private bool rightEyeOnce = true;

    private bool getAppleOnce = true;
    private bool getRibbonOnce = true;
    private bool getHatOnce = true;

    private PlayerManager _myPL;
    private StarterAssets.StarterAssetsInputs _myInput;

    public GameObject itmeHat;
    public GameObject itmeApple;
    public GameObject itmeRibbon;
    public GameObject itmeCarrot;

    public GameObject tempItemHat;
    public GameObject tempItemApple;
    public GameObject tempItemRibbon;
    public GameObject tempItemCarrot;

    public GameObject carrotItemHat;
    public GameObject carroItemApple;
    public GameObject carroItemRibbon;
    public GameObject carroItemCarrot;


    public GameObject combineItemHat;
    public GameObject combineItemApple;
    public GameObject combineItemRibbon;
    public GameObject combineItemCarrot;

    // Start is called before the first frame update
    void Start()
    {
        if(_player!=null)
        {
            _myPL = _player.GetComponent<PlayerManager>();
            _myInput = _player.GetComponent<StarterAssets.StarterAssetsInputs>();
        }
    }

    IEnumerator stay()
    {

        yield return new WaitForSeconds(1.5f);
    }

    IEnumerator step1()
    {
        yield return new WaitForSeconds(1.0f);
        leftStick.SetActive(false);
        rightStick.SetActive(true);
        yield return null;
    }

    IEnumerator step2()
    {
        yield return new WaitForSeconds(1.0f);
        rightStick.SetActive(false);
        leftTrigger.SetActive(true);
        yield return null;
    }

    IEnumerator step3()
    {
        yield return new WaitForSeconds(1.0f);
        leftTrigger.SetActive(false);
        pannel.SetActive(false);
        yield return null;
    }

    IEnumerator step4()
    {
        yield return new WaitForSeconds(1.0f);
        rightTrigger.SetActive(false);
        pannel.SetActive(false);

        //Destroy(rightTrigger);
        yield return null;
    }

    IEnumerator step5()
    {
        yield return new WaitForSeconds(10.0f);
        rightTrigger.SetActive(true);
        pannel.SetActive(true);
        mesh.SetActive(true);

        yield return null;

    }
    IEnumerator eye()
    {
        if(eyeTimeline!= null)
        {
            eyeTimeline.SetActive(true);
        }

        yield return new WaitForSeconds(3.0f);
        eyeTimeline.SetActive(false);
        yield return null;
    }
    IEnumerator carrot()
    {


        if (carrotTimeline != null)
        {
            carrotTimeline.SetActive(true);
        }
        mesh.SetActive(false);

        yield return new WaitForSeconds(7.5f);
        mesh.SetActive(true);

        yield return null;
    }



    IEnumerator getItems()
    {


        if (itemTimeline != null)
        {
            itemTimeline.SetActive(true);
            
        }

        mesh.SetActive(false);
        yield return new WaitForSeconds(4.0f);
        yield return new WaitForSeconds(8.0f);
        mesh.SetActive(true);
        if (itemTimeline != null)
        {
            itemTimeline.SetActive(false);

        }

        yield return null;
    }

    IEnumerator timeLine()
    {
        if (endTimeline != null)
        {
            endTimeline.SetActive(true);
        }
        mesh.SetActive(false);

        if (_myPL.playerItems[2] != 2)
        {
            combineItemCarrot.SetActive(false);
        }
        else
        {
            combineItemCarrot.SetActive(true);
        }

        if (_myPL.playerItems[6] != 6)
        {
            combineItemHat.SetActive(false);
        }
        else
        {
            combineItemHat.SetActive(true);
        }

        if (_myPL.playerItems[7] != 7)
        {
            
            combineItemRibbon.SetActive(false);
        }
        else
        {
            combineItemRibbon.SetActive(true);
        }

        if (_myPL.playerItems[8] != 8)
        {
            
            combineItemApple.SetActive(false);
        }
        else
        {
            combineItemApple.SetActive(true);
        }



        yield return new WaitForSeconds(12.0f);

        SceneManager.LoadScene("VillageMapTemp");

        yield return null;

    }
    // Update is called once per frame
    void Update()
    {   
        if (_myPL != null)
        {
           if(leftEyeOnce == true && _myPL.eyeNum == 1)
            {
                leftEyeOnce = false;
                StartCoroutine(eye());
            }
            if (rightEyeOnce == true && _myPL.eyeNum == 2)
            {
                rightEyeOnce = false;
                StartCoroutine(eye());
            }
            if (leftStick.activeSelf == true && (_myInput.move.x >0.2 || _myInput.move.x < -0.2 || _myInput.move.y>0.2 || _myInput.move.y<-0.2))
            {
                StartCoroutine(step1());
                
            }
        
           else if(rightStick.activeSelf == true && (_myInput.look.x >0.2|| _myInput.look.x<-0.2||_myInput.look.y<-0.2f||_myInput.look.y>0.2f))
            {
                StartCoroutine(step2());
                
            }
           else if(leftTrigger.activeSelf == true && _myInput.sprint == true)
            {
                StartCoroutine(step3());
                


            }

           if(jumpOnce && rightTrigger != null && rightTrigger.activeSelf == false &&_myPL.CanJump == true)
            {
                jumpOnce = false;
                mesh.SetActive(false);
                timeline.SetActive(true);
                
                StartCoroutine(step5());
                //rightTrigger.SetActive(true);
               // pannel.SetActive(true);
       
            }

            if (rightTrigger != null && rightTrigger.activeSelf == true && _myPL.CanJump == true &&_myInput.jump == true)
            {

                StartCoroutine(step4());
                jumpOnce = false;
            }

            if(_myPL.playerItems[2]==2 && carrotOnce == true)
            {
                carrotOnce = false;

                if(_myPL.playerItems[8]!=8)
                {
                    carroItemApple.SetActive(false);
                }
                else
                {
                    carroItemApple.SetActive(true);
                }
                if (_myPL.playerItems[7] != 7)
                {
                    carroItemRibbon.SetActive(false);
                }
                else
                {
                    carroItemRibbon.SetActive(true);
                }
                if (_myPL.playerItems[6] != 6)
                {
                    carrotItemHat.SetActive(false);
                }
                else
                {
                    carrotItemHat.SetActive(true);
                }

                StartCoroutine(carrot());
            }

            if(_myPL.playerItems[5] == 5 && endOnce==true)
            {
                endOnce = false;
                StartCoroutine(timeLine());
            }

            if (_myPL.playerItems[8] == 8 && getAppleOnce == true)
            {
                getAppleOnce = false;
                itmeHat.SetActive(false);
                itmeApple.SetActive(true);
                itmeRibbon.SetActive(false);

                if (_myPL.playerItems[2] != 2)
                {
                    itmeCarrot.SetActive(false);
                }
                else
                {
                    itmeCarrot.SetActive(true);
                }


                if (_myPL.playerItems[2] != 2)
                {
                    tempItemCarrot.SetActive(false);
                }
                else
                {
                   tempItemCarrot.SetActive(true);
                }

                if (_myPL.playerItems[6] != 6)
                {
                    tempItemHat.SetActive(false);
                }
                else
                {
                    tempItemHat.SetActive(true);
                }

                if (_myPL.playerItems[7] != 7)
                {
                    tempItemRibbon.SetActive(false);
                }
                else
                {
                    tempItemRibbon.SetActive(true);
                }
                tempItemApple.SetActive(false);

                StartCoroutine(getItems());
        



            }

            if (_myPL.playerItems[6] == 6 && getHatOnce == true)
            {
                getHatOnce = false;
                itmeApple.SetActive(false);
                itmeRibbon.SetActive(false);
                itmeHat.SetActive(true);
                if (_myPL.playerItems[2] != 2)
                {
                    itmeCarrot.SetActive(false);
                }
                else
                {
                    itmeCarrot.SetActive(true);
                }
                if (_myPL.playerItems[8] != 8)
                {
                    tempItemApple.SetActive(false);
                }
                else
                {
                    tempItemApple.SetActive(true);
                }
                if (_myPL.playerItems[2] != 2)
                {
                    tempItemCarrot.SetActive(false);
                }
                else
                {
                    tempItemCarrot.SetActive(true);
                }
                if (_myPL.playerItems[7] != 7)
                {
                    tempItemRibbon.SetActive(false);
                }
                else
                {
                    tempItemRibbon.SetActive(true);
                }
                tempItemHat.SetActive(false);

                StartCoroutine(getItems());
                
    
            }

            if (_myPL.playerItems[7] == 7 && getRibbonOnce == true)
            {
                getRibbonOnce = false;
                itmeApple.SetActive(false);
                itmeRibbon.SetActive(true);
                itmeHat.SetActive(false);
                if (_myPL.playerItems[2] != 2)
                {
                    itmeCarrot.SetActive(false);
                }
                else
                {
                    itmeCarrot.SetActive(true);
                }
                if (_myPL.playerItems[2] != 2)
                {
                    tempItemCarrot.SetActive(false);
                }
                else
                {
                    tempItemCarrot.SetActive(true);
                }

                if (_myPL.playerItems[8] != 8)
                {
                    tempItemApple.SetActive(false);
                }
                else
                {
                    tempItemApple.SetActive(true);
                }

                if (_myPL.playerItems[6] != 6)
                {
                    tempItemHat.SetActive(false);
                }
                else
                {
                    tempItemHat.SetActive(true);
                }

                tempItemRibbon.SetActive(false);
                
                StartCoroutine(getItems());
    
            }
        }
    }
}
