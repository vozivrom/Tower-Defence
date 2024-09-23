using Enemies;
using UnityEngine;
using Variable;

public class Bullet : MonoBehaviour
{
    private float speed = 5;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        try
        {
            other.gameObject.GetComponent<Enemy>().health -= Variables.damage[0];
            //Debug.Log(other.gameObject.GetComponent<Enemy>().health);
            Destroy(gameObject);
        }catch{}
    }
}
