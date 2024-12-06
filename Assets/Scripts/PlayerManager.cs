using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.DualShock;

public class PlayerManager : MonoBehaviour
{
    [Header("Player")]
    [Tooltip("player remain time ")]
    public float snowManLife = 300.0f;
    [Tooltip("player scale ")]
    public float scale = 2.0f;
    public float mulScale = 0.025f;
    public float melting = 1.0f;
    [Tooltip("player sight")]
    public float sight = 1.0f;
    public GameObject[] items = new GameObject[6];
    private StarterAssets.StarterAssetsInputs _input;
    //public bool isRacing = false;

    public GameObject branchManager;
    public GameObject savePoint;
    public int itemSize = 5;

    //public FullScreenPassRendererFeature FS;
    //public RenderPipelineAsset rains;
    public bool CanJump;
    public int eyeNum;
    public  bool isRace = true;
    public float size;
    public int[] playerItems = new int[6];
    private Collider _collider;

    float curTime = 0.0f;

    public float speed = 1f;
    public float amplitude = 1f;
    public float duration = 0.25f;

    public GameObject EndTime;

    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        //FS.passMaterial.SetFloat("OnRain", 0.0f);
        //FS.passMaterial.SetFloat("_OnRain", 0.0f);

        _input = GetComponent<StarterAssets.StarterAssetsInputs>();
        Scene myS = SceneManager.GetActiveScene();



        if (isRace)
        {
            for (int i = 0; i < playerItems.Length; i++)
            {
                playerItems[i] = i;
            }
        }
        else
        {

            for (int i = 0; i < playerItems.Length; i++)
            {
                playerItems[i] = -1;
            }
        }


    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        ScaleTrans();
        SetItem();
        aging();
        if (Input.GetKey(KeyCode.L)|| _input.save == true)
        {
            Debug.Log("try Move");
            _input.save = false;
            gameObject.transform.position = savePoint.transform.position;
        }

        if (snowManLife < 20.0f)
        {
            //FS.passMaterial.SetFloat("OnRain", 1.0f);
            //FS.passMaterial.SetFloat("_OnRain", 1.0f);
        }
        if(isRace == false)
        {
            if (playerItems[3] == 3 && playerItems[4] == 4)
            {
                CanJump = true;
                if (branchManager != null)
                {

                    branchManager.SetActive(false);



                }
            }
            else
            {
                CanJump = false;
            }

        }
        else
        {
            if (playerItems[3] == 3 || playerItems[4] == 4)
            {
                CanJump = true;
            }
            else
            {
                CanJump = false;
            }
        }




