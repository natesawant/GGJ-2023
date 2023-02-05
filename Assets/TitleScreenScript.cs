using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    public TextMeshProUGUI title, subtitle, instruction;
    public float alphaRate = 0.5f;

    void Start() {
        Debug.Log("RESETTING ALPHA");
        title.alpha = 0;
        subtitle.alpha = 0;
        instruction.alpha = 0;
    }

    void Update() {
        Debug.Log("INCREASING ALPHA");
        if (title.alpha < 1) {
            Debug.Log("title: " + title.alpha);
            title.alpha += alphaRate * Time.deltaTime;
            title.alpha = Mathf.Clamp(title.alpha, 0, 1);
        } else if (subtitle.alpha < 1) {
            Debug.Log("subtitle: " + subtitle.alpha);
            subtitle.alpha += alphaRate * Time.deltaTime;
            subtitle.alpha = Mathf.Clamp(subtitle.alpha, 0, 1);
        } else if (instruction.alpha < 1) {
            Debug.Log("instruction: " + instruction.alpha);
            instruction.alpha += alphaRate * Time.deltaTime;
            instruction.alpha = Mathf.Clamp(instruction.alpha, 0, 1);
        } else {
            if (Input.anyKey) {
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}