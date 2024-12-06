using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Iwantsleep : MonoBehaviour
{
    public GameObject branch;
    public GameObject carrot;
    public GameObject ball;


    public long Ftime;
    public long Stime;
    public long GetBtime;
    public long GetC;

    private bool timeCheck1 = true;
    private bool timeCheck2 = true;
    private bool timeCheck3 = true;

    private bool saveOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        timeCheck1 = true;
        timeCheck2 = true;
        timeCheck3 = true;

        saveOnce = true;

        Ftime = 0; Stime = 0; GetBtime = 0;
        GetC = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCheck1 && branch != null && branch.activeSelf == true)
        {
            timeCheck1 = false;
            GetBtime = gameObject.GetComponent<TimeManger>().getTime();
        }
        if (timeCheck2 &&  carrot != null && carrot.activeSelf == true)
        {
            timeCheck2= false;
            GetC = gameObject.GetComponent<TimeManger>().getTime();
        }
        if (timeCheck3 &&  ball != null && ball.activeSelf == true)
        {
            timeCheck3 = false;
            Ftime = gameObject.GetComponent<TimeManger>().getTime();
        }
        Scene scene = SceneManager.GetActiveScene();
        if (saveOnce && (scene.name == "ending" || scene.name == "gameover"))
        {
            saveOnce = false;
            Stime = gameObject.GetComponent<TimeManger>().getTime();
            gameObject.GetComponent<SaveCSV>().SaveToCsv();
        }

    }
}
