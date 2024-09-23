using UnityEngine;
using UnityEngine.UI;
using Variable;

public class SpawnRing : MonoBehaviour
{
    public GameObject _gunRing;

    public void SpawnGunRing()
    {
        _gunRing.SetActive(true);
        _gunRing.transform.position = transform.position;
        Variables._banner.enabled = true;
        Variables.active_gunplace = name;
    }

    public void SpawnOptionsRing()
    {
        
    }
}