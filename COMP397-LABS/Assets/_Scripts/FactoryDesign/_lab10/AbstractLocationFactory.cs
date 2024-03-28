using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class AbstractLocationFactory: MonoBehaviour
{
    public abstract ILocation CreateLocation();
}