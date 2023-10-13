using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    
   public static bool IsValid(this GameObject gameObject_)
    {
        bool isValid = gameObject_ == null || gameObject_ == default;
        return !isValid;
    }

    public static bool IsValid<T>(this T component_) where T : Component
    {
        Component convert = (Component)(component_ as Component);
        bool isValid = convert == null || convert == default;
        return !isValid;
    }

    public static bool IsValid<T>(this List<T> list_)
    {
        bool isValid = list_ == null || list_.Count < 1;
        return !isValid;
    }


}
