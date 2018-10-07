using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class barrier : MonoBehaviour {
    public GameObject born;
    public AudioClip die;
void OnTriggerEnter2D(Collider2D co) {
    if (co.name == "character")
    {
       Instantiate(born, co.transform.position, co.transform.rotation);
        AudioSource.PlayClipAtPoint(die,transform.position);
          StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
        {
            Destroy(co.gameObject);
            SceneManager.LoadScene (1);
        }, 0.5f));
    }
    }
}

