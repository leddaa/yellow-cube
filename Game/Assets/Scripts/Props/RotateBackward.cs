﻿using UnityEngine;

public class RotateBackward : MonoBehaviour
{

    private float speed = 100f;

    void Update()
    {
        transform.Rotate(Vector3.back * speed * Time.deltaTime);
    }

}