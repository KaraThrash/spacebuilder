﻿using UnityEngine;
using System.Collections;

public class DieInTime : MonoBehaviour {

    public float lifeTime;
    public float timer;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Destroy(this.gameObject);
        }

    }
}
