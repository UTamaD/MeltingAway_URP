using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    public int itemCode;
    public GameObject InteractionUI;
    
    public AudioSource getItem;
    
    // Start is called before the first frame update

    //private StarterAssets.StarterAssetsInputs myInput;


    // Update is called once per frame


    private void OnTriggerExit(Collider other)
    {
        if (InteractionUI != null)
        {

            InteractionUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        
        if (other.tag == "Player")
        {
 

            other.gameObject.GetComponent<StarterAssets.StarterAssetsInputs>().interaction = false;

        }
        
    }


    private void OnTriggerStay(Collider other)
    {


        if (other.tag == "Player")
        {

            if (InteractionUI != null)
            {

                InteractionUI.SetActive(true);
            }
            if (other.gameObject.GetComponent<StarterAssets.StarterAssetsInputs>().interaction == true)
            {

                if(getItem!=null)
                {
                    getItem.Play();
                }
                
                if ((itemCode == 3 || itemCode == 4) && other.gameObject.GetComponent<PlayerManager>().playerItems[3] == 3)
                {

                    other.gameObject.GetComponentInParent<PlayerManager>().playerItems[4] = 4;
                }
                else if((itemCode == 3 || itemCode == 4))
                {

                    other.gameObject.GetComponentInParent<PlayerManager>().playerItems[3] = 3;

                }
                else
                {
                    other.gameObject.GetComponentInParent<PlayerManager>().playerItems[itemCode] = itemCode;
                }


                
                
                other.gameObject.GetComponent<StarterAssets.StarterAssetsInputs>().interaction = false;
                InteractionUI.SetActive(false);
                Destroy(gameObject);
            }
            other.gameObject.GetComponent<StarterAssets.StarterAssetsInputs>().interaction = false;

        }

    }
}
