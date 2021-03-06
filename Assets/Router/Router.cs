using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Router : MonoBehaviour
{
    Dictionary<string, IView> allScreens = new Dictionary<string, IView>();
    public List<string> activeViews = new List<string>();
    private void Start()
    {
        Screen.SetResolution(Screen.width, Screen.height, false);
        InitRouters();
    }

    void InitRouters()
    {
        var views = gameObject.GetComponentsInChildren<IView>(true);
        foreach (var item in views)
        {
            allScreens.Add(item.GameObjectName(),item);
        }
        ActivateScreen(views[0].GameObjectName());
    }

    public void ActivateScreen(string screenName,string currScreen ="",bool needToDisableCurrent = true)
    {
        var activeView = allScreens.Where(x => x.Value.GameObjectName().Equals(screenName)).FirstOrDefault();
        foreach (var item in allScreens)
        {
            if (!needToDisableCurrent && item.Key.Equals(currScreen))
                continue;
            item.Value.Deactivate();
        }
        activeView.Value.Activate();
        ManageScreenStack(activeView);
    }

    public void BackPressed()
    {
        var count = activeViews.Count;
        if (/*activeViews[count -1].Equals(allScreens.Keys.ElementAt(0)) ||*/ activeViews.Count < 2)
            return;
        string lastScreen = activeViews[activeViews.Count - 2];
        ActivateScreen(lastScreen);

    }
    void ManageScreenStack(KeyValuePair<string, IView> activeView)
    {
        var count = activeViews.Count;
        if (count >1 && activeViews[count - 1].Equals(activeView.Key))
            return;
        activeViews.Add(activeView.Key);
        if (count > 20)
            activeViews.RemoveAt(0);
    }
}
