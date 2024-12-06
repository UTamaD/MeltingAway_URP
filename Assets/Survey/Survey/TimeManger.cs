using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class TimeManger : MonoBehaviour
{


 

public long ScenePlayTime;
    public long getBranchTime;
    public long getCarrotTime;

    System.Diagnostics.Stopwatch myTime;
    // Start is called before the first frame update
    void Start()
    {
        myTime = new System.Diagnostics.Stopwatch();

        myTime.Start();

        
    }

    private void Update()
    {

    }

    public long getTime()
    {
        myTime.Stop();
        
        long temp = myTime.ElapsedMilliseconds;
        myTime.Start();
       return temp;
    }

}
