using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    protected GameObject prefabBullet;
    [SerializeField]
    protected Transform spawnBullet;

    [SerializeField]
    protected ParticleSystem wuzzleFlash;

    [SerializeField]
    protected bool bulletSpawnCamera;
    [SerializeField]
    protected float distSpawn = 2f;

    [SerializeField]
    protected float TimeReload = 4f;
    bool isReloading = false;

    [SerializeField]
    protected int nbLoaderBulletMax = 10;
    protected int nbLoaderBullet;
    [SerializeField]
    protected int nbBagBullet = 30;

    protected UIPlayer UI;

    // Start is called before the first frame update
    void Start()
    {
        UI = FindObjectOfType<UIPlayer>();
        if (UI)
        {
            UI.CurrentNbBulletDelegate(nbLoaderBulletMax);
            UI.MaxNbBulletDelegate(nbLoaderBulletMax);
        }
        nbLoaderBullet = nbLoaderBulletMax;
        isReloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && nbLoaderBullet > 0)
        {
            InstantiateBullet();
            wuzzleFlash.Play();
        }

        if (Input.GetButtonDown("Reload") && nbLoaderBullet != nbLoaderBulletMax && nbBagBullet > 0 && !isReloading)
        {
            StartCoroutine("WaitReloadGun");
        }
    }

    protected virtual void InstantiateBullet()
    {

    }

    private void ReloadGun()
    {
        int nbBulletCanAdd = nbLoaderBulletMax - nbLoaderBullet;
        nbBagBullet -= nbBulletCanAdd;
        if (nbBagBullet < 0)
        {
            nbBulletCanAdd += nbBagBullet;
            nbBagBullet = 0;
        }
        nbLoaderBullet += nbBulletCanAdd;
        if (UI)
        {
            UI.CurrentNbBulletDelegate(nbLoaderBullet);
        }
        isReloading = false;
        UI.EndReloadCircleAnimation();
    }

    IEnumerator WaitReloadGun()
    {
        isReloading = true;
        UI.ReloadCircleAnimation(TimeReload);
        yield return new WaitForSeconds(TimeReload);

        ReloadGun();
    }
}
