using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gl_dressup : MonoBehaviour
{
    Animator anim;

    public int IdAni;

    public Transform HairGroup;
    public Transform UpperGroup;
    public Transform DownGroup;
    List<GameObject> Hairs = new List<GameObject>();
    List<GameObject> Uppers = new List<GameObject>();
    List<GameObject> Downs = new List<GameObject>();

    public int IDxHair = 0;
    public int IDxUpper = 0;
    public int IDxDown = 0;
    int OldIDxHair = 0;
    int OldIDxUpper = 0;
    int OldIDxDown = 0;
    void Start()
    {
        /*
        AddDress(HairGroup, Hairs);
        AddDress(UpperGroup, Uppers);
        AddDress(DownGroup, Downs);
        */
        foreach (Transform hair in HairGroup)
        {
            hair.gameObject.SetActive(false);
            Hairs.Add(hair.gameObject);
        }
        foreach (Transform upper in UpperGroup)
        {
            upper.gameObject.SetActive(false);
            Uppers.Add(upper.gameObject);
        }
        foreach (Transform down in DownGroup)
        {
            down.gameObject.SetActive(false);
            Downs.Add(down.gameObject);
        }
        //LoadState();

    }

    void Update()
    {
        /*
        ShowDress(Hairs,  IDxHair);
        ShowDress(Uppers, IDxUpper);
        ShowDress(Downs,  IDxDown);
        */

        HairCon();
        UpperCon();
        DownsCon();

        //SvaeState();
    }
    void HairCon()
    {
        Hairs[OldIDxHair].SetActive(false);
        Hairs[IDxHair].SetActive(true);
        OldIDxHair = IDxHair;
    }
    void UpperCon()
    {
        Uppers[OldIDxUpper].SetActive(false);
        Uppers[IDxUpper].SetActive(true);
        OldIDxUpper = IDxUpper;
    }
    void DownsCon()
    {
        Downs[OldIDxDown].SetActive(false);
        Downs[IDxDown].SetActive(true);
        OldIDxDown = IDxDown;
    }

    public void AdIdHair()
    {
        IDxHair = IDxHair + 1;
        if(IDxHair >= 9)
        {
            IDxHair = 0;
        }
    }
    public void AdIdUpper()
    {
        IDxUpper = IDxUpper + 1;
        if (IDxUpper >= 6)
        {
            IDxUpper = 0;
        }
    }
    public void AdIdDown()
    {
        IDxDown = IDxDown + 1;
        if (IDxDown >= 6)
        {
            IDxDown = 0;
        }
    }

    public void AddIdAni()
    {
        anim.SetInteger("IdexAnimation", IdAni++);
        if (IdAni >= 3)
        {
            IdAni = 0;
        }
    }
    public void SvaeState()
    {
        PlayerPrefs.SetInt("hair", IDxHair);
        PlayerPrefs.SetInt("upper", IDxUpper);
        PlayerPrefs.SetInt("down", IDxDown);
    }

    public void LoadState()
    {
        IDxHair = PlayerPrefs.GetInt("hair");
        IDxUpper = PlayerPrefs.GetInt("upper");
        IDxDown = PlayerPrefs.GetInt("down");
    }
}
/*
    void AddDress(Transform group, List<GameObject> itemList)
    {
        foreach (Transform item in group)
        {
            item.gameObject.SetActive(true);
            itemList.Add(item.gameObject);
        }
    }

    void ShowDress(List<GameObject> group, int idx)
    {
        for (int i = 0; i < Hairs.Count; i++)
        {
            Hairs[i].SetActive(false);
        }
        Hairs[idx].SetActive(true);
    } */