        if (playerItems[0] == 0 && playerItems[1] == 1)
        {
            eyeNum = 2;
        }
        else if (playerItems[0] == 0 || playerItems[1] == 1)
        {
            eyeNum = 1;
        }
        else
        {
            eyeNum = 0;
        }
    }
    IEnumerator gameOver()
    {
        if (EndTime != null)
        {
            EndTime.SetActive(true);
            
        }
        yield return new WaitForSeconds(15.0f);
        if (EndTime != null)
        {
            SceneManager.LoadScene("title");
        }
    }
    void aging()
    {

        curTime += Time.deltaTime * melting;
        //Debug.Log("curTime" + curTime);
        float localsize = 1.0f;
        if (isRace == true)
        {
            localsize = Mathf.Lerp(snowManLife, 50.0f, curTime / snowManLife);
        }
        else
        {
            localsize = Mathf.Lerp(50.0f, 100.0f, curTime / 200.0f);
        }
        

        if (isRace)
        {
            size = localsize / 300.0f;

            
        }
        else
        {
            size = localsize / 50.0f;
        }
        if (isRace == true)
        {
            if (size < 0.167f)
            {


                StartCoroutine(gameOver());

            }
            if (items[6] != null && size < 0.83f && items[6].activeSelf == true)
            {

                items[6].SetActive(false);
                playerItems[6] = -1;


            }
            if (items[7] != null && size < 0.83f && items[7].activeSelf == true)
            {

                items[7].SetActive(false);
                playerItems[7] = -1;


            }
            if (items[8] != null && size < 0.83f && items[8].activeSelf == true)
            {

                items[8].SetActive(false);
                playerItems[8] = -1;


            }
            if (size < 0.7f && items[2].activeSelf == true)
            {
                items[2].SetActive(false);
                playerItems[2] = -1;

            }
            if (size < 0.578f && items[4].activeSelf == true)
            {
                items[4].SetActive(false);
                playerItems[4] = -1;
            }

            if (size < 0.44f && (items[10].activeSelf == true || items[9].activeSelf == true))
            {
                items[10].SetActive(false);
                items[9].SetActive(false);
                playerItems[9] = -1;
                playerItems[10] = -1;
            }

            if (size < 0.32f && items[0].activeSelf == true)
            {
                items[0].SetActive(false);
                playerItems[0] = -1;
            }

            if (size < 0.23f && items[1].activeSelf == true)
            {
                items[1].SetActive(false);
                playerItems[1] = -1;
            }

        }
 




        //Debug.Log("size : " + size);
        //Debug.Log("snowManLife" + snowManLife);
        //Debug.Log("local : " + localsize);

        if(isRace == true)
        {
            if (snowManLife > 0.0f && scale > 0.9) scale = localsize * mulScale;
        }
        else
        {
            if (snowManLife > 0.0f && scale < 1.5f) scale = localsize * mulScale;
            //size = 1.0f - size;
        }
        
    }

    private void ScaleTrans()
    {
        GetComponent<Transform>().localScale = new Vector3(scale, scale, scale);
    }

    private void SetItem()
    {
        if (items[6].activeSelf == true)
        {
            if (playerItems[7] == 7 || playerItems[8] == 8)
            {
                playerItems[6] = -1;
            }
        }
        else if (items[7].activeSelf == true)
        {
            if (playerItems[6] == 6 || playerItems[8] == 8)
            {
                playerItems[7] = -1;
            }
        }
        else if (items[8].activeSelf == true)
        {
            if (playerItems[7] == 7 || playerItems[6] == 6)
            {
                playerItems[8] = -1;
            }
        }

        for (int i = 0; i < playerItems.Length; i++)
        {

            if (playerItems[i] == i)
            {
                items[i].SetActive(true);
            }
            else
            {
                items[i].SetActive(false);
            }

        }
    }
    public void LongVib()
    {
        StartCoroutine(LongVibrate());
    }

    IEnumerator LongVibrate()
    {
        Gamepad gamepad = Gamepad.current;
        if (gamepad == null)
        {
            Debug.LogError("Gamepad not found!");
            yield break;
        }

        gamepad.SetMotorSpeeds(speed*3, speed*3);

        yield return new WaitForSeconds(duration*4);

        gamepad.SetMotorSpeeds(0f, 0f);
    }

    public void callhitVib()
    {

        StartCoroutine(hitVib());


    }
    public void Vib()
    {
        StartCoroutine(Vibrate());
    }


    IEnumerator hitVib()
    {

        if(hitEffect != null)
        {
            hitEffect.SetActive(true);
        }
        
        Gamepad gamepad = Gamepad.current;
        if (gamepad == null)
        {
            //Debug.Log("Gamepad not found!");
            yield break;
        }

        gamepad.SetMotorSpeeds(speed * 2, speed * 2);

        yield return new WaitForSeconds(duration);
        gamepad.SetMotorSpeeds(0f, 0f);

        yield return new WaitForSeconds(duration);
        

        if (hitEffect != null)
        {
            hitEffect.SetActive(false);
        }

    }
    IEnumerator stay()
    {
        yield return new WaitForSeconds(0.5f);
    }
    IEnumerator Vibrate()
    {

        //DualShockGamepad gamepad = DualShockGamepad.current;

        Gamepad gamepad = Gamepad.current;
        if (gamepad == null)
        {
            Debug.Log("Gamepad not found!");
            yield break;
        }

        gamepad.SetMotorSpeeds(speed*2, speed*2);

        yield return new WaitForSeconds(duration);

        gamepad.SetMotorSpeeds(0f, 0f);
    }



}
