using System.Collections;
using UnityEngine;
using Variable;
using GameManage;
using UnityEngine.UI;

namespace Enemies
{

    public class Enemy : MonoBehaviour
    {
        private float speed = 1;
        public float health = 50;
        private byte gun;
        private Collision other_dup;
        private bool isDamage = true;

        void Start()
        {

        }

        void FixedUpdate()
        {
            if (health <= 0)
            {
                Variables.coins += 25;
                Destroy(gameObject);
            }

            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
            if (transform.position.x < -12)
            {
                GameManager._gameOver.enabled = true;
            }
        }

        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.tag != "Enemy" && other.gameObject.tag != "Bullet")
            {
                speed = 0;
                other_dup = other;
                switch (other.gameObject.tag)
                {
                    case "MachineGun":
                        gun = 0;
                        break;
                    case "FlameThrower":
                        gun = 1;
                        break;
                    case "GrenadeLauncher":
                        gun = 2;
                        break;
                }

                if (isDamage)
                {
                    isDamage = false;
                    StartCoroutine(DamageGun());
                }
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if(other.gameObject.tag != "Enemy" && other.gameObject.tag != "Bullet") speed = 1;
            Debug.Log("exit");
        }

        IEnumerator DamageGun()
        {
            yield return new WaitForSeconds(1);
            if (other_dup.gameObject.GetComponent<Shoot>().gunHealth <= 0)
            {
                //GetComponentInParent<Button>().interactable = true;
                Destroy(other_dup.gameObject);
            }
            else
            {
                other_dup.gameObject.GetComponent<Animator>().Play("DamageGun");
                yield return new WaitForSeconds(0.5f);
                //other_dup.gameObject.GetComponent<Animator>().enabled = false;
                other_dup.gameObject.GetComponent<Shoot>().gunHealth -= 10;
                Debug.Log(other_dup.gameObject.GetComponent<Shoot>().gunHealth);
                isDamage = true;
            }
        }
    }
}
