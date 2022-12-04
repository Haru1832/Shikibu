using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ShikibuAttribute : Attribute
{
    public ShikibuAttribute()
    {
    }

    public ShikibuAttribute(string methodName) => Name = methodName;

    public ShikibuAttribute(ShikibuEnum optional) => Optional = optional;

    public ShikibuAttribute(string methodName, ShikibuEnum optional)
    {
        Name = methodName;
        Optional = optional;
    }
    
    public string Name { get; set; }
    
    public ShikibuEnum Optional { get; set; }
    
}