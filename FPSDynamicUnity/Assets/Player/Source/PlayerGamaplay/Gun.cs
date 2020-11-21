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
    protected float TimeReload = 4f;
    [SerializeField]
    protected int nbLoaderBulletMax = 10;
    protected int nbLoaderBullet;
    protected int nbBagBullet = 30;

    protected UIPlayer UI;

    // Start is called before the first frame update
    void Start()
    {
        UI = FindObjectOfType<UIPlayer>();
        UI.CurrentNbBulletDelegate(nbLoaderBulletMax);
        UI.MaxNbBulletDelegate(nbLoaderBulletMax);
        nbLoaderBullet = nbLoaderBulletMax;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && nbLoaderBullet > 0)
        {
            InstantiateBullet();
        }

        if (Input.GetButtonDown("Reload") && nbLoaderBullet != nbLoaderBulletMax && nbBagBullet > 0)
        {
            Debug.Log("Reload");
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

        UI.CurrentNbBulletDelegate(nbLoaderBullet);
    }

    IEnumerator WaitReloadGun()
    {
        yield return new WaitForSeconds(TimeReload);

        ReloadGun();
    }
}
