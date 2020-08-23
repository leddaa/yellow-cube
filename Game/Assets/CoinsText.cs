using TMPro;
using UnityEngine;

public class CoinsText : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = Store.GetIntOrDefault(StoreKeys.Coins).ToString();
    }

}
