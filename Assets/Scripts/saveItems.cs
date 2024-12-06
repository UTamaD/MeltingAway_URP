using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveItems : MonoBehaviour
{
    public GameObject _Player;

    public int[] items;

    private PlayerManager _myPM;

    public bool copyOnce = true;
    public bool tempCopy = true;
    public bool isRacing = false;
    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.Find("Player");
        _myPM = _Player.GetComponent<PlayerManager>();
        isRacing = _myPM.isRace;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (_Player == null)
        {
            _Player = GameObject.Find("Player");

            if(_Player != null)
            {
                _myPM = _Player.GetComponent<PlayerManager>();
                if(isRacing==true)
                {



                }
                else
                {

                    isRacing = _myPM.isRace;

                }
                
            }
         
        }
        else
        {
            if (isRacing == false)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    items[i] = _myPM.playerItems[i];

                }
            }
        }

        if(tempCopy == true)
        {
            if(isRacing == true)
            {
                if (SceneManager.GetActiveScene().name == "VillageMapTemp")
                {

                    tempCopy = false;
                    for (int i = 0; i < items.Length; i++)
                    {
                        _myPM.playerItems[i] = items[i];

                    }
                }
            }

        }
        else
        {

            if (copyOnce == true && isRacing == true)
            {
                

                if (SceneManager.GetActiveScene().name != "VillageMapTemp")
                {
                    copyOnce = false;

                    for (int i = 0; i < items.Length; i++)
                    {
                        _myPM.playerItems[i] = items[i];

                    }
                }


            }
        }
        
  

        
    }


}





    

