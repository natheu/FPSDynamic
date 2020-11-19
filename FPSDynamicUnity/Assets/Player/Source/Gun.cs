using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabBullet;
    [SerializeField]
    private Transform spawnBullet;
    [SerializeField]
    private int nbLoaderBulletMax = 10;
    private int nbLoaderBullet;
    private int nbBagBullet = 30;

    // Start is called before the first frame update
    void Start()
    {
        nbLoaderBullet = nbLoaderBulletMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && nbLoaderBullet > 0)
        {
           Instantiate(prefabBullet, spawnBullet.position, spawnBullet.rotation);
            nbLoaderBullet--;
        }

        ReloadGun();
    }

    void ReloadGun()
    {
        if (nbLoaderBullet == nbLoaderBulletMax)
            return;
        if (Input.GetButtonDown("Reload"))
        {
            int nbBulletAdd = nbLoaderBulletMax - nbLoaderBullet;
            nbLoaderBullet += nbBulletAdd;
            nbBagBullet -= nbBulletAdd;
        }
    }
}
