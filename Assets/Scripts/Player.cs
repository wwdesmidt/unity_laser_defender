﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;

    [SerializeField] GameObject lazerBulletPrefab;

    [SerializeField] float lazerBulletSpeed = 10f;

    [SerializeField] float fireSpeed = 0.5f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    Coroutine firing;

    // Use this for initialization
    void Start ()
    {
        SetUpMoveBoundaries();

	}



    // Update is called once per frame
    void Update ()
    {
        Move();
        Fire();
		
	}

    private void Fire()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            firing = StartCoroutine(fireContinuously());
        }

        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firing);
        }
    }

    private IEnumerator fireContinuously()
    {
        while(true)
        {
            GameObject lazerBullet = Instantiate(lazerBulletPrefab, transform.position, Quaternion.identity) as GameObject;

            lazerBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, lazerBulletSpeed);

            yield return new WaitForSeconds(fireSpeed);

        }
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float newXPos = Mathf.Clamp(transform.position.x + deltaX,xMin,xMax);

        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float newYPos = Mathf.Clamp(transform.position.y + deltaY,yMin,yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }
}
