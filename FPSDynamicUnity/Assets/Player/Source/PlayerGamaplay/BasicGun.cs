using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : Gun
{
    protected override void InstantiateBullet()
    {
        Instantiate(prefabBullet, spawnBullet.position, spawnBullet.rotation);
        nbLoaderBullet--;
        UI.CurrentNbBulletDelegate(nbLoaderBullet);
    }
}
