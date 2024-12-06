using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class tempScene : MonoBehaviour
{

    public float duration = 20f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(next());
    }
    IEnumerator next()
    {

        yield return new WaitForSeconds(duration);

        SceneManager.LoadScene("RacingMap");
    }


}
