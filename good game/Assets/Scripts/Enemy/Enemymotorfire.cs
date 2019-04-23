using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymotorfire : MonoBehaviour
{
    public float TimeBetweenShotsInSeconds;
    public float AngleOffset;


    public GameObject LaserPrefab;

    private float timer;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 
        if (timer >= TimeBetweenShotsInSeconds)
        {
            timer = 0;
            var direction = Aim();
            Fire(direction);
        }
    }

    private Vector3 Aim()
    {
        var direction = player.transform.position - transform.position;
        return Quaternion.AngleAxis(UnityEngine.Random.Range(-AngleOffset, AngleOffset), Vector3.up) * direction;
    }

    private void Fire(Vector3 direction)
    {
        Debug.Log("Fire!!!");
        GameObject las = Instantiate(LaserPrefab, transform.position, Quaternion.LookRotation(direction));
        las.SetActive(true);
    }
}

