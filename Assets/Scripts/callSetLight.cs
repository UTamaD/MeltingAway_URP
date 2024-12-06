using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callSetLight : MonoBehaviour
{
    public GameObject lightManager;
    public PlayerManager _myPL;

    private void Start()
    {
        _myPL = gameObject.GetComponent<PlayerManager>();
    }
    void Update()
    {
        if(_myPL!=null)
        {
            if(_myPL.CanJump == true &&  (_myPL.playerItems[2] == 2 && (_myPL.playerItems[6] == 6 || _myPL.playerItems[7] == 7 || _myPL.playerItems[8] == 8))
                )
            {
                lightManager.GetComponent<lightManager>().setLight();
            }
        }
    }
}
