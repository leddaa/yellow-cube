using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerModel : MonoBehaviour
{
    private void ChangeMesh(GameObject pObject, Mesh pMesh)
    {
        if (pMesh == null) return;

        Mesh meshInstance = Instantiate(pMesh) as Mesh;

        pObject.GetComponent<MeshFilter>().mesh = meshInstance;
    }

    void Update()
    {
        if (Input.GetKeyDown("c"))
        {

           


        }
    }


}