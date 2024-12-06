using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gameEnd : MonoBehaviour
{
    public GameObject myTimelineStart;
    public string endSceneName = "endingFinal";
    public GameObject _myPL;
    public float duration = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    IEnumerator callEnd()
    {
        if (myTimelineStart != null)
        {
            myTimelineStart.SetActive(true);


        }
        _myPL.SetActive(false);
        yield return new WaitForSeconds(duration);


        SceneManager.LoadScene(endSceneName);
        yield return null;


    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {


            StartCoroutine(callEnd());


        }

    }
}
