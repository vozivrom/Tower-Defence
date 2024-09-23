using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Variable;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    private Transform Bullets;
    private byte gun;
    private float speed, range;
    private string gunTag;
    public byte gunHealth = 30;
    private bool isShoot = false;
    private void Start()
    {
        GameObject.Find(Variables.active_gunplace).GetComponent<Button>().interactable = false;
        Bullets = GameObject.Find("Bullets").GetComponent<Transform>();
        gunTag = tag;
        switch (gunTag)
        {
            case "MachineGun":
                gun = 0;
                range = 12 - transform.position.x;
                break;
            case "FlameThrower":
                gun = 1;
                break;
            case "GrenadeLauncher":
                gun = 2;
                break;
        }
        speed = Variables.speed[gun];
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.right, out hit, range))
        {
            if (hit.collider.tag == "Enemy" && !isShoot)
            {
                StartCoroutine(Shooting());
                isShoot = true;
            }
            //Debug.Log(hit.transform.position +  hit.collider.name);
        }
        Debug.DrawRay(transform.position, new Vector3(range,0, 0), Color.green);
    }

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(speed);
        Instantiate(_bullet, transform.position, Quaternion.identity, Bullets);
        isShoot = false;
    }
}
