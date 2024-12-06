using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalLight : MonoBehaviour
{
    public GameObject _player;
    private PlayerManager _playerManager;
    private Light _light;


    public Color startColor = new Color(0.0f, 0.0f, 1.0f);
    public Color endColor = new Color(1.0f, 1.0f, 1.0f);


    // Start is called before the first frame update
    void Start()
    {
        _playerManager = _player.GetComponent<PlayerManager>();
        _light = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float size = _playerManager.size;
        float RValue = Mathf.Lerp(120f, 0f, size);
        transform.rotation = Quaternion.Euler(new Vector3(RValue, -30.0f, 0));
        _light.color = Color.Lerp(endColor, startColor, size);
        _light.intensity = Mathf.Lerp(1.5f, 0.6f, size);

    }
}
