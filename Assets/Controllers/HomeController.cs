using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mb;
using UnityEngine.UI;
using System.IO;

public class HomeController : MonoBehaviour
{
    public GameObject category_ProtoType;
    public Activation loadingPanel;
    public Transform parent;
    public string categoryListPath;
    Router router;
    [HideInInspector] HomeView signUpView;
    public bool isLoggedIn;
    public List<GameObject> categaries = new List<GameObject>();
    private void OnEnable()
    {
        //Checking for login
        loadingPanel.OnActivation();
        isLoggedIn = string.IsNullOrEmpty(MBApplicationData.Instance.AccessToken) ? false : true;
        RenderData();
    }
    private void Awake()
    {
        router = gameObject.GetComponentInParent<Router>();
        signUpView = (HomeView)gameObject.GetComponent<IView>();
        OnClickEvents();
    }

   
    void RenderData()
    {
        signUpView.logOutTxt.text = isLoggedIn ? "LogOut" : "LogIN";
        DisplayCategorys();
    }
    void OnClickEvents()
    {
        signUpView.logOutBtn.onClick.AddListener(() => { OnLogOutClicked(); });
    }


    void DisplayCategorys()
    {
        var response = Resources.Load<TextAsset>(categoryListPath);
        var str = "{\"categories\":" + response.text + "}";
        var loginResponse = JsonUtility.FromJson<Category[]>(str);
        Debug.Log(str);

        //string path = Application.streamingAssetsPath + "/"+ categoryListPath;
        //string contents = File.ReadAllText(path);

        //  var loginResponse = JsonUtility.FromJson<CategoryData>(contents);


        loadingPanel.OnDeactivation();
        for (int i = 0; i < 4; i++)
        {
            GameObject go = Instantiate(category_ProtoType) as GameObject;
            CategoryViews category = go.GetComponent<CategoryViews>();
            Button button = go.GetComponent<Button>();
            category.id = i;
            button.onClick.AddListener(() =>
                SetecedCategory(button.gameObject.GetComponent<CategoryViews>())
            );

            go.transform.SetParent(parent, true);
            categaries.Add(go);
        }
    }

    void DestoryCategory()
    {
        foreach (var item in categaries)
        {
            Destroy(item);
        }
    }
    void SetecedCategory(CategoryViews category)
    {
        loadingPanel.OnActivation();
        Debug.Log("Selected Category ::"+ category.id);
    }
    void OnLogOutClicked()
    {
        isLoggedIn = false;
        MBApplicationData.Instance.AccessToken = "";
        RenderData();
        router.ActivateScreen("Login");
        Debug.Log("LogOut pressed");
    }

}
