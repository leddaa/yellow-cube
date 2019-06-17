using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacterScript : MonoBehaviour
{

    public Mesh[] mMeshes;

    private MeshFilter mFilter;

    void Awake()
    {
        mFilter = GetComponent<MeshFilter>();
    }

    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            mFilter.mesh = mMeshes[0];
        }   
    }
    
 }


