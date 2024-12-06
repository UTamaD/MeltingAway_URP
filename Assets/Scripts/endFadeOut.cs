using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endFadeOut : MonoBehaviour
{
    public GameObject endFade;
    public float duration = 15.0f;
    private Image myImage;
    private float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
        if (endFade != null)
        {
            myImage = endFade.GetComponent<Image>();

            if(myImage!=null)
            {
                StartCoroutine(fadeOut());
            }

        }
    }

    IEnumerator fadeOut()
    {

        Color Origin = myImage.color;
        Color target = new Color(Origin.r, Origin.g, Origin.b, 255f);

        

        while (time < duration)
        {
            float t = time / duration;

            myImage.color = Color.Lerp(Origin, target, t);




            time += Time.deltaTime;

            yield return null;
        }

        myImage.color = target;
        //yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("endingFinal");
    }

}
