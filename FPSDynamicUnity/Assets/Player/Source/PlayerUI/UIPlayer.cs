using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    [SerializeField]
    private List<Gun> guns;
    private int currentGun;

    public delegate void NbBulletDelegate(int nbBullet);
    public NbBulletDelegate CurrentNbBulletDelegate;
    public NbBulletDelegate MaxNbBulletDelegate;

    [SerializeField]
    private Text nbBulletT;
    [SerializeField]
    private Image reloadCircle;

    private float reloadTimer;
    private float currentRealoadTimer;
    private bool reload = false;
    // Start is called before the first frame update
    void Start()
    {
        CurrentNbBulletDelegate = UpdateCurrentBulletT;
        MaxNbBulletDelegate = UpdateMaxBulletT;
        reloadCircle.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(reload)
       {
            currentRealoadTimer -= Time.deltaTime;
            reloadCircle.fillAmount = currentRealoadTimer / reloadTimer;

            if (currentRealoadTimer <= 0)
                reload = false;
       }
    }

    void UpdateCurrentBulletT(int nbBullet)
    {
        string t = nbBulletT.text;
        string[] split = t.Split('/');
        split[0] = nbBullet.ToString();
        nbBulletT.text = split[0] + "/" + split[1];
    }
    void UpdateMaxBulletT(int nbBullet)
    {
        string t = nbBulletT.text;
        string[] split = t.Split('/');
        split[1] = nbBullet.ToString();
        nbBulletT.text = split[0] + "/" + split[1];
    }

    public void ReloadCircleAnimation(float waitTimer)
    {
        reloadTimer = waitTimer;
        currentRealoadTimer = waitTimer;
        reload = true;
        reloadCircle.enabled = true;
    }

    public void EndReloadCircleAnimation()
    {
        reloadCircle.fillAmount = 1;
        reloadCircle.enabled = false;
        reload = false;
    }

}
