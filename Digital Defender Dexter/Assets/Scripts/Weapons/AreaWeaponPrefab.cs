using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class AreaWeaponPrefab : MonoBehaviour
{

    public AreaWeapon weapon;
    private Vector3 targetSize;
    private float timer;
    public List<Enemy> enemiesInRange;
    private float counter;

    void Start()
    {
        weapon = GameObject.Find("Area Weapon").GetComponent<AreaWeapon>();
        //Destroy(gameObject, weapon.duration);
        targetSize = Vector3.one * weapon.stats[weapon.weaponLevel].range;
        transform.localScale = Vector3.zero;
        timer = weapon.stats[weapon.weaponLevel].duration;
        AudioController.Instance.PlaySound(AudioController.Instance.areaWeaponSpawn);
    }

    void Update()
    {
        //grow and shrink
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetSize, Time.deltaTime * 3);
        //disappear only after shrinking
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            targetSize = Vector3.zero;
            
            if (transform.localScale.x == 0f)
            {
                Destroy(gameObject);
                AudioController.Instance.PlaySound(AudioController.Instance.areaWeaponDespawn);
            }
        }

        //damage enemies in range
        counter -= Time.deltaTime;

        if (counter <= 0)
        {
            counter = weapon.stats[weapon.weaponLevel].attackSpeed;
            for (int i = 0; i < enemiesInRange.Count; i++)
            {
                enemiesInRange[i].TakeDamage(weapon.stats[weapon.weaponLevel].damage);
            }
        }

}


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            enemiesInRange.Add(collider.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(collider.GetComponent<Enemy>());
        }
    }

}
