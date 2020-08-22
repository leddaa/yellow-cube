using UnityEngine;
using UnityEngine.UI;

public class Cheat : MonoBehaviour
{
    public Material MaterialCheater { get; set; }
    public float UpwardForce;
    public Rigidbody Body;

    private void Rotate()
    {
        var toggle = this.GetComponent<RandomRotate>().enabled;

        if (toggle == true)
        {
            this.GetComponent<RandomRotate>().enabled = false;
        }
        else
        {
            this.GetComponent<RandomRotate>().enabled = true;
        }
    }

    private void Update()
    {
        if (Input.GetKey("f"))
        {
            Body.AddForce(0, UpwardForce * Time.deltaTime, 0 );
        }

        if (Input.GetKeyDown("g"))
        {
            Rotate();
        }

    }
}
