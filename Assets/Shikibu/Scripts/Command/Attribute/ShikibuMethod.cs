using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ShikibuMethod : Attribute
{
    public ShikibuMethod()
    {
    }

    public ShikibuMethod(string methodName) => Name = methodName;

    public ShikibuMethod(ShikibuEnum optional) => Optional = optional;

    public ShikibuMethod(string methodName, ShikibuEnum optional)
    {
        Name = methodName;
        Optional = optional;
    }

    public string Name { get; set; } = null;
    
    public ShikibuEnum Optional { get; set; }
    
}