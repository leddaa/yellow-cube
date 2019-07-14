using UnityEngine;

public class MuteGame : MonoBehaviour
{

    public bool isplaying;

    void Update()
    {

        if (Input.GetKeyDown("p"))
        {
            if(isplaying == true)
            {
                isplaying = false;
               
                GameObject.FindGameObjectWithTag(Tags.MUSIC).GetComponent<AudioSource>().Stop();
            }
            else
            {
                isplaying = true;
                GameObject.FindGameObjectWithTag(Tags.MUSIC).GetComponent<AudioSource>().Play();
            }
        }
    }

}
