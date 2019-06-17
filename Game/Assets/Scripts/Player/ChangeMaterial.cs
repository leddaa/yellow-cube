using UnityEngine;
using UnityEngine.Events;


public class ChangeMaterial : MonoBehaviour
{

    public UnityEvent Event;

    

    public Material material;
    public Material material2;
    public Material material3;
   

    public MeshRenderer meshrenderer;
    public int MaterialCounter = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        if (Event == null)
        {
            Event = new UnityEvent();

        }
        Event.AddListener(Ping);
    }

    void Ping()
    {
        Debug.Log("Works");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            
            Renderer rend = GetComponent<Renderer>();
            if (MaterialCounter == 0)
            {
                rend.material = material;
                MaterialCounter += 1;
            }
            else if (MaterialCounter == 1)
            {
                rend.material = material2;
                MaterialCounter += 1;
            }
            else if (MaterialCounter == 2)
            {
                rend.material = material3;
                MaterialCounter = 0;
            }
            
         

        }
    }
}
