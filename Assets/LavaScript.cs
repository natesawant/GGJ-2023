using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaScript : MonoBehaviour
{
    public GameObject deadTint;
    public GameObject deadText;

    void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log(coll.tag);
        if (coll.tag == "Player") {
            RootPullAbility script = coll.gameObject.GetComponent<RootPullAbility>();
            Debug.Log(script.isInvulnerable());
            bool invulnerable = script.isInvulnerable();
            if (!invulnerable) {
                StartCoroutine(RestartScene(5f));
            }
        }
    }

    IEnumerator RestartScene(float time) {
        Debug.Log("RESTARTING IN " + time);
        deadText.SetActive(true);
        deadTint.SetActive(true);
        Time.timeScale = 0f;
        yield return new WaitForSeconds(time);  // or however long you want it to wait
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
