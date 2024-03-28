using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FactoryGrass : AbstractLocationFactory
{
    public override ILocation CreateLocation()
    {
        return new LocationGrass();
    }
}
