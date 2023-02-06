using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gearmanager : MonoBehaviour
{
    public Text levelcomplete;

    private void Update()
    {
        gearscollected();

    }


    public void gearscollected()
    {
        if(transform.childCount==0)
        {
            Debug.Log("no quedan engranajes");
            levelcomplete.gameObject.SetActive(true);
            Invoke("changescene",1);
        }



    }

    void changescene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }

}
