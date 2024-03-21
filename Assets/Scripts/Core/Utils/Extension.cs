﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Extension
{
	public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component
	{
		return Util.GetOrAddComponent<T>(go);
	}

    public static T FindChild<T>(this GameObject go) where T : UnityEngine.Object
    {
        return Util.FindChild<T>(go);
    }

    public static bool IsValid(this GameObject go)
	{
		return go != null && go.activeSelf;
	}
}
