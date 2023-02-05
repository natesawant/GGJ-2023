using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("tutorial scene end.");

        if(c.gameObject.tag == "Player")
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
