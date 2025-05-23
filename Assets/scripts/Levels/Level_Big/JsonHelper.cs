//Dieser Teil vom Code wurde nur fürs ausprobieren genutzt, nicht relevant für die Funktionsfähigkeit vom ganzem.
using System;
using UnityEngine;

public static class JsonHelper
{
    public static T[] FromJsonArray<T>(string json)
    {
        string wrappedJson = "{\"Items\":" + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(wrappedJson);
        return wrapper.Items;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}