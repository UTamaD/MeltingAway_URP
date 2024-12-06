using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class middleCut : MonoBehaviour
{

    public GameObject S1;
    public GameObject S2;
    public GameObject _myUI;

    public float duration = 20f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nextScene());
    }

    IEnumerator nextScene()
    {

        yield return new WaitForSeconds(duration);
        S1.SetActive(false);
        S2.SetActive(false);
        _myUI.SetActive(true);
        yield return null;
    }
}
