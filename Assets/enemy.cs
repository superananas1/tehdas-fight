﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    public int Health;
    public GameObject endgame;
    playerHealth Playerhp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bullet")
        {
            if (Health <= 0)
            {
                
                    Destroy(gameObject);
                    endgame.gameObject.SetActive(false);

            }
          
            
            
            



        }

    }
    public void Youwon()
    {
        SceneManager.LoadScene("You win");
    }
}
