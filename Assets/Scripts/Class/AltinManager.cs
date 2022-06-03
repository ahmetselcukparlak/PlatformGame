using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltinManager : MonoBehaviour
{
   private int _altin;
   public int Altin
    {
        get
        {
            return _altin;
        }
        set
        {
            _altin = value;
        }
    }

    public void AltinAzalt(int altin=1)
    {
        Altin -= altin;
    }
    public void AltinArttir(int altin = 1)
    {
        Altin += altin;
    }
}
