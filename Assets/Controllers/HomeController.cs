using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mb;
using System.Linq;
using UnityEngine.UI;

public class HomeController : BaseController
{
    public GameObject category_ProtoType;
    public Activation loadingPanel;
    public Transform parent;
    public string categoryListPath;
    CategoryList categoryList;
    [HideInInspector] HomeView signUpView;
    public bool isLoggedIn;

    public List<GameObject> categaries = new List<GameObject>();
    Stack<int> callStack = new Stack<int>(); 
    private void Awake()
    {
        router = gameObject.GetComponentInParent<Router>();
        signUpView = (HomeView)gameObject.GetComponent<IView>();
        OnClickEvents();
        GetCategoryData();
    }
    private void OnEnable()
    {
        //Checking for login
        loadingPanel.OnActivation();
        isLoggedIn = string.IsNullOrEmpty(MBApplicationData.Instance.AccessToken) ? false : true;
        RenderData();
    }
   

   
    void RenderData()
    {
        signUpView.logOutTxt.text = isLoggedIn ? "LogOut" : "LogIN";

        ShowCategoies();
    }
    void OnClickEvents()
    {
        signUpView.logOutBtn.onClick.AddListener(() => { OnLogOutClicked(); });
    }

    void GetCategoryData()
    {
        var response = Resources.Load<TextAsset>(categoryListPath);
        var str = "{\"categories\":" + response.text + "}";
        categoryList = JsonUtility.FromJson<CategoryList>(str);
    }
    void ShowCategoies(int parentID = 0, bool addInList = true)
    {
        DestoryCategory();
        if (addInList)
            callStack.Push(parentID);

        var parentCategories = categoryList.categories.Where(x => x.parent_id == parentID).ToList();
        loadingPanel.OnDeactivation();

        foreach (var item in parentCategories)
        {
            GameObject go = Instantiate(category_ProtoType) as GameObject;
            CategoryViews mCategoryViews = go.GetComponent<CategoryViews>();
            Button button = go.GetComponent<Button>();
            mCategoryViews.category = item;
            button.onClick.AddListener(() =>
                SetecedCategory(button.gameObject.GetComponent<CategoryViews>())
            );

            go.transform.SetParent(parent, false);
            categaries.Add(go);
        }

    }

    void DestoryCategory()
    {
        foreach (var item in categaries)
        {
            Destroy(item);
        }
        categaries.Clear();
    }
    void SetecedCategory(CategoryViews categoryView)
    {
        Debug.Log("Selected Category ::" + categoryView.category.id);
        var subCategories = categoryList.categories.Where(x => x.parent_id == categoryView.category.id).ToList();
        MBApplicationData.Instance.selectedCategoryID = categoryView.category.id;
        if (subCategories.Count > 0)
            ShowCategoies(categoryView.category.id);
        else router.ActivateScreen("Products_List");
    }
    void OnLogOutClicked()
    {
        isLoggedIn = false;
        MBApplicationData.Instance.AccessToken = "";
        RenderData();
        router.ActivateScreen("Login");
        Debug.Log("LogOut pressed");
    }
    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (callStack.Count > 1)
            {
                callStack.Pop();
                ShowCategoies(callStack.Peek(), false);
                Debug.Log("Back Pressed" + transform.name);
            }
            else
                Debug.Log("No Back avilable");
             
        }
    }
}
