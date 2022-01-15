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
    public Stack<int> callStack = new Stack<int>(); 
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
      //  ResetData();
        loadingPanel.OnActivation();
        isLoggedIn = string.IsNullOrEmpty(MBApplicationData.Instance.AccessToken) ? false : true;
        ShowCategoies(MBApplicationData.Instance.selectedCategoryID);
    }
   

   
    void RenderData()
    {
        signUpView.logOutTxt.text = isLoggedIn ? "LogOut" : "LogIN";
    }
    void OnClickEvents()
    {
        signUpView.logOutBtn.onClick.AddListener(() => { OnButtonClicked("logOutBtn"); });
        signUpView.cartListBtnFooter.onClick.AddListener(() => { OnButtonClicked("cartListBtnFooter"); });
        signUpView.cartListBtnHeader.onClick.AddListener(() => { OnButtonClicked("cartListBtnHeader"); });
        signUpView.menuBtn.onClick.AddListener(() => { OnButtonClicked("menuBtn"); });
        signUpView.orderListBtn.onClick.AddListener(() => { OnButtonClicked("orderListBtn"); });
        signUpView.homeBtn.onClick.AddListener(() => { OnButtonClicked("homeBtn"); });
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
        if(parentCategories.Count>0)
        {
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
        else
        {
            BackAction();
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
        else router.ActivateScreen("Products_List",transform.name,false);
    }
    void OnLogOutClicked()
    {
        isLoggedIn = false;
        MBApplicationData.Instance.AccessToken = "";
        router.ActivateScreen("Login");
        Debug.Log("LogOut pressed");
    }
    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackAction();
        }
    }
    void BackAction()
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
    void ResetData()
    {
        callStack.Clear();
        MBApplicationData.Instance.selectedProductID = 0;
    }
    private void OnDisable()
    {
       // MBApplicationData.Instance.selectedCategoryID = callStack.Peek();

    }
}
