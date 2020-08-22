using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public GameObject pickupEffect;


    private void OnTriggerEnter(Collider other)
    {
        
        //if (other.gameObject.tag == Tags.PLAYER)
        //{
        //    gameObject.GetComponent<BoxCollider>().enabled = false;
        //    transform.GetChild(0).gameObject.SetActive(false);
        //    pickupEffect.GetComponent<ParticleSystem>().Play(true);

        //    int totalYCCoins = GameObject.FindGameObjectWithTag(Tags.DATA_STORE).GetComponent<Store>().GetInt(DatastoreKeys.TOTAL_YC_COINS, 0);
        //    Debug.Log("Total YC Coins before: " + totalYCCoins);
        //    GameObject.FindGameObjectWithTag(Tags.DATA_STORE).GetComponent<Store>().SetInt(DatastoreKeys.TOTAL_YC_COINS, totalYCCoins + 1);
        //    Debug.Log("Total YC Coins after: " + GameObject.FindGameObjectWithTag(Tags.DATA_STORE).GetComponent<Store>().GetInt(DatastoreKeys.TOTAL_YC_COINS, 0));
        //}
    }
}
