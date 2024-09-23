using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject _boss;
    [SerializeField] List<GameObject> _enemies = new List<GameObject>(3);
    private byte stripe, enemy;
    private float y;
    void Start()
    {
        for (int i = 0; i < 1; i++)
        {
            stripe = (byte)Random.Range(1, 5);
            switch (stripe)
            {
                case 1:
                    y = Random.Range(-4.5f, -3.8f);
                    break;
                case 2:
                    y = Random.Range(-2.7f, -1.85f);
                    break;
                case 3:
                    y = Random.Range(-0.75f, 0.1f);
                    break;
                case 4:
                    y = Random.Range(1.1f, 1.95f);
                    break;
                case 5:
                    y = Random.Range(2.9f, 3.75f);
                    break;
            }
            enemy = (byte)Random.Range(0, 2);
            Instantiate(_enemies[enemy], new Vector3(3, y, 0), Quaternion.Euler(0,0,180), GameObject.Find("Enemies").transform);
        }
    }

    void Update()
    {
        
    }
}
