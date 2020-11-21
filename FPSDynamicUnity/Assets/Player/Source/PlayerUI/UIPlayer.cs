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
    // Start is called before the first frame update
    void Start()
    {
        CurrentNbBulletDelegate = UpdateCurrentBulletT;
        MaxNbBulletDelegate = UpdateMaxBulletT;
    }

    // Update is called once per frame
    void Update()
    {
        
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


}
