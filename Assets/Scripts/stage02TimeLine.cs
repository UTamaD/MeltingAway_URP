using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage02TimeLine : MonoBehaviour
{
    public GameObject timeLine;
    public GameObject mesh1;
    public GameObject mesh2;

    public GameObject player;
    public PlayerManager _myPM;
    public StarterAssets.ThirdPersonController _myTP;
    public Animator _myAnim;


    public float deadTiming = 0.6f;

    bool timelineOnce = true;

    IEnumerator callTimeLine()
    {

        if(timeLine != null)
        {
            timeLine.SetActive(true);
        }

        mesh1.SetActive(false);

        yield return new WaitForSeconds(2.0f);
        mesh2.SetActive(true);

        _myTP._animator = _myAnim;
        

        yield return null;

    }
    // Start is called before the first frame update
    void Start()
    {
        _myPM = player.GetComponent<PlayerManager>();    }

    // Update is called once per frame
    void Update()
    {
        

        if(_myPM.size< deadTiming)
        {
            _myPM.playerItems[3] = -1;
            _myPM.CanJump = false;
            StartCoroutine(callTimeLine());
        }
    }
}
