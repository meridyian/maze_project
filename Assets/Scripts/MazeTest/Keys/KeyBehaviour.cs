using UnityEngine;

public class KeyBehaviour : MonoBehaviour
{
    
    // give the corresponding roomIDs for each key
    public int roomID;

    
    //collect the keys
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KeyCollector keyCollector = other.GetComponent<KeyCollector>();
            keyCollector.AddKey(roomID, gameObject);
            gameObject.SetActive(false);
        }
    }

}
