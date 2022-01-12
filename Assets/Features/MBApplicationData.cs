using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mb
{
    public class MBApplicationData : MonoBehaviour
    {
        public static string KEY_AccessToken = "AccessToken";
        string accessToken;
        static MBApplicationData mInstance;
        public int selectedCategoryID;
        public static MBApplicationData Instance
        {
            get
            {
                if (mInstance == null)
                {
                    GameObject tobj = new GameObject();
                    tobj.name = "MBApplicationData";
                    DontDestroyOnLoad(tobj);
                    mInstance = tobj.AddComponent<MBApplicationData>();
                    mInstance.Initialized();
                }
                return mInstance;
            }
        }

        void Initialized()
        {
            accessToken = PlayerPrefs.GetString(KEY_AccessToken, "");
            Application.runInBackground = true;
        }


        public string AccessToken
        {
            get
            {
                return accessToken;
            }
            set
            {
                accessToken = value;
                PlayerPrefs.SetString(KEY_AccessToken, accessToken);
            }
        }


    }

}
