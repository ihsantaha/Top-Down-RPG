using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticClass
{
    public static int       CurrentScene    { get; set; }
    public static int       PreviousScene   { get; set; }
    public static Vector3   CurrentPosition { get; set; }

    public static int       Health          { get; set; }
    public static int       Mana            { get; set; }
    public static int       Strength        { get; set; }
    public static int       Defense         { get; set; }
    public static string    Special         { get; set; }
}
