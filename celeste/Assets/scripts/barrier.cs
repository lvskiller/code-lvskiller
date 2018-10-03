using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class barrier : MonoBehaviour {

public Rigidbody2D m_string;
void OnTriggerEnter2D(Collider2D co) {
    if (co.name == "character")
    {
        Destroy(co.gameObject);
        SceneManager.LoadScene (0);
    }
}

}
