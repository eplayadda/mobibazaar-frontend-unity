using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace mb
{


    [Serializable]

    public class Category
    {
        public int id;
        public string categoryName;
        public string description;
        public string imageUrl;
        public int parent_id;
    }
    [Serializable]

    public class CategoryList
    {
        public List<Category> categories;
    }

}

