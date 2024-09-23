using UnityEngine;
using Variable;

public class SpawnGun : MonoBehaviour
{
    [SerializeField] GameObject _machineGun, _flameThrower, _grenadeLauncher;
    
        public void SelectMachineGun()
        {
            if (Variables.coins >= 50)
            {
                Variables.coins -= 50;
                Variables._banner.enabled = false;
                _machineGun = Instantiate(_machineGun, transform.position, Quaternion.Euler(0, 0, 270),
                    GameObject.Find(Variables.active_gunplace).GetComponent<Transform>());
                gameObject.SetActive(false);
            }
        }
        
        public void SelectFlameThrower()
        {
            if (Variables.coins >= 100)
            {
                Variables.coins -= 100;
                Variables._banner.enabled = false;
                _flameThrower = Instantiate(_flameThrower, transform.position, Quaternion.Euler(0, 0, 140),
                    GameObject.Find(Variables.active_gunplace).GetComponent<Transform>());
                gameObject.SetActive(false);
            }
        }
        
        public void SelectGrenadeLauncher()
        {
            if (Variables.coins >= 200)
            {
                Variables.coins -= 200;
                Variables._banner.enabled = false;
                _grenadeLauncher = Instantiate(_grenadeLauncher, transform.position, Quaternion.Euler(0, 0, 25),
                    GameObject.Find(Variables.active_gunplace).GetComponent<Transform>());
                gameObject.SetActive(false);
            }
        }
}
