using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : Gun
{
    protected override void InstantiateBullet()
    {
        if (!bulletSpawnCamera)
            Instantiate(prefabBullet, spawnBullet.position, spawnBullet.rotation);
        else
        {
            Transform camTransform = Camera.main.transform;
            Instantiate(prefabBullet, camTransform.position + distSpawn * camTransform.forward, spawnBullet.rotation);
        }

        nbLoaderBullet--;
        if(UI)
            UI.CurrentNbBulletDelegate(nbLoaderBullet);
    }
}
