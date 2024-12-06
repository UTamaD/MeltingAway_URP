using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRotate : MonoBehaviour
{
    public GameObject _player;
    private PlayerManager _playerManager;

    public float startV = -115.0f;
    public float endV = 120.0f;

    public float RValue;

    // Start is called before the first frame update
    void Start()
    {
        _playerManager = _player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        RValue = Mathf.Lerp(startV, endV, _playerManager.size);

        gameObject.GetComponent<RectTransform>().localRotation = Quaternion.Euler(new Vector3(0, 0, RValue));

       
       
    }
}
