using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static Dictionary<string, Menu> menus = new Dictionary<string, Menu>();
    public static string currentMenu;
    public static bool inMenu;
    public string menuName;

    public static void LoadMenu(string menu)
    {
        inMenu = true;
        menus[menu].gameObject.SetActive(true);
        currentMenu = menu;
    }

    public static void LeaveMenu()
    {
        if (!inMenu)
        {
            return;
        }
        if (!menus.ContainsKey(currentMenu))
        {
            menus[currentMenu].gameObject.SetActive(false);
        }
        inMenu = false;
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (!menus.ContainsKey(menuName))
        {
            menus.Add(menuName, this);
        }
        else
        {
            menus[menuName] = this;
            Debug.LogError("Duplicate menus.");
        }
        gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        menus.Remove(menuName);
    }
}
