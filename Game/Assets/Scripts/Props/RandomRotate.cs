﻿using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.back * 40f * Time.deltaTime);
        transform.Rotate(Vector3.left * 60f * Time.deltaTime);
        transform.Rotate(Vector3.up * 20f * Time.deltaTime);
    }
}
