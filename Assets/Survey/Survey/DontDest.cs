using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDest : MonoBehaviour
{
    public static DontDest Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
