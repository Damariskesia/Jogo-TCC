﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour{

    public Vector2 speed;
    public Rigidbody2D RockRigid;
    public Transform Aligator;
    public DuckController duck;

    // Use this for initialization
    void Start()
    {
        RockRigid = GetComponent<Rigidbody2D>();
        Aligator = GameObject.Find("Boss01").GetComponent<Transform>();
        duck = GameObject.Find("Duck").GetComponent<DuckController>();

        if (Aligator.localScale.x > 0)
        {
            RockRigid.velocity = speed * -1;
            Destroy(this.gameObject, 10f);

            
        }
        else if (Aligator.localScale.x < 0)
        {
            RockRigid.velocity = speed;
            Destroy(this.gameObject, 10f);
            gameObject.GetComponent<Transform>().localScale = this.gameObject.GetComponent<Transform>().localScale * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter2D(Collider2D col)    {
        
        if (col.CompareTag("Player"))
        {

            duck.Life -= 1;

            duck.knockbackCount = 1;
            Destroy(this.gameObject);

            if (RockRigid.transform.position.x > duck.DuckRigi.position.x)
            {
                duck.KnockDir = true;
            }
            else if (RockRigid.transform.position.x < duck.DuckRigi.position.x)
            {
                duck.KnockDir = false;
            }
        }

    }
}