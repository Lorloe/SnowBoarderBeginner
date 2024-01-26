using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrash = false;
    void OnTriggerEnter2D(Collider2D other) {
        crashEffect.Play();
        if(other.tag == "Ground" && !hasCrash){
            hasCrash = true;
            FindObjectOfType<PlayerController>().DisableControls();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", reloadDelay);
            //Debug.log("Hit ground");
        }
        else if(other.tag == "Rock" && !hasCrash){
            hasCrash = true;
            FindObjectOfType<PlayerController>().DisableControls();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", reloadDelay);
            //Debug.log("Hit rock");
        }
    }
    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
