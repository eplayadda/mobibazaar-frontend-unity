using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mb;
using System.Linq;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    public GameObject category_ProtoType;
    public Activation loadingPanel;
    public Transform parent;
    public string categoryListPath;
    CategoryList categoryList;
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
        GetCategoryData();
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
    void ShowCategoies(int parentID = 0)
    {
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
        categaries.Clear();
    }
    void SetecedCategory(CategoryViews categoryView)
    {
      //  loadingPanel.OnActivation();
        Debug.Log("Selected Category ::"+ categoryView.category.id);
        var subCategories = categoryList.categories.Where(x => x.parent_id == categoryView.category.id).ToList();
        if(subCategories.Count>0)
        {
            //  loadingPanel.OnDeactivation();
            DestoryCategory();
            ShowCategoies(categoryView.category.id);
        }
        else
        {

        }

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
