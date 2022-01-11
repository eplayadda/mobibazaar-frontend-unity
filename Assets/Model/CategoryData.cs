using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace mb
{
    [SerializeField]

    public class CategoryData : MonoBehaviour
    {
        Category[] categories;
    }
    [SerializeField]
    public class Category
    {
        public int id;
        public string categoryName;
        public string description;
        public string imageUrl;
        public int parent_id;
    }

}

